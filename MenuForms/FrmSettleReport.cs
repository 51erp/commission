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
    public partial class FrmSettleReport : Form
    {

        private string ProjectID = string.Empty;
        private string Period = string.Empty;
        DataTable dtRate;
        public DataRow[] drRate;

        public FrmSettleReport()
        {
            InitializeComponent();
            comboBox_CheckState.SelectedIndex = 0;
            dtRate = SqlHelper.ExecuteDataTable("select Code, Name, Rate from PerformanceRate");
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Detail_Click(object sender, EventArgs e)
        {
            ShowDetailForm();
        }

        private void ShowDetailForm()
        {
            if ((dataGridView_SettleMain.Rows.Count == 0) || (dataGridView_SettleMain.CurrentRow == null))
            {
                Prompt.Warning("没有选择记录！");
                return;
            }

            int rowIdx = dataGridView_SettleMain.CurrentRow.Index;

            if (rowIdx != -1)
            {
                FrmSettleDetail detail = new FrmSettleDetail();

                detail.RepSettle.Add("SettleID", dataGridView_SettleMain.CurrentRow.Cells["ColSettleID"].Value.ToString());
                detail.RepSettle.Add("ProjectID", dataGridView_SettleMain.CurrentRow.Cells["ColProjectID"].Value.ToString());
                detail.RepSettle.Add("ProjectName", dataGridView_SettleMain.CurrentRow.Cells["ColProjectName"].Value.ToString());
                detail.RepSettle.Add("TableName", dataGridView_SettleMain.CurrentRow.Cells["ColTableName"].Value.ToString());
                detail.RepSettle.Add("TableMaker", dataGridView_SettleMain.CurrentRow.Cells["ColTableMaker"].Value.ToString());
                detail.RepSettle.Add("SettleDate", dataGridView_SettleMain.CurrentRow.Cells["ColSettleDate"].FormattedValue.ToString());
                detail.RepSettle.Add("SettlePeriod", dataGridView_SettleMain.CurrentRow.Cells["ColSettlePeriod"].Value.ToString());
                detail.RepSettle.Add("Checker", dataGridView_SettleMain.CurrentRow.Cells["ColChecker"].Value.ToString());
                detail.RepSettle.Add("CheckDate", dataGridView_SettleMain.CurrentRow.Cells["ColCheckDate"].FormattedValue.ToString());

                detail.ShowDialog();

                dataGridView_SettleMain.CurrentRow.Cells["ColChecker"].Value = detail.RepSettle["Checker"];
                dataGridView_SettleMain.CurrentRow.Cells["ColCheckDate"].Value = detail.RepSettle["CheckDate"];
            }
        }


        private void button_Search_Click(object sender, EventArgs e)
        {
            Period = dateTimePicker_Period.Text;

            string condition = "SettlePeriod  = '" + Period + "'";

            if (comboBox_CheckState.Text == "未审")
            {
                condition += " and Checker is null";
            }else if (comboBox_CheckState.Text == "已审")
            {
                condition += " and Checker is not null";
            }

            string sql = string.Format("select SettleID, TableName, ProjectID, ProjectName,SettlePeriod,SettleDate,TableMaker,Checker,CheckDate, case Performance when 0 then '无' else '有' end Performance from SettleMain where ProjectID = {0}  and {1} order by ProjectID", Login.User.ProjectID, condition);

            dataGridView_SettleMain.DataSource = SqlHelper.ExecuteDataTable(sql);

            if (dataGridView_SettleMain.Rows.Count == 0)
                Prompt.Information("未查询到符合条件的记录！");

        }

        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {
            //业绩报表是否要删除

            if ((dataGridView_SettleMain.Rows.Count == 0) || (dataGridView_SettleMain.CurrentRow == null))
            {
                Prompt.Warning("没有选择记录！");
                return;
            }


            if (!dataGridView_SettleMain.CurrentRow.Cells["ColChecker"].Value.ToString().Equals(""))
            {
                Prompt.Warning("结算已经审核无法删除！");
                return;
            }


            int rowIdx = dataGridView_SettleMain.CurrentRow.Index;

            if (rowIdx != -1)
            {
                if (MessageBox.Show("确认要删除选择的记录？","", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    using (SqlConnection connection = SqlHelper.OpenConnection())  //创建连接对象 
                    {
                        SqlTransaction sqlTran = connection.BeginTransaction();    //开始事务 
                        SqlCommand cmd = connection.CreateCommand();               //创建SqlCommand对象 
                        cmd.Transaction = sqlTran;                                 //将SqlCommand与SqlTransaction关联起

                        try
                        {
                            string settleID = dataGridView_SettleMain.CurrentRow.Cells["ColSettleID"].Value.ToString();
                            string sql = "delete SettleMain where SettleID = " + settleID;
                            SqlHelper.ExecuteNonQuery(sql);

                            sql = "delete SettleDetail where SettleID = " + settleID;
                            SqlHelper.ExecuteNonQuery(sql);

                            sql = "update Receipt set SettleState = 0 where SettleState = " + settleID;
                            SqlHelper.ExecuteNonQuery(sql);

                            sql = "update Installment set Settled = 0 where Settled = " + settleID;
                            SqlHelper.ExecuteNonQuery(sql);

                            sqlTran.Commit();  //事务提交
                            connection.Close();

                            dataGridView_SettleMain.Rows.RemoveAt(rowIdx);

                            Prompt.Information("操作成功!");

                        }
                        catch (Exception ex)
                        {
                            sqlTran.Rollback();  //异常事务回滚
                            Prompt.Error("操作失败， 错误：" + ex.Message);
                        }
                    }
                
                }
            }
        }

        private void dataGridView_SettleMain_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ShowDetailForm();
        }

        private void toolStripButton_Restore_Click(object sender, EventArgs e)
        {
            if ((dataGridView_SettleMain.Rows.Count == 0) || (dataGridView_SettleMain.CurrentRow == null))
            {
                Prompt.Warning("没有选择记录！");
                return;
            }


            if (dataGridView_SettleMain.CurrentRow.Cells["ColChecker"].Value.ToString().Equals(""))
            {
                Prompt.Warning("记录未审核！");
                return;
            }

            if (MessageBox.Show("确定要进行反审操作？", Common.MsgCaption,  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string settleId = dataGridView_SettleMain.CurrentRow.Cells["ColSettleID"].Value.ToString();
                string sql = string.Format("update SettleMain set Checker = null, CheckDate = null where SettleID = {0}", settleId);
                if (SqlHelper.ExecuteNonQuery(sql) > 0)
                {
                    dataGridView_SettleMain.CurrentRow.Cells["ColChecker"].Value = "";
                    dataGridView_SettleMain.CurrentRow.Cells["ColCheckDate"].Value = "";
                }
            }


        }

        private void toolStripButton_Performance_Click(object sender, EventArgs e)
        {
            if ((dataGridView_SettleMain.Rows.Count == 0) || (dataGridView_SettleMain.CurrentRow == null))
            {
                Prompt.Warning("没有选择记录！");
                return;
            }


            if (dataGridView_SettleMain.CurrentRow.Cells["ColChecker"].Value.ToString().Equals(""))
            {
                Prompt.Warning("记录未审核！");
                return;
            }

            if (dataGridView_SettleMain.CurrentRow.Cells["ColPerformance"].Value.ToString().Equals("有"))
            {
                Prompt.Warning("业绩报表已存在，无法再次生成！");
                return;
            }


            Performance();

            dataGridView_SettleMain.CurrentRow.Cells["ColPerformance"].Value = "有";

            SqlHelper.ExecuteNonQuery(string.Format("update SettleMain set Performance = 1 where SettleID = {0}", dataGridView_SettleMain.CurrentRow.Cells["ColSettleID"].Value.ToString()));

            Prompt.Information("操作完成，业绩报表已生成！");

        }

        private void Performance()
        {
            string settleId = dataGridView_SettleMain.CurrentRow.Cells["ColSettleID"].Value.ToString();
            string sql = string.Format("select ID, SettleID, ContractID, ItemTypeCode, ItemTypeName, SubscribeDate, SubscribeSalesID,SubscribeSalesName, ReceiptDate, SalesID, SalesName, RecSettleTotal, FirstSettle from SettleDetail where SettleID = {0}", settleId);

            DataTable dtSettleDetail = SqlHelper.ExecuteDataTable(sql);

            foreach (DataRow drSettle in dtSettleDetail.Rows)
            {
                double rate = 0;

                if (drSettle["FirstSettle"].ToString().Equals("1")) //成销
                {
                    PerformanceType performanceType = GetSalesPerformanceType(drSettle["SubscribeSalesID"].ToString(), drSettle["SalesID"].ToString());

                    switch (performanceType)
                    {
                        case PerformanceType.own:  //个人
                            SalesPerformance(drSettle, Receivables.成销, 100, performanceType);
                            break;

                        case PerformanceType.allot: //分配
                            drRate = dtRate.Select("Code = 1"); //allot
                            rate = double.Parse(drRate[0]["Rate"].ToString());

                            SalesPerformance(drSettle, Receivables.成销, rate, performanceType);

                            break;
                        case PerformanceType.hold: //调岗
                            drRate = dtRate.Select("Code = 2"); //hold

                            rate = double.Parse(drRate[0]["Rate"].ToString());

                            SalesPerformance(drSettle, Receivables.成销, rate,performanceType, true);


                            drRate = dtRate.Select("Code = 3"); //takeover

                            rate = double.Parse(drRate[0]["Rate"].ToString());

                            SalesPerformance(drSettle, Receivables.成销, rate, performanceType);

                            break;
                    }

                    string deptID = GetDeptID(drSettle["SalesID"].ToString(),drSettle["ReceiptDate"].ToString());

                    MngPerformance(drSettle, Receivables.成销, deptID, drSettle["SalesID"].ToString());

                }
                else
                {
                    sql = string.Format("select a.ID, a.SettleID, ItemTypeCode, ItemTypeName, SubscribeDate, SubscribeSalesID,SubscribeSalesName,"
                        + "b.SalesID, b.SalesName, RecDate as ReceiptDate, b.Amount as RecSettleTotal,TypeCode from SettleDetail a "
                        + "inner join Receipt b on a.ContractID = b.ContractID and a.SettleID = b.SettleState " 
                        + "where a.ContractID = {0} and SettleState = {1}", drSettle["ContractID"].ToString(), settleId);

                    DataTable dtReceipt = SqlHelper.ExecuteDataTable(sql);

                    foreach (DataRow drReceipt in dtReceipt.Rows)
                    {
                        PerformanceType performanceType = GetSalesPerformanceType(drReceipt["SubscribeSalesID"].ToString(), drReceipt["SalesID"].ToString());

                        Receivables recType = (Receivables)int.Parse(drReceipt["TypeCode"].ToString());

                        switch (performanceType)
                        {
                            case PerformanceType.own:  //个人
                                SalesPerformance(drReceipt, recType, 100, performanceType);
                                break;

                            case PerformanceType.allot: //分配
                                drRate = dtRate.Select("Code = 1"); //allot
                                rate = double.Parse(drRate[0]["Rate"].ToString());

                                SalesPerformance(drReceipt, recType, rate, performanceType);

                                break;
                            case PerformanceType.hold: //调岗
                                drRate = dtRate.Select("Code = 2"); //hold

                                rate = double.Parse(drRate[0]["Rate"].ToString());

                                SalesPerformance(drReceipt, recType, rate, performanceType,true);


                                drRate = dtRate.Select("Code = 3"); //takeover

                                rate = double.Parse(drRate[0]["Rate"].ToString());

                                SalesPerformance(drReceipt, recType, rate, performanceType);

                                break;
                        }

                        string deptID = GetDeptID(drReceipt["SalesID"].ToString(), drSettle["ReceiptDate"].ToString());

                        MngPerformance(drReceipt, recType, deptID, drReceipt["SalesID"].ToString());

                    }
                }
            }
        }


        /// <summary>
        /// 计算业务员业绩
        /// </summary>
        /// <param name="row"></param>
        /// <param name="recType"></param>
        /// <param name="rate"></param>
        /// <param name="isHold"></param>
        private void SalesPerformance(DataRow row, Receivables recType, double rate, PerformanceType type, bool isHold = false)
        {
            string sql = string.Empty;
            string salesID = string.Empty;
            string salesName = string.Empty;
            string deptID = string.Empty;

            deptID = GetDeptID(row["SalesID"].ToString(), row["ReceiptDate"].ToString()); //调岗时认购业务员也默认此部门，目前此字段无用

            if (isHold)
            {
                salesID = row["SubscribeSalesID"].ToString();
                salesName = row["SubscribeSalesName"].ToString();
            }
            else
            {
                salesID = row["SalesID"].ToString();
                salesName = row["SalesName"].ToString();
            }

            string performance = Math.Round(double.Parse(row["RecSettleTotal"].ToString()) * rate / 100, 0, MidpointRounding.AwayFromZero).ToString();

            sql = "insert into PerformanceDetail (SettleDID,SettleID,SalesID,SalesName,DeptID,ReceiptDate, "
                + "ReceiptTypeCode,ReceiptTypeName,ItemTypeCode,ItemTypeName,ReceiptAmount,Performance,PerformanceType,SalesType) "
                + " values ( "
                + row["ID"].ToString()
                + "," + row["SettleID"].ToString()
                + "," + salesID
                + ",'" + salesName + "'"
                + "," + deptID
                + ",'" + row["ReceiptDate"].ToString() + "'"
                + "," + (int)recType
                + ",'" + recType + "'"
                + "," + row["ItemTypeCode"].ToString()
                + ",'" + row["ItemTypeName"].ToString() + "'"
                + "," + row["RecSettleTotal"].ToString()
                + "," + performance
                + "," + (int)type
                + ",'员工'"
                + ")";

            SqlHelper.ExecuteNonQuery(sql);
        }


        private void MngPerformance(DataRow row, Receivables recType, string deptID, string recSalesID)
        {
            string sql = string.Empty;
            string salesID = string.Empty;
            string salesName = string.Empty;
            

            
            string recDate = row["ReceiptDate"].ToString();

            //主管ID
            sql = string.Format("select SalesID, SalesName from JobTrack where JobType = '主管' and DeptID = {0} and ((BeginDate <= '{1}' and EndDate > '{1}') or (BeginDate <= '{1}' and EndDate is null))", deptID, recDate);
            DataTable dtMng = SqlHelper.ExecuteDataTable(sql);

            foreach (DataRow dr in dtMng.Rows)
            {

                salesID = dr["SalesID"].ToString();
                salesName = dr["SalesName"].ToString();

                if (salesID == recSalesID)
                {
                    continue; //主管与员工为同一人时，不计算主管业务
                }

                PerformanceType performanceType = PerformanceType.own;
                double rate = 100;

                sql = string.Format("select SalesID from JobTrack where DeptID = {0} and ((BeginDate <= '{1}' and EndDate > '{1}') or (BeginDate <= '{1}' and EndDate is null)) and SalesID = {2}", deptID, row["SubscribeDate"].ToString(), dr["SalesID"].ToString());

                object objResult = SqlHelper.ExecuteScalar(sql);
                if (objResult == null) //认购时间与任职期间不匹配，为分配业绩
                {
                    drRate = dtRate.Select("Code = 1"); //allot
                    rate = double.Parse(drRate[0]["Rate"].ToString());
                    performanceType = PerformanceType.allot;
                }


                string performance = Math.Round(double.Parse(row["RecSettleTotal"].ToString()) * rate / 100, 0, MidpointRounding.AwayFromZero).ToString();

                sql = "insert into PerformanceDetail (SettleDID,SettleID,SalesID,SalesName,DeptID,ReceiptDate, "
                    + "ReceiptTypeCode,ReceiptTypeName,ItemTypeCode,ItemTypeName,ReceiptAmount,Performance,PerformanceType, SalesType) "
                    + " values ( "
                    + row["ID"].ToString()
                    + "," + row["SettleID"].ToString()
                    + "," + salesID
                    + ",'" + salesName + "'"
                    + "," + deptID
                    + ",'" + row["ReceiptDate"].ToString() + "'"
                    + "," + (int)recType
                    + ",'" + recType + "'"
                    + "," + row["ItemTypeCode"].ToString()
                    + ",'" + row["ItemTypeName"].ToString() + "'"
                    + "," + row["RecSettleTotal"].ToString()
                    + "," + performance
                    + "," + (int)performanceType
                    + ",'主管'"
                    + ")";

                SqlHelper.ExecuteNonQuery(sql);

                string parentDeptID = GetParentDeptID(deptID);

                if ((parentDeptID != "") && (parentDeptID != "0"))
                {
                    MngPerformance(row, recType, parentDeptID, recSalesID);
                }

            }

        }

        private string GetParentDeptID(string deptID)
        {
            string sql = "select ParentID from department where DeptID = " + deptID;

            return SqlHelper.ExecuteScalar(sql).ToString();
        }


        private string GetDeptID(string salesID, string recDate)
        {
            string deptID = "0";

            string sql = string.Format("select deptID from JobTrack where SalesID = {0} and ((BeginDate <= '{1}' and EndDate > '{1}' ) or  (BeginDate <= '{1}'  or EndDate is null))", salesID, recDate);

            object objResult = SqlHelper.ExecuteScalar(sql);

            if (objResult != null)
            {
                deptID = objResult.ToString();
            }

            return deptID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscribeSalesID"></param>
        /// <param name="salesID"></param>
        /// <returns></returns>
        private PerformanceType GetSalesPerformanceType(string subscribeSalesID, string salesID)
        {
            PerformanceType result = PerformanceType.own; //默认为同一人

            if (!subscribeSalesID.Equals(salesID))
            {
                string sql = "select SalesID from sales where SalesID = " + subscribeSalesID + " and OutDate is null";

                if (SqlHelper.ExecuteScalar(sql) == null)
                {
                    result = PerformanceType.allot;  //认购离职，分配
                }
                else
                {
                    result = PerformanceType.hold;  //认购在职，调岗
                }

            }

            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesID"></param>
        /// <param name="recDate"></param>
        /// <param name="subscribeDate"></param>
        /// <returns>0：无主管，1：分配 2：个人</returns>
        private int GetMngPerformanceType(string salesID, string recDate, string subscribeDate)
        {
            int result = 0;

            string deptID = GetDeptID(salesID, recDate);

            //主管ID
            string sql = string.Format("select SalesID from JobTrack where JobType = '主管' and DeptID = {0} and ((BeginDate <= '{1}' and EndDate > '{1}') or (BeginDate <= '{1}' and EndDate is null))", deptID, recDate);
            DataTable dtMng = SqlHelper.ExecuteDataTable(sql);

            foreach (DataRow dr in dtMng.Rows)
            {
                sql = string.Format("select SalesID from JobTrack where DeptID = {0} and ((BeginDate <= '{1}' and EndDate > '{1}') or (BeginDate <= '{1}' and EndDate is null)) and SalesID = {2}", deptID, subscribeDate, dr["SalesID"].ToString());
                object objResult = SqlHelper.ExecuteScalar(sql);

                if (objResult == null) //认购时间与任职期间不匹配，为分配业绩
                {
                    result = 1;
                }
                else
                {
                    result = 2;
                }
            }



            return result;
        }

        
        
    }
}
