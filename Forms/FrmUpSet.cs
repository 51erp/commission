using Commission.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Commission.Business;

namespace Commission.Forms
{
    public partial class FrmUpSet : Form
    {
        public FormMode FrmMode = FormMode.add;
        public string UPID = string.Empty;

        public FrmUpSet()
        {
            InitializeComponent();
            MasterData.setUpBase(comboBox_UpBase);
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmUpSet_Load(object sender, EventArgs e)
        {
            if (FrmMode == FormMode.modify)
            {
                this.Text = "跳点设置－修改";
                LoadUpgrade();
            }

            if (FrmMode == FormMode.view)
            {
                this.Text = "跳点设置－查看";
                toolStripButton_Save.Visible = false;
                LoadUpgrade();
            }
        }

        private void LoadUpgrade()
        {
            string sql = string.Format("select UPID,UpName,UpBaseCode, UpBaseName, IsSubscribe,BaseRate,BeginDate,EndDate from SchemeUpgrade where UPID = {0} ", UPID);
            SqlDataReader sdr = SqlHelper.ExecuteReader(sql);
            if (sdr.Read())
            {
                textBox_UpName.Text = sdr["UpName"].ToString();
                comboBox_UpBase.SelectedValue = sdr["UpBaseCode"].ToString();
                checkBox_Subscribe.Checked = Convert.ToBoolean(sdr["IsSubscribe"]);
                textBox_BaseRate.Text = sdr["BaseRate"].ToString();
                dateTimePicker_Begin.Text = sdr["BeginDate"].ToString();
                dateTimePicker_End.Text = sdr["EndDate"].ToString();

                sql = string.Format("select BeginValue, EndValue, UpRate from UpValue where UPID = {0} order by RowNum ", UPID);

                SqlDataReader dr = SqlHelper.ExecuteReader(sql);
                while(dr.Read())
                {
                    int i = dataGridView_UpValues.Rows.Add();
                    dataGridView_UpValues.Rows[i].Cells["ColBeginValue"].Value = dr["BeginValue"].ToString();
                    dataGridView_UpValues.Rows[i].Cells["ColEndValue"].Value = dr["EndValue"].ToString();
                    dataGridView_UpValues.Rows[i].Cells["ColUpRate"].Value = dr["UpRate"].ToString();
                }
            }
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            dataGridView_UpValues.EndEdit();

            if (DataGridViewValidate())
            {
                int rowIdx = dataGridView_UpValues.Rows.Add();
                dataGridView_UpValues.CurrentCell = dataGridView_UpValues.Rows[rowIdx].Cells[0];
                dataGridView_UpValues[0, rowIdx].Value = 0;
                dataGridView_UpValues[1, rowIdx].Value = 0;
                dataGridView_UpValues[2, rowIdx].Value = 0;
                dataGridView_UpValues.BeginEdit(true);
            }
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            if (InputValidate())
            {
                if (FrmMode == FormMode.add)
                {
                    InsertData();
                }

                if (FrmMode == FormMode.modify)
                {
                    UpdateData();
                }
            }
        }


        private void InsertData()
        {
            //SQL事务
            using (SqlConnection connection = SqlHelper.OpenConnection())  //创建连接对象 
            {
                SqlTransaction sqlTran = connection.BeginTransaction();    //开始事务 
                SqlCommand cmd = connection.CreateCommand();               //创建SqlCommand对象 
                cmd.Transaction = sqlTran;                                 //将SqlCommand与SqlTransaction关联起

                try
                {
                    //跳点主表
                    string values = "'" + textBox_UpName.Text.Trim() + "'"
                        + "," + textBox_BaseRate.Text.Trim()
                        + "," + Login.User.ProjectID
                        + "," + comboBox_UpBase.SelectedValue
                        + ",'" + comboBox_UpBase.Text + "'"
                        + "," + (checkBox_Subscribe.Checked ? "1" : "0")
                        + ",'" + dateTimePicker_Begin.Text + "'"
                        + ",'" + dateTimePicker_End.Text + "'";
                    cmd.CommandText = string.Format("insert into SchemeUpgrade  (UpName,BaseRate, ProjectID,UpBaseCode,UpBaseName,IsSubscribe,BeginDate,EndDate) output inserted.upid  values ({0})", values);
                    string upid = cmd.ExecuteScalar().ToString();

                    //跳点值(子表）
                    for (int i = 0; i < dataGridView_UpValues.Rows.Count; i++)
                    {
                        string begin = dataGridView_UpValues.Rows[i].Cells["ColBeginValue"].FormattedValue.ToString().Equals("") ? "NULL" : dataGridView_UpValues.Rows[i].Cells["ColBeginValue"].FormattedValue.ToString();
                        string end = dataGridView_UpValues.Rows[i].Cells["ColEndValue"].FormattedValue.ToString().Equals("") ? "NULL" : dataGridView_UpValues.Rows[i].Cells["ColEndValue"].FormattedValue.ToString();
                        string rate = dataGridView_UpValues.Rows[i].Cells["ColUpRate"].FormattedValue.ToString();

                        cmd.CommandText = string.Format("insert into UpValue (UPID, RowNum, BeginValue, EndValue, UpRate) values ({0},{1},{2},{3},{4})", upid, i, begin, end, rate);
                        cmd.ExecuteNonQuery();
                    }

                    sqlTran.Commit();  //事务提交
                    connection.Close();

                    Prompt.Information("操作成功");
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;

                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();  //异常事务回滚
                    Prompt.Error("操作失败， 错误：" + ex.Message);
                }
            }
        }


        private void UpdateData()
        {
            //SQL事务
            using (SqlConnection connection = SqlHelper.OpenConnection())  //创建连接对象 
            {
                SqlTransaction sqlTran = connection.BeginTransaction();    //开始事务 
                SqlCommand cmd = connection.CreateCommand();               //创建SqlCommand对象 
                cmd.Transaction = sqlTran;

                string sql = string.Empty;
                try
                {
                    sql = string.Format("Update SchemeUpgrade set UpName = '{0}',BaseRate = {1}, UpBaseCode = {2},UpBaseName = '{3}', BeginDate = '{4}',EndDate = '{5}', IsSubscribe = {6}  where UPID = {7}",
                        textBox_UpName.Text.Trim(), 
                        textBox_BaseRate.Text.Trim(),
                        comboBox_UpBase.SelectedValue,
                        comboBox_UpBase.Text,
                        dateTimePicker_Begin.Text,
                        dateTimePicker_End.Text,
                        (checkBox_Subscribe.Checked ? "1" : "0"),
                        UPID);

                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = string.Format("delete UpValue where UPID = {0}", UPID);
                    cmd.ExecuteNonQuery();

                    //跳点值(子表）
                    for (int i = 0; i < dataGridView_UpValues.Rows.Count; i++)
                    {
                        string begin = dataGridView_UpValues.Rows[i].Cells["ColBeginValue"].FormattedValue.ToString().Equals("") ? "NULL" : dataGridView_UpValues.Rows[i].Cells["ColBeginValue"].FormattedValue.ToString();
                        string end = dataGridView_UpValues.Rows[i].Cells["ColEndValue"].FormattedValue.ToString().Equals("") ? "NULL" : dataGridView_UpValues.Rows[i].Cells["ColEndValue"].FormattedValue.ToString();
                        string rate = dataGridView_UpValues.Rows[i].Cells["ColUpRate"].FormattedValue.ToString();

                        cmd.CommandText = string.Format("insert into UpValue (UPID, RowNum, BeginValue, EndValue, UpRate) values ({0},{1},{2},{3},{4})", UPID, i, begin, end, rate);
                        cmd.ExecuteNonQuery();
                    }

                    sqlTran.Commit();  //事务提交
                    connection.Close();

                    Prompt.Information("操作成功");
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();  //异常事务回滚
                    Prompt.Error("操作失败， 错误：" + ex.Message);
                }
            }
        }


        private bool InputValidate()
        {
            if (textBox_UpName.Text.Trim().Equals(""))
            {
                Prompt.Warning("跳点名称不能为空！");
                textBox_UpName.Focus();
                return false;
            }

            if (textBox_BaseRate.Text.Trim().Equals(""))
            {
                Prompt.Warning("基础提点不能为空！");
                textBox_BaseRate.Focus();
                return false;
            }
            else
            {
                double baseRate = 0;
                if (double.TryParse(textBox_BaseRate.Text.Trim(), out baseRate))
                {
                    if ((baseRate <= 0) || (baseRate > 100))
                    {
                        Prompt.Warning("基础提点数值的有效区间为：0 < 基础提点 <= 100");
                        textBox_BaseRate.Focus();
                        return false;
                    }
                }
                else
                {
                    Prompt.Warning("基础提点必须为数字格式！");
                    textBox_BaseRate.Focus();
                    return false;
                }
            }



            if (dateTimePicker_Begin.Value > dateTimePicker_End.Value)
            {
                Prompt.Warning("开始时间不能大于结束时间！");
                dateTimePicker_Begin.Focus();
                return false;
            }

            if (dataGridView_UpValues.Rows.Count == 0)
            {
                Prompt.Warning("跳点信息记录不能为空！");
                return false;
            }

            return DataGridViewValidate();
        }


        private bool DataGridViewValidate()
        {
            dataGridView_UpValues.EndEdit();

            for (int i = 0; i < dataGridView_UpValues.Rows.Count; i++)
            {
                double beginVal = 0;
                if (!double.TryParse(dataGridView_UpValues.Rows[i].Cells["ColBeginValue"].FormattedValue.ToString(), out beginVal))
                {
                    Prompt.Error("请输入正确数字!");
                    dataGridView_UpValues.Rows[i].Cells["ColBeginValue"].Selected = true;
                    dataGridView_UpValues.BeginEdit(true);
                    return false;
                }
                else
                {
                    if (beginVal < 0)
                    {
                        Prompt.Error("起始数值不能为负值");
                        dataGridView_UpValues.Rows[i].Cells["ColBeginValue"].Selected = true;
                        dataGridView_UpValues.BeginEdit(true);
                        return false;
                    }
                }


                double endVal = 0;
                if (!double.TryParse(dataGridView_UpValues.Rows[i].Cells["ColEndValue"].FormattedValue.ToString(), out endVal))
                {
                    Prompt.Error("请输入正确数字!");
                    dataGridView_UpValues.Rows[i].Cells["ColEndValue"].Selected = true;
                    dataGridView_UpValues.BeginEdit(true);
                    return false;
                }
                else
                {
                    if (endVal < 0)
                    {
                        Prompt.Error("终止数值不能为负值!");
                        dataGridView_UpValues.Rows[i].Cells["ColEndValue"].Selected = true;
                        dataGridView_UpValues.BeginEdit(true);
                        return false;
                    }
                }

                double rate = 0;
                if (!double.TryParse(dataGridView_UpValues.Rows[i].Cells["ColUpRate"].FormattedValue.ToString(), out rate))
                {
                    Prompt.Error("请输入正确数字!");
                    dataGridView_UpValues.Rows[i].Cells["ColUpRate"].Selected = true;
                    dataGridView_UpValues.BeginEdit(true);
                    return false;
                }

                if (beginVal == 0 && endVal  == 0)
                {
                    Prompt.Error("起始值和终止值不能同时为零");
                    dataGridView_UpValues.Rows[i].Cells["ColBeginValue"].Selected = true;
                    dataGridView_UpValues.BeginEdit(true);
                    return false;
                }

                if (beginVal >= endVal)
                {
                    if (!(i == dataGridView_UpValues.RowCount -1 && endVal == 0)) //最后一条endVal为零即不设上限 
                    {
                        Prompt.Error("终止值必须大于起始值");
                        dataGridView_UpValues.Rows[i].Cells["ColBeginValue"].Selected = true;
                        dataGridView_UpValues.BeginEdit(true);
                        return false;

                    }
                }

                if (rate <= 0 || rate > 100)
                {
                    Prompt.Error("跳点比例有效区间为: 0 < 跳点比例 <= 100");
                    dataGridView_UpValues.Rows[i].Cells["ColUpRate"].Selected = true;
                    dataGridView_UpValues.BeginEdit(true);
                    return false;
                }

                if (i > 0) //第二条记录开始
                {
                    double preEndVal = double.Parse(dataGridView_UpValues.Rows[i - 1].Cells["ColEndValue"].FormattedValue.ToString());
                    if (beginVal < preEndVal)
                    {
                        Prompt.Error("起始数值不能小于前一记录的结束数值！");
                        dataGridView_UpValues.Rows[i].Cells["ColBeginValue"].Selected = true;
                        dataGridView_UpValues.BeginEdit(true);
                        return false;
                    }
                }
            }

            return true;
        }



        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {
            if (dataGridView_UpValues.CurrentRow != null)
            {
                int rowIdx = dataGridView_UpValues.CurrentRow.Index;
                dataGridView_UpValues.Rows.RemoveAt(rowIdx);
            }
            else
            {
                Prompt.Warning("未选择记录！");
            }
        }

        private void comboBox_UpBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_UpBase.SelectedIndex == 1)
            {
                checkBox_Subscribe.Enabled = true;
            }
            else
            {
                checkBox_Subscribe.Checked = false;
                checkBox_Subscribe.Enabled = false;
            }
        }

        private void dataGridView_UpValues_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tx = e.Control as TextBox;
            tx.KeyPress -= new KeyPressEventHandler(tx_KeyPress);
            tx.KeyPress += new KeyPressEventHandler(tx_KeyPress);
        }
        private void tx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void textBox_BaseRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.OnlyNumeric(sender, e);
        }
    }
}
