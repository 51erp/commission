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
    public partial class RepSubscribeReturn : Form
    {
        public RepSubscribeReturn()
        {
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Export_Click(object sender, EventArgs e)
        {
            Common.Exp2XLS(dataGridView_Subscribe);
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string condition = " and a.ProjectID = " + Login.User.ProjectID
                + " and a.ReturnDate >= '" + dateTimePicker_Begin.Value.ToString("yyyy-MM-dd") + "'"
                + " and a.ReturnDate <= '" + dateTimePicker_End.Value.ToString("yyyy-MM-dd") + "'";

            if (!textBox_Building.Text.Trim().Equals(""))
                condition += " and Building = '" + textBox_Building.Text.Trim() + "'";

            if (!textBox_Unit.Text.Trim().Equals(""))
                condition += " and Unit = '" + textBox_Unit.Text.Trim() + "'";

            if (!textBox_ItemNum.Text.Trim().Equals(""))
                condition += " and ItemNum = '" + textBox_ItemNum.Text.Trim() + "'";

            Search(condition);
        }


        public void Search(string condition)
        {
            int colQuantity = 0;

            DataTable dtSubscribe = GetSubscribeData(condition, out colQuantity);

            Transaction.InsertBindCol(dataGridView_Subscribe, 13, colQuantity);

            dataGridView_Subscribe.DataSource = dtSubscribe;

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

            sql = "select a.SubscribeID, a.ContractID, CustomerID,CustomerName,CustomerPhone,ItemTypeName, Building, Unit, ItemNum, "
                + " Area, Price, Amount, TotalAmount, '0' as RecTotalAmount, SubscribeDate,ReturnDate, RefundDate, ReturnReason, SalesID, SalesName, "
                + " ExtField0, ExtField1, ExtField2, ExtField3, ExtField4, ExtField5, ExtField6, ExtField7, ExtField8, ExtField9 "
                + " from SubscribeMain a "
                + " inner join SubscribeDetail b on a.SubscribeID = b.SubscribeID "
                + " where a.ProjectID = " + Login.User.ProjectID + " and  b.IsBind = 0 " + condition
                + " order by SubscribeID ";

            DataTable dtSubscribe = SqlHelper.ExecuteDataTable(sql); //主体表

            dtSubscribe.PrimaryKey = new DataColumn[] { dtSubscribe.Columns["SubscribeID"] };

            for (int i = 0; i < dtSubscribe.Rows.Count; i++)
            {
                string subId = dtSubscribe.Rows[i]["SubscribeID"].ToString();

                sql = string.Format("select ISNULL(SUM(Amount),0) from Receipt where  SubscribeID = {0} and TypeCode != {1}", subId, (int)Receivables.退房);
                string recTotalAmount = string.Format("{0:F0}", SqlHelper.ExecuteScalar(sql));
                dtSubscribe.Rows[i]["RecTotalAmount"] = recTotalAmount;


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

        private void toolStripButton_Refund_Click(object sender, EventArgs e)
        {
            if (dataGridView_Subscribe.CurrentRow == null)
            {
                Prompt.Warning("未选择记录！");
                return ;
            }

            string refundDate = dataGridView_Subscribe.CurrentRow.Cells["ColRefundDate"].Value.ToString();
            if (!refundDate.Equals(""))
            {
                Prompt.Warning("指定记录已退款！");
                return;
            }

            string recTotalAmount = dataGridView_Subscribe.CurrentRow.Cells["ColRecTotalAmount"].Value.ToString();

            if (recTotalAmount.Equals("0"))
            {
                Prompt.Warning("无收款记录！");
                return;
            }

            if (MessageBox.Show("确定要进行退款？",Common.MsgCaption,  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string subscribeId = dataGridView_Subscribe.CurrentRow.Cells["ColSubscribeID"].Value.ToString();
                string salesId = dataGridView_Subscribe.CurrentRow.Cells["ColSalesID"].Value.ToString();
                string salesName = dataGridView_Subscribe.CurrentRow.Cells["ColSalesName"].Value.ToString();
                string refund = "-" + recTotalAmount;

                using (SqlConnection connection = SqlHelper.OpenConnection())
                {
                    SqlTransaction sqlTran = connection.BeginTransaction();
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.Transaction = sqlTran;

                    try
                    {
                        string srvDate = SqlHelper.ExecuteScalar(string.Format("select Convert(varchar(10),GETDATE(),120)")).ToString();

                        cmd.CommandText = string.Format("update SubscribeMain set RefundDate = '{0}' where SubscribeID = {1}", srvDate, subscribeId);
                        cmd.ExecuteNonQuery();

                        string strValues = subscribeId + "," + Login.User.ProjectID + "," + refund + ",'" + srvDate + "'," + (int)Receivables.退房 + ",'" + Receivables.退房 + "','" + Receivables.退房 + "'," + salesId + ",'" + salesName + "',GETDATE(),'" + Login.User.UserName + "'";
                        cmd.CommandText = string.Format("insert into Receipt (SubscribeID,ProjectID,Amount,RecDate,TypeCode,TypeName,Memo,SalesID,SalesName,MakeDate,Maker) values ({0})", strValues);
                        cmd.ExecuteNonQuery();

                        dataGridView_Subscribe.CurrentRow.Cells["ColRefundDate"].Value = srvDate;
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

        private void RepSubscribeReturn_Load(object sender, EventArgs e)
        {
            Common.SetFirstOfMonth(dateTimePicker_Begin);
            Common.SetEndOfMonth(dateTimePicker_End);
        }

    }
}
