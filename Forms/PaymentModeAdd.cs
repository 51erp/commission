using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Commission.Business;
using Commission.Utility;
using Commission.MenuForms;
using System.Data.SqlClient;


namespace Commission.Forms
{
    public partial class PaymentModeAdd : Form
    {
        public FormMode Mode = FormMode.add;
        public string PaymentID = string.Empty;

        public PaymentModeAdd()
        {
            InitializeComponent();
            InitMyComponent();
            SetInitValue();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PaymentModeAdd_Load(object sender, EventArgs e)
        {
            if (Mode == FormMode.modify)
            {
                this.Text = "付款方式－修改";
                LoadData();
            }

            if (Mode == FormMode.view)
            {
                this.Text = "付款方式－查看";
                toolStripButton_Save.Visible = false;

                textBox_PayName.ReadOnly = true;
                comboBox_PayType.Enabled = false;
                textBox_DonwPayRate.ReadOnly = true;
                comboBox_Stardard.Enabled = false;
                comboBox_Base.Enabled = false;

                LoadData();
            }
        }


        private void LoadData()
        {
            string sql = string.Format("select PayName,PayType,DownPayRate,StandardCode,BaseCode,Memo from PaymentMode where ID = {0}", PaymentID);
            SqlDataReader sdr = SqlHelper.ExecuteReader(sql);

            if (sdr.Read())
            {
                textBox_PayName.Text = sdr["PayName"].ToString();
                textBox_DonwPayRate.Text = sdr["DownPayRate"].ToString();
                textBox_Memo.Text = sdr["Memo"].ToString();

                comboBox_PayType.SelectedValue = sdr["PayType"].ToString();
                comboBox_Stardard.SelectedValue = sdr["StandardCode"].ToString();
                comboBox_Base.SelectedValue = sdr["BaseCode"].ToString();

                textBox_PayName.Focus();
            }
        }


        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            if (InputValidate())
            {
                string sql = string.Empty;
                if (Mode == FormMode.add)
                {
                    sql = string.Format("insert into PaymentMode (ProjectID,PayName,PayType,PayTypeName,DownPayRate,StandardCode,StandardName,BaseCode,BaseName,Memo) values"
                        + " ({0},'{1}',{2},'{3}',{4},{5},'{6}',{7},'{8}','{9}')",
                        Login.User.ProjectID,
                        textBox_PayName.Text.Trim(),
                        comboBox_PayType.SelectedValue.ToString(),
                        comboBox_PayType.Text,
                        textBox_DonwPayRate.Text.Trim(),
                        comboBox_Stardard.SelectedValue.ToString(),
                        comboBox_Stardard.Text,
                        comboBox_Base.SelectedValue.ToString(),
                        comboBox_Base.Text,
                        textBox_Memo.Text.Trim());
                }

                if (Mode == FormMode.modify)
                {
                    sql = string.Format("update PaymentMode set PayName = '{0}', PayType = {1}, PayTypeName = '{2}', DownPayRate = {3},"
                        + "StandardCode = {4}, StandardName = '{5}', BaseCode = {6}, BaseName = '{7}', Memo = '{8}' where ID = {9}", 
                        textBox_PayName.Text.Trim(),
                        comboBox_PayType.SelectedValue.ToString(),
                        comboBox_PayType.Text,
                        textBox_DonwPayRate.Text.Trim(),
                        comboBox_Stardard.SelectedValue.ToString(),
                        comboBox_Stardard.Text,
                        comboBox_Base.SelectedValue.ToString(),
                        comboBox_Base.Text,
                        textBox_Memo.Text.Trim(),
                        PaymentID);
                }

                try
                {
                    if (SqlHelper.ExecuteNonQuery(sql) > 0)
                    {
                        SetInitValue();
                        (this.Owner as FrmPaymentMode).GetPaymentMode();
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                }
                catch (Exception)
                {
                    Prompt.Error("操作失败，请重新操作或联系系统管理员。");
                }
            }

        }

        private bool InputValidate()
        {
            if (textBox_PayName.Text.Trim().Equals(""))
            {
                Prompt.Warning("付款方式不能为空");
                textBox_PayName.Focus();
                return false;
            }

            if ((textBox_DonwPayRate.Enabled))
            {
                if (textBox_DonwPayRate.Text.Trim().Equals(""))
                {
                    Prompt.Warning("首付比例不能为空");
                    textBox_DonwPayRate.Focus();
                    textBox_DonwPayRate.SelectAll();
                    return false;
                }
                double result = 0;
                if (!double.TryParse(textBox_DonwPayRate.Text.Trim(), out result))
                {
                    Prompt.Warning("首付比例必须为有效数字");
                    textBox_DonwPayRate.Focus();
                    textBox_DonwPayRate.SelectAll();
                    return false;
                }
                if ((result > 100) || (result <= 0))
                {
                    Prompt.Warning("首付比例的有效区间为：0 < 首付比例 <= 100");
                    textBox_DonwPayRate.Focus();
                    textBox_DonwPayRate.SelectAll();
                    return false;
                }

            }

            return true;
        }


        private void InitMyComponent()
        {
            MasterData.SetPayType(comboBox_PayType);
            this.comboBox_PayType.SelectedIndexChanged += new System.EventHandler(this.comboBox_PayType_SelectedIndexChanged);


            SetComboBoxStandardValue();
            this.comboBox_Stardard.SelectedIndexChanged += new System.EventHandler(this.comboBox_Stardard_SelectedIndexChanged);

            SetComboBoxBaseValue();

            textBox_PayName.Focus();
        }

        private void SetInitValue()
        {
            textBox_PayName.Text = string.Empty;
            textBox_DonwPayRate.Text = "100";
            textBox_DonwPayRate.Enabled = false;
            textBox_Memo.Text = string.Empty;

            comboBox_PayType.SelectedIndex = 0;

            textBox_PayName.Focus();
        }

        private void comboBox_PayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetComboBoxStandardValue();

            if ((Mode == FormMode.add) || (Mode == FormMode.modify))
            {
                if ((comboBox_PayType.SelectedIndex == 0) || (comboBox_PayType.SelectedIndex == 2))
                {
                    textBox_DonwPayRate.Text = "100";
                    textBox_DonwPayRate.Enabled = false;
                }
                else
                {
                    textBox_DonwPayRate.Enabled = true;
                    textBox_DonwPayRate.Text = "0";
                    textBox_DonwPayRate.Focus();
                    textBox_DonwPayRate.SelectAll();
                }
            }

        }


