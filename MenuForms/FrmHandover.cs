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
        private int AgreementType;
       
        public FrmHandover()
        {
            InitializeComponent();
            MasterData.SetSales(comboBox_Sales);
            MasterData.SetSales(comboBox_NewSalesName);
            comboBox_type.SelectedIndex = 0;
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string condition = " and ProjectID = " + Login.User.ProjectID;

            if (!comboBox_Sales.Text.Equals(""))
                condition += " and  SalesID = " + textBox_Sales.Tag.ToString();

            int bindQty = 0;

            DataTable dtContract;

            AgreementType = comboBox_type.SelectedIndex;

            if (AgreementType == 0)
            {
                dtContract = Transaction.GetSubscribeData(condition, out bindQty);
                dataGridView_Contract.Columns["ColArea"].HeaderText = "认购面积";
                dataGridView_Contract.Columns["ColPrice"].HeaderText = "认购单价";
                dataGridView_Contract.Columns["ColAmount"].HeaderText = "认购金额";
                dataGridView_Contract.Columns["ColTotalAmount"].HeaderText = "认购总款";
            }
            else
            {
                dtContract = Transaction.GetContractDataEx(condition, out bindQty, true);
                dataGridView_Contract.Columns["ColArea"].HeaderText = "签约面积";
                dataGridView_Contract.Columns["ColPrice"].HeaderText = "签约单价";
                dataGridView_Contract.Columns["ColAmount"].HeaderText = "签约金额";
                dataGridView_Contract.Columns["ColTotalAmount"].HeaderText = "签约总款";
            }

            dataGridView_Contract.AutoGenerateColumns = false;

            Transaction.InsertBindCol(dataGridView_Contract, 13, bindQty);

            dataGridView_Contract.DataSource = dtContract;

            if (dtContract.Rows.Count == 0)
            {
                Prompt.Information("没有符合条件的查询结果 ");
            }
            else
            {
                button_Handover.Enabled = true;
            }
        }

        private void button_Handover_Click(object sender, EventArgs e)
        {
            if (dataGridView_Contract.RowCount > 0)
            {
                if (textBox_Sales.Text == comboBox_NewSalesName.Text)
                {
                    Prompt.Information("接收置业顾问与原置业顾问不能为同一人！");
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

        private bool IsChecked()
        {
            for (int i = 0; i < dataGridView_Contract.Rows.Count; i++)
            {
                if ((bool)dataGridView_Contract.Rows[i].Cells["ColCheck"].EditedFormattedValue)
                {
                    return true;
                }
            }

            return false;
        }

        private void handover()
        {
            
            if (!IsChecked())
            {
                Prompt.Information("没有选择要交接的记录!");
                return;
            }


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
                            
                            string newSalesID = comboBox_NewSalesName.SelectedValue.ToString();
                            string newSalesName = comboBox_NewSalesName.Text;


                            if (AgreementType == 0) //认购
                            {
                                string subscribeId = dataGridView_Contract.Rows[i].Cells["ColSubscribeID"].Value.ToString();

                                cmd.CommandText = string.Format("update SubscribeMain set SalesID = {0}, SalesName = '{1}' where SubscribeID = {2}", newSalesID, newSalesName, subscribeId);
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = string.Format("insert into HandOver (SubscribeID, ExchangeType, OrigID, OrigName, NewID, NewName, ExchangeDate, MakeUserName, MakeDate) values ({0},{1},{2},'{3}',{4},'{5}',{6},'{7}',{8})",
                                    subscribeId, "2",
                                    comboBox_Sales.SelectedValue.ToString(),
                                    comboBox_Sales.Text,
                                    newSalesID,
                                    newSalesName,
                                    "GETDATE()",
                                    Login.User.UserName,
                                    "GETDATE()");
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                string contractId = dataGridView_Contract.Rows[i].Cells["ColContractID"].Value.ToString();

                                cmd.CommandText = string.Format("update ContractMain set SalesID = {0}, SalesName = '{1}' where ContractID = {2}", newSalesID, newSalesName, contractId);
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = string.Format("insert into HandOver (ContractID, ExchangeType, OrigID, OrigName, NewID, NewName, ExchangeDate, MakeUserName, MakeDate) values ({0},{1},{2},'{3}',{4},'{5}',{6},'{7}',{8})",
                                    contractId, "2",
                                    comboBox_Sales.SelectedValue.ToString(),
                                    comboBox_Sales.Text,
                                    newSalesID,
                                    newSalesName,
                                    "GETDATE()",
                                    Login.User.UserName,
                                    "GETDATE()");
                                cmd.ExecuteNonQuery();
                            }

                            dataGridView_Contract.Rows[i].Cells["ColSalesName"].Value = newSalesName;
                        }
                    }

                    sqlTran.Commit();

                    button_Handover.Enabled = false;

                    Prompt.Information("操作成功，数据已更新!");
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

        private void FrmHandover_Load(object sender, EventArgs e)
        {

        }

        private void button_SalesMore_Click(object sender, EventArgs e)
        {
            FrmSales frmSales = new FrmSales();
            if (frmSales.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox_Sales.Tag = frmSales.SalesID;
                textBox_Sales.Text = frmSales.SalesName;
            }
            else
            {
                textBox_Sales.Tag = "";
                textBox_Sales.Text = "";
            }
        }




    }
}
