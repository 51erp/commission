using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Commission.Business;

namespace Commission.Forms
{
    public partial class FrmSubscribeBase : Form
    {
        public string SubscribeID = string.Empty;

        public FrmSubscribeBase()
        {
            InitializeComponent();
        }
        private void toolStripButton_Canel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string condition = "";

            if (!textBox_CusName.Text.Trim().Equals(""))
                condition += " and  CustomerName like '%" + textBox_CusName.Text.Trim() + "%'";

            if (!textBox_Phone.Text.Trim().Equals(""))
                condition += " and  (CustomerPhone like '%" + textBox_Phone.Text.Trim() + "%')";

            if (!textBox_Building.Text.Trim().Equals(""))
                condition += " and  Building = '" + textBox_Building.Text.Trim() + "'";

            if (!textBox_Unit.Text.Trim().Equals(""))
                condition += " and  Unit = '" + textBox_Unit.Text.Trim() + "'";

            if (!textBox_ItemNum.Text.Trim().Equals(""))
                condition += " and  ItemNum = '" + textBox_ItemNum.Text.Trim() + "'";


            string sql = "select DISTINCT  a.SubscribeID ,a.CustomerName, a.CustomerPhone, TotalAmount,SubscribeDate,SalesName from [SubscribeMain]  a "
                + " inner join [SubscribeDetail] b on a.SubscribeID = b.SubscribeID "
                + " where a.ContractID is null and  a.ProjectID = " + Login.User.ProjectID + condition
                + " order by a.SubscribeID ";

            dataGridView_SubscribeMain.DataSource = SqlHelper.ExecuteDataTable(sql);

            if (dataGridView_SubscribeMain.Rows.Count == 0 )
            {
                DataTable dt = (DataTable)dataGridView_SubscribeDetail.DataSource;
                dt.Clear();
                dataGridView_SubscribeDetail.DataSource = dt;

                Prompt.Information("没有符合条件的查询结果！");
            }
        }


        private void dataGridView_Transaction_SelectionChanged(object sender, EventArgs e)
        {
            string sql = string.Format("select ItemID,ItemTypeName, Building, Unit, ItemNum, Area, Price ,Amount from [SubscribeDetail] where SubscribeID = {0} order by rowid ", dataGridView_SubscribeMain.CurrentRow.Cells["ColSubscribeID"].Value.ToString());
            dataGridView_SubscribeDetail.DataSource = SqlHelper.ExecuteDataTable(sql);
        }

        private void toolStripButton_OK_Click(object sender, EventArgs e)
        {
            if (dataGridView_SubscribeMain.CurrentRow == null)
            {
                Prompt.Information("未选择相应记录！");
                return;
            }

            SubscribeID = dataGridView_SubscribeMain.CurrentRow.Cells["ColSubscribeID"].Value.ToString();
            DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
