using Commission.Business;
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
    public partial class FrmContractDateAdd : Form
    {
        public string ItemTypeCode = string.Empty;
        public string ItemTypeName = string.Empty;
        public string IntervalDays = string.Empty;

        public FrmContractDateAdd()
        {
            InitializeComponent();
            MasterData.SetItemType(comboBox_ItemType);
        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Close();
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            int days = 0;
            if (!int.TryParse(textBox_Days.Text.Trim(), out days))
            {
                Prompt.Error("递延天数必须为有效数字！");
                return;
            }
            if (days <= 0)
            {
                Prompt.Error("递延天数必须为正数！");
                return;
            }

            ItemTypeCode = comboBox_ItemType.SelectedValue.ToString();
            ItemTypeName = comboBox_ItemType.Text;
            IntervalDays = textBox_Days.Text.Trim();

            string sql = string.Format("select COUNT(ID) from ParaIntervalDays where ProjectID = {0} and ItemTypeCode = {1}", Login.User.ProjectID, ItemTypeCode);

            if (int.Parse(SqlHelper.ExecuteScalar(sql).ToString()) > 0)
            {
                Prompt.Error("已设置指定物业类型的递延天数，不能重复设置！");
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void FrmContractDateAdd_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox_Days_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.OnlyNumeric(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
