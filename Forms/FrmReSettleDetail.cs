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

namespace Commission.Forms
{
    public partial class FrmReSettleDetail : Form
    {
        public string FullSettleID = string.Empty;
        public FrmReSettleDetail()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool isChecked(string sid)
        {
            bool result = false;
            string sql = string.Format("select isnull(count(SID),0) from ReSettleMain where SID = {0} and Checker is not null", sid);
            int sqlResult = int.Parse(SqlHelper.ExecuteScalar(sql).ToString());
            if (sqlResult > 0)
            {
                result = true;
            }

            return result;
        }

        private void FrmReSettleDetail_Load(object sender, EventArgs e)
        {
            //loadData();
            LoadFullSettleDate();
        }


        private void LoadFullSettleDate()
        {
            string sql = string.Empty;
            sql = "select ProjectName,TableName,TableMaker,SettleDate,Checker from FullSettleMain where FullSettleID = " + FullSettleID;
            SqlDataReader sdr_main = SqlHelper.ExecuteReader(sql);
            sdr_main.Read();

            label_ProjectName.Text = sdr_main["ProjectName"].ToString();
            label_TableName.Text = sdr_main["TableName"].ToString();
            label_TableMaker.Text = sdr_main["TableMaker"].ToString();
            label_Date.Text = sdr_main["SettleDate"].ToString();
            label_Checker.Text = sdr_main["Checker"].ToString();

            dataGridView_Settlement.AutoGenerateColumns = false;
            dataGridView_Settlement.DataSource = null;

            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColCommissionAll"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColPremiumAll"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColTotalAll"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColCommissionSettleAll"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColPremiumSettleAll"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColUpSettleAll"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColSettleAll"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColSettleDifference"], ColType.amount);

