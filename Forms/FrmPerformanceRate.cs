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
    public partial class FrmPerformanceRate : Form
    {
        private string allot;
        private string hold;
        private string takeover;


        public FrmPerformanceRate()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmPerformanceRate_Load(object sender, EventArgs e)
        {
            GetRate();
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            if (textBox_Allot.Text.Trim() == "")
            {
                Prompt.Error("分配不允许为空!");
                textBox_Allot.Focus();
                return;
            }

            if (textBox_hold.Text.Trim() == "")
            {
                Prompt.Error("调岗（认购）不允许为空!");
                textBox_hold.Focus();
                return;
            }

            if (textBox_takeover.Text.Trim() == "")
            {
                Prompt.Error("调岗（收款）不允许为空!");
                textBox_takeover.Focus();
                return;
            }

            using (SqlConnection connection = SqlHelper.OpenConnection())
            {
                SqlTransaction sqlTran = connection.BeginTransaction();
                SqlCommand cmd = connection.CreateCommand();
                cmd.Transaction = sqlTran;

                try
                {
                    cmd.CommandText = "delete PerformanceRate";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = string.Format("insert into PerformanceRate (Code, Rate) values (1,{0})", textBox_Allot.Text.Trim());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = string.Format("insert into PerformanceRate (Code, Rate) values (2,{0})", textBox_hold.Text.Trim().Trim());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = string.Format("insert into PerformanceRate (Code, Rate) values (3,{0})", textBox_takeover.Text.Trim());
                    cmd.ExecuteNonQuery();

                    sqlTran.Commit();

                    Prompt.Information("操作成功，数据已保存！");

                    Close();
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    Prompt.Error("操作失败， 错误：" + ex.Message);
                }
            }
        }

        private void GetRate()
        {
            string sql = string.Format("select Code, Name, Rate from PerformanceRate");

            DataTable dtRate = SqlHelper.ExecuteDataTable(sql);

            foreach (DataRow dr in dtRate.Rows)
            {
                switch (int.Parse(dr["Code"].ToString()))
                {
                    case 1:
                        allot = dr["Rate"].ToString();
                        textBox_Allot.Text = dr["Rate"].ToString();
                        break;
                    case 2:
                        hold = dr["Rate"].ToString();
                        textBox_hold.Text = dr["Rate"].ToString();
                        break;
                    case 3:
                        takeover = dr["Rate"].ToString();
                        textBox_takeover.Text = dr["Rate"].ToString();
                        break;
                }
            }
        }

        private void textBox_KeyPress_OnlyNumeric(object sender, KeyPressEventArgs e)
        {
            Common.OnlyNumeric(sender, e);
        }


    }
}
