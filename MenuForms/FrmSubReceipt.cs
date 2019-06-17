using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Commission.MenuForms
{
    public partial class FrmSubReceipt : Form
    {
        public FrmSubReceipt()
        {
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void button_Export_Click(object sender, EventArgs e)
        {
            Common.Exp2XLS(dataGridView_Report);
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string beginDate = dateTimePicker_Period.Value.ToString("yyyy-MM-01");
            string endDate = DateTime.Parse(beginDate).AddMonths(1).AddDays(-1).ToString("yyy-MM-dd");

            DataTable dtBase = GetBaseData(beginDate, endDate);

            int colQuantity = GetBindData(dtBase);

            dataGridView_Report.AutoGenerateColumns = false;

            InsertBindCol(dataGridView_Report, "ColTotalAmount", colQuantity);

            Common.SetColumnStyle(dataGridView_Report.Columns["ColArea"], ColType.area);
            Common.SetColumnStyle(dataGridView_Report.Columns["ColPrice"], ColType.price);
            Common.SetColumnStyle(dataGridView_Report.Columns["ColAmount"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Report.Columns["ColTotalAmount"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Report.Columns["ColPreRecTotal"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Report.Columns["ColPeriodRecAmount"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Report.Columns["ColPeriodReturn"], ColType.amount);

            dataGridView_Report.Columns["ColItemNum"].Frozen = true;

            dataGridView_Report.DataSource = dtBase;

            if (dataGridView_Report.Rows.Count == 0)
                Prompt.Information("没有符合条件的记录");

        }

        private DataTable GetBaseData(string beginDate, string endDate)
        {
            DataTable dt = new DataTable();
            string sql = string.Empty;

            sql = string.Format("select distinct a.SubscribeID, CustomerName, CustomerPhone, b.Building, b.Unit, b.ItemNum, b.Area, b.Price, b.Amount, "
                + "TotalAmount, SubscribeDate, a.SalesName, '' LastRecDate, '' PreRecTotal, "
                + "a.ExtField0,a.ExtField1,a.ExtField2,a.ExtField3,a.ExtField4,a.ExtField5,a.ExtField6,a.ExtField7,a.ExtField8,a.ExtField9 "
                + "from SubscribeMain a " 
                + "inner join SubscribeDetail b on b.SubscribeID = a.SubscribeID "
                + "inner join Receipt c on c.SubscribeID = a.SubscribeID " 
                + "where b.IsBind = 0 and c.ContractID is null "
                + "and  Convert(Varchar(10),RecDate,120) >= '{0}'and Convert(Varchar(10),RecDate,120) <= '{1}' and a.ProjectID = {2} ", beginDate, endDate, Login.User.ProjectID);

            dt = SqlHelper.ExecuteDataTable(sql);
            dt.PrimaryKey = new DataColumn[] { dt.Columns["SubscribeID"] };


            //当期收款信息
            sql = string.Format("select SubscribeID, "
              + " SUM(case when TypeCode != '6' then amount else 0 end) PeriodRecAmount,"
              + " SUM(case TypeCode when '6' then amount else 0 end) PeriodReturn "
              + " from Receipt where Contractid is null " 
              + " and Convert(Varchar(10),RecDate,120) >= '{0}'and Convert(Varchar(10),RecDate,120) <= '{1}' and ProjectID = {2} "
              + " group by SubscribeID ", beginDate, endDate, Login.User.ProjectID);

            DataTable dtReceipt = SqlHelper.ExecuteDataTable(sql);

            dt.Merge(dtReceipt, false, MissingSchemaAction.Add);

            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string subscribeID = dt.Rows[i]["SubscribeID"].ToString();

                //前期回款累计
                sql = string.Format("select IsNull(sum(Amount),0) from receipt where Convert(Varchar(10),RecDate,120) < '{0}' and SubscribeID = {1}", beginDate, subscribeID);
                dt.Rows[i]["PreRecTotal"] = string.Format("{0:F0}", double.Parse(SqlHelper.ExecuteScalar(sql).ToString()));


                //最后收款日期
                sql = string.Format("select Convert(Varchar(10),MAX(RecDate),120) from Receipt where SubscribeID = {0}", subscribeID);

                object objResult = SqlHelper.ExecuteScalar(sql);

                if (objResult != null)
                {
                    dt.Rows[i]["LastRecDate"] = objResult.ToString();
                }
            }


            return dt;
        }

        private int GetBindData(DataTable dtBase)
        {
            int colQuantity = 0;
            string prefix = "Bind_";
            string sql = string.Empty;

            DataTable dtBind = new DataTable();
            dtBind.Columns.Add("SubscribeID", typeof(int));

            for (int i = 0; i < dtBase.Rows.Count; i++)
            {
                sql = string.Format("select ItemNum, Area, Price, Amount from ContractDetail where IsBind = 1 and ContractID = {0}", dtBase.Rows[i]["SubscribeID"].ToString());

                DataTable dtResult = SqlHelper.ExecuteDataTable(sql);

                //创建列，大于当前列则创建
                if (dtResult.Rows.Count > colQuantity)
                {
                    for (int j = colQuantity; j < dtResult.Rows.Count; j++)
                    {
                        for (int n = 0; n < dtResult.Columns.Count; n++)
                        {
                            string colName = prefix + dtResult.Columns[n].ColumnName + j;
                            dtBind.Columns.Add(colName, dtResult.Columns[n].DataType);
                        }
                    }
                    colQuantity = dtResult.Rows.Count;
                }

                //创建行并赋值
                if (dtResult.Rows.Count > 0)
                {
                    DataRow row = dtBind.NewRow();
                    row["SubscribeID"] = dtBase.Rows[i]["SubscribeID"].ToString();

                    for (int m = 0; m < dtResult.Rows.Count; m++)
                    {
                        for (int n = 0; n < dtResult.Columns.Count; n++)
                        {
                            string colName = prefix + dtResult.Columns[n].ColumnName + m;
                            row[colName] = dtResult.Rows[m][n];
                        }
                    }
                    dtBind.Rows.Add(row);
                }
            }

            if (dtBind.Rows.Count > 0)
                dtBase.Merge(dtBind, false, MissingSchemaAction.Add); //合并至主体表

            return colQuantity;
        }

        private void InsertBindCol(DataGridView dgv, string startColName, int iColQuantity)
        {
            string prefix = "Bind_";

            int iBeginPos = dgv.Columns[startColName].Index;

            //增加BIND字段
            for (int i = 0; i < iColQuantity; i++)
            {
                //房号
                string sItemNum = prefix + "ItemNum" + i.ToString();

                DataGridViewTextBoxColumn itemNum = new DataGridViewTextBoxColumn();
                itemNum.Name = sItemNum;
                itemNum.DataPropertyName = sItemNum;
                itemNum.HeaderText = "储藏间号" + i.ToString();
                dgv.Columns.Insert(iBeginPos++, itemNum);


                //面积
                string sArea = prefix + "Area" + i.ToString();

                DataGridViewTextBoxColumn area = new DataGridViewTextBoxColumn();
                area.Name = sArea;
                area.DataPropertyName = sArea;
                area.HeaderText = "面积" + i.ToString();
                area.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                area.DefaultCellStyle.Format = "F2";
                dgv.Columns.Insert(iBeginPos++, area);


                //单价
                string sPrice = prefix + "Price" + i.ToString();

                DataGridViewTextBoxColumn price = new DataGridViewTextBoxColumn();
                price.Name = sPrice;
                price.DataPropertyName = sPrice;
                price.HeaderText = "单价" + i.ToString();
                price.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                price.DefaultCellStyle.Format = "F4";
                dgv.Columns.Insert(iBeginPos++, price);


                //金额
                string sAmount = prefix + "Amount" + i.ToString();

                DataGridViewTextBoxColumn amount = new DataGridViewTextBoxColumn();
                amount.Name = sAmount;
                amount.DataPropertyName = sAmount;
                amount.HeaderText = "金额" + i.ToString();
                amount.DefaultCellStyle.Format = "F0";
                amount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Columns.Insert(iBeginPos++, amount);
            }


        }

    }
}
