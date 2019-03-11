namespace Commission.MenuForms
{
    partial class FrmChange
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
            this.toolStripButton_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Del = new System.Windows.Forms.ToolStripButton();
            this.dataGridView_Change = new System.Windows.Forms.DataGridView();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColChangeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColConfirmType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_Phone = new System.Windows.Forms.TextBox();
            this.textBox_CusName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_ItemNum = new System.Windows.Forms.TextBox();
            this.textBox_Unit = new System.Windows.Forms.TextBox();
            this.textBox_Building = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_Search = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_Contract = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.ColContractID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCustomerPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBuilding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColContractDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDownPayAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Change)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Contract)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripButton_Add
            // 
            this.toolStripButton_Add.Image = global::Commission.Properties.Resources.file_new;
            this.toolStripButton_Add.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Add.Name = "toolStripButton_Add";
            this.toolStripButton_Add.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_Add.Text = "新增";
            this.toolStripButton_Add.ToolTipText = "新增";
            this.toolStripButton_Add.Click += new System.EventHandler(this.toolStripButton_Add_Click);
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
            this.toolStripButton_Del.Click += new System.EventHandler(this.toolStripButton_Del_Click);
            // 
            // dataGridView_Change
            // 
            this.dataGridView_Change.AllowUserToAddRows = false;
            this.dataGridView_Change.AllowUserToDeleteRows = false;
            this.dataGridView_Change.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Change.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColChangeDate,
            this.ColConfirmType,
            this.ColMemo});
            this.dataGridView_Change.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Change.Location = new System.Drawing.Point(3, 50);
            this.dataGridView_Change.Name = "dataGridView_Change";
            this.dataGridView_Change.ReadOnly = true;
            this.dataGridView_Change.RowHeadersWidth = 21;
            this.dataGridView_Change.RowTemplate.Height = 23;
            this.dataGridView_Change.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Change.Size = new System.Drawing.Size(883, 116);
            this.dataGridView_Change.TabIndex = 5;
            // 
            // ColID
            // 
            this.ColID.DataPropertyName = "ID";
            this.ColID.HeaderText = "ID";
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            this.ColID.Visible = false;
            // 
            // ColChangeDate
            // 
            this.ColChangeDate.DataPropertyName = "ChangeDate";
            this.ColChangeDate.HeaderText = "变更日期";
            this.ColChangeDate.Name = "ColChangeDate";
            this.ColChangeDate.ReadOnly = true;
            // 
            // ColConfirmType
            // 
            this.ColConfirmType.DataPropertyName = "ConfirmType";
            this.ColConfirmType.HeaderText = "变更类型";
            this.ColConfirmType.Name = "ColConfirmType";
            this.ColConfirmType.ReadOnly = true;
            // 
            // ColMemo
            // 
            this.ColMemo.DataPropertyName = "Memo";
            this.ColMemo.HeaderText = "变更说明";
            this.ColMemo.Name = "ColMemo";
            this.ColMemo.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.panel1.Size = new System.Drawing.Size(895, 92);
            this.panel1.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_Phone);
            this.groupBox1.Controls.Add(this.textBox_CusName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox_ItemNum);
            this.groupBox1.Controls.Add(this.textBox_Unit);
            this.groupBox1.Controls.Add(this.textBox_Building);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button_Exit);
            this.groupBox1.Controls.Add(this.button_Search);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(889, 76);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // textBox_Phone
            // 
            this.textBox_Phone.Location = new System.Drawing.Point(257, 17);
            this.textBox_Phone.Name = "textBox_Phone";
            this.textBox_Phone.Size = new System.Drawing.Size(100, 21);
            this.textBox_Phone.TabIndex = 43;
            // 
            // textBox_CusName
            // 
            this.textBox_CusName.Location = new System.Drawing.Point(68, 17);
            this.textBox_CusName.Name = "textBox_CusName";
            this.textBox_CusName.Size = new System.Drawing.Size(121, 21);
            this.textBox_CusName.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(198, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 41;
            this.label6.Text = "联系电话";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 40;
            this.label7.Text = "客户姓名";
            // 
            // textBox_ItemNum
            // 
            this.textBox_ItemNum.Location = new System.Drawing.Point(406, 44);
            this.textBox_ItemNum.Name = "textBox_ItemNum";
            this.textBox_ItemNum.Size = new System.Drawing.Size(100, 21);
            this.textBox_ItemNum.TabIndex = 39;
            // 
            // textBox_Unit
            // 
            this.textBox_Unit.Location = new System.Drawing.Point(257, 44);
            this.textBox_Unit.Name = "textBox_Unit";
            this.textBox_Unit.Size = new System.Drawing.Size(100, 21);
            this.textBox_Unit.TabIndex = 38;
            // 
            // textBox_Building
            // 
            this.textBox_Building.Location = new System.Drawing.Point(68, 44);
            this.textBox_Building.Name = "textBox_Building";
            this.textBox_Building.Size = new System.Drawing.Size(121, 21);
            this.textBox_Building.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(371, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 36;
            this.label4.Text = "房号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 35;
            this.label3.Text = "单元";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 34;
            this.label2.Text = "楼号";
            // 
            // button_Exit
            // 
            this.button_Exit.Image = global::Commission.Properties.Resources.exit;
            this.button_Exit.Location = new System.Drawing.Point(617, 43);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(75, 23);
            this.button_Exit.TabIndex = 31;
            this.button_Exit.Text = " 关闭";
            this.button_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_Search
            // 
            this.button_Search.Image = global::Commission.Properties.Resources.Find_16;
            this.button_Search.Location = new System.Drawing.Point(536, 43);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(75, 23);
            this.button_Search.TabIndex = 30;
            this.button_Search.Text = " 查询";
            this.button_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 92);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.splitContainer1.Size = new System.Drawing.Size(895, 495);
            this.splitContainer1.SplitterDistance = 314;
            this.splitContainer1.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView_Contract);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(889, 306);
            this.groupBox2.TabIndex = 1;
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
            this.ColCustomerID,
            this.ColCusName,
            this.ColCustomerPhone,
            this.ColItemTypeName,
            this.ColBuilding,
            this.ColUnit,
            this.ColItemNum,
            this.ColContractDate,
            this.ColArea,
            this.ColPrice,
            this.ColAmount,
            this.ColDownPayAmount,
            this.ColLoan,
            this.ColTotalAmount,
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
            this.dataGridView_Contract.Location = new System.Drawing.Point(3, 17);
            this.dataGridView_Contract.Name = "dataGridView_Contract";
            this.dataGridView_Contract.ReadOnly = true;
            this.dataGridView_Contract.RowHeadersWidth = 21;
            this.dataGridView_Contract.RowTemplate.Height = 23;
            this.dataGridView_Contract.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Contract.Size = new System.Drawing.Size(883, 286);
            this.dataGridView_Contract.TabIndex = 5;
            this.dataGridView_Contract.SelectionChanged += new System.EventHandler(this.dataGridView_Contract_SelectionChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView_Change);
            this.groupBox3.Controls.Add(this.toolStrip2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.groupBox3.Size = new System.Drawing.Size(889, 169);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "变更记录";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Add,
            this.toolStripButton_Del});
            this.toolStrip2.Location = new System.Drawing.Point(3, 19);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(883, 31);
            this.toolStrip2.TabIndex = 4;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // ColContractID
            // 
            this.ColContractID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColContractID.DataPropertyName = "ContractID";
            this.ColContractID.HeaderText = "ContractID";
            this.ColContractID.Name = "ColContractID";
            this.ColContractID.ReadOnly = true;
            this.ColContractID.Visible = false;
            this.ColContractID.Width = 60;
            // 
            // ColCustomerID
            // 
            this.ColCustomerID.DataPropertyName = "CustomerID";
            this.ColCustomerID.HeaderText = "CustomerID";
            this.ColCustomerID.Name = "ColCustomerID";
            this.ColCustomerID.ReadOnly = true;
            this.ColCustomerID.Visible = false;
            this.ColCustomerID.Width = 90;
            // 
            // ColCusName
            // 
            this.ColCusName.DataPropertyName = "CustomerName";
            this.ColCusName.HeaderText = "客户名称";
            this.ColCusName.Name = "ColCusName";
            this.ColCusName.ReadOnly = true;
            this.ColCusName.Width = 78;
            // 
            // ColCustomerPhone
            // 
            this.ColCustomerPhone.DataPropertyName = "CustomerPhone";
            this.ColCustomerPhone.HeaderText = "客户电话";
            this.ColCustomerPhone.Name = "ColCustomerPhone";
            this.ColCustomerPhone.ReadOnly = true;
            this.ColCustomerPhone.Width = 78;
            // 
            // ColItemTypeName
            // 
            this.ColItemTypeName.DataPropertyName = "ItemTypeName";
            this.ColItemTypeName.HeaderText = "房产类型";
            this.ColItemTypeName.Name = "ColItemTypeName";
            this.ColItemTypeName.ReadOnly = true;
            this.ColItemTypeName.Width = 78;
            // 
            // ColBuilding
            // 
            this.ColBuilding.DataPropertyName = "Building";
            this.ColBuilding.HeaderText = "楼/幢";
            this.ColBuilding.Name = "ColBuilding";
            this.ColBuilding.ReadOnly = true;
            this.ColBuilding.Width = 60;
            // 
            // ColUnit
            // 
            this.ColUnit.DataPropertyName = "Unit";
            this.ColUnit.HeaderText = "单元";
            this.ColUnit.Name = "ColUnit";
            this.ColUnit.ReadOnly = true;
            this.ColUnit.Width = 54;
            // 
            // ColItemNum
            // 
            this.ColItemNum.DataPropertyName = "ItemNum";
            this.ColItemNum.HeaderText = "房号";
            this.ColItemNum.Name = "ColItemNum";
            this.ColItemNum.ReadOnly = true;
            this.ColItemNum.Width = 54;
            // 
            // ColContractDate
            // 
            this.ColContractDate.DataPropertyName = "ContractDate";
            this.ColContractDate.HeaderText = "签约时间";
            this.ColContractDate.Name = "ColContractDate";
            this.ColContractDate.ReadOnly = true;
            this.ColContractDate.Width = 78;
            // 
            // ColArea
            // 
            this.ColArea.DataPropertyName = "Area";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
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
            dataGridViewCellStyle2.Format = "F4";
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
            // ColDownPayAmount
            // 
            this.ColDownPayAmount.DataPropertyName = "DownPayAmount";
            this.ColDownPayAmount.HeaderText = "首付金额";
            this.ColDownPayAmount.Name = "ColDownPayAmount";
            this.ColDownPayAmount.ReadOnly = true;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "F0";
            this.ColTotalAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColTotalAmount.HeaderText = "签约总款";
            this.ColTotalAmount.Name = "ColTotalAmount";
            this.ColTotalAmount.ReadOnly = true;
            this.ColTotalAmount.Width = 78;
            // 
            // ColSalesName
            // 
            this.ColSalesName.DataPropertyName = "SalesName";
            this.ColSalesName.HeaderText = "置业顾问";
            this.ColSalesName.Name = "ColSalesName";
            this.ColSalesName.ReadOnly = true;
            this.ColSalesName.Width = 78;
            // 
            // ColExtField0
            // 
            this.ColExtField0.DataPropertyName = "ExtField0";
            this.ColExtField0.HeaderText = "备注0";
            this.ColExtField0.Name = "ColExtField0";
            this.ColExtField0.ReadOnly = true;
            this.ColExtField0.Width = 60;
            // 
            // ColExtField1
            // 
            this.ColExtField1.DataPropertyName = "ExtField1";
            this.ColExtField1.HeaderText = "备注1";
            this.ColExtField1.Name = "ColExtField1";
            this.ColExtField1.ReadOnly = true;
            this.ColExtField1.Width = 60;
            // 
            // ColExtField2
            // 
            this.ColExtField2.DataPropertyName = "ExtField2";
            this.ColExtField2.HeaderText = "备注2";
            this.ColExtField2.Name = "ColExtField2";
            this.ColExtField2.ReadOnly = true;
            this.ColExtField2.Width = 60;
            // 
            // ColExtField3
            // 
            this.ColExtField3.DataPropertyName = "ExtField3";
            this.ColExtField3.HeaderText = "备注3";
            this.ColExtField3.Name = "ColExtField3";
            this.ColExtField3.ReadOnly = true;
            this.ColExtField3.Width = 60;
            // 
            // ColExtField4
            // 
            this.ColExtField4.DataPropertyName = "ExtField4";
            this.ColExtField4.HeaderText = "备注4";
            this.ColExtField4.Name = "ColExtField4";
            this.ColExtField4.ReadOnly = true;
            this.ColExtField4.Width = 60;
            // 
            // ColExtField5
            // 
            this.ColExtField5.DataPropertyName = "ExtField5";
            this.ColExtField5.HeaderText = "备注5";
            this.ColExtField5.Name = "ColExtField5";
            this.ColExtField5.ReadOnly = true;
            this.ColExtField5.Width = 60;
            // 
            // ColExtField6
            // 
            this.ColExtField6.DataPropertyName = "ExtField6";
            this.ColExtField6.HeaderText = "备注6";
            this.ColExtField6.Name = "ColExtField6";
            this.ColExtField6.ReadOnly = true;
            this.ColExtField6.Width = 60;
            // 
            // ColExtField7
            // 
            this.ColExtField7.DataPropertyName = "ExtField7";
            this.ColExtField7.HeaderText = "备注7";
            this.ColExtField7.Name = "ColExtField7";
            this.ColExtField7.ReadOnly = true;
            this.ColExtField7.Width = 60;
            // 
            // ColExtField8
            // 
            this.ColExtField8.DataPropertyName = "ExtField8";
            this.ColExtField8.HeaderText = "备注8";
            this.ColExtField8.Name = "ColExtField8";
            this.ColExtField8.ReadOnly = true;
            this.ColExtField8.Width = 60;
            // 
            // ColExtField9
            // 
            this.ColExtField9.DataPropertyName = "ExtField9";
            this.ColExtField9.HeaderText = "备注9";
            this.ColExtField9.Name = "ColExtField9";
            this.ColExtField9.ReadOnly = true;
            this.ColExtField9.Width = 60;
            // 
            // FrmChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 587);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmChange";
            this.Text = "面积变更";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Change)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Contract)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton toolStripButton_Add;
        private System.Windows.Forms.ToolStripButton toolStripButton_Del;
        private System.Windows.Forms.DataGridView dataGridView_Change;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_Phone;
        private System.Windows.Forms.TextBox textBox_CusName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_ItemNum;
        private System.Windows.Forms.TextBox textBox_Unit;
        private System.Windows.Forms.TextBox textBox_Building;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.DataGridView dataGridView_Contract;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChangeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColConfirmType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColContractID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCustomerPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBuilding;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColContractDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDownPayAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalAmount;
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
    }
}