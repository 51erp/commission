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
    public partial class FrmItemTypeMng : Form
    {
        public FrmItemTypeMng()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmItemTypeMng_Load(object sender, EventArgs e)
        {
            dataGridView_ItemType.DataSource = SqlHelper.ExecuteDataTable(string.Format("select Code,Name,Memo from DictItemType where ProjectID = {0}", Login.User.ProjectID));
        }

        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {
            if (dataGridView_ItemType.CurrentRow == null)
                return;

            string code = dataGridView_ItemType.CurrentRow.Cells["ColCode"].Value.ToString();

            string sql = string.Format("select COUNT(ItemID) from SaleItem where ItemTypeCode = {0}", code);

            if (int.Parse(SqlHelper.ExecuteScalar(sql).ToString()) > 0)
            {
                Prompt.Warning("数据已应用，无法删除");
                return;
            }

            sql = string.Format("delete DictItemType where Code = {0}", code);

            if (SqlHelper.ExecuteNonQuery(sql) > 0)
            {
                dataGridView_ItemType.Rows.RemoveAt(dataGridView_ItemType.CurrentRow.Index);
                Prompt.Information("操作成功！数据已删除。");
            }

        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            FrmItemTypeAdd add = new FrmItemTypeAdd();
            if (add.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string sql = string.Format("insert into DictItemType (Name, Memo, ProjectID) values ('{0}','{1}', {2})", add.ItemTypeName, add.Memo, Login.User.ProjectID);
                if (SqlHelper.ExecuteNonQuery(sql) > 0)
                {
                    dataGridView_ItemType.DataSource = SqlHelper.ExecuteDataTable(string.Format("select Code,Name,Memo from DictItemType where ProjectID = {0}", Login.User.ProjectID));
                    Prompt.Information("操作成功！数据已添加。");
                }
            }
        }
    }
}
