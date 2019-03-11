using Commission.Business;
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
    public partial class FrmUpSettleDetail : Form
    {
        public string UpSettleID = string.Empty;

        public FrmUpSettleDetail()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Check_Click(object sender, EventArgs e)
        {
            DataTable dt_Settle = (DataTable)dataGridView_Settlement.DataSource;
            if (dt_Settle == null)
            {
                return;
            }

            if (dt_Settle.Rows.Count == 0)
            {
                Prompt.Warning("无结算记录，不能审核！");
                return;
            }

            if (!label_Checker.Text.Trim().Equals(""))
            {
                Prompt.Information("已经审核，无需进行再次审核！");
                return;
            }

            using (SqlConnection connection = SqlHelper.OpenConnection())  //创建连接对象 
            {
                SqlTransaction sqlTran = connection.BeginTransaction();    //开始事务 
                SqlCommand cmd = connection.CreateCommand();               //创建SqlCommand对象 
                cmd.Transaction = sqlTran;                                 //将SqlCommand与SqlTransaction关联起

                try
                {
                    cmd.CommandText = string.Format("update UpSettleMain set Checker = '{0}', CheckDate = GETDATE() where UpSettleID = {1}", Login.User.UserName, UpSettleID);
                    cmd.ExecuteNonQuery();

                    sqlTran.Commit();  //事务提交
                    label_Checker.Text = Login.User.UserName;
                    connection.Close();
                    Prompt.Information("操作成功");

                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();  //异常事务回滚
                    Prompt.Error("操作失败， 错误：" + ex.Message);
                }
            }

        }

        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {
            if ((dataGridView_Settlement.Rows.Count == 0) || (dataGridView_Settlement.CurrentRow == null))
            {
                Prompt.Warning("没有选择记录！");
                return;
            }

            if (dataGridView_Settlement.Rows.Count == 1)
            {
                Prompt.Warning("仅有一条记录！无法清空报表，请直接删除报表");
                return;
            }

            if (!label_Checker.Text.Equals(""))
            {
                Prompt.Warning("结算已审核，无法删除！");
                return;
            }

            int rowIdx = dataGridView_Settlement.CurrentRow.Index;

            if (rowIdx != -1) 
            {
                if (MessageBox.Show("确认要删除选择的记录？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string tid = dataGridView_Settlement.CurrentRow.Cells["ColTID"].Value.ToString();
                    string sid = dataGridView_Settlement.CurrentRow.Cells["ColSID"].Value.ToString();
                    string sql = "delete UpSettleDetail where SDID = " + dataGridView_Settlement.CurrentRow.Cells["ColSDID"].Value.ToString();
                    SqlHelper.ExecuteNonQuery(sql);

                    dataGridView_Settlement.Rows.RemoveAt(rowIdx);
                }
            }

        }

        private void toolStripButton_Export_Click(object sender, EventArgs e)
        {
            Common.Exp2XLS(dataGridView_Settlement);
        }

        private void FrmUpSettleDetail_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            string sql = string.Empty;
            sql = "select ProjectName,TableName,TableMaker,Convert(varchar(10),SettleDate,120) as SettleDate,Checker from UpSettleMain where UpSettleID = " + UpSettleID;
            SqlDataReader sdr_main = SqlHelper.ExecuteReader(sql);
            sdr_main.Read();

            label_ProjectName.Text = sdr_main["ProjectName"].ToString();
            label_TableName.Text = sdr_main["TableName"].ToString();
            label_TableMaker.Text = sdr_main["TableMaker"].ToString();
            label_Date.Text = sdr_main["SettleDate"].ToString();
            label_Checker.Text = sdr_main["Checker"].ToString();

            sdr_main.Close();

            sql = string.Format("select * from UpSettleDetail where UpSettleID = {0}", UpSettleID);

            DataTable dt_Settlement = SqlHelper.ExecuteDataTable(sql);
            dataGridView_Settlement.DataSource = dt_Settlement ;
        }
    }
}
