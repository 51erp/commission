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

namespace Commission.Forms
{
    public partial class FrmImpContract : Form
    {
        public FrmImpContract()
        {
            InitializeComponent();
        }

        private void toolStripButton_Back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmImpSubscribe_Load(object sender, EventArgs e)
        {
            DataGridViewCellStyle dgvcs = new DataGridViewCellStyle();
            dgvcs.BackColor = Color.Red;
            dataGridView_Subscribe.Columns["ColCustomerID"].DefaultCellStyle = dgvcs;
            dataGridView_Subscribe.Columns["ColItemID"].DefaultCellStyle = dgvcs;
            dataGridView_Subscribe.Columns["ColSalesID"].DefaultCellStyle = dgvcs;
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {

        }


        private DataTable OpenSourceFile()
        {
            DataTable dtSource = new DataTable();

            if (openFileDialog_Source.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                string fileName = openFileDialog_Source.FileName;

                FileInfo existingFile = new FileInfo(fileName);

                try
                {
                    ExcelPackage package = new ExcelPackage(existingFile);
                    int iSheetCount = package.Workbook.Worksheets.Count; //获取总Sheet页

                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];//选定 指定页

                    //int maxColumnNum = worksheet.Dimension.End.Column;//最大列
                    int maxColumnNum = 4;//最大列
                    int minColumnNum = worksheet.Dimension.Start.Column;//最小列

                    int maxRowNum = worksheet.Dimension.End.Row;//最大行
                    int minRowNum = worksheet.Dimension.Start.Row;//最小行


                    for (int i = 0; i < maxColumnNum; i++)
                    {
                        DataColumn col = new DataColumn("Col" + i.ToString());
                        dtSource.Columns.Add(col);
                    }

                    for (int n = 2; n <= maxRowNum; n++)
                    {
                        DataRow row = dtSource.NewRow();
                        for (int m = 1; m <= maxColumnNum; m++)
                        {
                            row[m - 1] = worksheet.Cells[n, m].Value;
                        }
                        dtSource.Rows.Add(row);
                    }
                }
                catch (Exception vErr)
                {
                    MessageBox.Show(vErr.Message);
                }
            }

            return dtSource;
        }

    }
}
