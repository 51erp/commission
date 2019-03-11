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
    public partial class FrmDelay : Form
    {
        public string ContractDate = string.Empty;
        public string DelayDate = string.Empty;

        public FrmDelay()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            DelayDate = dateTimePicker_DelayDate.Value.ToString("yyyy-MM-dd");
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void FrmDelay_Load(object sender, EventArgs e)
        {
            textBox_LastContractDate.Text = ContractDate;
        }
    }
}
