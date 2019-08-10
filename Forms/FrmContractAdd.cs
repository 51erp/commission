using Commission.DataAccess;
using Commission.MenuForms;
using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Commission.Business;

namespace Commission.Forms
{
    public partial class FrmContractAdd : Form
    {
        public FormMode FrmMode = FormMode.add;
        public string ContractID = string.Empty;

        bool isReferSubscibe = false; //是否参照认购业务

        string origContractNum = string.Empty;

        //List<string> lstOrigItemID = new List<string>();

        DataTable dtOrigItemsData = new DataTable();

        Dictionary<string, string> dictSubscribe = new Dictionary<string, string>(); //认购信息

        //付款类型表，避免频繁查询数据库
        PaymentMode PayModeData = new PaymentMode();

        //分期数据表
        DataTable dtInstallment = new DataTable();

        public FrmContractAdd()
        {
            InitializeComponent();
            InitDefComponent();
            initInput();
        }

        private void InitDefComponent()
        {
            //初始化分期表新增列
            dtInstallment.Columns.Add("Sequence", typeof(String));
            dtInstallment.Columns.Add("PayDate", typeof(String));
            dtInstallment.Columns.Add("Amount", typeof(int));
            dtInstallment.Columns.Add("Settled", typeof(String));


            //初始化付款方式数据表
            //string sql = string.Format("select ID, PayType, PayTypeName, DownPayRate, StandardCode, StandardName, BaseCode, BaseName from PaymentMode where ProjectID = {0}", Login.User.ProjectID);
            //dtPayType = SqlHelper.ExecuteDataTable(sql);

            MasterData.setPayment(comboBox_PayMode, ComboBoxType.input);
            this.comboBox_PayMode.SelectedIndexChanged += new System.EventHandler(this.comboBox_PayMode_SelectedIndexChanged);

            MasterData.SetSales(comboBox_Sales, ComboBoxType.input, true);
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void initInput()
        {
            textBox_CusName.Text = "";
            textBox_CusPhone.Text = "";
            textBox_CusPID.Text = "";
            textBox_CusAddr.Text = "";

            textBox_ContractNum.Text = "";
            textBox_TotalAmount.Text = "0";

            textBox_Discount.Text = "";
            textBox_Fund.Text = "0";
            textBox_FormalNum.Text = "";
            textBox_FormalDate.Text = "";


            textBox_ExtField1.Text = "";
            textBox_ExtField2.Text = "";
            textBox_ExtField3.Text = "";
            textBox_ExtField4.Text = "";
            textBox_ExtField5.Text = "";

            
            textBox_DownPay.Text = "0";
            textBox_DownPay.ReadOnly = true;
            textBox_Loan.Text = "0";
            textBox_Loan.ReadOnly = true;

            if (comboBox_PayMode.Items.Count > 0)
                comboBox_PayMode.SelectedIndex = 0;

            dataGridView_SaleItem.Rows.Clear();
        }

        public void OnlyNumeric(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 46 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void comboBox_PayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDownPayBaseRate(true);
        }


        private void textBox_DownPayRate_TextChanged(object sender, EventArgs e)
        {
            getDownPayBaseRate();
        }


        /// <summary>
        /// 获取支付类型编码
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //private PayType GetPayType(string id)
        //{
        //    int result = 0;
        //    if (dtPayType != null)
        //    {

        //        DataRow[] rows = dtPayType.Select("ID = " + id);

        //        int.TryParse(rows[0]["PayType"].ToString(), out result);

        //    }

        //    return (PayType)result;
        //}

        /// <summary>
        /// 获取首付比例
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //private int GetDownPayRate(string id)
        //{
        //    int result = 0;
        //    if (dtPayType != null)
        //    {

        //        DataRow[] rows = dtPayType.Select("ID = " + id);

        //        int.TryParse(rows[0]["DownPayRate"].ToString(), out result);

        //    }

        //    return result;
        //}


        //此功能暂停，允许直接签约和引用后签约时，做操作类型判断，目前仅支持引用签约，故暂停
        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            if (isReferSubscibe)
            {
                Prompt.Information("已引用认购信息，如有改动信息，请修改认购记录后重新引用!");
                return;
            }

            FrmBaseSaleItem saleItem = new FrmBaseSaleItem();

            if (saleItem.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SaleItem item = new SaleItem();

                item.getSaleItemByID(saleItem.saleItemID);

                int index = this.dataGridView_SaleItem.Rows.Add();
                dataGridView_SaleItem.Rows[index].Cells["ColItemID"].Value = item.ItemID;
                dataGridView_SaleItem.Rows[index].Cells["ColItemType"].Value = item.ItemTypeCode;
                dataGridView_SaleItem.Rows[index].Cells["ColTypeName"].Value = item.ItemTypeName;
                dataGridView_SaleItem.Rows[index].Cells["ColBuilding"].Value = item.Building;
                dataGridView_SaleItem.Rows[index].Cells["ColUnit"].Value = item.Unit;
                dataGridView_SaleItem.Rows[index].Cells["ColItemNum"].Value = item.ItemNum;
                dataGridView_SaleItem.Rows[index].Cells["ColArea"].Value = item.Area;
                dataGridView_SaleItem.Rows[index].Cells["ColPrice"].Value = item.Price.ToString();
                dataGridView_SaleItem.Rows[index].Cells["ColAmout"].Value = Math.Round((double.Parse(item.Area) * double.Parse(item.Price)), 0, MidpointRounding.AwayFromZero).ToString("F0");
            }

            getRowsTotalAmount();
        }

        /// <summary>
        /// 行增减时，计算总额 
        /// </summary>
        private void getRowsTotalAmount()
        {
            double sumAmount = 0;

            int countItem = 0;
            double sumArea = 0;


            foreach (DataGridViewRow row in dataGridView_SaleItem.Rows)
            {
                countItem++;

                double area = 0;
                double.TryParse(row.Cells["ColArea"].EditedFormattedValue.ToString(), out area);
                sumArea += area;

                double amount = 0;
                double.TryParse(row.Cells["ColAmout"].EditedFormattedValue.ToString(), out amount);
                sumAmount += amount;
            }

            textBox_TotalAmount.Text = sumAmount.ToString("G");

            getDownPayBaseRate();
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            if (inputValidate())
            {
                //实例付款方式（初始化）
                PayModeData.GetPaymentModeByID(comboBox_PayMode.SelectedValue.ToString());

                if ((PayModeData.PaymentType == PayType.Full) || (PayModeData.PaymentType == PayType.Loan))
                {
                    dtInstallment.Rows.Clear();
                }

                switch (FrmMode)
                {
                    case FormMode.add:
                        InsertData();
                        break;

                    case FormMode.modify:
                        UpdateData();
                        break;

                    case FormMode.exchange:
                        if (isExchange())
                            ExchangeData();
                        else
                            Prompt.Warning("房源没有发生变更，无须保存！");
                        break;

                    case FormMode.view:
                        break;

                    default:
                        break;
                }
            }
        }

