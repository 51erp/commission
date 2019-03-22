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
    public partial class FrmOrganizationAdd : Form
    {
        public string DeptName = string.Empty;
        public FrmOrganizationAdd()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            DeptName = textBox_Name.Text.Trim();
            if (string.IsNullOrEmpty(DeptName))
            {
                Commission.Utility.Prompt.Warning("部门名称不能为空！");
                return;
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
