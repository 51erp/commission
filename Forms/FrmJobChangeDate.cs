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
    public partial class FrmJobChangeDate : Form
    {
        public string SalesID = string.Empty;
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
            if (JobType == comboBox_JobType.Text)
            {
                Prompt.Warning("岗位类型未变更！");
                return;
            }


            ChangeDate = dateTimePicker_ChangeDate.Value.ToString("yyyy-MM-dd");

            string sql = string.Format("select Convert(varchar(10), BeginDate, 120) from JobTrack where SalesID = {0} and EndDate is null", SalesID);
            object objResult = SqlHelper.ExecuteScalar(sql);
            if (objResult != null && objResult != System.DBNull.Value)
            {
                if (DateTime.Parse(ChangeDate) < DateTime.Parse(objResult.ToString()))
                {
                    Prompt.Warning("调岗日期不能小于当前部门的调入日期!");
                    return;
                }
            }

            //else
            //{
            //    Prompt.Warning("调岗日期不能小于当前部门的调入日期!");
            //    return;
            //}

            JobType = comboBox_JobType.Text;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void FrmJobChangeDate_Load(object sender, EventArgs e)
        {
            comboBox_JobType.Text = JobType;
        }
    }
}
