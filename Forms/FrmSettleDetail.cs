using Commission.Business;
using Commission.Utility;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Commission.Forms
{
    public partial class FrmSettleDetail : Form
    {
        public Dictionary<string, string> RepSettle = new Dictionary<string, string>();
        public string SettleID = string.Empty;

        public FrmSettleDetail()
        {
            InitializeComponent();
            InitInput();
        }

        private void InitInput()
        {
            label_ProjectName.Text = string.Empty;
            label_TableName.Text = string.Empty;
            label_TableMaker.Text = string.Empty;
            label_Date.Text = string.Empty;
            label_Period.Text = string.Empty;
            label_Checker.Text = string.Empty;
            label_CheckDate.Text = string.Empty;
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            RepSettle["Checker"] = label_Checker.Text;
            RepSettle["CheckDate"] = label_CheckDate.Text;
            Close();
        }

        private void LoadData()
        {
            SettleID = RepSettle["SettleID"];
            label_ProjectName.Text = RepSettle["ProjectName"];
            label_TableName.Text = RepSettle["TableName"];
            label_TableMaker.Text = RepSettle["TableMaker"];
            label_Date.Text = RepSettle["SettleDate"];
            label_Period.Text = RepSettle["SettlePeriod"];
            label_Checker.Text = RepSettle["Checker"];
            label_CheckDate.Text = RepSettle["CheckDate"];

            dataGridView_Settlement.AutoGenerateColumns = false;

            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColRecDownPay"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColRecLoan"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColRecDiffer"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColRecDeliver"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColRecLimit"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColRecSettleTotal"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColLoan"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColDownPayAmount"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColPremiumAll"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColCommAll"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColSettleAll"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColNoSettleAll"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColPremium"], ColType.amount); 
            Common.SetColumnStyle(dataGridView_Settlement.Columns["ColCommTotal"], ColType.amount); 

            string sql = string.Format("select * from SettleDetail where SettleID = {0}", SettleID);
            dataGridView_Settlement.DataSource = SqlHelper.ExecuteDataTable(sql);
        }

        private void FrmSettleDetail_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {
            if ((dataGridView_Settlement.Rows.Count == 0) || (dataGridView_Settlement.CurrentRow == null))
            {
                Prompt.Warning("没有选择记录！");
                return;
            }

            if (dataGridView_Settlement.Rows.Count == 1)
            {
                Prompt.Warning("仅有一条记录！无法清空报表，请直接删除报表");
                return;
            }

            if (!RepSettle["Checker"].Equals(""))
            {
                Prompt.Warning("结算已审核，无法删除！");
                return;
            }


            if (dataGridView_Settlement.CurrentRow.Index != -1)
            {
                if (MessageBox.Show("确认要删除选择的记录？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    using (SqlConnection connection = SqlHelper.OpenConnection())  //创建连接对象 
                    {
                        SqlTransaction sqlTran = connection.BeginTransaction();    //开始事务 
                        SqlCommand cmd = connection.CreateCommand();               //创建SqlCommand对象 
                        cmd.Transaction = sqlTran;

                        try
                        {

                            string settleId = dataGridView_Settlement.CurrentRow.Cells["ColSettleID"].Value.ToString();
                            string contractId = dataGridView_Settlement.CurrentRow.Cells["ColContractID"].Value.ToString();
                            string sql = "delete SettleDetail where ID = " + dataGridView_Settlement.CurrentRow.Cells["ColID"].Value.ToString(); ;
                            SqlHelper.ExecuteNonQuery(sql);

                            sql = string.Format("update Receipt set SettleState = 0 where  SettleState = {0} and ContractID = {1}", settleId, contractId);
                            SqlHelper.ExecuteNonQuery(sql);

                            sql = string.Format("update Installment set Settled = 0 where Settled = {0} and ContractID = {0}", settleId, contractId);
                            SqlHelper.ExecuteNonQuery(sql);

                            dataGridView_Settlement.Rows.RemoveAt(dataGridView_Settlement.CurrentRow.Index);

                            sqlTran.Commit();  //事务提交
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

        //审核要变化，不进行状态更新，仅添加审核人
        private void toolStripButton_Check_Click(object sender, EventArgs e)
        {
            if (dataGridView_Settlement.Rows.Count == 0)
            {
                Prompt.Warning("无结算记录，不能审核！");
                return;
            }


            if (!RepSettle["Checker"].Equals(""))
            {
                Prompt.Information("已经审核，无法进行再次审核！");
                return;
            }


            try
            {
                SqlHelper.ExecuteNonQuery(string.Format("update SettleMain set Checker = '{0}', CheckDate = GETDATE() where SettleID = {1}", Login.User.UserName, SettleID));

                label_Checker.Text = Login.User.UserName;
                label_CheckDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                Prompt.Information("操作成功");

            }
            catch (Exception ex)
            {
                Prompt.Error("操作失败， 错误：" + ex.Message);
            }


        }

        private void toolStripButton_Export_Click(object sender, EventArgs e)
        {
            Common.Exp2XLS(dataGridView_Settlement);
        }

        private void Exp2XLS(DataGridView dgv)
        {
            string xlsFileName = string.Empty; ;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel文件(*.xlsx)|*.xlsx";

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                xlsFileName = sfd.FileName;
            else
                return;

            FileInfo xlsFile = new FileInfo(xlsFileName);

            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");


                //int idx = 0;
                //foreach (DataGridViewColumn column in dgv.Columns)
                //{
                //    if (column.Visible == true)
                //    {
                //        idx++;
                //        worksheet.Cells[1, idx].Value = column.HeaderText;
                //    }
                //}



                //标题
                int iColIdx = 0;
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    iColIdx++;
                    if (dgv.Columns[i].Visible == false)
                    {
                        iColIdx--;
                        continue;
                    }
                    worksheet.Cells[1, iColIdx].Value = dgv.Columns[i].HeaderText;
                }

                //数据
                int iRow = 0;
                int iCol = 0;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    iRow = i + 2;
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        iCol++;
                        if (dgv.Columns[j].Visible == false)
                        {
                            iCol--;
                            continue;
                        }
                        //Console.WriteLine(dgv.Rows[i].Cells[j].FormattedValue);
                        worksheet.Cells[iRow, iCol].Value = dgv.Rows[i].Cells[j].FormattedValue;
                    }
                }

                package.SaveAs(xlsFile);

                MessageBox.Show("成功导出为Excel！", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }


        //EPPlus
        private void Exp2Excel(DataTable dt)
        {
            string xlsFileName = string.Empty; ;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel文件(*.xlsx)|*.xlsx";

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                xlsFileName = sfd.FileName;
            else
                return;

            using (ExcelPackage package = new ExcelPackage(new FileInfo(xlsFileName)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                Console.WriteLine("1-- " + DateTime.Now.ToLongTimeString());
                foreach (DataColumn column in dt.Columns)
                {
                    worksheet.Cells[1, column.Ordinal + 1].Value = column.ColumnName;
                }

                string drValue;
                int iRow;
                int iCol;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        iRow = i + 2;
                        iCol = column.Ordinal + 1;

                        drValue = dt.Rows[i][column].ToString();

                        switch (column.DataType.ToString())
                        {
                            case "System.Decimal":
                            case "System.Double":
                                double doubV = 0;
                                double.TryParse(drValue, out doubV);
                                if (doubV == 0)
                                    worksheet.Cells[iRow, iCol].Value = "";
                                else
                                    worksheet.Cells[iRow, iCol].Value = doubV;
                                break;

                            case "System.DBNull":
                                worksheet.Cells[iRow, iCol].Value = "";
                                break;

                            default:
                                worksheet.Cells[iRow, iCol].Value = dt.Rows[i][column].ToString();
                                break;
                        }
                    }
                }

                Console.WriteLine("2-- " + DateTime.Now.ToLongTimeString());
                package.Save();

                MessageBox.Show("成功导出为Excel！", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
