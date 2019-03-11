using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Commission.Forms
{
    public partial class FrmUserPwd : Form
    {
        public FrmUserPwd()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            if (inputValidate ())
            {
                string sql = string.Format("update SysUser set UserPwd = '{0}' where UserName = '{1}' and UserPwd = '{2}'", textBox_NewPwd.Text.Trim(), textBox_UserName.Text, textBox_OldPwd.Text.Trim());
                int sqlResult = SqlHelper.ExecuteNonQuery(sql);
                if (sqlResult > 0)
                {
                    Prompt.Information("操作成功，密码已修改！");
                    Close();
                }
            }

        }

        private bool inputValidate()
        {
            if (textBox_OldPwd.Text.Trim().Equals(""))
            {
                Prompt.Warning("原密码不能为空");
                textBox_OldPwd.Focus();
                return false;
            }
            if (textBox_NewPwd.Text.Trim().Equals(""))
            {
                Prompt.Warning("新密码不能为空");
                textBox_NewPwd.Focus();
                return false;
            }
            if (textBox_ConfirmPwd.Text.Trim().Equals(""))
            {
                Prompt.Warning("确认密码不能为空");
                textBox_ConfirmPwd.Focus();
                return false;
            }
            if (!textBox_NewPwd.Text.Trim().Equals(textBox_ConfirmPwd.Text.Trim()))
            {
                Prompt.Warning("新密码与确认密码不一致");
                textBox_NewPwd.Focus();
                textBox_NewPwd.SelectAll();
                return false;
            }

            string sql = string.Format("select isnull(count(ID),0) from SysUser where UserName = '{0}' and UserPwd = '{1}'", textBox_UserName.Text, textBox_OldPwd.Text.Trim());
            int sqlResult = int.Parse(SqlHelper.ExecuteScalar(sql).ToString());
            if (sqlResult == 0)
            {
                Prompt.Warning("原密码不正确，请重新输入！");
                textBox_OldPwd.Focus();
                textBox_OldPwd.SelectAll();
                return false;
            }


            return true;
        }

        private void FrmUserPwd_Load(object sender, EventArgs e)
        {
            textBox_UserName.Text = Login.User.UserName;
        }

    }
}
