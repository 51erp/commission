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

namespace Commission.MenuForms
{
    public partial class FrmSaleItem : Form
    {
        public FrmSaleItem()
        {
            InitializeComponent();
            InitDefComponent();
        }

        private void InitDefComponent()
        {
            MasterData.SetItemType(comboBox_ItemType, ComboBoxType.search);
            MasterData.setSaleState(comboBox_SaleState, ComboBoxType.search);
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

        /// <summary>
        /// 按条件查询销售项目
        /// </summary>
        private void SearchSaleItem()
        {
            string sql = "select ItemID,'0' as Choose, Building,Unit,ItemNum,Area, Price, ROUND(Area * Price,0) Amount, "
                + "ItemTypeName, SaleStateCode, SaleStateName, (case IsBind when 1 then N'是'end) IsBind "
                + "From SaleItem where  ProjectID =  " + Login.User.ProjectID;

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

            if (!comboBox_SaleState.SelectedValue.ToString().Equals("9"))
            {
                sql += " and SaleStateCode = " + comboBox_SaleState.SelectedValue.ToString();
            }

            sql += " order by ItemTypeCode asc, Building,Unit,ItemNum ";

            dataGridView_Item.DataSource = SqlHelper.ExecuteDataTable(sql);

            Common.SetColumnStyle(dataGridView_Item.Columns["ColArea"], ColType.area);
            Common.SetColumnStyle(dataGridView_Item.Columns["ColPrice"], ColType.price);
            Common.SetColumnStyle(dataGridView_Item.Columns["ColAmount"], ColType.amount);

            if (dataGridView_Item.Rows.Count == 0)
                Prompt.Information("没有符合条件的查询结果！");

        }

        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {
            if (!hasItemChecked())
            {
                Prompt.Information("没有选择相应的记录！");
                return;
            }

            if (MessageBox.Show("确认要删除所选记录？", "房地产销售佣金结算管理系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                return;

            string sql = string.Empty;
            for (int i = 0; i < dataGridView_Item.Rows.Count; i++)
            {
                if ((bool)dataGridView_Item.Rows[i].Cells["ColCheck"].EditedFormattedValue == true)
                {
                    string itemID = dataGridView_Item.Rows[i].Cells["ColItemID"].Value.ToString();

                    string saleState = dataGridView_Item.Rows[i].Cells["ColSaleState"].Value.ToString();
                    if ((saleState != "待售") && (saleState != "保留"))
                    {
                        if (MessageBox.Show("房源已存在业务记录，无法删除！是否继续删除下一条记录？", "房地产销售佣金结算管理系统", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
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

        private bool hasItemChecked()
        {
            for (int i = 0; i < dataGridView_Item.Rows.Count; i++)
            {
                if ((bool)dataGridView_Item.Rows[i].Cells["ColCheck"].EditedFormattedValue)
                    return true;
            }
            return false; ;
        }

        private void FrmSaleItem_Shown(object sender, EventArgs e)
        {
            textBox_Building.Focus();
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
            itemAdd.ItemID = dataGridView_Item.CurrentRow.Cells["ColItemID"].Value.ToString();
            itemAdd.ShowDialog();

        }

        private void toolStripButton_UnBind_Click(object sender, EventArgs e)
        {
            SetItemBind(false);
        }
        private void toolStripButton_Bind_Click(object sender, EventArgs e)
        {
            SetItemBind(true);
        }


        private void SetItemBind(bool isBind)
        {
            string bind = isBind ? "1" : "0";

            if (!hasItemChecked())
            {
                Prompt.Information("没有选择相应的记录！");
                return;
            }

            for (int i = 0; i < dataGridView_Item.Rows.Count; i++)
            {
                if ((bool)dataGridView_Item.Rows[i].Cells["ColCheck"].EditedFormattedValue)
                {
                    if (dataGridView_Item.Rows[i].Cells["ColSaleStateCode"].Value.ToString() != ((int)ItemSaleState.待售).ToString())
                    {
                        Prompt.Warning("仅允许待售物业设置附属标记！");
                        return;
                    }
                }
            }

            if (MessageBox.Show("是否要设置所选记录？", "房地产销售佣金结算管理系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                return;

            for (int i = 0; i < dataGridView_Item.Rows.Count; i++)
            {
                if ((bool)dataGridView_Item.Rows[i].Cells["ColCheck"].EditedFormattedValue)
                {
                    string sql = string.Format("update SaleItem set IsBind = {0} where ItemID = {1} ",isBind ? "1" : "0", dataGridView_Item.Rows[i].Cells["ColItemID"].Value.ToString());
                    if (SqlHelper.ExecuteNonQuery(sql) > 0)
                    {
                        dataGridView_Item.Rows[i].Cells["ColIsBind"].Value = isBind ? "是" : "";
                    }
                }

            }

            Prompt.Information("操作成功，数据已更新！");
        }

 

    }
}
