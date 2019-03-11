using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Commission.Business;
using System.Data.SqlClient;

namespace Commission.Forms
{
    public partial class FrmSaleItemAdd : Form
    {
        public bool IsModifyMode = false;
        public string ItemID = string.Empty;

        private string _projectID = string.Empty;
        private string _building = string.Empty;
        private string _unit = string.Empty;
        private string _itemNum = string.Empty;

        public FrmSaleItemAdd()
        {
            InitializeComponent();
            InitDefComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            this.Validate();

            if (comboBox_ItemType.SelectedValue == null)
            {
                Prompt.Warning("没有房产类型的信息,无法操作！");
                return;
            }

            string sql = string.Empty;

            if (inputValidate())
            {
                if (IsModifyMode)
                {
                    if (isValueChange() && isExistItem()) //修改后数据与数据库记录重复
                    {
                        Prompt.Warning("楼盘信息已存在，不允许重复录入！");
                        return;
                    }

                    string upDateField = " Building = '" + textBox_Building.Text.Trim() + "',"
                        + "Unit = '" + textBox_Unit.Text.Trim() + "',"
                        + "ItemNum = '" + textBox_ItemNum.Text.Trim() + "',"
                        + "Area = " + textBox_Area.Text.Trim() + ","
                        + "Price = " + textBox_Price.Text.Trim() + ","
                        + "ItemTypeCode = " + comboBox_ItemType.SelectedValue.ToString() + ","
                        + "ItemTypeName = '" +comboBox_ItemType.Text + "',"
                        + "IsBind = " + (checkBox_SaleType.Checked ? 1 : 0).ToString();

                    sql = "update SaleItem set " + upDateField + " where itemID = " + ItemID;
                }
                else
                {
                    if (isExistItem())
                    {
                        Prompt.Warning("楼盘信息已存在，不允许重复录入！");
                        return;
                    }

                    string value = Login.User.ProjectID + ",'"
                         + Login.User.ProjectName + "','"
                         + textBox_Building.Text.Trim() + "','"
                         + textBox_Unit.Text.Trim() + "','"
                         + textBox_ItemNum.Text.Trim() + "',"
                         + textBox_Area.Text.Trim() + ","
                         + textBox_Price.Text.Trim() + ","
                         + comboBox_ItemType.SelectedValue.ToString() + ",'"
                         + comboBox_ItemType.Text + "',"
                         + (checkBox_SaleType.Checked ? 1 : 0).ToString() + ","
                         + (int)ItemSaleState.待售 + ",'"
                         + ItemSaleState.待售 + "'";

                    sql = "insert into SaleItem (ProjectID,ProjectName,Building,Unit,ItemNum,Area,Price,ItemTypeCode,ItemTypeName,IsBind, SaleStateCode, SaleStateName) values (" + value + ")";

                }
 
                if (SqlHelper.ExecuteNonQuery(sql) > 0)
                {
                    inputInit();
                    Prompt.Information("操作成功");
                    Close();
                }
            }
        }

        private bool isExistItem()
        {
            bool result = false;

            string sql = "select count(*) cnt from SaleItem "
                + " where ProjectID = " + Login.User.ProjectID
                + " and Building = '" + textBox_Building.Text.Trim() + "'"
                + " and Unit = '" + textBox_Unit.Text.Trim() + "'"
                + " and ItemNum = '" + textBox_ItemNum.Text.Trim() + "'";

            object sqlResult = SqlHelper.ExecuteScalar(sql);
            if (int.Parse(sqlResult.ToString()) > 0)
            {
                result = true;
            }

            return result;
        }

        private bool isValueChange()
        {
            if ((_building == textBox_Building.Text.Trim()) && (_unit == textBox_Unit.Text.Trim()) && (_itemNum == textBox_ItemNum.Text.Trim()))
            {
                return false;
            }

            return true;
        }

        private void FrmSaleItemAdd_Load(object sender, EventArgs e)
        {
            if (IsModifyMode)
            {
                this.Text = "修改房产信息";
                loadData(ItemID);
            }
                
        }

