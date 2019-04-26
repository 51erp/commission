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
    public partial class FrmCredit : Form
    {
        public FrmCredit()
        {
            InitializeComponent();
            comboBox_LoanState.SelectedIndex = 0;
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string condition = string.Format(" and (PaymentType = {0} or PaymentType = {1})", (int)PayType.Loan, (int)PayType.DownPayInstalment);

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

            if (comboBox_LoanState.SelectedIndex == 0)
            {
                toolStripButton_Add.Enabled = true;
                toolStripButton_Del.Enabled = false;
                condition += " and LoanDate is null";
            }
            else
            {
                toolStripButton_Add.Enabled = false;
                toolStripButton_Del.Enabled = true;
                condition += " and LoanDate is not null";
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


        private void SetCheckState(bool state)
        {
            dataGridView_Contract.EndEdit();

            for (int i = 0; i < dataGridView_Contract.Rows.Count; i++)
            {
                dataGridView_Contract.Rows[i].Cells["ColCheck"].Value = state;
            }
        }


        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            if (!hasItemChecked())
                return;

            FrmCreditDate frmCDate = new FrmCreditDate();
            string loanDate = string.Empty;

            if (frmCDate.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                loanDate = frmCDate.LoanDate;
            else
                return;

            string contractId = string.Empty;
            string loan = string.Empty;


            dataGridView_Contract.EndEdit();
            for (int i = 0; i < dataGridView_Contract.Rows.Count; i++)
            {
                if ((bool)dataGridView_Contract.Rows[i].Cells["ColCheck"].EditedFormattedValue == true)
                {
                    contractId = dataGridView_Contract.Rows[i].Cells["ColContractID"].Value.ToString();

                    if (!IsDownPayOff(contractId))
                    {
                        if (MessageBox.Show("应收首付与收款不符，是否继续放贷？", "房地产佣金管理系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                        {
                            continue;
                        }
                    }

                    if (!Loan(contractId, loanDate))
                    {
                        if (MessageBox.Show("是否继续更新剩余记录？", "房地产佣金管理系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                        {
                            return;
                        }
                    }
                    dataGridView_Contract.Rows.RemoveAt(i);
                    i--; //删除后索引变化
                }
            }

            Prompt.Information("操作成功！");
            
        }

        private bool IsDownPayOff(string contractId)
        {
            bool result = false;
            string sql = string.Empty;

            sql = string.Format("select IsNull(DownPayAmount,0) from ContractMain where ContractID = {0}", contractId);
            double downpay = double.Parse(SqlHelper.ExecuteScalar(sql).ToString());

            sql = string.Format("select SUM(Amount) from Receipt where ContractID = {0}", contractId);
            double recDownPay = double.Parse(SqlHelper.ExecuteScalar(sql).ToString());

            if (downpay == recDownPay)
            {
                result = true;
            }

            return result;
        }

        private bool Loan(string contractId, string loanDate)
        {
            using (SqlConnection connection = SqlHelper.OpenConnection())  //创建连接对象 
            {
                SqlTransaction sqlTran = connection.BeginTransaction();    //开始事务 
                SqlCommand cmd = connection.CreateCommand();               //创建SqlCommand对象 
                cmd.Transaction = sqlTran;                                 //将SqlCommand与SqlTransaction关联起
                string sql = string.Empty;

                try
                {
                    sql = string.Format("select Loan, PaymentType, SalesID, SalesName from ContractMain where ContractID = {0}", contractId);
                    SqlDataReader sdr = SqlHelper.ExecuteReader(sql);
                    sdr.Read();
                    //收款信息
                    sql = string.Format("insert into [Receipt] (ContractID, Amount, RecDate, IsLoan, TypeCode, TypeName, SalesID, SalesName, MakeDate, Maker,ProjectID) values "
                        + "({0},{1},'{2}',{3},{4},'{5}',{6},'{7}',{8},'{9}',{10})", 
                        contractId,
                        sdr["Loan"].ToString(),
                        loanDate,
                        1,
                        (int)Receivables.贷款,
                        Receivables.贷款,
                        sdr["SalesID"].ToString(),
                        sdr["SalesName"].ToString(),
                        "GETDATE()",
                        Login.User.UserName,
                        Login.User.ProjectID
                        );
                    
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    sdr.Close();

                    cmd.CommandText = string.Format("Update ContractMain set LoanDate = '{0}' where ContractID = {1}", loanDate, contractId);
                    cmd.ExecuteNonQuery();

                    sqlTran.Commit();  //事务提交
                    return true;
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();  //异常事务回滚
                    Prompt.Error("操作失败， 错误：" + ex.Message);
                    return false;
                }

            }
        }

        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {
            if (!hasItemChecked())
                return;

            string contractId = string.Empty;
            string loan = string.Empty;

            dataGridView_Contract.EndEdit();

            

            if (MessageBox.Show("确定要取消所选记录的贷款发放信息？","房地产佣金管理系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                for (int i = 0; i < dataGridView_Contract.Rows.Count; i++)
                {
                    if ((bool)dataGridView_Contract.Rows[i].Cells["ColCheck"].EditedFormattedValue == true)
                    {
                        contractId = dataGridView_Contract.Rows[i].Cells["ColContractID"].Value.ToString();

                        object obj = SqlHelper.ExecuteScalar(string.Format("select count(ID) from Receipt where  SettleState != 0 and TypeCode = {0} and  ContractID = {1}", (int)Receivables.贷款, contractId));
                        if (Convert.ToInt32(obj) > 0)
                        {
                            if (MessageBox.Show("放贷记录已结算，是否继续下一条记录的处理？\r\n是：继续，否则中断。","房地产佣金管理系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                continue;
                            }
                            else
                            {
                                return;
                            }
                        }

                        if (!removeLoan(contractId))
                        {
                            Prompt.Error("有错误发生，请重新执行或联系管理员！");
                            return;
                        }
                    }
                    dataGridView_Contract.Rows.RemoveAt(i);
                    i--; //删除后索引变化
                }
            }
            Prompt.Information("操作成功！");
        }

        private bool removeLoan(string contractId)
        {
            using (SqlConnection connection = SqlHelper.OpenConnection())  //创建连接对象 
            {
                SqlTransaction sqlTran = connection.BeginTransaction();    //开始事务 
                SqlCommand cmd = connection.CreateCommand();               //创建SqlCommand对象 
                cmd.Transaction = sqlTran;                                 //将SqlCommand与SqlTransaction关联起
                string sql = string.Empty;

                try
                {
                    //删除收款记录
                    cmd.CommandText = string.Format("delete [Receipt] where contractID = {0} and TypeCode = {1}",contractId, (int)Receivables.贷款);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "update ContractMain set LoanDate = null where ContractID = " + contractId;
                    cmd.ExecuteNonQuery();

                    sqlTran.Commit();  //事务提交
                    return true;
                }
                catch (Exception)
                {
                    sqlTran.Rollback();  //异常事务回滚
                    return false;
                }

            }
        }

        private void toolStripButton_All_Click(object sender, EventArgs e)
        {
            SetCheckState(true);
        }

        private void toolStripButton_None_Click(object sender, EventArgs e)
        {
            SetCheckState(false);
        }

    }
}
