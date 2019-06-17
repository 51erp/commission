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
    public partial class FrmJobOperation : Form
    {
        public string JobTrackID = string.Empty;
        public string SalesName = string.Empty;
        public string Phone = string.Empty;
        public string DeptID = string.Empty;
        public string DeptName = string.Empty;
        public string OperationDate = string.Empty;
        public string Position = string.Empty;
        public string JobType = string.Empty;
        public string Demo = string.Empty;


        public FrmJobOperation()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_OK_Click(object sender, EventArgs e)
        {
            string sql = string.Format("select EndDate from JobTrack where ID = {0}", JobTrackID);

            if (dateTimePicker_JobBeginDate.Value < DateTime.Parse(SqlHelper.ExecuteScalar(sql).ToString()))
            {
                Prompt.Warning("调入日期不能小于调出日期!");
                return;
            }

            Phone = textBox_Phone.Text;
            DeptName = textBox_DeptName.Text;
            DeptID = textBox_DeptName.Tag.ToString();
            OperationDate = dateTimePicker_JobBeginDate.Value.ToString("yyy-MM-dd");
            Position = comboBox_Position.Text;
            JobType = comboBox_JobType.Text;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            
        }

        private void FrmJobOperation_Load(object sender, EventArgs e)
        {
            textBox_Name.Text = SalesName;
            textBox_Phone.Text = Phone;
            textBox_DeptName.Text = DeptName;
            textBox_DeptName.Tag = DeptID;

            comboBox_Position.Text = Position;
            comboBox_JobType.Text = JobType;

        }

        private void button_More_Click(object sender, EventArgs e)
        {
            FrmDept frmDept = new FrmDept();
            if (frmDept.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox_DeptName.Text = frmDept.DeptName;
                textBox_DeptName.Tag = frmDept.DeptID;
            }
        }
    }
}
