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
        public FormMode FrmMode = FormMode.modify;
        
        public string SalesID = string.Empty;

        public string ChangeDate = string.Empty;
        public string JobType = string.Empty;
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
            if (FrmMode == FormMode.modify)
            {
                panel_Date.Visible = false;
                toolStripButton_OK.Visible = false;
            }
            else
            {
                panel_Date.Visible = true;
                toolStripButton_OK.Visible = true;
                comboBox_JobType.SelectedIndex = 0;
            }

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


            string sql = string.Format("select COUNT(*) from JobTrack where EndDate is null and DeptID = {0} ", selNode.Name);
            if (Convert.ToInt32(SqlHelper.ExecuteScalar(sql).ToString()) > 0)
            {
                Prompt.Warning("指定部门节点存在员工，无法删除！");
                return;
            }


            if (Prompt.Question("确定要删除部门：" + selNode.Text) == System.Windows.Forms.DialogResult.Yes)
            {
                SqlHelper.ExecuteNonQuery("delete Department where deptID = " + selNode.Name);
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



        private void toolStripButton_OK_Click(object sender, EventArgs e)
        {
            ChangeDate = dateTimePicker_ChangeDate.Value.ToString("yyyy-MM-dd");

            string sql = string.Format("select Convert(varchar(10), BeginDate, 120) from JobTrack where SalesID = {0} and EndDate is null", SalesID);
            object objResult = SqlHelper.ExecuteScalar(sql);
            if (objResult != null && objResult != System.DBNull.Value)
            {
                if (DateTime.Parse(ChangeDate) < DateTime.Parse(objResult.ToString()))
                {
                    Prompt.Warning("调岗日期不能小于当前部门的调入日期!");
                    return;
                }
            }

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

            if (DeptID == treeView_Dept.SelectedNode.Name)
            {
                Prompt.Error("所选择的部门与原部门一致！");
                return;
            }

            DeptID = treeView_Dept.SelectedNode.Name;
            DeptName = treeView_Dept.SelectedNode.Text;

            JobType = comboBox_JobType.Text;


            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
