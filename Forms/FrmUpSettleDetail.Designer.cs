namespace Commission.Forms
{
    partial class FrmUpSettleDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripButton_Del = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Export = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_Checker = new System.Windows.Forms.Label();
            this.label_TableMaker = new System.Windows.Forms.Label();
            this.label_Date = new System.Windows.Forms.Label();
            this.label_Period = new System.Windows.Forms.Label();
            this.label_TableName = new System.Windows.Forms.Label();
            this.label_ProjectName = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripButton_Check = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.dataGridView_Settlement = new System.Windows.Forms.DataGridView();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUpSettleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColContractID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBuilding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSubscribeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColContractDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColReceiptAll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBaseRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUpRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSettleAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Settlement)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripButton_Del
            // 
            this.toolStripButton_Del.Image = global::Commission.Properties.Resources.file_del;
            this.toolStripButton_Del.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Del.Name = "toolStripButton_Del";
            this.toolStripButton_Del.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_Del.Text = "删除";
            this.toolStripButton_Del.ToolTipText = "删除当前选定记录";
            this.toolStripButton_Del.Visible = false;
            this.toolStripButton_Del.Click += new System.EventHandler(this.toolStripButton_Del_Click);
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
            // toolStripButton_Close
            // 
            this.toolStripButton_Close.Image = global::Commission.Properties.Resources.exit_24;
            this.toolStripButton_Close.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Close.Name = "toolStripButton_Close";
            this.toolStripButton_Close.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_Close.Text = "关闭";
            this.toolStripButton_Close.Click += new System.EventHandler(this.toolStripButton_Close_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label_Checker);
            this.panel1.Controls.Add(this.label_TableMaker);
            this.panel1.Controls.Add(this.label_Date);
            this.panel1.Controls.Add(this.label_Period);
            this.panel1.Controls.Add(this.label_TableName);
            this.panel1.Controls.Add(this.label_ProjectName);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 62);
            this.panel1.TabIndex = 11;
            // 
            // label_Checker
            // 
            this.label_Checker.AutoSize = true;
            this.label_Checker.Font = new System.Drawing.Font("宋体", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Checker.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Checker.Location = new System.Drawing.Point(577, 36);
            this.label_Checker.Name = "label_Checker";
            this.label_Checker.Size = new System.Drawing.Size(44, 12);
            this.label_Checker.TabIndex = 0;
            this.label_Checker.Text = "审核人";
            // 
            // label_TableMaker
            // 
            this.label_TableMaker.AutoSize = true;
            this.label_TableMaker.Font = new System.Drawing.Font("宋体", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_TableMaker.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_TableMaker.Location = new System.Drawing.Point(390, 36);
            this.label_TableMaker.Name = "label_TableMaker";
            this.label_TableMaker.Size = new System.Drawing.Size(57, 12);
            this.label_TableMaker.TabIndex = 0;
            this.label_TableMaker.Text = "报表名称";
            // 
            // label_Date
            // 
            this.label_Date.AutoSize = true;
            this.label_Date.Font = new System.Drawing.Font("宋体", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Date.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Date.Location = new System.Drawing.Point(231, 36);
            this.label_Date.Name = "label_Date";
            this.label_Date.Size = new System.Drawing.Size(57, 12);
            this.label_Date.TabIndex = 0;
            this.label_Date.Text = "报表名称";
            // 
            // label_Period
            // 
            this.label_Period.AutoSize = true;
            this.label_Period.Font = new System.Drawing.Font("宋体", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Period.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Period.Location = new System.Drawing.Point(72, 36);
            this.label_Period.Name = "label_Period";
            this.label_Period.Size = new System.Drawing.Size(57, 12);
            this.label_Period.TabIndex = 0;
            this.label_Period.Text = "报表名称";
            // 
            // label_TableName
            // 
            this.label_TableName.AutoSize = true;
            this.label_TableName.Font = new System.Drawing.Font("宋体", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_TableName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_TableName.Location = new System.Drawing.Point(390, 13);
            this.label_TableName.Name = "label_TableName";
            this.label_TableName.Size = new System.Drawing.Size(71, 12);
            this.label_TableName.TabIndex = 0;
            this.label_TableName.Text = "报表名称  ";
            // 
            // label_ProjectName
            // 
            this.label_ProjectName.Font = new System.Drawing.Font("宋体", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_ProjectName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_ProjectName.Location = new System.Drawing.Point(72, 13);
            this.label_ProjectName.Name = "label_ProjectName";
            this.label_ProjectName.Size = new System.Drawing.Size(187, 12);
            this.label_ProjectName.TabIndex = 0;
            this.label_ProjectName.Text = "报表名称   ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(518, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "审核人";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(331, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "制表人";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(172, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "结算时间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "结算期间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(331, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "报表名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "项目名称";
            // 
            // toolStripButton_Check
            // 
            this.toolStripButton_Check.Image = global::Commission.Properties.Resources.checkmark_24;
            this.toolStripButton_Check.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Check.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Check.Name = "toolStripButton_Check";
            this.toolStripButton_Check.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_Check.Text = "审核";
            this.toolStripButton_Check.Click += new System.EventHandler(this.toolStripButton_Check_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Del,
            this.toolStripButton_Export,
            this.toolStripSeparator1,
            this.toolStripButton_Check,
            this.toolStripSeparator2,
            this.toolStripButton_Close});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(950, 31);
            this.toolStrip2.TabIndex = 10;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // dataGridView_Settlement
            // 
            this.dataGridView_Settlement.AllowUserToAddRows = false;
            this.dataGridView_Settlement.AllowUserToDeleteRows = false;
            this.dataGridView_Settlement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView_Settlement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Settlement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColUpSettleID,
            this.ColContractID,
            this.ColCusName,
            this.ColBuilding,
            this.ColUnit,
            this.ColNum,
            this.ColSubscribeDate,
            this.ColContractDate,
            this.ColArea,
            this.ColPrice,
            this.ColAmount,
            this.ColTotalAmount,
            this.ColReceiptAll,
            this.ColBaseRate,
            this.ColUpRate,
            this.ColSettleAmount});
            this.dataGridView_Settlement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Settlement.Location = new System.Drawing.Point(0, 93);
            this.dataGridView_Settlement.Name = "dataGridView_Settlement";
            this.dataGridView_Settlement.ReadOnly = true;
            this.dataGridView_Settlement.RowHeadersWidth = 21;
            this.dataGridView_Settlement.RowTemplate.Height = 23;
            this.dataGridView_Settlement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Settlement.Size = new System.Drawing.Size(950, 398);
            this.dataGridView_Settlement.TabIndex = 12;
            // 
            // ColID
            // 
            this.ColID.DataPropertyName = "ID";
            this.ColID.Frozen = true;
            this.ColID.HeaderText = "ID";
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            this.ColID.Visible = false;
            this.ColID.Width = 42;
            // 
            // ColUpSettleID
            // 
            this.ColUpSettleID.DataPropertyName = "UpSettleID";
            this.ColUpSettleID.Frozen = true;
            this.ColUpSettleID.HeaderText = "UpSettleID";
            this.ColUpSettleID.Name = "ColUpSettleID";
            this.ColUpSettleID.ReadOnly = true;
            this.ColUpSettleID.Visible = false;
            this.ColUpSettleID.Width = 90;
            // 
            // ColContractID
            // 
            this.ColContractID.DataPropertyName = "ContractID";
            this.ColContractID.Frozen = true;
            this.ColContractID.HeaderText = "ContractID";
            this.ColContractID.Name = "ColContractID";
            this.ColContractID.ReadOnly = true;
            this.ColContractID.Visible = false;
            this.ColContractID.Width = 90;
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
            // ColReceiptAll
            // 
            this.ColReceiptAll.DataPropertyName = "ReceiptAll";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "F0";
            dataGridViewCellStyle5.NullValue = "0";
            this.ColReceiptAll.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColReceiptAll.HeaderText = "累计收款";
            this.ColReceiptAll.Name = "ColReceiptAll";
            this.ColReceiptAll.ReadOnly = true;
            this.ColReceiptAll.Width = 78;
            // 
            // ColBaseRate
            // 
            this.ColBaseRate.DataPropertyName = "BaseRate";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "F2";
            dataGridViewCellStyle6.NullValue = "0";
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ColBaseRate.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColBaseRate.HeaderText = "提点(%)";
            this.ColBaseRate.Name = "ColBaseRate";
            this.ColBaseRate.ReadOnly = true;
            this.ColBaseRate.Width = 72;
            // 
            // ColUpRate
            // 
            this.ColUpRate.DataPropertyName = "UpRate";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "F2";
            dataGridViewCellStyle7.NullValue = "0";
            this.ColUpRate.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColUpRate.HeaderText = "跳点(%)";
            this.ColUpRate.Name = "ColUpRate";
            this.ColUpRate.ReadOnly = true;
            this.ColUpRate.Width = 72;
            // 
            // ColSettleAmount
            // 
            this.ColSettleAmount.DataPropertyName = "SettleAmount";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "F0";
            dataGridViewCellStyle8.NullValue = "0";
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ColSettleAmount.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColSettleAmount.HeaderText = "当期应结";
            this.ColSettleAmount.Name = "ColSettleAmount";
            this.ColSettleAmount.ReadOnly = true;
            this.ColSettleAmount.Width = 78;
            // 
            // FrmUpSettleDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 491);
            this.Controls.Add(this.dataGridView_Settlement);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip2);
            this.Name = "FrmUpSettleDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "跳点报表明细";
            this.Load += new System.EventHandler(this.FrmUpSettleDetail_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Settlement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton toolStripButton_Del;
        private System.Windows.Forms.ToolStripButton toolStripButton_Export;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Checker;
        private System.Windows.Forms.Label label_TableMaker;
        private System.Windows.Forms.Label label_Date;
        private System.Windows.Forms.Label label_Period;
        private System.Windows.Forms.Label label_TableName;
        private System.Windows.Forms.Label label_ProjectName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Check;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.DataGridView dataGridView_Settlement;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUpSettleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColContractID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBuilding;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSubscribeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColContractDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColReceiptAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBaseRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUpRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSettleAmount;
    }
}