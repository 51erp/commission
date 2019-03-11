using Commission.Business;
using Commission.Forms;
using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Commission.MenuForms
{
    public partial class FrmSales : Form
    {
        public string SalesID = string.Empty;
        public FrmSales()
        {
            InitializeComponent();
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
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            FrmSalesAdd salesAdd = new FrmSalesAdd();
            salesAdd.Owner = this;
            salesAdd.ShowDialog();
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            searchSalesInfo();

            if (dataGridView_Sales.RowCount <= 0)
            {
                Prompt.Information("没有符合条件的记录！");
            }
        }

        private void searchSalesInfo()
        {
            string condition = string.Empty;

            condition += " and ProjectID = " + Login.User.ProjectID;

            if (!textBox_Name.Text.Trim().Equals(""))
                condition += " and SalesName like '%" + textBox_Name.Text.Trim() + "%' ";
            if (!textBox_Phone.Text.Trim().Equals(""))
                condition += " and Phone like '%" + textBox_Phone.Text.Trim() + "%'";

            string sql = "select SalesID,SalesName,Phone,InDate,OutDate,Position,ProjectName from Sales where (OutDate is null or OutDate = '') " + condition + " order by SalesName";

            dataGridView_Sales.DataSource = SqlHelper.ExecuteDataTable(sql);
        }

        public void  getSalesInfo(string salesid)
        {
            string sql = "select SalesID,SalesName,Phone,InDate,OutDate,Position,ProjectName from Sales where SalesID = " + salesid;

            dataGridView_Sales.DataSource = SqlHelper.ExecuteDataTable(sql);
        }

        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {
            string sql;

            if (dataGridView_Sales.CurrentRow == null)
            {
                Prompt.Warning("没有或未选择相应的记录！");
                return;
            }

            sql = "select isNull(count(SubscribeID),0) from [SubscribeMain] where salesID = " + dataGridView_Sales.CurrentRow.Cells["ColID"].Value.ToString();

            int iCount = int.Parse(SqlHelper.ExecuteScalar(sql).ToString());

            if (iCount > 0)
            {
                Prompt.Information("该置业顾问已有业务记录，无法删除!");
            }
            else
            {
                sql = "delete sales where SalesID = " + dataGridView_Sales.CurrentRow.Cells["ColID"].Value.ToString();

                if (SqlHelper.ExecuteNonQuery(sql) > 0)
                {
                    Prompt.Information("操作成功！");
                }

                dataGridView_Sales.Rows.RemoveAt(dataGridView_Sales.CurrentRow.Index);
            }
        }

        private void toolStripButton_Modify_Click(object sender, EventArgs e)
        {
            if (dataGridView_Sales.CurrentRow == null)
            {
                Prompt.Information("未选择要修改的记录！");
                return;
            }

            FrmSalesAdd salesAdd = new FrmSalesAdd();
            salesAdd.IsModify = true;
            salesAdd.SalesID = dataGridView_Sales.CurrentRow.Cells["ColID"].Value.ToString();
            salesAdd.Owner = this;
            salesAdd.ShowDialog();

        }

        private void FrmSales_Load(object sender, EventArgs e)
        {
            searchSalesInfo();
        }

    }
}
