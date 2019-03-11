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
    public partial class FrmCreditAdd : Form
    {
        public string tid = string.Empty;
        public string ContractCode = string.Empty;
        private string _loan;

        public string Loan
        {
            get { return _loan; }
            set 
            { 
                _loan = value;

                textBox_Loan.Text = _loan;
            }
        }



        public FrmCreditAdd()
        {
            InitializeComponent();
        }


        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            if (!textBox_Loan.Text.Trim().Equals(""))
            {
                saveData();
            }
        }




        private void saveData()
        {
            using (SqlConnection connection = SqlHelper.OpenConnection())  //创建连接对象 
            {
                SqlTransaction sqlTran = connection.BeginTransaction();    //开始事务 
                SqlCommand cmd = connection.CreateCommand();               //创建SqlCommand对象 
                cmd.Transaction = sqlTran;                                 //将SqlCommand与SqlTransaction关联起
                string sql = string.Empty;

                try
                {

                    //收款信息
                    if (int.Parse(textBox_Loan.Text.Trim()) != 0)
                    {
                        sql = "insert into [Receipt] (tid,contractCode,Amount,RecDate,TypeCode, TypeName, MakeDate,Maker) values "
                            + "(" + tid + ",'" + ContractCode + "',"
                            + int.Parse(textBox_Loan.Text.Trim())
                            + ",'" + dateTimePicker_Loan.Value.ToShortDateString() + "'"
                            + ",4,'贷款'" 
                            + ",getDate(),'" + Login.User.UserName + "')";

                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                    }





                    //if (int.Parse(textBox_Receipt.Text.Trim()) != 0)
                    //{
                    //    sql = "insert into [Receipt] (tid,contractCode,Amount,RecDate,TypeCode, TypeName, MakeDate,Maker) values "
                    //        + "(" + tid + ",'" + ContractCode + "',"
                    //        + int.Parse(textBox_Receipt.Text.Trim())
                    //        + ",'" + dateTimePicker_Loan.Value.ToShortDateString() + "'"
                    //        + ",2,'首付'"
                    //        + ",getDate(),'" + Global.USER.UserName + "')";

                    //    cmd.CommandText = sql;
                    //    cmd.ExecuteNonQuery();
                    //}


                    sqlTran.Commit();  //事务提交
                    connection.Close();

                    Prompt.Information("操作成功");

                    DialogResult = System.Windows.Forms.DialogResult.OK;

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
