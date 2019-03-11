using Commission.Business;
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
    public partial class FrmChangeProject : Form
    {
        public FrmChangeProject()
        {
            InitializeComponent();
            setCombProject();
        }

        private void setCombProject()
        {
            string sql = string.Empty;
            if (Login.User.UserType == SysUserType.supermanager)
            {
                sql = "select ProjectID, ProjectName from Project where State = 1";
            }
            else
            {
                sql = "select ProjectID, ProjectName from UserProject where UserID = "+ Login.User.UserID +" order by ProjectID";
            }
            try
            {
                comboBox_Project.DataSource = SqlHelper.ExecuteDataTable(sql);
                comboBox_Project.DisplayMember = "ProjectName";
                comboBox_Project.ValueMember = "ProjectID";

                if (comboBox_Project.Items.Count > 0)
                    comboBox_Project.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Prompt.Error("数据库连接错误！请设置数据连接或联系管理员。\r\n\n错误信息：" + ex.Message.ToString());
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            if (comboBox_Project.Items.Count == 0)
            {
                Prompt.Error("没有选择项目！");
                return;
            }

            if (MessageBox.Show("确定要更换项目吗？","房地产佣金结算系统", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                Login.User.ProjectID = comboBox_Project.SelectedValue.ToString();
                Login.User.ProjectName = comboBox_Project.Text;

                //新版本处理 
                //Login.CurrentProject = MasterData.getTableProject(comboBox_Project.SelectedValue.ToString(), comboBox_Project.Text);

                DialogResult = System.Windows.Forms.DialogResult.OK;
            }

        }
    }
}
