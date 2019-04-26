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
    public partial class FrmConfirmDate : Form
    {
        public string ConfirmDate = "1900-01-01";
        public string SalesID = string.Empty;
        public string FormText = string.Empty;

        public FrmConfirmDate()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            ConfirmDate = dateTimePicker_Date.Value.ToString("yyyy-MM-dd");
            string sql = string.Format("select Convert(varchar(10), BeginDate, 120) from JobTrack where SalesID = {0} and EndDate is null", SalesID);
            object objResult = SqlHelper.ExecuteScalar(sql);
            if (objResult != null && objResult != System.DBNull.Value)
            {
                if (DateTime.Parse(ConfirmDate) < DateTime.Parse(objResult.ToString()))
                {
                    Prompt.Warning(FormText + "日期不能小于调入日期!");
                    return;
                }
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void FrmConfirmDate_Load(object sender, EventArgs e)
        {
            this.Text = FormText + "时间";
            label_Operation.Text = FormText;
        }
    }
}
