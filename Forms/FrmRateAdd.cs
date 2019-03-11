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
using Commission.MenuForms;
using System.Data.SqlClient;

namespace Commission.Forms
{
    public partial class FrmRateAdd : Form
    {
        public FormMode FrmMode = FormMode.add;
        public string ID = string.Empty;

        public FrmRateAdd()
        {
            InitializeComponent();
            MasterData.SetItemType(comboBox_ItemType, ComboBoxType.search);
        }


        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmRateAdd_Load(object sender, EventArgs e)
        {
            SetInitValue();
            if (FrmMode == FormMode.modify)
            {
                this.Text = "提点设置－修改";
                LoadRate();
            }
            
        }

        private void LoadRate()
        {
            string sql = string.Format("select RateName,ItemTypeCode,Rate,Amount,BeginDate,EndDate from SchemeRate where id = {0}", ID);
            SqlDataReader sdr = SqlHelper.ExecuteReader(sql);

            if (sdr.Read())
            {
                textBox_RateName.Text = sdr["RateName"].ToString();
                textBox_Rate.Text = sdr["Rate"].ToString(); ;
                textBox_Amount.Text = sdr["Amount"].ToString(); ;
                comboBox_ItemType.SelectedValue = sdr["ItemTypeCode"].ToString();

                dateTimePicker_BeginDate.Value = DateTime.Parse(sdr["BeginDate"].ToString());
                dateTimePicker_EndDate.Value = DateTime.Parse(sdr["EndDate"].ToString());
            }
        }


        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            if (InputValidate())
            {
                string sql = string.Empty;
                if (FrmMode == FormMode.add)
                {
                    sql = string.Format("insert into SchemeRate (ProjectID,RateName,ItemTypeCode,ItemTypeName,CommissionType, Rate,Amount,BeginDate,EndDate) "  
                        +" values ({0},'{1}',{2},'{3}',{4},{5},{6},'{7}','{8}')",
                        Login.User.ProjectID,
                        textBox_RateName.Text.Trim(),
                        comboBox_ItemType.SelectedValue.ToString(),
                        comboBox_ItemType.Text,
                        (double.Parse(textBox_Rate.Text.Trim()) > 0) ? 0:1,
                        textBox_Rate.Text.Trim(),
                        textBox_Amount.Text.Trim(),
                        dateTimePicker_BeginDate.Value.ToString("yyyy-MM-dd"),
                        dateTimePicker_EndDate.Value.ToString("yyyy-MM-dd") );
                }

                if (FrmMode == FormMode.modify)
                {
                    sql = string.Format("update SchemeRate set RateName = '{0}', ItemTypeCode = {1}, ItemTypeName = '{2}', CommissionType = {3}, Rate = {4}, Amount = {5}, BeginDate = '{6}', EndDate = '{7}' where ID = {8}",
                        textBox_RateName.Text.Trim(),
                        comboBox_ItemType.SelectedValue.ToString(),
                        comboBox_ItemType.Text,
                        (double.Parse(textBox_Rate.Text.Trim()) > 0) ? 0 : 1,
                        textBox_Rate.Text.Trim(),
                        textBox_Amount.Text.Trim(),
                        dateTimePicker_BeginDate.Value.ToString("yyyy-MM-dd"),
                        dateTimePicker_EndDate.Value.ToString("yyyy-MM-dd"), ID);
                }
                try
                {
                    if (SqlHelper.ExecuteNonQuery(sql) > 0)
                    {
                        (this.Owner as FrmRate).LoadRate();
                        SetInitValue();
                        Prompt.Information("操作成功!");
                    }

                    if (FrmMode == FormMode.modify)
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    Prompt.Error("操作失败，错误信息：\r\n" + ex.Message);
                }
            }

        }

        private bool InputValidate()
        {
            double rate = 0;
            if (double.TryParse(textBox_Rate.Text.Trim(), out rate) == false)
            {
                Prompt.Warning("佣金比例必须为有效数字！");
                textBox_Rate.Focus();
                textBox_Rate.SelectAll();
                return false;
            }

            if (rate < 0 || rate > 100)
            {
                Prompt.Warning("佣金比例的有效区间为：0 < 比例 <= 100 ");
                textBox_Rate.Focus();
                textBox_Rate.SelectAll();
                return false;
            }

            double amount = 0;
            if (double.TryParse(textBox_Amount.Text.Trim(), out amount) == false)
            {
                Prompt.Warning("佣金金额必须为有效数字！");
                textBox_Amount.Focus();
                textBox_Amount.SelectAll();
                return false;
            }

            if (amount < 0)
            {
                Prompt.Warning("佣金金额不能为负值！");
                textBox_Amount.Focus();
                textBox_Amount.SelectAll();
                return false;
            }

            if (rate == 0 && amount == 0)
            {
                Prompt.Warning("比例和金额不能同时为零！");
                textBox_Rate.Focus();
                textBox_Rate.SelectAll();
                return false;
            }

            if (rate != 0 && amount != 0)
            {
                Prompt.Warning("比例与金额只能设置一个！");
                textBox_Rate.Focus();
                textBox_Rate.SelectAll();
                return false;
            }


            DateTime beginDate = Convert.ToDateTime(dateTimePicker_BeginDate.Value.Date.ToString("yyyy-MM-dd"));
            DateTime endDate = Convert.ToDateTime(dateTimePicker_EndDate.Value.Date.ToString("yyyy-MM-dd"));

            if (DateTime.Compare(beginDate, endDate) > 0)
            {
                Prompt.Warning("开始时间不能晚于结束时间");
                dateTimePicker_BeginDate.Focus();
                return false;
            }

            //同一类型，同一时间，仅一个有效
            string sql = string.Empty;
            if (FrmMode == FormMode.modify)
            {
                //修改模式不与原记录对比有效期
                sql = string.Format("select BeginDate, EndDate from SchemeRate where ItemTypeCode = {0} and ID != {1}", comboBox_ItemType.SelectedValue.ToString(), ID);
            }
            else
            {
                sql = string.Format("select BeginDate, EndDate from SchemeRate where ItemTypeCode = {0}", comboBox_ItemType.SelectedValue.ToString());
            }
            
            SqlDataReader sdr = SqlHelper.ExecuteReader(sql);
            while(sdr.Read())
            {
                //startdate1 <=enddate2 and enddate1>=startdate2
                DateTime dbBeginDate = Convert.ToDateTime(string.Format("{0:yyyy-MM-dd}", sdr["BeginDate"]));
                DateTime dbEndDate = Convert.ToDateTime(string.Format("{0:yyyy-MM-dd}", sdr["EndDate"]));

                if ((DateTime.Compare(beginDate, dbEndDate) <= 0 ) && (DateTime.Compare(endDate,dbBeginDate) >= 0))
                {
                    Prompt.Warning("相同房源类型的有效时间段不能交叉叠加");
                    dateTimePicker_BeginDate.Focus();
                    return false;
                }
            }
            sdr.Close();


            return true;
        }

        private void SetInitValue()
        {
            textBox_RateName.Text = "";
            textBox_Rate.Text = "0";
            textBox_Amount.Text = "0";
            comboBox_ItemType.SelectedIndex = 0;

            dateTimePicker_BeginDate.Value = DateTime.Now;
            dateTimePicker_EndDate.Value = DateTime.Parse(DateTime.Now.Year.ToString() + "-12-31");

            textBox_RateName.Focus();
        }

        private void textBox_Rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.OnlyNumeric(sender, e);
        }

        private void textBox_Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.OnlyNumeric(sender, e);
        }

    }
}
