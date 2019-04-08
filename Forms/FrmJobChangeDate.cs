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
    public partial class FrmJobChangeDate : Form
    {
        public string ChangeDate = string.Empty;
        public string JobType = string.Empty;
        public FrmJobChangeDate()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_OK_Click(object sender, EventArgs e)
        {
            ChangeDate = dateTimePicker_ChangeDate.Value.ToString("yyyy-MM-dd");
            JobType = comboBox_JobType.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void FrmJobChangeDate_Load(object sender, EventArgs e)
        {
            comboBox_JobType.Text = JobType;
        }
    }
}
