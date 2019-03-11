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
    public partial class FrmCreditDate : Form
    {
        public string LoanDate = string.Empty;
        public FrmCreditDate()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            LoanDate = dateTimePicker_Loan.Value.ToShortDateString();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
