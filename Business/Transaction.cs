using Commission.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Commission.Business
{
    public class Transaction
    {

        /// <summary>
        /// 通过付款方式ID获取付款类型
        /// </summary>
        /// <param name="paymentId"></param>
        /// <returns></returns>
        public static int GetPayType(string paymentId)
        {
            string sql = string.Format("select IsNull(PayType,0) from PaymentMode where ID = {0}", paymentId);
            int result = int.Parse(SqlHelper.ExecuteScalar(sql).ToString());
            return result;
        }


        public static bool isChecked(string sid)
        {
            bool result = false;

            string sql = string.Format("select isnull(count(SID),0) from SettleMain where Checker is not null and SID = {0}", sid);
            int sqlResult = int.Parse(SqlHelper.ExecuteScalar(sql).ToString());
            if (sqlResult > 0)
            {
                result = true;
            }
            return result;
        }

        public static DataTable genCol(DataGridView dgv, int insIndex,string sql)
        {
            DataTable dt;

            int insColCount = getMaxRec();

            genGridCol(dgv, insIndex, insColCount);

            dt = genDataTableCol(sql, insColCount);

            return dt;
        }

        //获取单个业务中储藏间的最大数量
        private static int getMaxRec()
        {
            int result = 0;

            string sql = "select isnull(max(a.cnt),0) from (select COUNT(ContractCode) as cnt from V_TransactionBase  where ItemType = 3  group by ContractCode) a";

            int.TryParse(SqlHelper.ExecuteScalar(sql).ToString(), out result);

            return result;
        }


        /// <summary>
        /// 构建DataGridView的动态字段-储藏间
        /// </summary>
        /// <param name="newFiledCount"></param>
        /// <returns></returns>
        private static void genGridCol(DataGridView dgv, int insColIndex, int insColCount)
        {
            //清空重复字段
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                string sItemNum = "ItemNum" + i.ToString();
                for (int m = 0; m < dgv.ColumnCount; m++)
                {
                    if (dgv.Columns[m].Name == sItemNum)
                    {
                        dgv.Columns.Remove(sItemNum);
                        break;
                    }
                }

                string sArea = "Area" + i.ToString();
                for (int m = 0; m < dgv.ColumnCount; m++)
                {
                    if (dgv.Columns[m].Name == sArea)
                    {
                        dgv.Columns.Remove(sArea);
                        break;
                    }
                }

                string sPrice = "Price" + i.ToString();
                for (int m = 0; m < dgv.ColumnCount; m++)
                {
                    if (dgv.Columns[m].Name == sPrice)
                    {
                        dgv.Columns.Remove(sPrice);
                        break;
                    }
                }

                string sAmount = "Amount" + i.ToString();
                for (int m = 0; m < dgv.ColumnCount; m++)
                {
                    if (dgv.Columns[m].Name == sAmount)
                    {
                        dgv.Columns.Remove(sAmount);
                        break;
                    }
                }
            }


            for (int i = 0; i < insColCount; i++)
            {
                //房号
                string sItemNum = "ItemNum" + i.ToString();

                DataGridViewTextBoxColumn itemNum = new DataGridViewTextBoxColumn();
                itemNum.Name = sItemNum;
                itemNum.DataPropertyName = sItemNum;
                itemNum.HeaderText = "储藏间号" + i.ToString();
                dgv.Columns.Insert(insColIndex++, itemNum);


                //面积
                string sArea = "Area" + i.ToString();

                DataGridViewTextBoxColumn area = new DataGridViewTextBoxColumn();
                area.Name = sArea;
                area.DataPropertyName = sArea;
                area.HeaderText = "面积" + i.ToString();
                area.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                area.DefaultCellStyle.Format = "F2";
                dgv.Columns.Insert(insColIndex++, area);


                //单价
                string sPrice = "Price" + i.ToString();

                DataGridViewTextBoxColumn price = new DataGridViewTextBoxColumn();
                price.Name = sPrice;
                price.DataPropertyName = sPrice;
                price.HeaderText = "单价" + i.ToString();
                price.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                price.DefaultCellStyle.Format = "F0";
                dgv.Columns.Insert(insColIndex++, price);


                //金额
                string sAmount = "Amount" + i.ToString();

                DataGridViewTextBoxColumn amount = new DataGridViewTextBoxColumn();
                amount.Name = sAmount;
                amount.DataPropertyName = sAmount;
                amount.HeaderText = "金额" + i.ToString();
                amount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                amount.DefaultCellStyle.Format = "F0";
                dgv.Columns.Insert(insColIndex++, amount);
            }
        }


        /// <summary>
        /// 构建DataTable的动态字段
        /// </summary>
        /// <param name="newFiledCount"></param>
        /// <returns></returns>
        private static DataTable genDataTableCol(string sql, int insColCount)
        {
            //仅需要字段（列），用于生成DataTable的字段结构

            DataTable dt = SqlHelper.ExecuteDataTable(sql);

            for (int i = 0; i < insColCount; i++)
            {
                //房号
                string sItemNum = "ItemNum" + i.ToString();
                dt.Columns.Add(sItemNum, typeof(string));


                //面积
                string sArea = "Area" + i.ToString();
                dt.Columns.Add(sArea, typeof(string));

                //单价
                string sPrice = "Price" + i.ToString();
                dt.Columns.Add(sPrice, typeof(string));

                //金额
                string sAmount = "Amount" + i.ToString();
                dt.Columns.Add(sAmount, typeof(string));
            }

            return dt;
        }

        /// <summary>
        /// 生成签约数据并显示
        /// </summary>
        /// <param name="condition"></param>
        public static void getContract(string condition, DataGridView dgv, bool isChoose = false)
        {
            DataTable tabContract;
            int newColNumer = getMaxRec();
            int addColIndex = dgv.Columns["ColAmount"].Index + 1;


            //固定显示的字段列 -- 与填充的数据保持一致
            string sqlField;

            if (isChoose)
                sqlField = "select '' as Choose, TID, ContractCode ,ProjectName, CustomerName, Phone1, "
                + " ItemTypeName, Building, Unit, ItemNum, Area, Price ,Amount, TotalAmount,Loan,ContractDate,SalesName "
                + " from V_TransactionBase where 1 = 2 ";
            else
                sqlField = "select TID, ContractCode ,ProjectName, CustomerName, Phone1, "
                + " ItemTypeName, Building, Unit, ItemNum, Area, Price ,Amount, TotalAmount,Loan,ContractDate,SalesName "
                + " from V_TransactionBase where 1 = 2 ";

            ////和dataGridView列
            genGridCol(dgv, addColIndex, newColNumer);


            //生成DataTable结构
            tabContract = genDataTableCol(sqlField, newColNumer);
            
            
            //按条件查询业务号和合同号,再以查询结果为条件查询获取主从表信息填充到DataTable中，并以dataGridView显示
            string sql = "select distinct TID,ContractCode "
                + " from V_TransactionBase "
                + " where TransState = " + ((int)ItemSaleState.签约).ToString()
                + condition;

            //填充数据
            SqlDataReader sdr = SqlHelper.ExecuteReader(sql);
            while (sdr.Read())
            {
                DataRow dr = tabContract.NewRow();

                //业务信息--主表
                string sqlTrans;
                if (isChoose)
                    sqlTrans = "select '0' as Choose, TID, ContractCode ,ProjectName, CustomerName, Phone1, TotalAmount,Loan,ContractDate,SalesName from [V_TransactionBase] where TID = " + sdr["TID"].ToString() + " and ContractCode = '" + sdr["ContractCode"].ToString() + "'";
                else
                    sqlTrans = "select TID, ContractCode ,ProjectName, CustomerName, Phone1, TotalAmount,Loan,ContractDate,SalesName from [V_TransactionBase] where TID = " + sdr["TID"].ToString() + " and ContractCode = '" + sdr["ContractCode"].ToString() + "'";
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
                        //dr[fieldName] = sdrDetail_Store.GetValue(i);
                        if ((sdrDetail_Store.GetName(i).ToString() == "Price") || (sdrDetail_Store.GetName(i).ToString() == "Amount"))
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

                tabContract.Rows.Add(dr);
            }

            dgv.DataSource = tabContract;

            if (tabContract.Rows.Count == 0)
            {
                Prompt.Information("没有符合条件的记录！");
            }
        }



        public static void getContractConfirm(string condition, DataGridView dgv, bool isPrompt = true)
        {
            DataTable tabContract;
            int newColNumer = getMaxRec();
            int addColIndex = dgv.Columns["ColAmount"].Index + 1;


            //固定显示的字段列 -- 与填充的数据保持一致
            string sqlField;

            sqlField = "select '' as Choose, TID, ContractCode ,ProjectName, CustomerName, Phone1, "
            + " ItemTypeName, Building, Unit, ItemNum, Area, Price ,Amount, TotalAmount,Loan,ContractDate,SalesName "
            + " from V_TransactionBase where 1 = 2 ";

            ////和dataGridView列
            genGridCol(dgv, addColIndex, newColNumer);


            //生成DataTable结构
            tabContract = genDataTableCol(sqlField, newColNumer);


            //按条件查询业务号和合同号,再以查询结果为条件查询获取主从表信息填充到DataTable中，并以dataGridView显示
            string sql = "select distinct TID,ContractCode,isnull(TotalAmount,0) TotalAmount "
                + " from V_TransactionBase "
                + " where TransState = " + ((int)ItemSaleState.签约).ToString()
                + condition;

            //填充数据
            SqlDataReader sdr = SqlHelper.ExecuteReader(sql);
            while (sdr.Read())
            {
                string tid = sdr["TID"].ToString();
                string contractCode = sdr["ContractCode"].ToString();
                double totalAmount = double.Parse(sdr["TotalAmount"].ToString());

                double receipt = getReceiptAll(tid);

                if (receipt < totalAmount)  //累计收款小于合同金额，未交清款项，无法确权。
                    continue;
                

                DataRow dr = tabContract.NewRow();

                //业务信息--主表
                string sqlTrans = "select '0' as Choose, TID, ContractCode ,ProjectName, CustomerName, Phone1, TotalAmount,Loan,ContractDate,SalesName from [V_TransactionBase] where TID = " + tid + " and ContractCode = '" + contractCode + "'";
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
                        //dr[fieldName] = sdrDetail_Store.GetValue(i);
                        if ((sdrDetail_Store.GetName(i).ToString() == "Price") || (sdrDetail_Store.GetName(i).ToString() == "Amount"))
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

                tabContract.Rows.Add(dr);
            }

            dgv.DataSource = tabContract;

            if (isPrompt)
            {
                if (tabContract.Rows.Count == 0)
                {
                    Prompt.Information("没有符合条件的记录！");
                }
            }

        }


        /// <summary>
        /// 累计收款
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        private static double getReceiptAll(string tid)
        {
            string sqlReceipt = string.Format("select isnull(sum(Amount),0) from Receipt where TID = {0}", tid);

            double receipt = 0;
            double.TryParse(SqlHelper.ExecuteScalar(sqlReceipt).ToString(), out receipt);

            return receipt;
        }

        /// <summary>
        /// 是否已经存在合同号
        /// </summary>
        /// <param name="projectID"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool isExistCode(string number, bool isContract = true)
        {
            string sql = string.Empty;
            if (isContract)
            {
                sql = string.Format("select count(*) from [ContractMain] where projectID = {0} and ContractNum = '{1}'", Login.User.ProjectID, number);
            }
            else
            {
                sql = string.Format("select count(*) from [SubscribeMain] where projectID = {0} and SubscribeNum = '{1}'", Login.User.ProjectID, number);
            }
            int sqlResult = int.Parse(SqlHelper.ExecuteScalar(sql).ToString());
            if (sqlResult > 0)
                return true;

            return false;
        }


        public static DataTable GetContractBaseData(string condition, out int iBindQuantity)
        {
            iBindQuantity = 0;
            string formatAmount = "{0:F" + Login.Parameters.PrecisionAmount + "}";
            string sql = string.Empty;

            sql = "select  ContractMain.ContractID, CustomerName, CustomerPhone, ItemTypeName, "
                + " Building, Unit, ItemNum, Area, Price, Amount, DownPayAmount, Loan, TotalAmount, ContractDate, SalesName "
                + " from ContractMain "
                + " inner join  ContractDetail on ContractMain.ContractID = ContractDetail.ContractID "
                + " where ProjectID = " + Login.User.ProjectID + " and  IsBind = 0 " + condition
                + " order by ContractDetail.ContractID ";

            DataTable dtContract = SqlHelper.ExecuteDataTable(sql); //主体表

            dtContract.PrimaryKey = new DataColumn[] { dtContract.Columns["ContractID"] };


            //获取绑定（附属）物业相关信息
            for (int i = 0; i < dtContract.Rows.Count; i++)
            {
                string subId = dtContract.Rows[i]["ContractID"].ToString();

                sql = "select ItemNum, Area, Price, Amount from ContractDetail where IsBind = 1 and ContractID = " + subId;

                SqlDataReader dr = SqlHelper.ExecuteReader(sql);

                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();

                    dt.Columns.Add("ContractID", typeof(int));
                    dt.PrimaryKey = new DataColumn[] { dt.Columns["ContractID"] };

                    string fieldValue = subId;


                    int itemIdx = 0;     //一个房源相同尾号
                    while (dr.Read())
                    {
                        for (int j = 0; j < dr.FieldCount; j++) //????考虑：不在重新创建表和字段，主表一次合并，提高效率??
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

                        if (itemIdx > iBindQuantity)
                            iBindQuantity = itemIdx;
                    }

                    string[] strArray = fieldValue.Split(',');

                    dt.Rows.Add(strArray);

                    dtContract.Merge(dt, false, MissingSchemaAction.Add); //合并至主体表
                }
            }

            return dtContract;
        }



        public static DataTable GetContractDataEx(string condition, out int iBindQuantity, bool isChooce = false)
        {
            iBindQuantity = 0;
            string formatAmount = "{0:F" + Login.Parameters.PrecisionAmount + "}";
            string choose = isChooce ? " 'false' as Choose, " : "";
            string sql = string.Empty;

            sql = "select " + choose + "ContractMain.ContractID, CustomerID, CustomerName, CustomerPhone, ItemTypeName, "
                + " Building, Unit, ItemNum, Area, Price, Amount, DownPayAmount, Loan, TotalAmount, ContractDate, SalesID, SalesName, "
                + " ExtField0, ExtField1, ExtField2, ExtField3, ExtField4, ExtField5, ExtField6, ExtField7, ExtField8, ExtField9 "
                + " from ContractMain "
                + " inner join  ContractDetail on ContractMain.ContractID = ContractDetail.ContractID "
                + " where ReturnDate is null and ProjectID = " + Login.User.ProjectID + " and  IsBind = 0 " + condition
                + " order by ContractMain.ContractID ";

            DataTable dtContract = SqlHelper.ExecuteDataTable(sql); //主体表

            dtContract.PrimaryKey = new DataColumn[] { dtContract.Columns["ContractID"] };


            //获取绑定（附属）物业相关信息
            for (int i = 0; i < dtContract.Rows.Count; i++)
            {
                string subId = dtContract.Rows[i]["ContractID"].ToString();

                sql = "select ItemNum, Area, Price, Amount from ContractDetail where IsBind = 1 and ContractID = " + subId;

                SqlDataReader dr = SqlHelper.ExecuteReader(sql);

                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();

                    dt.Columns.Add("ContractID", typeof(int));
                    dt.PrimaryKey = new DataColumn[] { dt.Columns["ContractID"] };

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

                        if (itemIdx > iBindQuantity)
                            iBindQuantity = itemIdx;
                    }

                    string[] strArray = fieldValue.Split(',');

                    dt.Rows.Add(strArray);

                    dtContract.Merge(dt, false, MissingSchemaAction.Add); //合并至主体表
                }
            }

            return dtContract;
        }


        /// <summary>
        /// 增加DataGridView的绑定字段
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="iBeginPos">插入的开始位置</param>
        /// <param name="iColQuantity">列(组)数量</param>
        public static void InsertBindCol(DataGridView dgv, int iBeginPos, int iColQuantity)
        {
            Common.SetColumnStyle(dgv.Columns["ColArea"], ColType.area);
            Common.SetColumnStyle(dgv.Columns["ColPrice"], ColType.price);

            Common.SetColumnStyle(dgv.Columns["ColAmount"], ColType.amount);
            Common.SetColumnStyle(dgv.Columns["ColDownPayAmount"], ColType.amount);
            Common.SetColumnStyle(dgv.Columns["ColLoan"], ColType.amount);
            Common.SetColumnStyle(dgv.Columns["ColTotalAmount"], ColType.amount); 

            if (iColQuantity <= 0)
                return;


            if (dgv.DataSource != null)
            {
                DataTable dt = (DataTable)dgv.DataSource;
                dt.Rows.Clear();
                dgv.DataSource = dt; 
            }


            //删除BIND列
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                if (dgv.Columns[i].Name.Substring(0, 5) == "BIND_")
                {
                    dgv.Columns.Remove(dgv.Columns[i].Name);
                    i--; //列减少，索引不变
                }
            }

            //增加BIND字段
            for (int i = 0; i < iColQuantity; i++)
            {
                //房号
                string sItemNum = "BIND_ItemNum" + i.ToString();

                DataGridViewTextBoxColumn itemNum = new DataGridViewTextBoxColumn();
                itemNum.Name = sItemNum;
                itemNum.DataPropertyName = sItemNum;
                itemNum.HeaderText = "储藏间号" + i.ToString();
                dgv.Columns.Insert(iBeginPos++, itemNum);


                //面积
                string sArea = "BIND_Area" + i.ToString();

                DataGridViewTextBoxColumn area = new DataGridViewTextBoxColumn();
                area.Name = sArea;
                area.DataPropertyName = sArea;
                area.HeaderText = "面积" + i.ToString();
                area.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                area.DefaultCellStyle.Format = "F2";
                dgv.Columns.Insert(iBeginPos++, area);


                //单价
                string sPrice = "BIND_Price" + i.ToString();

                DataGridViewTextBoxColumn price = new DataGridViewTextBoxColumn();
                price.Name = sPrice;
                price.DataPropertyName = sPrice;
                price.HeaderText = "单价" + i.ToString();
                price.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                price.DefaultCellStyle.Format = "F4";
                dgv.Columns.Insert(iBeginPos++, price);


                //金额
                string sAmount = "BIND_Amount" + i.ToString();

                DataGridViewTextBoxColumn amount = new DataGridViewTextBoxColumn();
                amount.Name = sAmount;
                amount.DataPropertyName = sAmount;
                amount.HeaderText = "金额" + i.ToString();
                amount.DefaultCellStyle.Format = "F0";
                amount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Columns.Insert(iBeginPos++, amount);
            }
        }



    }
}
