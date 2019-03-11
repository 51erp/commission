using Commission.Utility;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;

namespace Commission
{
    public class Common
    {
        public static string MsgCaption = "房地产佣金结算系统";

        public static void OnlyNumeric(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 46 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        public static void SetFirstOfMonth(DateTimePicker dtp)
        {
            dtp.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        public static void SetEndOfMonth(DateTimePicker dtp)
        {

            dtp.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);
        }

        

        public static void Exp2XLS(DataGridView dgv)
        {
            if (dgv.RowCount == 0)
            {
                Prompt.Information("导出对象没有记录！");
                return;
            }

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

                //标题
                int idx = 0;
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    if (column.Visible == true)
                    {
                        idx++;
                        worksheet.Cells[1, idx].Value = column.HeaderText;
                    }
                }

                //数据
                int iRow = 0;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    iRow = i + 2;
                    int iCol = 0;
                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        if (column.Visible == true)
                        {
                            iCol++;
                            worksheet.Cells[iRow, iCol].Value = dgv.Rows[i].Cells[column.Name].FormattedValue;
                        }
                    }
                }

                package.SaveAs(xlsFile);

                MessageBox.Show("成功导出为Excel！", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }


        public static void Exp2XLS(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                Prompt.Information("导出对象没有记录！");
                return;
            }

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

                //标题
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = dt.Columns[i].ColumnName;
                }


                //数据
                int iRow = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    iRow = i + 2;
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        worksheet.Cells[iRow, j+1].Value = dt.Rows[i][j].ToString();
                    }
                }

                package.SaveAs(xlsFile);

                MessageBox.Show("成功导出为Excel！", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }




        public static void SetColumnStyle(DataGridViewColumn col, ColType type)
        {
            if (col == null)
                return;

            switch (type)
            {
                case ColType.area:
                    col.DefaultCellStyle.Format = Login.Parameters.FmtArea;
                    break;

                case ColType.price:
                    col.DefaultCellStyle.Format = Login.Parameters.FmtPrice;
                    break;

                case ColType.amount:
                    col.DefaultCellStyle.Format = Login.Parameters.FmtAmount;
                    break;

                default:
                    break;
            }

            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            col.DefaultCellStyle.Padding = new Padding(0, 0, 3, 0);
            col.DefaultCellStyle.NullValue = "0";
        }
    }

    //字段（列）类型
    public enum ColType
    {
        area,
        price,
        amount
    }

    //收款类型
    public enum Receivables
    {
        贷款 = 0,
        定金 = 1,
        首付 = 2,
        补差 = 3,
        交房 = 4,
        限价 = 5,
        退房 = 6,
        成销 = 7

        //成销 = 20,
        //退房 = 30,
        //定金 = 40,
        //首付 = 41,
        //贷款 = 42,
        //补差 = 50,
        //交房 = 51,
        //限价 = 52,
    }

    //销售类型
    public enum ItemSaleState
    {
        保留 = 0,
        待售 = 1,
        认购 = 2,
        签约 = 3
    }

    //窗口模式
    public enum FormMode
    {
        add,
        modify,
        view,
        exchange //更换房源，单据显示信息有区别
    }

    //业务类型
    public enum OperationType
    {
        [Description("认购")]
        subscribe,

        [Description("签约")]
        contract
    }


    //付款类型
    public enum PayType
    {
        Full = 1,              //全款
        Loan = 2,              //贷款
        FullInstalment = 3,    //全款分期
        DownPayInstalment = 4  //首付分期
    }

    //结算条件
    public enum SettleStandard
    {
        ContractAmount = 1,
        DownPay = 2,
        InstallmentFirst = 3,
        InstallmentStage = 4
    }

    //结算基础
    public enum SettleBase
    {
        ContractAmount = 1,
        DownPay = 2,
        ReceiptAmount = 3,
        InstallmentStage = 4,
        Single = 5
    }

    //跳点基础
    public enum UpBase
    {
        Subscribe = 1, //1,认购总额
        Contract = 2,  //2,签约总额
        Receipt = 3,   //3,回款金额
        Area = 4,      //4,销售面积
        Quantity = 5   //5,销售套数
    }

    public enum AchievementType
    {
        own,
        allot,
        hold
    }

}
