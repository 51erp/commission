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
    public partial class FrmReSettleReport : Form
    {
        string ProjectID = string.Empty;
        public FrmReSettleReport()
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
            string condition = string.Empty;

            if (comboBox_CheckState.Text == "未审")
            {
                condition += " and Checker is null";
            }
            else if (comboBox_CheckState.Text == "已审")
            {
                condition += " and Checker is not null";
            }

            string sql = "select FullSettleID, TableName, ProjectID, SettleDate,TableMaker,Checker,CheckDate  from FullSettleMain where ProjectID = " + Login.User.ProjectID + condition + " order by ProjectID";

            dataGridView_SettleMain.DataSource = SqlHelper.ExecuteDataTable(sql);

            if (dataGridView_SettleMain.Rows.Count == 0)
                Prompt.Information("没有符合条件的记录！");
        }

        //删除确权结算
        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {
            if ((dataGridView_SettleMain.Rows.Count == 0) || (dataGridView_SettleMain.CurrentRow == null))
            {
                Prompt.Warning("没有选择记录！");
                return;
            }

            if (isChecked(dataGridView_SettleMain.CurrentRow.Cells["ColFullSettleID"].Value.ToString()))
            {
                Prompt.Warning("结算已经审核无法删除！");
                return;
            }


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
                            string sql = string.Empty;
                            string fullSettleID = dataGridView_SettleMain.CurrentRow.Cells["ColFullSettleID"].Value.ToString();

                            sql = "update ContractMain set FullSettled = 0 where  FullSettled = " + fullSettleID;
                            SqlHelper.ExecuteNonQuery(sql);

                            sql = "delete FullSettleDetail where FullSettleID = " + fullSettleID;
                            SqlHelper.ExecuteNonQuery(sql);

                            sql = "delete FullSettleMain where FullSettleID = " + fullSettleID;
                            SqlHelper.ExecuteNonQuery(sql);
                            
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
                FrmReSettleDetail detail = new FrmReSettleDetail();

                detail.FullSettleID = dataGridView_SettleMain.CurrentRow.Cells["ColFullSettleID"].Value.ToString();

                detail.ShowDialog();
            }
        }

        private bool isChecked(string fullSettleID)
        {
            bool result = false;

            string sql = string.Format("select isnull(count(FullSettleID),0) from FullSettleMain where Checker is not null and FullSettleID = {0}", fullSettleID);
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
                string settleId = dataGridView_SettleMain.CurrentRow.Cells["ColFullSettleID"].Value.ToString();
                string sql = string.Format("update FullSettleMain set Checker = null, CheckDate = null where SettleID = {0}", settleId);
                if (SqlHelper.ExecuteNonQuery(sql) > 0)
                {
                    dataGridView_SettleMain.CurrentRow.Cells["ColChecker"].Value = "";
                    dataGridView_SettleMain.CurrentRow.Cells["ColCheckDate"].Value = "";
                }
            }
        }




    }
}
