using Commission.Business;
using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Commission.MenuForms
{
    public partial class FrmHandover : Form
    {
        public FrmHandover()
        {
            InitializeComponent();
            MasterData.setSales(comboBox_Sales);
            MasterData.setSales(comboBox_NewSalesName);
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string condition = " and ProjectID = " + Login.User.ProjectID;

            if (!comboBox_Sales.Text.Equals(""))
                condition += " and  SalesName like '%" + comboBox_Sales.Text + "%'";

            int bindQty = 0;

            DataTable dtContract = Transaction.GetContractDataEx(condition, out bindQty, true);

            Transaction.InsertBindCol(dataGridView_Contract, 11, bindQty);

            dataGridView_Contract.DataSource = dtContract;

            if (dtContract.Rows.Count == 0)
            {
                Prompt.Information("没有符合条件的查询结果 ");
            }
        }

        private void button_Handover_Click(object sender, EventArgs e)
        {
            if (dataGridView_Contract.RowCount > 0)
            {
                if (comboBox_Sales.Text == comboBox_NewSalesName.Text)
                {
                    Prompt.Information("新置业顾问与原置业顾问不能为同一人！");
                }
                else
                {
                    handover();
                }
            }
            else
            {
                Prompt.Information("没有查询结果！");
            }
        }

        private void handover()
        {
            bool isChecked = false;


            using (SqlConnection connection = SqlHelper.OpenConnection())
            {
                SqlTransaction sqlTran = connection.BeginTransaction();
                SqlCommand cmd = connection.CreateCommand();
                cmd.Transaction = sqlTran;

                try
                {
                    for (int i = 0; i < dataGridView_Contract.Rows.Count; i++)
                    {
                        if ((bool)dataGridView_Contract.Rows[i].Cells["ColCheck"].EditedFormattedValue)
                        {
                            isChecked = true;

                            string contractId = dataGridView_Contract.Rows[i].Cells["ColContractID"].Value.ToString();
                            string newSalesID = comboBox_NewSalesName.SelectedValue.ToString();
                            string newSalesName = comboBox_NewSalesName.Text;


                            cmd.CommandText = string.Format("update ContractMain set SalesID = {0}, SalesName = '{1}' where ContractID = {2}", newSalesID, newSalesName, contractId);
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = string.Format("insert into HandOver (ContractID, ExchangeType, OrigID, OrigName, NewID, NewName, ExchangeDate, MakeUserName, MakeDate) values ({0},{1},{2},'{3}',{4},'{5}',{6},'{7}',{8})",
                                contractId,"2",
                                comboBox_Sales.SelectedValue.ToString(),
                                comboBox_Sales.Text,
                                newSalesID,
                                newSalesName,
                                "GETDATE()",
                                Login.User.UserName,
                                "GETDATE()");
                            cmd.ExecuteNonQuery();

                            dataGridView_Contract.Rows[i].Cells["ColSalesName"].Value = newSalesName;
                        }
                    }

                    sqlTran.Commit();

                    if (isChecked)
                    {
                        Prompt.Information("操作成功，数据已更新!");
                    }
                    else
                    {
                        Prompt.Information("没有选择要交接的记录!");
                    }
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    Prompt.Error("操作失败！\n\r错误信息：" + ex.Message);
                }
            }

            
        }

        private void toolStripButton_All_Click(object sender, EventArgs e)
        {
            setCheckState(true);
        }

        private void toolStripButton_None_Click(object sender, EventArgs e)
        {
            setCheckState(false);
        }

        private void setCheckState(bool state)
        {
            dataGridView_Contract.EndEdit();
            for (int i = 0; i < dataGridView_Contract.Rows.Count; i++)
            {
                dataGridView_Contract.Rows[i].Cells["ColCheck"].Value = state;
            }
        }




    }
}
