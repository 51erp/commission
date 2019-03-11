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
    public partial class FrmReceipt : Form
    {
        public FrmReceipt()
        {
            InitializeComponent();
            InitDefComponent();
        }

        private void InitDefComponent()
        {
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
                condition += " and  (CustomerPhone like '%" + textBox_Phone.Text.Trim() + "%')";

            if (!textBox_Building.Text.Trim().Equals(""))
                condition += " and  Building = '" + textBox_Building.Text.Trim() + "'";

            if (!textBox_Unit.Text.Trim().Equals(""))
                condition += " and  Unit = '" + textBox_Unit.Text.Trim() + "'";

            if (!textBox_ItemNum.Text.Trim().Equals(""))
                condition += " and  ItemNum = '" + textBox_ItemNum.Text.Trim() + "'";

            Search(condition);
        }


        private void Search(string condition)
        {
            button_Search.Enabled = false;

            dataGridView_Agreement.AutoGenerateColumns = false;
            dataGridView_Agreement.DataSource = null;

            int conBindQty = 0;
            DataTable dtContract = GetContractData(condition, out conBindQty);

            int subBindQty = 0;
            DataTable dtSubscribe = GetSubscribeData(condition, out subBindQty);

            dtContract.PrimaryKey = null;

            dtContract.Merge(dtSubscribe, false, MissingSchemaAction.Add);

            int Qty = 0;
            if (conBindQty > subBindQty)
            {
                Qty = conBindQty;
            }
            else
            {
                Qty = subBindQty;
            }

            Transaction.InsertBindCol(dataGridView_Agreement, 14, Qty);

            dataGridView_Agreement.DataSource = dtContract;

            button_Search.Enabled = true;

            if (dtContract.Rows.Count == 0)
            {
                Prompt.Information("没有符合条件的查询结果 ");
            }

        }

        private DataTable GetSubscribeData(string condition, out int iBindQuantity)
        {
            iBindQuantity = 0;
            string sql = string.Empty;

            //主体表
            sql = "select IsNull(a.ContractID,0) as ContractID ,a.SubscribeID, SubscribeNum as AgreementNum, CustomerName,CustomerPhone, '认购' as AgreementType,SubscribeDate, " 
                + " ItemTypeName, Building, Unit, ItemNum, Area, Price, Amount, "
                + " TotalAmount, cast('0' as money) as DownPayAmount, cast('0' as money) as Loan, SalesID, SalesName,"
                + " ExtField0, ExtField1, ExtField2, ExtField3, ExtField4, ExtField5, ExtField6, ExtField7, ExtField8, ExtField9 "
                + " from SubscribeMain a"
                + " inner join  SubscribeDetail b on a.SubscribeID = b.SubscribeID "
                + " where ReturnDate is null and ContractID is null and ProjectID = " + Login.User.ProjectID + " and  IsBind = 0 " + condition
                + " order by a.SubscribeID ";

            DataTable dtSubscribe = SqlHelper.ExecuteDataTable(sql);
            dtSubscribe.PrimaryKey = new DataColumn[] { dtSubscribe.Columns["SubscribeID"] };

            //已收首付(除贷款） 、 未收首付
            sql = string.Format("select a.SubscribeID, isnull(sum(Amount),0) as DownPayTotal, cast('0' as money) as NoDownPay from SubscribeMain a  "
                + "inner join receipt b on a.SubscribeID = b.SubscribeID  "
                + "where b.ContractID is null and a.ProjectID = {0} group by a.SubscribeID", Login.User.ProjectID);
            DataTable dtRecTotal = SqlHelper.ExecuteDataTable(sql);

            for (int i = 0; i < dtRecTotal.Rows.Count; i++)
            {
                DataRow[] dr = dtSubscribe.Select("SubscribeID = " + dtRecTotal.Rows[i]["SubscribeID"]);
                if (dr.Length == 0)
                    dtRecTotal.Rows[i].Delete();
            }
            dtRecTotal.AcceptChanges();

            dtSubscribe.Merge(dtRecTotal, false, MissingSchemaAction.Add);


            // 获取绑定（附属）物业信息
            for (int i = 0; i < dtSubscribe.Rows.Count; i++)
            {
                string subscribeId = dtSubscribe.Rows[i]["SubscribeID"].ToString();

                //绑定房源信息
                sql = "select ItemNum, Area, Price, Amount from SubscribeDetail where IsBind = 1 and SubscribeID = " + subscribeId;

                SqlDataReader dr = SqlHelper.ExecuteReader(sql);

                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();

                    dt.Columns.Add("SubscribeID", typeof(int));
                    dt.PrimaryKey = new DataColumn[] { dt.Columns["SubscribeID"] };

                    string fieldValue = subscribeId;

                    int itemIdx = 0;     //一个房源相同尾号
                    while (dr.Read())
                    {
                        for (int j = 0; j < dr.FieldCount; j++)
                        {
                            string fieldName = "BIND_" + dr.GetName(j) + itemIdx;
                            dt.Columns.Add(fieldName, typeof(string));
                            if (dr.GetName(j).Equals("Amount"))
                            {
                                fieldValue += "," + string.Format("{0:F0}", dr.GetValue(j));
                            }
                            else
                            {
                                fieldValue += "," + dr.GetValue(j).ToString();
                            }
                        }

                        itemIdx++;

                        if (itemIdx > iBindQuantity)
                            iBindQuantity = itemIdx;
                    }

                    dr.Close();

                    string[] strArray = fieldValue.Split(',');

                    dt.Rows.Add(strArray);

                    dtSubscribe.Merge(dt, false, MissingSchemaAction.Add); //合并至主体表
                }
            }


            return dtSubscribe;
        }


        private DataTable GetContractData(string condition, out int iBindQuantity)
        {
            iBindQuantity = 0;
            string sql = string.Empty;

            //主体表
            sql = "select a.ContractID, a.SubscribeID, ContractNum as AgreementNum, CustomerName,CustomerPhone, '签约' as AgreementType, SubscribeDate, ContractDate,"
                + " ItemTypeName, Building, Unit, ItemNum, Area, Price, Amount, "
                + " TotalAmount, DownPayAmount, Loan, SalesID, SalesName,"
                + " ExtField0, ExtField1, ExtField2, ExtField3, ExtField4, ExtField5, ExtField6, ExtField7, ExtField8, ExtField9 "
                + " from ContractMain a"
                + " inner join  ContractDetail b on a.ContractID = b.ContractID "
                + " where ReturnDate is null and ProjectID = " + Login.User.ProjectID + " and  IsBind = 0 " + condition
                + " order by a.ContractID ";

            DataTable dtContract = SqlHelper.ExecuteDataTable(sql); 
            dtContract.PrimaryKey = new DataColumn[] { dtContract.Columns["ContractID"] };


            //已收首付(除贷款） 、 未收首付
            sql = string.Format("select a.ContractID, isnull(sum(Amount),0) as DownPayTotal,DownPayAmount-IsNull(sum(b.Amount),0) as NoDownPay from ContractMain a  "
                + "inner join receipt b on a.ContractID = b.ContractID  "
                + "where a.ProjectID = {0}  and b.TypeCode != 0 group by a.ContractID, DownPayAmount", Login.User.ProjectID);
            DataTable dtRecTotal = SqlHelper.ExecuteDataTable(sql);

            for (int i = 0; i < dtRecTotal.Rows.Count; i++)
            {
                DataRow[] dr = dtContract.Select("ContractID = " + dtRecTotal.Rows[i]["ContractID"]);
                if (dr.Length == 0)
                    dtRecTotal.Rows[i].Delete();
            }
            dtRecTotal.AcceptChanges();

            dtContract.Merge(dtRecTotal, false, MissingSchemaAction.Add);

            // 获取绑定（附属）物业信息
            for (int i = 0; i < dtContract.Rows.Count; i++)
            {
                string contractId = dtContract.Rows[i]["ContractID"].ToString();

                //绑定房源信息
                sql = "select ItemNum, Area, Price, Amount from ContractDetail where IsBind = 1 and ContractID = " + contractId;

                SqlDataReader dr = SqlHelper.ExecuteReader(sql);

                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();

                    dt.Columns.Add("ContractID", typeof(int));
                    dt.PrimaryKey = new DataColumn[] { dt.Columns["ContractID"] };

                    string fieldValue = contractId;

                    int itemIdx = 0;     //一个房源相同尾号
                    while (dr.Read())
                    {
                        for (int j = 0; j < dr.FieldCount; j++)
                        {
                            string fieldName = "BIND_" + dr.GetName(j) + itemIdx;
                            dt.Columns.Add(fieldName, typeof(string));
                            if (dr.GetName(j).Equals("Amount"))
                            {
                                fieldValue += "," + string.Format("{0:F0}",dr.GetValue(j));
                            }
                            else
                            {
                                fieldValue += "," + dr.GetValue(j).ToString();
                            }
                        }

                        itemIdx++;

                        if (itemIdx > iBindQuantity)
                            iBindQuantity = itemIdx;
                    }

                    dr.Close();

                    string[] strArray = fieldValue.Split(',');

                    dt.Rows.Add(strArray);

                    dtContract.Merge(dt, false, MissingSchemaAction.Add); //合并至主体表
                }
            }

            return dtContract;
        }



        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            if (dataGridView_Agreement.CurrentRow == null)
            {
                Prompt.Information("未选择相关签约信息");
                return;
            }

            FrmReceiptAdd receipt = new FrmReceiptAdd();

            string agreementId = string.Empty;
            string agreementType = dataGridView_Agreement.CurrentRow.Cells["ColAgreementType"].Value.ToString();

            receipt.AgreementType = agreementType;

            if (agreementType.Equals("签约"))
            {
                agreementId = dataGridView_Agreement.CurrentRow.Cells["ColcontractID"].Value.ToString();
            }
            else
            {
                agreementId = dataGridView_Agreement.CurrentRow.Cells["ColSubscribeID"].Value.ToString();
            }
            
            receipt.SalesID = dataGridView_Agreement.CurrentRow.Cells["ColSalesID"].Value.ToString();
            receipt.SalesName = dataGridView_Agreement.CurrentRow.Cells["ColSalesName"].Value.ToString();
            receipt.AgreementID = agreementId;

            if (receipt.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                getReceiptRecord(dataGridView_Agreement.CurrentRow.Cells["ColcontractID"].Value.ToString(), true);  

                if (agreementType.Equals("签约"))
                {
                    getReceiptRecord(agreementId, true);
                    UpdateReceiptGridDataView(dataGridView_Agreement.CurrentRow, true);
                    SetReceiptInfo(dataGridView_Agreement.CurrentRow, true);
                }
                else
                {
                    getReceiptRecord(agreementId, false);
                    UpdateReceiptGridDataView(dataGridView_Agreement.CurrentRow, false);
                    SetReceiptInfo(dataGridView_Agreement.CurrentRow, false);
                }

                Prompt.Information("操作成功，信息已添加！");
            }

        }

        /// <summary>
        /// 获取指定签约ID的全部收款记录
        /// </summary>
        /// <param name="id"></param>
        private void getReceiptRecord(string id, bool isContract)
        {
            string sql = string.Empty;

            if (!string.IsNullOrEmpty(id))
            {
                if (isContract)
                {
                    sql = "select ID, Source, Amount,RecDate,TypeCode,TypeName,case SettleState WHEN '0' THEN '否' ELSE  '是' END SettleState,Memo,SalesName, Maker from receipt where ContractID = " + id + " order by ID";
                }
                else
                {
                    sql = "select ID, Source, Amount,RecDate,TypeCode,TypeName,case SettleState WHEN '0' THEN '否' ELSE  '是' END SettleState,Memo,SalesName, Maker from receipt where SubscribeID = " + id + " order by ID";
                }

                dataGridView_Receipt.DataSource = SqlHelper.ExecuteDataTable(sql);
            }
        }

        /// <summary>
        /// 获取指定签约ID的已收首付金额
        /// </summary>
        /// <param name="contractId"></param>
        /// <returns></returns>
        private string  getReceiptDownPay(string contractId)
        {
            string sql = "select isnull(sum(Amount),0) as Amount from receipt where IsLoan = 0 and ContractID = " + contractId;
            return SqlHelper.ExecuteScalar(sql).ToString();
        }

        /// <summary>
        /// 款项信息－标题文字
        /// </summary>
        /// <param name="row"></param>
        private void SetReceiptInfo(DataGridViewRow row, bool isContract)
        {
            string sql = string.Empty;
            if (row == null)
            {
                label_ReceiptTotal.Text = "0.00";
                label_TotalAmount.Text = "0.00";
                label_Loan.Text = "0.00";
                label_DownPay.Text = "0.00";
                label_DownPayed.Text = "0.00";
                label_NoDownPay.Text = "0.00";
            }
            else
            {
                if (isContract)
                {
                    sql = string.Format("select isnull(sum(Amount),0) as Amount from receipt where ContractID = {0}", row.Cells["ColContractID"].Value.ToString());
                }
                else
                {
                    sql = string.Format("select isnull(sum(Amount),0) as Amount from receipt where SubscribeID = {0}", row.Cells["ColSubscribeID"].Value.ToString());
                }
                label_ReceiptTotal.Text = string.Format("{0:F2}",SqlHelper.ExecuteScalar(sql)); //全部收款金额，含贷款

                label_TotalAmount.Text = string.Format("{0:F2}", row.Cells["ColTotalAmount"].Value);
                label_Loan.Text = string.Format("{0:F2}", row.Cells["ColLoan"].Value);
                label_DownPay.Text = string.Format("{0:F2}", row.Cells["ColDownPayAmount"].Value);
                label_DownPayed.Text = string.Format("{0:F2}", row.Cells["ColDownPayTotal"].Value);
                label_NoDownPay.Text = string.Format("{0:F2}", row.Cells["ColNoDownPay"].Value);
            }
        }

        /// <summary>
        /// 更新DataGridView中的列数据
        /// </summary>
        /// <param name="row"></param>
        private void UpdateReceiptGridDataView(DataGridViewRow row, bool isContract)
        {
            string sql = string.Empty;
            
            //已收首付
            if (isContract)
            {
                sql = "select isnull(sum(Amount),0) as Amount from receipt where TypeCode != 0 and ContractID = " + row.Cells["ColContractID"].Value.ToString();
                row.Cells["ColDownPayTotal"].Value = string.Format("{0:F0}", SqlHelper.ExecuteScalar(sql).ToString());
                //未收首付
                row.Cells["ColNoDownPay"].Value = int.Parse(row.Cells["ColDownPayAmount"].FormattedValue.ToString()) - int.Parse(row.Cells["ColDownPayTotal"].FormattedValue.ToString());
            }
            else
            {
                sql = "select isnull(sum(Amount),0) as Amount from receipt where TypeCode != 0 and SubscribeID = " + row.Cells["ColSubscribeID"].Value.ToString();
                row.Cells["ColDownPayTotal"].Value = string.Format("{0:F0}", SqlHelper.ExecuteScalar(sql).ToString());
            }
        }


        private void dataGridView_Agreement_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_Agreement.CurrentRow == null)
            {
                return;
            }

            if (dataGridView_Agreement.CurrentRow.Cells["ColAgreementType"].Value.ToString().Equals("签约"))
            {
                string contractId = dataGridView_Agreement.CurrentRow.Cells["ColContractID"].Value.ToString();

                //全部收款记录
                getReceiptRecord(contractId, true);

                //款项信息-标题
                SetReceiptInfo(dataGridView_Agreement.CurrentRow, true);

                //分期信息
                dataGridView_Installment.DataSource = SqlHelper.ExecuteDataTable(string.Format("select Sequence, Amount, PayDate,Settled  from Installment where ContractID = {0} order by Sequence ", contractId));
            }
            else
            {
                string subscribeId = dataGridView_Agreement.CurrentRow.Cells["ColSubscribeID"].Value.ToString();

                getReceiptRecord(subscribeId, false);

                SetReceiptInfo(dataGridView_Agreement.CurrentRow, false);
            }

            
        }

        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {
            if (dataGridView_Receipt.CurrentRow == null)
            {
                Prompt.Warning("没有选择信息！");
                return;
            }

            if (dataGridView_Receipt.CurrentRow.Cells["ColSource"].Value.ToString() == "0")
            {
                Prompt.Warning("业务单据生成的收款，不能删除！");
                return;
            }

            if (dataGridView_Receipt.CurrentRow.Cells["ColSettleState"].Value.ToString() == "是")
            {
                Prompt.Warning("已结算记录，不能删除！");
                return;
            }



            if (MessageBox.Show("确定要删除选择的信息？", "房地产佣金结算系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string id = dataGridView_Receipt.CurrentRow.Cells["ColRecID"].Value.ToString();

                SqlHelper.ExecuteNonQuery("delete Receipt where ID = " + id);

                dataGridView_Receipt.Rows.Remove(dataGridView_Receipt.CurrentRow);

                
                if (dataGridView_Agreement.CurrentRow.Cells["ColAgreementType"].Value.ToString().Equals("签约"))
                {
                    UpdateReceiptGridDataView(dataGridView_Agreement.CurrentRow, true);
                    SetReceiptInfo(dataGridView_Agreement.CurrentRow, true);
                }
                else
                {
                    UpdateReceiptGridDataView(dataGridView_Agreement.CurrentRow,false);
                    SetReceiptInfo(dataGridView_Agreement.CurrentRow, false);
                }

                Prompt.Information("操作成功，信息已删除！");
            }
        }

        private void toolStripButton_Edit_Click(object sender, EventArgs e)
        {
            if (dataGridView_Receipt.CurrentRow == null)
            {
                Prompt.Warning("没有选择信息！");
                return;
            }

            if (dataGridView_Receipt.CurrentRow.Cells["ColSource"].Value.ToString() == "0")
            {
                Prompt.Warning("业务单据生成的收款，不能修改！");
                return;
            }


            if (dataGridView_Receipt.CurrentRow.Cells["ColSettleState"].Value.ToString() == "是")
            {
                Prompt.Warning("已结算记录，不能修改！");
                return;
            }



            FrmReceiptAdd receipt = new FrmReceiptAdd();

            string agreementId = string.Empty;
            string agreementType = dataGridView_Agreement.CurrentRow.Cells["ColAgreementType"].Value.ToString();

            if (agreementType.Equals("签约"))
            {
                agreementId = dataGridView_Agreement.CurrentRow.Cells["ColcontractID"].Value.ToString();
            }
            else
            {
                agreementId = dataGridView_Agreement.CurrentRow.Cells["ColSubscribeID"].Value.ToString();
            }

            receipt.Owner = this;
            receipt.FrmMode = FormMode.modify;
            receipt.ReceiptID = dataGridView_Receipt.CurrentRow.Cells["ColRecID"].Value.ToString();
            receipt.AgreementID = agreementId;
            receipt.AgreementType = agreementType;

            if (receipt.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (dataGridView_Agreement.CurrentRow.Cells["ColAgreementType"].Value.ToString().Equals("签约"))
                {
                    getReceiptRecord(agreementId, true);
                    UpdateReceiptGridDataView(dataGridView_Agreement.CurrentRow,true);
                    SetReceiptInfo(dataGridView_Agreement.CurrentRow, true);
                }
                else
                {
                    getReceiptRecord(agreementId, false);
                    UpdateReceiptGridDataView(dataGridView_Agreement.CurrentRow,false);
                    SetReceiptInfo(dataGridView_Agreement.CurrentRow, false);
                }

                Prompt.Information("操作成功，数据已更新!");
            }
        }

    }
}
