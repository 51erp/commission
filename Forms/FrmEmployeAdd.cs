using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Commission.Forms
{
    public partial class FrmEmployeAdd : Form
    {
        public string DeptId = string.Empty;
        public string DeptName = string.Empty;
        public FrmEmployeAdd()
        {
            InitializeComponent();
        }
        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmEmployeAdd_Load(object sender, EventArgs e)
        {
            textBox_DeptName.Tag = DeptId;
            textBox_DeptName.Text = DeptName;
            inputInit();
        }


        private void inputInit()
        {
            comboBox_Position.SelectedIndex = 0;
            comboBox_JobType.SelectedIndex = 0;

            textBox_Name.Text = "";
            textBox_Phone.Text = "";
            textBox_Memo.Text = "";
            textBox_Name.Focus();
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            if (InputValidate())
            {
                addData();
            }
        }


        private bool InputValidate()
        {
            bool result = true;

            if (textBox_Name.Text.Trim().Equals(""))
            {
                Prompt.Warning("姓名不能为空！");
                textBox_Name.Focus();

                return false;
            }

            return result;
        }

        private void addData()
        {
            string fields = "SalesName, InDate, Position";
            string values = "'" + textBox_Name.Text.Trim() + "','" + dateTimePicker_JobBeginDate.Value.ToString("yyyy-MM-dd") + "','" + comboBox_Position.Text + "'";

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

            string sqlSales = "insert into Sales (" + fields + ") output inserted.salesid  values (" + values + ")";
            


            using (SqlConnection connection = SqlHelper.OpenConnection())
            {
                SqlTransaction sqlTran = connection.BeginTransaction();
                SqlCommand cmd = connection.CreateCommand();
                cmd.Transaction = sqlTran;

                try
                {
                    cmd.CommandText = sqlSales;
                    string salesid = cmd.ExecuteScalar().ToString();

                    cmd.CommandText = string.Format("insert into JobTrack (SalesID, DeptID, DeptName, JobType, BeginDate) values ({0},{1},'{2}','{3}','{4}')",
                        salesid, DeptId, DeptName, comboBox_JobType.Text, dateTimePicker_JobBeginDate.Value.ToString("yyyy-MM-dd"));
                    cmd.ExecuteNonQuery();

                    sqlTran.Commit();

                    inputInit();
                    Prompt.Information("操作成功");

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    Prompt.Error("操作失败， 错误：" + ex.Message);
                }

            }
        }

    }
}