        private bool inputValidate()
        {
            bool result = false;

            if ((FrmMode == FormMode.add) || (FrmMode == FormMode.exchange))
            {
                if (Transaction.isExistCode(textBox_ContractNum.Text.Trim()))
                {
                    Prompt.Warning("签约编号已存在,不能重复录入！");
                    return false;
                }
            }

            if (FrmMode == FormMode.modify)
            {
                if (textBox_ContractNum.Text.Trim() != origContractNum)
                {
                    if (Transaction.isExistCode(textBox_ContractNum.Text.Trim()))
                    {
                        Prompt.Warning("签约编号已存在,不能重复录入！");
                        return false;
                    }
                }
            }

            if (comboBox_PayMode.Items.Count <= 0)
            {
                Prompt.Warning("未设置付款方式");
                return false;
            }

            if (comboBox_Sales.Text.Equals(""))
            {
                Prompt.Warning("未设置置业顾问");
                return false;
            }

            if ((PayModeData.PaymentType == PayType.FullInstalment) || (PayModeData.PaymentType == PayType.DownPayInstalment))
            {
                if (dtInstallment.Rows.Count == 0)
                {
                    Prompt.Warning("没有设置分期付款详细记录！");
                    return false;
                }

                int amount = Convert.ToInt32(dtInstallment.Compute("sum(Amount)", ""));

                int payment = int.Parse(textBox_DownPay.Text);

                if (payment != amount)
                {
                    Prompt.Warning("应付首付与分期付款总额不符！");
                    return false;
                }
            }

            if (textBox_Fund.Text.Trim().Equals(""))
            {
                textBox_Fund.Text = "0";
            }
            else
            {
                double fund = 0;
                if (!double.TryParse(textBox_Fund.Text.Trim(), out fund))
                {
                    Prompt.Warning("请填写有效维修基金金额");
                    textBox_Fund.Focus();
                    return false;
                }
            }



            double dpRate = 0;
            double downPay = 0;
            double loan = 0;

            double.TryParse(textBox_DownPayRate.Text, out dpRate);
            double.TryParse(textBox_DownPay.Text, out downPay);
            double.TryParse(textBox_Loan.Text, out loan);

            if (textBox_CusName.Text.Trim().Equals(""))
            {
                Prompt.Warning("客户信息不能为空！");
            }
            else if (dataGridView_SaleItem.Rows.Count == 0)
            {
                Prompt.Warning("房产信息不能为空！");
            }
            else if (textBox_ContractNum.Text.Trim() == "")
            {
                Prompt.Warning("签约编号不能为空！");
                textBox_ContractNum.Focus();
            }
            else if (textBox_DownPayRate.Text.Trim().Equals(""))
            {
                Prompt.Warning("首付比例不能为空！");
                textBox_DownPayRate.Focus();
            }
            else if (textBox_DownPay.Text.Trim().Equals(""))
            {
                Prompt.Warning("首付金额不能为空！");
                textBox_DownPay.Focus();
            }
            else if (textBox_Loan.Text.Trim().Equals(""))
            {
                Prompt.Warning("贷款金额不能为空！");
                textBox_Loan.Focus();
            }
            else if ((PayModeData.PaymentType == PayType.Loan) || (PayModeData.PaymentType == PayType.DownPayInstalment))
            {
                if (dpRate == 0)
                {
                    Prompt.Warning("首付比例不能为空或零！");
                    textBox_DownPayRate.Focus();
                }
                else if (downPay == 0)
                {
                    Prompt.Warning("首付金额不能为空或零！");
                    textBox_DownPay.Focus();
                }
                else if (loan == 0)
                {
                    Prompt.Warning("贷款金额不能为空或零！");
                    textBox_Loan.Focus();
                }
                else
                {
                    result = true;
                }
            }
            else
            {
                result = true;
            }

            return result;
        }

        private bool isExchange()
        {
            bool result = false;

            for (int i = 0; i < dtOrigItemsData.Rows.Count; i++)
            {
                string orig = dtOrigItemsData.Rows[i]["ItemID"].ToString();
                string curr = dataGridView_SaleItem.Rows[i].Cells["ColItemID"].Value.ToString();

                if (!orig.Equals(curr))
                {
                    return true;
                }
            }
            return result;
        }


