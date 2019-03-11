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
    public partial class FrmUpSettleReport : Form
    {
        string ProjectID = string.Empty;

        public FrmUpSettleReport()
        {
            InitializeComponent();
            comboBox_CheckState.SelectedIndex = 0;
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string condition = " and ProjectID = " + Login.User.ProjectID;

            if (comboBox_CheckState.Text == "未审")
            {
                condition += " and Checker is null";
            }
            else if (comboBox_CheckState.Text == "已审")
            {
                condition += " and Checker is not null";
            }

            string sql = "select UpSettleID, TableName, ProjectID, SettleDate, TableMaker,Checker,CheckDate  from UpSettleMain where 1=1 " + condition + " order by ProjectID";

            dataGridView_SettleMain.DataSource = SqlHelper.ExecuteDataTable(sql);

            if (dataGridView_SettleMain.Rows.Count == 0)
                Prompt.Warning("没有符合条件的记录！");
        }

        private void toolStripButton_Detail_Click(object sender, EventArgs e)
        {
            if ((dataGridView_SettleMain.Rows.Count == 0) || (dataGridView_SettleMain.CurrentRow == null))
            {
                Prompt.Warning("没有选择记录！");
                return;
            }

            int rowIdx = dataGridView_SettleMain.CurrentRow.Index;

            if (rowIdx != -1)
            {
                FrmUpSettleDetail detail = new FrmUpSettleDetail();

                detail.UpSettleID = dataGridView_SettleMain.CurrentRow.Cells["ColUpSettleID"].Value.ToString();

                detail.ShowDialog();
            }
        }

        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {
            if ((dataGridView_SettleMain.Rows.Count == 0) || (dataGridView_SettleMain.CurrentRow == null))
            {
                Prompt.Warning("没有选择记录！");
                return;
            }

            if (isChecked(dataGridView_SettleMain.CurrentRow.Cells["ColUpSettleID"].Value.ToString()))
            {
                Prompt.Warning("结算已经审核无法删除！");
                return;
            }

            //????????????????????????????
            //跳点结算后又生成了提点结算，跳点结算不能删除，删除提点结算后才能删除。
            //MAX(MakeDate)



            int rowIdx = dataGridView_SettleMain.CurrentRow.Index;

            if (rowIdx != -1)
            {
                if (MessageBox.Show("确认要删除选择的记录？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    using (SqlConnection connection = SqlHelper.OpenConnection())  //创建连接对象 
                    {
                        SqlTransaction sqlTran = connection.BeginTransaction();    //开始事务 
                        SqlCommand cmd = connection.CreateCommand();               //创建SqlCommand对象 
                        cmd.Transaction = sqlTran;                                 //将SqlCommand与SqlTransaction关联起

                        try
                        {
                            string upSettleID = dataGridView_SettleMain.CurrentRow.Cells["ColUpSettleID"].Value.ToString();

                            //取对应的历史提点
                            DataTable dtUp = SqlHelper.ExecuteDataTable(string.Format("select UpID, BaseOnRate from UpValue where Enabled = {0}", upSettleID));
                            string upID = dtUp.Rows[0]["UpID"].ToString();
                            string baseOnRate = dtUp.Rows[0]["BaseOnRate"].ToString();

                            //更新SaleItem.提点
                            SqlHelper.ExecuteNonQuery(string.Format("update SaleItem Set SettleRate = {0} where UpID = {1}", baseOnRate, upID));

                            //更新方案.BaseRate
                            SqlHelper.ExecuteNonQuery(string.Format("update SchemeUpgrade set BaseRate = {0} where UpID = {1}", baseOnRate, upID));

                            //更新方案值数据
                            SqlHelper.ExecuteNonQuery(string.Format("update UpValue set Enabled = 0, BaseOnRate = null where Enabled = {0}", upSettleID));

                            //删除从表
                            SqlHelper.ExecuteNonQuery(string.Format("delete UpSettleDetail where UpSettleID = {0}", upSettleID));

                            //删除主表
                            SqlHelper.ExecuteNonQuery(string.Format("delete UpSettleMain where UpSettleID = {0}", upSettleID));

                            sqlTran.Commit();  //事务提交
                            connection.Close();

                            dataGridView_SettleMain.Rows.RemoveAt(rowIdx);

                            Prompt.Information("操作成功!");

                        }
                        catch (Exception ex)
                        {
                            sqlTran.Rollback();  //异常事务回滚
                            Prompt.Error("操作失败， 错误：" + ex.Message);
                        }
                    }

                }
            }
        }

        private bool isChecked(string sid)
        {
            bool result = false;

            string sql = string.Format("select isnull(count(UpSettleID),0) from UpSettleMain where Checker is not null and UpSettleID = {0}", sid);
            int sqlResult = int.Parse(SqlHelper.ExecuteScalar(sql).ToString());
            if (sqlResult > 0)
            {
                result = true;
            }

            return result;
        }

        private void toolStripButton_Restore_Click(object sender, EventArgs e)
        {
            if ((dataGridView_SettleMain.Rows.Count == 0) || (dataGridView_SettleMain.CurrentRow == null))
            {
                Prompt.Warning("没有选择记录！");
                return;
            }


            if (dataGridView_SettleMain.CurrentRow.Cells["ColChecker"].Value.ToString().Equals(""))
            {
                Prompt.Warning("记录未审核！");
                return;
            }
            if (MessageBox.Show("确定要进行反审操作？", Common.MsgCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string settleId = dataGridView_SettleMain.CurrentRow.Cells["ColUpSettleID"].Value.ToString();
                string sql = string.Format("update UpSettleMain set Checker = null, CheckDate = null where SettleID = {0}", settleId);
                if (SqlHelper.ExecuteNonQuery(sql) > 0)
                {
                    dataGridView_SettleMain.CurrentRow.Cells["ColChecker"].Value = "";
                    dataGridView_SettleMain.CurrentRow.Cells["ColCheckDate"].Value = "";
                }
            }

        }

    }
}
