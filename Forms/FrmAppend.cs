using Commission.Business;
using Commission.DataAccess;
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
    public partial class FrmAppend : Form
    {
        public string ContractID;

        public FrmAppend()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            if (inputValidate())
            {
                saveData();
            }

        }

        private bool inputValidate()
        {
            if (dataGridView_SaleItem.Rows.Count == 0)
            {
                Prompt.Warning("没有添加记录，无法保存！");
                return false;
            }

            if (textBox_ContractNum.Text.Trim().Equals(""))
            {
                Prompt.Warning("签约编号不能为空！");
                return false;
            }

            if (Transaction.isExistCode(textBox_ContractNum.Text.Trim()))
            {
                Prompt.Warning("签约编号已经存在，不能重复。");
                return false;
            }
                
            return true;
        }

        private void saveData()
        {
            using (SqlConnection connection = SqlHelper.OpenConnection())  //创建连接对象 
            {
                SqlTransaction sqlTran = connection.BeginTransaction();    //开始事务 
                SqlCommand cmd = connection.CreateCommand();               //创建SqlCommand对象 
                cmd.Transaction = sqlTran;                                 //将SqlCommand与SqlTransaction关联起

                try
                {
                    string sql = string.Empty;
                    //主表
                    sql = string.Format("update ContractMain set DownPayAmount = {0}, Loan = {1}, TotalAmount = {2}, "
                        + " ContractNum = '{3}', ContractDate = '{4}' where ContractID = {5}", 
                        textBox_TotalDownPay.Text,
                        textBox_TotalLoan.Text,
                        textBox_TotalContract.Text,
                        textBox_ContractNum.Text.Trim(),
                        dateTimePicker_ContractDate.Value.ToString("yyyy-MM-dd"),
                        ContractID);
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();


                    sql = string.Format("select ISNULL(Count(ContractID),0) from ContractDetail where ContractID = {0}", ContractID);

                    int rowid = int.Parse(SqlHelper.ExecuteScalar(sql).ToString());


                    //从表
                    for (int i = 0; i < dataGridView_SaleItem.Rows.Count; i++)
                    {
                        sql = getTransDetailSQL(ContractID, i, rowid+i);
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();

                        sql = string.Format("update saleitem set SaleStateCode = {0}, SaleStateName = '{1}' where ItemID = {2}", (int)ItemSaleState.签约, ItemSaleState.签约, dataGridView_SaleItem.Rows[i].Cells["ColItemID"].Value.ToString());
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                    }

                    sqlTran.Commit();  //事务提交
                    connection.Close();

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();  //异常事务回滚
                    Prompt.Error("操作失败， 错误：" + ex.Message);
                }
            }

        }

        
        //生成新增业务明细SQL语句
        private string getTransDetailSQL(string contractId, int rowIdx, int rowid)
        {
            string sql = string.Empty;

            string fields = "ContractID,RowID,IsBind, ItemTypeCode,ItemTypeName,ItemID,building,Unit,ItemNum,Area,Price,Amount";
            string values = ContractID
                + "," + rowid + ",1"
                + "," + dataGridView_SaleItem.Rows[rowIdx].Cells["ColItemType"].Value.ToString()
                + ",'" + dataGridView_SaleItem.Rows[rowIdx].Cells["ColTypeName"].Value.ToString() + "'"
                + "," + dataGridView_SaleItem.Rows[rowIdx].Cells["ColItemID"].Value.ToString()
                + ",'" + dataGridView_SaleItem.Rows[rowIdx].Cells["ColBuilding"].Value.ToString() + "'"
                + ",'" + dataGridView_SaleItem.Rows[rowIdx].Cells["ColUnit"].Value.ToString() + "'"
                + ",'" + dataGridView_SaleItem.Rows[rowIdx].Cells["ColItemNum"].Value.ToString() + "'"
                + "," + dataGridView_SaleItem.Rows[rowIdx].Cells["ColArea"].Value.ToString()
                + "," + dataGridView_SaleItem.Rows[rowIdx].Cells["ColPrice"].Value.ToString()
                + "," + dataGridView_SaleItem.Rows[rowIdx].Cells["ColAmout"].Value.ToString();

            sql = "insert into [ContractDetail] (" + fields + ") values (" + values + ")";

            return sql;
        }

        //生成新增收款语句
        private string getReceiptSQL(string tid, string conCode)
        {
            string sql = string.Empty;

            string fields = "TID,ContractCode,Amount,RecDate,TypeCode,TypeName,Memo, MakeDate,Maker";
            string values = tid
                + ",'" + conCode
                + "'," + textBox_TotalDownPay.Text.Trim()
                + ",'" + dateTimePicker_ContractDate.Value.ToShortDateString() + "'"
                + ",2,'首付','储藏间单独收款',getDate()"
                + ",'" + Login.User.UserName + "'";

            sql = "insert into [Receipt] (" + fields + ") values (" + values + ")";

            return sql;
        }


        private void LoadData()
        {
            string sql = string.Empty;

            //主表信息
            sql = string.Format("select ProjectID,CustomerID,SalesName,PaymentID, PaymentName, PaymentType, DownPayRate, DownPayAmount, Loan, TotalAmount,ContractDate from [ContractMain] where ContractID = '{0}'", ContractID);
            SqlDataReader sdr = SqlHelper.ExecuteReader(sql);
            sdr.Read();

            PayType payCode = (PayType)(int.Parse(sdr["PaymentType"].ToString()));
            if ((payCode == PayType.Full) || (payCode == PayType.FullInstalment))
            {
                textBox_TotalLoan.ReadOnly = true;
            }

            textBox_TotalAmount.Text = double.Parse(sdr["TotalAmount"].ToString()).ToString("F0");
            dateTimePicker_ContractDate.Value = DateTime.Parse(sdr["ContractDate"].ToString());

            textBox_PaymentMode.Tag = sdr["PaymentID"].ToString();
            textBox_PaymentMode.Text = sdr["PaymentName"].ToString();
            textBox_PayRate.Text = sdr["DownPayRate"].ToString();
            textBox_DownPay.Text = double.Parse(sdr["DownPayAmount"].ToString()).ToString("F0");
            textBox_Loan.Text = double.Parse(sdr["Loan"].ToString()).ToString("F0");


            //客户信息
            sql = "select CustomerID,CustomerName,CustomerPhone,PID,Addr from Customer where CustomerID = " + sdr["CustomerID"].ToString();
            sdr = SqlHelper.ExecuteReader(sql);
            sdr.Read();
            textBox_CusName.Text = sdr["CustomerName"].ToString();
            textBox_CusPhone.Text = sdr["CustomerPhone"].ToString();
            textBox_CusPID.Text = sdr["PID"].ToString();
            textBox_CusAddr.Text = sdr["Addr"].ToString();

            sdr.Close();
        }

        private void FrmAppend_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            FrmBaseSaleItem saleItem = new FrmBaseSaleItem();

            saleItem.ItemSaleProperty = 1;

            if (saleItem.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SaleItem item = new SaleItem();

                item.getSaleItemByID(saleItem.saleItemID);

                int index = this.dataGridView_SaleItem.Rows.Add();
                dataGridView_SaleItem.Rows[index].Cells["ColItemID"].Value = item.ItemID;
                dataGridView_SaleItem.Rows[index].Cells["ColItemType"].Value = item.ItemTypeCode;
                dataGridView_SaleItem.Rows[index].Cells["ColTypeName"].Value = item.ItemTypeName;
                dataGridView_SaleItem.Rows[index].Cells["ColBuilding"].Value = item.Building;
                dataGridView_SaleItem.Rows[index].Cells["ColUnit"].Value = item.Unit;
                dataGridView_SaleItem.Rows[index].Cells["ColItemNum"].Value = item.ItemNum;
                dataGridView_SaleItem.Rows[index].Cells["ColArea"].Value = item.Area;
                dataGridView_SaleItem.Rows[index].Cells["ColPrice"].Value = item.Price.ToString();
                dataGridView_SaleItem.Rows[index].Cells["ColAmout"].Value = Math.Round((double.Parse(item.Area) * double.Parse(item.Price)), 0, MidpointRounding.AwayFromZero).ToString("F0");

                getRowsTotalAmount();
            }
        }

        private void getRowsTotalAmount()
        {
            double total = 0;  //附加总额
            double amount = 0; 

            foreach (DataGridViewRow row in dataGridView_SaleItem.Rows)
            {
                double.TryParse(row.Cells["ColAmout"].EditedFormattedValue.ToString(), out amount);
                total += amount;
            }

            textBox_Amount.Text = total.ToString("G");

            double totalamount = 0; //签约总额
            double.TryParse(textBox_TotalAmount.Text, out totalamount);

            textBox_TotalContract.Text = (totalamount + total).ToString(); //签约合计


            //附加后贷款金额
            double loan = double.Parse(textBox_TotalContract.Text.Trim()) * (1 - double.Parse(textBox_PayRate.Text.Trim()) / 100);
            double truncLoan = Math.Floor(loan / 10000) * 10000;
            textBox_TotalLoan.Text = Math.Round(truncLoan, 0, MidpointRounding.AwayFromZero).ToString();

            //附加后应付首付
            textBox_TotalDownPay.Text = Math.Round((double.Parse(textBox_TotalContract.Text.Trim()) - truncLoan), 0, MidpointRounding.AwayFromZero).ToString();
        }

        private void toolStripButton_Remove_Click(object sender, EventArgs e)
        {
            if (dataGridView_SaleItem.CurrentRow != null)
            {
                int idx = dataGridView_SaleItem.CurrentRow.Index;
                if (idx != -1)
                    dataGridView_SaleItem.Rows.RemoveAt(idx);

                getRowsTotalAmount();
            }
        }

        private void dataGridView_SaleItem_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            Console.WriteLine(dataGridView_SaleItem.Columns[e.ColumnIndex].Name);

            if ((dataGridView_SaleItem.Columns[e.ColumnIndex].Name == "ColAmout") || (dataGridView_SaleItem.Columns[e.ColumnIndex].Name == "ColPrice"))
            {
                double amount = 0;
                bool result = double.TryParse(dataGridView_SaleItem.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString(), out amount);

                if (!result)
                {
                    Prompt.Error("请填写正确的数字格式！");
                    e.Cancel = true;
                }
            }

        }

        private void dataGridView_SaleItem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            double area = 0;
            double price = 0;
            double amount = 0;
            if (dataGridView_SaleItem.Columns[e.ColumnIndex].Name == "ColPrice")
            {
                double.TryParse(dataGridView_SaleItem.Rows[rowIndex].Cells["ColArea"].Value.ToString(), out area);
                double.TryParse(dataGridView_SaleItem.Rows[rowIndex].Cells["ColPrice"].Value.ToString(), out price);

                dataGridView_SaleItem.Rows[rowIndex].Cells["ColAmout"].Value = (area * price).ToString("F0");
            }
            else if (dataGridView_SaleItem.Columns[e.ColumnIndex].Name == "ColAmout")
            {
                double.TryParse(dataGridView_SaleItem.Rows[rowIndex].Cells["ColArea"].Value.ToString(), out area);
                double.TryParse(dataGridView_SaleItem.Rows[rowIndex].Cells["ColAmout"].EditedFormattedValue.ToString(), out amount);

                dataGridView_SaleItem.Rows[rowIndex].Cells["ColPrice"].Value = (amount / area).ToString("F0");
            }

            getRowsTotalAmount();
        }


        private void textBox_TotalDownPay_TextChanged(object sender, EventArgs e)
        {
            double total = 0;
            double.TryParse(textBox_TotalContract.Text, out total);

            if (total == 0) return;


            double downpay = 0;
            double.TryParse(textBox_TotalDownPay.Text, out downpay);


            textBox_TotalLoan.Text = (total - downpay).ToString();
        }

        private void textBox_TotalDownPay_Validating(object sender, CancelEventArgs e)
        {
            double downpay = 0;
            if (!double.TryParse(textBox_TotalDownPay.Text, out downpay))
            {
                Prompt.Error("请录入正确的数字格式！");
                textBox_TotalDownPay.Focus();
                e.Cancel = true;
            }
        }

        private void textBox_TotalLoan_TextChanged(object sender, EventArgs e)
        {
            double total = 0;
            double.TryParse(textBox_TotalContract.Text, out total);
            
            if (total == 0) return;

            double loan = 0;
            double.TryParse(textBox_TotalLoan.Text, out loan);

            textBox_TotalDownPay.Text = (total - loan).ToString();
        }

        private void textBox_TotalLoan_Validating(object sender, CancelEventArgs e)
        {
            double loan = 0;
            if (!double.TryParse(textBox_TotalLoan.Text, out loan))
            {
                Prompt.Error("请录入正确的数字格式！");
                textBox_TotalLoan.Focus();
                e.Cancel = true;
            }
        }

        private void textBox_TotalLoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.OnlyNumeric(sender, e);
        }

        private void FrmAppend_Shown(object sender, EventArgs e)
        {
            textBox_ContractNum.Focus();
        }

    }
}