        /// <summary>
        /// 新增
        /// </summary>
        private void InsertData()
        {
            string errSQL = string.Empty;
            int errCode = 0;
            using (SqlConnection connection = SqlHelper.OpenConnection())  //创建连接对象 
            {
                SqlTransaction sqlTran = connection.BeginTransaction();    //开始事务 
                SqlCommand cmd = connection.CreateCommand();               //创建SqlCommand对象 
                cmd.Transaction = sqlTran;                                 //将SqlCommand与SqlTransaction关联起

                try
                {

                    errCode = 1;
                    //业务主表
                    cmd.CommandText = GenInsertSqlContractMain();
                    errSQL = cmd.CommandText ;
                    string contractId = cmd.ExecuteScalar().ToString();

                    errCode = 2;
                    //业务从表
                    for (int i = 0; i < dataGridView_SaleItem.Rows.Count; i++)
                    {
                        //添加房源
                        cmd.CommandText = GenInsertSqlContractDetail(i, contractId);
                        cmd.ExecuteNonQuery();
                        
                        //设置房源状态
                        string itemId = dataGridView_SaleItem.Rows[i].Cells["ColItemID"].Value.ToString();
                        bool isBind = Convert.ToBoolean(dataGridView_SaleItem.Rows[i].Cells["ColIsBind"].Value);

                        cmd.CommandText = GenUpdateSqlSaleItem(itemId, isBind);
                        cmd.ExecuteNonQuery();
                    }

                    errCode = 3;
                    //保存分期付款设置
                    for (int i = 0; i < dtInstallment.Rows.Count; i++)
                    {
                        cmd.CommandText = string.Format("insert into Installment (ContractID, Sequence,Amount, PayDate) values ({0},{1},{2},'{3}')",
                            contractId, dtInstallment.Rows[i]["Sequence"].ToString(), dtInstallment.Rows[i]["Amount"].ToString(), dtInstallment.Rows[i]["PayDate"].ToString());

                        cmd.ExecuteNonQuery();
                    }

                    errCode = 4;
                    //更新认购引用的签约信息
                    cmd.CommandText = string.Format("update SubscribeMain set ContractID = {0} where SubscribeID = {1}", contractId, dictSubscribe["SubscribeID"]);
                    cmd.ExecuteNonQuery();

                    errCode = 5;
                    //更新定金信息
                    cmd.CommandText = string.Format("update receipt set ContractID = {0} where SubscribeID = {1}", contractId, dictSubscribe["SubscribeID"]);
                    cmd.ExecuteNonQuery();

                    sqlTran.Commit();  //事务提交

                    (this.Owner as FrmContract).Search(" and  ContractDetail.ContractID = " + contractId);

                    initInput();

                    if (MessageBox.Show("操作成功！是否继续添加？", Common.MsgCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    {
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();  //异常事务回滚
                    Prompt.Error("操作失败! Error Code = " + errCode.ToString() + "\r\n错误信息：" + ex.Message);
                    Prompt.Error(errSQL);
                }

            }
        }

        /// <summary>
        /// 业务主表SQL构建
        /// </summary>
        /// <param name="conCode"></param>
        /// <returns></returns>
        private string GenInsertSqlContractMain()
        {
            string sql = string.Empty;

            string fields = "SubscribeID, SubscribeDate, SubscribeSalesID, SubscribeSalesName, ContractNum, ProjectID, ProjectName, CustomerID, CustomerName, CustomerPhone, ContractDate, "
                + " PaymentID, PaymentName, PaymentType, DownPayRate, DownPayAmount, Loan, TotalAmount, Discount, Fund, FormalNum, FormalDate, "
                + " SalesID, SalesName, MakeDate, UserID, UserName, "
                + " ExtField0,ExtField1,ExtField2,ExtField3,ExtField4,ExtField5,ExtField6,ExtField7,ExtField8,ExtField9 ";

            string values = dictSubscribe["SubscribeID"]
                + ",'" + dictSubscribe["SubscribeDate"] + "'"
                + "," + dictSubscribe["SubscribeSalesID"]
                + ",'" + dictSubscribe["SubscribeSalesName"] + "'"
                + ",'" + textBox_ContractNum.Text.Trim() + "'"
                + "," + Login.User.ProjectID
                + ",'" + Login.User.ProjectName + "'"
                + "," + textBox_CusName.Tag
                + ",'" + textBox_CusName.Text.Trim() + "'"
                + ",'" + textBox_CusPhone.Text.Trim() + "'"
                + ",'" + dateTimePicker_ContractDate.Value.ToString("yyyy-MM-dd") +"'"
                + "," + comboBox_PayMode.SelectedValue.ToString()
                + ",'" + comboBox_PayMode.Text + "'"
                + "," + Transaction.GetPayType(comboBox_PayMode.SelectedValue.ToString()).ToString()
                + "," + textBox_DownPayRate.Text.ToString()
                + "," + textBox_DownPay.Text.ToString()
                + "," + textBox_Loan.Text.ToString()
                + "," + textBox_TotalAmount.Text.Trim()
                + ",'" + textBox_Discount.Text.Trim() + "'"
                + "," + textBox_Fund.Text.Trim()
                + ",'" + textBox_FormalNum.Text.Trim() + "'"
                + ",'" + textBox_FormalDate.Text.Trim() + "'"
                + "," + comboBox_Sales.SelectedValue.ToString()
                + ",'" + comboBox_Sales.Text + "'"
                + ",convert(varchar(10),getdate(), 120)"
                + "," +Login.User.UserID
                + ",'" + Login.User.UserName + "'"
                + ",'" + textBox_ExtField0.Text.Trim() + "'"
                + ",'" + textBox_ExtField1.Text.Trim() + "'"
                + ",'" + textBox_ExtField2.Text.Trim() + "'"
                + ",'" + textBox_ExtField3.Text.Trim() + "'"
                + ",'" + textBox_ExtField4.Text.Trim() + "'"
                + ",'" + textBox_ExtField5.Text.Trim() + "'"
                + ",'" + textBox_ExtField6.Text.Trim() + "'"
                + ",'" + textBox_ExtField7.Text.Trim() + "'"
                + ",'" + textBox_ExtField8.Text.Trim() + "'"
                + ",'" + textBox_ExtField9.Text.Trim() + "'";

            sql = string.Format("insert into [ContractMain] ({0}) output inserted.ContractID  values ({1})", fields, values);

            return sql;
        }


        /// <summary>
        /// 业务从表SQL构建
        /// </summary>
        /// <param name="contractId"></param>
        /// <param name="contractCode"></param>
        /// <param name="rowid"></param>
        /// <returns></returns>
        private string GenInsertSqlContractDetail(int rowid, string contractId)
        {
            string sql = string.Empty;

            string amount = dataGridView_SaleItem.Rows[rowid].Cells["ColAmout"].Value.ToString();

            string fields = "RowID, ContractID, ItemTypeCode, ItemTypeName, IsBind, ItemID, building, Unit, ItemNum, Area, Price, Amount";
            string values = rowid
                + "," + contractId
                + "," + dataGridView_SaleItem.Rows[rowid].Cells["ColItemTypeCode"].Value.ToString()
                + ",'" + dataGridView_SaleItem.Rows[rowid].Cells["ColItemTypeName"].Value.ToString() + "'"
                + ",'" + dataGridView_SaleItem.Rows[rowid].Cells["ColIsBind"].Value.ToString() + "'"
                + "," + dataGridView_SaleItem.Rows[rowid].Cells["ColItemID"].Value.ToString()
                + ",'" + dataGridView_SaleItem.Rows[rowid].Cells["ColBuilding"].Value.ToString() + "'"
                + ",'" + dataGridView_SaleItem.Rows[rowid].Cells["ColUnit"].Value.ToString() + "'"
                + ",'" + dataGridView_SaleItem.Rows[rowid].Cells["ColItemNum"].Value.ToString() + "'"
                + "," + dataGridView_SaleItem.Rows[rowid].Cells["ColArea"].Value.ToString()
                + "," + dataGridView_SaleItem.Rows[rowid].Cells["ColPrice"].Value.ToString()
                + "," + double.Parse(amount, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint).ToString();

            sql = "insert into [ContractDetail] (" + fields + ") values (" + values + ")";

            return sql;
        }

        private string GenInsertSqlSubscribeDetail(int rowid, string subscribeId)
        {
            string sql = string.Empty;

            string amount = dataGridView_SaleItem.Rows[rowid].Cells["ColAmout"].Value.ToString();

            string fields = "RowID, SubscribeID, ItemTypeCode, ItemTypeName, IsBind, ItemID, building, Unit, ItemNum, Area, Price, Amount";
            string values = rowid
                + "," + subscribeId
                + "," + dataGridView_SaleItem.Rows[rowid].Cells["ColItemTypeCode"].Value.ToString()
                + ",'" + dataGridView_SaleItem.Rows[rowid].Cells["ColItemTypeName"].Value.ToString() + "'"
                + ",'" + dataGridView_SaleItem.Rows[rowid].Cells["ColIsBind"].Value.ToString() + "'"
                + "," + dataGridView_SaleItem.Rows[rowid].Cells["ColItemID"].Value.ToString()
                + ",'" + dataGridView_SaleItem.Rows[rowid].Cells["ColBuilding"].Value.ToString() + "'"
                + ",'" + dataGridView_SaleItem.Rows[rowid].Cells["ColUnit"].Value.ToString() + "'"
                + ",'" + dataGridView_SaleItem.Rows[rowid].Cells["ColItemNum"].Value.ToString() + "'"
                + "," + dataGridView_SaleItem.Rows[rowid].Cells["ColArea"].Value.ToString()
                + "," + dataGridView_SaleItem.Rows[rowid].Cells["ColPrice"].Value.ToString()
                + "," + double.Parse(amount, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint).ToString();

            sql = "insert into [SubscribeDetail] (" + fields + ") values (" + values + ")";

            return sql;
        }



        /// <summary>
        /// 构建房源信息更新语句
        /// 销售状态、付款方式（类型）、结算方式、提成比例（提点、跳点)
        /// ？跳点初始值如何设置？
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        private string GenUpdateSqlSaleItem(string itemId, bool isBind, string origSettleValue = null)
        {
            string sql = string.Empty;
            string update = string.Empty;

            if (isBind)
            {
                update = "SaleStateCode = " + ((int)ItemSaleState.签约).ToString()
                    + ", SaleStateName = '" + ItemSaleState.签约 + "'";
            }
            else
            {
                update = "SaleStateCode = " + ((int)ItemSaleState.签约).ToString()
                    + ", SaleStateName = '" + ItemSaleState.签约 + "'"
                    + ", PayModeID = " + comboBox_PayMode.SelectedValue.ToString()
                    + ", PayModeName = '" + comboBox_PayMode.Text + "'"
                    + ", PayTypeCode = " + PayModeData.PayTypeCode
                    + ", PayTypeName = '" + PayModeData.PayTypeName + "'"
                    + ", SettleStandardCode = " + PayModeData.StandardCode
                    + ", SettleStandardName = '" + PayModeData.StandardName + "'"
                    + ", SettleBaseCode = " + PayModeData.BaseCode
                    + ", SettleBaseName = '" + PayModeData.BaseName + "'";

                //获取有效期内的佣金比例
                if (origSettleValue == null)
                {
                    bool isAmount;
                    double result = GetSettleRate(itemId, dictSubscribe["SubscribeDate"].ToString(), out isAmount);
                    if (result > 0)
                    {
                        update += isAmount ? ", SettleAmount = " + result : ", SettleRate = " + result;
                    }
                }
                else
                {
                    update += origSettleValue;
                }
            }

            sql = string.Format("update SaleItem set {0} where ItemID = {1}", update, itemId);

            return sql;
        }

        /// <summary>
        /// 获取结算比例
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="subscribeDate"></param>
        /// <returns></returns>
        private double GetSettleRate(string itemId, string subscribeDate, out bool isAmount)
        {
            isAmount = false;
            double result = 0;

            string sql = string.Empty;

            //提点锁定
            sql = string.Format("select IsLocking from SaleItem where ItemID = {0}", itemId);
            object obj = SqlHelper.ExecuteScalar(sql);
            bool locking = bool.Parse(SqlHelper.ExecuteScalar(sql).ToString());
            if (locking)
            {
                return result;
            }

            //跳点，如设置跳点，执行跳点方案
            sql = string.Format("select IsNull(UpID,0) from SaleItem where ItemID = {0}", itemId);
            int upId = int.Parse(SqlHelper.ExecuteScalar(sql).ToString());
            if (upId > 0)
            {
                return result;
            }

            //匹配房源类型  
            sql = string.Format("select CommissionType, Rate, Amount  from SchemeRate a inner join SaleItem b on a.ItemTypeCode = b.ItemTypeCode where ItemID = {0} and ('{1}' >= BeginDate and '{1}' <= EndDate) and a.ProjectID = {2}", itemId, subscribeDate, Login.User.ProjectID);
            SqlDataReader sdr = SqlHelper.ExecuteReader(sql);
            if (sdr.Read())
            {
                if (Convert.ToBoolean(sdr["CommissionType"]))
                {
                    isAmount = true;
                    result = double.Parse(sdr["Amount"].ToString());
                }
                else
                {
                    result = double.Parse(sdr["Rate"].ToString());
                }
            }
            else
            {
                //项目默认
                sql = string.Format("select CommissionType, Rate, Amount from SchemeRate where ItemTypeCode = 0 and ('{1}' >= BeginDate and '{1}' <= EndDate) and ProjectID = {2}",itemId, subscribeDate, Login.User.ProjectID);
                sdr = SqlHelper.ExecuteReader(sql);
                if (sdr.Read())
                {
                    if (Convert.ToBoolean(sdr["CommissionType"]))
                    {
                        isAmount = true;
                        result = double.Parse(sdr["Amount"].ToString());
                    }
                    else
                    {
                        result = double.Parse(sdr["Rate"].ToString());
                    }
                }
            }

            sdr.Close();
            return result;
        }



        private void dataGridView_SaleItem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            double area = 0;
            double price = 0;
            double amount = 0;

            if ((dataGridView_SaleItem.Columns[e.ColumnIndex].Name == "ColPrice") || (dataGridView_SaleItem.Columns[e.ColumnIndex].Name == "ColArea"))
            {
                double.TryParse(dataGridView_SaleItem.Rows[rowIndex].Cells["ColArea"].Value.ToString(), out area);
                double.TryParse(dataGridView_SaleItem.Rows[rowIndex].Cells["ColPrice"].Value.ToString(), out price);

                dataGridView_SaleItem.Rows[rowIndex].Cells["ColAmout"].Value = (area * price).ToString("F0");
            }
            else if (dataGridView_SaleItem.Columns[e.ColumnIndex].Name == "ColAmout")
            {
                double.TryParse(dataGridView_SaleItem.Rows[rowIndex].Cells["ColArea"].Value.ToString(), out area);
                double.TryParse(dataGridView_SaleItem.Rows[rowIndex].Cells["ColAmout"].EditedFormattedValue.ToString(), out amount);

                dataGridView_SaleItem.Rows[rowIndex].Cells["ColPrice"].Value = (amount / area).ToString("F4");
            }

            getRowsTotalAmount();
        }

        /// <summary>
        /// 参照认购信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_ReferSubscribe_Click(object sender, EventArgs e)
        {
            if (comboBox_PayMode.Items.Count == 0)
            {
                Prompt.Warning("未设置付款方式，无法进行业务操作！");
                return;
            }

            FrmSubscribeBase frmSubscribe = new FrmSubscribeBase();

            if (frmSubscribe.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string sql = string.Format("select b.CustomerID, b.CustomerName, b.CustomerPhone, b.Addr, b.PID, SalesID, SalesName, convert(varchar(10),SubscribeDate,120) SubscribeDate, ExtField0,ExtField1,ExtField2,ExtField3,ExtField4,ExtField5,ExtField6,ExtField7,ExtField8,ExtField9 "
                    + " from SubscribeMain a  "
                    + " inner join Customer b on a.CustomerID = b.CustomerID "
                    + " where a.SubscribeID = {0}", frmSubscribe.SubscribeID);

                SqlDataReader sdr = SqlHelper.ExecuteReader(sql);
                sdr.Read();
                textBox_CusName.Tag = sdr["CustomerID"].ToString();
                textBox_CusName.Text = sdr["CustomerName"].ToString();
                textBox_CusPhone.Text = sdr["CustomerPhone"].ToString();
                textBox_CusAddr.Text = sdr["Addr"].ToString();
                textBox_CusPID.Text = sdr["PID"].ToString();
                comboBox_Sales.SelectedValue = sdr["SalesID"].ToString();
                textBox_ExtField0.Text = sdr["ExtField0"].ToString();
                textBox_ExtField1.Text = sdr["ExtField1"].ToString();
                textBox_ExtField2.Text = sdr["ExtField2"].ToString();
                textBox_ExtField3.Text = sdr["ExtField3"].ToString();
                textBox_ExtField4.Text = sdr["ExtField4"].ToString();
                textBox_ExtField5.Text = sdr["ExtField5"].ToString();
                textBox_ExtField6.Text = sdr["ExtField6"].ToString();
                textBox_ExtField7.Text = sdr["ExtField7"].ToString();
                textBox_ExtField8.Text = sdr["ExtField8"].ToString();
                textBox_ExtField9.Text = sdr["ExtField9"].ToString();

                dictSubscribe.Clear();
                dictSubscribe.Add("SubscribeID", frmSubscribe.SubscribeID);
                dictSubscribe.Add("SubscribeDate", sdr["SubscribeDate"].ToString());
                dictSubscribe.Add("SubscribeSalesID", sdr["SalesID"].ToString());
                dictSubscribe.Add("SubscribeSalesName", sdr["SalesName"].ToString());


                //清行
                if (dataGridView_SaleItem.Rows.Count > 0)
                    dataGridView_SaleItem.Rows.Clear();

                sql = string.Format("select ItemID, ItemTypeCode, ItemTypeName, Building, Unit, ItemNum, Area, Price ,Amount, IsBind from [SubscribeDetail] where SubscribeID = {0} order by rowid", frmSubscribe.SubscribeID);
                sdr = SqlHelper.ExecuteReader(sql);

                while (sdr.Read())
                {
                    int index = this.dataGridView_SaleItem.Rows.Add();
                    dataGridView_SaleItem.Rows[index].Cells["ColItemID"].Value = sdr["ItemID"].ToString();
                    dataGridView_SaleItem.Rows[index].Cells["ColItemTypeCode"].Value = sdr["ItemTypeCode"].ToString();
                    dataGridView_SaleItem.Rows[index].Cells["ColItemTypeName"].Value = sdr["ItemTypeName"].ToString();
                    dataGridView_SaleItem.Rows[index].Cells["ColBuilding"].Value = sdr["Building"].ToString();
                    dataGridView_SaleItem.Rows[index].Cells["ColUnit"].Value = sdr["Unit"].ToString();
                    dataGridView_SaleItem.Rows[index].Cells["ColItemNum"].Value = sdr["ItemNum"].ToString();
                    dataGridView_SaleItem.Rows[index].Cells["ColArea"].Value = sdr["Area"].ToString();
                    dataGridView_SaleItem.Rows[index].Cells["ColPrice"].Value = sdr["Price"].ToString();
                    dataGridView_SaleItem.Rows[index].Cells["ColAmout"].Value = double.Parse(sdr["Amount"].ToString()).ToString("F0");
                    dataGridView_SaleItem.Rows[index].Cells["ColIsBind"].Value = sdr["IsBind"].ToString();
                    //Math.Round(sdr["Amount"].ToString(), 0, MidpointRounding.AwayFromZero).ToString("N0");
                }

                getRowsTotalAmount();
            }
        }


        //暂停
        private void toolStripButton_Remove_Click(object sender, EventArgs e)
        {
            if (dataGridView_SaleItem.CurrentRow != null)
            {
                int idx = dataGridView_SaleItem.CurrentRow.Index;
                if (idx != -1)
                    dataGridView_SaleItem.Rows.RemoveAt(idx);
            }
        }

        //暂停
        private void dataGridView_SaleItem_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            getRowsTotalAmount();
        }

        private void LoadData()
        {
            string sql = string.Empty;
            SqlDataReader sdr = null;

            //主表信息
            sql = string.Format("select SubscribeID,convert(varchar(10),SubscribeDate,120) SubscribeDate,SubscribeSalesID,SubscribeSalesName, ContractNum, b.CustomerID,b.CustomerName,b.CustomerPhone,PID,Addr, SalesID, PaymentID,isnull(DownPayRate,0) DownPayRate,isnull(DownPayAmount,0) DownPayAmount,isnull(Loan,0) Loan,isnull(TotalAmount,0) TotalAmount,ContractDate, "
                + "Discount, Fund, FormalNum, FormalDate, ExtField0, ExtField1, ExtField2, ExtField3, ExtField4, ExtField5, ExtField6, ExtField7, ExtField8, ExtField9 "
                + "from [ContractMain] a "
                + "inner join Customer b on a.CustomerID = b.CustomerID "
                + "where contractID = {0}", ContractID);
            try
            {
                sdr = SqlHelper.ExecuteReader(sql);
                if (!sdr.Read())
                {
                    return;
                }

                PayModeData.GetPaymentModeByID(sdr["PaymentID"].ToString());

                //认购信息
                dictSubscribe.Clear();
                dictSubscribe.Add("SubscribeID", sdr["SubscribeID"].ToString());
                dictSubscribe.Add("SubscribeDate", sdr["SubscribeDate"].ToString());
                dictSubscribe.Add("SubscribeSalesID", sdr["SubscribeSalesID"].ToString());
                dictSubscribe.Add("SubscribeSalesName", sdr["SubscribeSalesName"].ToString());

                //原始签约编号
                origContractNum = sdr["ContractNum"].ToString();

                if ((PayModeData.PaymentType == PayType.FullInstalment) || (PayModeData.PaymentType == PayType.DownPayInstalment))//分期付款记录
                {
                    sql = "select Sequence, PayDate, cast(Amount AS int) Amount, Settled from Installment where ContractID = " + ContractID + " order by Sequence ";
                    dtInstallment = SqlHelper.ExecuteDataTable(sql);
                }

                textBox_CusName.Tag = sdr["CustomerID"].ToString();
                textBox_CusName.Text = sdr["CustomerName"].ToString();
                textBox_CusPhone.Text = sdr["CustomerPhone"].ToString();
                textBox_CusPID.Text = sdr["PID"].ToString();
                textBox_CusAddr.Text = sdr["Addr"].ToString();

                textBox_ContractNum.Text = sdr["ContractNum"].ToString();
                comboBox_Sales.SelectedValue = sdr["SalesID"].ToString();
                textBox_TotalAmount.Text = double.Parse(sdr["TotalAmount"].ToString()).ToString("F0");
                dateTimePicker_ContractDate.Value = DateTime.Parse(sdr["ContractDate"].ToString());

                comboBox_PayMode.SelectedValue = sdr["PaymentID"].ToString();
                textBox_DownPayRate.Text = sdr["DownPayRate"].ToString();
                textBox_DownPay.Text = double.Parse(sdr["DownPayAmount"].ToString()).ToString("F0");
                textBox_Loan.Text = double.Parse(sdr["Loan"].ToString()).ToString("F0");

                textBox_Discount.Text = sdr["Discount"].ToString();
                textBox_Fund.Text = sdr["Fund"].ToString();
                textBox_FormalNum.Text = sdr["FormalNum"].ToString();
                textBox_FormalDate.Text = sdr["FormalDate"].ToString();

                textBox_ExtField0.Text = sdr["ExtField0"].ToString();
                textBox_ExtField1.Text = sdr["ExtField1"].ToString();
                textBox_ExtField2.Text = sdr["ExtField2"].ToString();
                textBox_ExtField3.Text = sdr["ExtField3"].ToString();
                textBox_ExtField4.Text = sdr["ExtField4"].ToString();
                textBox_ExtField5.Text = sdr["ExtField5"].ToString();
                textBox_ExtField6.Text = sdr["ExtField6"].ToString();
                textBox_ExtField7.Text = sdr["ExtField7"].ToString();
                textBox_ExtField8.Text = sdr["ExtField8"].ToString();
                textBox_ExtField9.Text = sdr["ExtField9"].ToString();
            }
            catch (Exception ex)
            {
                Prompt.Error("查询错误!请重试或联系管理员.\r\n错误信息(LD-01)：" + ex.Message);
            }
            finally
            {
                sdr.Close();
            }


            //从表信息
            sql = string.Format("select ItemID,ItemTypeCode,ItemTypeName,Building,Unit,ItemNum,Area,Price,Amount,IsBind from [ContractDetail] where ContractID = {0} order by rowid ",ContractID);
            dtOrigItemsData = SqlHelper.ExecuteDataTable(sql);

            foreach (DataRow row in dtOrigItemsData.Rows)
            {
                int index = this.dataGridView_SaleItem.Rows.Add();
                dataGridView_SaleItem.Rows[index].Cells["ColItemID"].Value = row["ItemID"].ToString();
                dataGridView_SaleItem.Rows[index].Cells["ColItemTypeCode"].Value = row["ItemTypeCode"].ToString();
                dataGridView_SaleItem.Rows[index].Cells["ColItemTypeName"].Value = row["ItemTypeName"].ToString();
                dataGridView_SaleItem.Rows[index].Cells["ColBuilding"].Value = row["Building"].ToString();
                dataGridView_SaleItem.Rows[index].Cells["ColUnit"].Value = row["Unit"].ToString();
                dataGridView_SaleItem.Rows[index].Cells["ColItemNum"].Value = row["ItemNum"].ToString();
                dataGridView_SaleItem.Rows[index].Cells["ColArea"].Value = row["Area"].ToString();
                dataGridView_SaleItem.Rows[index].Cells["ColPrice"].Value = row["Price"].ToString();
                dataGridView_SaleItem.Rows[index].Cells["ColAmout"].Value = double.Parse(row["Amount"].ToString()).ToString("F0");
                dataGridView_SaleItem.Rows[index].Cells["ColIsBind"].Value = row["IsBind"].ToString();
            }
        }


        /// <summary>
        /// 更新、修改
        /// </summary>
        private void UpdateData()
        {
            int ErrCode = 0;
            using (SqlConnection connection = SqlHelper.OpenConnection())  //创建连接对象 
            {
                SqlTransaction sqlTran = connection.BeginTransaction();    //开始事务 
                SqlCommand cmd = connection.CreateCommand();               //创建SqlCommand对象 
                cmd.Transaction = sqlTran;                                 //将SqlCommand与SqlTransaction关联起

                try
                {
                    //业务主表
                    cmd.CommandText = GenUpdateContractMainSQL(ContractID);
                    ErrCode = 1;
                    cmd.ExecuteNonQuery();

                    //业务从表 - 清除原数据
                    cmd.CommandText = string.Format("delete [ContractDetail] where ContractID = {0}",ContractID);
                    ErrCode = 2;
                    cmd.ExecuteNonQuery();

                    //业务从表 - 重新添加
                    for (int i = 0; i < dataGridView_SaleItem.Rows.Count; i++)
                    {
                        cmd.CommandText = GenInsertSqlContractDetail(i, ContractID);
                        ErrCode = 7;
                        cmd.ExecuteNonQuery();

                        ErrCode = 8;
                        string itemId = dataGridView_SaleItem.Rows[i].Cells["ColItemID"].Value.ToString();
                        bool isBind = Convert.ToBoolean(dataGridView_SaleItem.Rows[i].Cells["ColIsBind"].Value);

                        ErrCode = 9;
                        cmd.CommandText = GenUpdateSqlSaleItem(itemId,isBind);
                        ErrCode = 3;
                        cmd.ExecuteNonQuery();


                        DataRow[] dr = dtOrigItemsData.Select("ItemID = " + itemId);
                        if (dr.Length > 0)
                        {
                            dtOrigItemsData.Rows[i].Delete();
                        }
                    }
                    dtOrigItemsData.AcceptChanges();

                    foreach (DataRow row in dtOrigItemsData.Rows) //重置移除房源的销售状态（防止事务死锁，对单一记录操作)
                    {
                        //业务从表 －换房源重置为待售
                        string sql = string.Format("update SaleItem set SaleStateCode = {0}, SaleStateName = '{1}', PayModeID = null,PayTypeCode = null,PayTypeName = null,"
                                + " SettleStandardCode = null,SettleStandardName = null,SettleBaseCode = null,SettleBaseName = null, SettleRate =0 "
                                + " where ItemID = {2}", (int)ItemSaleState.待售, ItemSaleState.待售, row["ItemID"].ToString());

                        cmd.CommandText = sql;
                        ErrCode = 4;
                        cmd.ExecuteNonQuery();
                    }

                    //更新分期付款设置
                    cmd.CommandText = "delete Installment where ContractID = " + ContractID;
                    ErrCode = 5;
                    cmd.ExecuteNonQuery();

                    for (int i = 0; i < dtInstallment.Rows.Count; i++)
                    {
                        cmd.CommandText = string.Format("insert into Installment (ContractID, Sequence,Amount, PayDate) values ({0},{1},{2},'{3}')",
                            ContractID, dtInstallment.Rows[i]["Sequence"].ToString(), dtInstallment.Rows[i]["Amount"].ToString(), dtInstallment.Rows[i]["PayDate"].ToString());
                        ErrCode = 6;
                        
                        cmd.ExecuteNonQuery();
                    }

                    sqlTran.Commit();  //事务提交
                    connection.Close();

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();  //异常事务回滚
                    Prompt.Error("操作失败! \r\n错误信息(UD-01)：" + ex.Message +  "\r\nErrCode:" + ErrCode);
                }
            }

        }

        private string GenUpdateContractMainSQL(string contractID)
        {
            string sql = string.Empty;

            string payTypeCode = Transaction.GetPayType(comboBox_PayMode.SelectedValue.ToString()).ToString();

            string updateField = "ContractNum = '" + textBox_ContractNum.Text.Trim() + "'"
                + ",CustomerID = " + textBox_CusName.Tag
                + ",CustomerName = '" + textBox_CusName.Text + "'"
                + ",CustomerPhone = '" + textBox_CusPhone.Text + "'"
                + ",ContractDate = '" + dateTimePicker_ContractDate.Value.ToString("yyyy-MM-dd") + "'"
                + ",PaymentID = " + comboBox_PayMode.SelectedValue.ToString()
                + ",PaymentName ='" + comboBox_PayMode.Text + "'"
                + ",PaymentType = " + payTypeCode 
                + ",DownPayRate = " + textBox_DownPayRate.Text.ToString()
                + ",DownPayAmount = " + textBox_DownPay.Text.ToString()
                + ",Loan = " + textBox_Loan.Text.ToString()
                + ",TotalAmount = " + double.Parse(textBox_TotalAmount.Text.Trim(), NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint).ToString()
                + ",Discount = '" + textBox_Discount.Text.Trim() + "'"
                + ",Fund = " + textBox_Fund.Text.Trim()
                + ",FormalNum = '" + textBox_FormalNum.Text.Trim() + "'"
                + ",formalDate = '" + textBox_FormalDate.Text.Trim() + "'"
                + ",SalesID = " + comboBox_Sales.SelectedValue.ToString()
                + ",SalesName = '" + comboBox_Sales.Text + "'"
                + ",ExtField0 = '" + textBox_ExtField0.Text.Trim() + "'"
                + ",ExtField1 = '" + textBox_ExtField1.Text.Trim() + "'"
                + ",ExtField2 = '" + textBox_ExtField2.Text.Trim() + "'"
                + ",ExtField3 = '" + textBox_ExtField3.Text.Trim() + "'"
                + ",ExtField4 = '" + textBox_ExtField4.Text.Trim() + "'"
                + ",ExtField5 = '" + textBox_ExtField5.Text.Trim() + "'"
                + ",ExtField6 = '" + textBox_ExtField6.Text.Trim() + "'"
                + ",ExtField7 = '" + textBox_ExtField7.Text.Trim() + "'"
                + ",ExtField8 = '" + textBox_ExtField8.Text.Trim() + "'"
                + ",ExtField9 = '" + textBox_ExtField9.Text.Trim() + "'";

            sql = string.Format("update [ContractMain] set {0} where ContractID = '{1}'", updateField, contractID);

            return sql;
        }

        /// <summary>
        /// 换房：整单退，新签约
        /// </summary>
        private void ExchangeData()
        {
            int ErrCode = 0;
            
            string strValues = string.Empty;
            double receiptTotal = 0;
            using (SqlConnection connection = SqlHelper.OpenConnection()) 
            {
                SqlTransaction sqlTran = connection.BeginTransaction();    
                SqlCommand cmd = connection.CreateCommand();               
                cmd.Transaction = sqlTran;

                try
                {
                    string origSubscribeID = dictSubscribe["SubscribeID"];
                    string origSubscribeDate = dictSubscribe["SubscribeDate"];
                    string salesId = comboBox_Sales.SelectedValue.ToString();
                    string salesName = comboBox_Sales.Text;


                    //更新主表
                    cmd.CommandText = string.Format("update ContractMain set ReturnDate = CONVERT(VARCHAR(10),GETDATE(),120), RefundDate = CONVERT(VARCHAR(10),GETDATE(),120), ReturnReason = '换房' where ContractID = {0}", ContractID);
                    ErrCode = 1;
                    cmd.ExecuteNonQuery();

                    //生成退款
                    cmd.CommandText = string.Format("select ISNULL(SUM(Amount),0) from Receipt where ContractID = {0}", ContractID);
                    receiptTotal = double.Parse(cmd.ExecuteScalar().ToString());
                    if (receiptTotal > 0)
                    {
                        string refund = "-" + receiptTotal;

                        strValues = ContractID + "," + origSubscribeID + "," + Login.User.ProjectID + "," + refund + ",GETDATE()," + (int)Receivables.退房 + ",'" + Receivables.退房 + "','换房'," + salesId + ",'" + salesName + "',GETDATE(),'" + Login.User.UserName + "'";
                        cmd.CommandText = string.Format("insert into Receipt (ContractID,SubscribeID, ProjectID,Amount,RecDate,TypeCode,TypeName,Memo,SalesID,SalesName,MakeDate,Maker) values ({0})", strValues);
                        ErrCode = 2;
                        cmd.ExecuteNonQuery();
                    }

                    //退房记录
                    strValues = ContractID + ",'" + OperationType.contract + "',GETDATE(),'换房',1," + salesId + ",'" + salesName + "','" + Login.User.UserName + "',GETDATE()";
                    cmd.CommandText = string.Format("insert into ItemReturn (AgreementID,OperationType,ReturnDate,Memo,IsRefund,SalesID, SalesName, MakeUserName,MakeDate) values ({0})", strValues);
                    ErrCode = 3;
                    cmd.ExecuteNonQuery();

                    //新增签约主表
                    cmd.CommandText = GenInsertSqlContractMain();
                    ErrCode = 4;
                    string newContractId = cmd.ExecuteScalar().ToString();

                    //新增认购主表
                    //数据来自于原认购，更新认购金额
                    cmd.CommandText = string.Format("insert into SubscribeMain output inserted.SubscribeID select '{0}' as ContractID,SubscribeNum,ProjectID,ProjectName,CustomerID,CustomerName,CustomerPhone, "
                        + "SubscribeDate,LastContractDate,ReturnDate,RefundDate,ReturnReason,ReturnUserName, '{1}' as TotalAmount, "
                        + "SalesID,SalesName,Memo,MakeDate,UserID,UserName,State, "
                        + "ExtField0,ExtField1,ExtField2,ExtField3,ExtField4,ExtField5,ExtField6,ExtField7,ExtField8,ExtField9,import from SubscribeMain where  SubscribeID = {2}", newContractId, textBox_TotalAmount.Text.Trim(), dictSubscribe["SubscribeID"]);
                    ErrCode = 5;
                    string newSubscribeId = cmd.ExecuteScalar().ToString();

                    //签约从表
                    for (int i = 0; i < dataGridView_SaleItem.Rows.Count; i++)
                    {
                        //添加房源(签约）
                        cmd.CommandText = GenInsertSqlContractDetail(i, newContractId);
                        ErrCode = 6;
                        cmd.ExecuteNonQuery();

                        //添加房源（认购）
                        cmd.CommandText = GenInsertSqlSubscribeDetail(i, newSubscribeId);
                        ErrCode = 7;
                        cmd.ExecuteNonQuery();

                        string itemId = dataGridView_SaleItem.Rows[i].Cells["ColItemID"].Value.ToString();

                        DataRow[] row = dtOrigItemsData.Select("ItemID = " + itemId);

                        if (row.Length > 0)
                        {
                            dtOrigItemsData.Rows[i].Delete();
                        }
                        else
                        {
                            string origItemID = dtOrigItemsData.Rows[i]["ItemID"].ToString();
                            //换房记录
                            DataTable dt = SqlHelper.ExecuteDataTable(string.Format("select Building, Unit, ItemNum from SaleItem where ItemID = {0}",origItemID));
                            strValues = Login.User.ProjectID +"," + newContractId + "," + ContractID + ","
                                + textBox_CusName.Tag.ToString() + ",'"
                                + textBox_CusName.Text + "','"
                                + textBox_CusPhone.Text + "',"
                                + receiptTotal + ","
                                + origItemID + ",'" 
                                + dt.Rows[0]["Building"].ToString() + "','" 
                                + dt.Rows[0]["Unit"].ToString() + "','" 
                                + dt.Rows[0]["ItemNum"].ToString() + "','"
                                + dataGridView_SaleItem.Rows[i].Cells["ColItemTypeName"].Value + "'," 
                                + dataGridView_SaleItem.Rows[i].Cells["ColItemID"].Value + ",'" 
                                + dataGridView_SaleItem.Rows[i].Cells["ColBuilding"].Value + "','" 
                                + dataGridView_SaleItem.Rows[i].Cells["ColUnit"].Value + "','" 
                                + dataGridView_SaleItem.Rows[i].Cells["ColItemNum"].Value + "','"
                                + salesName + "','"
                                + origSubscribeDate + "',"
                                + "GETDATE(),'" + Login.User.UserName + "',GETDATE()";

                            cmd.CommandText = string.Format("insert into ItemExchange (ProjectID,ContractID,OrigContractID, CustomerID, CustomerName, CustomerPhone, ReceiptTotal, "
                                + " OrigItemID,OrigBuilding,OrigUnit,OrigItemNum,ItemTypeName,ItemID,Building,Unit,ItemNum,SalesName,SubscribeDate, ExchangeDate, MakeUserName,MakeDate) values ({0})", strValues);
                            ErrCode = 8;
                            cmd.ExecuteNonQuery(); 

                            bool isBind = Convert.ToBoolean(dataGridView_SaleItem.Rows[i].Cells["ColIsBind"].Value);

                            //设置房源状态
                            if (isBind)
                                cmd.CommandText = GenUpdateSqlSaleItem(itemId, isBind);
                            else
                                cmd.CommandText = GenUpdateSqlSaleItem(itemId, isBind, GetSettleValue());  //主售物业获取结算数据

                            ErrCode = 9;
                            cmd.ExecuteNonQuery();
                        }
             
                    }

                    dtOrigItemsData.AcceptChanges();

                    //重置移除房源的销售状态
                    foreach (DataRow row in dtOrigItemsData.Rows) 
                    {
                        //业务从表 －换房源重置为待售
                        string sql = string.Format("update SaleItem set SaleStateCode = {0}, SaleStateName = '{1}', PayModeID = null,PayTypeCode = null,PayTypeName = null,"
                                + " SettleStandardCode = null,SettleStandardName = null,SettleBaseCode = null,SettleBaseName = null, SettleRate =0 "
                                + " where ItemID = {2}", (int)ItemSaleState.待售, ItemSaleState.待售, row["ItemID"]);

                        cmd.CommandText = sql;
                        ErrCode = 10;
                        cmd.ExecuteNonQuery();
                    }

                    //收款信息
                    cmd.CommandText = string.Format("insert into Receipt (ContractID,ProjectID,Amount,RecDate,TypeCode,TypeName,IsLoan,Memo,SalesID,SalesName,Source,MakeDate,Maker) "
                        + "select '{0}' as ContractID,ProjectID,Amount,RecDate,TypeCode,TypeName,IsLoan,Memo,SalesID,SalesName,Source,MakeDate,Maker from Receipt where ContractID = {1} and TypeCode != {2}", newContractId, ContractID, (int)Receivables.退房);
                    ErrCode = 11;
                    cmd.ExecuteNonQuery();

                    //保存分期付款设置
                    for (int i = 0; i < dtInstallment.Rows.Count; i++)
                    {
                        cmd.CommandText = string.Format("insert into Installment (ContractID, Sequence,Amount, PayDate) values ({0},{1},{2},'{3}')",
                            newContractId, dtInstallment.Rows[i]["Sequence"].ToString(), dtInstallment.Rows[i]["Amount"].ToString(), dtInstallment.Rows[i]["PayDate"].ToString());
                        ErrCode = 12;
                        cmd.ExecuteNonQuery();
                    }

                    //换房记录

                    ContractID = newContractId;

                    sqlTran.Commit();

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;

                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    Prompt.Error("操作失败! \r\n错误信息(UD-02)：" + ex.Message + "\r\nErrCode: " + ErrCode);
                }

            }
        }

        private string GetSettleValue()
        {
            string result = string.Empty;

            foreach (DataRow row in dtOrigItemsData.Rows)
            {
                SqlDataReader sdr = SqlHelper.ExecuteReader(string.Format("select SettleRate, SettleAmount from SaleItem where IsBind = 0 and  itemID = {0}", row["ItemID"]));
                if (sdr.HasRows)
                {
                    sdr.Read();
                    result = string.Format(",SettleRate = {0} , SettleAmount = {1}", sdr["SettleRate"].ToString(), sdr["SettleAmount"].ToString()); 
                    break;
                }
            }
            return result;
        }



        private void FrmContractAdd_Load(object sender, EventArgs e)
        {
            switch (FrmMode)
            {
                case FormMode.add:
                    toolStripButton_ReferSubscribe.Visible = true;
                    
                    toolStrip_Item.Visible = false;

                    dataGridView_SaleItem.Columns["ColArea"].ReadOnly = false;
                    break;

                case FormMode.exchange:
                    this.Text = "更换房源信息";
                    toolStripButton_ReferSubscribe.Visible = false;

                    toolStrip_Item.Visible = true;
                    toolStripButton_Add.Visible = false;
                    toolStripButton_Remove.Visible = false;
                    toolStripButton_Exchange.Visible = true;

                    dataGridView_SaleItem.ReadOnly = true;
                    dataGridView_SaleItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    
                    comboBox_Sales.Enabled = false;
                    comboBox_PayMode.Enabled = false;

                    LoadData();
                    break;


                case FormMode.modify:
                    this.Text = "变更签约信息";
                    toolStripButton_ReferSubscribe.Visible = false;

                    toolStrip_Item.Visible = false;

                    dataGridView_SaleItem.Columns["ColArea"].ReadOnly = true;
                    comboBox_Sales.Enabled = false;

                    LoadData();
                    break;

                case FormMode.view:
                    this.Text = "查看签约信息";
                    toolStripButton_ReferSubscribe.Visible = false;
                    toolStripButton_Save.Visible = false;

                    toolStrip_Item.Visible = false;

                    dataGridView_SaleItem.ReadOnly = true;
                    dataGridView_SaleItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    comboBox_PayMode.Enabled = false;
                    comboBox_Sales.Enabled = false;
                    textBox_ContractNum.ReadOnly = true;
                    dateTimePicker_ContractDate.Enabled = false;

                    LoadData();
                    break;

                default:
                    break;
            }
        }


        /// <summary>
        /// 计算首付金额（总额*比例） 为comboBox事件服务
        /// </summary>
        private void getDownPayBaseRate(bool isDownPayRate = false)
        {
            if (double.Parse(textBox_TotalAmount.Text.Trim()) == 0)
                return;

            double totalAmount = 0;
            double.TryParse(textBox_TotalAmount.Text.Trim(), out totalAmount);

            string payModeId = comboBox_PayMode.SelectedValue.ToString();

            PayModeData.GetPaymentModeByID(payModeId);

            double loan;
            double truncLoan;

            switch (PayModeData.PaymentType)
            {
                case PayType.Full:  //一次性付款
                    button_Installment.Enabled = false;
                    textBox_DownPay.ReadOnly = true;
                    textBox_Loan.ReadOnly = true;
                    textBox_DownPayRate.Enabled = false;

                    textBox_DownPayRate.Text = "100";
                    textBox_Loan.Text = "0";
                    textBox_DownPay.Text = totalAmount.ToString();
                    break;


                case PayType.Loan:  //贷款
                    button_Installment.Enabled = false;
                    textBox_DownPay.ReadOnly = false;
                    textBox_Loan.ReadOnly = false;
                    textBox_DownPayRate.Enabled = true;

                    if (isDownPayRate) //付款方式为贷款（首付分期）时获取首付比例,仅“付款方式”控件事件触发
                            textBox_DownPayRate.Text =  PayModeData.DownPayRate;//GetDownPayRate(payModeId).ToString();

                    if (!textBox_DownPayRate.Text.Trim().Equals(""))
                    {
                        if (textBox_DownPayRate.Text.Trim().Equals("0"))
                        {
                            textBox_Loan.Text = totalAmount.ToString();
                            textBox_DownPay.Text = "0";
                        }
                        else
                        {
                            //贷款
                            loan = double.Parse(textBox_TotalAmount.Text.Trim()) * (1 - double.Parse(textBox_DownPayRate.Text.Trim()) / 100);
                            truncLoan = Math.Floor(loan / 10000) * 10000;
                            textBox_Loan.Text = Math.Round(truncLoan, 0, MidpointRounding.AwayFromZero).ToString();

                            //应付首付
                            textBox_DownPay.Text = Math.Round((totalAmount - truncLoan), 0, MidpointRounding.AwayFromZero).ToString();
                        }
                    }
                    break;

                case PayType.FullInstalment:   //全款分期
                    button_Installment.Enabled = true;
                    textBox_DownPay.ReadOnly = true;
                    textBox_Loan.ReadOnly = true;
                    textBox_DownPayRate.Enabled = false;

                    textBox_DownPayRate.Text = "100";
                    textBox_Loan.Text = "0";
                    textBox_DownPay.Text = totalAmount.ToString();
                    break;

                case PayType.DownPayInstalment:  //首付分期
                    button_Installment.Enabled = true;
                    textBox_DownPay.ReadOnly = false;
                    textBox_Loan.ReadOnly = true;
                    textBox_DownPayRate.Enabled = true;

                    if (isDownPayRate)
                        textBox_DownPayRate.Text = PayModeData.DownPayRate;

                    if (!textBox_DownPayRate.Text.Trim().Equals(""))
                    {
                        if (textBox_DownPayRate.Text.Trim().Equals("0"))
                        {
                            textBox_Loan.Text = totalAmount.ToString();
                            textBox_DownPay.Text = "0";
                        }
                        else
                        {
                            loan = double.Parse(textBox_TotalAmount.Text.Trim()) * (1 - double.Parse(textBox_DownPayRate.Text.Trim()) / 100);
                            truncLoan = Math.Floor(loan / 10000) * 10000;

                            textBox_Loan.Text = Math.Round(truncLoan, 0, MidpointRounding.AwayFromZero).ToString();
                            textBox_DownPay.Text = Math.Round((totalAmount - truncLoan), 0, MidpointRounding.AwayFromZero).ToString();
                        }
                    }

                    break;



                default:
                    textBox_DownPay.Text = "0";
                    textBox_Loan.Text = "0";
                    break;
            }

        }

        /// <summary>
        /// 计算贷款,首付值, TextChange 调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calcAmount(object sender, EventArgs e)
        {
            if (double.Parse(textBox_TotalAmount.Text.Trim()) == 0)
                return;

            switch (PayModeData.PaymentType)
            {
                case PayType.Full:
                case PayType.FullInstalment:

                    break;

                case PayType.Loan:
                case PayType.DownPayInstalment:
                    double totalAmount = 0;
                    double downPay = 0;
                    double loan = 0;

                    double.TryParse(textBox_TotalAmount.Text.Trim(), out totalAmount);

                    if (sender == textBox_Loan)
                    {
                        double.TryParse(textBox_Loan.Text.Trim(), out loan); //贷款
                        downPay = Math.Round((totalAmount - loan), 0, MidpointRounding.AwayFromZero);
                        textBox_DownPay.Text = downPay.ToString();
                        //textBox_DownPayRate.Text = Math.Round(downPay / totalAmount * 100, 0, MidpointRounding.AwayFromZero).ToString();
                    }
                    else if (sender == textBox_DownPay)
                    {
                        double.TryParse(textBox_DownPay.Text.Trim(), out downPay); //首付
                        textBox_Loan.Text = Math.Round(totalAmount - downPay, 0, MidpointRounding.AwayFromZero).ToString();
                        //textBox_DownPayRate.Text = Math.Round(downPay / totalAmount * 100, 0, MidpointRounding.AwayFromZero).ToString();
                    }
                    else if (sender == textBox_TotalAmount)
                    {
                        //贷款取整万位
                        loan = double.Parse(textBox_TotalAmount.Text.Trim()) * (1 - double.Parse(textBox_DownPayRate.Text.Trim()) / 100);
                        double truncLoan = Math.Floor(loan / 10000) * 10000;
                        textBox_Loan.Text = Math.Round(truncLoan, 0, MidpointRounding.AwayFromZero).ToString();

                        //应付首付
                        textBox_DownPay.Text = Math.Round((totalAmount - truncLoan), 0, MidpointRounding.AwayFromZero).ToString();
                    }

                    break;

                default:

                    break;
            }
        }

        private void dataGridView_SaleItem_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            double price = 0;
            if (!double.TryParse(dataGridView_SaleItem.Rows[e.RowIndex].Cells["ColPrice"].EditedFormattedValue.ToString(), out price))
            {
                Prompt.Error("请填写正确的数字格式！");
                e.Cancel = true;
            }

            double amount = 0;
            if (!double.TryParse(dataGridView_SaleItem.Rows[e.RowIndex].Cells["ColAmout"].EditedFormattedValue.ToString(), out amount))
            {
                Prompt.Error("请填写正确的数字格式！");
                e.Cancel = true;
            }
        }

