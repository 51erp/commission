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
    public partial class FrmParameterSet : Form
    {
        public FrmParameterSet()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            //清空
            string sql = string.Empty;
            sql = string.Format("delete ParaSettle where ProjectID = {0}", Login.User.ProjectID);
            SqlHelper.ExecuteNonQuery(sql);

            //指定
            if (radioButton_ClosingDate.Checked)
            {
                int closedate = 0;
                if (int.TryParse(textBox_ClosingDate.Text.Trim(), out closedate))
                {
                    if (closedate < 1 || closedate > 31)
                    {
                        Prompt.Information("截止日期的有效区间为：1 - 31");
                        return;
                    }
                }
                else
                {
                    Prompt.Information("请输入有效数字格式！");
                    return;
                }

                sql = string.Format("insert ParaSettle (ClosingDate, ProjectID) values ({0},{1}) ", closedate, Login.User.ProjectID);
                SqlHelper.ExecuteNonQuery(sql);
            }

            Prompt.Information("操作成功！数据已保存。");
            Close();
        }

        private void radioButton_ClosingDate_CheckedChanged(object sender, EventArgs e)
        {
            textBox_ClosingDate.Enabled = radioButton_ClosingDate.Checked;
            if (radioButton_ClosingDate.Checked)
            {
                textBox_ClosingDate.Focus();
            }
            else
            {
                textBox_ClosingDate.Text = "";
            }
        }

        private void textBox_ClosingDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.OnlyNumeric(sender, e);
        }

        private void FrmParameterSet_Load(object sender, EventArgs e)
        {
            string sql = string.Format("select ClosingDate from ParaSettle where ProjectID = {0}", Login.User.ProjectID);
            object objResult = SqlHelper.ExecuteScalar(sql);

            string closeDate = objResult == null ? "" : objResult.ToString();
            if (!closeDate.Equals(""))
            {
                radioButton_ClosingDate.Checked = true;
                textBox_ClosingDate.Text = closeDate;
            }
        }
    }
}
