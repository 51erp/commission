using Commission.Utility;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Commission.MenuForms
{
    public partial class FrmBottomPriceImp : Form
    {
        public FrmBottomPriceImp()
        {
            InitializeComponent();
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
                    int maxColumnNum = 7;//最大列
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
                            vRow[m - 1] = worksheet.Cells[n, m].Value;
                        }
                        vTable.Rows.Add(vRow);
                    }

                    dataGridView_item.DataSource = vTable;
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

            label_State.Text = "状态：导入中...";
            this.Refresh();

            for (int i = 0; i < dataGridView_item.Rows.Count; i++)
            {
                string id = dataGridView_item.Rows[i].Cells[0].Value.ToString();

                string price = dataGridView_item.Rows[i].Cells[7].Value.ToString();
                if (price == "") price = "0";

                string rate = dataGridView_item.Rows[i].Cells[8].Value.ToString();
                if (rate == "") rate = "0";

                string limit = dataGridView_item.Rows[i].Cells[9].Value.ToString();
                if (limit == "") limit = "0";

                string sql = string.Format("update  SaleItem set BottomPrice = {0} ,BottomPriceRate = {1},BottomPriceLimit = {2} where itemID = {3}",  price,rate,limit,id);

                try
                {
                    SqlHelper.ExecuteNonQuery(sql);
                }
                catch (Exception ex)
                {
                    Prompt.Error("导入错误：" + ex.Message.ToString());
                    continue;
                }
            }

            label_State.Text = "状态：准备";
            button_Import.Enabled = true;
            this.Refresh();

            DataTable dt = (DataTable)dataGridView_item.DataSource;
            dt.Rows.Clear();
            dataGridView_item.DataSource = dt;

            Prompt.Information("导入完成，刷新查看导入结果！");
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool validate()
        {
            bool result = true;

            label_State.Text = "状态：检查中...";
            this.Refresh();

            if (dataGridView_item.Rows.Count == 0)
            {
                Prompt.Error("没有读取数据，无法导入！");
                return false; 
            }

            for (int i = 0; i < dataGridView_item.Rows.Count; i++)
            {
                string id = dataGridView_item.Rows[i].Cells[0].Value.ToString();
                if (string.IsNullOrEmpty(id))
                {
                    dataGridView_item.Rows[i].Selected = true;
                    Prompt.Error("ID不能为空！");
                    return false; 
                }
            }

            return result;
        }

        private void button_ExportDict_Click(object sender, EventArgs e)
        {
            string sql = string.Format("select ItemID ID, Building 楼号, Unit 单元, ItemNum 房号, '0' 底价, '0' 溢价分成, '0' 溢价限价 from SaleItem  where ProjectID = {0}", Login.User.ProjectID);

            Common.Exp2XLS(SqlHelper.ExecuteDataTable(sql));
        }


    }
}
