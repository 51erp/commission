using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Commission.Forms
{
    public partial class FrmConfig : Form
    {
        public FrmConfig()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            cfa.AppSettings.Settings["IPAddr"].Value = textBox_IP.Text.Trim();

            cfa.Save();

            ConfigurationManager.RefreshSection("appSettings");

            Prompt.Information("操作成功，请重新登录！");

            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {
            textBox_IP.Text = ConfigurationManager.AppSettings["IPAddr"];
        }
    }
}
