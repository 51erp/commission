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
    public partial class FrmItemTypeAdd : Form
    {
        public string ItemTypeName = string.Empty;
        public string Memo = string.Empty;
        public FrmItemTypeAdd()
        {
            InitializeComponent();
        }
  
        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            if (textBox_Name.Text.Trim().Equals(""))
            {
                MessageBox.Show("名称为空，无法进行保存!", Common.MsgCaption);
                return;
            }

            ItemTypeName = textBox_Name.Text.Trim();
            Memo = textBox_Memo.Text.Trim();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
