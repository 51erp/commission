using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Commission.MenuForms
{
    /// <summary>
    /// 权限列表管理界面
    /// 1 列出所有菜单项
    /// 2 设置缺省菜单项
    /// 3 设置菜单关联按钮
    /// </summary>


    public partial class FrmRole : Form
    {
        public FrmRole()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmRole_Load(object sender, EventArgs e)
        {
            InitRoleList();

            InitRootNode();

            if (listBox_Role.Items.Count > 0)
            {
                listBox_Role.SelectedIndex = 0;
                getAuthorizeByRoleID(listBox_Role.SelectedValue.ToString());
            }
        }

        /// <summary>
        /// 初始化角色列表
        /// </summary>
        private void InitRoleList()
        {
            string sql = "select RoleID,RoleName from Role order by RoleID";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            listBox_Role.DataSource = dt;
            listBox_Role.ValueMember = "roleid";
            listBox_Role.DisplayMember = "rolename";

            if (listBox_Role.Items.Count > 0)
            {
                listBox_Role.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 生成根结点
        /// </summary>
        private void InitRootNode()
        {
            treeView_MenuList.Nodes.Clear();

            string sql = "select ID,MenuName,MenuText from MenuList where ParentID = 0";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode node = new TreeNode();
                node.Name = dr["ID"].ToString();
                node.Tag = dr["MenuName"].ToString();
                node.Text = dr["MenuText"].ToString();

                //加载子节点
                InitSubNode(node);

                treeView_MenuList.Nodes.Add(node);

                treeView_MenuList.ExpandAll();
                
            }
        }

        /// <summary>
        /// 按指定结点加载子结点
        /// </summary>
        /// <param name="node"></param>
        private void InitSubNode(TreeNode node)
        {
            string parentId = node.Name;
            string sql = "select ID,MenuName,MenuText from MenuList where IsDefault = 0 and ParentID = " + parentId;
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode subNode = new TreeNode();
                subNode.Name = dr["ID"].ToString();
                subNode.Tag = dr["MenuName"].ToString();
                subNode.Text = dr["MenuText"].ToString();

                InitSubNode(subNode);

                node.Nodes.Add(subNode);
            }
        }


        private void getAuthorizeByRoleID(string roleid)
        {
            string sql = string.Format("select MenuID from Authorize where RoleID = {0}", roleid);
            DataTable dt = SqlHelper.ExecuteDataTable(sql);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    setNodeChecked(dr[0].ToString());
                }

                treeView_MenuList.SelectedNode = treeView_MenuList.Nodes[0];
            }
        }

        private void setNodeChecked(string menuid)
        {
            foreach (TreeNode tn in treeView_MenuList.Nodes)
            {
                if (tn.Name == menuid)
                {
                    tn.Checked = true;
                    break;
                }
                else
                {
                    setSubNodeChecked(tn, menuid);
                }
            }
        }

        private void setSubNodeChecked(TreeNode tn, string menuid)
        {
            foreach (TreeNode tnSub in tn.Nodes)
            {
                if (tnSub.Name == menuid)
                {
                    tnSub.Checked = true;
                    break;
                }
                else
                {
                    setSubNodeChecked(tnSub, menuid);
                }
            }
        }



        private void button_Add_Click(object sender, EventArgs e)
        {
            string roleName = textBox_RoleName.Text.Trim();
            if (roleName.Equals(""))
            {
                Prompt.Warning("请输入角色名称！");
                textBox_RoleName.Focus();
                return;
            }

            string sql = string.Format("select count(RoleID) from Role where RoleName = '{0}'", roleName);
            if (int.Parse(SqlHelper.ExecScalarEx(sql).ToString()) > 0)
            {
                Prompt.Warning("角色名称已经存在，请重新输入！");
                textBox_RoleName.Focus();
                return;
            }

            sql = string.Format("insert into Role (RoleName) values ('{0}')", roleName);
            try
            {
                SqlHelper.ExecuteNonQuery(sql);
                textBox_RoleName.Text = "";
                InitRoleList();
                Prompt.Information("操作成功");

            }
            catch (Exception ex)
            {
                Prompt.Error(ex.ToString());
            }



        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (listBox_Role.SelectedItem != null)
            {
                if (MessageBox.Show("确认要删除 [" + listBox_Role.Text+ "] 角色吗", "房地产佣金结算系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string sql = string.Format("delete Role where RoleID = {0}", listBox_Role.SelectedValue.ToString());
                    try
                    {
                        SqlHelper.ExecuteNonQuery(sql);
                        InitRoleList();
                        Prompt.Information("操作成功！");
                    }
                    catch (Exception ex)
                    {
                        Prompt.Error("操作错误!，请重新操作或联系系统管理员\r\n\n" + ex.Message);
                    }

                }
            }
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            if (listBox_Role.SelectedItem == null)
            {
                Prompt.Information("未选择相应要授权的角色");
                return;
            }

            string roleid = listBox_Role.SelectedValue.ToString();

            if (getNodeChecked(roleid))
            {
                Prompt.Information("操作成功！数据已保存。");
            }

        }

        private bool getNodeChecked(string roleid)
        {
            string del = "delete Authorize where RoleID = " + roleid;
            SqlHelper.ExecuteNonQuery(del);

            foreach (TreeNode tn in treeView_MenuList.Nodes)
            {
                if (tn.Checked)
                {
                    try
                    {
                        string sql = string.Format("insert into Authorize (RoleID, MenuID, MenuName) values ({0},{1},'{2}')", roleid, tn.Name, tn.Tag);
                        SqlHelper.ExecuteNonQuery(sql);

                        getSubNodeChecked(tn, roleid);
                    }
                    catch (Exception)
                    {
                        Prompt.Error("发生错误，请重新操作或联系系统管理员。");
                        return false;
                    }
                }
            }

            return true;
        }

        private void getSubNodeChecked(TreeNode tn, string roleid)
        {
            foreach (TreeNode tnSub in tn.Nodes)
            {
                if (tnSub.Checked)
                {
                    try
                    {
                        string sql = string.Format("insert into Authorize (RoleID, MenuID, MenuName) values ({0},{1},'{2}')", roleid, tnSub.Name, tnSub.Tag);
                        SqlHelper.ExecuteNonQuery(sql);

                        getSubNodeChecked(tnSub, roleid);
                    }
                    catch (Exception)
                    {
                        Prompt.Error("发生错误，请重新操作或联系系统管理员。");
                    }
                }
            }
        }



        private void listBox_Role_MouseClick(object sender, MouseEventArgs e)
        {
            InitRootNode();
            if (listBox_Role.SelectedValue != null)
            {
                getAuthorizeByRoleID(listBox_Role.SelectedValue.ToString());
            }
        }

        private void treeView_MenuList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            setParentNodeChecked(e.Node, e.Node.Checked);
            setSubNodeChecked(e.Node, e.Node.Checked);

        }

        private void setParentNodeChecked(TreeNode node, bool check)
        {
            //节点Checked=false时，检验同级存在Checked=true，父节点不处理
            if (!check) 
            {
                if (node.Parent is TreeNode)
                {
                    foreach (TreeNode subNode in node.Parent.Nodes)
                    {
                        if (subNode.Checked) return;
                    }
                }
            }

            if (node.Parent is TreeNode)
            {
                TreeNode pnode = (TreeNode)node.Parent;
                pnode.Checked = check;
                setParentNodeChecked(pnode, check);
            }
        }

        private void setSubNodeChecked(TreeNode node, bool check)
        {
            foreach (TreeNode subNode in node.Nodes)
            {
                subNode.Checked = check;
                setSubNodeChecked(subNode, check);
            }
        }

        private void button_SelAll_Click(object sender, EventArgs e)
        {
            setWholeNodeChecked(true);
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            setWholeNodeChecked(false);
        }

        private void setWholeNodeChecked(bool isChecked)
        {
            foreach (TreeNode tn in treeView_MenuList.Nodes)
            {
                tn.Checked = isChecked;
                setWholeSubNodeChecked(tn, isChecked);
            }
        }

        private void setWholeSubNodeChecked(TreeNode tn, bool isChecked)
        {
            foreach (TreeNode tnSub in tn.Nodes)
            {
                tnSub.Checked = isChecked;
                setSubNodeChecked(tnSub, isChecked);
            }
        }

    }
}
