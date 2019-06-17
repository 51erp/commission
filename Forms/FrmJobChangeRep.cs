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
    public partial class FrmJobChangeRep : Form
    {
        public FrmJobChangeRep()
        {
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string condition = string.Empty;
            if (!textBox_SalesName.Text.Trim().Equals(""))
            {
                condition = string.Format(" and a.SalesName like '%{0}%' ",textBox_SalesName.Text.Trim() );
            }

            string sql = string.Format("select a.ID, a.SalesID, a.SalesName,DeptID, DeptName, JobType, BeginDate, EndDate, OperationType from JobTrack a inner join Sales b on b.SalesID = a.SalesID  where b.ProjectID = {0} {1} order by a.ID Desc, a.SalesName, BeginDate ", Login.User.ProjectID, condition);

            dataGridView_Employee.DataSource = SqlHelper.ExecuteDataTable(sql);

            if (dataGridView_Employee.Rows.Count == 0)
                Prompt.Information("没有符合条件的记录！");
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            if (dataGridView_Employee.CurrentRow == null)
            {
                Prompt.Warning("未选定信息！");
            }

            string salesID = dataGridView_Employee.CurrentRow.Cells["ColSalesID"].Value.ToString();
            int currId = int.Parse(dataGridView_Employee.CurrentRow.Cells["ColID"].Value.ToString());

            string sql = string.Format("select max(id) from JobTrack where SalesID = {0}", salesID);
            int maxId = int.Parse(SqlHelper.ExecuteScalar(sql).ToString());

            if (currId < maxId)
            {
                Prompt.Warning("不是最后的操作记录，无法取消！");
                return;
            }

            string operationType = dataGridView_Employee.CurrentRow.Cells["ColOperationType"].Value.ToString();

            if (operationType == "入职")
            {
                Prompt.Warning("入职操作请执行删除功能！");
                return;
            }

            if (Prompt.Question("确定要取消选定的操作记录？") == System.Windows.Forms.DialogResult.Yes)
            {

                if (operationType == "调岗")
                {
                    SqlHelper.ExecuteNonQuery("Delete JobTrack where ID = "+ currId);
                    SqlHelper.ExecuteNonQuery(string.Format("Update JobTrack set EndDate = null where ID = (select max(id) from JobTrack where SalesID = {0})", salesID));
                    dataGridView_Employee.Rows.RemoveAt(dataGridView_Employee.CurrentRow.Index);
                }

                if (operationType == "调出")
                {
                    SqlHelper.ExecuteNonQuery(string.Format("Update JobTrack set OperationType = OrigOperationType, EndDate = null where ID = {0}", currId));
                }

                if (operationType == "调入")
                {
                    SqlHelper.ExecuteNonQuery(string.Format("Delete JobTrack where ID = {0}", currId));
                    SqlHelper.ExecuteNonQuery(string.Format("Update Sales set IsFree = 0 where SalesID = {0}", salesID));
                }

                if (operationType == "离职")
                {

                    string orig = SqlHelper.ExecuteScalar(string.Format("select OrigOperationType from JobTrack where ID = {0}", currId)).ToString();
                    if (orig.Equals("调出"))
                    {
                        sql = string.Format("Update JobTrack set OperationType = OrigOperationType where ID = {0}", currId);
                    }
                    else
                    {
                        sql = string.Format("Update JobTrack set OperationType = OrigOperationType, EndDate = null where ID = {0}", currId);
                    }

                    SqlHelper.ExecuteNonQuery(sql);
                    SqlHelper.ExecuteNonQuery(string.Format("Update Sales set OutDate = null where SalesID = {0}", salesID));
                }

                if (operationType == "复职")
                {
                    SqlHelper.ExecuteNonQuery(string.Format("Delete JobTrack where ID = {0}", currId));

                    sql = string.Format("select Convert(varchar(10), EndDate, 120) from JobTrack where ID = (select max(id) from JobTrack where SalesID = {0})", salesID); 
                    string outDate = SqlHelper.ExecuteScalar(sql).ToString();

                    SqlHelper.ExecuteNonQuery(string.Format("Update Sales set OutDate = '{0}' where SalesID = {1}",outDate, salesID));

                }

                Prompt.Information("操作完成！");

            }
        }
    }
}
