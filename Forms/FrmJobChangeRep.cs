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
    public partial class FrmJobChangeRep : Form
    {
        public FrmJobChangeRep()
        {
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string condition = string.Empty;
            if (!textBox_SalesName.Text.Trim().Equals(""))
            {
                condition = string.Format(" and SalesName like '%{0}%' ",textBox_SalesName.Text.Trim() );
            }

            string sql = string.Format("select SalesID, SalesName,DeptID, DeptName, JobType, BeginDate, EndDate, OperationType from JobTrack where 1=1 {0} order by SalesName, BeginDate ", condition);

            dataGridView_Employee.DataSource = SqlHelper.ExecuteDataTable(sql);
        }
    }
}
