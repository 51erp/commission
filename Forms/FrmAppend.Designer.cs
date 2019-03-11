namespace Commission.Forms
{
    partial class FrmAppend
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_CusPID = new System.Windows.Forms.TextBox();
            this.textBox_CusPhone = new System.Windows.Forms.TextBox();
            this.textBox_CusAddr = new System.Windows.Forms.TextBox();
            this.textBox_CusName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView_SaleItem = new System.Windows.Forms.DataGridView();
            this.ColItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBuilding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAmout = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Remove = new System.Windows.Forms.ToolStripButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBox_TotalLoan = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_TotalContract = new System.Windows.Forms.TextBox();
            this.textBox_TotalDownPay = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.textBox_ContractNum = new System.Windows.Forms.TextBox();
            this.textBox_Amount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker_ContractDate = new System.Windows.Forms.DateTimePicker();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label31 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.textBox_PaymentMode = new System.Windows.Forms.TextBox();
            this.textBox_PayRate = new System.Windows.Forms.TextBox();
            this.textBox_Loan = new System.Windows.Forms.TextBox();
            this.textBox_DownPay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_TotalAmount = new System.Windows.Forms.TextBox();
            this.toolTip_Info = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SaleItem)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Save,
            this.toolStripButton_Close});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(636, 31);
            this.toolStrip2.TabIndex = 22;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(636, 75);
            this.panel1.TabIndex = 24;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_CusPID);
            this.groupBox2.Controls.Add(this.textBox_CusPhone);
            this.groupBox2.Controls.Add(this.textBox_CusAddr);
            this.groupBox2.Controls.Add(this.textBox_CusName);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(630, 69);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "客户信息";
            // 
            // textBox_CusPID
            // 
            this.textBox_CusPID.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_CusPID.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_CusPID.Location = new System.Drawing.Point(468, 19);
            this.textBox_CusPID.Name = "textBox_CusPID";
            this.textBox_CusPID.ReadOnly = true;
            this.textBox_CusPID.Size = new System.Drawing.Size(149, 21);
            this.textBox_CusPID.TabIndex = 36;
            this.textBox_CusPID.TabStop = false;
            // 
            // textBox_CusPhone
            // 
            this.textBox_CusPhone.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_CusPhone.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_CusPhone.Location = new System.Drawing.Point(265, 19);
            this.textBox_CusPhone.Name = "textBox_CusPhone";
            this.textBox_CusPhone.ReadOnly = true;
            this.textBox_CusPhone.Size = new System.Drawing.Size(130, 21);
            this.textBox_CusPhone.TabIndex = 36;
            this.textBox_CusPhone.TabStop = false;
            // 
            // textBox_CusAddr
            // 
            this.textBox_CusAddr.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_CusAddr.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_CusAddr.Location = new System.Drawing.Point(71, 44);
            this.textBox_CusAddr.Name = "textBox_CusAddr";
            this.textBox_CusAddr.ReadOnly = true;
            this.textBox_CusAddr.Size = new System.Drawing.Size(546, 21);
            this.textBox_CusAddr.TabIndex = 36;
            this.textBox_CusAddr.TabStop = false;
            // 
            // textBox_CusName
            // 
            this.textBox_CusName.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_CusName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_CusName.Location = new System.Drawing.Point(71, 17);
            this.textBox_CusName.Name = "textBox_CusName";
            this.textBox_CusName.ReadOnly = true;
            this.textBox_CusName.Size = new System.Drawing.Size(130, 21);
            this.textBox_CusName.TabIndex = 36;
            this.textBox_CusName.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(411, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 34;
            this.label14.Text = "身份证号";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 33;
            this.label13.Text = "客户地址";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(211, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 32;
            this.label12.Text = "客户电话";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 31;
            this.label11.Text = "客户姓名";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 106);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(636, 322);
            this.panel2.TabIndex = 25;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(630, 316);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "签约信息";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView_SaleItem);
            this.panel3.Controls.Add(this.toolStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 84);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panel3.Size = new System.Drawing.Size(624, 164);
            this.panel3.TabIndex = 40;
            // 
            // dataGridView_SaleItem
            // 
            this.dataGridView_SaleItem.AllowUserToAddRows = false;
            this.dataGridView_SaleItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SaleItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColItemID,
            this.ColItemType,
            this.ColTypeName,
            this.ColBuilding,
            this.ColUnit,
            this.ColItemNum,
            this.ColArea,
            this.ColPrice,
            this.ColAmout});
            this.dataGridView_SaleItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_SaleItem.Location = new System.Drawing.Point(10, 25);
            this.dataGridView_SaleItem.Name = "dataGridView_SaleItem";
            this.dataGridView_SaleItem.ReadOnly = true;
            this.dataGridView_SaleItem.RowHeadersWidth = 21;
            this.dataGridView_SaleItem.RowTemplate.Height = 23;
            this.dataGridView_SaleItem.Size = new System.Drawing.Size(604, 139);
            this.dataGridView_SaleItem.TabIndex = 42;
            this.dataGridView_SaleItem.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_SaleItem_CellEndEdit);
            this.dataGridView_SaleItem.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView_SaleItem_CellValidating);
            // 
            // ColItemID
            // 
            this.ColItemID.Frozen = true;
            this.ColItemID.HeaderText = "ItemID";
            this.ColItemID.Name = "ColItemID";
            this.ColItemID.ReadOnly = true;
            this.ColItemID.Visible = false;
            // 
            // ColItemType
            // 
            this.ColItemType.Frozen = true;
            this.ColItemType.HeaderText = "ItemType";
            this.ColItemType.Name = "ColItemType";
            this.ColItemType.ReadOnly = true;
            this.ColItemType.Visible = false;
            // 
            // ColTypeName
            // 
            this.ColTypeName.Frozen = true;
            this.ColTypeName.HeaderText = "类型";
            this.ColTypeName.Name = "ColTypeName";
            this.ColTypeName.ReadOnly = true;
            this.ColTypeName.Width = 80;
            // 
            // ColBuilding
            // 
            this.ColBuilding.Frozen = true;
            this.ColBuilding.HeaderText = "楼/幢";
            this.ColBuilding.Name = "ColBuilding";
            this.ColBuilding.ReadOnly = true;
            this.ColBuilding.Width = 60;
            // 
            // ColUnit
            // 
            this.ColUnit.HeaderText = "单元";
            this.ColUnit.Name = "ColUnit";
            this.ColUnit.ReadOnly = true;
            this.ColUnit.Width = 60;
            // 
            // ColItemNum
            // 
            this.ColItemNum.HeaderText = "号码";
            this.ColItemNum.Name = "ColItemNum";
            this.ColItemNum.ReadOnly = true;
            this.ColItemNum.Width = 60;
            // 
            // ColArea
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ColArea.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColArea.HeaderText = "签约面积";
            this.ColArea.Name = "ColArea";
            this.ColArea.ReadOnly = true;
            // 
            // ColPrice
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "G";
            dataGridViewCellStyle5.NullValue = "0";
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ColPrice.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColPrice.HeaderText = "签约单价";
            this.ColPrice.Name = "ColPrice";
            this.ColPrice.ReadOnly = true;
            // 
            // ColAmout
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "G";
            dataGridViewCellStyle6.NullValue = "0";
            this.ColAmout.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColAmout.HeaderText = "签约金额";
            this.ColAmout.Name = "ColAmout";
            this.ColAmout.ReadOnly = true;
            this.ColAmout.Width = 120;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Add,
            this.toolStripButton_Remove});
            this.toolStrip1.Location = new System.Drawing.Point(10, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(604, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_Add
            // 
            this.toolStripButton_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Add.Image = global::Commission.Properties.Resources.Add_16px;
            this.toolStripButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Add.Name = "toolStripButton_Add";
            this.toolStripButton_Add.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Add.Text = "添加一个销售记录";
            this.toolStripButton_Add.Click += new System.EventHandler(this.toolStripButton_Add_Click);
            // 
            // toolStripButton_Remove
            // 
            this.toolStripButton_Remove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Remove.Image = global::Commission.Properties.Resources.remove2_16;
            this.toolStripButton_Remove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Remove.Name = "toolStripButton_Remove";
            this.toolStripButton_Remove.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Remove.Text = "移除一个销售记录";
            this.toolStripButton_Remove.Click += new System.EventHandler(this.toolStripButton_Remove_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.textBox_TotalLoan);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.textBox_TotalContract);
            this.panel4.Controls.Add(this.textBox_TotalDownPay);
            this.panel4.Controls.Add(this.label30);
            this.panel4.Controls.Add(this.textBox_ContractNum);
            this.panel4.Controls.Add(this.textBox_Amount);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.dateTimePicker_ContractDate);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 248);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(624, 65);
            this.panel4.TabIndex = 41;
            // 
            // textBox_TotalLoan
            // 
            this.textBox_TotalLoan.Location = new System.Drawing.Point(265, 37);
            this.textBox_TotalLoan.Name = "textBox_TotalLoan";
            this.textBox_TotalLoan.Size = new System.Drawing.Size(127, 21);
            this.textBox_TotalLoan.TabIndex = 61;
            this.textBox_TotalLoan.Text = "0";
            this.textBox_TotalLoan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_TotalLoan.TextChanged += new System.EventHandler(this.textBox_TotalLoan_TextChanged);
            this.textBox_TotalLoan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_TotalLoan_KeyPress);
            this.textBox_TotalLoan.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_TotalLoan_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(405, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 54;
            this.label6.Text = "签约金额";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(205, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 54;
            this.label5.Text = "贷款金额";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(405, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 54;
            this.label16.Text = "附加总额";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 56;
            this.label3.Text = "应付首付";
            // 
            // textBox_TotalContract
            // 
            this.textBox_TotalContract.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_TotalContract.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_TotalContract.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_TotalContract.Location = new System.Drawing.Point(465, 37);
            this.textBox_TotalContract.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.textBox_TotalContract.Name = "textBox_TotalContract";
            this.textBox_TotalContract.ReadOnly = true;
            this.textBox_TotalContract.Size = new System.Drawing.Size(149, 21);
            this.textBox_TotalContract.TabIndex = 60;
            this.textBox_TotalContract.Text = "0";
            this.textBox_TotalContract.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip_Info.SetToolTip(this.textBox_TotalContract, "附加总额 + 签约总额");
            // 
            // textBox_TotalDownPay
            // 
            this.textBox_TotalDownPay.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_TotalDownPay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_TotalDownPay.Location = new System.Drawing.Point(69, 37);
            this.textBox_TotalDownPay.Name = "textBox_TotalDownPay";
            this.textBox_TotalDownPay.ReadOnly = true;
            this.textBox_TotalDownPay.Size = new System.Drawing.Size(129, 21);
            this.textBox_TotalDownPay.TabIndex = 53;
            this.textBox_TotalDownPay.Text = "0";
            this.textBox_TotalDownPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_TotalDownPay.TextChanged += new System.EventHandler(this.textBox_TotalDownPay_TextChanged);
            this.textBox_TotalDownPay.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_TotalDownPay_Validating);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(9, 14);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(53, 12);
            this.label30.TabIndex = 32;
            this.label30.Text = "签约编号";
            // 
            // textBox_ContractNum
            // 
            this.textBox_ContractNum.Location = new System.Drawing.Point(69, 11);
            this.textBox_ContractNum.Name = "textBox_ContractNum";
            this.textBox_ContractNum.Size = new System.Drawing.Size(130, 21);
            this.textBox_ContractNum.TabIndex = 1;
            // 
            // textBox_Amount
            // 
            this.textBox_Amount.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Amount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Amount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Amount.Location = new System.Drawing.Point(465, 11);
            this.textBox_Amount.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.textBox_Amount.Name = "textBox_Amount";
            this.textBox_Amount.ReadOnly = true;
            this.textBox_Amount.Size = new System.Drawing.Size(149, 21);
            this.textBox_Amount.TabIndex = 60;
            this.textBox_Amount.Text = "0";
            this.textBox_Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 32;
            this.label2.Text = "签约时间";
            // 
            // dateTimePicker_ContractDate
            // 
            this.dateTimePicker_ContractDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_ContractDate.Location = new System.Drawing.Point(265, 11);
            this.dateTimePicker_ContractDate.Name = "dateTimePicker_ContractDate";
            this.dateTimePicker_ContractDate.Size = new System.Drawing.Size(127, 21);
            this.dateTimePicker_ContractDate.TabIndex = 35;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label31);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.label29);
            this.panel5.Controls.Add(this.textBox_PaymentMode);
            this.panel5.Controls.Add(this.textBox_PayRate);
            this.panel5.Controls.Add(this.textBox_Loan);
            this.panel5.Controls.Add(this.textBox_DownPay);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.textBox_TotalAmount);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 17);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(624, 67);
            this.panel5.TabIndex = 39;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(205, 44);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(53, 12);
            this.label31.TabIndex = 64;
            this.label31.Text = "贷款金额";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(205, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 65;
            this.label8.Text = "首付比例";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 65;
            this.label7.Text = "付款方式";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(9, 44);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(53, 12);
            this.label29.TabIndex = 65;
            this.label29.Text = "应付首付";
            // 
            // textBox_PaymentMode
            // 
            this.textBox_PaymentMode.Location = new System.Drawing.Point(68, 11);
            this.textBox_PaymentMode.Name = "textBox_PaymentMode";
            this.textBox_PaymentMode.ReadOnly = true;
            this.textBox_PaymentMode.Size = new System.Drawing.Size(128, 21);
            this.textBox_PaymentMode.TabIndex = 100;
            // 
            // textBox_PayRate
            // 
            this.textBox_PayRate.Location = new System.Drawing.Point(265, 11);
            this.textBox_PayRate.Name = "textBox_PayRate";
            this.textBox_PayRate.ReadOnly = true;
            this.textBox_PayRate.Size = new System.Drawing.Size(128, 21);
            this.textBox_PayRate.TabIndex = 101;
            this.textBox_PayRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_Loan
            // 
            this.textBox_Loan.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_Loan.Location = new System.Drawing.Point(264, 40);
            this.textBox_Loan.Name = "textBox_Loan";
            this.textBox_Loan.ReadOnly = true;
            this.textBox_Loan.Size = new System.Drawing.Size(128, 21);
            this.textBox_Loan.TabIndex = 103;
            this.textBox_Loan.Text = "0";
            this.textBox_Loan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_DownPay
            // 
            this.textBox_DownPay.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_DownPay.Location = new System.Drawing.Point(68, 40);
            this.textBox_DownPay.Name = "textBox_DownPay";
            this.textBox_DownPay.ReadOnly = true;
            this.textBox_DownPay.Size = new System.Drawing.Size(130, 21);
            this.textBox_DownPay.TabIndex = 102;
            this.textBox_DownPay.Text = "0";
            this.textBox_DownPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(405, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 61;
            this.label4.Text = "签约总额";
            // 
            // textBox_TotalAmount
            // 
            this.textBox_TotalAmount.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_TotalAmount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_TotalAmount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_TotalAmount.Location = new System.Drawing.Point(465, 40);
            this.textBox_TotalAmount.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.textBox_TotalAmount.Name = "textBox_TotalAmount";
            this.textBox_TotalAmount.ReadOnly = true;
            this.textBox_TotalAmount.Size = new System.Drawing.Size(149, 21);
            this.textBox_TotalAmount.TabIndex = 104;
            this.textBox_TotalAmount.Text = "0";
            this.textBox_TotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // toolTip_Info
            // 
            this.toolTip_Info.AutoPopDelay = 10000;
            this.toolTip_Info.BackColor = System.Drawing.Color.LightGray;
            this.toolTip_Info.ForeColor = System.Drawing.Color.Blue;
            this.toolTip_Info.InitialDelay = 500;
            this.toolTip_Info.IsBalloon = true;
            this.toolTip_Info.ReshowDelay = 100;
            // 
            // FrmAppend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 428);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAppend";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加储藏间";
            this.Load += new System.EventHandler(this.FrmAppend_Load);
            this.Shown += new System.EventHandler(this.FrmAppend_Shown);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SaleItem)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Save;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_CusPID;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_CusPhone;
        private System.Windows.Forms.TextBox textBox_CusAddr;
        private System.Windows.Forms.TextBox textBox_CusName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView_SaleItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBuilding;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAmout;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Add;
        private System.Windows.Forms.ToolStripButton toolStripButton_Remove;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_TotalAmount;
        private System.Windows.Forms.TextBox textBox_TotalDownPay;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ContractDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox textBox_ContractNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox textBox_Loan;
        private System.Windows.Forms.TextBox textBox_DownPay;
        private System.Windows.Forms.TextBox textBox_Amount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_TotalContract;
        private System.Windows.Forms.ToolTip toolTip_Info;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_PayRate;
        private System.Windows.Forms.TextBox textBox_PaymentMode;
        private System.Windows.Forms.TextBox textBox_TotalLoan;
    }
}