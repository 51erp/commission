using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Commission.Forms
{
    public partial class FrmContractDateMng : Form
    {
        public FrmContractDateMng()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            FrmContractDateAdd add = new FrmContractDateAdd();

            if (add.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string strValues = Login.User.ProjectID + "," + add.ItemTypeCode + ",'" + add.ItemTypeName + "'," + add.IntervalDays;
                string sql = string.Format("insert into ParaIntervalDays (ProjectID, ItemTypeCode, ItemTypeName,IntervalDays ) values ({0})", strValues);

                if (int.Parse(SqlHelper.ExecuteNonQuery(sql).ToString()) > 0)
                {
                    dataGridView_Days.DataSource = SqlHelper.ExecuteDataTable(string.Format("select ID, ItemTypeName, IntervalDays from ParaIntervalDays where ProjectID = {0} order by ID", Login.User.ProjectID));
                    Prompt.Information("操作成功！数据已添加。");
                }
            }
        }

        private void FrmContractDateMng_Load(object sender, EventArgs e)
        {
            dataGridView_Days.DataSource = SqlHelper.ExecuteDataTable(string.Format("select ID, ItemTypeName, IntervalDays from ParaIntervalDays where ProjectID = {0} order by ID", Login.User.ProjectID));
        }

        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {
            if (dataGridView_Days.CurrentRow == null)
            {
                return;
            }

            if (MessageBox.Show("确定要删除选择的数据？", Common.MsgCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string ID = dataGridView_Days.CurrentRow.Cells["ColID"].Value.ToString();

                string sql = string.Format("delete ParaIntervalDays where ID = {0}", ID);

                if (int.Parse(SqlHelper.ExecuteNonQuery(sql).ToString()) > 0)
                {
                    dataGridView_Days.DataSource = SqlHelper.ExecuteDataTable(string.Format("select ID, ItemTypeName, IntervalDays from ParaIntervalDays where ProjectID = {0} order by ID", Login.User.ProjectID));
                    Prompt.Information("操作成功！数据已删除");
                }
            }

        }
    }
}
