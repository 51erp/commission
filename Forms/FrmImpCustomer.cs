using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;
using Commission.Utility;

namespace Commission.Forms
{
    public partial class FrmImpCustomer : Form
    {
        public FrmImpCustomer()
        {
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_OpneExcel_Click(object sender, EventArgs e)
        {
            if (openFileDialog_Excel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                label_State.Text = "状态：读取中...";
                button_OpneExcel.Enabled = false;
                this.Refresh();

                string fileName = openFileDialog_Excel.FileName;

                FileInfo existingFile = new FileInfo(fileName);

                try
                {
                    ExcelPackage package = new ExcelPackage(existingFile);
                    int vSheetCount = package.Workbook.Worksheets.Count; //获取总Sheet页

                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];//选定 指定页

                    //int maxColumnNum = worksheet.Dimension.End.Column;//最大列
                    int maxColumnNum = 4;//最大列
                    int minColumnNum = worksheet.Dimension.Start.Column;//最小列

                    int maxRowNum = worksheet.Dimension.End.Row;//最大行
                    int minRowNum = worksheet.Dimension.Start.Row;//最小行

                    DataTable vTable = new DataTable();


                    for (int i = 0; i < maxColumnNum; i++)
                    {
                        DataColumn vC = new DataColumn("Col" + i.ToString());
                        vTable.Columns.Add(vC);
                    }

                    for (int n = 2; n <= maxRowNum; n++)
                    {
                        DataRow vRow = vTable.NewRow();
                        for (int m = 1; m <= maxColumnNum; m++)
                        {
                            vRow[m - 1] = worksheet.Cells[n, m].Value == null ? "" : worksheet.Cells[n, m].Value.ToString().Replace("\n", " ");
                        }
                        vTable.Rows.Add(vRow);
                    }

                    dataGridView_data.DataSource = vTable;
                }
                catch (IOException err)
                {
                    Prompt.Error("请关闭已打开的模板文件！\n\n错误信息： " + err.Message);
                }
                catch (Exception vErr)
                {
                    MessageBox.Show(vErr.Message);
                }
            }

            label_State.Text = "状态：准备";
            button_OpneExcel.Enabled = true;
            this.Refresh();

        }


        private void button_Import_Click(object sender, EventArgs e)
        {
            button_Import.Enabled = false;

            if (!validate())
            {
                button_Import.Enabled = true;
                return;
            }

            if (dataGridView_data.Rows.Count == 0)
            {
                Prompt.Information("没有可以导入的数据！");
                return;
            }


            label_State.Text = "状态：导入中...";
            this.Refresh();
            string values = string.Empty;
            for (int i = 0; i < dataGridView_data.Rows.Count; i++)
            {
                string customerName = dataGridView_data.Rows[i].Cells[0].Value.ToString();
                string customerPhone = dataGridView_data.Rows[i].Cells[1].Value.ToString();
                string pid = dataGridView_data.Rows[i].Cells[2].Value.ToString();
                string addr = dataGridView_data.Rows[i].Cells[3].Value.ToString();

                values = Login.User.ProjectID + ",'" + customerName + "','" + customerPhone + "','" + pid + "','" + addr + "'";

                string sql = string.Format("insert into Customer (ProjectID, CustomerName, CustomerPhone, PID, Addr) values ({0})", values);

                try
                {
                    SqlHelper.ExecuteNonQuery(sql);
                    Close();
                }
                catch (Exception ex)
                {
                    button_Import.Enabled = true;
                    Prompt.Error("导入错误：" + ex.Message.ToString());
                    continue;
                }

            }

            label_State.Text = "状态：导入完成！";
            this.Refresh();
            Prompt.Information("操作成功，数据已导入！");

            button_Import.Enabled = true;
        }

        private bool validate()
        {
            bool result = true;


            return result;
        }
    }
}
