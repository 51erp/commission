using Commission.Business;
using Commission.Forms;
using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Commission.MenuForms
{
    public partial class FrmUser : Form
    {
        public FrmUser()
        {
            InitializeComponent();
            comboBox_Role.SelectedIndex = 0;
            initRole();
        }


        private void initRole()
        {
            string sql = "select '0' as RoleID, '全部' as RoleName union all " 
                +"SELECT RoleID, RoleName FROM  [Role] where State = 1 order by RoleID";
            comboBox_Role.DataSource = SqlHelper.ExecuteDataTable(sql);
            comboBox_Role.ValueMember = "RoleID";
            comboBox_Role.DisplayMember = "RoleName";
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string condition = "";

            if (!textBox_Name.Text.Trim().Equals(""))
                condition += " and UserName like '%" + textBox_Name.Text.Trim() + "%'";

            if (comboBox_Role.SelectedIndex != 0)
            {
                condition += " and RoleID = " + comboBox_Role.SelectedValue.ToString();
            }

            Search(condition);

            if (dataGridView_User.Rows.Count == 0)
            {
                Prompt.Information("未查询到符合条件的记录！");
            }
        }

        private void Search(string condition)
        {
            string sql = "select ID, UserName, RoleName, '' as ProjectName, Memo from SysUser where State = 1 and UserType = 1 " + condition;

            DataTable dt = SqlHelper.ExecuteDataTable(sql);

            foreach (DataRow dr in dt.Rows)
            {
                string projectName = "";
                sql = "select ProjectName from UserProject where UserID = " + dr["ID"].ToString();
                SqlDataReader sdr = SqlHelper.ExecuteReader(sql);
                while (sdr.Read())
                {
                    projectName += (String.IsNullOrEmpty(projectName) ? "" : ",") + sdr["ProjectName"].ToString();
                }

                dr["ProjectName"] = projectName;
            }

            dataGridView_User.DataSource = dt;
        }


        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {
            if (dataGridView_User.CurrentRow == null)
            {
                Prompt.Warning("未选择记录！");
                return;
            }

            if (MessageBox.Show("确定要删除选择的记录？","房地产佣金结算系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string sql = "update SysUser Set State = 0 where ID = " + dataGridView_User.CurrentRow.Cells["ColID"].Value.ToString();
                object objResult = SqlHelper.ExecuteNonQuery(sql);
                if (objResult != null)
                {
                    dataGridView_User.Rows.RemoveAt(dataGridView_User.CurrentRow.Index);
                    Prompt.Information("操作成功，记录已删除！");
                }
            }
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            FrmUserAdd add = new FrmUserAdd();
            if (add.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Search("");
                Prompt.Information("操作成功！");
            }
        }

        private void toolStripButton_Edit_Click(object sender, EventArgs e)
        {
            if (dataGridView_User.CurrentRow == null)
            {
                Prompt.Warning("未选择相应的记录！");
                return;
            }

            FrmUserAdd add = new FrmUserAdd();
            add.IsModifyMode = true;
            add.Update_UserID = dataGridView_User.CurrentRow.Cells["ColID"].Value.ToString();
            //MessageBox.Show("begin");
            if (add.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            { 
                Search(" and ID = " + dataGridView_User.CurrentRow.Cells["ColID"].Value.ToString());
                Prompt.Information("操作成功！");
            }
        }

        private void toolStripButton_Reset_Click(object sender, EventArgs e)
        {
            if (dataGridView_User.CurrentRow == null)
            {
                Prompt.Warning("未选择相应的记录！");
                return;
            }

            if (MessageBox.Show("是否要重置用户密码？","房地产佣金结算系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string sql = "update SysUser Set UserPwd = '123456' where ID = " + dataGridView_User.CurrentRow.Cells["ColID"].Value.ToString();
                object objResult = SqlHelper.ExecuteNonQuery(sql);
                if (objResult != null)
                {
                    dataGridView_User.Rows.RemoveAt(dataGridView_User.CurrentRow.Index);
                    Prompt.Information("操作成功，密码已重置！");
                }

            }

        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            Search("");
        }
    }
}
