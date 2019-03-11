using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Commission.Utility
{
    class Prompt
    {
        public static string FormCaption = "房地产佣金结算系统";

        public static void Error(string msg)
        {
            MessageBox.Show(msg, FormCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //throw new NotImplementedException();
        }

        public static void Information(string msg)
        {
            MessageBox.Show(msg, FormCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Warning(string msg)
        {
            MessageBox.Show(msg, FormCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult Question(string msg)
        {
            return MessageBox.Show(msg, FormCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

    }
}
