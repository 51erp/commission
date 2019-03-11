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
    public partial class RepHandOver : Form
    {
        public RepHandOver()
        {
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Export_Click(object sender, EventArgs e)
        {
            Common.Exp2XLS(dataGridView_RepNameChange);
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            string condition = " ProjectID = " + Login.User.ProjectID;


            if (dateTimePicker_Begin.Checked)
            {
                condition += string.Format(" and ExchangeDate >= '{0}'", dateTimePicker_Begin.Value.ToString("yyyy-MM-dd"));
            }

            if (dateTimePicker_End.Checked)
            {
                condition += string.Format(" and ExchangeDate <= '{0}'", dateTimePicker_End.Value.ToString("yyyy-MM-dd"));
            }

            sql = string.Format("select a.ContractID, ItemID,Building,Unit,ItemNum,ItemTypeName,SubscribeDate,"
                + " OrigID,OrigName,[NewID],[NewName],ExchangeDate,c.Memo from ContractMain a "
                + " inner join ContractDetail b on b.ContractID = a.ContractID and b.IsBind = 0 "
                + " inner join HandOver c on c.ContractID = a.ContractID where ExchangeType = 2 and {0} order by ExchangeDate ", condition);

            dataGridView_RepNameChange.DataSource = SqlHelper.ExecuteDataTable(sql);

            if (dataGridView_RepNameChange.Rows.Count == 0)
                Prompt.Warning("没有符合条件的记录！");

        }

        private void RepHandOver_Load(object sender, EventArgs e)
        {
            Common.SetFirstOfMonth(dateTimePicker_Begin);
            dateTimePicker_Begin.Checked = false;
            Common.SetEndOfMonth(dateTimePicker_End);
            dateTimePicker_End.Checked = false;
        }
    }
}
