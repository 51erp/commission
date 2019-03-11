using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Commission.Forms;
using Commission.Utility;

namespace Commission.MenuForms
{
    public partial class FrmPaymentMode : Form
    {
        public FrmPaymentMode()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            PaymentModeAdd add = new PaymentModeAdd();
            add.Owner = this;
            if (add.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Prompt.Information("操作成功，数据已添加！");
            }
        }

        private void FrmPaymentMode_Load(object sender, EventArgs e)
        {
            GetPaymentMode();
        }

        public void GetPaymentMode()
        {
            string sql = string.Format("select ID,PayName,PayType,PayTypeName,DownPayRate,StandardCode,StandardName,BaseCode,BaseName,Memo from PaymentMode where ProjectID  = {0} and State = 1 order by ID",Login.User.ProjectID);
            dataGridView_PaymentMode.DataSource = SqlHelper.ExecuteDataTable(sql);
        }

        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {
            if (dataGridView_PaymentMode.CurrentRow == null)
            {
                Prompt.Warning("没有选择相应的记录");
                return;
            }

            string id = dataGridView_PaymentMode.CurrentRow.Cells["ColID"].Value.ToString();

            if (IsReference(id))
            {
                Prompt.Warning("相应记录已被应用，无法删除");
                return;
            }

            try
            {
                if (MessageBox.Show("确认要删除所选记录？", Prompt.FormCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (SqlHelper.ExecuteNonQuery(string.Format("Delete PaymentMode where ID = {0}", id)) > 0)
                    {
                        dataGridView_PaymentMode.Rows.RemoveAt(dataGridView_PaymentMode.CurrentRow.Index);
                        Prompt.Information("操作成功，记录已删除！");
                    }
                }
            }
            catch (Exception)
            {
                Prompt.Error("操作失败，请重新操作或联系系统管理员");
            }
        }

        private bool IsReference(string id)
        {
            string sql = string.Format("select count(ContractID) from ContractMain where PaymentID = {0}", id);

            if (int.Parse(SqlHelper.ExecuteScalar(sql).ToString()) > 0)
                return true;
            else
                return false;
        }

        private void toolStripButton_Modify_Click(object sender, EventArgs e)
        {
            if (dataGridView_PaymentMode.CurrentRow != null)
            {
                string id = dataGridView_PaymentMode.CurrentRow.Cells["ColID"].Value.ToString();

                if (IsReference(id))
                {
                    Prompt.Warning("相应记录已被应用，无法修改");
                    return;
                }

                PaymentModeAdd frmModify = new PaymentModeAdd();
                frmModify.Mode = FormMode.modify;
                frmModify.PaymentID = id;
                frmModify.Owner = this;

                frmModify.ShowDialog();
            }
        }

        private void toolStripButton_View_Click(object sender, EventArgs e)
        {
            if (dataGridView_PaymentMode.CurrentRow != null)
            {
                string id = dataGridView_PaymentMode.CurrentRow.Cells["ColID"].Value.ToString();

                PaymentModeAdd frmView = new PaymentModeAdd();
                frmView.Mode = FormMode.view;
                frmView.PaymentID = id;

                frmView.ShowDialog();
            }
        }


    }
}
