using Commission.Business;
using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Commission.Report
{
    public partial class RepReturn : Form
    {
        public RepReturn()
        {
            InitializeComponent();
            InitDefComponent();
        }
        private void InitDefComponent()
        {
            dateTimePicker_Begin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string condition = " and a.ProjectID = " + Login.User.ProjectID
                + " and a.ReturnDate >= '" + dateTimePicker_Begin.Value.ToString("yyyy-MM-dd") + "'"
                + " and a.ReturnDate <= '" + dateTimePicker_End.Value.ToString("yyyy-MM-dd") + "'";
 
            if (!textBox_Building.Text.Trim().Equals(""))
                condition += " and  b.Building = '" + textBox_Building.Text.Trim() + "'";

            if (!textBox_Unit.Text.Trim().Equals(""))
                condition += " and  b.Unit = '" + textBox_Unit.Text.Trim() + "'";

            if (!textBox_ItemNum.Text.Trim().Equals(""))
                condition += " and  b.ItemNum = '" + textBox_ItemNum.Text.Trim() + "'";

            GenDataGridViewBaseStru();

            //基础数据
            DataTable dtListData = GetBaseData(condition);

            int iQuantity = 0;

            //附属房源认购信息
            iQuantity = GetBindData(dtListData, "Subscribe");
            InsertBindCol(dataGridView_List, "SubTotalAmount", iQuantity, "Subscribe");

            //附属房源签约信息
            iQuantity = GetBindData(dtListData, "Contract");
            InsertBindCol(dataGridView_List, "TotalAmount", iQuantity, "Contract");

            //付款信息
            iQuantity = GetReceiptData(dtListData);
            InsertReceiptCol(dataGridView_List, "ReceiptTotalAmt", iQuantity);


            dataGridView_List.DataSource = dtListData;


            if (dataGridView_List.Rows.Count == 0)
                Prompt.Information("没有符合条件的记录！");

        }
        /////////////////

        private void GenDataGridViewBaseStru()
        {
            dataGridView_List.AutoGenerateColumns = false;
            dataGridView_List.DataSource = null;

            string fieldsName = "ContractID,Building,Unit,ItemNum,ItemTypeName,CustomerName,CustomerPhone,SubscribeSalesName,SalesID,SalesName,ReturnDate,RefundDate,ReturnReason,"
               + "SubscribeNum,SubscribeDate,SubArea,SubPrice,SubAmount,SubTotalAmount,"
               + "ContractNum,ContractDate,Area,Price,Amount,TotalAmount,"
               + "PaymentName,DownPayRate,RecDate,ReceiptTotalAmt,NoReceiptTotalAmt,DownPayAmount,DownPayTotal,NoDownPay,Loan";

            string headerText = "ContractID,楼号,单元,房号,房产类型,客户名称,电话,认购置业顾问,SalesID,现置业顾问,退款申请日期,实际退款日期,原因,"
                + "认购编号,认购时间,认购面积,认购单价,认购总价,认购总额,"
                + "签约编号,签约时间,签约面积,签约单价,签约总价,签约总额,"
                + "付款方式,首付比例(%),最后收款日期,付款合计,未付合计,应付首付,已收首付,未收首付,贷款金额";

            string[] arrFieldName = fieldsName.Split(',');
            string[] arrHeadText = headerText.Split(',');

            dataGridView_List.ColumnCount = arrFieldName.Length;

            string fieldName = string.Empty;
            for (int i = 0; i < dataGridView_List.ColumnCount; i++)
            {
                fieldName = arrFieldName[i].ToString();

                dataGridView_List.Columns[i].Name = fieldName;
                dataGridView_List.Columns[i].DataPropertyName = fieldName;
                dataGridView_List.Columns[i].HeaderText = arrHeadText[i].ToString();
            }

            dataGridView_List.Columns["ContractID"].Visible = false;
            dataGridView_List.Columns["SalesID"].Visible = false;


            Common.SetColumnStyle(dataGridView_List.Columns["SubArea"], ColType.area);
            Common.SetColumnStyle(dataGridView_List.Columns["Area"], ColType.area);

            Common.SetColumnStyle(dataGridView_List.Columns["SubPrice"], ColType.price);
            Common.SetColumnStyle(dataGridView_List.Columns["Price"], ColType.price);

            Common.SetColumnStyle(dataGridView_List.Columns["SubAmount"], ColType.amount);
            Common.SetColumnStyle(dataGridView_List.Columns["SubTotalAmount"], ColType.amount);
            Common.SetColumnStyle(dataGridView_List.Columns["Amount"], ColType.amount);
            Common.SetColumnStyle(dataGridView_List.Columns["TotalAmount"], ColType.amount);

            Common.SetColumnStyle(dataGridView_List.Columns["DownPayRate"], ColType.amount);
            Common.SetColumnStyle(dataGridView_List.Columns["DownPayAmount"], ColType.amount);
            Common.SetColumnStyle(dataGridView_List.Columns["DownPayTotal"], ColType.amount);
            Common.SetColumnStyle(dataGridView_List.Columns["NoDownPay"], ColType.amount);
            Common.SetColumnStyle(dataGridView_List.Columns["Loan"], ColType.amount);
            Common.SetColumnStyle(dataGridView_List.Columns["ReceiptTotalAmt"], ColType.amount);
            Common.SetColumnStyle(dataGridView_List.Columns["NoReceiptTotalAmt"], ColType.amount);
        }

        /// <summary>
        /// 获取基础数据(静态字段部分)
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        private DataTable GetBaseData(string condition)
        {
            DataTable dtBase;
            string sql = string.Format("select a.ContractID, c.SubscribeNum, a.ContractNum,a.SubscribeDate, a.ContractDate,a.CustomerName, a.CustomerPhone,a.SubscribeSalesName,a.SalesID,a.SalesName, "
                + " a.PaymentName,a.DownPayRate, a.DownPayAmount,a.Loan,a.TotalAmount,a.ReturnDate, a.RefundDate,a.ReturnReason, "
                + " b.ItemTypeName, b.Building,b.Unit,b.ItemNum, b.Area, b.Price,b.Amount, "
                + " d.Area as SubArea, d.Price as SubPrice, d.Amount as SubAmount, c.TotalAmount as SubTotalAmount "
                + " from ContractMain a "
                + " inner join ContractDetail b on b.ContractID = a.ContractID "
                + " inner join SubscribeMain c on c.ContractID = a.ContractID "
                + " inner join SubscribeDetail d on d.SubscribeID = c.SubscribeID "
                + " where  a.ReturnDate is not null and b.IsBind = 0 and d.IsBind = 0 {0} ", condition);

            dtBase = SqlHelper.ExecuteDataTable(sql);
            dtBase.PrimaryKey = new DataColumn[] { dtBase.Columns["ContractID"] };


            ////付款时间
            sql = "select a.ContractID, CONVERT(VARCHAR(10), MAX(RecDate), 120) as RecDate from ContractMain a left join Receipt b on a.ContractID = b.ContractID group by a.ContractID";
            DataTable dtRecLastDate = SqlHelper.ExecuteDataTable(sql);

            for (int i = 0; i < dtRecLastDate.Rows.Count; i++)
            {
                DataRow[] dr = dtBase.Select("ContractID = " + dtRecLastDate.Rows[i]["ContractID"]);
                if (dr.Length == 0 )
                    dtRecLastDate.Rows[i].Delete();
                
            }
            dtRecLastDate.AcceptChanges();
            dtBase.Merge(dtRecLastDate, false, MissingSchemaAction.Add);


            //已收首付(除贷款）、未收首付
            sql = string.Format("select a.ContractID, isnull(sum(Amount),0) as DownPayTotal,DownPayAmount-IsNull(sum(b.Amount),0) as NoDownPay from ContractMain a  "
                + "inner join receipt b on a.ContractID = b.ContractID  "
                + "where a.ProjectID = {0}  and b.TypeCode != {1} and  b.TypeCode != {2} group by a.ContractID, DownPayAmount", Login.User.ProjectID, (int)Receivables.贷款, (int)Receivables.退房);
            DataTable dtRecTotal = SqlHelper.ExecuteDataTable(sql);

            for (int i = 0; i < dtRecTotal.Rows.Count; i++)
            {
                DataRow[] dr = dtBase.Select("ContractID = " + dtRecTotal.Rows[i]["ContractID"]);
                if (dr.Length == 0)
                    dtRecTotal.Rows[i].Delete();
            }

            dtRecTotal.AcceptChanges();

            dtBase.Merge(dtRecTotal, false, MissingSchemaAction.Add);

            //已收汇总，未收汇总
            sql = string.Format("select a.ContractID, ISNULL(SUM(Amount),0) as ReceiptTotalAmt, (a.TotalAmount - ISNULL(SUM(Amount),0)) as NoReceiptTotalAmt from ContractMain a "
                + " left join Receipt b on b.ContractID = a.ContractID where a.ProjectID = {0} and b.TypeCode != {1}  group by a.ContractID, a.TotalAmount ", Login.User.ProjectID, (int)Receivables.退房);

            DataTable dtNoRec = SqlHelper.ExecuteDataTable(sql);

            for (int i = 0; i < dtNoRec.Rows.Count; i++)
            {
                DataRow[] dr = dtBase.Select("ContractID = " + dtNoRec.Rows[i]["ContractID"]);
                if (dr.Length == 0)
                    dtNoRec.Rows[i].Delete();
            }

            dtNoRec.AcceptChanges();

            dtBase.Merge(dtNoRec, false, MissingSchemaAction.Add);


            return dtBase;
        }

        /// <summary>
        /// 获取绑定房源（一次合并到主表）
        /// </summary>
        /// <param name="dtBase"></param>
        private int GetBindData(DataTable dtBase, string agreement)
        {
            int colQuantity = 0;

            string sql = string.Empty;
            string contractId = string.Empty;

            string prefix = string.Empty;
            string tableName = string.Empty;
            if (agreement.Equals("Subscribe"))
            {
                prefix = "Sub_Bind_";
                sql = "select ItemNum, Area, Price, Amount from SubscribeMain a inner join SubscribeDetail b on b.SubscribeID = a.SubscribeID  where IsBind = 1 and a.ContractID = ";
            }
            if (agreement.Equals("Contract"))
            {
                prefix = "Con_Bind_";
                sql = "select ItemNum, Area, Price, Amount from ContractDetail where IsBind = 1 and ContractID = ";
            }

            DataTable dtBind = new DataTable();
            dtBind.Columns.Add("ContractID", typeof(int));

            dtBase.PrimaryKey = new DataColumn[] { dtBase.Columns["ContractID"] };
            for (int i = 0; i < dtBase.Rows.Count; i++)
            {
                contractId = dtBase.Rows[i]["ContractID"].ToString();

                DataTable dtResult = SqlHelper.ExecuteDataTable(sql + contractId);

                //创建列，大于当前列则创建
                if (dtResult.Rows.Count > colQuantity)
                {
                    for (int j = colQuantity; j < dtResult.Rows.Count; j++)
                    {
                        for (int n = 0; n < dtResult.Columns.Count; n++)
                        {
                            string colName = prefix + dtResult.Columns[n].ColumnName + j;
                            dtBind.Columns.Add(colName, dtResult.Columns[n].DataType);
                        }
                    }
                    colQuantity = dtResult.Rows.Count;
                }

                //创建行并赋值
                if (dtResult.Rows.Count > 0)
                {
                    DataRow row = dtBind.NewRow();
                    row["ContractID"] = contractId;

                    for (int m = 0; m < dtResult.Rows.Count; m++)
                    {
                        for (int n = 0; n < dtResult.Columns.Count; n++)
                        {
                            string colName = prefix + dtResult.Columns[n].ColumnName + m;
                            row[colName] = dtResult.Rows[m][n];
                        }
                    }
                    dtBind.Rows.Add(row);
                }
            }

            if (dtBind.Rows.Count > 0)
                dtBase.Merge(dtBind, false, MissingSchemaAction.Add); //合并至主体表

            return colQuantity;
        }



        /// <summary>
        /// 动态插入绑定房源列
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="colName"></param>
        /// <param name="iColQuantity"></param>
        /// <param name="agreement"></param>
        private void InsertBindCol(DataGridView dgv, string colName, int iColQuantity, string agreement)
        {
            if (iColQuantity <= 0)
                return;

            string prefix = string.Empty;
            if (agreement.Equals("Subscribe"))
            {
                prefix = "Sub_Bind_";
            }
            if (agreement.Equals("Contract"))
            {
                prefix = "Con_Bind_";
            }

            int iBeginPos = dgv.Columns[colName].Index;

            //增加BIND字段
            for (int i = 0; i < iColQuantity; i++)
            {
                //房号
                string sItemNum = prefix + "ItemNum" + i.ToString();

                DataGridViewTextBoxColumn itemNum = new DataGridViewTextBoxColumn();
                itemNum.Name = sItemNum;
                itemNum.DataPropertyName = sItemNum;
                itemNum.HeaderText = "储藏间号" + i.ToString();
                dgv.Columns.Insert(iBeginPos++, itemNum);


                //面积
                string sArea = prefix + "Area" + i.ToString();

                DataGridViewTextBoxColumn area = new DataGridViewTextBoxColumn();
                area.Name = sArea;
                area.DataPropertyName = sArea;
                area.HeaderText = "面积" + i.ToString();
                area.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                area.DefaultCellStyle.Format = "F2";
                dgv.Columns.Insert(iBeginPos++, area);


                //单价
                string sPrice = prefix + "Price" + i.ToString();

                DataGridViewTextBoxColumn price = new DataGridViewTextBoxColumn();
                price.Name = sPrice;
                price.DataPropertyName = sPrice;
                price.HeaderText = "单价" + i.ToString();
                price.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                price.DefaultCellStyle.Format = "F4";
                dgv.Columns.Insert(iBeginPos++, price);


                //金额
                string sAmount = prefix + "Amount" + i.ToString();

                DataGridViewTextBoxColumn amount = new DataGridViewTextBoxColumn();
                amount.Name = sAmount;
                amount.DataPropertyName = sAmount;
                amount.HeaderText = "金额" + i.ToString();
                amount.DefaultCellStyle.Format = "F0";
                amount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Columns.Insert(iBeginPos++, amount);
            }
        }

        /// <summary>
        /// 获取收款数据
        /// </summary>
        /// <param name="dtBase"></param>
        /// <returns></returns>
        private int GetReceiptData(DataTable dtBase)
        {
            int iQuantity = 0;

            string sql = string.Empty;

            for (int i = 0; i < dtBase.Rows.Count; i++)
            {
                string contractId = dtBase.Rows[i]["ContractID"].ToString();

                sql = string.Format("select RecDate, Amount from Receipt where ContractID = {0} and TypeCode != {1} order by RecDate ", contractId, (int)Receivables.退房);

                DataTable dtReceipt = SqlHelper.ExecuteDataTable(sql);

                if (dtReceipt.Rows.Count > 0)
                {
                    if (dtReceipt.Rows.Count > iQuantity)
                        iQuantity = dtReceipt.Rows.Count;

                    DataTable dt = new DataTable();

                    dt.Columns.Add("ContractID", typeof(int));
                    dt.PrimaryKey = new DataColumn[] { dt.Columns["ContractID"] };

                    string fieldValue = contractId;

                    for (int rowIdx = 0; rowIdx < dtReceipt.Rows.Count; rowIdx++)
                    {
                        for (int colIdx = 0; colIdx < dtReceipt.Columns.Count; colIdx++)
                        {
                            string fieldName = "Rec_" + dtReceipt.Columns[colIdx].ColumnName + rowIdx;

                            dt.Columns.Add(fieldName, dtReceipt.Columns[colIdx].DataType);

                            fieldValue += "," + dtReceipt.Rows[rowIdx][colIdx].ToString();
                        }
                    }
                    string[] strArray = fieldValue.Split(',');

                    dt.Rows.Add(strArray);

                    dtBase.Merge(dt, false, MissingSchemaAction.Add); //合并至主体表
                }
            }

            return iQuantity;
        }

        private void InsertReceiptCol(DataGridView dgv, string colName, int iColQuantity)
        {
            if (iColQuantity <= 0)
                return;

            int iBeginPos = dgv.Columns[colName].Index;

            string prefix = "Rec_";

            //增加收款字段
            for (int i = 0; i < iColQuantity; i++)
            {
                //房号
                string sItemNum = prefix + "RecDate" + i.ToString();

                DataGridViewTextBoxColumn itemNum = new DataGridViewTextBoxColumn();
                itemNum.Name = sItemNum;
                itemNum.DataPropertyName = sItemNum;
                itemNum.HeaderText = "收款日期" + i.ToString();
                dgv.Columns.Insert(iBeginPos++, itemNum);

                //金额
                string sAmount = prefix + "Amount" + i.ToString();

                DataGridViewTextBoxColumn amount = new DataGridViewTextBoxColumn();
                amount.Name = sAmount;
                amount.DataPropertyName = sAmount;
                amount.HeaderText = "金额" + i.ToString();
                amount.DefaultCellStyle.Format = "F0";
                amount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Columns.Insert(iBeginPos++, amount);
            }
        }





        private void GetReturnData()
        {

        }

        //-/////////////////////////////////

        private void button_Export_Click(object sender, EventArgs e)
        {
            //Common.Exp2XLS(dataGridView_Contract);
        }

        private void toolStripButton_Refund_Click(object sender, EventArgs e)
        {
            if (dataGridView_List.CurrentRow == null)
            {
                Prompt.Warning("未选择记录！");
                return;
            }

            string refundDate = dataGridView_List.CurrentRow.Cells["RefundDate"].Value.ToString();
            if (!refundDate.Equals(""))
            {
                Prompt.Warning("指定记录已退款！");
                return;
            }

            string recTotalAmount = dataGridView_List.CurrentRow.Cells["ReceiptTotalAmt"].Value.ToString();

            if (recTotalAmount.Equals("0"))
            {
                Prompt.Warning("无收款记录！");
                return;
            }

            if (MessageBox.Show("确定要进行退款？", Common.MsgCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string contractId = dataGridView_List.CurrentRow.Cells["ContractID"].Value.ToString();
                string salesId = dataGridView_List.CurrentRow.Cells["SalesID"].Value.ToString();
                string salesName = dataGridView_List.CurrentRow.Cells["SalesName"].Value.ToString();
                string refund = "-" + recTotalAmount;

                using (SqlConnection connection = SqlHelper.OpenConnection())
                {
                    SqlTransaction sqlTran = connection.BeginTransaction();
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.Transaction = sqlTran;

                    try
                    {
                        string srvDate = SqlHelper.ExecuteScalar(string.Format("select Convert(varchar(10),GETDATE(),120)")).ToString();

                        cmd.CommandText = string.Format("update ContractMain set RefundDate = '{0}' where ContractID = {1}", srvDate, contractId);
                        cmd.ExecuteNonQuery();

                        string strValues = contractId + "," + Login.User.ProjectID + "," + refund + ",'" + srvDate + "'," + (int)Receivables.退房 + ",'" + Receivables.退房 + "','" + Receivables.退房 + "'," + salesId + ",'" + salesName + "',GETDATE(),'" + Login.User.UserName + "'";
                        cmd.CommandText = string.Format("insert into Receipt (ContractID,ProjectID,Amount,RecDate,TypeCode,TypeName,Memo,SalesID,SalesName,MakeDate,Maker) values ({0})", strValues);
                        cmd.ExecuteNonQuery();

                        dataGridView_List.CurrentRow.Cells["RefundDate"].Value = srvDate;
                        Prompt.Information("操作成功！已退款。");

                        sqlTran.Commit();
                    }
                    catch (Exception ex)
                    {
                        sqlTran.Rollback();
                        Prompt.Error("操作失败， 错误信息：" + ex.Message);
                    }

                }
            }
        }

        private void RepReturn_Load(object sender, EventArgs e)
        {
            Common.SetFirstOfMonth(dateTimePicker_Begin);
            Common.SetEndOfMonth(dateTimePicker_End);
        }
    }
}
