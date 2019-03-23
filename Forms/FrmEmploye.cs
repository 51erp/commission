using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            //e.DrawDefault = true;
            //return;

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
                + "where EndDate is null and DeptId = {0} order by a.SalesID ", deptId);
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

        }

        private void toolStripButton_Edit_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_ChangeJob_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_JobIn_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_JobOut_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_Dimission_Click(object sender, EventArgs e)
        {

        }

        private void treeView_Dept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView_Dept.SelectedNode.Name != null)
            {
                LoadSales(treeView_Dept.SelectedNode.Name);
            }
            
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
