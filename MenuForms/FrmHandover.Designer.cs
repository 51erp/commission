namespace Commission.MenuForms
{
    partial class FrmHandover
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_NewSalesName = new System.Windows.Forms.ComboBox();
            this.comboBox_type = new System.Windows.Forms.ComboBox();
            this.comboBox_Sales = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button_Handover = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_Search = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_Contract = new System.Windows.Forms.DataGridView();
            this.ColContractID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSubscribeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSaleItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColCustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCustomerPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBuilding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDownPayAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColContractDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSubscribeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSalesID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSalesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExtField0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExtField1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExtField2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExtField3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExtField4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExtField5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExtField6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExtField7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExtField8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExtField9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_All = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_None = new System.Windows.Forms.ToolStripButton();
            this.button_SalesMore = new System.Windows.Forms.Button();
            this.textBox_Sales = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Contract)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1162, 64);
            this.panel1.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_Sales);
            this.groupBox1.Controls.Add(this.button_SalesMore);
            this.groupBox1.Controls.Add(this.comboBox_NewSalesName);
            this.groupBox1.Controls.Add(this.comboBox_type);
            this.groupBox1.Controls.Add(this.comboBox_Sales);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.button_Handover);
            this.groupBox1.Controls.Add(this.button_Exit);
            this.groupBox1.Controls.Add(this.button_Search);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1156, 51);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // comboBox_NewSalesName
            // 
            this.comboBox_NewSalesName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_NewSalesName.FormattingEnabled = true;
            this.comboBox_NewSalesName.Location = new System.Drawing.Point(614, 23);
            this.comboBox_NewSalesName.Name = "comboBox_NewSalesName";
            this.comboBox_NewSalesName.Size = new System.Drawing.Size(115, 20);
            this.comboBox_NewSalesName.TabIndex = 62;
            // 
            // comboBox_type
            // 
            this.comboBox_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_type.FormattingEnabled = true;
            this.comboBox_type.Items.AddRange(new object[] {
            "认购",
            "签约"});
            this.comboBox_type.Location = new System.Drawing.Point(78, 23);
            this.comboBox_type.Name = "comboBox_type";
            this.comboBox_type.Size = new System.Drawing.Size(96, 20);
            this.comboBox_type.TabIndex = 62;
            // 
            // comboBox_Sales
            // 
            this.comboBox_Sales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Sales.FormattingEnabled = true;
            this.comboBox_Sales.Location = new System.Drawing.Point(1005, 23);
            this.comboBox_Sales.Name = "comboBox_Sales";
            this.comboBox_Sales.Size = new System.Drawing.Size(115, 20);
            this.comboBox_Sales.TabIndex = 62;
            this.comboBox_Sales.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(531, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 54;
            this.label2.Text = "接收置业顾问";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 54;
            this.label1.Text = "业务类型";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(195, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 54;
            this.label7.Text = "原置业顾问";
            // 
            // button_Handover
            // 
            this.button_Handover.Image = global::Commission.Properties.Resources.copy_161;
            this.button_Handover.Location = new System.Drawing.Point(735, 21);
            this.button_Handover.Name = "button_Handover";
            this.button_Handover.Size = new System.Drawing.Size(75, 24);
            this.button_Handover.TabIndex = 45;
            this.button_Handover.Text = " 交接";
            this.button_Handover.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Handover.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Handover.UseVisualStyleBackColor = true;
            this.button_Handover.Click += new System.EventHandler(this.button_Handover_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.Image = global::Commission.Properties.Resources.exit;
            this.button_Exit.Location = new System.Drawing.Point(867, 21);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(75, 24);
            this.button_Exit.TabIndex = 45;
            this.button_Exit.Text = " 关闭";
            this.button_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_Search
            // 
            this.button_Search.Image = global::Commission.Properties.Resources.Find_16;
            this.button_Search.Location = new System.Drawing.Point(431, 21);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(75, 24);
            this.button_Search.TabIndex = 44;
            this.button_Search.Text = " 查询";
            this.button_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1162, 440);
            this.panel2.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView_Contract);
            this.groupBox2.Controls.Add(this.toolStrip2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1162, 440);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "购房信息";
            // 
            // dataGridView_Contract
            // 
            this.dataGridView_Contract.AllowUserToAddRows = false;
            this.dataGridView_Contract.AllowUserToDeleteRows = false;
            this.dataGridView_Contract.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView_Contract.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Contract.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColContractID,
            this.ColSubscribeID,
            this.ColSaleItem,
            this.ColCheck,
            this.ColCustomerID,
            this.ColCustomerName,
            this.ColCustomerPhone,
            this.ColItemTypeName,
            this.ColBuilding,
            this.ColUnit,
            this.ColItemNum,
            this.ColArea,
            this.ColPrice,
            this.ColAmount,
            this.ColDownPayAmount,
            this.ColLoan,
            this.ColTotalAmount,
            this.ColContractDate,
            this.ColSubscribeDate,
            this.ColSalesID,
            this.ColSalesName,
            this.ColExtField0,
            this.ColExtField1,
            this.ColExtField2,
            this.ColExtField3,
            this.ColExtField4,
            this.ColExtField5,
            this.ColExtField6,
            this.ColExtField7,
            this.ColExtField8,
            this.ColExtField9});
            this.dataGridView_Contract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Contract.Location = new System.Drawing.Point(3, 48);
            this.dataGridView_Contract.Name = "dataGridView_Contract";
            this.dataGridView_Contract.RowHeadersWidth = 21;
            this.dataGridView_Contract.RowTemplate.Height = 23;
            this.dataGridView_Contract.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Contract.Size = new System.Drawing.Size(1156, 389);
            this.dataGridView_Contract.TabIndex = 12;
            // 
            // ColContractID
            // 
            this.ColContractID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColContractID.DataPropertyName = "ContractID";
            this.ColContractID.HeaderText = "ContractID";
            this.ColContractID.Name = "ColContractID";
            this.ColContractID.Visible = false;
            this.ColContractID.Width = 60;
            // 
            // ColSubscribeID
            // 
            this.ColSubscribeID.DataPropertyName = "SubscribeID";
            this.ColSubscribeID.HeaderText = "SubscribeID";
            this.ColSubscribeID.Name = "ColSubscribeID";
            this.ColSubscribeID.Visible = false;
            this.ColSubscribeID.Width = 96;
            // 
            // ColSaleItem
            // 
            this.ColSaleItem.HeaderText = "SaleItemID";
            this.ColSaleItem.Name = "ColSaleItem";
            this.ColSaleItem.Visible = false;
            this.ColSaleItem.Width = 90;
            // 
            // ColCheck
            // 
            this.ColCheck.DataPropertyName = "Choose";
            this.ColCheck.FalseValue = "false";
            this.ColCheck.HeaderText = "选择";
            this.ColCheck.Name = "ColCheck";
            this.ColCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColCheck.TrueValue = "true";
            this.ColCheck.Width = 54;
            // 
            // ColCustomerID
            // 
            this.ColCustomerID.DataPropertyName = "CustomerID";
            this.ColCustomerID.HeaderText = "CustomerID";
            this.ColCustomerID.Name = "ColCustomerID";
            this.ColCustomerID.Visible = false;
            this.ColCustomerID.Width = 90;
            // 
            // ColCustomerName
            // 
            this.ColCustomerName.DataPropertyName = "CustomerName";
            this.ColCustomerName.HeaderText = "客户名称";
            this.ColCustomerName.Name = "ColCustomerName";
            this.ColCustomerName.ReadOnly = true;
            this.ColCustomerName.Width = 78;
            // 
            // ColCustomerPhone
            // 
            this.ColCustomerPhone.DataPropertyName = "CustomerPhone";
            this.ColCustomerPhone.HeaderText = "客户电话";
            this.ColCustomerPhone.Name = "ColCustomerPhone";
            this.ColCustomerPhone.Width = 78;
            // 
            // ColItemTypeName
            // 
            this.ColItemTypeName.DataPropertyName = "ItemTypeName";
            this.ColItemTypeName.HeaderText = "房产类型";
            this.ColItemTypeName.Name = "ColItemTypeName";
            this.ColItemTypeName.Width = 78;
            // 
            // ColBuilding
            // 
            this.ColBuilding.DataPropertyName = "Building";
            this.ColBuilding.HeaderText = "楼/幢";
            this.ColBuilding.Name = "ColBuilding";
            this.ColBuilding.Width = 60;
            // 
            // ColUnit
            // 
            this.ColUnit.DataPropertyName = "Unit";
            this.ColUnit.HeaderText = "单元";
            this.ColUnit.Name = "ColUnit";
            this.ColUnit.Width = 54;
            // 
            // ColItemNum
            // 
            this.ColItemNum.DataPropertyName = "ItemNum";
            this.ColItemNum.HeaderText = "房号";
            this.ColItemNum.Name = "ColItemNum";
            this.ColItemNum.Width = 54;
            // 
            // ColArea
            // 
            this.ColArea.DataPropertyName = "Area";
            this.ColArea.HeaderText = "签约面积";
            this.ColArea.Name = "ColArea";
            this.ColArea.Width = 78;
            // 
            // ColPrice
            // 
            this.ColPrice.DataPropertyName = "Price";
            this.ColPrice.HeaderText = "签约单价";
            this.ColPrice.Name = "ColPrice";
            this.ColPrice.Width = 78;
            // 
            // ColAmount
            // 
            this.ColAmount.DataPropertyName = "Amount";
            this.ColAmount.HeaderText = "签约金额";
            this.ColAmount.Name = "ColAmount";
            this.ColAmount.Width = 78;
            // 
            // ColDownPayAmount
            // 
            this.ColDownPayAmount.DataPropertyName = "DownPayAmount";
            this.ColDownPayAmount.HeaderText = "首付金额";
            this.ColDownPayAmount.Name = "ColDownPayAmount";
            this.ColDownPayAmount.Width = 78;
            // 
            // ColLoan
            // 
            this.ColLoan.DataPropertyName = "Loan";
            this.ColLoan.HeaderText = "贷款金额";
            this.ColLoan.Name = "ColLoan";
            this.ColLoan.ReadOnly = true;
            this.ColLoan.Width = 78;
            // 
            // ColTotalAmount
            // 
            this.ColTotalAmount.DataPropertyName = "TotalAmount";
            this.ColTotalAmount.HeaderText = "签约总款";
            this.ColTotalAmount.Name = "ColTotalAmount";
            this.ColTotalAmount.Width = 78;
            // 
            // ColContractDate
            // 
            this.ColContractDate.DataPropertyName = "ContractDate";
            this.ColContractDate.HeaderText = "签约时间";
            this.ColContractDate.Name = "ColContractDate";
            this.ColContractDate.Width = 78;
            // 
            // ColSubscribeDate
            // 
            this.ColSubscribeDate.DataPropertyName = "SubscribeDate";
            this.ColSubscribeDate.HeaderText = "认购日期";
            this.ColSubscribeDate.Name = "ColSubscribeDate";
            this.ColSubscribeDate.Width = 78;
            // 
            // ColSalesID
            // 
            this.ColSalesID.DataPropertyName = "SalesID";
            this.ColSalesID.HeaderText = "SalesID";
            this.ColSalesID.Name = "ColSalesID";
            this.ColSalesID.Visible = false;
            this.ColSalesID.Width = 72;
            // 
            // ColSalesName
            // 
            this.ColSalesName.DataPropertyName = "SalesName";
            this.ColSalesName.HeaderText = "置业顾问";
            this.ColSalesName.Name = "ColSalesName";
            this.ColSalesName.Width = 78;
            // 
            // ColExtField0
            // 
            this.ColExtField0.DataPropertyName = "ExtField0";
            this.ColExtField0.HeaderText = "备注0";
            this.ColExtField0.Name = "ColExtField0";
            this.ColExtField0.Width = 60;
            // 
            // ColExtField1
            // 
            this.ColExtField1.DataPropertyName = "ExtField1";
            this.ColExtField1.HeaderText = "备注1";
            this.ColExtField1.Name = "ColExtField1";
            this.ColExtField1.Width = 60;
            // 
            // ColExtField2
            // 
            this.ColExtField2.DataPropertyName = "ExtField2";
            this.ColExtField2.HeaderText = "备注2";
            this.ColExtField2.Name = "ColExtField2";
            this.ColExtField2.Width = 60;
            // 
            // ColExtField3
            // 
            this.ColExtField3.DataPropertyName = "ExtField3";
            this.ColExtField3.HeaderText = "备注3";
            this.ColExtField3.Name = "ColExtField3";
            this.ColExtField3.Width = 60;
            // 
            // ColExtField4
            // 
            this.ColExtField4.DataPropertyName = "ExtField4";
            this.ColExtField4.HeaderText = "备注4";
            this.ColExtField4.Name = "ColExtField4";
            this.ColExtField4.Width = 60;
            // 
            // ColExtField5
            // 
            this.ColExtField5.DataPropertyName = "ExtField5";
            this.ColExtField5.HeaderText = "备注5";
            this.ColExtField5.Name = "ColExtField5";
            this.ColExtField5.Width = 60;
            // 
            // ColExtField6
            // 
            this.ColExtField6.DataPropertyName = "ExtField6";
            this.ColExtField6.HeaderText = "备注6";
            this.ColExtField6.Name = "ColExtField6";
            this.ColExtField6.Width = 60;
            // 
            // ColExtField7
            // 
            this.ColExtField7.DataPropertyName = "ExtField7";
            this.ColExtField7.HeaderText = "备注7";
            this.ColExtField7.Name = "ColExtField7";
            this.ColExtField7.Width = 60;
            // 
            // ColExtField8
            // 
            this.ColExtField8.DataPropertyName = "ExtField8";
            this.ColExtField8.HeaderText = "备注8";
            this.ColExtField8.Name = "ColExtField8";
            this.ColExtField8.Width = 60;
            // 
            // ColExtField9
            // 
            this.ColExtField9.DataPropertyName = "ExtField9";
            this.ColExtField9.HeaderText = "备注9";
            this.ColExtField9.Name = "ColExtField9";
            this.ColExtField9.Width = 60;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_All,
            this.toolStripButton_None});
            this.toolStrip2.Location = new System.Drawing.Point(3, 17);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1156, 31);
            this.toolStrip2.TabIndex = 11;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton_All
            // 
            this.toolStripButton_All.Image = global::Commission.Properties.Resources.list;
            this.toolStripButton_All.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_All.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_All.Name = "toolStripButton_All";
            this.toolStripButton_All.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_All.Text = "全选";
            this.toolStripButton_All.Click += new System.EventHandler(this.toolStripButton_All_Click);
            // 
            // toolStripButton_None
            // 
            this.toolStripButton_None.Image = global::Commission.Properties.Resources.Nolist;
            this.toolStripButton_None.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_None.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_None.Name = "toolStripButton_None";
            this.toolStripButton_None.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_None.Text = "全清";
            this.toolStripButton_None.Click += new System.EventHandler(this.toolStripButton_None_Click);
            // 
            // button_SalesMore
            // 
            this.button_SalesMore.Image = global::Commission.Properties.Resources.more;
            this.button_SalesMore.Location = new System.Drawing.Point(372, 22);
            this.button_SalesMore.Name = "button_SalesMore";
            this.button_SalesMore.Size = new System.Drawing.Size(26, 23);
            this.button_SalesMore.TabIndex = 63;
            this.button_SalesMore.UseVisualStyleBackColor = true;
            this.button_SalesMore.Click += new System.EventHandler(this.button_SalesMore_Click);
            // 
            // textBox_Sales
            // 
            this.textBox_Sales.Location = new System.Drawing.Point(266, 23);
            this.textBox_Sales.Name = "textBox_Sales";
            this.textBox_Sales.ReadOnly = true;
            this.textBox_Sales.Size = new System.Drawing.Size(100, 21);
            this.textBox_Sales.TabIndex = 64;
            // 
            // FrmHandover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 504);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmHandover";
            this.Text = "业务交接";
            this.Load += new System.EventHandler(this.FrmHandover_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Contract)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox_Sales;
        private System.Windows.Forms.ComboBox comboBox_NewSalesName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Handover;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_All;
        private System.Windows.Forms.ToolStripButton toolStripButton_None;
        private System.Windows.Forms.DataGridView dataGridView_Contract;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColContractID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSubscribeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSaleItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCustomerPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBuilding;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDownPayAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColContractDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSubscribeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSalesID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSalesName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExtField0;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExtField1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExtField2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExtField3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExtField4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExtField5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExtField6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExtField7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExtField8;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExtField9;
        private System.Windows.Forms.TextBox textBox_Sales;
        private System.Windows.Forms.Button button_SalesMore;
    }
}