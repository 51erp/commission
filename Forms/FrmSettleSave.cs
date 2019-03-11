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
    public partial class FrmSettleSave : Form
    {
        public string tabMaker = string.Empty;
        public string tabDate = string.Empty;
        public string tabName = string.Empty;
        public FrmSettleSave()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            if (textBox_TableMaker.Text.Trim().Equals(""))
            {
                Prompt.Warning("制表人不能为空");
                textBox_TableMaker.Focus();
            }
            else if (textBox_TableName.Text.Trim().Equals(""))
            {
                Prompt.Warning("表格名称不能为空");
                textBox_TableName.Focus();
            }
            else
            {
                
                tabMaker = textBox_TableMaker.Text.Trim();
                tabDate = textBox_MakeDate.Text;
                tabName = textBox_TableName.Text.Trim();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void FrmSettleSave_Load(object sender, EventArgs e)
        {
            textBox_TableMaker.Text = tabMaker;
            textBox_TableName.Text = tabName;
            textBox_MakeDate.Text = SqlHelper.ExecuteScalar(string.Format("select CONVERT(VARCHAR(10),GETDATE(),120)")).ToString();
        }
    }
}
