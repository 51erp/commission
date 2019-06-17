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
    public partial class FrmDept : Form
    {
        public string DeptID = string.Empty;
        public string DeptName = string.Empty;

        public FrmDept()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmDept_Load(object sender, EventArgs e)
        {
            InitDeptNode();
        }

        private void toolStripButton_OK_Click(object sender, EventArgs e)
        {
            if (treeView_Dept.SelectedNode == null)
            {
                Prompt.Error("未选择部门！");
                return;
            }

            DeptID = treeView_Dept.SelectedNode.Name;
            DeptName = treeView_Dept.SelectedNode.Text;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void InitDeptNode()
        {

            string sql = string.Format("select DeptID, DeptName from Department where ParentID = 0 and ProjectID = {0}", Login.User.ProjectID);
            DataTable dtDept = SqlHelper.ExecuteDataTable(sql);

            foreach (DataRow dr in dtDept.Rows)
            {
                TreeNode root = new TreeNode();
                root.Name = dr["DeptID"].ToString();
                root.Text = dr["DeptName"].ToString();

                treeView_Dept.Nodes.Add(root);

                LoadDeptSubNode(root);
            }

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
    }
}
