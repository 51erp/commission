using Commission.Business;
using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Commission.Report
{
    public partial class RepReceive : Form
    {
        public RepReceive()
        {
            InitializeComponent();
            GenDataGridViewBaseStru();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Export_Click(object sender, EventArgs e)
        {
            Common.Exp2XLS(dataGridView_Report);
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string beginDate = dateTimePicker_Period.Value.ToString("yyyy-MM-01");
            string endDate = DateTime.Parse(beginDate).AddMonths(1).AddDays(-1).ToString("yyy-MM-dd");

            //MessageBox.Show("BeginDate: " + beginDate + "\n\r" + "EndDate   : " + endDate);

            GenDataGridViewBaseStru();

            DataTable dtBase = GetBaseData(beginDate, endDate);


            int iQuantity = 0;

            //附属房源认购信息
            iQuantity = GetBindData(dtBase, "Subscribe");
            InsertBindCol(dataGridView_Report, "SubTotalAmount", iQuantity, "Subscribe");

            //附属房源签约信息
            iQuantity = GetBindData(dtBase, "Contract");
            InsertBindCol(dataGridView_Report, "TotalAmount", iQuantity, "Contract");

            dataGridView_Report.DataSource = dtBase;

            if (dataGridView_Report.Rows.Count == 0)
                Prompt.Warning("没有符合查询条件的记录！");
        }

        private void GenDataGridViewBaseStru()
        {
            dataGridView_Report.AutoGenerateColumns = false;
            dataGridView_Report.DataSource = null;

            string fieldsName = "ContractID, Building, Unit, ItemNum,ItemTypeName,CustomerName,CustomerPhone,SubscribeSalesName,SalesName,"
               + "SubscribeNum,SubscribeDate,SubArea,SubPrice,SubAmount,SubTotalAmount,"
               + "ContractNum,ContractDate,Area,Price,Amount,TotalAmount,DownPayAmount,Loan,"
               + "PreRecTotalAmt,PeriodRecLoan,PeriodRecDownPay,PeriodRecDiffer,PeriodRecDeliver,PeriodRecLimit,PeriodRecTotal,"
               + "PaymentName,DownPayRate,LastRecDate,ReceiptTotalAmt,NoReceiptTotalAmt,"
               + "ExtField0,ExtField1,ExtField2,ExtField3,ExtField4,ExtField5,ExtField6,ExtField7,ExtField8,ExtField9";

            string headerText = "ContractID,楼号,单元,房号,房产类型,客户名称,客户电话,认购置业顾问,现置业顾问,"
                + "认购编号,认购日期,认购面积,认购单价,认购总价,认购总额,"
                + "签约编号,签约日期,签约面积,签约单价,签约总价,签约总额,应付首付,贷款金额,"
                + "当期之前回款,当期放贷,当期首付,当期补差,当期交房,当期限价,当期合计,"
                + "付款方式,首付比例(%),回款日期,截止当期已收,截止当期未收,"
                + "备注0,备注1,备注2,备注3,备注4,备注5,备注6,备注7,备注8,备注9";

            string[] arrFieldName = fieldsName.Split(',');
            string[] arrHeadText = headerText.Split(',');

            dataGridView_Report.ColumnCount = arrFieldName.Length;

            string fieldName = string.Empty;
            for (int i = 0; i < dataGridView_Report.ColumnCount; i++)
            {
                fieldName = arrFieldName[i].ToString();

                dataGridView_Report.Columns[i].Name = fieldName;
                dataGridView_Report.Columns[i].DataPropertyName = fieldName;
                dataGridView_Report.Columns[i].HeaderText = arrHeadText[i].ToString();
            }

            dataGridView_Report.Columns["ContractID"].Visible = false;


            Common.SetColumnStyle(dataGridView_Report.Columns["SubArea"], ColType.area);
            Common.SetColumnStyle(dataGridView_Report.Columns["Area"], ColType.area);

            Common.SetColumnStyle(dataGridView_Report.Columns["SubPrice"], ColType.price);
            Common.SetColumnStyle(dataGridView_Report.Columns["Price"], ColType.price);

            Common.SetColumnStyle(dataGridView_Report.Columns["SubAmount"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Report.Columns["SubTotalAmount"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Report.Columns["Amount"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Report.Columns["TotalAmount"], ColType.amount);

            Common.SetColumnStyle(dataGridView_Report.Columns["DownPayRate"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Report.Columns["ReceiptTotalAmt"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Report.Columns["NoReceiptTotalAmt"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Report.Columns["DownPayAmount"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Report.Columns["Loan"], ColType.amount);

            Common.SetColumnStyle(dataGridView_Report.Columns["PreRecTotalAmt"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Report.Columns["PeriodRecLoan"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Report.Columns["PeriodRecDownPay"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Report.Columns["PeriodRecDiffer"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Report.Columns["PeriodRecDeliver"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Report.Columns["PeriodRecLimit"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Report.Columns["PeriodRecTotal"], ColType.amount);

            //dataGridView_Report.Columns["CustomerPhone"].Frozen = true;
            
        }

        private DataTable GetBaseData(string beginDate, string endDate)
        {
            DataTable dtBase;

            string sql = string.Empty;
            
            sql = string.Format("select a.ContractID, c.SubscribeNum, a.ContractNum,a.SubscribeDate, a.ContractDate,a.CustomerName, a.CustomerPhone,a.SubscribeSalesName,a.SalesName, "
                + " a.PaymentName,a.DownPayRate, a.DownPayAmount,a.Loan,a.TotalAmount, '' as RecDate, "
                + " b.ItemTypeName, b.Building, b.Unit,b.ItemNum, b.Area, b.Price,b.Amount, "
                + " d.Area as SubArea, d.Price as SubPrice, d.Amount as SubAmount, c.TotalAmount as SubTotalAmount, "
                + " a.ExtField0,a.ExtField1,a.ExtField2,a.ExtField3,a.ExtField4,a.ExtField5,a.ExtField6,a.ExtField7,a.ExtField8,a.ExtField9 "
                + " from ContractMain a "
                + " inner join ContractDetail b on b.ContractID = a.ContractID "
                + " inner join SubscribeMain c on c.ContractID = a.ContractID "
                + " inner join SubscribeDetail d on d.SubscribeID = c.SubscribeID "
                + " where  b.IsBind = 0 and d.IsBind = 0 and a.projectid = {0}", Login.User.ProjectID);

            dtBase = SqlHelper.ExecuteDataTable(sql);
            dtBase.PrimaryKey = new DataColumn[] { dtBase.Columns["ContractID"] };

            
            //当期收款信息
            sql = string.Format("select ContractID, "
              + " SUM(case TypeCode when '0' then amount else 0 end) PeriodRecLoan, "
              + " (SUM(case TypeCode when '1' then amount else 0 end) + SUM(case TypeCode when '2' then amount else 0 end)) PeriodRecDownPay,"
              + " SUM(case TypeCode when '3' then amount else 0 end) PeriodRecDiffer, "
              + " SUM(case TypeCode when '4' then amount else 0 end) PeriodRecDeliver, "
              + " SUM(case TypeCode when '5' then amount else 0 end) PeriodRecLimit,"
              + " SUM(amount) PeriodRecTotal"
              + " from Receipt  where contractid is not null and  Convert(Varchar(10),RecDate,120) >= '{0}'and Convert(Varchar(10),RecDate,120) <= '{1}' and ProjectID = {2} "
              + " group by ContractID ", beginDate, endDate, Login.User.ProjectID);

            DataTable dtReceipt = SqlHelper.ExecuteDataTable(sql);

            Console.WriteLine("Start:" + dtBase.Rows.Count);
            for (int i = 0; i < dtBase.Rows.Count; i++)
            {
                DataRow[] dr = dtReceipt.Select("ContractID = " + dtBase.Rows[i]["ContractID"].ToString());
                if (dr.Length == 0)
                {
                    dtBase.Rows[i].Delete();
                    Console.WriteLine("Count-" + dtBase.Rows.Count);
                }
            }

            dtBase.AcceptChanges();

            dtBase.Merge(dtReceipt, false, MissingSchemaAction.Add);

            //当期之前回款
            sql = string.Format("select ContractID, ISNULL(SUM(Amount),0) as PreRecTotalAmt from Receipt where ContractID is not null and RecDate < '{0}' and ProjectID = {1} group by ContractID ", beginDate, Login.User.ProjectID);
            DataTable dtPreRec = SqlHelper.ExecuteDataTable(sql);

            for (int i = 0; i < dtPreRec.Rows.Count; i++)
            {
                DataRow[] dr = dtBase.Select("ContractID = " + dtPreRec.Rows[i]["ContractID"].ToString());
                if (dr.Length == 0)
                {
                    dtPreRec.Rows[i].Delete();
                }
            }
            dtPreRec.AcceptChanges();

            dtBase.Merge(dtPreRec, false, MissingSchemaAction.Add);
            
            //累计已回，累计未回
            sql = string.Format("select a.ContractID , ISNULL(SUM(Amount),0) as ReceiptTotalAmt, TotalAmount - ISNULL(SUM(Amount),0) as NoReceiptTotalAmt from ContractMain a"
                + " inner join Receipt b on b.ContractID = a.ContractID "
                + " where b.ContractID is not null and RecDate <= '{0}' and a.ProjectID = {1} "
                + " group by a.ContractID, TotalAmount", endDate, Login.User.ProjectID);
            DataTable dtRecTotal = SqlHelper.ExecuteDataTable(sql);

            for (int i = 0; i < dtRecTotal.Rows.Count; i++)
            {
                DataRow[] dr = dtBase.Select("ContractID = " + dtRecTotal.Rows[i]["ContractID"].ToString());
                if (dr.Length == 0)
                {
                    dtRecTotal.Rows[i].Delete();
                }
            }
            dtRecTotal.AcceptChanges();

            dtBase.Merge(dtRecTotal, false, MissingSchemaAction.Add);

            //最后收款日期
            sql = string.Format("select ContractID, MAX(RecDate) as LastRecDate from Receipt  where ContractID is not null and RecDate <= '{0}' and ProjectID = {1} group by ContractID", endDate, Login.User.ProjectID);
            DataTable dtReceiptDate = SqlHelper.ExecuteDataTable(sql);

            for (int i = 0; i < dtReceiptDate.Rows.Count; i++)
            {
                DataRow[] dr = dtBase.Select("ContractID = " + dtReceiptDate.Rows[i]["ContractID"].ToString());
                if (dr.Length == 0)
                {
                    dtReceiptDate.Rows[i].Delete();
                }
            }
            dtReceiptDate.AcceptChanges();

            dtBase.Merge(dtReceiptDate, false, MissingSchemaAction.Add);

            return dtBase;
        }


        /// <summary>
        /// 获取绑定房源（一次合并到主表）
        /// </summary>
        /// <param name="dtBase"></param>
        private int GetBindData(DataTable dtBase, string agreement)
        {
            int colQuantity = 0;

            string sql = string.Empty;
            string contractId = string.Empty;

            string prefix = string.Empty;
            string tableName = string.Empty;
            if (agreement.Equals("Subscribe"))
            {
                prefix = "Sub_Bind_";
                sql = "select ItemNum, Area, Price, Amount from SubscribeMain a inner join SubscribeDetail b on b.SubscribeID = a.SubscribeID  where IsBind = 1 and a.ContractID = ";
            }
            if (agreement.Equals("Contract"))
            {
                prefix = "Con_Bind_";
                sql = "select ItemNum, Area, Price, Amount from ContractDetail where IsBind = 1 and ContractID = ";
            }


            dtBase.PrimaryKey = new DataColumn[] { dtBase.Columns["ContractID"] };

            DataTable dtBind = new DataTable();
            dtBind.Columns.Add("ContractID", typeof(int));
            //dtBind.PrimaryKey = new DataColumn[] { dtBind.Columns["ContractID"] };

            for (int i = 0; i < dtBase.Rows.Count; i++)
            {
                contractId = dtBase.Rows[i]["ContractID"].ToString();

                DataTable dtResult = SqlHelper.ExecuteDataTable(sql + contractId);

                //创建列，大于当前列则创建
                if (dtResult.Rows.Count > colQuantity)
                {
                    for (int j = colQuantity; j < dtResult.Rows.Count; j++)
                    {
                        for (int n = 0; n < dtResult.Columns.Count; n++)
                        {
                            string colName = prefix + dtResult.Columns[n].ColumnName + j;
                            dtBind.Columns.Add(colName, dtResult.Columns[n].DataType);
                        }
                    }
                    colQuantity = dtResult.Rows.Count;
                }

                //创建行并赋值
                if (dtResult.Rows.Count > 0)
                {
                    DataRow row = dtBind.NewRow();
                    row["ContractID"] = contractId;

                    for (int m = 0; m < dtResult.Rows.Count; m++)
                    {
                        for (int n = 0; n < dtResult.Columns.Count; n++)
                        {
                            string colName = prefix + dtResult.Columns[n].ColumnName + m;
                            row[colName] = dtResult.Rows[m][n];
                        }
                    }
                    dtBind.Rows.Add(row);
                }
            }

            if (dtBind.Rows.Count > 0)
                dtBase.Merge(dtBind, false, MissingSchemaAction.Add); //合并至主体表

            return colQuantity;
        }

        /// <summary>
        /// 动态插入绑定房源列
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="colName"></param>
        /// <param name="iColQuantity"></param>
        /// <param name="agreement"></param>
        private void InsertBindCol(DataGridView dgv, string colName, int iColQuantity, string agreement)
        {
            if (iColQuantity <= 0)
                return;

            string prefix = string.Empty;
            if (agreement.Equals("Subscribe"))
            {
                prefix = "Sub_Bind_";
            }
            if (agreement.Equals("Contract"))
            {
                prefix = "Con_Bind_";
            }

            int iBeginPos = dgv.Columns[colName].Index;

            //增加BIND字段
            for (int i = 0; i < iColQuantity; i++)
            {
                //房号
                string sItemNum = prefix + "ItemNum" + i.ToString();

                DataGridViewTextBoxColumn itemNum = new DataGridViewTextBoxColumn();
                itemNum.Name = sItemNum;
                itemNum.DataPropertyName = sItemNum;
                itemNum.HeaderText = "储藏间号" + i.ToString();
                dgv.Columns.Insert(iBeginPos++, itemNum);


                //面积
                string sArea = prefix + "Area" + i.ToString();

                DataGridViewTextBoxColumn area = new DataGridViewTextBoxColumn();
                area.Name = sArea;
                area.DataPropertyName = sArea;
                area.HeaderText = "面积" + i.ToString();
                area.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                area.DefaultCellStyle.Format = "F2";
                dgv.Columns.Insert(iBeginPos++, area);


                //单价
                string sPrice = prefix + "Price" + i.ToString();

                DataGridViewTextBoxColumn price = new DataGridViewTextBoxColumn();
                price.Name = sPrice;
                price.DataPropertyName = sPrice;
                price.HeaderText = "单价" + i.ToString();
                price.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                price.DefaultCellStyle.Format = "F4";
                dgv.Columns.Insert(iBeginPos++, price);


                //金额
                string sAmount = prefix + "Amount" + i.ToString();

                DataGridViewTextBoxColumn amount = new DataGridViewTextBoxColumn();
                amount.Name = sAmount;
                amount.DataPropertyName = sAmount;
                amount.HeaderText = "金额" + i.ToString();
                amount.DefaultCellStyle.Format = "F0";
                amount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Columns.Insert(iBeginPos++, amount);
            }
        }
    }
}
