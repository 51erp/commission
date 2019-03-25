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
    public partial class FrmOrganization : Form
    {
        public string DeptID = string.Empty;
        public string DeptName = string.Empty;

        public FrmOrganization()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmOrganization_Load(object sender, EventArgs e)
        {
            //InitDeptNode_Test();
            InitDeptNode();
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            AddDept( );
        }

        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {
            if (treeView_Dept.SelectedNode == null)
            {
                Prompt.Error("未选择删除的部门！");
                return;
            }

            TreeNode selNode = treeView_Dept.SelectedNode;

            if (selNode.Tag != null)
            {
                Prompt.Warning("不允许删除项目信息！");
                return;
            }


            if (selNode.Nodes.Count > 0)
            {
                Prompt.Warning("不允许删除存在下属节点的部门！");
                return;
            }


            if (Prompt.Question("确定要删除部门：" + selNode.Text) == System.Windows.Forms.DialogResult.Yes)
            {
                selNode.Remove();
            }



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


    


        private void AddDept()
        {
            if (treeView_Dept.SelectedNode == null)
            {
                Prompt.Error("未选择新增部门的节点！");
                return;
            }

            TreeNode selNode = treeView_Dept.SelectedNode;

            if (selNode.Tag != null)
            {

            }

            //string parentId = selNode.Tag == null ? selNode.Name : "0";

            FrmOrganizationAdd organAdd = new FrmOrganizationAdd();
            if (organAdd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string sql = string.Format("insert into Department (ParentID, DeptName, ProjectID) output inserted.DeptID values ({0},'{1}',{2})", selNode.Name, organAdd.DeptName, Login.User.ProjectID);

                string deptId = SqlHelper.ExecuteScalar(sql).ToString();

                TreeNode newNode = new TreeNode();
                newNode.Name = deptId;
                newNode.Text = organAdd.DeptName;

                selNode.Nodes.Add(newNode);

                selNode.Expand();
            }

        }

        #region    treeView 加载测试
        private void InitDeptNode_Test()
        {
            TreeNode node1 = new TreeNode();
            node1.Name = "0";
            node1.Text = Login.User.ProjectName;
            node1.Tag = "root";

            treeView_Dept.Nodes.Add(node1);

            TreeNode subNode1 = new TreeNode();
            subNode1.Name = "a";
            subNode1.Text = "销售一部";

            node1.Nodes.Add(subNode1);

            TreeNode subNode2 = new TreeNode();
            subNode2.Name = "b";
            subNode2.Text = "销售二部";

            node1.Nodes.Add(subNode2);


            TreeNode childNode1 = new TreeNode();
            childNode1.Name = "zz";
            childNode1.Text = "住宅";

            subNode1.Nodes.Add(childNode1);


            TreeNode childNode2 = new TreeNode();
            childNode2.Name = "sy";
            childNode2.Text = "商业";

            subNode1.Nodes.Add(childNode2);

            TreeNode childNode3 = new TreeNode();
            childNode3.Name = "cw";
            childNode3.Text = "车位";

            subNode1.Nodes.Add(childNode3);

            treeView_Dept.ExpandAll();
        }
        #endregion

        private void toolStripButton_OK_Click(object sender, EventArgs e)
        {
            if (treeView_Dept.SelectedNode == null)
            {
                Prompt.Error("未选择调岗的调入部门！");
                return;
            }

            if (treeView_Dept.SelectedNode.Parent == null)
            {
                Prompt.Error("所选择的节点不是部门！");
                return;
            }

            DeptID = treeView_Dept.SelectedNode.Name;
            DeptName = treeView_Dept.SelectedNode.Text;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
