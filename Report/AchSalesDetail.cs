﻿using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Commission.Report
{
    public partial class AchSalesDetail : Form
    {
        public AchievementType AchieveType;
        public AchSalesDetail()
        {
            InitializeComponent();
        }

        private void AchSalesOwn_Load(object sender, EventArgs e)
        {
            Common.SetFirstOfMonth(dateTimePicker_Begin);
            Common.SetEndOfMonth(dateTimePicker_End);
            SetReceiptType();

            switch (AchieveType)
            {
                case AchievementType.own:
                    this.Text = "置业顾问个人业绩统计";
                    break;

                case AchievementType.allot:
                    this.Text = "置业顾问分配业绩统计";
                    break;

                case AchievementType.hold:
                    this.Text = "置业顾问调岗业绩统计";
                    break;

                default:
                    break;
            }
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Export_Click(object sender, EventArgs e)
        {
            Common.Exp2XLS(dataGridView_Achievement);
        }

        private void button_Save_Click(object sender, EventArgs e)
        {

        }

        private void SetReceiptType()
        {
            string sql = "select code, name from DictReceiptType where IsAchievement = 1 and State = 1 order by Code ";

            comboBox_RecType.DataSource = SqlHelper.ExecuteDataTable(sql);
            comboBox_RecType.DisplayMember = "name";
            comboBox_RecType.ValueMember = "code";

            if (comboBox_RecType.Items.Count > 0)
                comboBox_RecType.SelectedIndex = 0;
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            ShowAchievement();
        }

        private void ShowAchievement()
        {
            Common.SetColumnStyle(dataGridView_Achievement.Columns["ColArea"], ColType.area);
            Common.SetColumnStyle(dataGridView_Achievement.Columns["ColPrice"], ColType.price);
            Common.SetColumnStyle(dataGridView_Achievement.Columns["ColAmount"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Achievement.Columns["ColTotalAmount"], ColType.amount);
            Common.SetColumnStyle(dataGridView_Achievement.Columns["ColAchievement"], ColType.amount);

            dataGridView_Achievement.AutoGenerateColumns = false;

            dataGridView_Achievement.DataSource = GetAchievementData(AchieveType);

            if (dataGridView_Achievement.Rows.Count == 0)
                Prompt.Warning("没有符合条件的记录！");
        }

        private DataTable GetAchievementData(AchievementType type)
        {
            DataTable dtAchievement;

            string sql = string.Empty;
            string condition = string.Empty;
            //Receivables recType = (Receivables)comboBox_RecType.SelectedValue;
            string receiptType = string.Empty;

            if ((Receivables)comboBox_RecType.SelectedValue == Receivables.成销)
            {
                receiptType = string.Format("(TypeCode = {0} or TypeCode = {1} ) ", (int)Receivables.定金, (int)Receivables.首付);
            }
            else
            {
                receiptType = string.Format("TypeCode = {0}", comboBox_RecType.SelectedValue);
            }

            string beginDate = dateTimePicker_Begin.Value.ToString("yyyy-MM-dd");
            string endDate = dateTimePicker_End.Value.ToString("yyyy-MM-dd");

            //结算收款为业绩, 是否需要审核？
            //condition = string.Format("ProjectID = {0} and RecDate >= '{1}' and RecDate <= '{2}' and SettleState > 0 ",Login.User.ProjectID, beginDate, endDate);

            //未审核，测试用
            condition = string.Format("a.ProjectID = {0} and RecDate >= '{1}' and RecDate <= '{2}' and {3}", Login.User.ProjectID, beginDate, endDate, receiptType);

            switch (type)
            {
                case AchievementType.own:   //回款业绩-个人
                    sql = string.Format("select a.ContractID, a.SalesID, a.SalesName, SUM(Amount) as Achievement from Receipt a "
                        + "inner join ContractMain b on b.ContractID = a.ContractID "
                        + "where a.SalesID = b.SubscribeSalesID and {0} group by a.ContractID, a.SalesID, a.SalesName order by a.SalesID", condition);

                    break;

                case AchievementType.allot: //回款业绩-分配
                    sql = string.Format("select a.ContractID, a.SalesID, a.SalesName, SUM(Amount) * 0.7 as Achievement from Receipt a "
                        + "inner join ContractMain b on b.ContractID = a.ContractID "
                        + "where a.SalesID != b.SubscribeSalesID and {0} group by a.ContractID, a.SalesID, a.SalesName order by a.SalesID", condition);

                    break;

                case AchievementType.hold:  //回款业绩-调岗
                    sql = string.Format("select a.ContractID, b.SubscribeSalesID as SalesID,  b.SubscribeSalesName as SalesName, SUM(Amount) * 0.3 as Achievement from Receipt a "
                        + "inner join ContractMain b on b.ContractID = a.ContractID "
                        + "where a.SalesID != b.SubscribeSalesID and {0} group by a.ContractID, b.SubscribeSalesID,  b.SubscribeSalesName order by b.SubscribeSalesID", condition);

                    break;

                default:
                    break;
            }

            dtAchievement = SqlHelper.ExecuteDataTable(sql);
            dtAchievement.PrimaryKey = new DataColumn[] { dtAchievement.Columns["ContractID"], dtAchievement.Columns["SalesID"] };


            string contractId = string.Empty;
            string salesId = string.Empty;

            for (int i = 0; i < dtAchievement.Rows.Count; i++)
            {
                contractId = dtAchievement.Rows[i]["ContractID"].ToString();
                salesId = dtAchievement.Rows[i]["SalesID"].ToString();

                sql = string.Format("select a.ContractID, cast('{0}' as int) as SalesID, CustomerName, Building, Unit, ItemNum, SubscribeDate, ContractDate, '' as ReceiptDate, "
                    + "b.Area, b.Price, b.Amount, TotalAmount, '' as PayPercent from ContractMain a "
                    + "inner join ContractDetail b on b.ContractID = a.ContractID "
                    + "where IsBind = 0 and a.ContractID = {1}", salesId, contractId);

                DataTable dtContract = SqlHelper.ExecuteDataTable(sql);

                sql = string.Format("select MAX(CONVERT(varchar(10),RecDate,120)) as ReceiptDate from Receipt where ContractID = {0}", contractId);
                object objResult = SqlHelper.ExecuteScalar(sql);
                if (objResult != null)
                {
                    dtContract.Rows[0]["ReceiptDate"] = objResult.ToString();
                }

                //截止当期累计回款及占比
                sql = string.Format("select SUM(Amount) as ReceiptAmount from Receipt where ContractID = {0} and TypeCode ! = 6  and RecDate <= '{1}'", contractId, endDate);
                double tmp = double.Parse(SqlHelper.ExecuteScalar(sql).ToString());
                dtContract.Rows[0]["PayPercent"] = Math.Round(double.Parse(SqlHelper.ExecuteScalar(sql).ToString()) / double.Parse(dtContract.Rows[0]["TotalAmount"].ToString()) * 100, 2);

                dtAchievement.Merge(dtContract, false, MissingSchemaAction.Add);

            }

            ////回款百分比
            //DataColumn colPayPercent = new DataColumn();
            //colPayPercent.DataType = System.Type.GetType("System.Decimal");
            //colPayPercent.ColumnName = "PayPercent";
            //colPayPercent.Expression = "Achievement / TotalAmount * 100";
            //dtAchievement.Columns.Add(colPayPercent);

            return dtAchievement;
        }




    }
}