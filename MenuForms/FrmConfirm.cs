using Commission.Business;
using Commission.Forms;
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
    public partial class FrmConfirm : Form
    {
        public bool IsConfirm = true;

        public FrmConfirm()
        {
            InitializeComponent();
            comboBox_ConfirmState.SelectedIndex = 0;
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string condition = "";

            if (!textBox_CusName.Text.Trim().Equals(""))
                condition += " and  CustomerName like '%" + textBox_CusName.Text.Trim() + "%'";

            if (!textBox_Phone.Text.Trim().Equals(""))
                condition += " and  CustomerPhone like '%" + textBox_Phone.Text.Trim() + "%'";

            if (!textBox_Building.Text.Trim().Equals(""))
                condition += " and  Building = '" + textBox_Building.Text.Trim() + "'";

            if (!textBox_Unit.Text.Trim().Equals(""))
                condition += " and  Unit = '" + textBox_Unit.Text.Trim() + "'";

            if (!textBox_ItemNum.Text.Trim().Equals(""))
                condition += " and  ItemNum = '" + textBox_ItemNum.Text.Trim() + "'";

            if (IsConfirm)
            {
                toolStripButton_Add.Enabled = true;
                toolStripButton_Cancel.Enabled = false;
                condition += " and ConfirmDate is null ";
            }
            else
            {
                toolStripButton_Add.Enabled = false;
                toolStripButton_Cancel.Enabled = true;
                condition += " and ConfirmDate is not null ";
            }

            int bindQty = 0;

            DataTable dtContract = Transaction.GetContractDataEx(condition, out bindQty, true);

            Transaction.InsertBindCol(dataGridView_Contract, 11, bindQty);

            dataGridView_Contract.AutoGenerateColumns = false;
            dataGridView_Contract.DataSource = dtContract;

            if (dtContract.Rows.Count == 0)
            {
                Prompt.Information("没有符合条件的查询结果 ");
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

        private bool hasItemChecked()
        {
            for (int i = 0; i < dataGridView_Contract.Rows.Count; i++)
            {
                if ((bool)dataGridView_Contract.Rows[i].Cells["ColCheck"].EditedFormattedValue)
                    return true;
            }

            Prompt.Information("没有选择相应的记录！");

            return false; ;
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            if (!hasItemChecked())
                return;

            SetConfirm(true);
        }

        private void SetConfirm(bool isConfirm)
        {
            string sql = string.Empty;

            string value = isConfirm ? "GETDATE()" : "NULL";

            dataGridView_Contract.EndEdit();

            string contractId = string.Empty;
            for (int i = 0; i < dataGridView_Contract.Rows.Count; i++)
            {
                if ((bool)dataGridView_Contract.Rows[i].Cells["ColCheck"].FormattedValue == true)
                {
                    contractId = dataGridView_Contract.Rows[i].Cells["ColContractID"].Value.ToString();

                    sql = string.Format("select LoanDate from ContractMain where ContractID = {0}",contractId);

                    string objResult = SqlHelper.ExecuteScalar(sql).ToString();

                    PayType type = (PayType)dataGridView_Contract.Rows[i].Cells["ColPaymentType"].Value;

                    if (type == PayType.Loan || type == PayType.DownPayInstalment)
                    {
                        if (string.IsNullOrEmpty(dataGridView_Contract.Rows[i].Cells["ColLoanDate"].Value.ToString()))
                        {
                            dataGridView_Contract.Rows[i].Selected = true;
                            if (MessageBox.Show("此记录未放贷，不允许确权，是否继续其它记录", Common.MsgCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                continue;
                            else
                                return;
                        }
                    }
                    
                    if (!IsPayOff(contractId))
                    {
                        dataGridView_Contract.Rows[i].Selected = true;
                        if (MessageBox.Show("已收款合计与合同金额不符，不允许确权，是否继续其它记录", Common.MsgCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            continue;
                        else
                            return;
                    }

                    try
                    {
                        sql = string.Format("update ContractMain set ConfirmDate = {0} where ContractID = {1}", value, contractId);
                        SqlHelper.ExecuteNonQuery(sql);
                        dataGridView_Contract.Rows.RemoveAt(i);
                        i--;
                    }
                    catch (Exception ex)
                    {
                        Prompt.Error("操作失败，\r\n错误信息：" + ex.Message);
                        break;
                    }
                }
            }

            Prompt.Information("操作完毕!");
        }

        /// <summary>
        /// 合同金额是否付清
        /// </summary>
        /// <param name="contractId"></param>
        /// <returns></returns>
        private bool IsPayOff(string contractId)
        {
            bool result = false;
            string sql = string.Empty;

            sql = string.Format("select TotalAmount from ContractMain where ContractID = {0}", contractId);
            double totalAmount = double.Parse(SqlHelper.ExecuteScalar(sql).ToString());

            sql = string.Format("select SUM(Amount) from Receipt where ContractID = {0}", contractId);
            double recDownPay = double.Parse(SqlHelper.ExecuteScalar(sql).ToString());

            if (totalAmount <= recDownPay)
            {
                result = true;
            }

            return result;
        }

        private void toolStripButton_Cancel_Click(object sender, EventArgs e)
        {
            if (!hasItemChecked())
                return;

            SetConfirm(false);
        }

        private void FrmConfirm_Load(object sender, EventArgs e)
        {
            if (IsConfirm)
            {
                this.Text = "房屋确权";
                toolStripButton_Add.Visible = true;
                toolStripButton_Cancel.Visible = false;
            }
            else
            {
                this.Text = "房屋反确权";
                toolStripButton_Add.Visible = false;
                toolStripButton_Cancel.Visible = true;
            }

        }
    }
}
