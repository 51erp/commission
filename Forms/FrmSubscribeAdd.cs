using Commission.DataAccess;
using Commission.MenuForms;
using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Commission.Business;

namespace Commission.Forms
{
    public partial class FrmSubscribeAdd : Form
    {
        public FormMode FrmMode = FormMode.add;
        public string SubscribeID;

        public FrmSubscribeAdd()
        {
            InitializeComponent();
            InitDefComponent();
            initInput();
        }

        private void InitDefComponent()
        {
            MasterData.setSales(comboBox_Sales, ComboBoxType.input);
        }

        private void initInput()
        {
            textBox_CusName.Text = "";
            textBox_CusPhone.Text = "";
            textBox_CusPID.Text = "";
            textBox_CusAddr.Text = "";
            textBox_SubscribeNum.Text = "";

            textBox_Deposit.Text = "0";

            textBox_ExtField0.Text = "";
            textBox_ExtField1.Text = "";
            textBox_ExtField2.Text = "";
            textBox_ExtField3.Text = "";
            textBox_ExtField4.Text = "";
            textBox_ExtField5.Text = "";
            textBox_ExtField6.Text = "";
            textBox_ExtField7.Text = "";
            textBox_ExtField8.Text = "";
            textBox_ExtField9.Text = "";

            dataGridView_SaleItem.Rows.Clear();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_CusMore_Click(object sender, EventArgs e)
        {
            FrmCustomer frmCus = new FrmCustomer();

            if (frmCus.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox_CusName.Tag = frmCus.SelectedCus.CustomerID;
                textBox_CusName.Text = frmCus.SelectedCus.CustomerName;
                textBox_CusPhone.Text = frmCus.SelectedCus.Phone;
                textBox_CusPID.Text = frmCus.SelectedCus.PID;
                textBox_CusAddr.Text = frmCus.SelectedCus.Addr;
            }
        }

        /// <summary>
        /// 向dataGridView添加销售房产信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            FrmBaseSaleItem frmSaleItem = new FrmBaseSaleItem();

            if (frmSaleItem.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (isExist(frmSaleItem.saleItemID))
                {
                    return;
                }

                SaleItem item = new SaleItem();

                item.getSaleItemByID(frmSaleItem.saleItemID);

                bool isBind = Convert.ToBoolean(item.IsBind);

                if (!isBind)
                {
                    if (isHavMain())
                    {
                        Prompt.Information("仅允许添加一个主售房源！");
                        return;
                    }
                }


                int index = 0;

                if (isBind)
                {
                    index = dataGridView_SaleItem.Rows.Add();
                }
                else
                {
                    dataGridView_SaleItem.Rows.Insert(0, 1);
                }

                dataGridView_SaleItem.Rows[index].Cells["ColItemID"].Value = item.ItemID;
                dataGridView_SaleItem.Rows[index].Cells["ColItemTypeCode"].Value = item.ItemTypeCode;
                dataGridView_SaleItem.Rows[index].Cells["ColItemTypeName"].Value = item.ItemTypeName;
                dataGridView_SaleItem.Rows[index].Cells["ColIsBind"].Value = item.IsBind;
                dataGridView_SaleItem.Rows[index].Cells["ColBuilding"].Value = item.Building;
                dataGridView_SaleItem.Rows[index].Cells["ColUnit"].Value = item.Unit;
                dataGridView_SaleItem.Rows[index].Cells["ColItemNum"].Value = item.ItemNum;
                dataGridView_SaleItem.Rows[index].Cells["ColSubscribeArea"].Value = item.Area;
                dataGridView_SaleItem.Rows[index].Cells["ColSubscribePrice"].Value = item.Price;
                dataGridView_SaleItem.Rows[index].Cells["ColSubscribeAmout"].Value = Math.Round((double.Parse(item.Area) * double.Parse(item.Price)), 0, MidpointRounding.AwayFromZero).ToString();
                dataGridView_SaleItem.Rows[index].Cells["ColIsBind"].Value = item.IsBind;

                if (!bool.Parse(item.IsBind))
                {
                    GetLastContractDate(item.ItemID);
                }

                getRowsTotalAmount();
            }
        }