        private void textBox_DownPay_Validated(object sender, EventArgs e)
        {
            double dResult = 0;
            double.TryParse(textBox_DownPay.Text.Trim(), out dResult);
            textBox_DownPay.Text = dResult.ToString();
        }

        private void textBox_Loan_Validated(object sender, EventArgs e)
        {
            double dResult = 0;
            double.TryParse(textBox_Loan.Text.Trim(), out dResult);
            textBox_Loan.Text = dResult.ToString();
        }

        private void exchang()
        {
            if (dataGridView_SaleItem.CurrentRow == null)
            {
                Prompt.Warning("未选择要更换的原房屋！");
                return;
            }

            int idx = dataGridView_SaleItem.CurrentRow.Index;

            FrmBaseSaleItem saleItem = new FrmBaseSaleItem();

            saleItem.ItemSaleProperty = Convert.ToBoolean(dataGridView_SaleItem.CurrentRow.Cells["ColIsBind"].Value) ? 1 : 0;

            if (saleItem.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (isExist(saleItem.saleItemID))
                {
                    Prompt.Information("此记录已存在，不能重复添加！");
                    return;
                }

                dataGridView_SaleItem.Rows.RemoveAt(idx); //移除原房屋

                SaleItem item = new SaleItem();

                item.getSaleItemByID(saleItem.saleItemID);

                dataGridView_SaleItem.Rows.Insert(idx, 1);
                dataGridView_SaleItem.Rows[idx].Cells["ColItemID"].Value = item.ItemID;
                dataGridView_SaleItem.Rows[idx].Cells["ColItemTypeCode"].Value = item.ItemTypeCode;
                dataGridView_SaleItem.Rows[idx].Cells["ColItemTypeName"].Value = item.ItemTypeName;
                dataGridView_SaleItem.Rows[idx].Cells["ColBuilding"].Value = item.Building;
                dataGridView_SaleItem.Rows[idx].Cells["ColUnit"].Value = item.Unit;
                dataGridView_SaleItem.Rows[idx].Cells["ColItemNum"].Value = item.ItemNum;
                dataGridView_SaleItem.Rows[idx].Cells["ColArea"].Value = item.Area;
                dataGridView_SaleItem.Rows[idx].Cells["ColPrice"].Value = item.Price;
                dataGridView_SaleItem.Rows[idx].Cells["ColAmout"].Value = Math.Round((double.Parse(item.Area) * double.Parse(item.Price)), 0, MidpointRounding.AwayFromZero).ToString();
                dataGridView_SaleItem.Rows[idx].Cells["ColIsBind"].Value = item.IsBind;

                dataGridView_SaleItem.Rows[idx].Cells[2].Selected = true;

                getRowsTotalAmount();
            }
        }

        private bool isExist(string itemID)
        {
            bool result = false;

            for (int i = 0; i < dataGridView_SaleItem.Rows.Count; i++)
            {
                if (dataGridView_SaleItem.Rows[i].Cells["ColItemID"].FormattedValue.ToString() == itemID)
                    return true;
            }

            return result;
        }

        private void button_Installment_Click(object sender, EventArgs e)
        {
            FrmInstallment frmInstallment = new FrmInstallment();

            frmInstallment.InstallmentAmount = textBox_DownPay.Text;
            frmInstallment.ContractID = ContractID;
            frmInstallment.dtInstallment = dtInstallment;
            frmInstallment.FrmMode = this.FrmMode;

            if (frmInstallment.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                dtInstallment = frmInstallment.dtInstallment;
        }

        private void textBox_DownPayRate_Validated(object sender, EventArgs e)
        {
            double dResult = 0;
            double.TryParse(textBox_DownPayRate.Text.Trim(), out dResult);
            textBox_DownPayRate.Text = dResult.ToString();
        }

        private void toolStripButton_Exchange_Click(object sender, EventArgs e)
        {
            exchang();
        }


    }
}
