using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Commission.Forms
{
    public partial class FrmRateSet : Form
    {
        public string rate = string.Empty;
        public string amount = string.Empty;
        public FrmRateSet()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            if (!IsValidInput())
            {
                return;
            }

            if (MessageBox.Show("确定要设置提点数值？", Common.MsgCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                rate = textBox_Rate.Text.Trim();
                amount = textBox_Amount.Text.Trim();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private bool IsValidInput()
        {
            bool result = true;
            double rate = 0;
            double amount = 0;

            if (string.IsNullOrEmpty(textBox_Rate.Text.Trim()))
            {
                Prompt.Error("结算比例不能为空！");
                textBox_Rate.Focus();
                return false;
            }

            if (!double.TryParse(textBox_Rate.Text.Trim(),out rate))
            {
                Prompt.Error("结算比例必须为有效数字！");
                textBox_Rate.Focus();
                textBox_Rate.SelectAll();
                return false;
            }
            else if (rate < 0)
            {
                Prompt.Error("结算比例不能为负数！");
                textBox_Rate.Focus();
                textBox_Rate.SelectAll();
                return false;
            }

            if (string.IsNullOrEmpty(textBox_Amount.Text.Trim()))
            {
                Prompt.Error("单套金额不能为空！");
                textBox_Amount.Focus();
                return false;
            }

            if (!double.TryParse(textBox_Amount.Text.Trim(),out amount))
            {
                Prompt.Error("单套金额必须为有效数字！");
                textBox_Amount.Focus();
                return false;
            }
            else if (amount < 0)
            {
                Prompt.Error("单套金额不能为负数！");
                textBox_Amount.Focus();
                textBox_Amount.SelectAll();
                return false;
            }

            if (rate > 0 && amount > 0)
            {
                Prompt.Error("结算比例、单套金额不能同时设置！");
                return false;
            }

            return result;
        }

    }
}
