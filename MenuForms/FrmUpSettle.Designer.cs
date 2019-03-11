namespace Commission.MenuForms
{
    partial class FrmUpSettle
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView_Settlement = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_ClosingDate = new System.Windows.Forms.TextBox();
            this.textBox_Period = new System.Windows.Forms.TextBox();
            this.dateTimePicker_ClosingDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker_SettlePeriod = new System.Windows.Forms.DateTimePicker();
            this.button_Exit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button_SettleUp = new System.Windows.Forms.Button();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Exp2XLS = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Upgrade = new System.Windows.Forms.ComboBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Settlement)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.dataGridView_Settlement.Size = new System.Drawing.Size(1092, 321);
            this.dataGridView_Settlement.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_Upgrade);
            this.groupBox1.Controls.Add(this.textBox_ClosingDate);
            this.groupBox1.Controls.Add(this.textBox_Period);
            this.groupBox1.Controls.Add(this.dateTimePicker_ClosingDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePicker_SettlePeriod);
            this.groupBox1.Controls.Add(this.button_Exit);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button_SettleUp);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1086, 54);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "跳点结算信息";
            // 
            // textBox_ClosingDate
            // 
            this.textBox_ClosingDate.Location = new System.Drawing.Point(776, 18);
            this.textBox_ClosingDate.Name = "textBox_ClosingDate";
            this.textBox_ClosingDate.ReadOnly = true;
            this.textBox_ClosingDate.Size = new System.Drawing.Size(48, 21);
            this.textBox_ClosingDate.TabIndex = 21;
            this.textBox_ClosingDate.Visible = false;
            // 
            // textBox_Period
            // 
            this.textBox_Period.Location = new System.Drawing.Point(685, 18);
            this.textBox_Period.Name = "textBox_Period";
            this.textBox_Period.ReadOnly = true;
            this.textBox_Period.Size = new System.Drawing.Size(65, 21);
            this.textBox_Period.TabIndex = 21;
            this.textBox_Period.Visible = false;
            // 
            // dateTimePicker_ClosingDate
            // 
            this.dateTimePicker_ClosingDate.CustomFormat = "dd";
            this.dateTimePicker_ClosingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_ClosingDate.Location = new System.Drawing.Point(430, 23);
            this.dateTimePicker_ClosingDate.Name = "dateTimePicker_ClosingDate";
            this.dateTimePicker_ClosingDate.ShowUpDown = true;
            this.dateTimePicker_ClosingDate.Size = new System.Drawing.Size(48, 21);
            this.dateTimePicker_ClosingDate.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(371, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "截止日期";
            // 
            // dateTimePicker_SettlePeriod
            // 
            this.dateTimePicker_SettlePeriod.CustomFormat = "yyyy-MM";
            this.dateTimePicker_SettlePeriod.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_SettlePeriod.Location = new System.Drawing.Point(297, 23);
            this.dateTimePicker_SettlePeriod.Name = "dateTimePicker_SettlePeriod";
            this.dateTimePicker_SettlePeriod.ShowUpDown = true;
            this.dateTimePicker_SettlePeriod.Size = new System.Drawing.Size(68, 21);
            this.dateTimePicker_SettlePeriod.TabIndex = 18;
            this.dateTimePicker_SettlePeriod.ValueChanged += new System.EventHandler(this.dateTimePicker_ContractDate_ValueChanged);
            // 
            // button_Exit
            // 
            this.button_Exit.Image = global::Commission.Properties.Resources.exit;
            this.button_Exit.Location = new System.Drawing.Point(591, 20);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(75, 27);
            this.button_Exit.TabIndex = 17;
            this.button_Exit.Text = " 关闭";
            this.button_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "结算期间";
            // 
            // button_SettleUp
            // 
            this.button_SettleUp.Image = global::Commission.Properties.Resources.calc;
            this.button_SettleUp.Location = new System.Drawing.Point(494, 20);
            this.button_SettleUp.Name = "button_SettleUp";
            this.button_SettleUp.Size = new System.Drawing.Size(91, 27);
            this.button_SettleUp.TabIndex = 1;
            this.button_SettleUp.Text = " 跳点结算";
            this.button_SettleUp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_SettleUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_SettleUp.UseVisualStyleBackColor = true;
            this.button_SettleUp.Click += new System.EventHandler(this.button_SettleUp_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Add,
            this.toolStripSeparator1,
            this.toolStripButton_Exp2XLS});
            this.toolStrip2.Location = new System.Drawing.Point(0, 62);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1092, 31);
            this.toolStrip2.TabIndex = 5;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton_Add
            // 
            this.toolStripButton_Add.Image = global::Commission.Properties.Resources.save_24;
            this.toolStripButton_Add.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Add.Name = "toolStripButton_Add";
            this.toolStripButton_Add.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_Add.Text = "保存";
            this.toolStripButton_Add.Click += new System.EventHandler(this.toolStripButton_Add_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButton_Exp2XLS
            // 
            this.toolStripButton_Exp2XLS.Image = global::Commission.Properties.Resources.excel;
            this.toolStripButton_Exp2XLS.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Exp2XLS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Exp2XLS.Name = "toolStripButton_Exp2XLS";
            this.toolStripButton_Exp2XLS.Size = new System.Drawing.Size(52, 28);
            this.toolStripButton_Exp2XLS.Text = "导出";
            this.toolStripButton_Exp2XLS.Click += new System.EventHandler(this.toolStripButton_Exp2XLS_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.panel1.Size = new System.Drawing.Size(1092, 62);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "跳点方案";
            // 
            // comboBox_Upgrade
            // 
            this.comboBox_Upgrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Upgrade.FormattingEnabled = true;
            this.comboBox_Upgrade.Location = new System.Drawing.Point(69, 23);
            this.comboBox_Upgrade.Name = "comboBox_Upgrade";
            this.comboBox_Upgrade.Size = new System.Drawing.Size(163, 20);
            this.comboBox_Upgrade.TabIndex = 22;
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "F2";
            this.ColArea.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColArea.HeaderText = "签约面积";
            this.ColArea.Name = "ColArea";
            this.ColArea.ReadOnly = true;
            this.ColArea.Width = 78;
            // 
            // ColPrice
            // 
            this.ColPrice.DataPropertyName = "Price";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "F0";
            this.ColPrice.DefaultCellStyle = dataGridViewCellStyle10;
            this.ColPrice.HeaderText = "签约单价";
            this.ColPrice.Name = "ColPrice";
            this.ColPrice.ReadOnly = true;
            this.ColPrice.Width = 78;
            // 
            // ColAmount
            // 
            this.ColAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "F0";
            this.ColAmount.DefaultCellStyle = dataGridViewCellStyle11;
            this.ColAmount.HeaderText = "签约金额";
            this.ColAmount.Name = "ColAmount";
            this.ColAmount.ReadOnly = true;
            this.ColAmount.Width = 78;
            // 
            // ColTotalAmount
            // 
            this.ColTotalAmount.DataPropertyName = "TotalAmount";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "F0";
            this.ColTotalAmount.DefaultCellStyle = dataGridViewCellStyle12;
            this.ColTotalAmount.HeaderText = "签约总额";
            this.ColTotalAmount.Name = "ColTotalAmount";
            this.ColTotalAmount.ReadOnly = true;
            this.ColTotalAmount.Width = 78;
            // 
            // ColReceiptAll
            // 
            this.ColReceiptAll.DataPropertyName = "ReceiptAll";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "F0";
            dataGridViewCellStyle13.NullValue = "0";
            this.ColReceiptAll.DefaultCellStyle = dataGridViewCellStyle13;
            this.ColReceiptAll.HeaderText = "累计收款";
            this.ColReceiptAll.Name = "ColReceiptAll";
            this.ColReceiptAll.ReadOnly = true;
            this.ColReceiptAll.Width = 78;
            // 
            // ColBaseRate
            // 
            this.ColBaseRate.DataPropertyName = "BaseRate";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "F2";
            dataGridViewCellStyle14.NullValue = "0";
            dataGridViewCellStyle14.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ColBaseRate.DefaultCellStyle = dataGridViewCellStyle14;
            this.ColBaseRate.HeaderText = "提点(%)";
            this.ColBaseRate.Name = "ColBaseRate";
            this.ColBaseRate.ReadOnly = true;
            this.ColBaseRate.Width = 72;
            // 
            // ColUpRate
            // 
            this.ColUpRate.DataPropertyName = "UpRate";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "F2";
            dataGridViewCellStyle15.NullValue = "0";
            this.ColUpRate.DefaultCellStyle = dataGridViewCellStyle15;
            this.ColUpRate.HeaderText = "跳点(%)";
            this.ColUpRate.Name = "ColUpRate";
            this.ColUpRate.ReadOnly = true;
            this.ColUpRate.Width = 72;
            // 
            // ColSettleAmount
            // 
            this.ColSettleAmount.DataPropertyName = "SettleAmount";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "F0";
            dataGridViewCellStyle16.NullValue = "0";
            dataGridViewCellStyle16.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ColSettleAmount.DefaultCellStyle = dataGridViewCellStyle16;
            this.ColSettleAmount.HeaderText = "当期应结";
            this.ColSettleAmount.Name = "ColSettleAmount";
            this.ColSettleAmount.ReadOnly = true;
            this.ColSettleAmount.Width = 78;
            // 
            // FrmUpSettle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 414);
            this.Controls.Add(this.dataGridView_Settlement);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmUpSettle";
            this.Text = "跳点结算";
            this.Load += new System.EventHandler(this.FrmUpSettle_Load);
            this.Shown += new System.EventHandler(this.FrmUpSettle_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Settlement)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_SettleUp;
        private System.Windows.Forms.ToolStripButton toolStripButton_Exp2XLS;
        private System.Windows.Forms.ToolStripButton toolStripButton_Add;
        private System.Windows.Forms.DataGridView dataGridView_Settlement;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_SettlePeriod;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ClosingDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_ClosingDate;
        private System.Windows.Forms.TextBox textBox_Period;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Upgrade;
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