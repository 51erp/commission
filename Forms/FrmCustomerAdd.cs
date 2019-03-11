using Commission.Business;
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

namespace Commission.Forms
{
    public partial class FrmCustomerAdd : BaseFrmAdd
    {
        public bool IsModify = false;
        public string CustomerID = string.Empty;
        public FrmCustomerAdd()
        {
            InitializeComponent();
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
            string sql = "update Customer set CustomerName = '" + textBox_Name.Text.Trim() + "'"
                + ", CustomerPhone = '" + textBox_Phone.Text.Trim() + "'"
                + ", PID = '" + textBox_PID.Text.Trim() + "'"
                + ", Addr = '" + textBox_Addr.Text.Trim() + "'"
                + ",CusTypeName = '" +textBox_CusType.Text.Trim() + "'"
                + "  where CustomerID = " + CustomerID;

            SqlHelper.ExecuteNonQuery(sql);
            (this.Owner as FrmCustomer).getCustomerInfo(CustomerID);
            Prompt.Information("操作成功");
            Close();
        }


        private void addData()
        {
            string fields = "CustomerName, ProjectID";
            string values = "'" + textBox_Name.Text.Trim() + "'," + Login.User.ProjectID;

            if (!textBox_Phone.Text.Trim().Equals(""))
            {
                fields += ",CustomerPhone";
                values += ",'" + textBox_Phone.Text.Trim() + "'";
            }

            if (!textBox_PID.Text.Trim().Equals(""))
            {
                fields += ",PID";
                values += ",'" + textBox_PID.Text.Trim() + "'";
            }

            if (!textBox_Addr.Text.Trim().Equals(""))
            {
                fields += ",Addr";
                values += ",'" + textBox_Addr.Text.Trim() + "'";
            }

            if (!textBox_CusType.Text.Trim().Equals(""))
            {
                fields += ",CusTypeName";
                values += ",'" + textBox_CusType.Text.Trim() + "'";
            }

            string sql = "insert into Customer (" + fields + ") output inserted.CustomerID values (" + values + ")";

            string id = SqlHelper.ExecuteScalar(sql).ToString();

            if (int.Parse(id) > 0)
            {
                inputInit();
                (this.Owner as FrmCustomer).getCustomerInfo(id);
                Prompt.Information("操作成功");
            }
        }


        private void inputInit()
        {
            textBox_Phone.Text = "";
            textBox_PID.Text = "";
            textBox_Addr.Text = "";
            textBox_Name.Text = "";
            textBox_Name.Focus();
        }

        private bool inputValidate()
        {
            if (textBox_Name.Text.Trim().Equals(""))
            {
                textBox_Name.Focus();
                Prompt.Warning("客户名称不能为空！");
                return false;
            }

            return true;
        }

        private void FrmCustomerAdd_Load(object sender, EventArgs e)
        {
            if(IsModify)
            {
                loadData();
            }
        }

        private void loadData()
        {
            string sql = "select CustomerName,CustomerPhone,PID,Addr,CusTypeName from Customer where CustomerID = " + CustomerID;
            SqlDataReader sdr = SqlHelper.ExecuteReader(sql);

            sdr.Read();

            textBox_Name.Text = sdr["CustomerName"].ToString();
            textBox_Phone.Text = sdr["CustomerPhone"].ToString();
            textBox_PID.Text = sdr["PID"].ToString();
            textBox_Addr.Text = sdr["Addr"].ToString();
            textBox_CusType.Text = sdr["CusTypeName"].ToString();

        }
    }
}
