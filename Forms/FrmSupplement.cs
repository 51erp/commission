using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Commission.Forms
{
    public partial class FrmSupplement : Form
    {
        public string TID = string.Empty;
        public string ContractCode = string.Empty;

        public FrmSupplement()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            if (double.Parse(textBox_DownPayRate.Text) >= double.Parse(comboBox_DownPayRate.Text.Trim()))
            {
                Prompt.Warning("首付比例必须大于原比例！");
                comboBox_DownPayRate.Focus();
                return;
            }

            if (textBox_ContractCode.Text.Trim().Equals(""))
            {
                Prompt.Warning("签约编号不能为空！");
                textBox_ContractCode.Focus();
                return;
            }

            getDownPay();

            double dpTotal = 0;
            double newDP = 0;

            double.TryParse(textBox_DownPayTotal.Text,out dpTotal);
            double.TryParse(textBox_NewDP.Text, out newDP);
            if (dpTotal > newDP)
            {
                saveData();
            }
            else
            {
                Prompt.Warning("首付总额必须大于首付金额！");
            }
        }


        private void saveData()
        {
            string downPayRate = comboBox_DownPayRate.Text;
            string downPay = textBox_DownPayTotal.Text;
            string loan = textBox_LoanTotal.Text;
            string supplement = textBox_Supplement.Text.Trim();


            using (SqlConnection connection = SqlHelper.OpenConnection())  //创建连接对象 
            {
                SqlTransaction sqlTran = connection.BeginTransaction();    //开始事务 
                SqlCommand cmd = connection.CreateCommand();               //创建SqlCommand对象 
                cmd.Transaction = sqlTran;                                 //将SqlCommand与SqlTransaction关联起

                try
                {
                    string newConCode = textBox_ContractCode.Text.Trim();

                    //业务表
                    cmd.CommandText = string.Format("update Transactions set ContractCode = '{0}' where tid = {1} and ContractCode = '{2}'", newConCode, TID, ContractCode);
                    cmd.ExecuteNonQuery();

                    //业务主表
                    cmd.CommandText = string.Format("update TransMain set ContractCode = '{0}', DownPayRate = {1}, DownPay = {2}, Loan = {3} where tid = {4} and ContractCode = '{5}'", newConCode,downPayRate, downPay, loan, TID, ContractCode);
                    cmd.ExecuteNonQuery();

                    //业务从表
                    cmd.CommandText = string.Format("update TransDetail set ContractCode = '{0}' where tid = {1} and ContractCode = '{2}'", newConCode, TID, ContractCode);
                    cmd.ExecuteNonQuery();


                    //收款表
                    cmd.CommandText = getReceiptSQL(TID, newConCode, supplement);
                    cmd.ExecuteNonQuery();

                    sqlTran.Commit();
                    Prompt.Information("操作成功！");
                    Close();
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();  //异常事务回滚
                    Prompt.Error("操作失败， 错误：" + ex.Message);
                }
            }

        }

        private string getReceiptSQL(string tid, string conCode, string receipt)
        {
            string sql = string.Empty;

            string fields = "TID,ContractCode,Amount,RecDate,TypeCode,TypeName,Memo, MakeDate,Maker";
            string values = tid
                + ",'" + conCode
                + "'," + receipt
                + ",'" + dateTimePicker_ContractDate.Value.ToShortDateString() + "'"
                + ",2,'首付','补交首付', getDate()"
                + ",'" + Login.User.UserName + "'";

            sql = "insert into [Receipt] (" + fields + ") values (" + values + ")";

            return sql;
        }


        private void loadData(string tid, string contractCode)
        {
            string sql = string.Empty;

            //主表信息
            sql = string.Format("select DownPayRate,DownPay,Loan,TotalAmount from [TransMain] where tid = {0} and contractCode = '{1}'", TID, ContractCode);
            SqlDataReader sdr = SqlHelper.ExecuteReader(sql);
            sdr.Read();
            textBox_TotalAmount.Text = double.Parse(sdr["TotalAmount"].ToString()).ToString("F0");
            textBox_DownPayRate.Text = sdr["DownPayRate"].ToString();
            textBox_DownPay.Text = double.Parse(sdr["DownPay"].ToString()).ToString("F0");
            textBox_Loan.Text = double.Parse(sdr["Loan"].ToString()).ToString("F0");

            string dp = (double.Parse(sdr["TotalAmount"].ToString()) * double.Parse(sdr["DownPayRate"].ToString()) / 100).ToString();
            textBox_DP.Text = dp;

            comboBox_DownPayRate.Text = sdr["DownPayRate"].ToString();
            textBox_NewDP.Text = dp;
            textBox_DownPayTotal.Text = double.Parse(sdr["DownPay"].ToString()).ToString("F0");
            textBox_LoanTotal.Text = double.Parse(sdr["Loan"].ToString()).ToString("F0");

            comboBox_DownPayRate.Focus();
        }

        private void FrmSupplement_Load(object sender, EventArgs e)
        {
            loadData(TID, ContractCode);
        }

        private void textBox_Supplement_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.OnlyNumeric(sender, e);
        }

        private void comboBox_DownPayRate_Validating(object sender, CancelEventArgs e)
        {
            double rate = 0;

            if (!double.TryParse(comboBox_DownPayRate.Text.Trim(), out rate))
            {
                Prompt.Warning("请输入正确的数字格式！");
                e.Cancel = true;
            }

            if (double.Parse(textBox_DownPayRate.Text) >= rate )
            {
                Prompt.Warning("首付比例必须大于原比例！");
                e.Cancel = true;
            }

            getDownPay();
        }


        private void getDownPay()
        {
            double dp = double.Parse(textBox_TotalAmount.Text.Trim()) * double.Parse(comboBox_DownPayRate.Text.Trim()) / 100;

            textBox_NewDP.Text = Math.Round(dp, 0, MidpointRounding.AwayFromZero).ToString();
        }

        private void comboBox_DownPayRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.OnlyNumeric(sender, e);
        }

        private void textBox_Supplement_TextChanged(object sender, EventArgs e)
        {
            //double.Parse(textBox_TotalAmount.Text)

            double dpTotal = 0;

            textBox_DownPayTotal.Text = (double.Parse(textBox_DownPay.Text) + double.Parse(textBox_Supplement.Text.Trim())).ToString();

            double.TryParse(textBox_DownPayTotal.Text, out dpTotal);

            textBox_LoanTotal.Text = string.Format("{0}", double.Parse(textBox_TotalAmount.Text) - dpTotal);
        }


    }
}
