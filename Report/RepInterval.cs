using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Commission.Report
{
    public partial class RepInterval : Form
    {
        public RepInterval()
        {
            InitializeComponent();
        }
        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button_Search_Click(object sender, EventArgs e)
        {
            Search();
        }


        private void Search()
        {
            string condtion = string.Empty;
            if (dateTimePicker_Begin.Checked)
            {
                condtion += " and SubscribeDate >= '" + dateTimePicker_Begin.Value.ToString("yyyy-MM-dd") + "'";
            }

            if (dateTimePicker_End.Checked)
            {
                condtion += " and SubscribeDate <= '" + dateTimePicker_End.Value.ToString("yyyy-MM-dd") + "'";
            }

            string sql = string.Format("select a.SubscribeID, Building, Unit, ItemNum, ItemTypeName, CustomerName, CustomerPhone, "
                + "SubscribeDate, LastContractDate, DATEDIFF(day,LastContractDate,GETDATE()) as IntervalDays, SalesName " 
                + "from SubscribeMain a " 
                + "inner join SubscribeDetail b on b.SubscribeID = a.SubscribeID " 
                + "where ContractID is null and IsBind = 0 and ProjectID  = {0} {1}", Login.User.ProjectID, condtion);

            dataGridView_RepInterval.DataSource = SqlHelper.ExecuteDataTable(sql);
        }

        private void button_Export_Click(object sender, EventArgs e)
        {
            Common.Exp2XLS(dataGridView_RepInterval);

        }

    }
}
