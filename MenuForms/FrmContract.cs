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
    public partial class FrmContract : Form
    {
        public FrmContract()
        {
            InitializeComponent();
        }


        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string condition = " and ProjectID = " + Login.User.ProjectID;

            if (!textBox_CusName.Text.Trim().Equals(""))
                condition += " and  CustomerName like '%" + textBox_CusName.Text.Trim() + "%'";

            if (!textBox_Phone.Text.Trim().Equals(""))
                condition += " and  (CustomerPhone like '%" + textBox_Phone.Text.Trim();

            if (!textBox_Building.Text.Trim().Equals(""))
                condition += " and  Building = '" + textBox_Building.Text.Trim() + "'";

            if (!textBox_Unit.Text.Trim().Equals(""))
                condition += " and  Unit = '" + textBox_Unit.Text.Trim() + "'";

            if (!textBox_ItemNum.Text.Trim().Equals(""))
                condition += " and  ItemNum = '" + textBox_ItemNum.Text.Trim() + "'";

            Search(condition);
        }

        public void Search(string condition)
        {
            button_Search.Enabled = false;

            int bindQty = 0;

            DataTable dtContract = Transaction.GetContractDataEx(condition, out bindQty);

            Transaction.InsertBindCol(dataGridView_Contract, 12, bindQty);

            dataGridView_Contract.AutoGenerateColumns = false;
            dataGridView_Contract.DataSource = dtContract;

            getRowsTotalAmount();

            button_Search.Enabled = true;

            if (dtContract.Rows.Count == 0)
            {
                Prompt.Information("没有符合条件的查询结果 ");
            }
        }

        private void getRowsTotalAmount()
        {
            int countItem = 0;
            double sumArea = 0;
            double sumAmount = 0;


            foreach (DataGridViewRow row in dataGridView_Contract.Rows)
            {
                countItem++;
                sumArea += double.Parse(row.Cells["ColArea"].Value.ToString());
                sumAmount += double.Parse(row.Cells["ColAmount"].Value.ToString());
            }

            textBox_countItem.Text = countItem.ToString();
            textBox_sumArea.Text = sumArea.ToString("F2");
            textBox_sumAmount.Text = sumAmount.ToString("F0");
        }



        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            FrmContractAdd contractAdd = new FrmContractAdd();
            contractAdd.Owner = this;
            contractAdd.ShowDialog();
        }

        private void toolStripButton_Edit_Click(object sender, EventArgs e)
        {
            if (dataGridView_Contract.CurrentRow == null)
            {
                Prompt.Warning("未选择相应的记录！");
                return;
            }

            string contractId = dataGridView_Contract.CurrentRow.Cells["ColContractID"].Value.ToString();

            int iResult = int.Parse(SqlHelper.ExecuteScalar(string.Format("select count(ContractID) from ContractMain where ConfirmDate is not null and ContractID = {0}", contractId)).ToString());
            if (iResult > 0)
            {
                Prompt.Warning("签约已确权，不允许变更！");
                return;
            }

            FrmContractAdd contractAdd = new FrmContractAdd();
            contractAdd.Owner = this;
            contractAdd.FrmMode = FormMode.modify;

            contractAdd.ContractID = contractId;
            if (contractAdd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Search(" and  ContractMain.ContractID = " + dataGridView_Contract.CurrentRow.Cells["ColContractID"].Value.ToString());
                Prompt.Information("操作成功！数据已更新。");
            }
        }

        private void toolStripButton_Rename_Click(object sender, EventArgs e)
        {
            if (dataGridView_Contract.CurrentRow == null)
            {
                Prompt.Warning("未选择相应的记录！");
                return;
            }

            FrmRename rename = new FrmRename();
            rename.AgreementID = dataGridView_Contract.CurrentRow.Cells["ColContractID"].Value.ToString();
            rename.CustomerID = dataGridView_Contract.CurrentRow.Cells["ColCustomerID"].Value.ToString();
            if (rename.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                dataGridView_Contract.CurrentRow.Cells["ColCustomerID"].Value = rename.NewCustomer.CustomerID;
                dataGridView_Contract.CurrentRow.Cells["ColCustomerName"].Value = rename.NewCustomer.CustomerName;
                dataGridView_Contract.CurrentRow.Cells["ColCustomerPhone"].Value = rename.NewCustomer.Phone;
                Prompt.Information("操作成功，数据已更新！");
            }
        }

        private void toolStripButton_Supplment_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 付款方式是否为贷款
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        private bool isCreditMode(string tid, string contractCode)
        {
            bool result = false;

            string sql = string.Format("select PayCode from TransMain where tid = {0} and Contractcode = '{1}'",tid, contractCode);
            object objResult = SqlHelper.ExecuteScalar(sql);
            if (objResult != null)
            {
                if ((objResult.ToString() == "3" ) || (objResult.ToString() == "4"))
                {
                    result = true;
                }
            }
            return result;
        }

        private bool isCredited(string tid)
        {
            bool result = false;

            string sql = "select isnull(count(*),0) from receipt where TypeCode = 4 and tid = " + tid;
            if (int.Parse(SqlHelper.ExecuteScalar(sql).ToString()) > 0)
            {
                result = true;
            }

            return result;
        }

        private void toolStripButton_Append_Click(object sender, EventArgs e)
        {
            if (dataGridView_Contract.CurrentRow == null)
            {
                Prompt.Warning("未选择相应的记录！");
                return;
            }

            FrmAppend append = new FrmAppend();
            append.ContractID = dataGridView_Contract.CurrentRow.Cells["ColContractID"].Value.ToString();
            if (append.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Search("and ContractMain.ContractID = " + dataGridView_Contract.CurrentRow.Cells["ColContractID"].Value.ToString());
                Prompt.Information("操作成功！数据已更新");
            }
        }

        private void toolStripButton_Back_Click(object sender, EventArgs e)
        {
            if (dataGridView_Contract.CurrentRow == null)
            {
                Prompt.Warning("未选择相应的记录！");
                return;
            }

            FrmReturn frmReturn = new FrmReturn();
            string sql = string.Format("select ISNULL(SUM(Amount),0) from Receipt where ContractID = {0}", dataGridView_Contract.CurrentRow.Cells["ColContractID"].Value.ToString());
            frmReturn.ReceiptAmount = string.Format("{0:F0}",SqlHelper.ExecuteScalar(sql));


            if (frmReturn.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (ReturnHouse(frmReturn.IsRefund, frmReturn.ReturnDate, frmReturn.ReturnMemo))
                {
                    dataGridView_Contract.Rows.RemoveAt(dataGridView_Contract.CurrentRow.Index);
                    Prompt.Information("操作成功！");
                }
            }
        }

        private bool ReturnHouse(bool isRefund, string returnDate, string returnMemo)
        {
            bool result = false;

            using (SqlConnection connection = SqlHelper.OpenConnection())  //创建连接对象 
            {
                SqlTransaction sqlTran = connection.BeginTransaction();    //开始事务 
                SqlCommand cmd = connection.CreateCommand();               //创建SqlCommand对象 
                cmd.Transaction = sqlTran;                                 //将SqlCommand与SqlTransaction关联起

                string contractId = dataGridView_Contract.CurrentRow.Cells["ColContractID"].Value.ToString();
                string salesId =  dataGridView_Contract.CurrentRow.Cells["ColSalesID"].Value.ToString();
                string salesName = dataGridView_Contract.CurrentRow.Cells["ColSalesName"].Value.ToString();

                try
                {
                    //更新主表
                    if (isRefund)
                        cmd.CommandText = string.Format("update ContractMain set ReturnDate = '{0}', RefundDate = '{0}', ReturnReason = '{1}' where ContractID = {2}", returnDate, returnMemo, contractId);
                    else
                        cmd.CommandText = string.Format("update ContractMain set ReturnDate = '{0}', ReturnReason = '{1}' where ContractID = {2}", returnDate, returnMemo, contractId);
                    
                    cmd.ExecuteNonQuery();

                    //更新销售状态
                    cmd.CommandText = string.Format("update SaleItem set SaleStateCode = {0}, SaleStateName = '{1}' where ItemID in (select ItemID From ContractDetail where ContractID = {2})", (int)ItemSaleState.待售,ItemSaleState.待售,contractId);
                    cmd.ExecuteNonQuery();

                    string strValues = string.Empty;

                    //退款
                    if (isRefund)
                    {
                        cmd.CommandText = string.Format("select ISNULL(SUM(Amount),0) from Receipt where ContractID = {0}", contractId);
                        string refund = "-" + cmd.ExecuteScalar().ToString();

                        strValues = contractId + "," + Login.User.ProjectID + "," + refund + ",'" + returnDate + "'," + (int)Receivables.退房 + ",'" + Receivables.退房 + "','" + returnMemo + "'," + salesId + ",'" + salesName + "',GETDATE(),'" + Login.User.UserName + "'";
                        cmd.CommandText = string.Format("insert into Receipt (ContractID,ProjectID,Amount,RecDate,TypeCode,TypeName,Memo,SalesID,SalesName,MakeDate,Maker) values ({0})", strValues);
                        cmd.ExecuteNonQuery();
                    }

                    //添加操作记录
                    strValues = contractId + ",'" +OperationType.contract+ "','" + returnDate + "','" + returnMemo + "'," + (isRefund ? "1" : "0") + "," + salesId + ",'" + salesName + "','" + Login.User.UserName + "',GETDATE()";
                    cmd.CommandText = string.Format("insert into ItemReturn (AgreementID,OperationType, ReturnDate,Memo,IsRefund,SalesID, SalesName, MakeUserName,MakeDate) values ({0})", strValues);
                    cmd.ExecuteNonQuery();


                    sqlTran.Commit();  //事务提交
                    connection.Close();

                    result = true;
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();  //异常事务回滚
                    Prompt.Error("操作失败， 错误：" + ex.Message);
                }
            }
            return result;
        }

        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {
            if (dataGridView_Contract.CurrentRow == null)
            {
                Prompt.Warning("未选择相应的记录！");
                return;
            }

            string contractId = dataGridView_Contract.CurrentRow.Cells["ColContractID"].Value.ToString();

            int iResult = Convert.ToInt32(SqlHelper.ExecuteScalar(string.Format("select ISNULL(count(ContractID),0) from receipt where TypeCode != 1 and ContractID = {0}", contractId)));
            if (iResult > 0)
            {
                Prompt.Warning("已存在收款记录，无法删除！");
                return;
            }


            if (MessageBox.Show("确认要删除签约记录？", Common.MsgCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (DelContract(contractId))
                {
                    dataGridView_Contract.Rows.RemoveAt(dataGridView_Contract.CurrentRow.Index);
                    
                    Prompt.Information("操作成功，数据已删除！");
                }
            }


        }

        private bool DelContract(string contractId)
        {
            bool result = false;

            using (SqlConnection connection = SqlHelper.OpenConnection())  //创建连接对象 
            {
                SqlTransaction sqlTran = connection.BeginTransaction();    //开始事务 
                SqlCommand cmd = connection.CreateCommand();               //创建SqlCommand对象 
                cmd.Transaction = sqlTran;                                 //将SqlCommand与SqlTransaction关联起

                try
                {
                    //取消认购引用
                    cmd.CommandText = string.Format("update SubscribeMain set ContractID = null where ContractID = {0}", contractId);
                    cmd.ExecuteNonQuery();

                    //房源重置：销售状态、付款、结算
                    string sql = string.Format("select ItemID,IsBind from ContractDetail where ContractID = {0}", contractId);
                    DataTable dt = SqlHelper.ExecuteDataTable(sql);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string sqlUpdate = string.Empty;

                        sql = string.Format("select COUNT(ItemID) from SubscribeDetail where ItemID = {0}", dt.Rows[i]["ItemID"].ToString());
                        if (int.Parse(SqlHelper.ExecuteScalar(sql).ToString()) > 0) //针对附加的物业直接回到待售状态
                        {
                            sqlUpdate = string.Format("update SaleItem set SaleStateCode = {0}, SaleStateName = '{1}' ", (int)ItemSaleState.认购, ItemSaleState.认购);
                        }
                        else
                        {
                            sqlUpdate = string.Format("update SaleItem set SaleStateCode = {0}, SaleStateName = '{1}' ", (int)ItemSaleState.待售, ItemSaleState.待售);
                        }

                        if (!bool.Parse(dt.Rows[i]["IsBind"].ToString())) 
                        {
                            sqlUpdate += ",PayModeID = null, PayModeName = null, PayTypeCode = null,PayTypeName = null,"
                                + " SettleStandardCode = null,SettleStandardName = null,SettleBaseCode = null,SettleBaseName = null, SettleRate =0 ";
                        }

                        sqlUpdate += string.Format(" where ItemID = {0}", dt.Rows[i]["ItemID"].ToString());

                        cmd.CommandText = sqlUpdate;
                        cmd.ExecuteNonQuery();
                    }



                    //删除房源明细（从表）
                    cmd.CommandText = string.Format("delete ContractDetail where ContractID = {0}", contractId);
                    cmd.ExecuteNonQuery();

                    //删除签约（主表）
                    cmd.CommandText = string.Format("delete ContractMain where ContractID = {0}", contractId);
                    cmd.ExecuteNonQuery();

                    //更新收款（定金）
                    cmd.CommandText = string.Format("update Receipt set ContractID = null where ContractID = {0}", contractId);
                    cmd.ExecuteNonQuery();

                    //删除分期
                    cmd.CommandText = string.Format("delete Installment where ContractID = {0}", contractId);
                    cmd.ExecuteNonQuery();

                    sqlTran.Commit();  //事务提交
                    connection.Close();

                    result = true;
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();  //异常事务回滚
                    Prompt.Error("操作失败， 错误：" + ex.Message);
                }
            }


            return result;

        }

        private void toolStripButton_View_Click(object sender, EventArgs e)
        {
            ViewContract();
        }

        private void ViewContract()
        {
            if (dataGridView_Contract.CurrentRow == null)
            {
                Prompt.Warning("未选择相应的记录！");
                return;
            }

            FrmContractAdd contractAdd = new FrmContractAdd();
            contractAdd.FrmMode = FormMode.view;
            contractAdd.ContractID = dataGridView_Contract.CurrentRow.Cells["ColContractID"].Value.ToString();
            contractAdd.ShowDialog();
        }


        private void toolStripButton_Exchange_Click(object sender, EventArgs e)
        {
            if (dataGridView_Contract.CurrentRow == null)
            {
                Prompt.Warning("未选择相应的记录！");
                return;
            }

            FrmContractAdd contractAdd = new FrmContractAdd();
            contractAdd.FrmMode = FormMode.exchange;
            contractAdd.ContractID = dataGridView_Contract.CurrentRow.Cells["ColContractID"].Value.ToString();
            if (contractAdd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Search("and ContractMain.ContractID = " + contractAdd.ContractID);
                Prompt.Information("操作成功！数据已更新");
            }

        }

        private void toolStripButton_Export_Click(object sender, EventArgs e)
        {
            Common.Exp2XLS(dataGridView_Contract);
        }

        private void dataGridView_Contract_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                ViewContract(); 
        }

    }
}