        private void SetComboBoxStandardValue()
        {
            string sql = string.Format("select distinct StandardCode, StandardName from SchemeSettle where PayCode = {0} order by StandardCode", comboBox_PayType.SelectedValue.ToString());

            comboBox_Stardard.DataSource = SqlHelper.ExecuteDataTable(sql);
            comboBox_Stardard.DisplayMember = "StandardName";
            comboBox_Stardard.ValueMember = "StandardCode";

            if (comboBox_Stardard.Items.Count > 0)
                comboBox_Stardard.SelectedIndex = 0;
        }

        private void comboBox_Stardard_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetComboBoxBaseValue();
        }

        private void SetComboBoxBaseValue()
        {
            string sql = string.Format("select BaseCode, BaseName from SchemeSettle where PayCode = {0} and  StandardCode = {1} order by BaseCode", comboBox_PayType.SelectedValue.ToString(), comboBox_Stardard.SelectedValue.ToString());

            comboBox_Base.DataSource = SqlHelper.ExecuteDataTable(sql);
            comboBox_Base.DisplayMember = "BaseName";
            comboBox_Base.ValueMember = "BaseCode";

            if (comboBox_Base.Items.Count > 0)
                comboBox_Base.SelectedIndex = 0;
        }

        private void textBox_DonwPayRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.OnlyNumeric(sender, e);
        }
    }
}
