using Commission.Forms;
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

namespace Commission.MenuForms
{
    public partial class FrmUpgrade : Form
    {
        public FormMode FrmMode;
        public Dictionary<int, string> UpInfo = new Dictionary<int, string>();

        public FrmUpgrade()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            FrmUpSet add = new FrmUpSet();
            if (add.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                LoadUpgrade();
        }

        private void FrmUpgrade_Load(object sender, EventArgs e)
        {
            if (FrmMode == FormMode.view)
            {
                toolStripButton_Add.Visible = false;
                toolStripButton_Del.Visible = false;
                toolStripButton_Modify.Visible = false;
            }
            else
            {
                toolStripButton_OK.Visible = false;
                toolStripButton_No.Visible = false;
            }

            LoadUpgrade();
        }

        private void LoadUpgrade()
        {
            string sql = string.Format("select UPID,UpName,UpBaseName,IsSubscribe, BaseRate, BeginDate,EndDate  from SchemeUpgrade where ProjectID = {0}", Login.User.ProjectID);
            dataGridView_Rate.DataSource = SqlHelper.ExecuteDataTable(sql);

        }

        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {
            if (dataGridView_Rate.CurrentRow == null)
            {
                Prompt.Warning("未选择记录");
                return;
            }

            string sql = string.Format("select count(itemID) from SaleItem where UpID = {0}", dataGridView_Rate.CurrentRow.Cells["ColUpID"].FormattedValue.ToString());

            if (int.Parse(SqlHelper.ExecuteScalar(sql).ToString()) > 0)
            {
                Prompt.Warning("记录已被引用，无法删除！");
                return;
            }


            if (MessageBox.Show("是否要删除所选记录","房地产佣金结算系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                using (SqlConnection connection = SqlHelper.OpenConnection())  //创建连接对象 
                {
                    SqlTransaction sqlTran = connection.BeginTransaction();    //开始事务 
                    SqlCommand cmd = connection.CreateCommand();               //创建SqlCommand对象 
                    cmd.Transaction = sqlTran;


                    sql = string.Format("Delete SchemeUpgrade where UPID = {0}", dataGridView_Rate.CurrentRow.Cells["ColUpID"].FormattedValue.ToString()); //删除主表
                    try
                    {
                        if (SqlHelper.ExecuteNonQuery(sql) > 0)
                        {
                            sql = string.Format("Delete UpValue where UPID = {0}", dataGridView_Rate.CurrentRow.Cells["ColUpID"].FormattedValue.ToString());  //删除子表
                            if (SqlHelper.ExecuteNonQuery(sql) > 0)
                            {
                                dataGridView_Rate.Rows.RemoveAt(dataGridView_Rate.CurrentRow.Index);

                                sqlTran.Commit();  //事务提交
                                connection.Close();

                                Prompt.Information("操作成功");
                            }
                        }
                        else
                        {
                            sqlTran.Rollback();
                            Prompt.Error("操作失败，请重新操作或联系系统管理员");
                        }
                    }
                    catch (Exception ex)
                    {
                        sqlTran.Rollback();
                        Prompt.Error("操作失败，请重新操作或联系系统管理员。\r\n错误信息：\r\n" + ex.Message.ToString());
                        throw;
                    }
                }
            }
        }

        private void toolStripButton_Modify_Click(object sender, EventArgs e)
        {
            if (dataGridView_Rate.CurrentRow == null)
            {
                Prompt.Warning("未选择记录");
                return;
            }
            FrmUpSet modify = new FrmUpSet();

            modify.FrmMode = FormMode.modify;
            modify.UPID = dataGridView_Rate.CurrentRow.Cells["ColUpID"].FormattedValue.ToString();

            if (modify.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                LoadUpgrade();
        }

        private void toolStripButton_Detail_Click(object sender, EventArgs e)
        {
            if (dataGridView_Rate.CurrentRow == null)
            {
                Prompt.Warning("未选择记录");
                return;
            }
            FrmUpSet modify = new FrmUpSet();

            modify.FrmMode = FormMode.view;
            modify.UPID = dataGridView_Rate.CurrentRow.Cells["ColUpID"].FormattedValue.ToString();

            modify.ShowDialog();
        }

        private void toolStripButton_OK_Click(object sender, EventArgs e)
        {
            if (dataGridView_Rate.CurrentRow == null)
            {
                Prompt.Warning("未选择记录");
                return;
            }

            UpInfo.Add(1, dataGridView_Rate.CurrentRow.Cells["ColUpID"].Value.ToString());
            UpInfo.Add(2, dataGridView_Rate.CurrentRow.Cells["ColUpName"].Value.ToString());
            UpInfo.Add(3, dataGridView_Rate.CurrentRow.Cells["ColBaseRate"].Value.ToString());

            DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void toolStripButton_No_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.No;
        }
    }
}
