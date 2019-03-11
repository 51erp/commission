using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Commission.Forms
{
    public partial class FrmBottomSet : Form
    {
        public int BottomParaType = 0;
        public Dictionary<string, string> BottomSet = new Dictionary<string, string>();
        public double Range = 0;

        //public string Price = string.Empty;
        //public string PriceLimit = string.Empty;
        //public string PriceRate = string.Empty;
        public FrmBottomSet()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            if (tabControl_Bottom.SelectedIndex == 0)
            {
                if (inputValidate())
                {
                    BottomParaType = 0;

                    BottomSet.Add("Price", textBox_BottomPrice.Text.Trim());
                    BottomSet.Add("Amount", textBox_BottomAmount.Text.Trim());
                    BottomSet.Add("Limit", textBox_BottomPriceLimit.Text.Trim());
                    BottomSet.Add("Rate", textBox_BottomPriceRate.Text.Trim());

                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }

            if (tabControl_Bottom.SelectedIndex == 1)
            {
                BottomParaType = 1;

                if (!double.TryParse(textBox_Range.Text.Trim(), out Range))
                {
                    Prompt.Warning("增幅必须为有效数字！");
                    return;
                }

                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            
        }

        private bool inputValidate()
        {
            double price = 0;
            if (!double.TryParse(textBox_BottomPrice.Text.Trim(), out price) )
            {
                Prompt.Warning("请输入有效数值！");
                textBox_BottomPrice.Focus();
                textBox_BottomPrice.SelectAll();
                return false;
            }

            double amount = 0;
            if (!double.TryParse(textBox_BottomAmount.Text.Trim(), out amount))
            {
                Prompt.Warning("请输入有效数值！");
                textBox_BottomAmount.Focus();
                textBox_BottomAmount.SelectAll();
                return false;
            }

            if (price == 0 && amount == 0)
            {
                Prompt.Error("单价和总价不能同时为零");
                textBox_BottomPrice.Focus();
                textBox_BottomPrice.SelectAll();
                return false;
            }

            if (price > 0 && amount > 0)
            {
                Prompt.Error("单价和总价只能设置一个");
                textBox_BottomPrice.Focus();
                textBox_BottomPrice.SelectAll();
                return false;
            }

            double result = 0;
            if (!double.TryParse(textBox_BottomPriceLimit.Text.Trim(),out result))
            {
                Prompt.Warning("请输入有效数值！");
                textBox_BottomPriceLimit.Focus();
                textBox_BottomPriceLimit.SelectAll();
                return false;
            }

            if (!double.TryParse(textBox_BottomPriceRate.Text.Trim(), out result))
            {
                Prompt.Warning("请输入有效数值！");
                textBox_BottomPriceRate.Focus();
                textBox_BottomPriceRate.SelectAll();
                return false;
            }

            if (result <= 0)
            {
                Prompt.Warning("溢价分成必须大于0！");
                textBox_BottomPriceRate.Focus();
                textBox_BottomPriceRate.SelectAll();
                return false;
            }

            return true;
        }



        private void textBox_Validated(object sender, EventArgs e)
        {
            double result = 0;
            if (!double.TryParse(((TextBox)sender).Text.Trim(), out result))
            {
                Prompt.Warning("请输入有效数字");
            }
        }
    }
}
