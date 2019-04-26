using Commission.Business;
using Commission.DataAccess;
using Commission.Utility;
using System;
using System.Collections;
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
    public partial class RepList : Form
    {

        public RepList()
        {
            InitializeComponent();
            //GenDataGridViewBaseStru();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void useTime(DateTime beginTime)
        {
            DateTime end = DateTime.Now;
            TimeSpan ts = end.Subtract(beginTime);
            Console.WriteLine("Time:" + ts.ToString("G"));
        }

 
        private void button_Search_Click(object sender, EventArgs e)
        {
            //基础结构
            GenDataGridViewBaseStru();

            //签约基础数据
            DataTable dtListData = GetBaseData(GetCondition());

            int conQty = GetBindData(dtListData, "Subscribe");

            //认购基础数据
            DataTable dtSubscribe = GetSubscribeData(GetSubscribeCondition());
            
            int subQty = GetSubscribeBindData(dtSubscribe);

            int iQuantity = 0;
            iQuantity = conQty >= subQty ? conQty : subQty;
               
            InsertBindCol(dataGridView_List, "SubTotalAmount", iQuantity, "Subscribe");


            //签约附属房源
            iQuantity = GetBindData(dtListData, "Contract");
            InsertBindCol(dataGridView_List, "TotalAmount", iQuantity, "Contract");

            //付款信息
            iQuantity = GetReceiptData(dtListData);
            InsertReceiptCol(dataGridView_List, "ReceiptTotalAmt", iQuantity);

            dtListData.PrimaryKey = null;
            dtSubscribe.PrimaryKey = null;

            dtListData.Merge(dtSubscribe, false, MissingSchemaAction.Add);

            dataGridView_List.DataSource = dtListData;

            GetRowsTotalAmount();

            if (dataGridView_List.Rows.Count == 0)
                Prompt.Information("没有符合条件的记录！");
        }

        private void GenDataGridViewBaseStru()
        {
            dataGridView_List.AutoGenerateColumns = false;
            dataGridView_List.DataSource = null;

            string fieldsName = "ContractID,SubscribeID,Building,Unit,ItemNum,ItemTypeName,SaleState,CustomerName,CustomerPhone,SubscribeSalesName,SalesName,"
               + "SubscribeNum,SubscribeDate,SubArea,SubPrice,SubAmount,SubTotalAmount,"
               + "ContractNum,ContractDate,Area,Price,Amount,TotalAmount,"
               + "PaymentName,DownPayRate,RecDate,ReceiptTotalAmt,NoReceiptTotalAmt,DownPayAmount,DownPayTotal,NoDownPay,Loan,LoanDate,"
               + "ExtField0,ExtField1,ExtField2,ExtField3,ExtField4,ExtField5,ExtField6,ExtField7,ExtField8,ExtField9";

            string headerText = "ContractID,SubscribeID,楼号,单元,房号,房产类型,销售状态,客户名称,电话,认购置业顾问,现置业顾问,"
                + "认购编号,认购时间,认购面积,认购单价,认购总价,认购总额,"
                + "签约编号,签约时间,签约面积,签约单价,签约总价,签约总额,"
                + "付款方式,首付比例(%),最后收款日期,已收总额,未收总额,应付首付,已收首付,未收首付,贷款金额,放贷日期,"
                + "备注0,备注1,备注2,备注3,备注4,备注5,备注6,备注7,备注8,备注9";


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
            dataGridView_List.Columns["SubscribeID"].Visible = false;


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

            dataGridView_List.Columns["ItemNum"].Frozen = true;
        }

        private string GetSubscribeCondition()
        {
            string condition = " a.ProjectID  = " + Login.User.ProjectID;

            if (!textBox_CusName.Text.Trim().Equals(""))
                condition += " and  a.CustomerName Like '%" + textBox_CusName.Text.Trim() + "%'";

            if (!textBox_Building.Text.Trim().Equals(""))
                condition += " and  b.Building = '" + textBox_Building.Text.Trim() + "'";

            if (!textBox_Unit.Text.Trim().Equals(""))
                condition += " and  b.Unit = '" + textBox_Unit.Text.Trim() + "'";

            if (!textBox_ItemNum.Text.Trim().Equals(""))
                condition += " and  b.ItemNum = '" + textBox_ItemNum.Text.Trim() + "'";


            //认购条件
            if (!textBox_SubCode.Text.Trim().Equals(""))
                condition += " and  a.ContractNum = '" + textBox_SubCode.Text.Trim() + "'";

            if (dateTimePicker_SubBegin.Checked)
                condition += " and a.SubscribeDate >= '" + dateTimePicker_SubBegin.Value.ToString("yyyy-MM-dd") + "'";

            if (dateTimePicker_SubEnd.Checked)
                condition += " and a.SubscribeDate <= '" + dateTimePicker_SubEnd.Value.ToString("yyyy-MM-dd") + "'";


            //签约条件
            if (!textBox_ConCode.Text.Trim().Equals(""))
                condition = "1 = 2";

            if (dateTimePicker_ConBegin.Checked)
                condition = "1 = 2";

            if (dateTimePicker_ConEnd.Checked)
                condition = "1 = 2";

            //放贷时间
            if (dateTimePicker_LoanBegin.Checked)
                condition = "1 = 2";

            if (dateTimePicker_LoanEnd.Checked)
                condition = "1 = 2";


            return condition;
        }

        private string GetCondition()
        {
            string condition = " a.ProjectID  = " + Login.User.ProjectID;

            if (!textBox_CusName.Text.Trim().Equals(""))
                condition += " and  a.CustomerName Like '%" + textBox_CusName.Text.Trim() + "%'";

            if (!textBox_Building.Text.Trim().Equals(""))
                condition += " and  b.Building = '" + textBox_Building.Text.Trim() + "'";

            if (!textBox_Unit.Text.Trim().Equals(""))
                condition += " and  b.Unit = '" + textBox_Unit.Text.Trim() + "'";

            if (!textBox_ItemNum.Text.Trim().Equals(""))
                condition += " and  b.ItemNum = '" + textBox_ItemNum.Text.Trim() + "'";


            //认购条件
            if (!textBox_SubCode.Text.Trim().Equals(""))
                condition += " and  c.ContractNum = '" + textBox_SubCode.Text.Trim() + "'";

            if (dateTimePicker_SubBegin.Checked)
                condition += " and a.SubscribeDate >= '" + dateTimePicker_SubBegin.Value.ToString("yyyy-MM-dd") + "'";

            if (dateTimePicker_SubEnd.Checked)
                condition += " and a.SubscribeDate <= '" + dateTimePicker_SubEnd.Value.ToString("yyyy-MM-dd") + "'";

            //签约条件
            if (!textBox_ConCode.Text.Trim().Equals(""))
                condition += " and  a.ContractCode = '" + textBox_ConCode.Text.Trim() + "'";

            if (dateTimePicker_ConBegin.Checked)
                condition += " and a.ContractDate >= '" + dateTimePicker_ConBegin.Value.ToString("yyyy-MM-dd") + "'";

            if (dateTimePicker_ConEnd.Checked)
                condition += " and a.ContractDate <= '" + dateTimePicker_ConEnd.Value.ToString("yyyy-MM-dd") + "'";

            //放贷时间
            if (dateTimePicker_LoanBegin.Checked)
                condition += " and a.LoanDate >= '" + dateTimePicker_LoanBegin.Value.ToString("yyyy-MM-dd") + "'";

            if (dateTimePicker_LoanEnd.Checked)
                condition += " and a.LoanDate <= '" + dateTimePicker_LoanEnd.Value.ToString("yyyy-MM-dd") + "'";

            return condition;
        }

        /// <summary>
        /// 获取基础数据(静态字段部分)
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        private DataTable GetBaseData(string condition)
        {
            DataTable dtBase;
            string sql = string.Format("select a.ContractID, cast('0' as int) as SubscribeID, '签约' as SaleState, c.SubscribeNum, a.ContractNum,a.SubscribeDate, a.ContractDate,a.CustomerName, a.CustomerPhone,a.SubscribeSalesName,a.SalesName, "
                + " a.PaymentName,a.DownPayRate, a.DownPayAmount,a.Loan,a.TotalAmount,a.LoanDate, '' as RecDate, "
                + " b.ItemTypeName, b.Building,b.Unit,b.ItemNum, b.Area, b.Price,b.Amount, "
                + " d.Area as SubArea, d.Price as SubPrice, d.Amount as SubAmount, c.TotalAmount as SubTotalAmount, "
                + " a.ExtField0,a.ExtField1,a.ExtField2,a.ExtField3,a.ExtField4,a.ExtField5,a.ExtField6,a.ExtField7,a.ExtField8,a.ExtField9 "
                + " from ContractMain a "
                + " inner join ContractDetail b on b.ContractID = a.ContractID "
                + " inner join SubscribeMain c on c.ContractID = a.ContractID "
                + " inner join SubscribeDetail d on d.SubscribeID = c.SubscribeID "
                + " where  a.ReturnDate is null and b.IsBind = 0 and d.IsBind = 0 and {0} ", condition);

            dtBase = SqlHelper.ExecuteDataTable(sql);

            dtBase.PrimaryKey = new DataColumn[] { dtBase.Columns["ContractID"] };


            ////付款时间
            sql = "select a.ContractID, CONVERT(VARCHAR(10), MAX(RecDate), 120) as RecDate from ContractMain a left join Receipt b on a.ContractID = b.ContractID group by a.ContractID";
            
            string recDate = string.Empty;
            if (dateTimePicker_RecBegin.Checked)
                if (recDate.Equals(""))
                    recDate = " MAX(RecDate) >= '" + dateTimePicker_RecBegin.Value.ToString("yyyy-MM-dd") + "'";
                else
                    recDate += " and MAX(RecDate) >= '" + dateTimePicker_RecBegin.Value.ToString("yyyy-MM-dd") + "'";

            if (dateTimePicker_RecEnd.Checked)
                if (recDate.Equals(""))
                    recDate = " MAX(RecDate) <= '" + dateTimePicker_RecEnd.Value.ToString("yyyy-MM-dd") + "'";
                else
                    recDate += " and MAX(RecDate) <= '" + dateTimePicker_RecEnd.Value.ToString("yyyy-MM-dd") + "'";

            if (!recDate.Equals(""))
            {
                sql += " having " + recDate; ;
            }

            DataTable dtRecLastDate = SqlHelper.ExecuteDataTable(sql);
            //dtRecLastDate.PrimaryKey = new DataColumn[] { dtRecLastDate.Columns["ContractID"] };

            for (int i = 0; i < dtBase.Rows.Count; i++)
            {
                DataRow[] dr = dtRecLastDate.Select("ContractID = " + dtBase.Rows[i]["ContractID"]);
                if (dr.Length == 0)
                {
                    dtBase.Rows[i].Delete();
                }
                else
                {
                    dtBase.Rows[i]["RecDate"] = dr[0]["RecDate"].ToString();
                }
            }

            dtBase.AcceptChanges();


            //已收首付(除贷款）、未收首付
            sql = string.Format("select a.ContractID, isnull(sum(Amount),0) as DownPayTotal,DownPayAmount-IsNull(sum(b.Amount),0) as NoDownPay from ContractMain a  "
                + "inner join receipt b on a.ContractID = b.ContractID  "
                + "where a.ProjectID = {0}  and b.TypeCode != 0 group by a.ContractID, DownPayAmount", Login.User.ProjectID);
            DataTable dtRecTotal = SqlHelper.ExecuteDataTable(sql);

            for (int i = 0; i < dtRecTotal.Rows.Count; i++)
            {
                DataRow[] dr = dtBase.Select("ContractID = " + dtRecTotal.Rows[i]["ContractID"]);
                if (dr.Length == 0)
                    dtRecTotal.Rows[i].Delete();
            }

            dtRecTotal.AcceptChanges();

            dtBase.Merge(dtRecTotal, false, MissingSchemaAction.Add);

            //已收汇总，未收汇总（仅签约）
            sql = string.Format("select a.ContractID, ISNULL(SUM(Amount),0) as ReceiptTotalAmt, (a.TotalAmount - ISNULL(SUM(Amount),0)) as NoReceiptTotalAmt from ContractMain a " 
                + " left join Receipt b on b.ContractID = a.ContractID where a.ProjectID = {0} group by a.ContractID, a.TotalAmount ", Login.User.ProjectID);

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
            string agreementId = string.Empty;

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


            dtBase.PrimaryKey = new DataColumn[] { dtBase.Columns["ContractID"] };

            DataTable dtBind = new DataTable();
            dtBind.Columns.Add("ContractID", typeof(int));

            for (int i = 0; i < dtBase.Rows.Count; i++)
            {
                agreementId = dtBase.Rows[i]["ContractID"].ToString();

                DataTable dtResult = SqlHelper.ExecuteDataTable(sql + agreementId);

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
                    row["ContractID"] = agreementId;

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

                sql = string.Format("select RecDate, Amount from Receipt where ContractID = {0}",contractId);

                DataTable dtReceipt = SqlHelper.ExecuteDataTable(sql);

                if (dtReceipt.Rows.Count > 0)
                {
                    if (dtReceipt.Rows.Count > iQuantity)
                        iQuantity = dtReceipt.Rows.Count;

                    DataTable dt = new DataTable();

                    dt.Columns.Add("ContractID", typeof(int));
                    //dt.PrimaryKey = new DataColumn[] { dt.Columns["ContractID"] };

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


        private void RepList_Load(object sender, EventArgs e)
        {
            dateTimePicker_SubBegin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateTimePicker_ConBegin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateTimePicker_RecBegin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateTimePicker_LoanBegin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            dateTimePicker_SubBegin.Checked = false;
            dateTimePicker_ConBegin.Checked = false;
            dateTimePicker_RecBegin.Checked = false;
            dateTimePicker_LoanBegin.Checked = false;
        }

        private DataTable GetSubscribeData(string condition)
        {
            string sql = string.Format("select cast('' as int) as ContractID, a.SubscribeID, Building,Unit,ItemNum,ItemTypeName, '认购' as SaleState,CustomerName,CustomerPhone,SalesName, "
                + " SubscribeNum, SubscribeDate, Area as SubArea, Price as SubPrice, Amount as SubAmount, TotalAmount as SubTotalAmount, cast('' as money) as ReceiptTotalAmt, "
                + " ExtField0,ExtField1,ExtField2,ExtField3,ExtField4,ExtField5,ExtField6,ExtField7,ExtField8,ExtField9 "
                + " from SubscribeMain a "
                + " inner join SubscribeDetail b on b.SubscribeID = a.SubscribeID "
                + " where a.ContractID is null and IsBind = 0 and ReturnDate is null and {0}", condition);

            DataTable dtSubscribe = SqlHelper.ExecuteDataTable(sql);

            foreach (DataRow row in dtSubscribe.Rows)
            {
                sql = string.Format("select ISNULL(SUM(Amount),0) as ReceiptTotalAmt from Receipt where ContractID is null and SubscribeID = {0}", row["SubscribeID"].ToString());

                row["ReceiptTotalAmt"] = double.Parse(SqlHelper.ExecuteScalar(sql).ToString());
            }

            return dtSubscribe;
        }

        private int GetSubscribeBindData(DataTable dtBase)
        {
            int colQuantity = 0;

            string sql = string.Empty;
            string agreementId = string.Empty;

            string prefix = string.Empty;
            string tableName = string.Empty;

            prefix = "Sub_Bind_";
            sql = "select ItemNum, Area, Price, Amount from SubscribeDetail where IsBind = 1 and SubscribeID = ";

            dtBase.PrimaryKey = new DataColumn[] { dtBase.Columns["SubscribeID"] };

            DataTable dtBind = new DataTable();
            dtBind.Columns.Add("SubscribeID", typeof(int));

            for (int i = 0; i < dtBase.Rows.Count; i++)
            {
                agreementId = dtBase.Rows[i]["SubscribeID"].ToString();

                DataTable dtResult = SqlHelper.ExecuteDataTable(sql + agreementId);

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
                    row["SubscribeID"] = agreementId;

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


        private void GetRowsTotalAmount()
        {
            int countItem = 0;

            double sumSubArea = 0;
            double sumSubAmount = 0;
            double sumConArea = 0;
            double sumConAmount = 0;
            double sumConTotalAmount = 0;
            double sumBindArea = 0;
            double sumBindAmount = 0;

            double sumRecTotalAmount = 0;

            foreach (DataGridViewRow row in dataGridView_List.Rows)
            {
                countItem++;

                if (row.Cells["ReceiptTotalAmt"].Value != null)
                {
                    sumRecTotalAmount += double.Parse(row.Cells["ReceiptTotalAmt"].Value.ToString()); //含认购收款
                }

                if (row.Cells["SaleState"].Value.ToString().Equals("签约"))
                {
                    string contractID = row.Cells["ContractID"].Value.ToString();

                    double bindArea = 0;
                    double bindAmount = 0;

                    GetSumConBind(contractID, out bindArea, out bindAmount);

                    sumBindArea += bindArea;
                    sumBindAmount += bindAmount;

                    sumConArea += double.Parse(row.Cells["Area"].Value.ToString());
                    sumConAmount += double.Parse(row.Cells["Amount"].Value.ToString());

                    sumConTotalAmount += double.Parse(row.Cells["TotalAmount"].Value.ToString());

                    
                }
                else
                {
                    sumSubArea += double.Parse(row.Cells["SubArea"].Value.ToString());
                    sumSubAmount += double.Parse(row.Cells["SubTotalAmount"].Value.ToString());
                }
            }

            textBox_countItem.Text = countItem.ToString();
            textBox_sumArea.Text = sumConArea.ToString("F2");
            textBox_sumAmount.Text = sumConAmount.ToString("F0");
            textBox_SumBindAmount.Text = sumBindAmount.ToString("F2");
            textBox_SumConTotalAmount.Text = sumConTotalAmount.ToString("F0");
            textBox_sumRecTotalAmount.Text = sumRecTotalAmount.ToString("F0");
        }

        /// <summary>
        /// 签约地下面积、总价
        /// </summary>
        /// <param name="subscribeID"></param>
        /// <param name="area"></param>
        /// <param name="amount"></param>
        private void GetSumConBind(string contractID, out double area, out double amount)
        {
            area = 0;
            amount = 0;
            string sql = string.Format("select ISNULL(SUM(Area),0) area, ISNULL(SUM(amount),0) amount from  ContractDetail where IsBind = 1 and ContractID = {0}", contractID);

            DataTable dt = SqlHelper.ExecuteDataTable(sql);

            area = Convert.ToDouble(dt.Rows[0]["area"]);
            amount = Convert.ToDouble(dt.Rows[0]["amount"]);
        }

        private void button_Export_Click(object sender, EventArgs e)
        {
                Common.Exp2XLS(dataGridView_List);
        }
    }
}
