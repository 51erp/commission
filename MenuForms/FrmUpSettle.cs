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
    public partial class FrmUpSettle : Form
    {
        string SettlePeriod = string.Empty;      //结算期间 yyyy-MM
        string SettleClosingDate = string.Empty; //结算截止日期 yyyy-MM-dd

        //string SchemeUpID = string.Empty; //跳点结算方案ID

        public FrmUpSettle()
        {
            InitializeComponent();
            SetComboBoxUpgrade();
        }


        private void SetComboBoxUpgrade()
        {
            comboBox_Upgrade.DataSource = SqlHelper.ExecuteDataTable("select UpID, UpName from SchemeUpgrade where ProjectID = " + Login.User.ProjectID);
            comboBox_Upgrade.DisplayMember = "UpName";
            comboBox_Upgrade.ValueMember = "UpID";

            if (comboBox_Upgrade.Items.Count > 0)
                comboBox_Upgrade.SelectedIndex = 0;
        }


        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_SettleUp_Click(object sender, EventArgs e)
        {
            if (comboBox_Upgrade.SelectedIndex < 0)
            {
                Prompt.Warning("未设置跳点方案无法进行结算！");
                return;
            }

            

            SettlePeriod = dateTimePicker_SettlePeriod.Value.ToString("yyyy-MM");
            SettleClosingDate = SettlePeriod + dateTimePicker_ClosingDate.Value.ToString("-dd");

            UpgradeSettle();
        }


        private void UpgradeSettle()
        {
            button_SettleUp.Enabled = false;

            dataGridView_Settlement.AutoGenerateColumns = false;
            dataGridView_Settlement.DataSource = null;

            string upId = comboBox_Upgrade.SelectedValue.ToString();

            double standardValue = GetStandardValue(upId);      //统计跳点方案的业务数值

            double upRate = GetUpSettleRate(standardValue); //依据数值获取相应的跳点比例

            double baseRate = GetBaseRate(upId);

            if (upRate > baseRate) //不符合跳点，或无新跳点
            {
                int i = 0;
                DataTable dtContract = GetContractBaseData(upId,string.Format("{0:F2}", baseRate), string.Format("{0:F2}", upRate), out i);

                Transaction.InsertBindCol(dataGridView_Settlement, 10, i);

                dataGridView_Settlement.DataSource = dtContract;
            }

            button_SettleUp.Enabled = true;

            if (dataGridView_Settlement.Rows.Count <= 0)
                Prompt.Information("没有符合条件的记录");

        }

        /// <summary>
        /// 统计跳点方案的业务数据
        /// </summary>
        /// <returns></returns>
        private double GetStandardValue(string upId)
        {
            double standardValue = 0;

            string sql = string.Empty;

            DataTable dtResult = new DataTable();

            sql = string.Format("select UPID,UpName,ProjectID,UpBaseCode,UpBaseName,IsSubscribe,BeginDate,EndDate from SchemeUpgrade where UPID = {0}", upId);
            dtResult = SqlHelper.ExecuteDataTable(sql);

            bool isSubscribe = (bool)dtResult.Rows[0]["IsSubscribe"];
            UpBase baseCode = (UpBase)dtResult.Rows[0]["UpBaseCode"];

            switch (baseCode)
            {
                case UpBase.Subscribe:
                    sql = string.Format("select IsNull(SUM(TotalAmount),0) from SubscribeMain a "
                        + " inner join SubscribeDetail b on a.SubscribeID = b.SubscribeID "
                        + " inner join SaleItem c on c.ItemID = b.ItemID "
                        + " where a.ProjectID = {0} and  UpID = {1} and  SubscribeDate <= '{2}'", Login.User.ProjectID, upId, SettleClosingDate);
                    standardValue = Convert.ToDouble(SqlHelper.ExecuteScalar(sql));
                    break;

                case UpBase.Contract:
                    sql = string.Format("select IsNull(SUM(TotalAmount),0) from ContractMain a " 
                        + " inner join ContractDetail b on a.ContractID = b.ContractID "
                        + " inner join SaleItem c on c.ItemID = b.ItemID "
                        + " where a.ProjectID = {0} and  UpID = {1} and ContractDate <= '{2}'", Login.User.ProjectID, upId, SettleClosingDate);
                    standardValue = Convert.ToDouble(SqlHelper.ExecuteScalar(sql));

                    if (isSubscribe)
                    {
                        sql = string.Format("select IsNull(SUM(TotalAmount),0) from SubscribeMain a "
                            + " inner join SubscribeDetail b on a.SubscribeID = b.SubscribeID "
                            + " inner join SaleItem c on c.ItemID = b.ItemID "
                            + " where a.ContractID is null and a.ProjectID = {0} and  UpID = {1} and  SubscribeDate <= '{2}'", Login.User.ProjectID, upId, SettleClosingDate);
                        standardValue += Convert.ToDouble(SqlHelper.ExecuteScalar(sql));
                    }
                    break;

                case UpBase.Receipt:
                    sql = string.Format("select IsNull(SUM(Amount),0) from Receipt a " 
                        + " inner join SaleItem c on c.ItemID = b.ItemID "
                        + " where a.ProjectID = {0} and  UpID = {1} and RecDate <= '{2}'", Login.User.ProjectID, upId, SettleClosingDate);
                    standardValue = Convert.ToDouble(SqlHelper.ExecuteScalar(sql));
                    break;

                case UpBase.Area:
                    sql = string.Format("select IsNull(SUM(Area),0) from ContractMain a "
                        + " inner join ContractDetail b on a.ContractID = b.ContractID "
                        + " inner join SaleItem c on c.ItemID = b.ItemID "
                        + " where a.ProjectID = {0} and  UpID = {1} and ContractDate <= '{2}'", Login.User.ProjectID, upId, SettleClosingDate);
                    standardValue = Convert.ToDouble(SqlHelper.ExecuteScalar(sql));

                    if (isSubscribe)
                    {
                        sql = string.Format("select IsNull(SUM(Area),0) from SubscribeMain a "
                            + " inner join SubscribeDetail b on a.SubscribeID = b.SubscribeID "
                            + " inner join SaleItem c on c.ItemID = b.ItemID "
                            + " where a.ContractID is null and a.ProjectID = {0} and  UpID = {1} and  SubscribeDate <= '{2}'", Login.User.ProjectID, upId, SettleClosingDate);
                        standardValue += Convert.ToDouble(SqlHelper.ExecuteScalar(sql));
                    }

                    break;

                case UpBase.Quantity:
                    sql = string.Format("select IsNull(count(a.ContractID),0) from ContractMain a "
                        + " inner join ContractDetail b on a.ContractID = b.ContractID "
                        + " inner join SaleItem c on c.ItemID = b.ItemID "
                        + " where a.ProjectID = {0} and  UpID = {1} and ContractDate <= '{2}'", Login.User.ProjectID, upId, SettleClosingDate);
                    standardValue = Convert.ToDouble(SqlHelper.ExecuteScalar(sql));

                    if (isSubscribe)
                    {
                        sql = string.Format("select IsNull(count(a.SubscribeID),0) from SubscribeMain a "
                            + " inner join SubscribeDetail b on a.SubscribeID = b.SubscribeID "
                            + " inner join SaleItem c on c.ItemID = b.ItemID "
                            + " where a.ContractID is null and a.ProjectID = {0} and  UpID = {1} and  SubscribeDate <= '{2}'", Login.User.ProjectID, upId, SettleClosingDate);
                        standardValue += Convert.ToDouble(SqlHelper.ExecuteScalar(sql));
                    }

                    break;

                default:
                    break;
            }

            return standardValue;
        }

        /// <summary>
        /// 根据业务数据获取相应的跳点比例
        /// </summary>
        /// <param name="standardValue"></param>
        /// <returns></returns>
        private double GetUpSettleRate(double standardValue)
        {
            double upRate = 0;

            string sql = string.Format("select BeginValue,EndValue,UpRate from UpValue where UpID = {0} order by RowNum ", comboBox_Upgrade.SelectedValue.ToString());
            DataTable dtResult = SqlHelper.ExecuteDataTable(sql);
            
            for (int i = 0; i < dtResult.Rows.Count; i++)
            {
                double beginValue = Convert.ToDouble(dtResult.Rows[i]["BeginValue"]);
                double endValue = Convert.ToDouble(dtResult.Rows[i]["EndValue"]);

                if ((i == dtResult.Rows.Count - 1) && (endValue == 0))
                {
                    if (standardValue >= beginValue)
                    {
                        upRate = Convert.ToDouble(dtResult.Rows[i]["UpRate"]);
                    }
                }
                else
                {
                    if ((standardValue >= beginValue) && (standardValue < endValue))  //含下，不含上
                    {
                        upRate = Convert.ToDouble(dtResult.Rows[i]["UpRate"]);
                    }
                }
            }

            return upRate;
        }


        /// <summary>
        /// 当前启用跳点比例
        /// </summary>
        /// <returns></returns>
        private double GetBaseRate(string upId)
        {
            double enabledRate = 0;

            string sql = string.Format("select IsNull(BaseRate,0) from SchemeUpgrade where UpID = {0}", upId);
            object obj = SqlHelper.ExecuteScalar(sql);
            if (obj != null)
            {
                enabledRate = double.Parse(obj.ToString());
            }

            return enabledRate;
        }


        private DataTable GetContractBaseData(string SchemeUpID, string baseRate, string upRate, out int iBindQuantity)
        {
            iBindQuantity = 0;
            string formatAmount = "{0:F" + Login.Parameters.PrecisionAmount + "}";
            string sql = string.Empty;

            sql = string.Format("select  a.ContractID, CustomerName, SubscribeDate, ContractDate,SalesName, TotalAmount, "
                + " b.ItemTypeName, b.ItemID, b.Building, b.Unit, b.ItemNum, b.Area, b.Price, b.Amount "
                + " from ContractMain a "
                + " inner join  ContractDetail b on a.ContractID = b.ContractID "
                + " inner join SaleItem c on c.ItemID = b.ItemID "
                + " where c.IsBind = 0 and c.UpID ={0} " 
                + " and  a.ContractID in ( select ContractID from Receipt where SettleState != 0 and RecDate < = '{1}' and ProjectID = {2} group by ContractID ) "
                + " order by a.ContractID ", SchemeUpID, SettleClosingDate, Login.User.ProjectID);

            DataTable dtContract = SqlHelper.ExecuteDataTable(sql); //主体表
            dtContract.PrimaryKey = new DataColumn[] { dtContract.Columns["ContractID"] };

            string difference = Convert.ToString((double.Parse(upRate) - double.Parse(baseRate)) / 100);

            sql = string.Format("select a.ContractID, SUM(a.amount) as ReceiptAll, '{0}' BaseRate, '{1}' UpRate, SUM(a.amount) * {2} as SettleAmount  from Receipt a "
                + " inner join ContractDetail b on b.ContractID = a.ContractID "
                + " inner join SaleItem c on c.ItemID = b.ItemID "
                + " where a.SettleState != 0 and c.UpID = {3} and RecDate < = '{4}' and a.ProjectID = {5} "
                + " group by a.ContractID ",baseRate, upRate,difference, SchemeUpID, SettleClosingDate, Login.User.ProjectID);

            DataTable dtReceipt = SqlHelper.ExecuteDataTable(sql);
            dtContract.Merge(dtReceipt, false, MissingSchemaAction.Add);


            //获取绑定（附属）物业相关信息
            for (int i = 0; i < dtContract.Rows.Count; i++)
            {
                string subId = dtContract.Rows[i]["ContractID"].ToString();

                sql = "select ItemNum, Area, Price, Amount from ContractDetail where IsBind = 1 and ContractID = " + subId;

                SqlDataReader dr = SqlHelper.ExecuteReader(sql);

                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();

                    dt.Columns.Add("ContractID", typeof(int));
                    dt.PrimaryKey = new DataColumn[] { dt.Columns["ContractID"] };

                    string fieldValue = subId;


                    int itemIdx = 0;     //一个房源相同尾号
                    while (dr.Read())
                    {
                        for (int j = 0; j < dr.FieldCount; j++) //????考虑：不在重新创建表和字段，主表一次合并，提高效率??
                        {
                            string fieldName = "BIND_" + dr.GetName(j) + itemIdx;
                            dt.Columns.Add(fieldName, typeof(string));

                            if (dr.GetName(j).Equals("Amount"))
                            {
                                fieldValue += "," + string.Format(formatAmount, dr.GetValue(j));
                            }
                            else
                            {
                                fieldValue += "," + dr.GetValue(j).ToString();
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



        /////////////////////////////////////////////////////////////////////////////////////////
        private void FrmUpSettle_Load(object sender, EventArgs e)
        {
            string closingDate = SqlHelper.ExecuteScalar(string.Format("select CONVERT(varchar(10),MAX(ClosingDate),120) from SettleMain where ProjectID = {0}", Login.User.ProjectID)).ToString();

            if (closingDate.Equals(""))
            {
                button_SettleUp.Enabled = false;
            }
            else
            {
                button_SettleUp.Enabled = true;
                dateTimePicker_SettlePeriod.Value = Convert.ToDateTime(closingDate.Substring(0,8) + "01");
                dateTimePicker_ClosingDate.Value = Convert.ToDateTime(closingDate);
            }

        }

        private void dateTimePicker_ContractDate_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker_ClosingDate.Value = Convert.ToDateTime(dateTimePicker_SettlePeriod.Value.AddMonths(1).ToString("yyyy-MM-01")).AddDays(-1);
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            if (dataGridView_Settlement.Rows.Count <= 0)
            {
                Prompt.Warning("没有结算记录，无法保存！");
                return;
            }

            FrmSettleSave save = new FrmSettleSave();

            save.tabMaker = Login.User.UserName;
            save.tabName = Login.User.ProjectName + "_" + SettlePeriod + "_跳点结算报表";

            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string upId = comboBox_Upgrade.SelectedValue.ToString();
                if (SaveUpSettle(upId, save.tabMaker, save.tabDate, save.tabName))
                {
                    DataTable dt = (DataTable)dataGridView_Settlement.DataSource;
                    dt.Rows.Clear();
                    dataGridView_Settlement.DataSource = dt;

                    Prompt.Information("操作成功");
                }
            }
        }

        private bool SaveUpSettle(string SchemeUpID, string tabMaker, string tabDate, string tabName)
        {
            bool result = false;

            string sql = string.Empty;

            using (SqlConnection connection = SqlHelper.OpenConnection())  //创建连接对象 
            {
                SqlTransaction sqlTran = connection.BeginTransaction();    //开始事务 
                SqlCommand cmd = connection.CreateCommand();               //创建SqlCommand对象 
                cmd.Transaction = sqlTran;                                 //将SqlCommand与SqlTransaction关联起

                try
                {
                    //添加结算主表
                    string values = "'" + tabName + "'," + Login.User.ProjectID + ",'" + Login.User.ProjectName + "','" + SettlePeriod + "','" + tabDate + "','" + tabMaker + "',GETDATE(),'" + Login.User.UserName + "'";
                    cmd.CommandText = string.Format("insert into UpSettleMain (TableName, ProjectID, ProjectName, SettlePeriod, SettleDate, TableMaker, MakeDate, UserName) output inserted.UpSettleID values ({0})", values);
                    string upSettleId = cmd.ExecuteScalar().ToString();


                    //添加结算从表
                    string baseRate = string.Empty;
                    string upRate = string.Empty;
                    DataTable dt_settle = (DataTable)dataGridView_Settlement.DataSource;

                    string fields = "insert into UpSettleDetail (UpSettleID,ContractID,CustomerName,SubscribeDate,ContractDate,ItemID, Building,Unit,ItemNum,Area,Price,Amount,TotalAmount,ReceiptAll,BaseRate,UpRate,SettleAmount) values ";
                    for (int i = 0; i < dt_settle.Rows.Count; i++)
                    {
                        baseRate = dt_settle.Rows[i]["BaseRate"].ToString();
                        upRate = dt_settle.Rows[i]["UpRate"].ToString();

                        values = string.Empty;
                        values = upSettleId + "," + dt_settle.Rows[i]["ContractID"].ToString()
                            + ",'" + dt_settle.Rows[i]["CustomerName"].ToString() + "'"
                            + ",'" + dt_settle.Rows[i]["SubscribeDate"].ToString() + "'"
                            + ",'" + dt_settle.Rows[i]["ContractDate"].ToString() + "'"
                            + "," + dt_settle.Rows[i]["ItemID"].ToString()
                            + ",'" + dt_settle.Rows[i]["Building"].ToString() + "'"
                            + ",'" + dt_settle.Rows[i]["Unit"].ToString() + "'"
                            + ",'" + dt_settle.Rows[i]["ItemNum"].ToString() + "'"
                            + "," + dt_settle.Rows[i]["Area"].ToString()
                            + "," + dt_settle.Rows[i]["Price"].ToString()
                            + "," + dt_settle.Rows[i]["Amount"].ToString()
                            + "," + dt_settle.Rows[i]["TotalAmount"].ToString()
                            + "," + dt_settle.Rows[i]["ReceiptAll"].ToString()
                            + "," + dt_settle.Rows[i]["BaseRate"].ToString()
                            + "," + dt_settle.Rows[i]["UpRate"].ToString()
                            + "," + dt_settle.Rows[i]["SettleAmount"].ToString();

                        cmd.CommandText = fields + "(" + values + ")";
                        cmd.ExecuteNonQuery();
                    }

                    //更新房源提点 
                    cmd.CommandText = string.Format("Update SaleItem Set SettleRate = {0} where Isbind = 0 and UpID = {1}", upRate, SchemeUpID);
                    cmd.ExecuteNonQuery();

                    //更新方案信息
                    cmd.CommandText = string.Format("Update SchemeUpgrade Set BaseRate = {0} where UpID = {1}", upRate, SchemeUpID);
                    cmd.ExecuteNonQuery();

                    //where UpRate = {2} and UpID = {3} 定位行（保证UpRate唯一，否错误，应该取RowNum）
                    cmd.CommandText = string.Format("Update UpValue Set Enabled = {0}, BaseOnRate = {1} where UpRate = {2} and UpID = {3}", upSettleId, baseRate, upRate, SchemeUpID);
                    cmd.ExecuteNonQuery();


                    sqlTran.Commit();  //事务提交
                    connection.Close();

                    result = true;
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();  //异常事务回滚
                    Prompt.Error("操作失败， 错误：" + ex.Message);
                }
            }

            return result;
        }

        private void FrmUpSettle_Shown(object sender, EventArgs e)
        {
            if (button_SettleUp.Enabled == false)
            {
                Prompt.Warning("没有相应的基础结算，无法进行跳点结算！");
            }
        }

        private void toolStripButton_Exp2XLS_Click(object sender, EventArgs e)
        {
            Common.Exp2XLS(dataGridView_Settlement);
        }
    }
}