        private bool isExist(string itemID)
        {
            bool result = false;

            for (int i = 0; i < dataGridView_SaleItem.Rows.Count; i++)
            {
                if (dataGridView_SaleItem.Rows[i].Cells["ColItemID"].FormattedValue.ToString() == itemID)
                    return true;
            }

            return result;
        }

        private bool isHavMain()
        {
            bool result = false;

            for (int i = 0; i < dataGridView_SaleItem.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView_SaleItem.Rows[i].Cells["ColIsBind"].Value) == false)
                    return true;
            }

            return result;
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            if (!inputValidate())
            {
                return;    
            }

            switch (FrmMode)
            {
                case FormMode.add:
                    InsertData();
                    break;

                case FormMode.modify:
                    UpdateData();
                    break;

                case FormMode.view:
                    break;
                default:
                    break;
            }

        }

        private bool inputValidate()
        {
            bool result = true;

            dataGridView_SaleItem.EndEdit();


            if (textBox_CusName.Text.Equals(""))
            {
                Prompt.Warning("客户信息不能为空！");
                return false;
            }
            if(dataGridView_SaleItem.Rows.Count < 1 )
            {
                Prompt.Warning("房产信息不能为空！");
                return false;
            }
            if (textBox_SubscribeNum.Text.Trim().Equals(""))
            {
                Prompt.Warning("认购编号不能为空！");
                textBox_SubscribeNum.Focus();
                return false;
            }

            if (comboBox_Sales.SelectedValue == null)
            {
                Prompt.Warning("未创建置业顾问信息,无法操作！");
                return false;
            }

            if ((FrmMode == FormMode.add) && Transaction.isExistCode(textBox_SubscribeNum.Text.Trim(), false))
            {
                Prompt.Warning("认购编号已存在,不能重复录入！");
                return false;
            }

            string sql = string.Format("select IsNull(ParaValue, 0) ParaValue from ParaProject where ProjectID = {0} and ParaTypeID = {1}",Login.User.ProjectID, 1);
            object objResult = SqlHelper.ExecuteScalar(sql);
            if (objResult != null)
            {
                int paraValue = int.Parse(objResult.ToString());
                sql = string.Format("select DATEDIFF(DAY,'{0}', GETDATE()) diff", dateTimePicker_SubscribeDate.Value.ToString("yyyy-MM-dd"));
                int diff = int.Parse(SqlHelper.ExecuteScalar(sql).ToString());
                if (diff > paraValue)
                {
                    Prompt.Warning("认购日期超出前置天数！");
                    return false;
                }
            }

            int iCnt = getMainItemCount();

            if (iCnt == 0)
            {
                Prompt.Warning("必须有一个主体标的，附属标的不允许独立销售！");
                return false;
            }

            if (iCnt > 1)
            {
                Prompt.Warning("每份合约只允许存在一个主体标的！");
                return false;
            }

            return result;
        }

        /// <summary>
        /// 统计列表中主售标的的数量
        /// </summary>
        /// <returns></returns>
        private int getMainItemCount()
        {
            int itemCnt = 0;

            for (int i = 0; i < dataGridView_SaleItem.Rows.Count; i++)
            {
                if (dataGridView_SaleItem.Rows[i].Cells["ColIsBind"].Value.ToString() == "False")
                {
                    itemCnt++;
                }
            }

            return itemCnt;
        }

        private bool isExistCode(string projectID, string contractCode)
        {
            string sql = string.Format("select count(tid) from TransMain where and projectID = {0} and ContractCode = '{1}'", projectID, contractCode);
            int sqlResult = int.Parse(SqlHelper.ExecuteScalar(sql).ToString());
            if (sqlResult > 0)
                return true;

            return false;
        }

        private void InsertData()
        {
            using (SqlConnection connection = SqlHelper.OpenConnection())  //创建连接对象 
            {
                string sql = string.Empty;
                SqlTransaction sqlTran = connection.BeginTransaction();    //开始事务 
                SqlCommand cmd = connection.CreateCommand();               //创建SqlCommand对象 
                cmd.Transaction = sqlTran;                                 //将SqlCommand与SqlTransaction关联起

                try
                {
                    //业务主表
                    cmd.CommandText = GenSubscribeMainSQL();
                    string subcribeID = cmd.ExecuteScalar().ToString();


                    //业务从表
                    for (int i = 0; i < dataGridView_SaleItem.Rows.Count; i++)
                    {
                        cmd.CommandText = genSubscribeDetailSQL(i, subcribeID);
                        cmd.ExecuteNonQuery();

                        //设置房产销售状态
                        cmd.CommandText = string.Format("update saleitem set SaleStateCode = {0}, SaleStateName = '{1}' where ItemID = {2}", ((int)ItemSaleState.认购).ToString(), ItemSaleState.认购, dataGridView_SaleItem.Rows[i].Cells["ColItemID"].Value.ToString());
                        cmd.ExecuteNonQuery();
                    }

                    //收款信息
                    if (int.Parse(textBox_Deposit.Text.Trim()) > 0)
                    {
                        sql = string.Format("insert into [Receipt] (SubscribeID,Amount,RecDate,TypeCode,TypeName,SalesID, SalesName, MakeDate, Maker,ProjectID) " 
                            + "values ({0},{1},'{2}',{3},'{4}',{5},'{6}',{7},'{8}',{9})",
                            subcribeID, textBox_Deposit.Text.Trim(), dateTimePicker_SubscribeDate.Value.ToShortDateString(), 
                            (int)Receivables.定金, Receivables.定金,comboBox_Sales.SelectedValue.ToString(), comboBox_Sales.Text, "GETDATE()", Login.User.UserName, Login.User.ProjectID);

                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                    }

                    sqlTran.Commit(); 

                    (this.Owner as FrmSubscribe).Search(" and a.SubscribeID = " + subcribeID);
                    initInput();

                    if (MessageBox.Show("操作成功！是否继续添加？",Common.MsgCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    {
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();  //异常事务回滚
                    Prompt.Error("操作失败， 错误：" + ex.Message);
                }

                

            }
        }


        private void UpdateData()
        {
            using (SqlConnection connection = SqlHelper.OpenConnection())  //创建连接对象 
            {
                SqlTransaction sqlTran = connection.BeginTransaction();    //开始事务 
                SqlCommand cmd = connection.CreateCommand();               //创建SqlCommand对象 
                cmd.Transaction = sqlTran;                                 //将SqlCommand与SqlTransaction关联起

                try
                {
                    //业务主表
                    cmd.CommandText = genUpdateMainSQL(SubscribeID);
                    cmd.ExecuteNonQuery();

                    //业务从表 - 重置房产销售状态
                    ResetItemSaleState();

                    //业务从表 - 清除
                    cmd.CommandText = string.Format("delete [SubscribeDetail] where SubscribeID = {0} ", SubscribeID);
                    cmd.ExecuteNonQuery();

                    //业务从表 - 添加
                    for (int i = 0; i < dataGridView_SaleItem.Rows.Count; i++)
                    {
                        cmd.CommandText = genSubscribeDetailSQL(i, SubscribeID);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = string.Format("update saleitem set SaleStateCode = {0}, SaleStateName = '{1}' where ItemID = {2}", ((int)ItemSaleState.认购).ToString(), ItemSaleState.认购, dataGridView_SaleItem.Rows[i].Cells["ColItemID"].Value.ToString());
                        cmd.ExecuteNonQuery();
                    }


                    //收款信息 - 清除
                    cmd.CommandText = string.Format("delete [Receipt] where SubscribeID = {0}", SubscribeID);
                    cmd.ExecuteNonQuery();

                    //收款信息 - 添加
                    if (int.Parse(textBox_Deposit.Text.Trim()) > 0)
                    {
                        cmd.CommandText = string.Format("insert into [Receipt] (SubscribeID,Amount,RecDate,TypeCode,TypeName,SalesID, SalesName, MakeDate,Maker,ProjectID) values ('{0}',{1},'{2}',{3},'{4}',{5},'{6}',{7},'{8}',{9})",
                            SubscribeID, textBox_Deposit.Text.Trim(), dateTimePicker_SubscribeDate.Value.ToShortDateString(),
                            (int)Receivables.定金, Receivables.定金, comboBox_Sales.SelectedValue.ToString(), comboBox_Sales.Text, "GETDATE()", Login.User.UserName,Login.User.ProjectID);
                            
                        cmd.ExecuteNonQuery();
                    }


                    sqlTran.Commit();  //事务提交
                    connection.Close();
                    (this.Owner as FrmSubscribe).Search(" and a.SubscribeID = " + SubscribeID);

                    //Prompt.Information("操作成功!数据已更新。");
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();  //异常事务回滚
                    Prompt.Error("操作失败， 错误：" + ex.Message);
                }
            }

            
        }




        /// <summary>
        /// 业务主表SQL构建
        /// </summary>
        /// <param name="conCode"></param>
        /// <returns></returns>
        private string GenSubscribeMainSQL()
        {
            string sql = string.Empty;

            string lastDate = textBox_LastContractDate.Text.Equals("") ? "NULL" : "'" + textBox_LastContractDate.Text + "'";

            string fields = "SubscribeNum, ProjectID, ProjectName, CustomerID, CustomerName, CustomerPhone, SubscribeDate,LastContractDate, "
                + "TotalAmount, SalesID, SalesName, MakeDate, UserID, UserName, "
                + "ExtField0,ExtField1,ExtField2,ExtField3,ExtField4,ExtField5,ExtField6,ExtField7,ExtField8,ExtField9";

            string values = "'" + textBox_SubscribeNum.Text.Trim() + "'"
                + "," + Login.User.ProjectID
                + ",'" + Login.User.ProjectName + "'"
                + "," + textBox_CusName.Tag
                + ",'" + textBox_CusName.Text + "'"
                + ",'" + textBox_CusPhone.Text.Trim() + "'"
                + ",'" + dateTimePicker_SubscribeDate.Value.ToShortDateString() + "'"
                + "," +lastDate 
                + "," + double.Parse(textBox_Total.Text.Trim(), NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint).ToString()
                + "," + comboBox_Sales.SelectedValue.ToString()
                + ",'" + comboBox_Sales.Text + "'"
                + ",getDate()"
                + "," + Login.User.UserID
                + ",'" + Login.User.UserName + "'"
                + ",'" + textBox_ExtField0.Text.Trim() + "'"
                + ",'" + textBox_ExtField1.Text.Trim() + "'"
                + ",'" + textBox_ExtField2.Text.Trim() + "'"
                + ",'" + textBox_ExtField3.Text.Trim() + "'"
                + ",'" + textBox_ExtField4.Text.Trim() + "'"
                + ",'" + textBox_ExtField5.Text.Trim() + "'"
                + ",'" + textBox_ExtField6.Text.Trim() + "'"
                + ",'" + textBox_ExtField7.Text.Trim() + "'"
                + ",'" + textBox_ExtField8.Text.Trim() + "'"
                + ",'" + textBox_ExtField9.Text.Trim() + "'";


            sql = "insert into [SubscribeMain] (" + fields + ") output inserted.SubscribeID values (" + values + ")";

            return sql;
        }


        /// <summary>
        /// 业务从表SQL构建
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="conCode"></param>
        /// <param name="rowid"></param>
        /// <returns></returns>
        private string genSubscribeDetailSQL(int rowid, string subcribeId)
        {
            string sql = string.Empty;

            string amount = dataGridView_SaleItem.Rows[rowid].Cells["ColSubscribeAmout"].FormattedValue.ToString();

            string fields = "RowID, SubscribeID, ItemTypeCode, ItemTypeName, IsBind, ItemID, building, Unit, ItemNum, Area, Price, Amount";
            string values = rowid
                + "," + subcribeId
                + "," + dataGridView_SaleItem.Rows[rowid].Cells["ColItemTypeCode"].Value.ToString() 
                + ",'" + dataGridView_SaleItem.Rows[rowid].Cells["ColItemTypeName"].Value.ToString() + "'"
                + ",'" + dataGridView_SaleItem.Rows[rowid].Cells["ColIsBind"].Value.ToString() + "'"
                + "," + dataGridView_SaleItem.Rows[rowid].Cells["ColItemID"].Value.ToString()
                + ",'" + dataGridView_SaleItem.Rows[rowid].Cells["ColBuilding"].Value.ToString() + "'"
                + ",'" + dataGridView_SaleItem.Rows[rowid].Cells["ColUnit"].Value.ToString() + "'"
                + ",'" + dataGridView_SaleItem.Rows[rowid].Cells["ColItemNum"].Value.ToString() + "'"
                + "," + dataGridView_SaleItem.Rows[rowid].Cells["ColSubscribeArea"].FormattedValue.ToString()
                + "," + dataGridView_SaleItem.Rows[rowid].Cells["ColSubscribePrice"].FormattedValue.ToString()
                + "," + double.Parse(amount, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint).ToString();

            sql = "insert into [SubscribeDetail] (" + fields + ") values (" + values + ")";

            return sql;
        }

        /// <summary>
        /// 设置房产的销售状态,1:认购
        /// </summary>
        /// <param name="rowid"></param>
        /// <returns></returns>
        private string genSetSaleStateSQL(string  itemID)
        {
            string sql = string.Empty;

            sql = "update saleitem set SaleState = " + ((int)ItemSaleState.认购).ToString() + " where ItemID = " + itemID;

            return sql;
        }


        /// <summary>
        /// 保存收款信息
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="conCode"></param>
        /// <returns></returns>
        private string genReceiptSQL()
        {
            string sql = string.Format("insert into [Receipt] (SubscribeCode,Amount,RecDate,TypeCode,TypeName,MakeDate,Maker) " 
                + "values ('{0}',{1},'{2}',{3},{4},getDate(),{5})", 
                textBox_SubscribeNum.Text.Trim(), textBox_Deposit.Text.Trim(),dateTimePicker_SubscribeDate.Value.ToShortDateString(), 
                (int)Receivables.定金, Receivables.定金, Login.User.UserName);

            return sql;
        }
        
        private void toolStripButton_Remove_Click(object sender, EventArgs e)
        {
            if (dataGridView_SaleItem.CurrentRow != null)
            {
                int idx = dataGridView_SaleItem.CurrentRow.Index;
                if (idx != -1)
                {
                    //if (isModify)
                    //{
                    //    string sql = "update saleitem set SaleState = 0 where itemID = " + dataGridView_SaleItem.Rows[idx].Cells["ColItemID"].Value.ToString();
                    //    SqlHelper.ExecuteNonQuery(sql);
                    //}
                        dataGridView_SaleItem.Rows.RemoveAt(idx);
                }
                    
            }
        }


        private void dataGridView_Subscribe_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            getRowsTotalAmount();
        }


        /// <summary>
        /// 行增减时，计算总额 
        /// </summary>
        private void getRowsTotalAmount()
        {
            int countItem = 0;
            double sumAmount = 0;


            foreach (DataGridViewRow row in dataGridView_SaleItem.Rows)
            {
                countItem++;
                sumAmount += double.Parse(row.Cells["ColSubscribeAmout"].FormattedValue.ToString());
            }

            textBox_Total.Text = sumAmount.ToString("F0");
        }

        private void FrmSubscribeAdd_Load(object sender, EventArgs e)
        {
            switch (FrmMode)
            {
                case FormMode.add:
                    break;
                case FormMode.modify:
                    this.Text = "修改认购信息";
                    textBox_SubscribeNum.ReadOnly = true;
                    LoadDate();
                    break;

                case FormMode.view:
                    this.Text = "查看认购信息";

                    dateTimePicker_SubscribeDate.Enabled = false;
                    textBox_SubscribeNum.ReadOnly = true;

                    dataGridView_SaleItem.ReadOnly = true;
                    dataGridView_SaleItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    toolStripButton_Save.Visible = false;
                    button_CusMore.Visible = false;
                    toolStrip1.Visible = false;
                    comboBox_Sales.Enabled = false;
                    textBox_Deposit.ReadOnly = true;
                    LoadDate();
                    break;

                default:
                    break;
            }

        }

        private void LoadDate()
        {
            string sql = string.Empty;
            try
            {
                sql = string.Format("select SubscribeNum, ProjectID,CustomerID,SalesID,TotalAmount,SubscribeDate,Convert(varchar(10),LastContractDate,120) as LastContractDate,ExtField0,ExtField1,ExtField2,ExtField3,ExtField4,ExtField5,ExtField6,ExtField7,ExtField8,ExtField9 from [SubscribeMain] where SubscribeID = {0} ", SubscribeID);
                SqlDataReader sdr = SqlHelper.ExecuteReader(sql);
                sdr.Read();
                textBox_SubscribeNum.Text = sdr["SubscribeNum"].ToString();
                comboBox_Sales.SelectedValue = sdr["SalesID"].ToString();
                textBox_Total.Text = double.Parse(sdr["TotalAmount"].ToString()).ToString("F0");
                dateTimePicker_SubscribeDate.Value = DateTime.Parse(sdr["SubscribeDate"].ToString());
                textBox_LastContractDate.Text = sdr["LastContractDate"].ToString();
                textBox_ExtField0.Text = sdr["ExtField0"].ToString();
                textBox_ExtField1.Text = sdr["ExtField1"].ToString();
                textBox_ExtField2.Text = sdr["ExtField2"].ToString();
                textBox_ExtField3.Text = sdr["ExtField3"].ToString();
                textBox_ExtField4.Text = sdr["ExtField4"].ToString();
                textBox_ExtField5.Text = sdr["ExtField5"].ToString();
                textBox_ExtField6.Text = sdr["ExtField6"].ToString();
                textBox_ExtField7.Text = sdr["ExtField7"].ToString();
                textBox_ExtField8.Text = sdr["ExtField8"].ToString();
                textBox_ExtField9.Text = sdr["ExtField9"].ToString();

                //客户信息
                sql = "select CustomerID,CustomerName,CustomerPhone,PID,Addr from Customer where CustomerID = " + sdr["CustomerID"].ToString();
                sdr = SqlHelper.ExecuteReader(sql);
                sdr.Read();
                textBox_CusName.Tag = sdr["CustomerID"].ToString();
                textBox_CusName.Text = sdr["CustomerName"].ToString();
                textBox_CusPhone.Text = sdr["CustomerPhone"].ToString();
                textBox_CusPID.Text = sdr["PID"].ToString();
                textBox_CusAddr.Text = sdr["Addr"].ToString();

                //收款信息
                sql = string.Format("select isnull(sum(Amount),0) from Receipt where SubscribeID = {0}", SubscribeID);
                Object result = SqlHelper.ExecuteScalar(sql);
                if (result == null)
                {
                    textBox_Deposit.Text = "0";
                }
                else
                {
                    textBox_Deposit.Text = string.Format("{0:F0}", result);
                }

                //从表信息
                sql = string.Format("select ItemID,ItemTypeCode,ItemTypeName,Building,Unit,ItemNum,Area,Price,Amount,IsBind from [SubscribeDetail] where SubscribeID = {0} order by rowid ", SubscribeID);
                sdr = SqlHelper.ExecuteReader(sql);
                while (sdr.Read())
                {
                    int index = this.dataGridView_SaleItem.Rows.Add();
                    dataGridView_SaleItem.Rows[index].Cells["ColItemID"].Value = sdr["ItemID"].ToString();
                    dataGridView_SaleItem.Rows[index].Cells["ColItemTypeCode"].Value = sdr["ItemTypeCode"].ToString();
                    dataGridView_SaleItem.Rows[index].Cells["ColItemTypeName"].Value = sdr["ItemTypeName"].ToString();
                    dataGridView_SaleItem.Rows[index].Cells["ColBuilding"].Value = sdr["Building"].ToString();
                    dataGridView_SaleItem.Rows[index].Cells["ColUnit"].Value = sdr["Unit"].ToString();
                    dataGridView_SaleItem.Rows[index].Cells["ColItemNum"].Value = sdr["ItemNum"].ToString();
                    dataGridView_SaleItem.Rows[index].Cells["ColSubscribeArea"].Value = sdr["Area"].ToString();
                    dataGridView_SaleItem.Rows[index].Cells["ColSubscribePrice"].Value = sdr["Price"].ToString();
                    dataGridView_SaleItem.Rows[index].Cells["ColSubscribeAmout"].Value = double.Parse(sdr["Amount"].ToString()).ToString("F0");
                    dataGridView_SaleItem.Rows[index].Cells["ColIsBind"].Value = sdr["IsBind"].ToString();
                }
            }
            catch (Exception ex)
            {
                Prompt.Error("系统错误，错误信息（LD-01）：" + ex.Message);
            }
            //主表信息
 
        }

        private string genUpdateMainSQL(string subscribeID)
        {
            string sql = string.Empty;

            string lastDate = textBox_LastContractDate.Text.Equals("") ? "NULL" : string.Format("'{0}'",textBox_LastContractDate.Text);

            string updateField = "CustomerID = " + textBox_CusName.Tag
                + ",CustomerName = '" + textBox_CusName.Text + "'"
                + ",CustomerPhone = '" + textBox_CusPhone.Text + "'"
                + ",SubscribeDate = '" + dateTimePicker_SubscribeDate.Value.ToShortDateString() + "'"
                + ",LastContractDate = " + lastDate
                + ",TotalAmount = " + double.Parse(textBox_Total.Text.Trim(), NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint).ToString()
                + ",SalesID = " + comboBox_Sales.SelectedValue.ToString()
                + ",SalesName = '" + comboBox_Sales.Text + "'"
                + ",ExtField0 = '" + textBox_ExtField0.Text.Trim() + "'"
                + ",ExtField1 = '" + textBox_ExtField1.Text.Trim() + "'"
                + ",ExtField2 = '" + textBox_ExtField2.Text.Trim() + "'"
                + ",ExtField3 = '" + textBox_ExtField3.Text.Trim() + "'"
                + ",ExtField4 = '" + textBox_ExtField4.Text.Trim() + "'"
                + ",ExtField5 = '" + textBox_ExtField5.Text.Trim() + "'"
                + ",ExtField6 = '" + textBox_ExtField6.Text.Trim() + "'"
                + ",ExtField7 = '" + textBox_ExtField7.Text.Trim() + "'"
                + ",ExtField8 = '" + textBox_ExtField8.Text.Trim() + "'"
                + ",ExtField9 = '" + textBox_ExtField9.Text.Trim() + "'";


            sql = string.Format("update [SubscribeMain] set {0} where SubscribeID = {1}", updateField, SubscribeID);

            return sql;
        }

        //重置房产状态
        private void ResetItemSaleState()
        {
            string sql = string.Format("select ItemID from [SubscribeDetail] where SubscribeID = {0}", SubscribeID);
            SqlDataReader sdr = SqlHelper.ExecuteReader(sql);
            while (sdr.Read())
            {
                sql = string.Format("update saleitem set SaleStateCode = {0}, SaleStateName = '{1}' where ItemID = {2}", ((int)ItemSaleState.待售).ToString(), ItemSaleState.待售, sdr["itemID"].ToString());
                SqlHelper.ExecuteNonQuery(sql);
            }
        }

        private void dataGridView_SaleItem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            double area = 0;
            double price = 0;
            double amount = 0;

            if (dataGridView_SaleItem.Columns[e.ColumnIndex].Name == "ColSubscribePrice")
            {
                double.TryParse(dataGridView_SaleItem.Rows[rowIndex].Cells["ColSubscribeArea"].FormattedValue.ToString(), out area);
                double.TryParse(dataGridView_SaleItem.Rows[rowIndex].Cells["ColSubscribePrice"].FormattedValue.ToString(), out price);

                dataGridView_SaleItem.Rows[rowIndex].Cells["ColSubscribeAmout"].Value = (area * price).ToString("F0");
            }
            else if (dataGridView_SaleItem.Columns[e.ColumnIndex].Name == "ColSubscribeAmout")
            {
                double.TryParse(dataGridView_SaleItem.Rows[rowIndex].Cells["ColSubscribeArea"].FormattedValue.ToString(), out area);
                double.TryParse(dataGridView_SaleItem.Rows[rowIndex].Cells["ColSubscribeAmout"].EditedFormattedValue.ToString(), out amount);

                dataGridView_SaleItem.Rows[rowIndex].Cells["ColSubscribePrice"].Value = (amount / area).ToString("F4");
            }

            getRowsTotalAmount();
        }

        private void comboBox_Project_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("****" + comboBox_Project.SelectedValue.ToString());
            //MasterData.setSales(comboBox_Project.SelectedValue.ToString(), comboBox_Sales, ComboBoxType.input);
        }

        private void dataGridView_SaleItem_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView_SaleItem.Rows.Count == 0)
                e.Cancel = true;

            double amount = 0;
            bool result = true ;
            result = double.TryParse(dataGridView_SaleItem.Rows[e.RowIndex].Cells["ColSubscribeAmout"].EditedFormattedValue.ToString(), out amount);

            if (!result)
            {
                Prompt.Error("请填写正确的数字格式！");
                e.Cancel = true;
            }

            double price = 0;
            result = double.TryParse(dataGridView_SaleItem.Rows[e.RowIndex].Cells["ColSubscribePrice"].EditedFormattedValue.ToString(), out price);

            if (!result)
            {
                Prompt.Error("请填写正确的数字格式！");
                e.Cancel = true;
            }
        }

        private void textBox_Deposit_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.OnlyNumeric(sender, e);
        }

        private void dateTimePicker_SubscribeDate_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView_SaleItem.Rows.Count; i++)
            {
                bool isBind = bool.Parse(dataGridView_SaleItem.Rows[i].Cells["ColIsBind"].Value.ToString());
                if (!isBind)
                {
                    GetLastContractDate(dataGridView_SaleItem.Rows[i].Cells["ColItemID"].Value.ToString());
                }
            }
        }

        private void GetLastContractDate(string itemId)
        {
            string sql = string.Format("select IntervalDays from saleitem a "
                + " inner join paraintervalDays b on b.ItemTypeCode = a.ItemTypeCode "
                + " where a.ItemID = {0}", itemId);
            object objResult = SqlHelper.ExecuteScalar(sql);

            if (objResult != null)
            {
                double days = double.Parse(objResult.ToString());
                textBox_LastContractDate.Text = dateTimePicker_SubscribeDate.Value.AddDays(days).ToString("yyyy-MM-dd");
            }

        }

    }
}
