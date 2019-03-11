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
    public partial class FrmProjectAdd : Form
    {
        public bool IsModifyMode = false;
        public string ProjectID;
        public FrmProjectAdd()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            if (!inputValidate())
                return;

            if (IsModifyMode)
                updateData();
            else
                addData();

            Close();
        }

        private void addData()
        {
            string fields = "ProjectName,FirstParty,Memo,CreateDate";
            string values = "'" + textBox_Name.Text.Trim() + "','"
                + textBox_FirstParty.Text.Trim() + "','"
                + textBox_Memo.Text + "',getdate()";

            string sql = "insert into Project (" + fields + ") values (" + values + ")";

            if (SqlHelper.ExecuteNonQuery(sql) > 0)
            {
                inputInit();
                Prompt.Information("操作成功");

                (this.Owner as FrmProject).getProjectInfo();
            }
        }

        private void updateData()
        {
            string sql = "update Project set "
                + " ProjectName = " + "'" + textBox_Name.Text.Trim() + "'"
                + ",FirstParty = '" + textBox_FirstParty.Text.Trim() + "'"
                + ",Memo = '" + textBox_Memo.Text + "'"
                + " where ProjectID = " + ProjectID;

            if (SqlHelper.ExecuteNonQuery(sql) > 0)
            {
                Prompt.Information("操作成功");
                (this.Owner as FrmProject).getProjectInfo();
                Close();
            }

        }

        private void loadData()
        {
            string sql = "select ProjectName,FirstParty,Memo from Project where ProjectID  = " + ProjectID;

            SqlDataReader sdr = SqlHelper.ExecuteReader(sql);
            sdr.Read();

            textBox_Name.Text = sdr["ProjectName"].ToString();
            textBox_FirstParty.Text = sdr["FirstParty"].ToString();
            textBox_Memo.Text = sdr["Memo"].ToString();
        }



        private void inputInit()
        {
            textBox_FirstParty.Text = "";
            textBox_Memo.Text = "";
            textBox_Name.Text = "";
            textBox_Name.Focus();
        }

        private bool inputValidate()
        {
            bool result = false;

            if (textBox_Name.Text.Trim().Equals(""))
            {
                textBox_Name.Focus();
                Prompt.Warning("楼盘名称不能为空！");
            }
            else if (textBox_FirstParty.Text.Trim().Equals(""))
            {
                textBox_FirstParty.Focus();
                Prompt.Warning("甲方名称不能为空！");
            }
            else
            {
                result = true;
            }

            return result;
        }

        private void FrmProjectAdd_Load(object sender, EventArgs e)
        {
            if (IsModifyMode)
                loadData();
        }

    }
}
