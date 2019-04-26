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
    public partial class FrmSalesList : Form
    {
        public string OperationType = string.Empty;
        public string SalesID = string.Empty;
        public string SalesName = string.Empty;
        public string OperationDate = string.Empty;
        public string JobType = string.Empty;
        public string Phone = string.Empty;
        public string InDate = string.Empty;
        public string Position = string.Empty;



        public FrmSalesList()
        {
            InitializeComponent();
            comboBox_JobType.SelectedIndex = 0;
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_OK_Click(object sender, EventArgs e)
        {

            if (dataGridView_Sales.SelectedRows.Count < 1)
            {
                Prompt.Information("没有选择相应的记录！");
            }
            else
            {
                SalesID = dataGridView_Sales.CurrentRow.Cells["ColID"].Value.ToString();
                SalesName = dataGridView_Sales.CurrentRow.Cells["ColSalesName"].Value.ToString();
                OperationDate = dateTimePicker_OperationDate.Value.ToString("yyyy-MM-dd");
                JobType = comboBox_JobType.Text;
                Phone = dataGridView_Sales.CurrentRow.Cells["ColPhone"].Value.ToString();
                InDate = dataGridView_Sales.CurrentRow.Cells["ColInDate"].Value.ToString();
                Position = dataGridView_Sales.CurrentRow.Cells["ColPosition"].Value.ToString();

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void FrmSalesList_Load(object sender, EventArgs e)
        {
            GetSalesList();
        }

        private void GetSalesList()
        {
            string condition = string.Empty;

            if (OperationType == "调入")
            {
                condition = " and IsFree = 1 ";
            }

            if (OperationType == "复职")
            {
                condition = " and OutDate is not null ";
            }


            string sql = "select SalesID,SalesName,Phone,InDate,OutDate,Position,ProjectName from Sales where  1=1 " + condition + " order by SalesName";

            dataGridView_Sales.DataSource = SqlHelper.ExecuteDataTable(sql);

        }

    }
}
