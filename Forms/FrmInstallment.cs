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
    public partial class FrmInstallment : Form
    {
        public FormMode FrmMode;
        public string InstallmentAmount = "0";
        public string ContractID = string.Empty;

        public DataTable dtInstallment;

        public FrmInstallment()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            AddStage();
        }

        private void AddStage(int amount=0)
        {

            if (!this.Validate()) //防止验证未通过而执行其它操作
            {
                return;
            }

            int idx = dataGridView_Installment.Rows.Add();
            DataGridViewRow dr = dataGridView_Installment.Rows[idx];
            dr.Cells["ColSequence"].Value = (idx + 1).ToString();
            dr.Cells["ColPayDate"].Value = DateTime.Now.ToShortDateString();
            dr.Cells["ColSettled"].Value = "0";

            dataGridView_Installment.CurrentCell = dataGridView_Installment.Rows[idx].Cells["ColAmount"];
            
            if (amount == 0)
            {
                dataGridView_Installment.BeginEdit(true);
            }
            else
            {
                dataGridView_Installment.CurrentCell.Value = amount;
            }
        }

        private void toolStripButton_Remove_Click(object sender, EventArgs e)
        {
            if (dataGridView_Installment.CurrentRow == null)
            {
                Prompt.Warning("未选择要删除的记录！");
            }
            else
            {
                int rowIdx = dataGridView_Installment.CurrentRow.Index;
                dataGridView_Installment.Rows.RemoveAt(rowIdx);

                for (int i = rowIdx; i < dataGridView_Installment.Rows.Count; i++)
                {
                    dataGridView_Installment.Rows[i].Cells["ColSequence"].Value = (i + 1).ToString();
                }
            }
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            if (!this.Validate()) //验证DGV中的数据
            {
                return;
            }

            if (dataGridView_Installment.Rows.Count <= 1)
            {
                Prompt.Warning("分期付款记录应不少于两期！");
                return;
            }

            if (int.Parse(textBox_Unassigned.Text) != 0)
            {
                Prompt.Warning("分期付款金额与应付金额不符，无法保存！");
                return;
            }

            dtInstallment.Rows.Clear();

            for (int i = 0; i < dataGridView_Installment.Rows.Count; i++)
            {
                DataRow dr = this.dtInstallment.NewRow();

                dr["Sequence"] = dataGridView_Installment.Rows[i].Cells["ColSequence"].EditedFormattedValue.ToString();
                dr["PayDate"] = dataGridView_Installment.Rows[i].Cells["ColPayDate"].EditedFormattedValue.ToString();
                dr["Amount"] = dataGridView_Installment.Rows[i].Cells["ColAmount"].EditedFormattedValue.ToString();
                dr["Settled"] = dataGridView_Installment.Rows[i].Cells["ColSettled"].EditedFormattedValue.ToString();

                this.dtInstallment.Rows.Add(dr);
            }

            if (MessageBox.Show("是否要保存分期付款设置？","房地产佣金系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }


            
        }

        private void FrmInstallment_Load(object sender, EventArgs e)
        {
            if (FrmMode == FormMode.view)
            {
                toolStripButton_Save.Visible = false;
            }
            LoadInstallment();
        }

        private void LoadInstallment()
        {
            dataGridView_Installment.Rows.Clear();

            textBox_Amount.Text = InstallmentAmount;

            if (dtInstallment.Rows.Count == 0)
            {
                textBox_Unassigned.Text = InstallmentAmount;
                return;
            }
                

            //dataGridView_Installment.DataSource = dtInstallment;

            foreach (DataRow dr  in dtInstallment.Rows)
            {

                int idx = dataGridView_Installment.Rows.Add();
                DataGridViewRow row = dataGridView_Installment.Rows[idx];
                row.Cells["ColSequence"].Value = dr["Sequence"];
                row.Cells["ColPayDate"].Value = dr["PayDate"];
                row.Cells["ColAmount"].Value = dr["Amount"];
                row.Cells["ColSettled"].Value = dr["Settled"];
            }

            try
            {
                int amount = int.Parse(dtInstallment.Compute("sum(Amount)", "").ToString());
                textBox_Unassigned.Text = (double.Parse(InstallmentAmount) - amount).ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }

        private void dataGridView_Installment_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int amount = 0;
            if (dataGridView_Installment.IsCurrentCellInEditMode == true)
            {
                if (!int.TryParse(dataGridView_Installment.Rows[e.RowIndex].Cells["ColAmount"].EditedFormattedValue.ToString(), out amount))
                {
                    Prompt.Error("请填写正确的数字格式！");
                    e.Cancel = true;
                }
                else
                {
                    if (amount <= 0)
                    {
                        Prompt.Error("分配金额不能为负数或零");
                        e.Cancel = true;
                    }
                }
            }
        }

        private void dataGridView_Installment_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            getUnassigned();
        }

        private void dataGridView_Installment_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            getUnassigned();
        }

        private void getUnassigned()
        {
            double amount = 0;
            for (int i = 0; i < dataGridView_Installment.Rows.Count; i++)
            {
                amount += double.Parse(dataGridView_Installment.Rows[i].Cells["ColAmount"].EditedFormattedValue.ToString());
            }

            textBox_Unassigned.Text = (double.Parse(textBox_Amount.Text) - amount).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int unassigned = int.Parse(textBox_Unassigned.Text);
            if (unassigned <= 0)
            {
                Prompt.Warning("没有足够数值进行分配！");
                return;
            }

            AddStage(unassigned);
            textBox_Unassigned.Text = "0";
        }


    }
}
