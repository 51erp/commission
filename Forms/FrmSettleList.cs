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
    public partial class FrmSettleList : Form
    {
        public string SettleID = string.Empty;
        public string SettleTableName = string.Empty;
        public FrmSettleList()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_OK_Click(object sender, EventArgs e)
        {
            Selected();
        }

        private void Selected()
        {
            if ((dataGridView_SettleMain.Rows.Count == 0) || (dataGridView_SettleMain.CurrentRow == null))
            {
                Prompt.Warning("没有选择记录！");
                return;
            }

            SettleID = dataGridView_SettleMain.CurrentRow.Cells["ColSettleID"].Value.ToString();
            SettleTableName = dataGridView_SettleMain.CurrentRow.Cells["ColTableName"].Value.ToString();

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void FrmSettleList_Load(object sender, EventArgs e)
        {
            string sql = string.Format("select  ProjectID, SettleID, TableName, SettlePeriod from SettleMain " 
                + "where ProjectID = {0}  and  Performance = 1 order by SettleID ", Login.User.ProjectID);

            dataGridView_SettleMain.DataSource = SqlHelper.ExecuteDataTable(sql);
        }

        private void dataGridView_SettleMain_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Selected();
        }
    }
}
