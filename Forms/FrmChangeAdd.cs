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

namespace Commission.Forms
{
    public partial class FrmChangeAdd : Form
    {
        public string ContractID = string.Empty;
        public Dictionary<string, string> dictChange = new Dictionary<string, string>();

        private DataTable dtInstallment = new DataTable();

        private PayType PayType;
        public FrmChangeAdd()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }


        private PayType GetPayType(string paymentId)
        {
            string sql = string.Format("select IsNull(PayType,0) from PaymentMode where ID = {0}", paymentId);
            int result = int.Parse(SqlHelper.ExecuteScalar(sql).ToString());
            return (PayType)result;
        }


        private void FrmChangeAdd_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string sql = string.Empty;

            //主表信息
            sql = string.Format("select SalesName, PaymentID, PaymentName, DownPayRate, DownPayAmount, Loan, TotalAmount, ContractDate from [ContractMain] where ContractID = {0}", ContractID);
            SqlDataReader sdr = SqlHelper.ExecuteReader(sql);
            sdr.Read();

            PayType = GetPayType(sdr["PaymentID"].ToString());

            //分期信息
            if ((PayType == PayType.DownPayInstalment) || (PayType == PayType.FullInstalment))
            {
                sql = "select Sequence, PayDate, cast(Amount AS int) Amount, Settled from Installment where ContractID = " + ContractID + " order by Sequence ";
                dtInstallment = SqlHelper.ExecuteDataTable(sql);

                button_Installment.Enabled = true;
            }

            if ((PayType == PayType.DownPayInstalment) || (PayType == PayType.Loan))
            {
                textBox_NewLoan.ReadOnly = false;
            }

            if (( PayType == PayType.Full) || ( PayType == PayType.FullInstalment))
            {
                textBox_NewDownPay.ReadOnly = true;
            }

            //签约信息
            textBox_PaymentMode.Text = sdr["PaymentName"].ToString();
            textBox_DownPayRate.Text = sdr["DownPayRate"].ToString();
            textBox_DownPay.Text = double.Parse(sdr["DownPayAmount"].ToString()).ToString("F0");
            textBox_Loan.Text = double.Parse(sdr["Loan"].ToString()).ToString("F0");
            textBox_TotalAmount.Text = double.Parse(sdr["TotalAmount"].ToString()).ToString("F0");

            //房源明细
            sql = string.Format("select ConDID, ItemID, ItemTypeName, Building, Unit, ItemNum, Area, Price ,Amount, '0' as ChangeArea, '0' as NewAmount  from [ContractDetail] where ContractID ={0} order by rowid ", ContractID);
            dataGridView_SaleItem.DataSource = SqlHelper.ExecuteDataTable(sql);

