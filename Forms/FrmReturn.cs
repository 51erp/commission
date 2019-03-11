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
    public partial class FrmReturn : Form
    {
        public bool IsRefund = false;
        public string ReturnDate = string.Empty;
        public string ReturnMemo = string.Empty;

        public string ReceiptAmount = string.Empty;
        public FrmReturn()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            IsRefund = checkBox_Refund.Checked;
            ReturnDate = dateTimePicker_ReturnDate.Value.ToString("yyyy-MM-dd");
            ReturnMemo = textBox_Memo.Text.Trim();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void FrmReturn_Load(object sender, EventArgs e)
        {
            textBox_ReceiptAmount.Text = ReceiptAmount;
        }
    }
}
