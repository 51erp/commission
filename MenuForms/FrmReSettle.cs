using Commission.Business;
using Commission.Forms;
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

namespace Commission.MenuForms
{
    public partial class FrmReSettle : Form
    {
        public FrmReSettle()
        {
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Settle_Click(object sender, EventArgs e)
        {
            FullSettle();
        }


        private void FullSettle()
        {
            button_Settle.Enabled = false;

            dataGridView_Settlement.AutoGenerateColumns = false;
            dataGridView_Settlement.DataSource = null;

            int bindQty = 0;
            DataTable dtContract = GetContractData("", out bindQty);

            Transaction.InsertBindCol(dataGridView_Settlement, 13, bindQty);

            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColCommissionAll"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColPremiumAll"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColTotalAll"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColCommissionSettleAll"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColPremiumSettleAll"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColUpSettleAll"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColSettleAll"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColSettleDifference"], ColType.amount);

            dataGridView_Settlement.DataSource = dtContract;

            button_Settle.Enabled = true;

            if (dataGridView_Settlement.Rows.Count == 0)
                Prompt.Information("没有符合条件的记录！");
        }



        public DataTable GetContractData(string condition, out int iBindQuantity)
        {
            iBindQuantity = 0;
            string formatAmount = "{0:F" + Login.Parameters.PrecisionAmount + "}";
            string sql = string.Empty;

            sql = "select  a.ContractID, CustomerName,SubscribeDate, ContractDate, TotalAmount, "
                + " b.ItemTypeName,b.ItemID, b.Building, b.Unit, b.ItemNum, b.Area, b.Price, b.Amount, "
                + " c.SettleRate, c.BottomPrice, c.BottomPriceLimit, c.BottomPriceRate "
                + " from ContractMain a "
                + " inner join  ContractDetail b on b.ContractID = a.ContractID "
                + " inner join SaleItem c on c.ItemID = b.ItemID "
                + " where a.FullSettled = 0 and b.IsBind = 0 and a.ConfirmDate is not null and BottomPrice > 0 and a.ProjectID = " + Login.User.ProjectID + condition
                + " order by a.ContractID ";

            DataTable dtContract = SqlHelper.ExecuteDataTable(sql); //主体表

            dtContract.PrimaryKey = new DataColumn[] { dtContract.Columns["ContractID"] };

            sql = string.Format("select ContractID, SUM(Amount) as ReceiptAll from Receipt where ProjectID = {0} group by ContractID ", Login.User.ProjectID);
            DataTable dtReceipt = SqlHelper.ExecuteDataTable(sql);
            dtReceipt.PrimaryKey = new DataColumn[] { dtReceipt.Columns["ContractID"] };

            string contractId = string.Empty;
            dtContract.Columns.Add("ReceiptAll", typeof(string));          //累计收款
            dtContract.Columns.Add("CommissionAll", typeof(string));       //应结佣金
            dtContract.Columns.Add("PremiumAll", typeof(string));          //应结溢价
            dtContract.Columns.Add("TotalAll", typeof(string));            //应结总额
            dtContract.Columns.Add("CommissionSettleAll", typeof(string)); //已结佣金
            dtContract.Columns.Add("PremiumSettleAll", typeof(string));    //已结溢价
            dtContract.Columns.Add("UpSettleAll", typeof(string));         //已结跳点
            dtContract.Columns.Add("SettleAll", typeof(string));           //已结总额
            dtContract.Columns.Add("SettleDifference", typeof(string));    //结算差额

            for (int i = 0; i < dtContract.Rows.Count; i++)
            {
                contractId = dtContract.Rows[i]["ContractID"].ToString();

                DataRow[] dr = dtReceipt.Select("ContractID = " + contractId);

                double totalAmount = Convert.ToDouble(dtContract.Rows[i]["TotalAmount"]);
                double receiptAll = Convert.ToDouble(dr[0]["ReceiptAll"]);

                if (totalAmount != receiptAll)
                {
                    dtContract.Rows[i].Delete();
                    continue;
                }

                dtContract.Rows[i]["ReceiptAll"] = receiptAll;
                
                //应结佣金  ＝ 底价*面积*结算比例
                double commission = Convert.ToDouble(dtContract.Rows[i]["BottomPrice"]) * Convert.ToDouble(dtContract.Rows[i]["Area"]) * Convert.ToDouble(dtContract.Rows[i]["SettleRate"]) /100;

                //应结溢价 ＝ 差额 *面积 * 溢价分成
                double difference = Convert.ToDouble(dtContract.Rows[i]["Price"]) - Convert.ToDouble(dtContract.Rows[i]["BottomPrice"]);
                double limit =  Convert.ToDouble(dtContract.Rows[i]["BottomPriceLimit"]);
                if ((limit > 0 ) && (difference > limit))
                {
                    difference = limit;
                }

                double premium = difference * Convert.ToDouble(dtContract.Rows[i]["Area"]) * Convert.ToDouble(dtContract.Rows[i]["BottomPriceRate"]) /100;

                dtContract.Rows[i]["CommissionAll"] = commission.ToString();
                dtContract.Rows[i]["PremiumAll"] = premium.ToString();
                dtContract.Rows[i]["TotalAll"] = (commission + premium).ToString();
            }

            dtContract.AcceptChanges();

            sql = string.Format("select a.ContractID, ISNULL(SUM(a.Commission),0) CommissionSettleAll ,ISNULL(SUM(a.Premium),0) PremiumSettleAll, ISNULL(SUM(c.SettleAmount),0) UpSettleAll from SettleDetail a "
                + " inner join SaleItem b on a.itemid = b.ItemID "
                + " left join UpSettleDetail c on c.ContractID = a.ContractID "
                + " where b.BottomPrice > 0 and ProjectID = {0} "
                + " group by a.ContractID ",Login.User.ProjectID);

            DataTable dtSettlement = SqlHelper.ExecuteDataTable(sql);

            for (int i = 0; i < dtContract.Rows.Count; i++)
            {
                contractId = dtContract.Rows[i]["ContractID"].ToString();
                DataRow[] dr = dtSettlement.Select("ContractID = " + contractId);

                if (dr.Length > 0)
                {
                    dtContract.Rows[i]["CommissionSettleAll"] = string.Format("{0:F0}",dr[0]["CommissionSettleAll"]);
                    dtContract.Rows[i]["PremiumSettleAll"] = string.Format("{0:F0}",dr[0]["PremiumSettleAll"]);
                    dtContract.Rows[i]["UpSettleAll"] = string.Format("{0:F0}",dr[0]["UpSettleAll"]);

                    double settleAll = Convert.ToDouble(dr[0]["CommissionSettleAll"]) + Convert.ToDouble(dr[0]["PremiumSettleAll"]) + Convert.ToDouble(dr[0]["UpSettleAll"]);

                    dtContract.Rows[i]["SettleAll"] = settleAll;

                    dtContract.Rows[i]["SettleDifference"] = Convert.ToDouble(dtContract.Rows[i]["TotalAll"]) - settleAll;
                }

            }

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



        /// <summary>
        /// 保存确权结构数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            if (dataGridView_Settlement.Rows.Count <= 0)
            {
                Prompt.Warning("没有结算记录，无法保存！");
                return;
            }

            FrmSettleSave save = new FrmSettleSave();

            save.tabMaker = Login.User.UserName;
            save.tabName = Login.User.ProjectName + "_" + DateTime.Now.ToShortDateString() + "_确权结算报表";

            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (SaveFullSettle(save.tabMaker, save.tabDate, save.tabName))
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
        private bool SaveFullSettle(string tabMaker, string tabDate, string tabName)
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
                    string values = "'" + tabName + "'," + Login.User.ProjectID + ",'" + Login.User.ProjectName + "','" + tabDate + "','" + tabMaker + "',GETDATE(),'" + Login.User.UserName + "'";
                    cmd.CommandText = string.Format("insert into FullSettleMain (TableName, ProjectID, ProjectName, SettleDate, TableMaker, MakeDate, UserName) output inserted.FullSettleID values ({0})", values);
                    string fullSettleID = cmd.ExecuteScalar().ToString();


                    //添加结算从表
                    DataTable dtSettle = (DataTable)dataGridView_Settlement.DataSource;

                    string fields = "insert into FullSettleDetail " 
                        + "(FullSettleID,ContractID,CustomerName, SubscribeDate,ContractDate,ItemID,Building,Unit,ItemNum,Area,Price,Amount,TotalAmount, "
                        + " BottomPrice,ReceiptAll,CommissionAll,PremiumAll,TotalAll,CommissionSettleAll,PremiumSettleAll, " 
                        + " UpSettleAll,SettleAll,SettleDifference ) values ";


                    for (int i = 0; i < dtSettle.Rows.Count; i++)
                    {
                        values = string.Empty;

                        values = fullSettleID
                            + "," + dtSettle.Rows[i]["ContractID"].ToString()
                            + ",'" + dtSettle.Rows[i]["CustomerName"].ToString() + "'"
                            + ",'" + dtSettle.Rows[i]["SubscribeDate"].ToString() + "'"
                            + ",'" + dtSettle.Rows[i]["ContractDate"].ToString() + "'"
                            + "," + dtSettle.Rows[i]["ItemID"].ToString()
                            + ",'" + dtSettle.Rows[i]["Building"].ToString() + "'"
                            + ",'" + dtSettle.Rows[i]["Unit"].ToString() + "'"
                            + ",'" + dtSettle.Rows[i]["ItemNum"].ToString() + "'"
                            + "," + dtSettle.Rows[i]["Area"].ToString()
                            + "," + dtSettle.Rows[i]["Price"].ToString()
                            + "," + dtSettle.Rows[i]["Amount"].ToString()
                            + "," + dtSettle.Rows[i]["TotalAmount"].ToString()
                            + "," + dtSettle.Rows[i]["BottomPrice"].ToString()
                            + "," + dtSettle.Rows[i]["ReceiptAll"].ToString()
                            + "," + dtSettle.Rows[i]["CommissionAll"].ToString()
                            + "," + dtSettle.Rows[i]["PremiumAll"].ToString()
                            + "," + dtSettle.Rows[i]["TotalAll"].ToString()
                            + "," + dtSettle.Rows[i]["CommissionSettleAll"].ToString()
                            + "," + dtSettle.Rows[i]["PremiumSettleAll"].ToString()
                            + "," + dtSettle.Rows[i]["UpSettleAll"].ToString()
                            + "," + dtSettle.Rows[i]["SettleAll"].ToString()
                            + "," + dtSettle.Rows[i]["SettleDifference"].ToString();

                        cmd.CommandText = fields + "(" + values + ")";
                        cmd.ExecuteNonQuery();


                        //更新签约合同状态
                        cmd.CommandText = string.Format("update ContractMain set FullSettled = {0} where ContractID = {1}",fullSettleID, dtSettle.Rows[i]["ContractID"].ToString());
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
                }
            }
            return result;
        }

        private void toolStripButton_Export_Click(object sender, EventArgs e)
        {
            Common.Exp2XLS(dataGridView_Settlement);
        }



    }
}
