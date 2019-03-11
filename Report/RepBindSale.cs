using Commission.Utility;
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
    public partial class RepBindSale : Form
    {
        public RepBindSale()
        {
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Export_Click(object sender, EventArgs e)
        {
            Common.Exp2XLS(dataGridView_RepBind);
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            button_Search.Enabled = false;

            string condtion = string.Empty;
            if (dateTimePicker_Begin.Checked)
            {
                condtion += " and ContractDate >= '" + dateTimePicker_Begin.Value.ToString("yyyy-MM-dd") + "'";
            }

            if (dateTimePicker_End.Checked)
            {
                condtion += " and ContractDate <= '" + dateTimePicker_End.Value.ToString("yyyy-MM-dd") + "'";
            }

            string sql = string.Format("select a.ContractID, Building, Unit, ItemNum, ItemTypeName, CustomerName, CustomerPhone,ContractDate, SalesName "
                + "from ContractMain a "
                + "inner join ContractDetail b on b.ContractID = a.ContractID "
                + "where IsBind = 1 and ProjectID  = {0} {1}", Login.User.ProjectID, condtion);

            dataGridView_RepBind.DataSource = SqlHelper.ExecuteDataTable(sql);

            button_Search.Enabled = true;

            if (dataGridView_RepBind.Rows.Count == 0)
            {
                Prompt.Information("没有符合条件的记录!");
            }
        }


    }
}
