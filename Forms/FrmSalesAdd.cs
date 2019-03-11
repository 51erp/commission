using Commission.MenuForms;
using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Commission.Business;

namespace Commission.Forms
{
    public partial class FrmSalesAdd : BaseFrmAdd
    {
        public bool IsModify = false;
        public string SalesID = string.Empty;
        public FrmSalesAdd()
        {
            InitializeComponent();
            InitDefComponent();
        }

        private void InitDefComponent()
        {
            comboBox_Position.SelectedIndex = 0;
        }

        protected override void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            if (inputValidate())
            {
                if (IsModify)
                    updateData();
                else
                    addData();
                
            }
        }

        private void updateData()
        {
            string sql = "update Sales set SalesName = '" + textBox_Name.Text.Trim() + "'"
                + ", Phone = '" + textBox_Phone.Text.Trim() + "'"
                + ", InDate = '" + dateTimePicker_In.Value.ToShortDateString() + "'"
                + ", Position = '" + comboBox_Position.Text + "'"
                + ", ProjectID = " + Login.User.ProjectID
                + ", ProjectName = '" + Login.User.ProjectName + "'";

            sql += " where SalesID = " + SalesID;

            SqlHelper.ExecuteNonQuery(sql);
            (this.Owner as FrmSales).getSalesInfo(SalesID);
            Prompt.Information("操作成功");
            Close();
        }

        private void addData()
        {
            string fields = "SalesName, InDate, Position";
            string values = "'" + textBox_Name.Text.Trim() + "','" + dateTimePicker_In.Value.ToShortDateString() + "','" + comboBox_Position.Text + "'";

            if (!textBox_Phone.Text.Trim().Equals(""))
            {
                fields += ",Phone";
                values += ",'" + textBox_Phone.Text.Trim() + "'";
            }

            if (!textBox_Memo.Text.Trim().Equals(""))
            {
                fields += ",Memo";
                values += ",'" + textBox_Memo.Text.Trim() + "'";
            }

            fields += ",ProjectID, ProjectName";
            values += "," + Login.User.ProjectID + ",'" + Login.User.ProjectName + "'";


            string sql = "insert into Sales (" + fields + ") output inserted.salesid values (" + values + ")";

            string salesid = SqlHelper.ExecuteScalar(sql).ToString();

            if (int.Parse(salesid) > 0)
            {
                inputInit();
                (this.Owner as FrmSales).getSalesInfo(salesid);
                Prompt.Information("操作成功");
            }
        }

        private void inputInit()
        {
            textBox_Name.Text = "";
            textBox_Phone.Text = "";
            textBox_Position.Text = "";
            textBox_Memo.Text = "";
            textBox_Name.Focus();
        }

        private bool inputValidate()
        {
            bool result = false;

            if (textBox_Name.Text.Trim().Equals(""))
            {
                Prompt.Warning("业务员名称不能为空！");
                textBox_Name.Focus();
            }
            else
            {
                result = true;
            }


            return result;
        }

        private void FrmSalesAdd_Load(object sender, EventArgs e)
        {
            if (IsModify)
            {
                this.Text = "修改置业顾问信息";
                loadData();
            }
                
        }

        private void loadData()
        {
            string sql = "select SalesName,Phone,InDate,OutDate,Position,ProjectID,Memo from Sales where SalesID = " + SalesID;
            SqlDataReader sdr = SqlHelper.ExecuteReader(sql);

            sdr.Read();

            textBox_Name.Text = sdr["SalesName"].ToString();
            textBox_Phone.Text = sdr["Phone"].ToString();
            dateTimePicker_In.Text = sdr["InDate"].ToString();
            comboBox_Position.Text = sdr["Position"].ToString();
        }
    }
}