            dataGridView_Settlement.DataSource = SqlHelper.ExecuteDataTable(string.Format("select * from FullSettleDetail where FullSettleID = {0}", FullSettleID));


        }

        private void loadData()
        {
            string sql = string.Empty;
            sql = "select ProjectName,TableName,TableMaker,SettleDate,Checker from ReSettleMain where SID = " + FullSettleID;
            SqlDataReader sdr_main = SqlHelper.ExecuteReader(sql);
            sdr_main.Read();

            label_ProjectName.Text = sdr_main["ProjectName"].ToString();
            label_TableName.Text = sdr_main["TableName"].ToString();
            label_TableMaker.Text = sdr_main["TableMaker"].ToString();
            label_Date.Text = sdr_main["SettleDate"].ToString();
            label_Checker.Text = sdr_main["Checker"].ToString();

            string sqlField = "select TID, ContractCode, CustomerName, "
                + "Building, Unit, ItemNum, Area, Price ,Amount, TotalAmount,'' as BottomPrice,'' as SubscriptDate, ContractDate, "
                + "'' as Receipt, '' as Commission, '' as Addition, '' as CommTotal, '' as SettledTotal, '' as SettledDiffer "
                + "from V_TransactionBase where 1 = 2 ";

            DataTable dt_Settlement = Transaction.genCol(dataGridView_Settlement, 12, sqlField);

            dt_Settlement.Columns.Add("SDID", typeof(string));
            dt_Settlement.Columns.Add("SID", typeof(string));


            sql = "select SDID,SID,TID,ContractCode,ContractDate,BottomPrice,Receipt,Commission,Addition,CommTotal,SettledTotal,SettledDiffer from ReSettleDetail where SID = " + FullSettleID;
            SqlDataReader sdr = SqlHelper.ExecuteReader(sql);
            while (sdr.Read())
            {
                string tid = sdr["TID"].ToString();
                string contractCode = sdr["ContractCode"].ToString();

                DataRow dr = dt_Settlement.NewRow();

                //业务信息--主表
                sql = string.Format("select TID, ContractCode , CustomerName, TotalAmount, ContractDate from [V_TransactionBase] where TID = {0} and ContractCode = '{1}'", tid, contractCode);
                SqlDataReader sdrTrans = SqlHelper.ExecuteReader(sql);
                sdrTrans.Read();
                for (int i = 0; i < sdrTrans.FieldCount; i++)
                {
                    string fieldName = sdrTrans.GetName(i);
                    dr[fieldName] = sdrTrans.GetValue(i);
                }

                //业务明细--非储藏间：（ItemType <> 3） //要求单独购买，仅一条记录!!!
                string sqlDetail = string.Format("select  Building, Unit, ItemNum, Area, Price ,Amount from [TransDetail] where TID = {0} and ContractCode = '{1}' and ItemType <> 3 ", tid, contractCode);
                SqlDataReader sdrDetail = SqlHelper.ExecuteReader(sqlDetail);

                if (sdrDetail.Read())
                {
                    for (int i = 0; i < sdrDetail.FieldCount; i++)
                    {
                        string fieldName = sdrDetail.GetName(i);
                        dr[fieldName] = sdrDetail.GetValue(i);
                    }
                }

                //业务明细--储藏间：（ItemType ＝ 3)
                string sqlDetail1_Store = string.Format("select ItemNum, Area, Price ,Amount from [TransDetail] where TID = {0} and ContractCode = '{1}' and ItemType = 3", tid, contractCode);
                SqlDataReader sdrDetail_Store = SqlHelper.ExecuteReader(sqlDetail1_Store);

                int fieldIndex = 0;
                while (sdrDetail_Store.Read())
                {
                    for (int i = 0; i < sdrDetail_Store.FieldCount; i++)
                    {
                        string fieldName = sdrDetail_Store.GetName(i) + fieldIndex.ToString();



                        if ((sdrDetail_Store.GetName(i).ToString() == "Price") || (sdrDetail_Store.GetName(i).ToString() == "Amount"))
                        {
                            dr[fieldName] = string.Format("{0:F0}", sdrDetail_Store.GetValue(i));
                        }
                        else
                        {
                            dr[fieldName] = sdrDetail_Store.GetValue(i);
                        }
                    }

                    fieldIndex++;
                }

                dr["SDID"] = sdr["SDID"].ToString();
                dr["SID"] = sdr["SID"].ToString();
                dr["SubscriptDate"] = string.Format("{0:d}", sdr["ContractDate"]);
                dr["BottomPrice"] = string.Format("{0:f0}", sdr["BottomPrice"]);
                dr["Receipt"] = string.Format("{0:f0}", sdr["Receipt"]);

                dr["Commission"] = string.Format("{0:f0}", sdr["Commission"]);
                dr["Addition"] = string.Format("{0:f0}", sdr["Addition"]);

                dr["CommTotal"] = string.Format("{0:f0}", sdr["CommTotal"]);

                dr["SettledTotal"] = string.Format("{0:f0}", sdr["SettledTotal"]);
                dr["SettledDiffer"] = string.Format("{0:f0}", sdr["SettledDiffer"]);

                dt_Settlement.Rows.Add(dr);
            }

            dataGridView_Settlement.DataSource = dt_Settlement;
        }

        //审核
        private void toolStripButton_Check_Click(object sender, EventArgs e)
        {
            DataTable dt_Settle = (DataTable)dataGridView_Settlement.DataSource;
            if (dt_Settle == null)
            {
                return;
            }

            if (dt_Settle.Rows.Count == 0)
            {
                Prompt.Warning("无结算记录，不能审核！");
                return;
            }

            if (!label_Checker.Text.Equals(""))
            {
                Prompt.Information("已经审核，无法进行再次审核！");
                return;
            }

            string sql = string.Format("update FullSettleMain set Checker = '{0}', CheckDate = GETDATE() where FullSettleID = {1}", Login.User.UserName, FullSettleID);
            if (SqlHelper.ExecuteNonQuery(sql) > 0)
                label_Checker.Text = Login.User.UserName;
 
        }

        //删除确权记录
        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {
            if ((dataGridView_Settlement.Rows.Count == 0) || (dataGridView_Settlement.CurrentRow == null))
            {
                Prompt.Warning("没有选择记录！");
                return;
            }

            if (!label_Checker.Text.Equals(""))
            {
                Prompt.Warning("结算已审核，无法删除！");
                return;
            }

            if (dataGridView_Settlement.Rows.Count == 1)
            {
                Prompt.Warning("仅有一条记录！无法清空报表，请直接删除报表");
                return;
            }



            int rowIdx = dataGridView_Settlement.CurrentRow.Index;

            if (rowIdx != -1)  
            {
                if (MessageBox.Show("确认要删除选择的记录？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    using (SqlConnection connection = SqlHelper.OpenConnection())  //创建连接对象 
                    {
                        SqlTransaction sqlTran = connection.BeginTransaction();    //开始事务 
                        SqlCommand cmd = connection.CreateCommand();               //创建SqlCommand对象 
                        cmd.Transaction = sqlTran;

                        try
                        {
                            string id = dataGridView_Settlement.CurrentRow.Cells["ColID"].Value.ToString();
                            string contractID = dataGridView_Settlement.CurrentRow.Cells["ColContractID"].Value.ToString();
                            string fullSettleID = dataGridView_Settlement.CurrentRow.Cells["ColFullSettleID"].Value.ToString();

                            cmd.CommandText = string.Format("update ContractMain set FullSettled = 0 where ContractID = {0}", contractID);
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = string.Format("delete FullSettleDetail where id = {0}", id);
                            cmd.ExecuteNonQuery();


                            sqlTran.Commit();  //事务提交
                            //DialogResult = System.Windows.Forms.DialogResult.OK;
                        }
                        catch (Exception ex)
                        {
                            sqlTran.Rollback();  //异常事务回滚
                            Prompt.Error("操作失败， 错误：" + ex.Message);
                        }

                    }

                    dataGridView_Settlement.Rows.RemoveAt(rowIdx);
                }
            }
        }

        private void toolStripButton_Export_Click(object sender, EventArgs e)
        {
            Common.Exp2XLS(dataGridView_Settlement);
        }


    }
}
