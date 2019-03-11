using Commission.DataAccess;
using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Commission.Business;

namespace Commission.Forms
{

    public partial class FrmBaseSaleItem : Form
    {
        public int ItemSaleProperty = 2;
        public string saleItemID = string.Empty;
        public FrmBaseSaleItem()
        {
            InitializeComponent();
            MasterData.SetItemType(comboBox_ItemType, ComboBoxType.search);
        }

        private void toolStripButton_Canel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_OK_Click(object sender, EventArgs e)
        {
            getSaleItemID();
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            GetSaleItemData();

            if (dataGridView_Item.Rows.Count <= 0)
                Prompt.Information("没有符合条件的查询结果！");
        }

        private void FrmBaseSaleItem_Load(object sender, EventArgs e)
        {
            GetSaleItemData();
        }

        private void getSaleItemID()
        {
            if (dataGridView_Item.CurrentRow == null)
            {
                Prompt.Information("未选择相应记录！");
                return;
            }
            saleItemID = dataGridView_Item.CurrentRow.Cells["ColID"].Value.ToString();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void GetSaleItemData()
        {
            string condition = string.Empty;

            if (ItemSaleProperty < 2)
            {
                condition += " and IsBind = " + ItemSaleProperty.ToString();
            }

            condition += " and ProjectID = " + Login.User.ProjectID;

            if (comboBox_ItemType.Text != "全部")
            {
                condition += " and ItemTypeCode = " + comboBox_ItemType.SelectedValue.ToString();
            }

            if (!textBox_Building.Text.Trim().Equals(""))
            {
                condition += " and Building = '" + textBox_Building.Text.Trim() + "'";
            }

            if (!textBox_Unit.Text.Trim().Equals(""))
            {
                condition += " and Unit = '" + textBox_Unit.Text.Trim() + "'";
            }

            if (!textBox_ItemNum.Text.Trim().Equals(""))
            {
                condition += " and ItemNum = '" + textBox_ItemNum.Text.Trim() + "'";
            }

            string sql = "select ItemID, Building, Unit, ItemNum, Area, Price, ItemTypeName, case IsBind when 1 then '是' end  IsBind from SaleItem  where SaleStateCode = " + (int)ItemSaleState.待售 + condition + " Order by ItemTypeCode, Building,Unit,ItemNum";

            dataGridView_Item.DataSource = SqlHelper.ExecuteDataTable(sql);



        }

        private void dataGridView_Item_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) 
                return;

            getSaleItemID();
        }
    }
}
