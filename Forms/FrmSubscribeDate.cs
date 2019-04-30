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
    public partial class FrmSubscribeDate : Form
    {
        private bool IsHavPara = false;
        public FrmSubscribeDate()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            double value = 0;
            if (!double.TryParse(textBox_Days.Text, out value))
            {
                Prompt.Information("输入有效数字!");
                return;
            }

            value = Math.Round(value, 0);
            string sql = string.Empty;

            if (IsHavPara)
                sql = string.Format("update ParaProject set ParaValue = {0} where ParaTypeID = 1 and ProjectID = {1}", value, Login.User.ProjectID);
            else
                sql = string.Format("insert into ParaProject (ProjectID, ProjectName, ParaTypeID, ParaTypeName, ParaValue) values ({0},'{1}',1,'认购日期限定',{2})", Login.User.ProjectID, Login.User.ProjectName, value);

            if (SqlHelper.ExecuteNonQuery(sql) > 0)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.OnlyNumeric(sender, e);
        }

        private void FrmSubscribeDate_Load(object sender, EventArgs e)
        {
            int paraValue = 0;
            string sql = string.Format("select ParaValue from ParaProject where ParaTypeID = 1 and ProjectID = {0}", Login.User.ProjectID);
            object objResult = SqlHelper.ExecuteScalar(sql);

            if (objResult != null)
            {
                IsHavPara = true;
                int.TryParse(objResult.ToString(), out paraValue);
            }
            else
            {
                IsHavPara = false;
            }

            textBox_Days.Text = paraValue.ToString();

        }
    }
}
