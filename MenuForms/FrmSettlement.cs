using Commission.Business;
using Commission.Forms;
using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Commission.MenuForms
{
    public partial class FrmSettlement : Form
    {
        //用于保存结算主表信息，查询时赋值
        private string SettlePeriod = string.Empty; //结算期间 yyyy-MM
        private string SettleClosingDate = string.Empty; //结算截止日期 yyyy-MM-dd
        bool IsEndMonth;

        public FrmSettlement()
        {
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Settle_Click(object sender, EventArgs e)
        {
            Settlement();
        }

        private void Settlement()
        {
            button_Settle.Enabled = false;

            dataGridView_Settlement.AutoGenerateColumns = false;
            dataGridView_Settlement.DataSource = null;


            SettlePeriod = dateTimePicker_SettlePeriod.Value.ToString("yyyy-MM");
            SettleClosingDate = SettlePeriod + dateTimePicker_CloseDate.Value.ToString("-dd");

            int bindQty = 0;
            DataTable dtContract = GetContractData(SettleClosingDate, out bindQty);

            Transaction.InsertBindCol(dataGridView_Settlement, 15, bindQty);

            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColRecDownPay"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColRecLoan"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColRecDiffer"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColRecDeliver"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColRecLimit"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColRecSettleTotal"], ColType.amount);

            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColCommAll"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColPremiumAll"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColSettleALL"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColNoSettleALL"], ColType.amount); 

            dataGridView_Settlement.DataSource = dtContract;

            button_Settle.Enabled = true;

            if (dataGridView_Settlement.Rows.Count == 0)
                Prompt.Information("没有符合条件的记录");

        }


        public DataTable GetContractData(string closingDate, out int iBindQuantity)
        {
            iBindQuantity = 0;
            
            string sql = string.Empty;

            string condition = string.Format(" select Distinct ContractID from Receipt where SettleState = 0 and Convert(Varchar(10),RecDate,120) <= '{0}' and ProjectID = {1} ", closingDate, Login.User.ProjectID);

            //以收款为基准：收款日期小于截止日期且未结算，签约时间小于截止时间
            sql = "select a.ContractID, a.ContractNum, CustomerName, b.ItemTypeCode, b.ItemTypeName, CONVERT(varchar(10),SubscribeDate,120) SubscribeDate, SubscribeSalesID, SubscribeSalesName,  CONVERT(varchar(10),ContractDate,120) ContractDate, PaymentName,  "
                + " b.ItemID, b.Building, b.Unit, b.ItemNum, b.Area, b.Price, b.Amount, "
                + " DownPayRate, DownPayAmount, Loan, TotalAmount, "
                + " SettleStandardCode, SettleBaseCode, SettleRate, SettleAmount, BottomPrice, BottomPriceLimit, BottomPriceRate "
                + " from ContractMain a "
                + " inner join  ContractDetail b on a.ContractID = b.ContractID "
                + " inner join SaleItem c on b.ItemID = c.ItemID"
                + " where a.ContractDate <= '" + closingDate + "' and b.IsBind = 0 and a.ContractID in (" + condition + ")"
                + " order by a.ContractID ";
            
            //主体表
            DataTable dtContract = SqlHelper.ExecuteDataTable(sql); 
            dtContract.PrimaryKey = new DataColumn[] { dtContract.Columns["ContractID"] };

            //累计收款 --是截止到结算截止日期还是系统时间??? //当前为结算截止日期的累计收款
            sql = string.Format("select ContractID, IsNull(SUM(Amount),0) as ReceiptAll from Receipt where ContractID in ({0}) group by ContractID ", condition);
            DataTable dtReceiptAll = SqlHelper.ExecuteDataTable(sql);
            dtContract.Merge(dtReceiptAll, false, MissingSchemaAction.Add);


            //最后收款日期 － modify by 20190710 ：保证最后收款日期与相应的收款业务员匹配
            sql = "select ContractID, SalesID, SalesName, RecDate as ReceiptDate from Receipt where 1=0";
            DataTable dtReceiptDate = SqlHelper.ExecuteDataTable(sql);

            for (int i = 0; i < dtContract.Rows.Count; i++)
            {
                sql = string.Format("select top 1 ContractID, SalesID, SalesName, RecDate as ReceiptDate from Receipt "
                    + "where ContractID = {0} and SettleState = 0 and Convert(Varchar(10),RecDate,120) <= '{1}' "
                    + "order by RecDate Desc, ID Desc ", dtContract.Rows[i]["ContractID"].ToString(), closingDate);
                DataTable dt = SqlHelper.ExecuteDataTable(sql);
                dtReceiptDate.Rows.Add(dt.Rows[0].ItemArray);  
            }

            dtContract.Merge(dtReceiptDate, false, MissingSchemaAction.Add);

            //可结算收款
            sql = "select ContractID, "
                + " SUM(case TypeCode when '0' then amount else 0 end) RecLoan, "
                + " (SUM(case  when TypeCode = '1' or TypeCode = '2' then amount else 0 end)) RecDownPay, "
                + " SUM(case TypeCode when '3' then amount else 0 end) RecDiffer, "
                + " SUM(case TypeCode when '4' then amount else 0 end) RecDeliver, "
                + " SUM(case TypeCode when '5' then amount else 0 end) RecLimit,"
                + " SUM(case TypeCode when '6' then amount else 0 end) RecRetrun,"
                + " SUM(case when TypeCode != '6' then amount else 0 end) RecSettleTotal"
                + " from Receipt  where contractid is not null and SettleState = 0 and Convert(Varchar(10),RecDate,120) <= '" + closingDate + "' and ProjectID = " + Login.User.ProjectID
                + " group by ContractID ";

            DataTable dtNoSettle = SqlHelper.ExecuteDataTable(sql);
            dtContract.Merge(dtNoSettle, false, MissingSchemaAction.Add);

            //存放佣金数据
            DataTable dtCommission = new DataTable();
            dtCommission.Columns.Add("ContractID", typeof(int));
            dtCommission.Columns.Add("PremiumAll", typeof(int));
            dtCommission.Columns.Add("CommAll", typeof(int));
            dtCommission.Columns.Add("SettleAll", typeof(int));
            dtCommission.Columns.Add("NoSettleAll", typeof(int));
            dtCommission.Columns.Add("Premium", typeof(int));
            dtCommission.Columns.Add("Commission", typeof(int));
            dtCommission.Columns.Add("CommTotal", typeof(int));
            dtCommission.Columns.Add("FirstSettle", typeof(int));



            dtContract.AcceptChanges();
            int firstSettle;
            for (int i = 0; i < dtContract.Rows.Count; i++)
            {
                firstSettle = 0;
                if (IsSetted(dtContract.Rows[i]["ContractID"].ToString()) == false)  //是否已有结算记录，有：直接结算，无：检测达标条件
                {
                    if (IsStandard(dtContract.Rows[i]) == false) //是否达标
                    {
                        dtContract.Rows[i].Delete();
                        continue;
                    }
                    else
                    {
                        firstSettle = 1; //无结算记录且达标，视为首次结算（成销）
                    }
                }

                //计算佣金数据
                object[] commissoinData = CalculateCommssion(dtContract.Rows[i], firstSettle);
                dtCommission.Rows.Add(commissoinData);

            }
            dtContract.AcceptChanges(); //提交删除

            //合并,佣金数据
            dtContract.Merge(dtCommission, false, MissingSchemaAction.Add);

            string formatAmount = "{0:F" + Login.Parameters.PrecisionAmount + "}"; //字段格式
            //获取绑定（附属）物业相关信息
            for (int i = 0; i < dtContract.Rows.Count; i++)
            {
                string subId = dtContract.Rows[i]["ContractID"].ToString();

                sql = "select ItemNum, Area, Price, Amount from ContractDetail where IsBind = 1 and ContractID = " + subId;

                DataTable dtBind = SqlHelper.ExecuteDataTable(sql);

                if (dtBind.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();

                    dt.Columns.Add("ContractID", typeof(int));
                    dt.PrimaryKey = new DataColumn[] { dt.Columns["ContractID"] };

                    string fieldValue = subId;

                    int itemIdx = 0;     //一个房源相同尾号

                    for (int iRow = 0; iRow < dtBind.Rows.Count; iRow++)
                    {
                        for (int iCol = 0; iCol < dtBind.Columns.Count; iCol++) //????考虑：不在重新创建表和字段，主表一次合并，提高效率??
                        {
                            string fieldName = "BIND_" + dtBind.Columns[iCol].ColumnName + itemIdx;
                            dt.Columns.Add(fieldName, typeof(string));

                            if (dtBind.Columns[iCol].ColumnName.Equals("Amount"))
                            {
                                fieldValue += "," + string.Format(formatAmount, dtBind.Rows[iRow][iCol]);
                            }
                            else
                            {
                                fieldValue += "," + dtBind.Rows[iRow][iCol].ToString();
                            }
                        }

                        itemIdx++;

                        if (itemIdx > iBindQuantity)
                            iBindQuantity = itemIdx;
                    }

                    string[] strArray = fieldValue.Split(',');

                    dt.Rows.Add(strArray);

                    dtContract.Merge(dt, false, MissingSchemaAction.Add); //合并至主体表

                }
            }

            return dtContract;
        }


        /// <summary>
        /// 是否达到结算标准
        /// </summary>
        /// <param name="i">索引</param>
        /// <returns></returns>
        private bool IsStandard(DataRow row)
        {
            bool result = false;
            string sql = string.Empty;

            if (string.IsNullOrEmpty(row["SettleStandardCode"].ToString()))
            {
                return false;
            }

            string contractId = row["ContractID"].ToString();

            //检测条件
            int receipt = Convert.ToInt32(row["RecSettleTotal"]); //可结算收款合计
            int receiptAll = Convert.ToInt32(row["ReceiptAll"]);  //累计收款合计

            SettleStandard standardCode = (SettleStandard)row["SettleStandardCode"];  

            switch (standardCode)
            {
                case SettleStandard.ContractAmount:
                    if (receipt >= Convert.ToInt32(row["TotalAmount"]))
                    {
                        result = true;
                    }
                    break;

                case SettleStandard.DownPay:
                    if (receipt >= Convert.ToInt32(row["DownPayAmount"]))
                    {
                        result = true;
                    }
                    break;

                case  SettleStandard.InstallmentFirst:
                    sql = string.Format("select top 1 Amount from Installment  where ContractID = {0} order by Sequence", contractId);
                    object objResult = SqlHelper.ExecuteScalar(sql);
                    if (objResult != null)
                    {
                        if (receipt >= Convert.ToInt32(objResult))
                        {
                            result = true;
                        }
                    }
                    break;

                case SettleStandard.InstallmentStage:
                    result = IsInstallmentStandard(contractId, receiptAll);
                    break;

                default:
                    break;
            }

            return result;

        }

        /// <summary>
        /// 是否有结算记录，有则达标
        /// </summary>
        /// <param name="contractId"></param>
        /// <returns></returns>
        private bool IsSetted(string contractId)
        {
            string sql = string.Empty;
            sql = string.Format("select count(*) from Installment where ContractID = {0}", contractId);
            int result = int.Parse(SqlHelper.ExecuteScalar(sql).ToString());
            if (result > 0)  //是否存分期
            {
                sql = string.Format("select count(*) from Installment where ContractID = {0} and Settled != 0 ", contractId); 
                if ((int.Parse(SqlHelper.ExecuteScalar(sql).ToString()) != 0)) 
                {
                    return true;
                }
            }
            else
            {
                sql = string.Format("select count(*) from Receipt where SettleState > 0 and ContractID = {0}", contractId);
                if (int.Parse(SqlHelper.ExecuteScalar(sql).ToString()) > 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 分期达标检测
        /// </summary>
        /// <param name="contractId"></param>
        /// <param name="receipt"></param>
        /// <returns></returns>
        private bool IsInstallmentStandard(string contractId, int receipt)
        {
            bool result = false;

            List<double[]> listAmount = new List<double[]>();


            //未结算指标
            string sql = string.Format("select Amount,Settled  from Installment where ContractID = {0} order by Sequence", contractId);
            SqlDataReader sdr = SqlHelper.ExecuteReader(sql);

            if (!sdr.HasRows)
                return false;

            int iAmount = 0;
            while (sdr.Read())
            {
                iAmount += Convert.ToInt32(sdr["Amount"]); //指标值累计
                listAmount.Add(new double[] { iAmount, double.Parse(sdr["Settled"].ToString()) });
            }

            listAmount.Reverse(); //从最大值计算

            bool allSettled = true;
            for (int i = 0; i < listAmount.Count; i++)
            {
                if ((listAmount[i][1] == 0))
                {
                    allSettled = false;
                    if (receipt >= listAmount[i][0]) //累计收款金额 大于 未结指标 即符合达标条件
                        return true;
                }
            }

            if ((receipt >= listAmount[0][0]) && allSettled) //大于最大值，且全部结算，如有收款即达标 －－防止中间删除结算
                return true;


            return result;
        }

        /// <summary>
        /// 计算佣金相关数据
        /// </summary>
        /// <param name="row"></param>
        private object[] CalculateCommssion(DataRow row, int firstSettle)
        {
            double premiumAll = 0; //溢价总额
            double commAll = 0;    //佣金总额
            double settleAll = 0;  //累计已结佣金
            double noSettleAll = 0;//未结佣金
            double premium = 0;    //当期溢价
            double commission = 0; //当期佣金
            double commTotal = 0;  //当期应结

            string contractId = row["ContractID"].ToString();
            
            double recSettleTotal = Convert.ToInt32(row["RecSettleTotal"]);         //可结收款总额
            double recPremium = recSettleTotal - Convert.ToInt32(row["RecDiffer"]); //可结收款总额，不含补差款
            double totalAmount = Convert.ToInt32(row["TotalAmount"]);               //合同总额
            double recRate = recSettleTotal / totalAmount;                          //回款比例 (含补差款)

            double area = Convert.ToDouble(row["area"]);
            double price = Convert.ToDouble(row["price"]);
            double downPayAmount = Convert.ToDouble(row["DownPayAmount"]);

            double bottomPrice = Convert.ToDouble(row["BottomPrice"]);
            double bottomPriceLimit = Convert.ToDouble(row["BottomPriceLimit"]);
            double bottomPriceRate = Convert.ToDouble(row["BottomPriceRate"]) / 100;

            double settleRate = Convert.ToDouble(row["SettleRate"]) / 100;
            double settleAmount = Convert.ToDouble(row["SettleAmount"]);


            double ReceiptAll = Convert.ToDouble(row["ReceiptAll"]);

            SettleBase baseCode = (SettleBase)(row["SettleBaseCode"]);

            //底价差额 (有限价且底价差额超出限价的，按限价计算)
            double bottomDiffer = price - bottomPrice; //底价差额(实差）

            if (bottomDiffer > 0) //销售单价小于底价的不计算溢价，否则为负数
            {
                if ((bottomPriceLimit > 0) && bottomDiffer > bottomPriceLimit)
                {
                    bottomDiffer = bottomPriceLimit; //（限差）
                }

                //溢价总额 = 面积 * 底价差额 * 溢价提成比例
                premiumAll = Math.Round(area * bottomDiffer * bottomPriceRate, 0, MidpointRounding.AwayFromZero);
            }


            //佣金总额:  无底价 = 合同总额 * 提点 ； 有底价 = (合同总额 - 实溢总额) * 提点，即： (合同总额 - (单价 - 底价) * 面积) * 提点
            if (baseCode == SettleBase.Single)
            {
                commAll = Convert.ToDouble(row["SettleAmount"]);
            }
            else
            {
                if ((bottomPrice > 0) && (bottomDiffer > 0)) //修改溢价为负数问题
                {
                    //没有单独取附属房源信息，所以合同金额减去溢价差额（实差）获取佣金计算基数（差额 = (price - bottomPrice) * area）
                    commAll = Math.Round((totalAmount - (price - bottomPrice) * area) * settleRate, 0, MidpointRounding.AwayFromZero);
                }
                else
                {
                    commAll = Math.Round(totalAmount * settleRate, 0, MidpointRounding.AwayFromZero);
                }
            }


            //累计已结佣金（不含溢价）
            settleAll = Convert.ToDouble(SqlHelper.ExecuteScalar(string.Format("select IsNull(SUM(Commission),0) as SettleAll from SettleDetail where ContractID = {0}", contractId)));


            //未结佣金
            noSettleAll = commAll - settleAll; 

            //当期溢价 = 溢价总额 * 回款比例（不含补差款）
            premium = Math.Round(premiumAll * (recPremium / totalAmount), 0, MidpointRounding.AwayFromZero);

            //当期佣金
            commission = 0;
            switch (baseCode)
            {
                case SettleBase.ContractAmount:
                    if (settleAll == 0)
                    {
                        commission = commAll;
                    }
                    else
                    {
                        if (settleAll < commAll)
                            commission = Math.Round(commAll * recRate, 0, MidpointRounding.AwayFromZero);
                    }
                    break;

                case SettleBase.DownPay:
                    if (settleAll == 0)
                    {
                        commission = downPayAmount * settleRate;
                    }
                    else
                    {
                        if ((ReceiptAll * settleRate) > settleAll) //累计收款小于首付的不算佣金，但小于变更后首付的计算，
                            commission = Math.Round(commAll * recRate, 0, MidpointRounding.AwayFromZero);
                    }
                    break;

                case SettleBase.ReceiptAmount:
                    commission = Math.Round(commAll * recRate, 0, MidpointRounding.AwayFromZero);
                    break;

                case SettleBase.InstallmentStage:  //?????????????????????????????????????
                    commission = Math.Round(GetInstallmentCommission(contractId, recSettleTotal, commAll, totalAmount), 0, MidpointRounding.AwayFromZero);
                    break;

                case SettleBase.Single:
                    if (settleAll < settleAmount)
                        commission = settleAmount;
                    else
                        commission = 0;
                    break;

                default:
                    break;
            }

            //当期应结
            commTotal = premium + commission;

            return new object[] { int.Parse(contractId), (int)premiumAll, (int)commAll, (int)settleAll, (int)noSettleAll, (int)premium, (int)commission, (int)commTotal, firstSettle };
        }


        /// <summary>
        /// 分期可结佣金
        /// </summary>
        /// <param name="contractID"></param>
        /// <param name="recSettleTotal">可结回款</param>
        /// <param name="commAll">佣金总额</param>
        /// <param name="totalAmount">合同总额</param>
        /// <returns></returns>
        private double GetInstallmentCommission(string contractID, double recSettleTotal, double commAll, double totalAmount)
        {
            double result = 0;

            string sql = string.Empty;

            sql = string.Format("select Sequence,Amount, (select SUM(Amount) from Installment b where b.Sequence < a.Sequence and settled = 0 and  ContractID = {0}) as AmountSum "
                + " from Installment a where settled = 0 and  ContractID = {0} order by Sequence ", contractID);

            DataTable dtInstallment = SqlHelper.ExecuteDataTable(sql);


            if (dtInstallment.Rows.Count > 0) //有未结阶段，即存在未达标值
            {
                //分期总额
                sql = string.Format("select ISNULL(SUM(Amount),0)  from Installment where ContractID = {0}", contractID);
                double installmentSum = double.Parse(SqlHelper.ExecuteScalar(sql).ToString());

                //已结分期总额
                sql = string.Format("select ISNULL(SUM(Amount),0)  from Installment where settled != 0 and ContractID = {0}", contractID);
                double installmentSettled = double.Parse(SqlHelper.ExecuteScalar(sql).ToString());


                //累计回款
                sql = string.Format("select ISNULL(SUM(Amount),0) from receipt where ContractID = {0}", contractID);
                double recSum = double.Parse(SqlHelper.ExecuteScalar(sql).ToString());

                if (recSum >= installmentSum)
                {
                    //佣金总额 *（(累计回款-已结分期总额)/合同金额）
                    result = commAll * ((recSum - installmentSettled) / totalAmount);
                }
                else
                {
                    double stageSum = 0; //阶段汇总
                    for (int i = 0; i < dtInstallment.Rows.Count; i++)
                    {
                        if (recSum > double.Parse(dtInstallment.Rows[i]["AmountSum"].ToString()))
                        {
                            stageSum += double.Parse(dtInstallment.Rows[i]["Amount"].ToString());
                        }
                    }

                    //佣金总额 * (阶段汇总/合同金额）
                    result = commAll * (stageSum / totalAmount);

                }
            }
            else
            {
                //佣金总额*（未结回款/合同金额）
                result = commAll * (recSettleTotal / totalAmount);
            }




            return result;
        }


        //////////////////////////////////////////////////////////////////////////////////



        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            if (dataGridView_Settlement.Rows.Count <= 0)
            {
                Prompt.Warning("没有结算记录，无法保存！");
                return;
            }

            FrmSettleSave save = new FrmSettleSave();

            save.tabMaker = Login.User.UserName;
            save.tabName = Login.User.ProjectName + "_" + SettlePeriod + "_结算报表";

            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (SaveSettleData(save.tabMaker, save.tabDate, save.tabName))
                {
                    DataTable dt = (DataTable)dataGridView_Settlement.DataSource;
                    dt.Rows.Clear();
                    dataGridView_Settlement.DataSource = dt;

                    Prompt.Information("操作成功");
                }
            }
        }

        /// <summary>
        /// 保存结算表
        /// </summary>
        /// <param name="tabMaker"></param>
        /// <param name="tabDate"></param>
        /// <param name="tabName"></param>
        /// <returns></returns>
        private bool SaveSettleData(string tabMaker, string tabDate, string tabName)
        {
            bool result = false;

            int errCode = 0;
            string errMsg = string.Empty;

            using (SqlConnection connection = SqlHelper.OpenConnection())  //创建连接对象 
            {
                SqlTransaction sqlTran = connection.BeginTransaction();    //开始事务 
                SqlCommand cmd = connection.CreateCommand();               //创建SqlCommand对象 
                cmd.Transaction = sqlTran;                                 //将SqlCommand与SqlTransaction关联起

                try
                {
                    errCode = 1;
                    //添加结算主表
                    string settleId = string.Empty;
                    string values = "'" + tabName + "'," + Login.User.ProjectID + ",'" + Login.User.ProjectName + "','" + SettlePeriod +"','" + SettleClosingDate +"','" + tabDate + "','" + tabMaker + "',GETDATE(),'" + Login.User.UserName + "'";
                    cmd.CommandText = string.Format("insert into SettleMain (TableName, ProjectID, ProjectName, SettlePeriod, ClosingDate, SettleDate, TableMaker, MakeDate, UserName) output inserted.SettleID values ({0})", values);
                    settleId = cmd.ExecuteScalar().ToString();

                    errCode = 2;
                    //添加结算从表
                    DataTable dt_settle = (DataTable)dataGridView_Settlement.DataSource;

                    string fields = "insert into SettleDetail (SettleID,ContractID, ContractNum, CustomerName,ItemTypeCode, ItemTypeName, "
                        + " SubscribeDate, SubscribeSalesID, SubscribeSalesName, ContractDate,PaymentName,ReceiptDate, SalesID, SalesName,"
                        + " ItemID, Building, Unit,ItemNum, Area, Price,Amount,DownPayRate, DownPayAmount, Loan, TotalAmount, "
                        + " SettleStandardCode, SettleBaseCode, SettleRate, SettleAmount, BottomPrice, BottomPriceLimit, BottomPriceRate, "
                        + " RecLoan,RecDownPay,RecDiffer,RecDeliver,RecLimit,RecSettleTotal,PremiumAll,CommAll,SettleAll,NoSettleAll,Premium,Commission,CommTotal,FirstSettle) values ";

                    for (int i = 0; i < dt_settle.Rows.Count; i++)
                    {
                        values = string.Empty;
                        string contractId = dt_settle.Rows[i]["ContractID"].ToString();

                        values = settleId + "," + contractId
                            + ",'" + dt_settle.Rows[i]["ContractNum"].ToString() + "'"
                            + ",'" + dt_settle.Rows[i]["CustomerName"].ToString() + "'"
                            + "," + dt_settle.Rows[i]["ItemTypeCode"].ToString()
                            + ",'" + dt_settle.Rows[i]["ItemTypeName"].ToString() + "'"
                            + ",'" + dt_settle.Rows[i]["SubscribeDate"].ToString() + "'"  
                            + "," + dt_settle.Rows[i]["SubscribeSalesID"].ToString()
                            + ",'" + dt_settle.Rows[i]["SubscribeSalesName"].ToString() + "'"
                            + ",'" + dt_settle.Rows[i]["ContractDate"].ToString() + "'"
                            + ",'" + dt_settle.Rows[i]["PaymentName"].ToString() + "'"
                            + ",'" + dt_settle.Rows[i]["ReceiptDate"].ToString() + "'"
                            + "," + dt_settle.Rows[i]["SalesID"].ToString()
                            + ",'" + dt_settle.Rows[i]["SalesName"].ToString() + "'"
                            + "," + dt_settle.Rows[i]["ItemID"].ToString()
                            + ",'" + dt_settle.Rows[i]["Building"].ToString() + "'"
                            + ",'" + dt_settle.Rows[i]["Unit"].ToString() + "'"
                            + ",'" + dt_settle.Rows[i]["ItemNum"].ToString() + "'"
                            + "," + dt_settle.Rows[i]["Area"].ToString()
                            + "," + dt_settle.Rows[i]["Price"].ToString()
                            + "," + dt_settle.Rows[i]["Amount"].ToString()
                            + "," + dt_settle.Rows[i]["DownPayRate"].ToString()
                            + "," + dt_settle.Rows[i]["DownPayAmount"].ToString()
                            + "," + dt_settle.Rows[i]["Loan"].ToString()
                            + "," + dt_settle.Rows[i]["TotalAmount"].ToString()
                            + "," + dt_settle.Rows[i]["SettleStandardCode"].ToString()
                            + "," + dt_settle.Rows[i]["SettleBaseCode"].ToString()
                            + "," + dt_settle.Rows[i]["SettleRate"].ToString()
                            + "," + dt_settle.Rows[i]["SettleAmount"].ToString()
                            + "," + dt_settle.Rows[i]["BottomPrice"].ToString()
                            + "," + dt_settle.Rows[i]["BottomPriceLimit"].ToString()
                            + "," + dt_settle.Rows[i]["BottomPriceRate"].ToString()
                            + "," + dt_settle.Rows[i]["RecLoan"].ToString()
                            + "," + dt_settle.Rows[i]["RecDownPay"].ToString()
                            + "," + dt_settle.Rows[i]["RecDiffer"].ToString()
                            + "," + dt_settle.Rows[i]["RecDeliver"].ToString()
                            + "," + dt_settle.Rows[i]["RecLimit"].ToString()
                            + "," + dt_settle.Rows[i]["RecSettleTotal"].ToString()
                            + "," + dt_settle.Rows[i]["PremiumAll"].ToString()
                            + "," + dt_settle.Rows[i]["CommAll"].ToString()
                            + "," + dt_settle.Rows[i]["SettleAll"].ToString()
                            + "," + dt_settle.Rows[i]["NoSettleAll"].ToString()
                            + "," + dt_settle.Rows[i]["Premium"].ToString()
                            + "," + dt_settle.Rows[i]["Commission"].ToString()
                            + "," + dt_settle.Rows[i]["CommTotal"].ToString()
                            + "," + dt_settle.Rows[i]["FirstSettle"].ToString();


                        cmd.CommandText = fields + "(" + values + ")";
                        errMsg = cmd.CommandText;
                        cmd.ExecuteNonQuery();

                        errCode = 3;

                        Console.WriteLine(dt_settle.Rows[i]["CustomerName"].ToString() +'-'+ dt_settle.Rows[i]["SettleStandardCode"].ToString() + '－' + dt_settle.Rows[i]["SettleBaseCode"].ToString());

                        Console.WriteLine("" + contractId);

                        if ((SettleStandard)dt_settle.Rows[i]["SettleStandardCode"] == SettleStandard.InstallmentFirst)
                        {
                            if (dt_settle.Rows[i]["FirstSettle"].ToString().Equals("1"))
                            {
                                cmd.CommandText = string.Format("update Installment set Settled = {0} where ContractID = {1} and  Sequence = 1", settleId, dt_settle.Rows[i]["ContractID"].ToString());
                                cmd.ExecuteNonQuery();
                            }
                        }

                        //分期结算：设置分期指标的结算状态,更新为sid
                        if ((SettleStandard)dt_settle.Rows[i]["SettleStandardCode"] == SettleStandard.InstallmentStage)
                        {
                            Double receiptAll = Convert.ToDouble(dt_settle.Rows[i]["ReceiptAll"]);
                            string sequence = installmentStandard(contractId, receiptAll);
                            if (int.Parse(sequence) > 0)
                            {
                                cmd.CommandText = string.Format("update Installment set Settled = {0} where ContractID = {1} and Settled = 0 and Sequence <= {2} ", settleId, dt_settle.Rows[i]["ContractID"].ToString(), sequence);
                                cmd.ExecuteNonQuery();
                            }
                        }


                        errCode = 4;
                        //更新收款状态
                        cmd.CommandText = string.Format("update Receipt set SettleState = {0} where  SettleState = 0 and ContractID = {1} and  Convert(Varchar(10),RecDate,120)  <= '{2}'", settleId, contractId, SettleClosingDate);
                        cmd.ExecuteNonQuery();
                    }

                    sqlTran.Commit();  //事务提交
                    connection.Close();

                    result = true;
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();  //异常事务回滚
                    Prompt.Error("操作失败， 错误：" + ex.Message);
                    Prompt.Error("Error Code = " + errCode.ToString() + "\r\n" + errMsg);
                }
            }
            return result;
        }

        /// <summary>
        /// 分期结算标准值
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="contractID"></param>
        /// <returns></returns>
        private string installmentStandard(string contractID, Double receiptAll)
        {
            string result = "0";

            string sql = string.Empty;

            List<string[]> listAmount = new List<string[]>();
            double iAmount = 0;
            sql = string.Format("select Sequence,Amount from Installment where Settled = 0  and  ContractID = {0} order by Sequence", contractID);
            SqlDataReader sdr = SqlHelper.ExecuteReader(sql);

            while (sdr.Read())
            {
                //累计收款数 > 指标累计，按符合条件的序号进行更新
                iAmount += double.Parse(sdr["Amount"].ToString()); //指标值累计
                if ((receiptAll < iAmount))
                {
                    result = sdr["Sequence"].ToString();
                }
            }
            sdr.Close();

            return result;
        }


        //////////////////////////////////////////////////////////////////////////////////



        private void FrmSettlement_Load(object sender, EventArgs e)
        {
            object objResult = SqlHelper.ExecuteScalar(string.Format("select ClosingDate from ParaSettle where ProjectID = {0}",Login.User.ProjectID));
            if (objResult == null)
            {
                IsEndMonth = true;
                dateTimePicker_CloseDate.Value = Convert.ToDateTime(DateTime.Now.AddMonths(1).ToString("yyyy-MM-01")).AddDays(-1);
            }
            else
            {
                IsEndMonth = false;
                dateTimePicker_CloseDate.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-") + objResult.ToString());
            }
        }

        private void dateTimePicker_ContractDate_ValueChanged(object sender, EventArgs e)
        {
            if (IsEndMonth)
            {
                dateTimePicker_CloseDate.Value = Convert.ToDateTime(dateTimePicker_SettlePeriod.Value.AddMonths(1).ToString("yyyy-MM-01")).AddDays(-1);
            }
            else
            {
                dateTimePicker_CloseDate.Value = Convert.ToDateTime(dateTimePicker_SettlePeriod.Value.ToString("yyyy-MM-") + dateTimePicker_CloseDate.Value.ToString("dd"));
            }
        }

        private void toolStripButton_Export_Click(object sender, EventArgs e)
        {
            Common.Exp2XLS(dataGridView_Settlement);
        }


    }
}
