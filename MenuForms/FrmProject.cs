using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Commission.Forms;
using Commission.Utility;
using Commission.Business;

namespace Commission.MenuForms
{
    public partial class FrmProject : Form
    {
        public FrmProject()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            FrmProjectAdd project = new FrmProjectAdd();
            project.Owner = this;
            project.ShowDialog();
        }

        private void FrmProject_Load(object sender, EventArgs e)
        {
            getProjectInfo();
        }

        public  void getProjectInfo()
        {
            string sql = "select ProjectID, ProjectName, FirstParty, Memo from Project order by CreateDate desc";

            dataGridView_Project.DataSource = SqlHelper.ExecuteDataTable(sql);
        }

        public void getUpSetInfo(string ProjectID)
        {
            string sql = "select b.ProjectName, c.Name, BaseValue, Rate, BeginDate, EndDate from UpSet a "
                + " inner join Project b on a.ProjectID = b.ProjectID "
                + " inner join DictUpBase c on a.UpCode = c.Code " 
                + " where a.ProjectID = " + ProjectID ;
        }

        private void toolStripButton_Refresh_Click(object sender, EventArgs e)
        {
            getProjectInfo();
        }

        private void dataGridView_Project_SelectionChanged(object sender, EventArgs e)
        {
            string code = getProjectID();
            getUpSetInfo(code);
        }

        //private void toolStripButton_UpAdd_Click(object sender, EventArgs e)
        //{

        //    if (dataGridView_Project.Rows.Count < 1)
        //    {
        //        Prompt.Information("未选择要设置信息的楼盘");
        //        return;
        //    }
        //    string code = dataGridView_Project.Rows[dataGridView_Project.CurrentCell.RowIndex].Cells["ColProjectID"].Value.ToString();
        //    string name = dataGridView_Project.Rows[dataGridView_Project.CurrentCell.RowIndex].Cells["ColProjectName"].Value.ToString();

        //    FrmUpAdd up = new FrmUpAdd();
        //    up.Owner = this;
        //    up.textBox_Code.Text = code;
        //    up.textBox_Name.Text = name;
        //    up.ShowDialog();
        //    getUpSetInfo(code);
        //}

        private string getProjectID()
        {
            string code = string.Empty;

            if (dataGridView_Project.Rows.Count > 0)
                code = dataGridView_Project.Rows[dataGridView_Project.CurrentCell.RowIndex].Cells["ColProjectID"].Value.ToString();

            return code;
        }

        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要删除 [ " + dataGridView_Project.CurrentRow.Cells["ColProjectName"].Value.ToString() + " ] 的信息？", "房地产销售佣金结算管理系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (dataGridView_Project.Rows.Count > 0) 
                {
                    string ProjectID = dataGridView_Project.CurrentRow.Cells["ColProjectID"].Value.ToString();

                    if (MasterData.isReferred(MasterDataType.project, ProjectID))
                        return;

                    string sql = "delete Project where ProjectID = " + ProjectID;
                    SqlHelper.ExecuteNonQuery(sql);

                    getProjectInfo();
                }
            }
        }

        private void toolStripButton_Edit_Click(object sender, EventArgs e)
        {
            if (dataGridView_Project.CurrentRow == null)
            {
                Prompt.Information("未选择要修改的记录！");
                return;
            }

            FrmProjectAdd project = new FrmProjectAdd();
            project.IsModifyMode = true;
            project.ProjectID = dataGridView_Project.CurrentRow.Cells["ColProjectID"].Value.ToString();
            project.Owner = this;
            project.ShowDialog();

        }


    }
}
