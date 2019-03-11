namespace Commission.MenuForms
{
    partial class FrmReSettle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_Settle = new System.Windows.Forms.Button();
            this.dataGridView_Settlement = new System.Windows.Forms.DataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Export = new System.Windows.Forms.ToolStripButton();
            this.ColContractID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBuilding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSubscribeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColContractDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBottomPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColReceiptAll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCommissionAll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPremiumAll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalAll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCommissionSettleAll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPremiumSettleAll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUpSettleAll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSettleALL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSettleDifference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Settlement)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.panel1.Size = new System.Drawing.Size(1206, 62);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_Exit);
            this.groupBox1.Controls.Add(this.button_Settle);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1200, 54);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "结算信息";
            // 
            // button_Exit
            // 
            this.button_Exit.Image = global::Commission.Properties.Resources.exit;
            this.button_Exit.Location = new System.Drawing.Point(87, 20);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(75, 27);
            this.button_Exit.TabIndex = 17;
            this.button_Exit.Text = " 关闭";
            this.button_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_Settle
            // 
            this.button_Settle.Image = global::Commission.Properties.Resources.calc;
            this.button_Settle.Location = new System.Drawing.Point(6, 20);
            this.button_Settle.Name = "button_Settle";
            this.button_Settle.Size = new System.Drawing.Size(75, 27);
            this.button_Settle.TabIndex = 1;
            this.button_Settle.Text = " 结算";
            this.button_Settle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Settle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Settle.UseVisualStyleBackColor = true;
            this.button_Settle.Click += new System.EventHandler(this.button_Settle_Click);
            // 
            // dataGridView_Settlement
            // 
            this.dataGridView_Settlement.AllowUserToAddRows = false;
            this.dataGridView_Settlement.AllowUserToDeleteRows = false;
            this.dataGridView_Settlement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView_Settlement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Settlement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColContractID,
            this.ColCusName,
            this.ColBuilding,
            this.ColUnit,
            this.ColNum,
            this.ColItemTypeName,
            this.ColSubscribeDate,
            this.ColContractDate,
            this.ColArea,
            this.ColPrice,
            this.ColAmount,
            this.ColTotalAmount,
            this.ColBottomPrice,
            this.ColReceiptAll,
            this.ColCommissionAll,
            this.ColPremiumAll,
            this.ColTotalAll,
            this.ColCommissionSettleAll,
            this.ColPremiumSettleAll,
            this.ColUpSettleAll,
            this.ColSettleALL,
            this.ColSettleDifference});
            this.dataGridView_Settlement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Settlement.Location = new System.Drawing.Point(0, 93);
            this.dataGridView_Settlement.Name = "dataGridView_Settlement";
            this.dataGridView_Settlement.ReadOnly = true;
            this.dataGridView_Settlement.RowHeadersWidth = 21;
            this.dataGridView_Settlement.RowTemplate.Height = 23;
            this.dataGridView_Settlement.Size = new System.Drawing.Size(1206, 331);
            this.dataGridView_Settlement.TabIndex = 5;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Save,
            this.toolStripSeparator1,
            this.toolStripButton_Export});
            this.toolStrip2.Location = new System.Drawing.Point(0, 62);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1206, 31);
            this.toolStrip2.TabIndex = 4;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton_Save
            // 
            this.toolStripButton_Save.Image = global::Commission.Properties.Resources.save_24;
            this.toolStripButton_Save.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Save.Name = "toolStripButton_Save";
            this.toolStripButton_Save.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_Save.Text = "保存";
            this.toolStripButton_Save.Click += new System.EventHandler(this.toolStripButton_Save_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButton_Export
            // 
            this.toolStripButton_Export.Image = global::Commission.Properties.Resources.excel;
            this.toolStripButton_Export.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Export.Name = "toolStripButton_Export";
            this.toolStripButton_Export.Size = new System.Drawing.Size(52, 28);
            this.toolStripButton_Export.Text = "导出";
            this.toolStripButton_Export.Click += new System.EventHandler(this.toolStripButton_Export_Click);
            // 
            // ColContractID
            // 
            this.ColContractID.DataPropertyName = "ContractID";
            this.ColContractID.Frozen = true;
            this.ColContractID.HeaderText = "合同ID";
            this.ColContractID.Name = "ColContractID";
            this.ColContractID.ReadOnly = true;
            this.ColContractID.Visible = false;
            this.ColContractID.Width = 66;
            // 
            // ColCusName
            // 
            this.ColCusName.DataPropertyName = "CustomerName";
            this.ColCusName.Frozen = true;
            this.ColCusName.HeaderText = "客户";
            this.ColCusName.Name = "ColCusName";
            this.ColCusName.ReadOnly = true;
            this.ColCusName.Width = 54;
            // 
            // ColBuilding
            // 
            this.ColBuilding.DataPropertyName = "Building";
            this.ColBuilding.Frozen = true;
            this.ColBuilding.HeaderText = "楼号";
            this.ColBuilding.Name = "ColBuilding";
            this.ColBuilding.ReadOnly = true;
            this.ColBuilding.Width = 54;
            // 
            // ColUnit
            // 
            this.ColUnit.DataPropertyName = "Unit";
            this.ColUnit.Frozen = true;
            this.ColUnit.HeaderText = "单元";
            this.ColUnit.Name = "ColUnit";
            this.ColUnit.ReadOnly = true;
            this.ColUnit.Width = 54;
            // 
            // ColNum
            // 
            this.ColNum.DataPropertyName = "ItemNum";
            this.ColNum.Frozen = true;
            this.ColNum.HeaderText = "房号";
            this.ColNum.Name = "ColNum";
            this.ColNum.ReadOnly = true;
            this.ColNum.Width = 54;
            // 
            // ColItemTypeName
            // 
            this.ColItemTypeName.DataPropertyName = "ItemTypeName";
            this.ColItemTypeName.HeaderText = "房源类型";
            this.ColItemTypeName.Name = "ColItemTypeName";
            this.ColItemTypeName.ReadOnly = true;
            this.ColItemTypeName.Width = 78;
            // 
            // ColSubscribeDate
            // 
            this.ColSubscribeDate.DataPropertyName = "SubscribeDate";
            this.ColSubscribeDate.HeaderText = "认购日期";
            this.ColSubscribeDate.Name = "ColSubscribeDate";
            this.ColSubscribeDate.ReadOnly = true;
            this.ColSubscribeDate.Width = 78;
            // 
            // ColContractDate
            // 
            this.ColContractDate.DataPropertyName = "ContractDate";
            this.ColContractDate.HeaderText = "签约日期";
            this.ColContractDate.Name = "ColContractDate";
            this.ColContractDate.ReadOnly = true;
            this.ColContractDate.Width = 78;
            // 
            // ColArea
            // 
            this.ColArea.DataPropertyName = "Area";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "F2";
            this.ColArea.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColArea.HeaderText = "签约面积";
            this.ColArea.Name = "ColArea";
            this.ColArea.ReadOnly = true;
            this.ColArea.Width = 78;
            // 
            // ColPrice
            // 
            this.ColPrice.DataPropertyName = "Price";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "F0";
            this.ColPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColPrice.HeaderText = "签约单价";
            this.ColPrice.Name = "ColPrice";
            this.ColPrice.ReadOnly = true;
            this.ColPrice.Width = 78;
            // 
            // ColAmount
            // 
            this.ColAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "F0";
            this.ColAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColAmount.HeaderText = "签约金额";
            this.ColAmount.Name = "ColAmount";
            this.ColAmount.ReadOnly = true;
            this.ColAmount.Width = 78;
            // 
            // ColTotalAmount
            // 
            this.ColTotalAmount.DataPropertyName = "TotalAmount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "F0";
            this.ColTotalAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColTotalAmount.HeaderText = "签约总额";
            this.ColTotalAmount.Name = "ColTotalAmount";
            this.ColTotalAmount.ReadOnly = true;
            this.ColTotalAmount.Width = 78;
            // 
            // ColBottomPrice
            // 
            this.ColBottomPrice.DataPropertyName = "BottomPrice";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "F0";
            this.ColBottomPrice.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColBottomPrice.HeaderText = "销售底价";
            this.ColBottomPrice.Name = "ColBottomPrice";
            this.ColBottomPrice.ReadOnly = true;
            this.ColBottomPrice.Width = 78;
            // 
            // ColReceiptAll
            // 
            this.ColReceiptAll.DataPropertyName = "ReceiptAll";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "F0";
            this.ColReceiptAll.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColReceiptAll.HeaderText = "累计收款";
            this.ColReceiptAll.Name = "ColReceiptAll";
            this.ColReceiptAll.ReadOnly = true;
            this.ColReceiptAll.Width = 78;
            // 
            // ColCommissionAll
            // 
            this.ColCommissionAll.DataPropertyName = "CommissionAll";
            this.ColCommissionAll.HeaderText = "应结佣金";
            this.ColCommissionAll.Name = "ColCommissionAll";
            this.ColCommissionAll.ReadOnly = true;
            this.ColCommissionAll.Width = 78;
            // 
            // ColPremiumAll
            // 
            this.ColPremiumAll.DataPropertyName = "PremiumAll";
            this.ColPremiumAll.HeaderText = "应结溢价";
            this.ColPremiumAll.Name = "ColPremiumAll";
            this.ColPremiumAll.ReadOnly = true;
            this.ColPremiumAll.Width = 78;
            // 
            // ColTotalAll
            // 
            this.ColTotalAll.DataPropertyName = "TotalAll";
            this.ColTotalAll.HeaderText = "应结总额";
            this.ColTotalAll.Name = "ColTotalAll";
            this.ColTotalAll.ReadOnly = true;
            this.ColTotalAll.Width = 78;
            // 
            // ColCommissionSettleAll
            // 
            this.ColCommissionSettleAll.DataPropertyName = "CommissionSettleAll";
            this.ColCommissionSettleAll.HeaderText = "已结佣金";
            this.ColCommissionSettleAll.Name = "ColCommissionSettleAll";
            this.ColCommissionSettleAll.ReadOnly = true;
            this.ColCommissionSettleAll.Width = 78;
            // 
            // ColPremiumSettleAll
            // 
            this.ColPremiumSettleAll.DataPropertyName = "PremiumSettleAll";
            this.ColPremiumSettleAll.HeaderText = "已结溢价";
            this.ColPremiumSettleAll.Name = "ColPremiumSettleAll";
            this.ColPremiumSettleAll.ReadOnly = true;
            this.ColPremiumSettleAll.Width = 78;
            // 
            // ColUpSettleAll
            // 
            this.ColUpSettleAll.DataPropertyName = "UpSettleAll";
            this.ColUpSettleAll.HeaderText = "已结跳点";
            this.ColUpSettleAll.Name = "ColUpSettleAll";
            this.ColUpSettleAll.ReadOnly = true;
            this.ColUpSettleAll.Width = 78;
            // 
            // ColSettleALL
            // 
            this.ColSettleALL.DataPropertyName = "SettleAll";
            this.ColSettleALL.HeaderText = "已结总额";
            this.ColSettleALL.Name = "ColSettleALL";
            this.ColSettleALL.ReadOnly = true;
            this.ColSettleALL.Width = 78;
            // 
            // ColSettleDifference
            // 
            this.ColSettleDifference.DataPropertyName = "SettleDifference";
            this.ColSettleDifference.HeaderText = "结算差异";
            this.ColSettleDifference.Name = "ColSettleDifference";
            this.ColSettleDifference.ReadOnly = true;
            this.ColSettleDifference.Width = 78;
            // 
            // FrmReSettle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 424);
            this.Controls.Add(this.dataGridView_Settlement);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmReSettle";
            this.Text = "确权重算";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Settlement)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Settle;
        private System.Windows.Forms.DataGridView dataGridView_Settlement;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Export;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColContractID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBuilding;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSubscribeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColContractDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBottomPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColReceiptAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCommissionAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPremiumAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCommissionSettleAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPremiumSettleAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUpSettleAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSettleALL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSettleDifference;


    }
}