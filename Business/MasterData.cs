using Commission.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Commission.Business
{
    class MasterData
    {
        #region 初始化下拉框组件


        public static void  getAllProject(ComboBox cbx)
        {
            try
            {
                string sql = "select ProjectID, ProjectName from Project order by ProjectID";
                cbx.DataSource = SqlHelper.ExecuteDataTable(sql);
                cbx.DisplayMember = "ProjectName";
                cbx.ValueMember = "ProjectID";

                if (cbx.Items.Count > 0)
                    cbx.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Prompt.Error("数据库连接错误！请设置数据连接或联系管理员。\r\n\n错误信息：" + ex.Message.ToString());
            }
        }

        //销售状态
        public static void setSaleState(ComboBox cbx, ComboBoxType type = ComboBoxType.input)
        {
            string sql = "select code, name from DictSaleState where 1=1";

            if (type == ComboBoxType.search)
            {
                sql = "select '9' as code,'全部' as name union all " + sql;
            }

            cbx.DataSource = SqlHelper.ExecuteDataTable(sql);
            cbx.DisplayMember = "name";
            cbx.ValueMember = "code";

            if (cbx.Items.Count > 0)
                cbx.SelectedIndex = 0;
        }

        //房产类型
        public static void SetItemType(ComboBox cbx, ComboBoxType type = ComboBoxType.input)
        {
            string sql = "select code, name from DictItemType where 1=1 and ProjectID = " + Login.User.ProjectID;

            if (type == ComboBoxType.search)
            {
                sql = "select '0' as code,'全部' as name union all " + sql;
            }

            cbx.DataSource = SqlHelper.ExecuteDataTable(sql);
            cbx.DisplayMember = "name";
            cbx.ValueMember = "code";

            if (cbx.Items.Count > 0)
                cbx.SelectedIndex = 0;
        }

        //收款类型
        public static void SetReceiptType(ComboBox cbx, ComboBoxType type = ComboBoxType.input)
        {
            string sql = "select code, name from DictReceiptType where IsSys = 0 and State = 1 order by Code ";

            if (type == ComboBoxType.search)
            {
                sql = "select '0' as code,'全部' as name union all " + sql;
            }

            cbx.DataSource = SqlHelper.ExecuteDataTable(sql);
            cbx.DisplayMember = "name";
            cbx.ValueMember = "code";

            if (cbx.Items.Count > 0)
                cbx.SelectedIndex = 0;
        }

        //付款方式
        public static void setPayment(ComboBox cbx, ComboBoxType type = ComboBoxType.input)
        {
            string sql = "select id, PayName from PaymentMode where ProjectID = " + Login.User.ProjectID + " order by ID";

            if (type == ComboBoxType.search)
            {
                sql = "select '0' as ID,'全部' as PayName union all " + sql;
            }

            cbx.DataSource = SqlHelper.ExecuteDataTable(sql);
            cbx.DisplayMember = "PayName";
            cbx.ValueMember = "id";

            if (cbx.Items.Count > 0)
                cbx.SelectedIndex = 0;
        }


        //付款类型
        public static void SetPayType(ComboBox cbx, ComboBoxType type = ComboBoxType.input)
        {
            string sql = "select code, name from DictPayType order by Code";

            if (type == ComboBoxType.search)
            {
                sql = "select '0' as code,'全部' as name union all " + sql;
            }

            cbx.DataSource = SqlHelper.ExecuteDataTable(sql);
            cbx.DisplayMember = "name";
            cbx.ValueMember = "code";

            if (cbx.Items.Count > 0)
                cbx.SelectedIndex = 0;
        }

        //结算条件
        public static void setSettleStandard(ComboBox cbx, ComboBoxType type = ComboBoxType.input)
        {
            string sql = "select code, name from DictSettleStandard where 1=1";

            if (type == ComboBoxType.search)
            {
                sql = "select '0' as code,'全部' as name union all " + sql;
            }

            cbx.DataSource = SqlHelper.ExecuteDataTable(sql);
            cbx.DisplayMember = "name";
            cbx.ValueMember = "code";

            if (cbx.Items.Count > 0)
                cbx.SelectedIndex = 0;
        }

        //结算基础
        public static void setSettleBase(ComboBox cbx, ComboBoxType type = ComboBoxType.input)
        {
            string sql = "select code, name from DictSettleBase where 1=1";

            if (type == ComboBoxType.search)
            {
                sql = "select '0' as code,'全部' as name union all " + sql;
            }

            cbx.DataSource = SqlHelper.ExecuteDataTable(sql);
            cbx.DisplayMember = "name";
            cbx.ValueMember = "code";

            if (cbx.Items.Count > 0)
                cbx.SelectedIndex = 0;
        }


        public static void setUpBase(ComboBox cbx, ComboBoxType type = ComboBoxType.input)
        {
            string sql = "select code, name from DictUpBase where 1=1";

            if (type == ComboBoxType.search)
            {
                sql = "select '0' as code,'全部' as name union all " + sql;
            }

            cbx.DataSource = SqlHelper.ExecuteDataTable(sql);
            cbx.DisplayMember = "name";
            cbx.ValueMember = "code";

            if (cbx.Items.Count > 0)
                cbx.SelectedIndex = 0;
        }

        //置业顾问
        public static void SetSales(ComboBox cbx, ComboBoxType type = ComboBoxType.input, bool isOnlySales = false)
        {
            string sql = string.Empty;

            if (isOnlySales)
            {
                sql = "select a.SalesID, a.SalesName from sales a "
                    + " inner join JobTrack b on a.SalesID = b.SalesID "
                    + " where b.EndDate is null and JobType = '员工' and ProjectID = " + Login.User.ProjectID;
            }
            else
            {
                sql = "select SalesID, SalesName from Sales where OutDate is null and ProjectID = " + Login.User.ProjectID;
            }


            if (type == ComboBoxType.search)
            {
                sql = "select '0' as SalesID,'全部' as SalesName union all " + sql;
            }

            cbx.DataSource = SqlHelper.ExecuteDataTable(sql);
            cbx.ValueMember = "SalesID";
            cbx.DisplayMember = "SalesName";
            

            if (cbx.Items.Count > 0)
                cbx.SelectedIndex = 0;
        }


        #endregion


        public static bool isReferred(MasterDataType type, string id)
        {
            string sql = string.Empty;

            switch (type)
            {
                case MasterDataType.project:
                    sql = "select isnull(count(SubscribeID),0) from [SubscribeMain] where ProjectID = " + id;
                    break;
                case MasterDataType.item:
                    sql = "select isnull(count(SubscribeID),0) from [SubscribeDetail] where ItemID = " + id;
                    break;
                case MasterDataType.customer:
                    sql = "select isnull(count(SubscribeID),0) from [SubscribeMain] where CustomerID = " + id;
                    break;
                case MasterDataType.sales:
                    sql = "select isnull(count(SubscribeID),0) from [SubscribeMain] where SalesID = " + id;
                    break;
            }

            if (int.Parse(SqlHelper.ExecuteScalar(sql).ToString()) > 0)
            {
                return true;
            }

            return false;
        }

    }

    public enum MasterDataType
    {
        project,item,customer,sales
    }

    //初始化下拉框组件数据,区分用途。
    public enum ComboBoxType
    {
        input = 0,    //用于录入
        search = 1    //用于查询－添加 "全部" 记录，用于查询
    }
}
