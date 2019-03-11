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
    public partial class FrmSettleReport : Form
    {

        private string ProjectID = string.Empty;
        private string Period = string.Empty;

        public FrmSettleReport()
        {
            InitializeComponent();
            comboBox_CheckState.SelectedIndex = 0;
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Detail_Click(object sender, EventArgs e)
        {
            ShowDetailForm();
        }

        private void ShowDetailForm()
        {
            if ((dataGridView_SettleMain.Rows.Count == 0) || (dataGridView_SettleMain.CurrentRow == null))
            {
                Prompt.Warning("没有选择记录！");
                return;
            }

            int rowIdx = dataGridView_SettleMain.CurrentRow.Index;

            if (rowIdx != -1)
            {
                FrmSettleDetail detail = new FrmSettleDetail();

                detail.RepSettle.Add("SettleID", dataGridView_SettleMain.CurrentRow.Cells["ColSettleID"].Value.ToString());
                detail.RepSettle.Add("ProjectID", dataGridView_SettleMain.CurrentRow.Cells["ColProjectID"].Value.ToString());
                detail.RepSettle.Add("ProjectName", dataGridView_SettleMain.CurrentRow.Cells["ColProjectName"].Value.ToString());
                detail.RepSettle.Add("TableName", dataGridView_SettleMain.CurrentRow.Cells["ColTableName"].Value.ToString());
                detail.RepSettle.Add("TableMaker", dataGridView_SettleMain.CurrentRow.Cells["ColTableMaker"].Value.ToString());
                detail.RepSettle.Add("SettleDate", dataGridView_SettleMain.CurrentRow.Cells["ColSettleDate"].FormattedValue.ToString());
                detail.RepSettle.Add("SettlePeriod", dataGridView_SettleMain.CurrentRow.Cells["ColSettlePeriod"].Value.ToString());
                detail.RepSettle.Add("Checker", dataGridView_SettleMain.CurrentRow.Cells["ColChecker"].Value.ToString());
                detail.RepSettle.Add("CheckDate", dataGridView_SettleMain.CurrentRow.Cells["ColCheckDate"].FormattedValue.ToString());

                detail.ShowDialog();

                dataGridView_SettleMain.CurrentRow.Cells["ColChecker"].Value = detail.RepSettle["Checker"];
                dataGridView_SettleMain.CurrentRow.Cells["ColCheckDate"].Value = detail.RepSettle["CheckDate"];
            }
        }


        private void button_Search_Click(object sender, EventArgs e)
        {
            Period = dateTimePicker_Period.Text;

            string condition = "SettlePeriod  = '" + Period + "'";

            if (comboBox_CheckState.Text == "未审")
            {
                condition += " and Checker is null";
            }else if (comboBox_CheckState.Text == "已审")
            {
                condition += " and Checker is not null";
            }

            string sql = string.Format("select SettleID, TableName, ProjectID, ProjectName,SettlePeriod,SettleDate,TableMaker,Checker,CheckDate  from SettleMain where ProjectID = {0}  and {1} order by ProjectID", Login.User.ProjectID, condition);

            dataGridView_SettleMain.DataSource = SqlHelper.ExecuteDataTable(sql);

            if (dataGridView_SettleMain.Rows.Count == 0)
                Prompt.Information("未查询到符合条件的记录！");

        }

        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {
            if ((dataGridView_SettleMain.Rows.Count == 0) || (dataGridView_SettleMain.CurrentRow == null))
            {
                Prompt.Warning("没有选择记录！");
                return;
            }


            if (!dataGridView_SettleMain.CurrentRow.Cells["ColChecker"].Value.ToString().Equals(""))
            {
                Prompt.Warning("结算已经审核无法删除！");
                return;
            }


            int rowIdx = dataGridView_SettleMain.CurrentRow.Index;

            if (rowIdx != -1)
            {
                if (MessageBox.Show("确认要删除选择的记录？","", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    using (SqlConnection connection = SqlHelper.OpenConnection())  //创建连接对象 
                    {
                        SqlTransaction sqlTran = connection.BeginTransaction();    //开始事务 
                        SqlCommand cmd = connection.CreateCommand();               //创建SqlCommand对象 
                        cmd.Transaction = sqlTran;                                 //将SqlCommand与SqlTransaction关联起

                        try
                        {
                            string settleID = dataGridView_SettleMain.CurrentRow.Cells["ColSettleID"].Value.ToString();
                            string sql = "delete SettleMain where SettleID = " + settleID;
                            SqlHelper.ExecuteNonQuery(sql);

                            sql = "delete SettleDetail where SettleID = " + settleID;
                            SqlHelper.ExecuteNonQuery(sql);

                            sql = "update Receipt set SettleState = 0 where SettleState = " + settleID;
                            SqlHelper.ExecuteNonQuery(sql);

                            sql = "update Installment set Settled = 0 where Settled = " + settleID;
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

        private void dataGridView_SettleMain_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ShowDetailForm();
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
            if (MessageBox.Show("确定要进行反审操作？", Common.MsgCaption,  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string settleId = dataGridView_SettleMain.CurrentRow.Cells["ColSettleID"].Value.ToString();
                string sql = string.Format("update SettleMain set Checker = null, CheckDate = null where SettleID = {0}", settleId);
                if (SqlHelper.ExecuteNonQuery(sql) > 0)
                {
                    dataGridView_SettleMain.CurrentRow.Cells["ColChecker"].Value = "";
                    dataGridView_SettleMain.CurrentRow.Cells["ColCheckDate"].Value = "";
                }
            }


        }

    }
}
