using Commission.Business;
using Commission.Forms;
using Commission.MenuForms;
using Commission.Report;
using Commission.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Commission
{
    public partial class FrmMain : Form
    {
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public FrmMain()
        {
            InitializeComponent();
            InitParameters();
        }

        private void InitParameters()
        {
            Login.Parameters.FmtAmount = "F0";
            Login.Parameters.FmtPrice = "F4";
            Login.Parameters.FmtArea = "F2";
            Login.Parameters.PrecisionArea = 2;
            Login.Parameters.PrecisionPrice = 4;
            Login.Parameters.PrecisionAmount = 0;
        }


        private void Exit_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
 
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Prompt.Question("确认要退出系统？") != System.Windows.Forms.DialogResult.Yes)
                e.Cancel = true;
        }


        //private void setCurrBtnColor(object sender)
        //{
        //    if (sender is ToolStripButton)
        //    {
        //        foreach (ToolStripItem vItem in toolStrip1.Items)
        //        {
        //            if (vItem is ToolStripButton)
        //            {
        //                if (vItem.Name == ((ToolStripButton)sender).Name)
        //                    ((ToolStripButton)vItem).BackColor = System.Drawing.SystemColors.ControlDark;
        //                else
        //                    ((ToolStripButton)vItem).BackColor = System.Drawing.SystemColors.Control;
        //            }
        //        }
        //    }
        //}


        private void FrmMain_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                this.Text = "房地产销售佣金结算管理系统";
                toolStripStatusLabel_FormTitle.Text = "主窗口";

                foreach (ToolStripItem vItem in toolStrip_Main.Items)
                {
                    if (vItem is ToolStripButton)
                    {
                        ((ToolStripButton)vItem).BackColor = System.Drawing.SystemColors.Control;
                    }
                }

            }
            else
            {
                this.Text = "房地产销售佣金结算管理系统 - [ " + this.ActiveMdiChild.Text + " ]";
                toolStripStatusLabel_FormTitle.Text = this.ActiveMdiChild.Text;
            }
                
        }

        private void FormShow(Form form, object sender)
        {
            foreach (Form frm in this.MdiChildren) //遍历子窗口
            {
                //if (frm.Name == form.Name)
                //{
                //    frm.Activate();
                //    return;
                //}

                frm.Close();

            }

            if (sender is ToolStripButton)
            {
                ((ToolStripButton)sender).BackColor = System.Drawing.SystemColors.ControlDark;
            }
            

            form.MdiParent = this;
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.Dock = DockStyle.Fill;

            form.Show();
        }

        private void SaleItem_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSaleItem frmItem = new FrmSaleItem();
            FormShow(frmItem, sender);
        }

        private void Contract_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmContract frmContract = new FrmContract();
            FormShow(frmContract, sender);
        }

        private void Project_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProject project = new FrmProject();
            project.ShowDialog();
        }

        private void Receipt_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReceipt receipt = new FrmReceipt();
            FormShow(receipt, sender);
        }

        private void Change_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChange change = new FrmChange();
            FormShow(change, sender);
        }

        private void Commission_ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmSettlement settle = new FrmSettlement();
            FormShow(settle, sender);
        }

        private void Customer_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCustomer customer = new FrmCustomer();
            customer.ShowDialog();
        }

        private void Sales_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEmploye employe = new FrmEmploye();
            FormShow(employe, sender);


            //FrmSales sales = new FrmSales();
            //sales.ShowDialog();

        }

        private void Confirm_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConfirm confirm = new FrmConfirm();
            FormShow(confirm, sender);
        }

        private void Credit_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCredit credit = new FrmCredit();
            FormShow(credit, sender);
        }

        private void Subscribe_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSubscribe subscribe = new FrmSubscribe();
            FormShow(subscribe, sender);
        }

        private void ToolStripMenuItem_Parameter_Click(object sender, EventArgs e)
        {
            FrmConfig config = new FrmConfig();
            config.ShowDialog();
        }

        private void ToolStripMenuItem_User_Click(object sender, EventArgs e)
        {
            FrmUser user = new FrmUser();
            user.ShowDialog();
        }

        private void ToolStripMenuItem_Handover_Click(object sender, EventArgs e)
        {
            FrmHandover handover = new FrmHandover();
            FormShow(handover, sender);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel_User.Text = Login.User.UserName;
            toolStripStatusLabel_ProjectName.Text = Login.User.ProjectName;

            if (Login.User.UserType != Business.SysUserType.supermanager)
            {
                getAuthorize();
            }
            
        }

        private void getAuthorize()
        {
            //获取授权菜单项
            string sql = string.Format("select MenuName from Authorize where RoleID = {0}",Login.User.RoleID);
            DataTable dt = SqlHelper.ExecuteDataTable(sql);

            //获取缺省授权菜单项
            sql = string.Format("select MenuName from MenuList where IsDefault = 1");
            SqlDataReader sdr = SqlHelper.ExecuteReader(sql);

            while (sdr.Read())
            {
                dt.Rows.Add(sdr["MenuName"].ToString());
            }

            //遍历菜单设置授权
            traversalMenu(dt);

        }


        private void traversalMenu(DataTable dt)
        {
            foreach (ToolStripMenuItem mi in menuStrip_Main.Items)
            {
                string where = string.Format("MenuName = '{0}'", mi.Name.ToString());
                DataRow[] dr = dt.Select(where);
                if (dr.Length == 0)
                {
                    mi.Visible = false;
                    //continue; //需要设置对应工具栏按钮可视状态
                }

                traversalSubMenu(mi,dt);
            }
        }

        private void traversalSubMenu(ToolStripMenuItem mi, DataTable dt)
        {
            foreach (ToolStripItem submi in mi.DropDownItems)
            {
                if (submi is ToolStripMenuItem)
                {
                    string where = string.Format("MenuName = '{0}'", submi.Name.ToString());
                    DataRow[] dr = dt.Select(where);
                    if (dr.Length == 0)
                    {
                        
                        submi.Visible = false;

                        //对应按钮
                        if (submi.Tag != null)
                        {
                            string tsmName = submi.Tag.ToString();
                            ToolStripItem[] items = toolStrip_Main.Items.Find(tsmName, true);
                            if (items.Length > 0)
                                items[0].Visible = false;
                        }
                    }
                    //递归
                    traversalSubMenu((ToolStripMenuItem)submi, dt);
                }
            }
        }




        private void ToolStripMenuItem_ChangePwd_Click(object sender, EventArgs e)
        {
            FrmUserPwd pwd = new FrmUserPwd();
            pwd.ShowDialog();
        }

        private void ToolStripMenuItem_Import_Click(object sender, EventArgs e)
        {
            FrmItemImport itemImport = new FrmItemImport();
            itemImport.ShowDialog();
        }

        private void ToolStripMenuItem_Return_Click(object sender, EventArgs e)
        {
            RepReturn ret = new RepReturn();
            FormShow(ret, sender);
        }

        private void ToolStripMenuItem_ListReport_Click(object sender, EventArgs e)
        {
            RepList list = new RepList();
            FormShow(list, sender);
        }

        private void ToolStripMenuItem_ReceiptReport_Click(object sender, EventArgs e)
        {
            RepReceive receive = new RepReceive();
            FormShow(receive, sender);
        }

        private void toolStripMenuItem_Project_Click(object sender, EventArgs e)
        {
            FrmChangeProject project = new FrmChangeProject();

            if (project.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (Form frm in this.MdiChildren) //遍历已打开窗口
                {
                    frm.Close();
                }

                toolStripStatusLabel_ProjectName.Text = Login.User.ProjectName;
            }
        }

        private void SaleItemMng_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Resettle_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //确权重算
            FrmReSettle resettle = new FrmReSettle();
            FormShow(resettle, sender);

        }

        private void UpSettle_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUpSettle upSettle = new FrmUpSettle();
            FormShow(upSettle, sender);
        }

        private void BPImport_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBottomPriceImp bpImport = new FrmBottomPriceImp();
            bpImport.ShowDialog();
        }

        private void ToolStripMenuItem_Project_Click_1(object sender, EventArgs e)
        {
            FrmProject project = new FrmProject();
            project.ShowDialog();
        }

        private void ToolStripMenuItem_Role_Click(object sender, EventArgs e)
        {
            FrmRole role = new FrmRole();
            role.ShowDialog();
        }

        private void ToolStripMenuItem_PayMode_Click(object sender, EventArgs e)
        {
            FrmPaymentMode payMode = new FrmPaymentMode();
            payMode.ShowDialog();
        }

        private void ToolStripMenuItem_RateMng_Click(object sender, EventArgs e)
        {
            FrmRate rate = new FrmRate();
            rate.ShowDialog();
        }

        private void ToolStripMenuItem_UpMng_Click(object sender, EventArgs e)
        {
            FrmUpgrade upgrade = new FrmUpgrade();
            upgrade.ShowDialog();
        }

        private void ToolStripMenuItem_SettlePara_Click(object sender, EventArgs e)
        {
            FrmParameterSet frmParaSet = new FrmParameterSet();
            frmParaSet.ShowDialog();
        }

        private void ToolStripMenuItem_SettleMng_Click(object sender, EventArgs e)
        {
            FrmSaleItemMng frmItemSet = new FrmSaleItemMng();
            FormShow(frmItemSet, sender);
        }

        private void ToolStripMenuItem_MI_SettleVerify_Click(object sender, EventArgs e)
        {
            FrmSettleReport report = new FrmSettleReport();
            FormShow(report, sender);
        }

        private void ToolStripMenuItem_MI_UpVerify_Click(object sender, EventArgs e)
        {
            FrmUpSettleReport upsettle = new FrmUpSettleReport();
            FormShow(upsettle, sender);
        }

        private void ToolStripMenuItem_MI_ReSettleVerify_Click(object sender, EventArgs e)
        {
            FrmReSettleReport resettle = new FrmReSettleReport();
            FormShow(resettle, sender);
        }

        private void ToolStripMenuItem_NameChange_Click(object sender, EventArgs e)
        {
            FrmNameChange nameChange = new FrmNameChange();
            FormShow(nameChange, sender);
        }

        private void ToolStripMenuIte_Handover_Click(object sender, EventArgs e)
        {
            RepHandOver handover = new RepHandOver();
            FormShow(handover, sender);
        }

        private void ToolStripMenuItem_ItemType_Click(object sender, EventArgs e)
        {
            FrmItemTypeMng itemType = new FrmItemTypeMng();
            itemType.ShowDialog();
        }

        private void ToolStripMenuItem_ContractDate_Click(object sender, EventArgs e)
        {
            FrmContractDateMng contractDate = new FrmContractDateMng();
            contractDate.ShowDialog();
        }

        private void ToolStripMenuItem_ContractInterval_Click(object sender, EventArgs e)
        {
            RepInterval interval = new RepInterval();
            FormShow(interval, sender);
        }

        private void ToolStripMenuItem_BindSale_Click(object sender, EventArgs e)
        {
            RepBindSale bind = new RepBindSale();
            FormShow(bind, sender);
        }

        private void ToolStripMenuItem_SubscribeReturn_Click(object sender, EventArgs e)
        {
            RepSubscribeReturn subReturn = new RepSubscribeReturn();
            FormShow(subReturn, sender);
        }

        private void ToolStripMenuItem_Exchange_Click(object sender, EventArgs e)
        {
            RepItemExchange exchange = new RepItemExchange();
            FormShow(exchange, sender);
        }

        private void ToolStripMenuItem_SalesOwn_Click(object sender, EventArgs e)
        {
            AchSalesDetail salesOwn = new AchSalesDetail();
            salesOwn.AchieveType = PerformanceType.own;
            FormShow(salesOwn, sender);
        }

        private void ToolStripMenuItem_SalesAllot_Click(object sender, EventArgs e)
        {
            AchSalesDetail salesAllot = new AchSalesDetail();
            salesAllot.AchieveType = PerformanceType.allot;
            FormShow(salesAllot, sender);
        }

        private void ToolStripMenuItem_SalesHold_Click(object sender, EventArgs e)
        {
            AchSalesDetail salesHold = new AchSalesDetail();
            salesHold.AchieveType = PerformanceType.hold;
            FormShow(salesHold, sender);
        }

        private void ToolStripMenuItem_About_Click(object sender, EventArgs e)
        {
            FrmAbout about = new FrmAbout();
            about.ShowDialog();
        }

        private void ToolStripMenuItem_ImpCustomer_Click(object sender, EventArgs e)
        {
            FrmImpCustomer impCustomer = new FrmImpCustomer();
            impCustomer.ShowDialog();
        }

        private void ToolStripMenuItem_ImpSales_Click(object sender, EventArgs e)
        {
            FrmImpSales impSales = new FrmImpSales();
            impSales.ShowDialog();
        }

        private void toolStripButton_Temp_Click(object sender, EventArgs e)
        {
            AchSalesDetail salesOwn = new AchSalesDetail();
            FormShow(salesOwn, sender);
        }

        private void ToolStripMenuItem_ImpContract_Click(object sender, EventArgs e)
        {
            FrmImpContract impSubscribe = new FrmImpContract();
            FormShow(impSubscribe, sender);
            //impSubscribe.ShowDialog();
        }

        private void toolStripButton_CreateMenuList_Click(object sender, EventArgs e)
        {
            CreateMenuList();
        }
        /// <summary>
        /// 遍历菜单并生成写入数据的语句--手工添加默认项目
        /// </summary>
        private void CreateMenuList()
        {
            int id = 0;
            int pid = 0;
            foreach (ToolStripMenuItem con in this.MainMenuStrip.Items)
            {
                id++;
                pid = id;
                Console.WriteLine(string.Format("insert into menulist (id,MenuName,MenuText,ParentID) values ({0},'{1}','{2}',0)", id, con.Name.ToString(), con.Text.ToString()));
                foreach (ToolStripItem con2 in con.DropDownItems)
                {
                    if (con2 is ToolStripMenuItem)
                    {
                        id++;
                        Console.WriteLine(string.Format("insert into menulist (id,MenuName,MenuText,ParentID) values ({0},'{1}','{2}',{3})", id, con2.Name.ToString(), con2.Text.ToString(), pid));
                    }
                }
            }
            MessageBox.Show("OK");
        }

        private void ToolStripMenuItem_SubscribeDate_Click(object sender, EventArgs e)
        {
            FrmSubscribeDate subDate = new FrmSubscribeDate();
            subDate.ShowDialog();
        }

        private void ToolStripMenuItem_NoConfirm_Click(object sender, EventArgs e)
        {
            FrmConfirm confirm = new FrmConfirm();
            confirm.IsConfirm = false;
            FormShow(confirm, sender);
        }

        private void ToolStripMenuItem_organiz_Click(object sender, EventArgs e)
        {
            FrmOrganization organiz = new FrmOrganization();
            organiz.ShowDialog();
        }

        private void ToolStripMenuItem_DircetorOwn_Click(object sender, EventArgs e)
        {
            AchSalesDetail performance = new AchSalesDetail();
            performance.AchieveType = PerformanceType.own;
            performance.SalesType = "主管";
            FormShow(performance, sender);
        }

        private void ToolStripMenuItem_DircetorAllot_Click(object sender, EventArgs e)
        {
            AchSalesDetail performance = new AchSalesDetail();
            performance.AchieveType = PerformanceType.allot;
            performance.SalesType = "主管";
            FormShow(performance, sender);
        }

        private void ToolStripMenuItem_JobChangeRep_Click(object sender, EventArgs e)
        {
            FrmJobChangeRep frmJCRep = new FrmJobChangeRep();
            FormShow(frmJCRep, sender);
        }

        private void ToolStripMenuItem_PerformanceRate_Click(object sender, EventArgs e)
        {
            FrmPerformanceRate frmPR = new FrmPerformanceRate();
            frmPR.ShowDialog();
        }
    }
}
