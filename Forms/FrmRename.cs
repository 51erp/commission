using Commission.DataAccess;
using Commission.MenuForms;
using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Commission.Forms
{
    public partial class FrmRename : Form
    {
        public OperationType OperType = OperationType.contract;
        public string AgreementID;
        public string CustomerID;
        public Customer NewCustomer = new Customer();

        public FrmRename()
        {
            InitializeComponent();

        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmRename_Load(object sender, EventArgs e)
        {
            if (OperType == OperationType.subscribe)
            {
                this.Text = "认购更名";
                label_AgreementNum.Text = "认购编号";
            }

            loadData();
        }

        private void loadData()
        {
            string sql = "select CustomerName,CustomerPhone,PID,Addr from Customer where CustomerID = " + CustomerID;
            SqlDataReader sdr = SqlHelper.ExecuteReader(sql);
            if(sdr.Read())
            {
                textBox_OrigCusName.Text = sdr["CustomerName"].ToString();
                textBox_OrigCusPhone.Text = sdr["CustomerPhone"].ToString();
                textBox_OrigCusPID.Text = sdr["PID"].ToString();
                textBox_OrigCusAddr.Text = sdr["Addr"].ToString();
            }
        }

        private void button_CusMore_Click(object sender, EventArgs e)
        {
            FrmCustomer cus = new FrmCustomer();

            if (cus.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox_CusName.Tag = cus.SelectedCus.CustomerID;
                textBox_CusName.Text = cus.SelectedCus.CustomerName;
                textBox_CusPhone.Text = cus.SelectedCus.Phone;
                textBox_CusPID.Text = cus.SelectedCus.PID;
                textBox_CusAddr.Text = cus.SelectedCus.Addr;
            }
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            if (textBox_CusName.Text.Equals(""))
            {
                Prompt.Information("未选择新客户信息！");
                return;
            }

            if (textBox_AgreementNum.Text.Trim().Equals(""))
            {
                Prompt.Information("编号不能为空！");
                return;
            }

            using (SqlConnection connection = SqlHelper.OpenConnection())  //创建连接对象 
            {
                SqlTransaction sqlTran = connection.BeginTransaction();    //开始事务 
                SqlCommand cmd = connection.CreateCommand();               //创建SqlCommand对象 
                cmd.Transaction = sqlTran;                                 //将SqlCommand与SqlTransaction关联起

                try
                {
                    if (OperType == OperationType.contract)
                    {
                        //签约主表
                        cmd.CommandText = string.Format("update ContractMain Set CustomerID = {0}, CustomerName = '{1}', CustomerPhone = '{2}',ContractNum = '{3}' where ContractID = {4}",
                            textBox_CusName.Tag.ToString(), textBox_CusName.Text, textBox_CusPhone.Text, textBox_AgreementNum.Text.Trim(), AgreementID);
                    }
                    else
                    {
                        //认购主表
                        cmd.CommandText = string.Format("update SubscribeMain Set CustomerID = {0}, CustomerName = '{1}', CustomerPhone = '{2}',SubscribeNum = '{3}' where SubscribeID = {4}",
                            textBox_CusName.Tag.ToString(), textBox_CusName.Text, textBox_CusPhone.Text, textBox_AgreementNum.Text.Trim(), AgreementID);
                    }
                    cmd.ExecuteNonQuery();

                    //更名记录
                    string strValue = AgreementID + ",'" + OperType.ToString() + "'," + CustomerID + ",'" + textBox_OrigCusName.Text + "','" + textBox_OrigCusPhone.Text + "'," + textBox_CusName.Tag.ToString() + ",'" + textBox_CusName.Text + "',"
                        + "'" + dateTimePicker_ChangeNameDate.Value.ToString("yyyy-MM-dd") + "','" + textBox_Memo.Text+ "','" + textBox_Relation.Text.Trim() + "','" + Login.User.UserName + "',GETDATE()";
                    cmd.CommandText = string.Format("insert into NameExchange " 
                        + "(AgreementID,ExchangeType,OrigID,OrigName,OrigPhone,NewID,NewName,ExchangeDate,Memo,Relation, MakeUserName,MakeDate) values ({0})", strValue);
                    cmd.ExecuteNonQuery();



                    sqlTran.Commit();  //事务提交
                    connection.Close();

                    NewCustomer.CustomerID = textBox_CusName.Tag.ToString();
                    NewCustomer.CustomerName = textBox_CusName.Text;
                    NewCustomer.Phone = textBox_CusPhone.Text;

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;

                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();  //异常事务回滚
                    Prompt.Error("操作失败， 错误：" + ex.Message);
                }
            }
        }
    }
}


