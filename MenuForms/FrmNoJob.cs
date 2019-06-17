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
    public partial class FrmNoJob : Form
    {
        public FrmNoJob()
        {
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string condition = string.Format(" a.ProjectID = {0} and OperationType = '{1}' ", Login.User.ProjectID, comboBox_OperationType.Text);

            if (comboBox_OperationType.Text.Equals("调出"))
            {
                condition += " and a.IsFree = 1 and OutDate is null ";
            }

            if (comboBox_OperationType.Text.Equals("离职"))
            {
                condition += " and a.OutDate is not null ";
            }
            

            if (!textBox_SalesName.Text.Trim().Equals(""))
            {
                condition += string.Format(" and a.SalesName like '%{0}%'", textBox_SalesName.Text.Trim());
            }

            if (condition.Equals(""))
            {
                DataTable dt = dataGridView_Employe.DataSource as DataTable;

                dt.Clear();

                dataGridView_Employe.DataSource = dt;

                return;
            }

            string sql = string.Format("select ID, a.SalesID, DeptID, DeptName, a.SalesName, Phone, InDate, BeginDate, EndDate, OutDate, Position, JobType, OperationType, Memo from Sales a "
                + "inner join JobTrack b on a.SalesID = b.SalesID "
                + "where {0} order by JobType desc, a.SalesID ", condition);
            dataGridView_Employe.DataSource = SqlHelper.ExecuteDataTable(sql);

            if (dataGridView_Employe.Rows.Count == 0)
            {
                Prompt.Information("未查询到符合条件的记录！");
            }
            else
            {
                if (comboBox_OperationType.Text.Equals("离职"))
                {
                    toolStripButton_JobIn.Enabled = false;
                    toolStripButton_Dimission.Enabled = false;
                    toolStripButton_Return.Enabled = true;
                }
                else
                {
                    toolStripButton_JobIn.Enabled = true ;
                    toolStripButton_Dimission.Enabled = true ;
                    toolStripButton_Return.Enabled = false;
                }
            }
        }

        private void FrmNoJob_Load(object sender, EventArgs e)
        {
            comboBox_OperationType.SelectedIndex = 0;
        }

        private void toolStripButton_JobIn_Click(object sender, EventArgs e)
        {
            if (dataGridView_Employe.CurrentRow == null)
            {
                Prompt.Warning("没有选定记录！");
                return;
            }

            JobOperation("调入");

        }

        private void toolStripButton_Return_Click(object sender, EventArgs e)
        {
            if (dataGridView_Employe.CurrentRow == null)
            {
                Prompt.Warning("没有选定记录！");
                return;
            }

            JobOperation("复职");

        }

        private void toolStripButton_Dimission_Click(object sender, EventArgs e)
        {
            if (dataGridView_Employe.CurrentRow == null)
            {
                Prompt.Warning("没有选定记录！");
                return;
            }


            string OutDate = string.Empty;

            if (dataGridView_Employe.CurrentRow == null)
            {
                Prompt.Warning("未选择员工记录!");
                return;
            }

            string JobTractID = dataGridView_Employe.CurrentRow.Cells["ColID"].Value.ToString();

            string salesID = dataGridView_Employe.CurrentRow.Cells["ColSalesID"].Value.ToString();

            FrmConfirmDate frmDate = new FrmConfirmDate();

            frmDate.SalesID = salesID;
            frmDate.FormText = "离职";


            if (frmDate.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                OutDate = frmDate.ConfirmDate;

                using (SqlConnection connection = SqlHelper.OpenConnection())
                {
                    SqlTransaction sqlTran = connection.BeginTransaction();
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.Transaction = sqlTran;

                    try
                    {
                        cmd.CommandText = string.Format("update JobTrack set OrigOperationType = OperationType, OperationType = '离职' where ID = {0} ", JobTractID);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = string.Format("update Sales Set OutDate ='{0}' where SalesID = {1}", OutDate, salesID);
                        cmd.ExecuteNonQuery();

                        sqlTran.Commit();

                        dataGridView_Employe.Rows.RemoveAt(dataGridView_Employe.CurrentRow.Index);

                        Prompt.Information("操作成功！员工已离职。");
                    }
                    catch (Exception ex)
                    {
                        sqlTran.Rollback();
                        Prompt.Error("操作失败， 错误：" + ex.Message);
                    }

                }
            }


        }



        private void JobOperation(string operationType)
        {
            FrmJobOperation frmOperation = new FrmJobOperation();

            string salesID = dataGridView_Employe.CurrentRow.Cells["ColSalesID"].Value.ToString();
            string salesName = dataGridView_Employe.CurrentRow.Cells["ColSalesName"].Value.ToString();

            frmOperation.JobTrackID = dataGridView_Employe.CurrentRow.Cells["ColID"].Value.ToString();
            frmOperation.SalesName = dataGridView_Employe.CurrentRow.Cells["ColSalesName"].Value.ToString();
            frmOperation.Phone = dataGridView_Employe.CurrentRow.Cells["ColPhone"].Value.ToString(); ;
            frmOperation.DeptID = dataGridView_Employe.CurrentRow.Cells["ColDeptID"].Value.ToString();
            frmOperation.DeptName = dataGridView_Employe.CurrentRow.Cells["ColDeptName"].Value.ToString();
            frmOperation.Position = dataGridView_Employe.CurrentRow.Cells["ColPosition"].Value.ToString();
            frmOperation.JobType = dataGridView_Employe.CurrentRow.Cells["ColJobType"].Value.ToString();


            if (frmOperation.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (SqlConnection connection = SqlHelper.OpenConnection())
                {
                    SqlTransaction sqlTran = connection.BeginTransaction();
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.Transaction = sqlTran;

                    try
                    {
                        if (operationType == "复职")
                        {
                            cmd.CommandText = string.Format("update Sales Set OutDate = null where SalesID = {0}", salesID);
                            cmd.ExecuteNonQuery();
                        }

                        if (operationType == "调入")
                        {
                            cmd.CommandText = string.Format("update Sales Set IsFree = 0 where SalesID = {0}", salesID);
                            cmd.ExecuteNonQuery();
                        }

                        cmd.CommandText = string.Format("insert into JobTrack (SalesID, SalesName, DeptID, DeptName, JobType, BeginDate, OperationType, ProjectID, ProjectName) values " 
                            + "({0},'{1}',{2},'{3}','{4}','{5}','{6}', {7}, '{8}')",
                            salesID, salesName,frmOperation.DeptID, frmOperation.DeptName, frmOperation.JobType, frmOperation.OperationDate, operationType, Login.User.ProjectID, Login.User.ProjectName);

                        cmd.ExecuteNonQuery();


                        cmd.CommandText = string.Format("update Sales Set Position = '{0}', Memo = '{1}' where SalesID = {2}", frmOperation.Position, frmOperation.Demo, dataGridView_Employe.CurrentRow.Cells["ColSalesID"].Value.ToString());
                        cmd.ExecuteNonQuery();

                        sqlTran.Commit();

                        dataGridView_Employe.Rows.RemoveAt(dataGridView_Employe.CurrentRow.Index);

                        Prompt.Information("操作成功!");
                    }
                    catch (Exception ex)
                    {
                        sqlTran.Rollback();
                        Prompt.Error("操作失败， 错误：" + ex.Message);
                    }
                }
            }
        }
    }
}