            //变更信息
            textBox_NewTotalAmount.Text = double.Parse(sdr["TotalAmount"].ToString()).ToString("F0");
            textBox_NewLoan.Text = double.Parse(sdr["Loan"].ToString()).ToString("F0");
            textBox_NewDownPay.Text = double.Parse(sdr["DownPayAmount"].ToString()).ToString("F0");
        }

        private void dataGridView_TransDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            double newArea = 0;
            double price = 0;
            double amount = 0;

            double.TryParse(dataGridView_SaleItem.Rows[rowIndex].Cells["ColNewArea"].EditedFormattedValue.ToString(), out newArea);
            
            //
            //设置当前行金额
            if (newArea == 0)
            {
                dataGridView_SaleItem.Rows[rowIndex].Cells["ColNewAmount"].Value = 0;
            }
            else
            {
                price = double.Parse(dataGridView_SaleItem.Rows[rowIndex].Cells["ColPrice"].Value.ToString());
                dataGridView_SaleItem.Rows[rowIndex].Cells["ColNewAmount"].Value = Math.Round(newArea * price, 0, MidpointRounding.AwayFromZero).ToString();
            }

            double differ = 0;
            for (int i = 0; i < dataGridView_SaleItem.Rows.Count; i++)
            {
                double.TryParse(dataGridView_SaleItem.Rows[i].Cells["ColNewArea"].EditedFormattedValue.ToString(), out newArea);

                if (newArea == 0)
                    continue;
                
                price = double.Parse(dataGridView_SaleItem.Rows[i].Cells["ColPrice"].Value.ToString());
                amount = double.Parse(dataGridView_SaleItem.Rows[i].Cells["ColAmount"].Value.ToString());

                differ += Math.Round(newArea * price - amount, 0, MidpointRounding.AwayFromZero);
            }

            //设置修改数据
            SetReviseData(differ); 
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetReviseData(double differ)
        {
            if (differ == 0)
            {
                textBox_NewDownPay.Text = textBox_DownPay.Text;
                textBox_NewLoan.Text = textBox_Loan.Text;
                textBox_NewTotalAmount.Text = textBox_TotalAmount.Text;
                textBox_Differ.Text = differ.ToString();
            }
            else
            {
                double newTotalAmount = double.Parse(textBox_TotalAmount.Text) + differ;

                textBox_Differ.Text = differ.ToString();
                textBox_NewTotalAmount.Text = newTotalAmount.ToString();

                //贷款金额取整，先计算
                double truncLoan = Math.Floor((newTotalAmount * (1 - double.Parse(textBox_DownPayRate.Text.Trim()) / 100)) / 10000) * 10000;

                textBox_NewLoan.Text = Math.Round(truncLoan, 0, MidpointRounding.AwayFromZero).ToString();
                textBox_NewDownPay.Text = Math.Round((double.Parse(textBox_NewTotalAmount.Text.Trim()) - truncLoan), 0, MidpointRounding.AwayFromZero).ToString();
            }
        }

        private void dataGridView_TransDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!dataGridView_SaleItem.Columns[e.ColumnIndex].Name.Equals("ColNewArea"))
            {
                return;
            }

            double newArea = 0;
            if (double.TryParse(dataGridView_SaleItem.Rows[e.RowIndex].Cells["ColNewArea"].EditedFormattedValue.ToString(), out newArea) == false)
            {
                Prompt.Error("变更面积应填写正确的数字格式！");
                e.Cancel = true;
            }

            double area = 0;
            double.TryParse(dataGridView_SaleItem.Rows[e.RowIndex].Cells["ColArea"].Value.ToString(), out area);
            if (newArea == area)
            {
                Prompt.Error("变更面积与原面积无差异！");
                e.Cancel = true;
            }
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            this.Validate();

            dataGridView_SaleItem.EndEdit();

            bool isHasNewArea = false;
            for (int i = 0; i < dataGridView_SaleItem.Rows.Count; i++)
            {
                if (double.Parse(dataGridView_SaleItem.Rows[i].Cells["ColNewArea"].Value.ToString()) > 0)
                {
                    isHasNewArea = true;
                    break;
                }
            }

            if (!isHasNewArea)
            {
                Prompt.Warning("没有面积变更！不能保存。");
                return;
            }

            if (inputValidate())
            {
                UpdateData();
            }
        }

        /// <summary>
        /// 验证输入数据
        /// </summary>
        /// <returns></returns>
        private bool inputValidate()
        {
            bool result = true;



            if (textBox_ContractNum.Text.Trim().Equals(""))
            {
                Prompt.Warning("签约编号不能为空。");
                textBox_ContractNum.Focus();
                return false;
            }

            if (Transaction.isExistCode(textBox_ContractNum.Text.Trim()))
            {
                Prompt.Warning("签约编号已经存在，不能重复。");
                return false;
            }

            if ((PayType == PayType.FullInstalment) || (PayType == PayType.DownPayInstalment))
            {
                if (dtInstallment.Rows.Count == 0)
                {
                    Prompt.Warning("没有设置分期付款详细记录！");
                    return false;
                }

                int amount = Convert.ToInt32(dtInstallment.Compute("sum(Amount)", ""));

                int payment = int.Parse(textBox_NewDownPay.Text);

                if (payment != amount)
                {
                    Prompt.Warning("应付首付与分期付款总额不符！");
                    return false;
                }
            }


            return result;
        }

        /// <summary>
        /// 变更签约数据
        /// 主表：合同编号、首付金额、贷款金额、合同总款，从表：面积、金额
        /// </summary>
        private void UpdateData()
        {
            using (SqlConnection connection = SqlHelper.OpenConnection())  //创建连接对象 
            {
                SqlTransaction sqlTran = connection.BeginTransaction();    //开始事务 
                SqlCommand cmd = connection.CreateCommand();               //创建SqlCommand对象 
                cmd.Transaction = sqlTran;                                 //将SqlCommand与SqlTransaction关联起

                try
                {
                    string newContractNum = textBox_ContractNum.Text.Trim();
                    string sql = string.Empty;

                    //签约主表
                    cmd.CommandText = string.Format("update ContractMain set ContractNum = '{0}',TotalAmount = {1},DownPayAmount = {2}, Loan = {3}  where  ContractID = {4}", newContractNum, textBox_NewTotalAmount.Text, textBox_NewDownPay.Text, textBox_NewLoan.Text, ContractID);
                    cmd.ExecuteNonQuery();

                    //面积变更主表
                    string changeDate = dateTimePicker_ChangeDate.Value.ToShortDateString();
                    //string confirmType = comboBox_ConfirmType.Text;
                    string memo = textBox_Memo.Text.Trim();

                    cmd.CommandText = string.Format("insert into AreaChangeMain "
                        + "(ContractID, OrigDownPay, OrigLoan, OrigTotalAmount,NewDownPay, NewLoan, NewTotalAmount, ChangeDate, Memo, MakeUserName, MakeDate) "
                        + "output inserted.ID values ({0},{1},{2},{3},{4},{5},{6},'{7}','{8}','{9}',{10})",
                        ContractID, textBox_DownPay.Text, textBox_Loan.Text, textBox_TotalAmount.Text, textBox_NewDownPay.Text, textBox_NewLoan.Text, textBox_NewTotalAmount.Text, changeDate, memo, Login.User.UserName, "GETDATE()");
                    string changeId = cmd.ExecuteScalar().ToString();

                    for (int i = 0; i < dataGridView_SaleItem.Rows.Count; i++)
                    {
                        if (double.Parse(dataGridView_SaleItem.Rows[i].Cells["ColNewArea"].Value.ToString()) > 0)
                        {
                            //签约明细
                            string condid = dataGridView_SaleItem.Rows[i].Cells["ColConDID"].Value.ToString();
                            string newArea = dataGridView_SaleItem.Rows[i].Cells["ColNewArea"].FormattedValue.ToString();
                            string newAmount = dataGridView_SaleItem.Rows[i].Cells["ColNewAmount"].FormattedValue.ToString();

                            cmd.CommandText = string.Format("update ContractDetail set area = {0}, amount = {1} where ConDID = {2}", newArea, newAmount, condid);
                            cmd.ExecuteNonQuery();


                            //面积变更明细
                            string itemId = dataGridView_SaleItem.Rows[i].Cells["ColItemID"].Value.ToString();
                            string building = dataGridView_SaleItem.Rows[i].Cells["ColBuilding"].Value.ToString();
                            string unit = dataGridView_SaleItem.Rows[i].Cells["ColUnit"].Value.ToString();
                            string itemNum = dataGridView_SaleItem.Rows[i].Cells["ColItemNum"].Value.ToString();
                            string origAmount = dataGridView_SaleItem.Rows[i].Cells["ColAmount"].Value.ToString();
                            string origArea = dataGridView_SaleItem.Rows[i].Cells["ColArea"].Value.ToString();

                            string strValues = changeId + "," + itemId + ",'" + building + "','" + unit + "','" + itemNum + "'," + origAmount + "," + origArea + "," + newArea;

                            cmd.CommandText = string.Format("insert into AreaChangeDetail (MainID,ItemID,Building,Unit,ItemNum,OrigAmount,OrigArea,NewArea) values ({0}) ", strValues);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    //更新分期付款设置
                    if (dtInstallment.Rows.Count > 0)
                    {
                        //保存原数据
                        cmd.CommandText = string.Format("insert into InstallmentHis (SourceID, SourceType,ContractID,Sequence,PayDate,Amount,Settled) select {0},{1},ContractID,Sequence,PayDate,Amount,Settled from Installment where ContractID = {2}", changeId, '1', ContractID);
                        cmd.ExecuteNonQuery();

                        //更新新数据
                        cmd.CommandText = "delete Installment where ContractID = " + ContractID; //清除原数据
                        cmd.ExecuteNonQuery();

                        for (int i = 0; i < dtInstallment.Rows.Count; i++)
                        {
                            cmd.CommandText = string.Format("insert into Installment (ContractID, Sequence,Amount, PayDate) values ({0},{1},{2},'{3}')",
                                ContractID, dtInstallment.Rows[i]["Sequence"].ToString(), dtInstallment.Rows[i]["Amount"].ToString(), dtInstallment.Rows[i]["PayDate"].ToString());
                            cmd.ExecuteNonQuery();
                        }
                    }
         

                    sqlTran.Commit();  //事务提交

                    DialogResult = System.Windows.Forms.DialogResult.OK;

                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();  //异常事务回滚
                    Prompt.Error("操作失败， 错误：" + ex.Message);
                }

            }
        }

        private void textBox_NewDownPay_TextChanged(object sender, EventArgs e)
        {
            double total = 0;
            double.TryParse(textBox_NewTotalAmount.Text, out total);

            if (total == 0) return;


            double downpay = 0;
            double.TryParse(textBox_NewDownPay.Text, out downpay);


            textBox_NewLoan.Text = (total - downpay).ToString();
        }

        private void textBox_NewLoan_TextChanged(object sender, EventArgs e)
        {
            double total = 0;
            double.TryParse(textBox_NewTotalAmount.Text, out total);

            if (total == 0) return;

            double loan = 0;
            double.TryParse(textBox_NewLoan.Text, out loan);

            textBox_NewDownPay.Text = (total - loan).ToString();
        }

        //分期设置
        private void button_Installment_Click(object sender, EventArgs e)
        {
            FrmInstallment frmInstallment = new FrmInstallment();

            frmInstallment.InstallmentAmount = textBox_NewDownPay.Text;
            frmInstallment.ContractID = ContractID;
            frmInstallment.dtInstallment = dtInstallment;

            if (frmInstallment.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                dtInstallment = frmInstallment.dtInstallment;
        }

        private void FrmChangeAdd_Shown(object sender, EventArgs e)
        {
            dataGridView_SaleItem.CurrentCell = dataGridView_SaleItem.Rows[0].Cells["ColNewArea"];
            dataGridView_SaleItem.BeginEdit(true);
        }
    }
}
