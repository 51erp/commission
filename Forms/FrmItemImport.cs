using Commission.Business;
using Commission.Utility;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Commission.Forms
{
    public partial class FrmItemImport : Form
    {
        public DataTable DictItemType = new DataTable();
        public FrmItemImport()
        {
            InitializeComponent();
            DictItemType = SqlHelper.ExecuteDataTable(string.Format("select Code, Name from DictItemType where ProjectID = {0}", Login.User.ProjectID));
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_OpneExcel_Click(object sender, EventArgs e)
        {

            if (openFileDialog_Excel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileName = openFileDialog_Excel.FileName;

                FileInfo existingFile = new FileInfo(fileName);

                try
                {
                    ExcelPackage package = new ExcelPackage(existingFile);
                    int vSheetCount = package.Workbook.Worksheets.Count; //获取总Sheet页

                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];//选定 指定页

                    int minColumnNum = worksheet.Dimension.Start.Column;//最小列

                    int minRowNum = worksheet.Dimension.Start.Row;//最小行
                    int maxRowNum = worksheet.Dimension.End.Row;  //最大行

                    DataTable dtItem = new DataTable();

                    //楼号
                    DataColumn colBuilding = new DataColumn();
                    colBuilding.DataType = System.Type.GetType("System.String");
                    colBuilding.ColumnName = "Building";
                    colBuilding.DefaultValue = "";
                    dtItem.Columns.Add(colBuilding);

                    //单元
                    DataColumn colUnit = new DataColumn();
                    colUnit.DataType = System.Type.GetType("System.String");
                    colUnit.ColumnName = "Unit";
                    colUnit.DefaultValue = "";
                    dtItem.Columns.Add(colUnit);

                    //房号
                    DataColumn colItemNum = new DataColumn();
                    colItemNum.DataType = System.Type.GetType("System.String");
                    colItemNum.ColumnName = "ItemNum";
                    colItemNum.DefaultValue = "";
                    dtItem.Columns.Add(colItemNum);

                    //面积
                    DataColumn colArea = new DataColumn();
                    colArea.DataType = System.Type.GetType("System.Decimal");
                    colArea.ColumnName = "Area";
                    colArea.DefaultValue = 0;
                    dtItem.Columns.Add(colArea);

                    //单价
                    DataColumn colPrice = new DataColumn();
                    colPrice.DataType = System.Type.GetType("System.Decimal");
                    colPrice.ColumnName = "Price";
                    colPrice.DefaultValue = 0;
                    dtItem.Columns.Add(colPrice);
                    
                    //总价
                    DataColumn colAmount = new DataColumn();
                    colAmount.DataType = System.Type.GetType("System.Decimal");
                    colAmount.ColumnName = "Amount";
                    colAmount.Expression = "Area * Price";
                    dtItem.Columns.Add(colAmount);

                    //类型
                    DataColumn colItemType = new DataColumn();
                    colItemType.DataType = System.Type.GetType("System.String");
                    colItemType.ColumnName = "ItemType";
                    dtItem.Columns.Add(colItemType);

                    for (int i = 2; i <= maxRowNum; i++)
                    {
                        DataRow dr = dtItem.NewRow();

                        dr["Building"] = worksheet.Cells[i, 1].Value == null ? "" : dr["Building"] = worksheet.Cells[i, 1].Value; 
                        dr["Unit"] = worksheet.Cells[i, 2].Value == null ? "" : worksheet.Cells[i, 2].Value;
                        dr["ItemNum"] = worksheet.Cells[i, 3].Value == null ? "" : worksheet.Cells[i, 3].Value;
                        if (worksheet.Cells[i, 4].Value == null) continue;
                        dr["Area"] = worksheet.Cells[i, 4].Value;
                        if (worksheet.Cells[i, 5].Value == null) continue;
                        dr["Price"] = worksheet.Cells[i, 5].Value;
                        dr["ItemType"] = worksheet.Cells[i, 6].Value;

                        dtItem.Rows.Add(dr);
                    }

                    dataGridView_SaleItem.DataSource = dtItem;
                    toolStripStatusLabel_Count.Text = dtItem.Rows.Count.ToString();

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
            string values = string.Empty;
            for (int i = 0; i <  dataGridView_SaleItem.Rows.Count; i++)
            {
                string itemTypeCode = string.Empty;
                string itemTypeName = dataGridView_SaleItem.Rows[i].Cells[6].Value.ToString();


                DataRow[] rows = DictItemType.Select(string.Format("Name ='{0}'",itemTypeName));
                if (rows.Length > 0)
                {
                    itemTypeCode = rows[0]["Code"].ToString();
                }
                else
                {
                    if (MessageBox.Show("房源类型： [ " + itemTypeName + " ] 不匹配，请参照字典。是否继续导入？", Common.MsgCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                string area = dataGridView_SaleItem.Rows[i].Cells[3].Value.ToString();

                string price = dataGridView_SaleItem.Rows[i].Cells[4].Value.ToString();

                values = Login.User.ProjectID
                   + ",'" + Login.User.ProjectName + "'"
                   + ",'" + dataGridView_SaleItem.Rows[i].Cells[0].Value.ToString() + "'"
                   + ",'" + dataGridView_SaleItem.Rows[i].Cells[1].Value.ToString() + "'"
                   + ",'" + dataGridView_SaleItem.Rows[i].Cells[2].Value.ToString() + "'"
                   + ",'" + area + "'"
                   + ",'" + price + "'"
                   + "," + itemTypeCode
                   + ",'" + itemTypeName + "'";


                string sql = string.Format("insert into SaleItem (ProjectID,ProjectName,Building,Unit,ItemNum,Area,Price,ItemTypeCode, ItemTypeName) values ({0})", values);

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
            Prompt.Information("导入完成，具体结果请查询房源信息！");

            button_Import.Enabled = true;
        }

        private bool validate()
        {
            label_State.Text = "状态：检查中...";
            this.Refresh();

            bool result = true;

            DataTable dt = (DataTable)dataGridView_SaleItem.DataSource;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string building = dt.Rows[i]["Building"].ToString();
                string unit = dt.Rows[i]["Unit"].ToString();
                string itemnum = dt.Rows[i]["ItemNum"].ToString();

                DataRow[] rows = dt.Select(string.Format("Building ='{0}' and Unit = '{1}' and ItemNum = '{2}'", building, unit, itemnum));
                if (rows.Length > 1)
                {
                    dataGridView_SaleItem.CurrentCell = dataGridView_SaleItem.Rows[i].Cells[1];
                    Prompt.Error("房源标识( 楼号+单元+房号 )重复！");
                    return false;
                }
            }


            for (int i = 0; i < dataGridView_SaleItem.Rows.Count; i++)
            {
                string building = dataGridView_SaleItem.Rows[i].Cells[0].Value.ToString();
                string unit = dataGridView_SaleItem.Rows[i].Cells[1].Value.ToString();
                string itemnum = dataGridView_SaleItem.Rows[i].Cells[2].Value.ToString();

                if (itemnum.Equals(""))
                {
                    dataGridView_SaleItem.CurrentCell = dataGridView_SaleItem.Rows[i].Cells[5];
                    dataGridView_SaleItem.Rows[i].Selected = true;
                    Prompt.Error("房号不能为空！");
                    return false; 
                }


                if (isExistItem(Login.User.ProjectID, building, unit, itemnum))
                {
                    dataGridView_SaleItem.CurrentCell = dataGridView_SaleItem.Rows[i].Cells[5];
                    dataGridView_SaleItem.Rows[i].Selected = true;
                    Prompt.Error("楼盘信息已经存在，不允许重复录入！");
                    return false; 
                }

                string itemType = dataGridView_SaleItem.Rows[i].Cells[6].Value.ToString();

                int QueryResult = int.Parse(SqlHelper.ExecuteScalar(string.Format("select COUNT(Code)  from DictItemType where Name = '{0}'",itemType)).ToString());

                if (QueryResult == 0)
                {
                    dataGridView_SaleItem.CurrentCell = dataGridView_SaleItem.Rows[i].Cells[5];
                    dataGridView_SaleItem.Rows[i].Selected = true;
                    Prompt.Error("楼盘类型错误，无法导入，请检查后，重新操作！");
                    return false;
                }
            }

            return result;
        }

        private bool isExistItem(string projectID, string building, string unit, string itemnum)
        {
            bool result = false;

            string sql = "select count(*) cnt from SaleItem "
                + " where ProjectID = " + Login.User.ProjectID
                + " and Building = '" + building + "'"
                + " and Unit = '" + unit + "'"
                + " and ItemNum = '" + itemnum + "'";

            object sqlResult = SqlHelper.ExecuteScalar(sql);
            if (int.Parse(sqlResult.ToString()) > 0)
            {
                result = true;
            }

            return result;
        }

        private void button_ExportDict_Click(object sender, EventArgs e)
        {
            DataTable dtItemType = SqlHelper.ExecuteDataTable(string.Format("select code as 编码, name as 名称 from DictItemType where ProjectID = {0}",Login.User.ProjectID));
            Common.Exp2XLS(dtItemType);
        }
    }
}
