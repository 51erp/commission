using Commission.Business;
using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Commission.Forms
{
    public partial class FrmUserAdd : Form
    {
        public bool IsModifyMode = false;
        public string Update_UserID = string.Empty;
        public FrmUserAdd()
        {
            InitializeComponent();
            initRole();
            initProject();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void initRole()
        {
            string sql = "SELECT RoleID, RoleName FROM  [Role] where State = 1 order by RoleID";
            comboBox_Role.DataSource = SqlHelper.ExecuteDataTable(sql);
            comboBox_Role.ValueMember = "RoleID";
            comboBox_Role.DisplayMember = "RoleName";
        }

        private void initProject()
        {
            string sql = "select ProjectID, ProjectName from Project where State = 1 order by ProjectID";
            checkedListBox_Projects.DataSource = SqlHelper.ExecuteDataTable(sql);
            checkedListBox_Projects.ValueMember = "ProjectID";
            checkedListBox_Projects.DisplayMember = "ProjectName";
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            string userName = textBox_UserName.Text.Trim();

            if (userName.Equals(""))
            {
                Prompt.Warning("用户名称不能为空");
                textBox_UserName.Focus();
                return;
            }

            if (comboBox_Role.Items.Count == 0)
            {
                Prompt.Warning("未设置角色，无法保存。");
                return;
            }

            if (checkedListBox_Projects.Items.Count <= 0)
            {
                Prompt.Warning("未设置归属项目，无法保存。");
                return;
            }

            if (checkedListBox_Projects.CheckedItems.Count <= 0)
            {
                Prompt.Warning("未选择归属项目!无法保存。");
                return;
            }

            if (IsModifyMode)
            {
                UpdateUser();
            }
            else
            {
                AddUser();
            }
        }
        private void UpdateUser()
        {
            string sql = string.Empty;
            string projectID = string.Empty; ;
            string projectName = string.Empty;



            string userName = textBox_UserName.Text.Trim();

            string roleID = comboBox_Role.SelectedValue.ToString();
            string roleName = comboBox_Role.Text.ToString();


            using (SqlConnection connection = SqlHelper.OpenConnection())  //创建连接对象 
            {
                SqlTransaction sqlTran = connection.BeginTransaction();    //开始事务 
                SqlCommand cmd = connection.CreateCommand();               //创建SqlCommand对象 
                cmd.Transaction = sqlTran;                                 //将SqlCommand与SqlTransaction关联起

                try
                {
                    sql = string.Format("update SysUser Set RoleID = {0}, RoleName = '{1}', Memo = '{2}' where ID = {3}", roleID, roleName, textBox_Memo.Text.Trim(), Update_UserID);
                    SqlHelper.ExecuteNonQuery(sql);

                    sql = string.Format("delete UserProject where UserID = {0}", Update_UserID );
                    SqlHelper.ExecuteNonQuery(sql);

                    foreach (object item in checkedListBox_Projects.CheckedItems)
                    {
                        DataRowView drv = (DataRowView)item;

                        projectID = drv["ProjectID"].ToString();
                        projectName = drv["ProjectName"].ToString();

                        sql = string.Format("insert into UserProject (UserID, UserName, ProjectID, ProjectName) values ({0},'{1}',{2},'{3}')", Update_UserID, userName, projectID, projectName);

                        SqlHelper.ExecuteScalar(sql);
                    }

                    sqlTran.Commit();  //事务提交
                    connection.Close();

                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();  //异常事务回滚
                    Prompt.Error("操作失败， 错误：" + ex.Message);
                }
            }
        }

        private void AddUser()
        {
            string sql = string.Empty;
            string projectID = string.Empty; ;
            string projectName = string.Empty;

            string userName = textBox_UserName.Text.Trim();

            string roleID = comboBox_Role.SelectedValue.ToString();
            string roleName = comboBox_Role.Text.ToString();

            if (isExistUserName(userName))
            {
                Prompt.Warning("用户名称已经存在，不能重复添加");
                textBox_UserName.Focus();
                return;
            }

            using (SqlConnection connection = SqlHelper.OpenConnection())  //创建连接对象 
            {
                SqlTransaction sqlTran = connection.BeginTransaction();    //开始事务 
                SqlCommand cmd = connection.CreateCommand();               //创建SqlCommand对象 
                cmd.Transaction = sqlTran;                                 //将SqlCommand与SqlTransaction关联起

                try
                {
                    sql = string.Format("insert into SysUser (UserName, UserPwd, RoleID, RoleName, Memo) output inserted.ID values ('{0}','123456',{1},'{2}','{3}')", userName, roleID, roleName, textBox_Memo.Text.Trim());
                    object userId = SqlHelper.ExecuteScalar(sql);


                    foreach (object item in checkedListBox_Projects.CheckedItems)
                    {
                        DataRowView drv = (DataRowView)item;

                        projectID = drv["ProjectID"].ToString();
                        projectName = drv["ProjectName"].ToString();

                        sql = string.Format("insert into UserProject (UserID, UserName, ProjectID, ProjectName) values ({0},'{1}',{2},'{3}')", userId.ToString(), userName, projectID, projectName);

                        SqlHelper.ExecuteScalar(sql);
                    }

                    sqlTran.Commit();  //事务提交
                    connection.Close();

                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();  //异常事务回滚
                    Prompt.Error("操作失败， 错误：" + ex.Message);
                }
            }
        }


        private void FrmUserAdd_Load(object sender, EventArgs e)
        {
            if (IsModifyMode)
            {
                textBox_UserName.ReadOnly = true;
                loadData();
            }
        }

        private void loadData()
        {
            string sql = "select ID, UserName, RoleID, RoleName, Memo from SysUser where ID = " + Update_UserID;
            DataTable dtUser = SqlHelper.ExecuteDataTable(sql);

            for (int i = 0; i < dtUser.Rows.Count; i++)
            {
                textBox_UserName.Text = dtUser.Rows[i]["UserName"].ToString();
                textBox_Memo.Text = dtUser.Rows[i]["Memo"].ToString();
                comboBox_Role.SelectedValue = int.Parse(dtUser.Rows[i]["RoleID"].ToString());

                sql = string.Format("select ProjectID from UserProject where UserID = {0}", dtUser.Rows[i]["ID"].ToString());
                DataTable dtProject = SqlHelper.ExecuteDataTable(sql);

                
                for (int j = 0; j < checkedListBox_Projects.Items.Count; j++)
                {
                    DataRowView dv = ((DataRowView)checkedListBox_Projects.Items[j]);
                    string projectId = dv["ProjectID"].ToString();

                    DataRow[] row = dtProject.Select("ProjectID = " + projectId); 
                    if (row.Length > 0)
                        checkedListBox_Projects.SetItemChecked(j, true); 
                }
            }

        }

        private bool isExistUserName(string userName)
        {
            string sql = string.Format("select isnull(count(id),0) from SysUser where Upper(UserName) = '{0}'", userName.ToUpper());
            int result = int.Parse(SqlHelper.ExecuteScalar(sql).ToString());

            if (result > 0)
                return true;

            return false;
        }
    }
}
