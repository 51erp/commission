using Commission.Forms;
using Commission.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Commission.Business;
using OfficeOpenXml;
using System.IO;

namespace Commission.MenuForms
{
    public partial class FrmSaleItemMng : Form
    {
        public FrmSaleItemMng()
        {
            InitializeComponent();
            InitDefComponent();
        }

        private void InitDefComponent()
        {
            MasterData.SetItemType(comboBox_ItemType, ComboBoxType.search);
            MasterData.setSaleState(comboBox_SaleState, ComboBoxType.search);
            MasterData.SetPayType(comboBox_PayType, ComboBoxType.search);
        }


        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {

            //新增前清除查询结果
            if (dataGridView_Item.DataSource != null)
            {
                DataTable dt = (DataTable)dataGridView_Item.DataSource;
                dt.Rows.Clear();
                dataGridView_Item.DataSource = dt;
            }

            FrmSaleItemAdd itemAdd = new FrmSaleItemAdd();
            itemAdd.ShowDialog();
        }

        private void toolStripButton_All_Click(object sender, EventArgs e)
        {
            dataGridView_Item.EndEdit();

            for (int i = 0; i < dataGridView_Item.Rows.Count; i++)
            {
                dataGridView_Item.Rows[i].Cells["ColCheck"].Value = true;
            }
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            SearchSaleItem();
        }

        private bool hasItemChecked()
        {
            for (int i = 0; i < dataGridView_Item.Rows.Count; i++)
            {
                if ((bool)dataGridView_Item.Rows[i].Cells["ColCheck"].EditedFormattedValue)
                    return true;
            }

            return false; ;
        }


