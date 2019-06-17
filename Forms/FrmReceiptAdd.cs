using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Commission.Business;

namespace Commission.Forms
{
    public partial class FrmReceiptAdd : BaseFrmAdd
    {
        public FormMode FrmMode = FormMode.add;

        public string AgreementType = string.Empty;
        public string ReceiptID = string.Empty; //修改收款记录
        public string AgreementID = string.Empty;
        public string SalesID = string.Empty;
        public string SalesName = string.Empty;

        public FrmReceiptAdd()
        {
            InitializeComponent();
            InitComponentValue();
        }

        private void InitComponentValue()
        {
            MasterData.SetReceiptType(comboBox_ReceiptType);
            textBox_RecAmount.Text = "";
            textBox_Memo.Text = "";
        }

        protected override void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            if (inputValidate())
            {
                if (FrmMode == FormMode.add)
                    InsertReceipt();
                else
                    updateReceipt(ReceiptID);
            }

        }

        private bool inputValidate()
        {
            this.Focus();

            if (comboBox_ReceiptType.Items.Count <= 0)
            {
                Prompt.Warning("未获取正确的收款类型！");
                return false;
            }

            double amount = 0;
            if (!double.TryParse(textBox_RecAmount.Text.Trim(),out amount))
            {
                Prompt.Warning("请输入正确的收款金额!");
                textBox_RecAmount.Focus();
                return false;
            }

            if (amount == 0)
            {
                Prompt.Warning("收款金额不能为空或零！");
                textBox_RecAmount.Focus();
                return false;
            }

            if (IsOverAmount(AgreementID, amount))
            {
                if (MessageBox.Show("收款合计超出合同金额，是否继续收款?", Common.MsgCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

      
        /// <summary>
        /// 合同金额是否付清
        /// </summary>
        /// <param name="agreementID"></param>
        /// <param name="amount">收款</param>
        /// <returns></returns>
        private bool IsOverAmount(string agreementID, double amount)
        {
            bool result = false;
            string sql = string.Empty;
            string condition = string.Empty;



            //if (AgreementType.Equals("签约"))
            //{
            //    sql = string.Format("select TotalAmount from ContractMain where ContractID = {0}", agreementID);
            //}
            //else
            //{

            //    sql = string.Format("select TotalAmount from  SubscribeMain where SubscribeID = {0}", agreementID);
            //}

            if (AgreementType.Equals("签约"))
            {
                condition = string.Format("ContractID = {0}", agreementID);
                sql = "select TotalAmount from  ContractMain where " + condition;
            }
            else
            {

                condition = string.Format("SubscribeID = {0}", agreementID);
                sql = "select TotalAmount from  SubscribeMain where " + condition;
            }

            double totalAmount = double.Parse(SqlHelper.ExecuteScalar(sql).ToString());

            if (FrmMode == FormMode.add)
            {
                sql = "select isnull(SUM(Amount),0) from Receipt where  " + condition;
            }
            else
            {
                sql = "select isnull(SUM(Amount),0) from Receipt where  " + condition + " and ID != " + ReceiptID;
            }

            double totalReceipt = double.Parse(SqlHelper.ExecuteScalar(sql).ToString());

            totalReceipt += amount;

            if (totalReceipt > totalAmount)
            {
                result = true;
            }

            return result;
        }



        private void InsertReceipt()
        {
            string fields = string.Empty;

            if (AgreementType.Equals("签约"))
            {
                fields = "ContractID, ProjectID, RecDate, Amount, TypeCode, TypeName, SalesID, SalesName, Source, MakeDate, Maker";
            }
            else
            {
                fields = "SubscribeID, ProjectID, RecDate, Amount, TypeCode, TypeName, SalesID, SalesName, Source, MakeDate, Maker";
            }
            
            string values = AgreementID
                + "," + Login.User.ProjectID
                + ",'" + dateTimePicker_Receipt.Value.ToString("yyyy-MM-dd") + "'"
                + "," + textBox_RecAmount.Text.Trim()
                + "," + comboBox_ReceiptType.SelectedValue.ToString()
                + ",'" + comboBox_ReceiptType.Text + "'"
                + "," + SalesID
                + ",'" + SalesName + "'"
                + ",1,GETDATE(),'" + Login.User.UserName + "'";

            
            if (!textBox_Memo.Text.Trim().Equals(""))
            {
                fields += ",Memo";
                values += ",'" +textBox_Memo.Text.Trim() + "'";
            }

            string sql = "insert into receipt (" + fields + ") values (" + values + ")";

            try
            {
                if (SqlHelper.ExecuteNonQuery(sql) > 0)
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作错误：" + ex.Message) ;
            }

        }

        private void updateReceipt(string id)
        {
            string sql = "update Receipt set Amount = " + textBox_RecAmount.Text.Trim()
                + ", RecDate = '" + dateTimePicker_Receipt.Value.ToShortDateString() + "'"
                + ", TypeCode = " + comboBox_ReceiptType.SelectedValue.ToString()
                + ", TypeName = '" + comboBox_ReceiptType.Text + "'"
                + ", Memo = '" + textBox_Memo.Text.Trim() + "'"
                + " where id = " + id;

            try
            {
                if (SqlHelper.ExecuteNonQuery(sql) > 0)
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作错误：" + ex.Message);
            }
        }


        private void OnlyNumeric(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 45 && e.KeyChar != 46 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void FrmReceiptAdd_Load(object sender, EventArgs e)
        {
            if (FrmMode == FormMode.modify)
            {
                loadData(ReceiptID);
            }
            
        }

        private void loadData(string id)
        {
            string sql = string.Format("select RecDate,Amount,TypeCode, TypeName, Memo from [Receipt] where id = {0}", id);
            SqlDataReader sdr = SqlHelper.ExecuteReader(sql);
            sdr.Read();

            textBox_RecAmount.Text = string.Format("{0:G}",double.Parse(sdr["Amount"].ToString()));
            comboBox_ReceiptType.SelectedValue = sdr["TypeCode"].ToString();
            dateTimePicker_Receipt.Text = sdr["RecDate"].ToString();
            textBox_Memo.Text = sdr["Memo"].ToString();
        }
    }
}