        private void loadData(string itemID)
        {
            string sql = "select Building,Unit,ItemNum,Area,Price,ItemTypeCode,IsBind from SaleItem where itemID = " + itemID;
            SqlDataReader sdr = SqlHelper.ExecuteReader(sql);

            sdr.Read();

            _building = sdr["Building"].ToString();
            _unit = sdr["Unit"].ToString();
            _itemNum = sdr["ItemNum"].ToString();

            textBox_Building.Text = sdr["Building"].ToString();
            textBox_Unit.Text = sdr["Unit"].ToString();
            textBox_ItemNum.Text = sdr["ItemNum"].ToString();
            textBox_Area.Text = sdr["Area"].ToString();
            textBox_Price.Text = sdr["Price"].ToString();
            comboBox_ItemType.SelectedValue = sdr["ItemTypeCode"].ToString();
            checkBox_SaleType.Checked = bool.Parse(sdr["IsBind"].ToString());
        }

        private void InitDefComponent()
        {
            MasterData.SetItemType(comboBox_ItemType);
        }

        private void inputInit()
        {
            textBox_Unit.Text = "";
            textBox_ItemNum.Text = "";
            textBox_Area.Text = "0";
            textBox_Price.Text = "0";
            textBox_Building.Text = "";
            textBox_Building.Focus();
        }

        private bool inputValidate()
        {
            if (comboBox_ItemType.Text == "房产")
            {
                if (textBox_Building.Text.Trim() == "")
                {
                    textBox_Building.Focus();
                    Prompt.Warning("楼号不能为空！");
                    return false;
                }

                if (textBox_Unit.Text.Trim() == "")
                {
                    textBox_Unit.Focus();
                    Prompt.Warning("单元号不能为空！");
                    return false;
                }
            }

            if (textBox_ItemNum.Text.Trim() == "")
            {
                textBox_ItemNum.Focus();
                Prompt.Warning("编号不能为空！");
                return false;
            }

            if (textBox_Area.Text.Trim().Equals("") || textBox_Area.Text.Trim().Equals("0"))
            {
                textBox_Area.Focus();
                Prompt.Warning("面积不能为空或零！");
                return false;
            }

            if (textBox_Price.Text.Trim().Equals(""))
            {
                textBox_Price.Focus();
                Prompt.Warning("单价不能为空！");
                return false;
            }

            if (textBox_Amount.Text.Trim().Equals(""))
            {
                textBox_Price.Focus();
                Prompt.Warning("总价不能为空！");
                return false;
            }


            double result = 0;
            if (!double.TryParse(textBox_Area.Text.Trim(), out result))
            {
                Prompt.Warning("面积不是有效数字！");
                textBox_Area.Focus();
                return false;
            }

            if (!double.TryParse(textBox_Price.Text.Trim(), out result))
            {
                Prompt.Warning("单价不是有效数字！");
                textBox_Price.Focus();
                return false;
            }

            if (!double.TryParse(textBox_Amount.Text.Trim(), out result))
            {
                Prompt.Warning("总价不是有效数字！");
                textBox_Price.Focus();
                return false;
            }

            return true; 
        }

        private void KeyPress_OnlyNumeric(object sender, KeyPressEventArgs e)
        {
            Common.OnlyNumeric(sender, e);
        }

        private void textBox_Area_Validating(object sender, CancelEventArgs e)
        {

        }

        private void textBox_Price_Validating(object sender, CancelEventArgs e)
        {

        }


        private void CalcAmount(object sender, EventArgs e)
        {
            double area = 0;
            double price = 0;
            double amount = 0;

            if (((TextBox)sender).Name.Equals("textBox_Area"))
            {
                double.TryParse(textBox_Area.Text, out area);

                if (area == 0)
                {
                    textBox_Price.Text = "0";
                    textBox_Amount.Text = "0";
                }
                else
                {
                    double.TryParse(textBox_Price.Text, out price);
                    textBox_Amount.Text = Math.Round((area * price), 0, MidpointRounding.AwayFromZero).ToString();
                }
            }
            else if (((TextBox)sender).Name.Equals("textBox_Price"))
            {
                double.TryParse(textBox_Area.Text, out area);
                double.TryParse(textBox_Price.Text, out price);

                textBox_Amount.Text = Math.Round((area * price), 0, MidpointRounding.AwayFromZero).ToString();
            }
            else if (((TextBox)sender).Name.Equals("textBox_Amount"))
            {
                double.TryParse(textBox_Area.Text, out area);

                if (area != 0)
                {
                    double.TryParse(textBox_Amount.Text, out amount);

                    textBox_Price.Text = Math.Round((amount / area), 4, MidpointRounding.AwayFromZero).ToString();
                }

            }
        }
    }
}