        /// <summary>
        /// 按条件查询销售项目
        /// 面积和单价为房源的数据，与认购或签约的数据有所不同。考虑是否更新房源基础数据
        /// </summary>
        private void SearchSaleItem()
        {
            string sql = string.Format("select ItemID,'false' as Choose, Building,Unit,ItemNum,Area, Price, ROUND(Area * Price,0) Amount,ItemTypeName, " //case IsBind when '1' then '是' end IsBind,
                + "PayModeID, PayModeName, PayTypeCode, PayTypeName, SaleStateName,SettleStandardName, SettleBaseName,SettleRate,SettleAmount, case IsLocking when '1' then '是' else '否' end IsLocking, "
                + "UpName,BottomPrice,BottomPriceLimit,BottomPriceRate  from SaleItem "
                + "where IsBind = 0 and ProjectID = {0}", Login.User.ProjectID);

            if (!textBox_Building.Text.Trim().Equals(""))
            {
                sql += " and Building = '" + textBox_Building.Text.Trim() + "'";
            }

            if (!textBox_Unit.Text.Trim().Equals(""))
            {
                sql += " and Unit = '" + textBox_Unit.Text.Trim() + "'";
            }

            if (!textBox_ItemNum.Text.Trim().Equals(""))
            {
                sql += " and ItemNum = '" + textBox_ItemNum.Text.Trim() + "'";
            }

            if (!comboBox_ItemType.SelectedValue.ToString().Equals("0"))
            {
                sql += " and ItemTypeCode = " + comboBox_ItemType.SelectedValue.ToString();
            }

            if (!comboBox_PayType.SelectedValue.ToString().Equals("0"))
            {
                sql += " and PayTypeCode = " + comboBox_PayType.SelectedValue.ToString();
            }

            if (!comboBox_SaleState.SelectedValue.ToString().Equals("9"))
            {
                sql += " and SaleStateCode = " + comboBox_SaleState.SelectedValue.ToString();
            }

            sql += " order by ProjectName,ItemTypeCode asc, Building,Unit,ItemNum ";


            dataGridView_Item.DataSource = SqlHelper.ExecuteDataTable(sql);;

            if (dataGridView_Item.Rows.Count == 0)
                Prompt.Information("没有符合条件的记录！");

        }

        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {
            if (!hasItemChecked())
            {
                Prompt.Information("没有选择相应的记录！");
                return;
            }

            string sql = string.Empty;
            for (int i = 0; i < dataGridView_Item.Rows.Count; i++)
            {
                if ((bool)dataGridView_Item.Rows[i].Cells["ColCheck"].EditedFormattedValue == true)
                {
                    string itemID = dataGridView_Item.Rows[i].Cells["ColID"].Value.ToString();

                    if (MasterData.isReferred(MasterDataType.item, itemID))
                    {
                        if (MessageBox.Show("房产已被引用，无法删除！是否继续删除下一次记录？否则中止操作。", "房地产销售佣金结算管理系统", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            continue;
                        else
                            return;
                    }

                    sql = "delete SaleItem where ItemID  = " + itemID;
                    SqlHelper.ExecuteNonQuery(sql);
                }
            }

            SearchSaleItem();
        }

        private void FrmSaleItem_Shown(object sender, EventArgs e)
        {
            textBox_Building.Focus();
        }

        private void toolStripButton_Settle_Click(object sender, EventArgs e)
        {
            if (!hasItemChecked())
            {
                Prompt.Warning("未选择设置对象！");
                return;
            }

            string payTypeCode = string.Empty;
            for (int i = 0; i < dataGridView_Item.RowCount; i++)
            {
                if ((bool)dataGridView_Item.Rows[i].Cells["ColCheck"].EditedFormattedValue)
                {
                    if (dataGridView_Item.Rows[i].Cells["ColSaleStateName"].Value.ToString() != "签约")
                    {
                        Prompt.Warning("仅支持已签约记录进行结算设置！");
                        return;
                    }

                    if (payTypeCode.Equals(""))
                    {
                        payTypeCode = dataGridView_Item.Rows[i].Cells["ColPayTypeCode"].Value.ToString();
                    }
                    else
                    {
                        if (payTypeCode != dataGridView_Item.Rows[i].Cells["ColPayTypeCode"].Value.ToString())
                        {
                            Prompt.Warning("仅支持相同付款类型的记录进行批量设置！");
                            return;
                        }
                    }
                }
            }

            string sql = string.Empty;

            FrmSettleSet settle = new FrmSettleSet();

            settle.PayTypeCode = payTypeCode;

            if (settle.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                for (int i = 0; i < dataGridView_Item.RowCount; i++)
                {
                    if ((bool)dataGridView_Item.Rows[i].Cells["ColCheck"].EditedFormattedValue)
                    {
                        sql = "update SaleItem set SettleBaseCode = " + settle.BaseCode
                            + ",SettleBaseName = '" + settle.BaseName + "'"
                            + ",SettleStandardCode = " + settle.StandardCode
                            + ",SettleStandardName = '" + settle.StandardName + "' "
                            + "where ItemID  = " + dataGridView_Item.Rows[i].Cells["ColID"].Value.ToString();
                        SqlHelper.ExecuteNonQuery(sql);

                        dataGridView_Item.Rows[i].Cells["ColSettleStandardName"].Value = settle.StandardName; 
                        dataGridView_Item.Rows[i].Cells["ColSettleBaseName"].Value = settle.BaseName;

                    }
                }
                Prompt.Information("结算设置完成！");
            }
        }

        private void toolStripButton_Bottom_Click(object sender, EventArgs e)
        {
            if (!hasItemChecked())
            {
                Prompt.Warning("未选择设置对象！");
                return;
            }

            string sql = string.Empty;
            

            FrmBottomSet frmBottom = new FrmBottomSet();
            if (frmBottom.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (frmBottom.BottomParaType == 0)
                    SetBottomBase(frmBottom.BottomSet);
                else
                    SetBottomRange(frmBottom.Range);

            }

        }

        private void SetBottomBase(Dictionary<string, string> bottomSet)
        {
            string price = string.Empty;
            double area = 0;
            for (int i = 0; i < dataGridView_Item.RowCount; i++)
            {
                if ((bool)dataGridView_Item.Rows[i].Cells["ColCheck"].EditedFormattedValue)
                {
                    if (double.Parse(bottomSet["Price"]) == 0)
                    {
                        double.TryParse(dataGridView_Item.Rows[i].Cells["ColArea"].Value.ToString(), out area);
                        price = Math.Round((double.Parse(bottomSet["Amount"]) / area), 4, MidpointRounding.AwayFromZero).ToString();
                    }
                    else
                    {
                        price = bottomSet["Price"].ToString();
                    }


                    string sql = "update SaleItem set BottomPrice = " + price
                        + ", BottomPriceLimit = " + bottomSet["Limit"].ToString()
                        + ", BottomPriceRate = " + bottomSet["Rate"].ToString()
                        + " where ItemID  = " + dataGridView_Item.Rows[i].Cells["ColID"].Value.ToString();
                    SqlHelper.ExecuteNonQuery(sql);

                    dataGridView_Item.Rows[i].Cells["ColBottomPrice"].Value = price;
                    dataGridView_Item.Rows[i].Cells["ColBottomPriceLimit"].Value = bottomSet["Limit"].ToString();
                    dataGridView_Item.Rows[i].Cells["ColBottomPriceRate"].Value = bottomSet["Rate"].ToString();

                }
            }
            Prompt.Information("操作成功，底价设置完成！");
        }

        private void SetBottomRange(double range)
        {
            for (int i = 0; i < dataGridView_Item.RowCount; i++)
            {
                if ((bool)dataGridView_Item.Rows[i].Cells["ColCheck"].EditedFormattedValue)
                {
                    double bPrice = 0;
                    double.TryParse(dataGridView_Item.Rows[i].Cells["ColBottomPrice"].Value.ToString(), out bPrice);

                    string newBottomPrice = (bPrice + range).ToString();

                    string sql = string.Format("update SaleItem set BottomPrice = {0} where ItemID = {1}", newBottomPrice, dataGridView_Item.Rows[i].Cells["ColID"].Value.ToString());
                    SqlHelper.ExecuteNonQuery(sql);
                    dataGridView_Item.Rows[i].Cells["ColBottomPrice"].Value = newBottomPrice;
                }

            }
            Prompt.Information("操作成功，底价设置完成！");
        }

        private void toolStripButton_None_Click(object sender, EventArgs e)
        {
            dataGridView_Item.EndEdit();

            for (int i = 0; i < dataGridView_Item.Rows.Count; i++)
            {
                dataGridView_Item.Rows[i].Cells["ColCheck"].Value = false;
            }
        }

        private void toolStripButton_Edit_Click(object sender, EventArgs e)
        {
            if (dataGridView_Item.CurrentRow == null)
            {
                Prompt.Warning("没有选择相应的记录！");
                return;
            }

            FrmSaleItemAdd itemAdd = new FrmSaleItemAdd();
            itemAdd.IsModifyMode = true;
            itemAdd.ItemID = dataGridView_Item.CurrentRow.Cells["ColID"].Value.ToString();
            itemAdd.ShowDialog();

        }

        private void toolStripButton_CloseCase_Click(object sender, EventArgs e)
        {
            //if (!hasItemChecked())
            //{
            //    Prompt.Information("没有选择相应的记录！");
            //    return;
            //}

            //string sql = string.Empty;

            //for (int i = 0; i < dataGridView_Item.RowCount; i++)
            //{
            //    string itemID = dataGridView_Item.Rows[i].Cells["ColID"].Value.ToString();

            //    if ((bool)dataGridView_Item.Rows[i].Cells["ColCheck"].EditedFormattedValue)
            //    {
            //        if (checkSaleState(ItemSaleState.签约, itemID))
            //        {
            //            sql = "update SaleItem set SaleState = 3 where ItemID = " + itemID;
            //            SqlHelper.ExecuteNonQuery(sql);
            //            dataGridView_Item.Rows[i].Cells["ColState"].Value = "结案";
            //        }
            //        else
            //        {
            //            if (MessageBox.Show("仅签约状态才能设置结案！是否继续下一次记录？否则中止操作。", "房地产销售佣金结算管理系统", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            //                continue;
            //            else
            //                return;
            //        }
            //    }
            //}

            //Prompt.Information("结案设置完成！");
        }

        private void toolStripButton_Recovery_Click(object sender, EventArgs e)
        {
            //if (!hasItemChecked())
            //{
            //    Prompt.Information("没有选择相应的记录！");
            //    return;
            //}

            //string sql = string.Empty;

            //for (int i = 0; i < dataGridView_Item.RowCount; i++)
            //{
            //    string itemID = dataGridView_Item.Rows[i].Cells["ColID"].Value.ToString();

            //    if ((bool)dataGridView_Item.Rows[i].Cells["ColCheck"].EditedFormattedValue)
            //    {
            //        if (checkSaleState(ItemSaleState.closed, itemID))
            //        {
            //            sql = "update SaleItem set SaleState = 2 where ItemID = " + itemID;
            //            SqlHelper.ExecuteNonQuery(sql);
            //            dataGridView_Item.Rows[i].Cells["ColState"].Value = "签约";
            //        }
            //        else
            //        {
            //            if (MessageBox.Show("仅结案状态才能恢复！是否继续下一次记录？否则中止操作。", "房地产销售佣金结算管理系统", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            //                continue;
            //            else
            //                return;
            //        }
            //    }
            //}

            //Prompt.Information("恢复操作完成！");
        }

        private bool checkSaleState(ItemSaleState state, string itemID)
        {
            bool result = false;

            string sql = string.Format("select SaleState from SaleItem where ItemID = {0}", itemID);

            object objResult = SqlHelper.ExecuteScalar(sql);
            if (objResult != null)
            {
                if (int.Parse(objResult.ToString()) == (int)state)
                    return true;
            }

            return result;
        }

        private void toolStripButton_Up_Click(object sender, EventArgs e)
        {
            if (!hasItemChecked())
            {
                Prompt.Warning("未选择设置对象！");
                return;
            }
            string sql = string.Empty;

            //检验：已签约的不允许再修改????????已结算？？？

            FrmUpgrade frmUp = new FrmUpgrade();
            frmUp.FrmMode = FormMode.view;

            System.Windows.Forms.DialogResult formRsult = frmUp.ShowDialog();

            if (formRsult ==  System.Windows.Forms.DialogResult.OK)
            {
                Dictionary<int, string> UpInfo = frmUp.UpInfo;
                
                for (int i = 0; i < dataGridView_Item.RowCount; i++)
                {
                    if (((bool)dataGridView_Item.Rows[i].Cells["ColCheck"].EditedFormattedValue))
                    {
                        try
                        {
                            sql = string.Format("update SaleItem set UpID = {0}, UpName = '{1}', SettleRate = {2} where ItemID = {3}", UpInfo[1].ToString(), UpInfo[2].ToString(), UpInfo[3].ToString(), dataGridView_Item.Rows[i].Cells["ColID"].Value.ToString());
                            SqlHelper.ExecuteNonQuery(sql);
                            dataGridView_Item.Rows[i].Cells["ColUpName"].Value = UpInfo[2].ToString();
                            dataGridView_Item.Rows[i].Cells["ColSettleRate"].Value = UpInfo[3].ToString();
                        }
                        catch (Exception ex)
                        {
                            Prompt.Error("操作错误，执行中止！\r\n错误信息：" +ex.Message);
                            return;
                        }
                    }
                }

                Prompt.Information("操作成功，数据已更新！");
            }

            //取消置空
            if (formRsult == System.Windows.Forms.DialogResult.No)
            {
                for (int i = 0; i < dataGridView_Item.RowCount; i++)
                {
                    if (((bool)dataGridView_Item.Rows[i].Cells["ColCheck"].EditedFormattedValue))
                    {
                        try
                        {
                            sql = string.Format("update SaleItem set UpID = NULL, UpName = NULL where ItemID = {0}", dataGridView_Item.Rows[i].Cells["ColID"].Value.ToString());
                            SqlHelper.ExecuteNonQuery(sql);
                            dataGridView_Item.Rows[i].Cells["ColUpName"].Value = "";
                        }
                        catch (Exception ex)
                        {
                            Prompt.Error("操作错误，执行中止！\r\n错误信息：" + ex.Message);
                            return;
                        }
                    }
                }

                Prompt.Information("操作成功，数据已更新！");
            }
        }

        private ArrayList getItem()
        {
            ArrayList item = new ArrayList();

            for (int i = 0; i < dataGridView_Item.Rows.Count; i++)
            {
                if ((bool)dataGridView_Item.Rows[i].Cells["ColCheck"].EditedFormattedValue)
                    item.Add(dataGridView_Item.Rows[i].Cells["ColID"].Value.ToString());
            }
            return item;
        }

        private void toolStripButton_Export_Click(object sender, EventArgs e)
        {

            if (dataGridView_Item.Rows.Count == 0)
            {
                Prompt.Warning("无楼盘记录，无法导出");
            }
            else
            {
                toolStripButton_Export.Enabled = false;
                Exp2Exc();
                toolStripButton_Export.Enabled = true;
            }
        }

        private void Exp2Exc()
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


                worksheet.Cells[1, 1].Value = dataGridView_Item.Columns["ColID"].HeaderText;
                worksheet.Cells[1, 2].Value = dataGridView_Item.Columns["ColProjectName"].HeaderText;
                worksheet.Cells[1, 3].Value = dataGridView_Item.Columns["ColBuilding"].HeaderText;
                worksheet.Cells[1, 4].Value = dataGridView_Item.Columns["ColUnit"].HeaderText;
                worksheet.Cells[1, 5].Value = dataGridView_Item.Columns["ColNum"].HeaderText;
                worksheet.Cells[1, 6].Value = dataGridView_Item.Columns["ColArea"].HeaderText;
                worksheet.Cells[1, 7].Value = dataGridView_Item.Columns["ColPrice"].HeaderText;
                worksheet.Cells[1, 8].Value = dataGridView_Item.Columns["ColBottomPrice"].HeaderText;
                worksheet.Cells[1, 9].Value = dataGridView_Item.Columns["ColBottomPriceRate"].HeaderText;
                worksheet.Cells[1, 10].Value = dataGridView_Item.Columns["ColBottomPriceLimit"].HeaderText;

                worksheet.Column(6).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                worksheet.Column(7).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                worksheet.Column(8).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                worksheet.Column(9).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                worksheet.Column(6).Style.Numberformat.Format = "#0.00";


                int iRow;
                for (int i = 0; i < dataGridView_Item.Rows.Count; i++)
                {
                    iRow = i + 2;

                    string area = dataGridView_Item.Rows[i].Cells["ColArea"].FormattedValue.ToString();
                    string rate = dataGridView_Item.Rows[i].Cells["ColBottomPriceRate"].FormattedValue.ToString().Replace("%", "");

                    worksheet.Cells[iRow, 1].Value = dataGridView_Item.Rows[i].Cells["ColID"].FormattedValue;
                    worksheet.Cells[iRow, 2].Value = dataGridView_Item.Rows[i].Cells["ColProjectName"].FormattedValue;
                    worksheet.Cells[iRow, 3].Value = dataGridView_Item.Rows[i].Cells["ColBuilding"].FormattedValue;
                    worksheet.Cells[iRow, 4].Value = dataGridView_Item.Rows[i].Cells["ColUnit"].FormattedValue;
                    worksheet.Cells[iRow, 5].Value = dataGridView_Item.Rows[i].Cells["ColNum"].FormattedValue;
                    worksheet.Cells[iRow, 6].Value = string.IsNullOrEmpty(area) ? 0 : double.Parse(area);
                    worksheet.Cells[iRow, 7].Value = dataGridView_Item.Rows[i].Cells["ColPrice"].FormattedValue;
                    worksheet.Cells[iRow, 8].Value = dataGridView_Item.Rows[i].Cells["ColBottomPrice"].FormattedValue;
                    worksheet.Cells[iRow, 9].Value = string.IsNullOrEmpty(rate) ? 0 : double.Parse(rate);
                    worksheet.Cells[iRow, 10].Value =  double.Parse(dataGridView_Item.Rows[i].Cells["ColBottomPriceLimit"].FormattedValue.ToString());
                }



                Console.WriteLine("2-- " + DateTime.Now.ToLongTimeString());
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton_Rate_Click(object sender, EventArgs e)
        {
            if (!hasItemChecked())
            {
                Prompt.Warning("未选择设置对象！");
                return;
            }
            string sql = string.Empty;

            FrmRateSet rateset = new FrmRateSet();

            if (rateset.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string rate = rateset.rate;
                string amount = rateset.amount;

                for (int i = 0; i < dataGridView_Item.RowCount; i++)
                {
                    if ((bool)dataGridView_Item.Rows[i].Cells["ColCheck"].EditedFormattedValue)
                    {
                        string itemId = dataGridView_Item.Rows[i].Cells["ColID"].Value.ToString();
                        //比例
                        sql = string.Format("update SaleItem set SettleRate = {0} where ItemID = {1}", rate, itemId);
                        SqlHelper.ExecuteNonQuery(sql);
                        dataGridView_Item.Rows[i].Cells["ColSettleRate"].Value = rate;

                        //金额
                        sql = string.Format("update SaleItem set SettleAmount = {0} where ItemID = {1}", amount, itemId);
                        SqlHelper.ExecuteNonQuery(sql);
                        dataGridView_Item.Rows[i].Cells["ColSpecialAmount"].Value = amount;
                    }
                }
                Prompt.Information("操作成功！");
            }

        }

        private void toolStripButton_Locking_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要锁定选择的记录？", Common.MsgCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                SetLockState(true);
            }
        }

        private void toolStripButton_Unlock_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要解锁选择的记录？", Common.MsgCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                SetLockState(false);
            }
        }

        private void SetLockState(bool isLocking)
        {
            if (!hasItemChecked())
            {
                Prompt.Warning("未选择设置对象！");
                return;
            }

            string state = isLocking ? "1" : "0";
            string stateName = isLocking ? "是" : "否";

            string sql = string.Empty;
            for (int i = 0; i < dataGridView_Item.RowCount; i++)
            {
                if ((bool)dataGridView_Item.Rows[i].Cells["ColCheck"].EditedFormattedValue)
                {
                    string itemId = dataGridView_Item.Rows[i].Cells["ColID"].Value.ToString();

                    sql = string.Format("update SaleItem set IsLocking = {0} where ItemID = {1}", state, itemId);
                    SqlHelper.ExecuteNonQuery(sql);
                    dataGridView_Item.Rows[i].Cells["ColIsLocking"].Value = stateName;
                }
            }
        }

    }
}
