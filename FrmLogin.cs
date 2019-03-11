using Commission.Business;
using Commission.Forms;
using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;


namespace Commission
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")] //调用windowsAPI keybd_event() Tab键取代Retrun键
        public static extern void keybd_event(Byte bVk, Byte bScan, Int32 dwFlags, Int32 dwExtraInfo);

        private void showDBConnMsg(bool isVisible)
        {
            label1.Visible = isVisible;
            this.Refresh();
        }


        private bool inputValidate()
        {
            if (textBox_User.Text.Trim().Equals(""))
            {
                Prompt.Warning("用户名不能为空！");
                textBox_User.Focus();
                return false;
            }
            if (textBox_Pwd.Text.Trim().Equals(""))
            {
                Prompt.Warning("密码不能为空！");
                textBox_Pwd.Focus();
                return false;
            }

            //项目为空
            if (comboBox_Project.Items.Count == 0)
            {
                if (textBox_User.Text.Trim().Equals("admin"))
                {
                    createProject();
                    return false;
                }
                else
                {
                    Prompt.Warning("项目为空，请使用管理员权限登录并创建项目！");
                    textBox_User.Focus();
                    return false;
                }
            }

            return true;
        }


        //创建项目
        private void createProject()
        {
            if (isValidUser())
            {
                Commission.MenuForms.FrmProject project = new Commission.MenuForms.FrmProject();
                project.ShowDialog();

                MasterData.getAllProject(comboBox_Project);
            }
        }

        //验证用户有效性
        private bool isValidUser()
        {
            string user = textBox_User.Text.Trim();
            string pwd = textBox_Pwd.Text.Trim();

            string sql = string.Format("select ID,UserName,RoleID, RoleName, UserType from SysUser where State = 1 and UserName = '{0}' and UserPwd = '{1}'", user, pwd);
            try
            {
                SqlDataReader sdr = SqlHelper.ExecuteReader(sql);

                if (sdr.Read())
                {
                    Login.User.UserID = sdr["ID"].ToString();
                    Login.User.UserName = sdr["UserName"].ToString();
                    Login.User.RoleID = sdr["RoleID"].ToString();
                    Login.User.RoleName = sdr["RoleName"].ToString();
                    Login.User.UserType = (SysUserType)int.Parse(sdr["UserType"].ToString());
                }
                else
                {
                    Prompt.Error("用户名或密码错误！");
                    textBox_User.Focus();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Prompt.Error(ex.Message);
                return false;
            }

            return true;
        }

        private bool setValidProject()
        {
            string user = textBox_User.Text.Trim();
            string projectID = comboBox_Project.SelectedValue.ToString();

            if (user != "admin")
            {
                string sql = string.Format("select count(ProjectID) from UserProject where UserName = '{0}' and ProjectID = {1}", user, projectID);

                if (int.Parse(SqlHelper.ExecuteScalar(sql).ToString()) <= 0)
                {
                    Prompt.Warning("用户与项目不匹配！\n\n请重新选择或联系管理员分配相应权限。");
                    return false;
                }
            }

            Login.User.ProjectID = comboBox_Project.SelectedValue.ToString();
            Login.User.ProjectName = comboBox_Project.Text;
            return true;
        }



        private void textBox_User_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                keybd_event(9, 0, 0, 0);
            }
        }


        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Login_Click(object sender, EventArgs e)
        {

            showDBConnMsg(true);

            if (inputValidate())
            {
                if (isValidUser())
                {
                    if (setValidProject())
                        this.DialogResult = DialogResult.OK;
                }
            }

            showDBConnMsg(false);
        }

        private void FrmLogin_Shown(object sender, EventArgs e)
        {
            showDBConnMsg(true);
            MasterData.getAllProject(comboBox_Project);
            showDBConnMsg(false);
        }

        private void textBox_Enter_SelectAll(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Trim() != "")
            {
                ((TextBox)sender).SelectAll();
            }
        }

        private void button_Config_Click(object sender, EventArgs e)
        {
            FrmConfig config = new FrmConfig();
            config.ShowDialog();
        }

    }
}
