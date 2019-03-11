using Commission.DataAccess;
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
    public partial class FrmCustomer : Form
    {
        public Customer SelectedCus = new Customer();

        public string CustomerID = string.Empty;

        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_OK_Click(object sender, EventArgs e)
        {
            if (dataGridView_Customer.SelectedRows.Count > 0 )
            {
                SelectedCus.CustomerID = dataGridView_Customer.CurrentRow.Cells["ColID"].Value.ToString();
                SelectedCus.CustomerName = dataGridView_Customer.CurrentRow.Cells["ColCustomerName"].Value.ToString();
                SelectedCus.Phone = dataGridView_Customer.CurrentRow.Cells["ColCustomerPhone"].Value.ToString();
                SelectedCus.PID = dataGridView_Customer.CurrentRow.Cells["ColPID"].Value.ToString();
                SelectedCus.Addr = dataGridView_Customer.CurrentRow.Cells["ColAddr"].Value.ToString();
                SelectedCus.Type = dataGridView_Customer.CurrentRow.Cells["ColCusTypeName"].Value.ToString();

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                Prompt.Information("没有选择相应的记录！");
            }
            
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            FrmCustomerAdd cusAdd = new FrmCustomerAdd();
            cusAdd.Owner = this;
            cusAdd.ShowDialog();
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string condition = string.Empty;

            if (!textBox_Name.Text.Trim().Equals(""))
                condition += " and CustomerName like '%" + textBox_Name.Text.Trim() + "%' ";

            if (!textBox_Phone.Text.Trim().Equals(""))
                condition += " and CustomerPhone like '%" + textBox_Phone.Text.Trim() + "%'";

            if (!textBox_PID.Text.Trim().Equals(""))
                condition += " and PID like '%" + textBox_PID.Text.Trim() + "%'";

            search(condition);


            if (dataGridView_Customer.Rows.Count == 0)
                Prompt.Information("未查询到符合条件的记录！");
        }

        private void search(string condition = "")
        {
            string sql = "select CustomerID,CustomerName,CustomerPhone,PID,Addr,CusTypeCode,CusTypeName from Customer where ProjectID = " + Login.User.ProjectID + condition + " order by CustomerName";

            dataGridView_Customer.DataSource = SqlHelper.ExecuteDataTable(sql);
        }

        public void  getCustomerInfo(string id)
        {
            string sql = "select CustomerID,CustomerName,CustomerPhone,PID,Addr,CusTypeCode,CusTypeName from Customer where CustomerID = " + id;

            dataGridView_Customer.DataSource = SqlHelper.ExecuteDataTable(sql);
        }

        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {
            if (dataGridView_Customer.SelectedRows.Count < 1)
            {
                Prompt.Information("没有选择相应的记录！");
            }
            else
            {
                if (MessageBox.Show("是否要删除 [ " + dataGridView_Customer.CurrentRow.Cells["ColCustomerName"].Value.ToString() + " ] 的信息？", "房地产销售佣金结算管理系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string sql = "select IsNull(count(SubscribeID),0) from [SubscribeMain] where CustomerID = " + dataGridView_Customer.CurrentRow.Cells["ColID"].Value.ToString();

                    int iResult = int.Parse(SqlHelper.ExecuteScalar(sql).ToString());
                    if (iResult > 0)
                    {
                        Prompt.Information("该客户已有业务记录，无法删除!");
                        return;
                    }

                    CustomerID = dataGridView_Customer.CurrentRow.Cells["ColID"].Value.ToString();

                    sql = "delete Customer where CustomerID = " + CustomerID;

                    SqlHelper.ExecuteNonQuery(sql);

                    dataGridView_Customer.Rows.RemoveAt(dataGridView_Customer.CurrentRow.Index);

                }

            }

        }

        private void toolStripButton_Modify_Click(object sender, EventArgs e)
        {
            if (dataGridView_Customer.CurrentRow == null)
            {
                Prompt.Information("未选择要修改的记录！");
                return;
            }

            FrmCustomerAdd cusAdd = new FrmCustomerAdd();
            cusAdd.IsModify = true;
            cusAdd.CustomerID = dataGridView_Customer.CurrentRow.Cells["ColID"].Value.ToString();
            cusAdd.Owner = this;
            cusAdd.ShowDialog();
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            search();
        }

    }
}
