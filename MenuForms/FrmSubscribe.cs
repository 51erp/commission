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
    public partial class FrmSubscribe : Form
    {
        private string ProjectID = string.Empty;
        public FrmSubscribe()
        {
            InitializeComponent();
            InitDefComponent();
        }

        private void InitDefComponent()
        {
            comboBox_ReferState.SelectedIndex = 0;
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            FrmSubscribeAdd subscribe = new FrmSubscribeAdd();
            subscribe.Owner = this;
            subscribe.ShowDialog();
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

            if (comboBox_ReferState.Text == "未签约")
            {
                condition += " and ContractID is null";
                toolStripButton_Del.Enabled = true;
                toolStripButton_Modify.Enabled = true;
                toolStripButton_Rename.Enabled = true;
                toolStripButton_Back.Enabled = true;
            }
            else
            {
                condition += " and ContractID is not null";
                toolStripButton_Del.Enabled = false;
                toolStripButton_Modify.Enabled = false;
                toolStripButton_Rename.Enabled = false;
                toolStripButton_Back.Enabled = false;
                toolStripButton_Delay.Enabled = false;
            }


            Search(condition);

        }


        public void Search(string condition)
        {
            button_Search.Enabled = false;

            int colQuantity = 0;

            DataTable dtSubscribe = GetSubscribeData(condition, out colQuantity);

            Transaction.InsertBindCol(dataGridView_Subscribe, 13, colQuantity);

            dataGridView_Subscribe.DataSource = dtSubscribe;

            getRowsTotalAmount();

            button_Search.Enabled = true;

            if (dtSubscribe.Rows.Count == 0)
            {
                Prompt.Information("没有符合条件的查询结果 ");
            }
        }
        
      
        /// <summary>
        /// 利用Merge()先将附属物业合同，再合并到主体标的表中
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="iMaxColQuantity"></param>
        /// <returns></returns>
        private DataTable GetSubscribeData(string condition, out int iMaxColQuantity)
        {
            iMaxColQuantity = 0;
            string formatAmount = "{0:F" + Login.Parameters.PrecisionAmount + "}";
            string sql = string.Empty;

            sql = "select a.SubscribeID, a.ContractID, CustomerID,CustomerName,CustomerPhone, "
                + " ItemTypeName, Building, Unit, ItemNum, Area, Price, Amount, TotalAmount, SubscribeDate, convert(varchar(10),LastContractDate,120) LastContractDate, SalesID, SalesName," 
                + " ExtField0, ExtField1, ExtField2, ExtField3, ExtField4, ExtField5, ExtField6, ExtField7, ExtField8, ExtField9 "
                + " from SubscribeMain a "
                + " inner join SubscribeDetail b on a.SubscribeID = b.SubscribeID "
                + " where ReturnDate is null and a.ProjectID = " + Login.User.ProjectID + " and  b.IsBind = 0 " + condition
                + " order by SubscribeID ";

            DataTable dtSubscribe = SqlHelper.ExecuteDataTable(sql); //主体表

            dtSubscribe.PrimaryKey = new DataColumn[] { dtSubscribe.Columns["SubscribeID"] };

            for (int i = 0; i < dtSubscribe.Rows.Count; i++)
			{
                string subId = dtSubscribe.Rows[i]["SubscribeID"].ToString();

                sql = "select ItemNum, Area, Price, Amount from SubscribeDetail where IsBind = 1 and SubscribeID = " + subId;

                SqlDataReader dr = SqlHelper.ExecuteReader(sql);

                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();

                    dt.Columns.Add("SubscribeID", typeof(int));
                    dt.PrimaryKey = new DataColumn[] { dt.Columns["SubscribeID"] };

                    string fieldValue = subId;

                    
                    int itemIdx = 0;     //一个房源相同尾号
                    while (dr.Read())    
                    {
                        for (int j = 0; j < dr.FieldCount; j++)
                        {
                            string fieldName = "BIND_" + dr.GetName(j) + itemIdx;
                            dt.Columns.Add(fieldName, typeof(string));

                            if (dr.GetName(j).Equals("Amount"))
                            {
                                fieldValue += "," + string.Format(formatAmount, dr.GetValue(j));
                            }
                            else
                            {
                                fieldValue += "," + dr.GetValue(j).ToString();
                            }
                        }

                        itemIdx++;

                        if (itemIdx > iMaxColQuantity)
                            iMaxColQuantity = itemIdx;
                    }

                    string[] strArray = fieldValue.Split(',');

                    dt.Rows.Add(strArray);

                    dtSubscribe.Merge(dt, false, MissingSchemaAction.Add); //合并至主体表
                }
            }

            return dtSubscribe;
        }





        /// <summary>
        /// 生成认购数据并显示
        /// </summary>
        /// <param name="condition"></param>
        private void getSubscribe(string condition, string state)
        {
            string sql = string.Empty ;

             
            //固定显示的字段列
            string sqlField = "select SubscribeID, CustomerName,"
                + " ItemTypeName, Building, Unit, ItemNum, Area, Price ,Amount, TotalAmount,ContractDate,SalesName,IsRefer "
                + " from SubscribeMain where 1 = 2 ";

            //生成DataTable结构和dataGridView列
            DataTable tabSubscribe = Transaction.genCol(dataGridView_Subscribe, 13, sqlField);

            //查询符合条件的业务号和合同号,以此为条件获取主从表信息并填充到dataGridView
            if (state == "1")
            {
                sql = "select tid,ContractCode from TransMain where isrefer = 1 and TransState =  " + ((int)ItemSaleState.认购).ToString() + condition; ;
            }
            else
            {
                sql = "select distinct TID,ContractCode "
                    + " from V_TransactionBase "
                    + " where  isrefer = 0 and TransState = " + ((int)ItemSaleState.认购).ToString()
                    + condition;
            }

            //填充数据
            SqlDataReader sdr = SqlHelper.ExecuteReader(sql);
            while(sdr.Read())
            {
                DataRow dr = tabSubscribe.NewRow();

                //业务信息--主表
                string sqlTrans = "select TID, ContractCode ,ProjectName, CustomerName, Phone1, TotalAmount,ContractDate,SalesName,IsRefer from " 
                    + "[TransMain] a inner join Customer b on a.CustomerID = b.CustomerID " 
                    + "where TID = " + sdr["TID"].ToString() + " and ContractCode = '" + sdr["ContractCode"].ToString() + "'";
                SqlDataReader sdrTrans = SqlHelper.ExecuteReader(sqlTrans);
                sdrTrans.Read();
                for (int i = 0; i < sdrTrans.FieldCount; i++)
                {
                    string fieldName = sdrTrans.GetName(i);
                    dr[fieldName] = sdrTrans.GetValue(i);
                }

                //业务明细--非储藏间：（ItemType <> 3） //要求单独购买，仅一条记录!!!
                string sqlDetail = "select ItemTypeName, Building, Unit, ItemNum, Area, Price ,Amount from [TransDetail] where ItemType <> 3 and TID = " + sdr["TID"].ToString() + " and ContractCode = '" + sdr["ContractCode"].ToString() + "'";
                SqlDataReader sdrDetail = SqlHelper.ExecuteReader(sqlDetail);
                
                if (sdrDetail.Read())
                {
                    for (int i = 0; i < sdrDetail.FieldCount; i++)
                    {
                        string fieldName = sdrDetail.GetName(i);
                        dr[fieldName] = sdrDetail.GetValue(i);
                    }
                }

                //业务明细--储藏间：（ItemType ＝ 3）  //购买可单独,可附加，多条记录
                string sqlDetail1_Store = "select ItemNum, Area, Price ,Amount from [TransDetail] where ItemType = 3 and TID = " + sdr["TID"].ToString() + " and ContractCode = '" + sdr["ContractCode"].ToString() + "'";
                SqlDataReader sdrDetail_Store = SqlHelper.ExecuteReader(sqlDetail1_Store);

                int fieldIndex = 0;
                while (sdrDetail_Store.Read())
                {
                    for (int i = 0; i < sdrDetail_Store.FieldCount; i++)
                    {
                        string fieldName = sdrDetail_Store.GetName(i) + fieldIndex.ToString();

                        if (sdrDetail_Store.GetName(i).ToString() == "Price")
                        {
                            dr[fieldName] = string.Format("{0:F4}", sdrDetail_Store.GetValue(i));
                        }
                        else if (sdrDetail_Store.GetName(i).ToString() == "Amount")
                        {
                            dr[fieldName] = string.Format("{0:F0}", sdrDetail_Store.GetValue(i));
                        }
                        else
                        {
                            dr[fieldName] = sdrDetail_Store.GetValue(i);
                        }
                    }
                    fieldIndex++;
                }

                tabSubscribe.Rows.Add(dr);
            }

            dataGridView_Subscribe.DataSource = tabSubscribe;

            //getRowsTotalAmount();
        }

        private void toolStripButton_Modify_Click(object sender, EventArgs e)
        {
            if (dataGridView_Subscribe.CurrentRow == null)
            {
                Prompt.Warning("未选择相应的记录！");
                return;
            }

            string SubscribeID = dataGridView_Subscribe.CurrentRow.Cells["ColSubscribeID"].Value.ToString();

            if (!dataGridView_Subscribe.CurrentRow.Cells["ColContractID"].Value.ToString().Equals(""))
            {
                Prompt.Warning("已经被签约引用，无法修改！");
                return;
            }

            FrmSubscribeAdd subscribe = new FrmSubscribeAdd();
            subscribe.FrmMode = FormMode.modify;
            subscribe.SubscribeID = dataGridView_Subscribe.CurrentRow.Cells["ColSubscribeID"].Value.ToString();
            subscribe.Owner = this;

            if (subscribe.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Prompt.Information("操作成功!数据已更新。");
            }

        }

        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {
            if (dataGridView_Subscribe.CurrentRow == null)
            {
                Prompt.Warning("未选择相应的记录！");
                return;
            }

            string SubscribeID = dataGridView_Subscribe.CurrentRow.Cells["ColSubscribeID"].Value.ToString();

            if (!dataGridView_Subscribe.CurrentRow.Cells["ColContractID"].Value.ToString().Equals(""))
            {
                Prompt.Warning("已经被签约引用，无法删除！");
                return;
            }

            if (MessageBox.Show("确认要删除记录？", "房产销售佣金系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (DelSubscribe(SubscribeID))
                {
                    dataGridView_Subscribe.Rows.RemoveAt(dataGridView_Subscribe.CurrentRow.Index);
                    if (dataGridView_Subscribe.CurrentRow != null)
                        dataGridView_Subscribe.Rows[dataGridView_Subscribe.CurrentRow.Index].Cells[0].Selected = true;    
                    Prompt.Information("操作成功，数据已经删除！");
                }
            }

        }

        private bool isRefer(string tid, string contractCode)
        {
            string sql = string.Format("select isnull(count(*),0) from TransMain where IsRefer = 1 and tid = {0} and ContractCode = '{1}'", tid, contractCode);

            int result = int.Parse(SqlHelper.ExecuteScalar(sql).ToString());

            if (result > 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// 按认购ID重置房源销售状态
        /// </summary>
        /// <param name="subscribID">认购ID</param>
        private void ResetItemSaleState(string subscribID)
        {
            string sql = string.Format("select ItemID from [SubscribeDetail] where SubscribeID = {0}", subscribID);
            SqlDataReader sdr = SqlHelper.ExecuteReader(sql);
            while (sdr.Read())
            {
                sql = string.Format("update saleitem set SaleStateCode = {0}, SaleStateName = '{1}' where ItemID = {2}", ((int)ItemSaleState.待售).ToString(), ItemSaleState.待售,  sdr["itemID"].ToString());
                SqlHelper.ExecuteNonQuery(sql);
            }
        }


        private bool DelSubscribe(string subscribeID)
        {
            bool result = false;

            using (SqlConnection connection = SqlHelper.OpenConnection())  //创建连接对象 
            {
                SqlTransaction sqlTran = connection.BeginTransaction();    //开始事务 
                SqlCommand cmd = connection.CreateCommand();               //创建SqlCommand对象 
                cmd.Transaction = sqlTran;                                 //将SqlCommand与SqlTransaction关联起

                try
                {
                    //删除主表
                    cmd.CommandText = string.Format("delete SubscribeMain where SubscribeID = {0}", subscribeID);
                    cmd.ExecuteNonQuery();

                    //恢复待售状态
                    ResetItemSaleState(subscribeID);

                    //删除明细项目
                    cmd.CommandText = string.Format("delete SubscribeDetail where SubscribeID = {0}", subscribeID);
                    cmd.ExecuteNonQuery();

                    //删除所有收款
                    cmd.CommandText = string.Format("delete Receipt where SubscribeID = {0}", subscribeID);
                    cmd.ExecuteNonQuery();

                    sqlTran.Commit();  //事务提交
                    connection.Close();

                    result =  true;


                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();  //异常事务回滚
                    Prompt.Error("操作失败， 错误：" + ex.Message);
                }
            }

            return result;

        }




        private void FrmSubscribe_Load(object sender, EventArgs e)
        {
        }

        private void toolStripButton_View_Click(object sender, EventArgs e)
        {
            ViewSubscribe();
        }

        private void ViewSubscribe()
        {
            if (dataGridView_Subscribe.CurrentRow == null)
            {
                Prompt.Warning("未选择相应的记录！");
                return;
            }


            FrmSubscribeAdd subscribe = new FrmSubscribeAdd();
            subscribe.FrmMode = FormMode.view;
            subscribe.SubscribeID = dataGridView_Subscribe.CurrentRow.Cells["ColSubscribeID"].Value.ToString();
            subscribe.ShowDialog();
        }


        private void getRowsTotalAmount()
        {
            int countItem = 0;         //套数
            double sumTotalAmount = 0; //总款
            double sumArea = 0;        //地上面积
            double sumAmount = 0;      //地上金额

            double sumBindArea = 0;    //附属面积
            double sumBindAmount = 0;  //附属金额
            


            foreach (DataGridViewRow row in dataGridView_Subscribe.Rows)
            {
                double bindArea = 0;
                double bindAmount = 0;
                 
                countItem++;
                sumArea += double.Parse(row.Cells["ColArea"].Value.ToString());
                sumAmount += double.Parse(row.Cells["ColAmount"].Value.ToString());
                sumTotalAmount += double.Parse(row.Cells["ColTotalAmount"].Value.ToString());

                GetSumBind(row.Cells["ColSubscribeID"].Value.ToString(), out bindArea, out bindAmount);

                sumBindArea += bindArea;
                sumBindAmount += bindAmount;
            }

            textBox_countItem.Text = countItem.ToString();
            textBox_TotalAmount.Text = sumTotalAmount.ToString("F0");
            textBox_sumArea.Text = sumArea.ToString("F2");
            textBox_sumAmount.Text = sumAmount.ToString("F0");
            textBox_BindArea.Text = sumBindArea.ToString("F2");
            textBox_BindAmount.Text = sumBindAmount.ToString("F0");
        }

        private void  GetSumBind(string subscribeID, out double area, out double amount)
        {
            area = 0;
            amount = 0;
            string sql = string.Format("select ISNULL(SUM(Area),0) area, ISNULL(SUM(amount),0) amount from  SubscribeDetail where IsBind = 1 and SubscribeID = {0}", subscribeID);

            DataTable dt = SqlHelper.ExecuteDataTable(sql);

            area = Convert.ToDouble(dt.Rows[0]["area"]);
            amount = Convert.ToDouble(dt.Rows[0]["amount"]);
        }


        private void toolStripButton_Rename_Click(object sender, EventArgs e)
        {
            if (dataGridView_Subscribe.CurrentRow == null)
            {
                Prompt.Warning("未选择相应的记录！");
                return;
            }

            FrmRename rename = new FrmRename();
            rename.OperType = OperationType.subscribe;
            rename.AgreementID = dataGridView_Subscribe.CurrentRow.Cells["ColSubscribeID"].Value.ToString();
            rename.CustomerID = dataGridView_Subscribe.CurrentRow.Cells["ColCustomerID"].Value.ToString();
            if (rename.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                dataGridView_Subscribe.CurrentRow.Cells["ColCustomerID"].Value = rename.NewCustomer.CustomerID;
                dataGridView_Subscribe.CurrentRow.Cells["ColCustomerName"].Value = rename.NewCustomer.CustomerName;
                dataGridView_Subscribe.CurrentRow.Cells["ColCustomerPhone"].Value = rename.NewCustomer.Phone;
                Prompt.Information("操作成功，数据已更新！");
            }
        }

        private void toolStripButton_Back_Click(object sender, EventArgs e)
        {
            if (dataGridView_Subscribe.CurrentRow == null)
            {
                Prompt.Warning("未选择相应的记录！");
                return;
            }

            FrmReturn frmReturn = new FrmReturn();
            string sql = string.Format("select ISNULL(SUM(Amount),0) from Receipt where SubscribeID = {0}", dataGridView_Subscribe.CurrentRow.Cells["ColSubscribeID"].Value.ToString());
            frmReturn.ReceiptAmount = string.Format("{0:F0}", SqlHelper.ExecuteScalar(sql));

            if (frmReturn.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (ReturnHouse(frmReturn.IsRefund, frmReturn.ReturnDate, frmReturn.ReturnMemo))
                {
                    dataGridView_Subscribe.Rows.RemoveAt(dataGridView_Subscribe.CurrentRow.Index);
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

                string subscribeId = dataGridView_Subscribe.CurrentRow.Cells["ColSubscribeID"].Value.ToString();
                string salesId = dataGridView_Subscribe.CurrentRow.Cells["ColSalesID"].Value.ToString();
                string salesName = dataGridView_Subscribe.CurrentRow.Cells["ColSalesName"].Value.ToString();

                try
                {
                    //更新主表
                    if (isRefund)
                        cmd.CommandText = string.Format("update SubscribeMain set ReturnDate = '{0}', RefundDate = '{0}', ReturnReason = '{1}' where SubscribeID = {2}", returnDate, returnMemo, subscribeId);
                    else
                        cmd.CommandText = string.Format("update SubscribeMain set ReturnDate = '{0}', ReturnReason = '{1}' where SubscribeID = {2}", returnDate, returnMemo, subscribeId);

                    cmd.ExecuteNonQuery();

                    //更新销售状态
                    cmd.CommandText = string.Format("update SaleItem set SaleStateCode = {0}, SaleStateName = '{1}' where ItemID in (select ItemID From SubscribeDetail where SubscribeID = {2})", (int)ItemSaleState.待售, ItemSaleState.待售, subscribeId);
                    cmd.ExecuteNonQuery();

                    string strValues = string.Empty;

                    //退款
                    if (isRefund)
                    {
                        cmd.CommandText = string.Format("select ISNULL(SUM(Amount),0) from Receipt where  SubscribeID = {0} and TypeCode != {1}", subscribeId, (int)Receivables.退房);
                        string refund = "-" + cmd.ExecuteScalar().ToString();

                        strValues = subscribeId + "," + Login.User.ProjectID + "," + refund + ",'" + returnDate + "'," + (int)Receivables.退房 + ",'" + Receivables.退房 + "','" + returnMemo + "'," + salesId + ",'" + salesName + "',GETDATE(),'" + Login.User.UserName + "'";
                        cmd.CommandText = string.Format("insert into Receipt (SubscribeID,ProjectID,Amount,RecDate,TypeCode,TypeName,Memo,SalesID,SalesName,MakeDate,Maker) values ({0})", strValues);
                        cmd.ExecuteNonQuery();
                    }

                    //添加操作记录
                    strValues = subscribeId + ",'" + OperationType.subscribe + "','" + returnDate + "','" + returnMemo + "'," + (isRefund ? "1" : "0") + "," + salesId + ",'" + salesName + "','" + Login.User.UserName + "',GETDATE()";
                    cmd.CommandText = string.Format("insert into ItemReturn (AgreementID, OperationType, ReturnDate,Memo,IsRefund,SalesID, SalesName, MakeUserName,MakeDate) values ({0})", strValues);
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

        private void dataGridView_Subscribe_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ViewSubscribe();
            }
        }

        private void toolStripButton_Export_Click(object sender, EventArgs e)
        {
            Common.Exp2XLS(dataGridView_Subscribe);
        }

        private void toolStripButton_Delay_Click(object sender, EventArgs e)
        {
            if (dataGridView_Subscribe.CurrentRow == null)
            {
                Prompt.Warning("未选择相应的记录！");
                return;
            }

            FrmDelay delay = new FrmDelay();
            string subscribeId = dataGridView_Subscribe.CurrentRow.Cells["ColSubscribeID"].Value.ToString();
            delay.ContractDate = dataGridView_Subscribe.CurrentRow.Cells["ColLastContractDate"].Value.ToString();

            if (delay.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string sql = string.Format("update SubscribeMain set LastContractDate = '{0}' where SubscribeID = {1}", delay.DelayDate, subscribeId);
                if (SqlHelper.ExecuteNonQuery(sql) > 0 )
                {
                    dataGridView_Subscribe.CurrentRow.Cells["ColLastContractDate"].Value = delay.DelayDate;
                    Prompt.Information("操作成功！数据已更新。");
                }
                  
            }
        }

    }
}
