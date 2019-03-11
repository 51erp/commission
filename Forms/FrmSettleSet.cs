using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Commission.Business;

namespace Commission.Forms
{
    public partial class FrmSettleSet : Form
    {
        public string PayTypeCode;
        public string BaseCode;
        public string BaseName;
        public string StandardCode;
        public string StandardName;

        bool isLoadComplete = false;


        public FrmSettleSet()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            BaseCode = comboBox_Base.SelectedValue.ToString();
            BaseName = comboBox_Base.Text;

            StandardCode = comboBox_Stardard.SelectedValue.ToString();
            StandardName = comboBox_Stardard.Text;

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void FrmSettleSet_Load(object sender, EventArgs e)
        {
            SetComboBoxStandardValue();
            isLoadComplete = true;
        }

        private void comboBox_Stardard_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetComboBoxBaseValue();
        }

        private void SetComboBoxStandardValue()
        {
            string sql = string.Format("select distinct StandardCode, StandardName from SchemeSettle where PayCode = {0} order by StandardCode", PayTypeCode);

            comboBox_Stardard.DataSource = SqlHelper.ExecuteDataTable(sql);
            comboBox_Stardard.DisplayMember = "StandardName";
            comboBox_Stardard.ValueMember = "StandardCode";

            if (comboBox_Stardard.Items.Count > 0)
                comboBox_Stardard.SelectedIndex = 0;
        }

        private void SetComboBoxBaseValue()
        {
            if (isLoadComplete)
            {
                string sql = string.Format("select BaseCode, BaseName from SchemeSettle where PayCode = {0} and  StandardCode = {1} order by BaseCode", PayTypeCode, comboBox_Stardard.SelectedValue.ToString());

                comboBox_Base.DataSource = SqlHelper.ExecuteDataTable(sql);
                comboBox_Base.DisplayMember = "BaseName";
                comboBox_Base.ValueMember = "BaseCode";

                if (comboBox_Base.Items.Count > 0)
                    comboBox_Base.SelectedIndex = 0;
            }
        }

        private void FrmSettleSet_Shown(object sender, EventArgs e)
        {
            SetComboBoxBaseValue();
        }



    }
}
