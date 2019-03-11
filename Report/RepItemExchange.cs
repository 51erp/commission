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
    public partial class RepItemExchange : Form
    {
        public RepItemExchange()
        {
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Export_Click(object sender, EventArgs e)
        {
            Common.Exp2XLS(dataGridView_ItemExchange);
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

            sql = string.Format("select ContractID,OrigContractID,CustomerName, CustomerPhone, ItemTypeName, OrigItemID,OrigBuilding,OrigUnit,OrigItemNum,Building,Unit,ItemNum,SubscribeDate, ExchangeDate, ReceiptTotal,SalesName from ItemExchange where {0} ", condition);

            dataGridView_ItemExchange.DataSource = SqlHelper.ExecuteDataTable(sql);

            if (dataGridView_ItemExchange.Rows.Count == 0)
                Prompt.Warning("没有符合条件的记录！");
        }
    }
}
