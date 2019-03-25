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
    public partial class FrmEmploye : Form
    {
        public FrmEmploye()
        {
            InitializeComponent();
        }

        private void treeViewDrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                e.Graphics.FillRectangle(Brushes.DodgerBlue, e.Node.Bounds);

                Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width + 2, e.Bounds.Height); //字体显示不全
                e.Graphics.DrawString(e.Node.Text, ((TreeView)sender).Font, Brushes.White, rect);
            }
            else
            {
                e.DrawDefault = true;
            }
        }


        private void FrmEmploye_Load(object sender, EventArgs e)
        {
            InitDeptNode();
            treeView_Dept.HideSelection = false;
            this.treeView_Dept.DrawMode = TreeViewDrawMode.OwnerDrawText;
            this.treeView_Dept.DrawNode += new DrawTreeNodeEventHandler(treeViewDrawNode);
        }


        private void InitDeptNode()
        {
            TreeNode root = new TreeNode();
            root.Name = "0";
            root.Text = Login.User.ProjectName;

            treeView_Dept.Nodes.Add(root);

            LoadDeptSubNode(root);

            treeView_Dept.ExpandAll();
        }

        private void LoadDeptSubNode(TreeNode node)
        {
            string sql = string.Format("select DeptID, DeptName from Department where ParentID = {0} and ProjectID = {1}", node.Name, Login.User.ProjectID);
            DataTable dtDept = SqlHelper.ExecuteDataTable(sql);

            foreach (DataRow dr in dtDept.Rows)
            {
                TreeNode subNode = new TreeNode();
                subNode.Name = dr["DeptID"].ToString();
                subNode.Text = dr["DeptName"].ToString();

                LoadDeptSubNode(subNode);

                node.Nodes.Add(subNode);
            }
        }

        private void LoadSales(string deptId)
        {
            string sql = string.Empty;

            sql = string.Format("select a.SalesID, SalesName, Phone, InDate, BeginDate, Position, JobType, Memo from Sales a "
                + "inner join JobTrack b on a.SalesID = b.SalesID "
                + "where EndDate is null and DeptId = {0} order by JobType desc, a.SalesID ", deptId);
            dataGridView_Employe.DataSource = SqlHelper.ExecuteDataTable(sql);
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            if (treeView_Dept.SelectedNode == null)
            {
                Prompt.Warning("未选择部门！");
                return;
            }

            if (treeView_Dept.SelectedNode.Parent == null)
            {
                Prompt.Warning("无法在项目下直接新增员工，请选择部门！");
                return;
            }

            FrmEmployeAdd add = new FrmEmployeAdd();
            add.DeptId = treeView_Dept.SelectedNode.Name;
            add.DeptName = treeView_Dept.SelectedNode.Text;

            if (add.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadSales(treeView_Dept.SelectedNode.Name);

            }

        }

        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {
            if (dataGridView_Employe.CurrentRow == null)
            {
                Prompt.Warning("未选择员工记录!");
                return;
            }

            if (Prompt.Question("确定要删除员工：" + dataGridView_Employe.CurrentRow.Cells["ColSalesName"].Value) == System.Windows.Forms.DialogResult.Yes)
            {
                using (SqlConnection connection = SqlHelper.OpenConnection())
                {
                    SqlTransaction sqlTran = connection.BeginTransaction();
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.Transaction = sqlTran;

                    try
                    {
                        cmd.CommandText = string.Format("delete sales where SalesId = {0}", dataGridView_Employe.CurrentRow.Cells["ColID"].Value);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = string.Format("delete JobTrack where SalesID = {0}", dataGridView_Employe.CurrentRow.Cells["ColID"].Value);
                        cmd.ExecuteNonQuery();

                        dataGridView_Employe.Rows.RemoveAt(dataGridView_Employe.CurrentRow.Index);

                        Prompt.Information("操作成功，记录已删除！");


                        sqlTran.Commit();
                    }
                    catch (Exception ex)
                    {
                        sqlTran.Rollback();
                        Prompt.Error("操作失败， 错误：" + ex.Message);
                    }

                }
            }


        }

        private void toolStripButton_Edit_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_ChangeJob_Click(object sender, EventArgs e)
        {
            JobTrack();
        }

        private void toolStripButton_JobIn_Click(object sender, EventArgs e)
        {
            JobTrack(1);
        }

        private void toolStripButton_JobOut_Click(object sender, EventArgs e)
        {
            if (dataGridView_Employe.CurrentRow == null)
            {
                Prompt.Warning("未选择员工记录!");
                return;
            }

            if (Prompt.Question("确定将员工 [ " + dataGridView_Employe.CurrentRow.Cells["ColSalesName"].Value.ToString() + " ] 调出该部门？") == System.Windows.Forms.DialogResult.Yes)
            {
                string sql = string.Format("update JobTrack set EndDate = {0} where SalesID = {1} and DeptID = {2} and EndDate is null",
                                    "Convert(varchar(10),GETDATE(),120)", dataGridView_Employe.CurrentRow.Cells["ColID"].Value.ToString(), treeView_Dept.SelectedNode.Name);
                SqlHelper.ExecuteNonQuery(sql);

                dataGridView_Employe.Rows.RemoveAt(dataGridView_Employe.CurrentRow.Index);

                Prompt.Information("操作成功！员工已调出。");
            }
            
        }

        private void toolStripButton_Dimission_Click(object sender, EventArgs e)
        {
            if (dataGridView_Employe.CurrentRow == null)
            {
                Prompt.Warning("未选择员工记录!");
                return;
            }

            if (Prompt.Question("确定将员工 [ " + dataGridView_Employe.CurrentRow.Cells["ColSalesName"].Value.ToString() + " ] 进行离职操作？") == System.Windows.Forms.DialogResult.Yes)
            {

                using (SqlConnection connection = SqlHelper.OpenConnection())
                {
                    SqlTransaction sqlTran = connection.BeginTransaction();
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.Transaction = sqlTran;

                    try
                    {
                        cmd.CommandText = string.Format("update JobTrack set EndDate = {0} where SalesID = {1} and EndDate is null",
                           "Convert(varchar(10),GETDATE(),120)", dataGridView_Employe.CurrentRow.Cells["ColID"].Value.ToString());
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = string.Format("update Sales Set OutDate = {0}", "Convert(varchar(10),GETDATE(),120)");
                        cmd.ExecuteNonQuery();

                        sqlTran.Commit();

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

        private void treeView_Dept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView_Dept.SelectedNode.Name != null)
            {
                LoadSales(treeView_Dept.SelectedNode.Name);
            }

        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void JobTrack(int type = 0)
        {
            if (dataGridView_Employe.CurrentRow == null)
            {
                Prompt.Warning("未选择员工记录!");
                return;
            }

            FrmOrganization destDept = new FrmOrganization();
            destDept.Text = "请选择调入部门";
            if (destDept.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (SqlConnection connection = SqlHelper.OpenConnection())
                {
                    SqlTransaction sqlTran = connection.BeginTransaction();
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.Transaction = sqlTran;

                    try
                    {
                        string sysDate = "Convert(varchar(10),GETDATE(),120)";

                        switch (type)
                        {

                            case  0: //调岗
                                cmd.CommandText = string.Format("update JobTrack set EndDate = {0} where SalesID = {1} and DeptID = {2} and EndDate is null",
                                    sysDate, dataGridView_Employe.CurrentRow.Cells["ColID"].Value.ToString(), treeView_Dept.SelectedNode.Name);

                                cmd.ExecuteNonQuery();

                                cmd.CommandText = string.Format("insert into JobTrack (SalesID, DeptID, JobType, BeginDate) values ({0},{1},'{2}',{3})",
                                    dataGridView_Employe.CurrentRow.Cells["ColID"].Value.ToString(),
                                    destDept.DeptID,
                                    dataGridView_Employe.CurrentRow.Cells["ColJobType"].Value.ToString(), sysDate);

                                cmd.ExecuteNonQuery();

                                break;

                            case 1: //调入
                                cmd.CommandText = string.Format("insert into JobTrack (SalesID, DeptID, JobType, BeginDate) values ({0},{1},'{2}',{3})",
                                    dataGridView_Employe.CurrentRow.Cells["ColID"].Value.ToString(),
                                    destDept.DeptID,
                                    dataGridView_Employe.CurrentRow.Cells["ColJobType"].Value.ToString(), sysDate);

                                cmd.ExecuteNonQuery();

                                break;

                            default:
                                break;
                        }

                        sqlTran.Commit();

                        if (type == 0)
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
