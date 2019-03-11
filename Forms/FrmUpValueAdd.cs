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
    public partial class FrmUpValueAdd : Form
    {
        public FrmUpValueAdd()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            if ((textBox_BeginValue.Text.Trim().Equals("")) && (textBox_EndValue.Text.Trim().Equals("")))
            {
                Prompt.Error("数值不能同时为空!");
                return;
            }

            if (textBox_Rate.Text.Trim().Equals(""))
            {
                Prompt.Error("比率不能同时为零或空!");
                return;
            }

            //(this.Owner as FrmUpSet).addNewRow(textBox_BeginValue.Text.Trim(), textBox_EndValue.Text.Trim(), textBox_Rate.Text);

            textBox_BeginValue.Text = "";
            textBox_EndValue.Text = "";
            textBox_Rate.Text = "";
            textBox_BeginValue.Focus();

        }

        private void textBox_BeginValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.OnlyNumeric(sender, e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.OnlyNumeric(sender, e);
        }

        private void textBox_EndValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.OnlyNumeric(sender, e);
        }

        private void toolStripSeparator1_Click(object sender, EventArgs e)
        {

        }
    }
}
