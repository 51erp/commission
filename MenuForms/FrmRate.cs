using Commission.Forms;
using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Commission.MenuForms
{
    public partial class FrmRate : Form
    {
        public FrmRate()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            FrmRateAdd add = new FrmRateAdd();
            add.Owner = this;
            add.ShowDialog();
        }

        private void FrmRate_Load(object sender, EventArgs e)
        {
            LoadRate();
        }

        public void LoadRate(int rowIdx = 0)
        {
            string sql = string.Format("select ID,RateName,ItemTypeCode,ItemTypeName,Rate,Amount,BeginDate,EndDate from SchemeRate where ProjectID ={0}  order by ItemTypeCode", Login.User.ProjectID);
            dataGridView_Rate.DataSource = SqlHelper.ExecuteDataTable(sql);

            //if (dataGridView_Rate.Rows.Count > 0)
            //    dataGridView_Rate.Rows[rowIdx].Selected = true;

        }

        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {
            if (dataGridView_Rate.CurrentRow != null)
            {
                string id = dataGridView_Rate.CurrentRow.Cells["ColID"].Value.ToString();

                string sql = string.Format("Delete SchemeRate where ID = {0}", id);
                try
                {
                    if (SqlHelper.ExecuteNonQuery(sql) > 0)
                    {
                        dataGridView_Rate.Rows.RemoveAt(dataGridView_Rate.CurrentRow.Index);
                        Prompt.Information("操作成功，记录已删除！");
                    }
                }
                catch (Exception)
                {
                    Prompt.Error("操作失败，请重新操作或联系系统管理员");
                }
            }
            else
            {
                Prompt.Warning("没有选择相应的记录");
            }
        }

        private void toolStripButton_Modify_Click(object sender, EventArgs e)
        {
            if (dataGridView_Rate.CurrentRow != null)
            {
                string id = dataGridView_Rate.CurrentRow.Cells["ColID"].Value.ToString();

                FrmRateAdd modify = new FrmRateAdd();
                modify.Owner = this;
                modify.FrmMode = FormMode.modify;
                modify.ID = id;
                modify.ShowDialog();
            }

        }

        private void toolStripButton_IsDefault_Click(object sender, EventArgs e)
        {
            if (dataGridView_Rate.CurrentRow != null)
            {
                int rowIdx = dataGridView_Rate.CurrentRow.Index;
                string id = dataGridView_Rate.CurrentRow.Cells["ColID"].Value.ToString();

                string sql = string.Format("update SchemeRate set IsDefault = 0 where IsDefault = 1 and ProjectID = {0}", Login.User.ProjectID);
                try
                {
                    SqlHelper.ExecuteNonQuery(sql);

                    sql = string.Format("update SchemeRate set IsDefault = 1 where ID = {0}", id);

                    SqlHelper.ExecuteNonQuery(sql);

                    LoadRate(rowIdx);
                }
                catch (Exception ex)
                {
                    Prompt.Warning("操作失败!\r\n错误信息：" + ex.Message);
                }
            }
        }
    }
}
