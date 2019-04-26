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
    public partial class FrmChange : Form
    {
        public FrmChange()
        {
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string condition = string.Empty;

            if (!textBox_CusName.Text.Trim().Equals(""))
                condition += " and  CustomerName like '%" + textBox_CusName.Text.Trim() + "%'";

            if (!textBox_Phone.Text.Trim().Equals(""))
                condition += " and  (CustomerPhone like '%" + textBox_Phone.Text.Trim() + "%'";

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
            int bindQty = 0;

            DataTable dtContract = Transaction.GetContractDataEx(condition, out bindQty);

            Transaction.InsertBindCol(dataGridView_Contract, 11, bindQty);

            dataGridView_Contract.AutoGenerateColumns = false;
            dataGridView_Contract.DataSource = dtContract;

            if (dtContract.Rows.Count == 0)
            {
                Prompt.Information("没有符合条件的查询结果 ");
            }
        }


        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            if (dataGridView_Contract.CurrentRow == null)
            {
                Prompt.Information("未选择客户相关信息");
                return;
            }

            string contractID = dataGridView_Contract.CurrentRow.Cells["ColcontractID"].Value.ToString();

            FrmChangeAdd change = new FrmChangeAdd();
            change.ContractID = contractID;

            if (change.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Search(" and ContractMain.ContractID = " + contractID);

                Prompt.Information("操作成功，数据已更新！");
            }
        }

        private void dataGridView_Contract_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_Contract.CurrentRow != null)
            {
                string contractId = dataGridView_Contract.CurrentRow.Cells["ColContractID"].Value.ToString();
                getChangeByID(contractId);
            }
            
        }

        private void getChangeByID(string contractId)
        {
            string sql = string.Format("select ID, ChangeDate, ConfirmType, Memo from AreaChangeMain where ContractID = {0} order by ID", contractId);
            DataTable dtAreaChange = SqlHelper.ExecuteDataTable(sql);

            dtAreaChange.PrimaryKey = new DataColumn[] { dtAreaChange.Columns["ID"] };

            int colQty = 0;

            foreach (DataRow row in dtAreaChange.Rows)
            {
                sql = string.Format("select ItemNum, OrigArea, NewArea from AreaChangeDetail where MainID = {0}", row["ID"].ToString());
                DataTable dtDetail = SqlHelper.ExecuteDataTable(sql);

                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));

                string fieldValue = row["ID"].ToString();
                int itemIdx = 0;

                foreach (DataRow dr in dtDetail.Rows)
                {
                    for (int i = 0; i < dtDetail.Columns.Count; i++)
                    {
                        string fieldName = "AC_" + dtDetail.Columns[i].ColumnName + itemIdx;
                        dt.Columns.Add(fieldName, typeof(string));

                        fieldValue += "," + dr[i].ToString();

                    }
                    itemIdx++;

                    colQty = itemIdx > colQty ? itemIdx : colQty;
                }

                string[] strArray = fieldValue.Split(',');

                dt.Rows.Add(strArray);

                 dtAreaChange.Merge(dt, false, MissingSchemaAction.Add); //合并至主体表
            }

            InsertCol(dataGridView_Change, 4, colQty);

            dataGridView_Change.DataSource = dtAreaChange;
        }


        private void InsertCol(DataGridView dgv, int iBeginPos, int iColQuantity)
        {
            //删除AC列
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                if (dgv.Columns[i].Name.Substring(0, 3) == "AC_")
                {
                    dgv.Columns.Remove(dgv.Columns[i].Name);
                    i--; //列减少，索引不变
                }
            }

            //增加AC字段
            for (int i = 0; i < iColQuantity; i++)
            {
                //房号
                string sItemNum = "AC_ItemNum" + i.ToString();

                DataGridViewTextBoxColumn itemNum = new DataGridViewTextBoxColumn();
                itemNum.Name = sItemNum;
                itemNum.DataPropertyName = sItemNum;
                itemNum.HeaderText = "房号" + i.ToString();
                itemNum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Columns.Insert(iBeginPos++, itemNum);


                //原面积
                string sOrigArea = "AC_OrigArea" + i.ToString();

                DataGridViewTextBoxColumn origArea = new DataGridViewTextBoxColumn();
                origArea.Name = sOrigArea;
                origArea.DataPropertyName = sOrigArea;
                origArea.HeaderText = "原面积" + i.ToString();
                origArea.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                origArea.DefaultCellStyle.Format = "F2";
                dgv.Columns.Insert(iBeginPos++, origArea);


                //新面积
                string sNewArea = "AC_NewArea" + i.ToString();

                DataGridViewTextBoxColumn newArea = new DataGridViewTextBoxColumn();
                newArea.Name = sNewArea;
                newArea.DataPropertyName = sNewArea;
                newArea.HeaderText = "新面积" + i.ToString();
                newArea.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                newArea.DefaultCellStyle.Format = "F2";
                dgv.Columns.Insert(iBeginPos++, newArea);
            }
        }



        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {
            if (dataGridView_Contract.CurrentRow == null)
            {
                return;
            }

            string contractId = dataGridView_Contract.CurrentRow.Cells["ColContractID"].Value.ToString();

            if (dataGridView_Change.CurrentRow == null)
            {
                Prompt.Warning("未选择相关记录！");
                return;
            }

            string sql = string.Empty;

            int changeId = int.Parse(dataGridView_Change.CurrentRow.Cells["ColID"].Value.ToString());

            int maxId = int.Parse(SqlHelper.ExecuteScalar(string.Format("select IsNull(MAX(ID),0) from AreaChangeMain where ContractID = {0}", contractId)).ToString());

            if (changeId != maxId)
            {
                Prompt.Information("仅允许删除最后一次变更记录！");
                return;
            }

            //检验首付、贷款、总款变化时，不允许删除(影响数据恢复)
            sql = string.Format("select count(a.ContractID) from ContractMain a inner join AreaChangeMain b on b.ContractID = a.ContractID" 
                + " where a.DownPayAmount = b.NewDownPay and a.Loan = b.NewLoan and a.TotalAmount = b.NewTotalAmount and a.ContractID = {0}", contractId);
            if (int.Parse(SqlHelper.ExecuteScalar(sql).ToString()) == 0)
            {
                Prompt.Warning("数据已发生变更，无法删除！");
                return;
            }


            if (MessageBox.Show("确认要删除选择的记录吗？",Common.MsgCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string origArea = string.Empty;
                string origAmount = string.Empty;
                string origDownPay = string.Empty;
                string origLoan = string.Empty;
                string origTotalAmount = string.Empty;
                string itemId = string.Empty;

                using (SqlConnection connection = SqlHelper.OpenConnection())  //创建连接对象 
                {
                    SqlTransaction sqlTran = connection.BeginTransaction();    //开始事务 
                    SqlCommand cmd = connection.CreateCommand();               //创建SqlCommand对象 
                    cmd.Transaction = sqlTran;

                    try
                    {
                        sql = string.Format("select OrigDownPay, OrigLoan, OrigTotalAmount from AreaChangeMain where ID = {0}", changeId);
                        SqlDataReader sdr = SqlHelper.ExecuteReader(sql);

                        if (sdr.Read())
                        {
                            origDownPay = sdr["OrigDownPay"].ToString();
                            origLoan = sdr["OrigLoan"].ToString();
                            origTotalAmount = sdr["OrigTotalAmount"].ToString();

                            //恢复签约主表
                            cmd.CommandText = string.Format("update ContractMain set DownPayAmount = {0}, Loan = {1}, TotalAmount = {2} where ContractID = {3}", origDownPay, origLoan, origTotalAmount, contractId);
                            cmd.ExecuteNonQuery();

                            //恢复签约明细
                            sql = string.Format("select ItemID, OrigAmount, OrigArea from AreaChangeDetail where MainID = {0}", changeId);
                            SqlDataReader sdrOrigData = SqlHelper.ExecuteReader(sql);
                            while(sdrOrigData.Read())
                            {
                                itemId = sdrOrigData["ItemID"].ToString();
                                origArea = sdrOrigData["OrigArea"].ToString();
                                origAmount = sdrOrigData["OrigAmount"].ToString();
                                cmd.CommandText = string.Format("update ContractDetail set Area = {0}, Amount = {1} where ContractID = {2} and ItemID = {3}", origArea, origAmount, contractId, itemId);
                                cmd.ExecuteNonQuery();
                            }
                            sdrOrigData.Close();
                        }

                        sdr.Close();

                        //恢复原始分期、删除历史分期
                        cmd.CommandText = string.Format("Delete Installment where ContractID = {0}", contractId);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = string.Format("insert into Installment (ContractID,Sequence,PayDate,Amount,Settled) select ContractID,Sequence,PayDate,Amount,Settled from InstallmentHis where ContractID = {0} and SourceID = {1}", contractId, changeId);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = string.Format("delete InstallmentHis where ContractID = {0} and SourceID = {1}", contractId, changeId);
                        cmd.ExecuteNonQuery();

                        //删除面积变更记录
                        cmd.CommandText = string.Format("delete AreaChangeMain where ID = {0}", changeId);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = string.Format("delete AreaChangeDetail where MainID = {0}", changeId);
                        cmd.ExecuteNonQuery();

                        sqlTran.Commit();  //事务提交
                    }
                    catch (Exception ex)
                    {
                        sqlTran.Rollback();  //异常事务回滚
                        Prompt.Error("操作失败， 错误：" + ex.Message);
                    }
                }

                Search(" and ContractMain.ContractID = " + contractId);

                Prompt.Information("操作成功，数据已经更新!");

            }
        }
    }
}
