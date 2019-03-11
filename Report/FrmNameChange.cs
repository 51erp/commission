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
    public partial class FrmNameChange : Form
    {
        public FrmNameChange()
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

            if (comboBox_OperType.Text.Equals("认购"))
            {

                sql = string.Format("select a.SubscribeID as AgreementID, ItemID,Building,Unit,ItemNum,ItemTypeName,SalesID,SalesName,SubscribeDate,"
                    + " OrigID,OrigName,OrigPhone,Relation,[NewID],[NewName],ExchangeDate,c.Memo from SubscribeMain a "
                    + " inner join SubscribeDetail b on b.SubscribeID = a.SubscribeID and b.IsBind = 0 "
                    + " inner join NameExchange c on c.AgreementID = a.SubscribeID where ExchangeType  = 'subscribe'  and {0} order by ExchangeDate ", condition);
            }
            else
            {
                sql = string.Format("select a.ContractID as AgreementID, ItemID,Building,Unit,ItemNum,ItemTypeName,SalesID,SalesName,SubscribeDate,"
                    + " OrigID,OrigName,OrigPhone,Relation,[NewID],[NewName],ExchangeDate,c.Memo from ContractMain a "
                    + " inner join ContractDetail b on b.ContractID = a.ContractID and b.IsBind = 0 "
                    + " inner join NameExchange c on c.AgreementID = a.ContractID where ExchangeType = 'contract' and {0} order by ExchangeDate ", condition);
            }

            dataGridView_RepNameChange.DataSource = SqlHelper.ExecuteDataTable(sql);

            if (dataGridView_RepNameChange.RowCount == 0)
                Prompt.Information("没有符合条件的查询结果！");

        }

        private void FrmNameChange_Load(object sender, EventArgs e)
        {
            comboBox_OperType.SelectedIndex = 0;

            Common.SetFirstOfMonth(dateTimePicker_Begin);
            dateTimePicker_Begin.Checked = false;
            Common.SetEndOfMonth(dateTimePicker_End);
            dateTimePicker_End.Checked = false;
        }
    }
}
