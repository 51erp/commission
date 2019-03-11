namespace Commission.Forms
{
    partial class FrmChangeAdd
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
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.textBox_PaymentMode = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox_DownPayRate = new System.Windows.Forms.TextBox();
            this.textBox_Loan = new System.Windows.Forms.TextBox();
            this.textBox_DownPay = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_TotalAmount = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView_SaleItem = new System.Windows.Forms.DataGridView();
            this.ColConDID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBuilding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNewArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNewAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_Memo = new System.Windows.Forms.TextBox();
            this.button_Installment = new System.Windows.Forms.Button();
            this.comboBox_ConfirmType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_Differ = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_NewTotalAmount = new System.Windows.Forms.TextBox();
            this.textBox_NewDownPay = new System.Windows.Forms.TextBox();
            this.textBox_NewLoan = new System.Windows.Forms.TextBox();
            this.textBox_ContractNum = new System.Windows.Forms.TextBox();
            this.dateTimePicker_ChangeDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SaleItem)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Save,
            this.toolStripSeparator1,
            this.toolStripButton_Close});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(795, 31);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label31);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Controls.Add(this.textBox_PaymentMode);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.textBox_DownPayRate);
            this.groupBox3.Controls.Add(this.textBox_Loan);
            this.groupBox3.Controls.Add(this.textBox_DownPay);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBox_TotalAmount);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 31);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(795, 78);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "签约信息";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(208, 51);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(53, 12);
            this.label31.TabIndex = 74;
            this.label31.Text = "贷款金额";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(208, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 75;
            this.label8.Text = "首付比例";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 76;
            this.label3.Text = "付款方式";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(12, 51);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(53, 12);
            this.label29.TabIndex = 77;
            this.label29.Text = "应付首付";
            // 
            // textBox_PaymentMode
            // 
            this.textBox_PaymentMode.Location = new System.Drawing.Point(71, 22);
            this.textBox_PaymentMode.Name = "textBox_PaymentMode";
            this.textBox_PaymentMode.ReadOnly = true;
            this.textBox_PaymentMode.Size = new System.Drawing.Size(129, 21);
            this.textBox_PaymentMode.TabIndex = 69;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(72, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(129, 21);
            this.textBox1.TabIndex = 69;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_DownPayRate
            // 
            this.textBox_DownPayRate.Location = new System.Drawing.Point(267, 22);
            this.textBox_DownPayRate.Name = "textBox_DownPayRate";
            this.textBox_DownPayRate.ReadOnly = true;
            this.textBox_DownPayRate.Size = new System.Drawing.Size(110, 21);
            this.textBox_DownPayRate.TabIndex = 69;
            this.textBox_DownPayRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_Loan
            // 
            this.textBox_Loan.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_Loan.Location = new System.Drawing.Point(267, 47);
            this.textBox_Loan.Name = "textBox_Loan";
            this.textBox_Loan.ReadOnly = true;
            this.textBox_Loan.Size = new System.Drawing.Size(110, 21);
            this.textBox_Loan.TabIndex = 72;
            this.textBox_Loan.Text = "0";
            this.textBox_Loan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_DownPay
            // 
            this.textBox_DownPay.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_DownPay.Location = new System.Drawing.Point(71, 47);
            this.textBox_DownPay.Name = "textBox_DownPay";
            this.textBox_DownPay.ReadOnly = true;
            this.textBox_DownPay.Size = new System.Drawing.Size(130, 21);
            this.textBox_DownPay.TabIndex = 73;
            this.textBox_DownPay.Text = "0";
            this.textBox_DownPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(378, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 71;
            this.label7.Text = "%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(383, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 71;
            this.label4.Text = "签约总额";
            // 
            // textBox_TotalAmount
            // 
            this.textBox_TotalAmount.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_TotalAmount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_TotalAmount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_TotalAmount.Location = new System.Drawing.Point(442, 47);
            this.textBox_TotalAmount.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.textBox_TotalAmount.Name = "textBox_TotalAmount";
            this.textBox_TotalAmount.ReadOnly = true;
            this.textBox_TotalAmount.Size = new System.Drawing.Size(125, 21);
            this.textBox_TotalAmount.TabIndex = 70;
            this.textBox_TotalAmount.Text = "0";
            this.textBox_TotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView_SaleItem);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.groupBox1.Size = new System.Drawing.Size(795, 162);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "变更信息";
            // 
            // dataGridView_SaleItem
            // 
            this.dataGridView_SaleItem.AllowUserToAddRows = false;
            this.dataGridView_SaleItem.AllowUserToDeleteRows = false;
            this.dataGridView_SaleItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView_SaleItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SaleItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColConDID,
            this.ColItemID,
            this.ColTypeName,
            this.ColBuilding,
            this.ColUnit,
            this.ColItemNum,
            this.ColArea,
            this.ColPrice,
            this.ColAmount,
            this.ColNewArea,
            this.ColNewAmount});
            this.dataGridView_SaleItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_SaleItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView_SaleItem.Location = new System.Drawing.Point(10, 19);
            this.dataGridView_SaleItem.MultiSelect = false;
            this.dataGridView_SaleItem.Name = "dataGridView_SaleItem";
            this.dataGridView_SaleItem.RowHeadersWidth = 21;
            this.dataGridView_SaleItem.RowTemplate.Height = 23;
            this.dataGridView_SaleItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_SaleItem.Size = new System.Drawing.Size(775, 138);
            this.dataGridView_SaleItem.TabIndex = 3;
            this.dataGridView_SaleItem.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_TransDetail_CellEndEdit);
            this.dataGridView_SaleItem.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView_TransDetail_CellValidating);
            // 
            // ColConDID
            // 
            this.ColConDID.DataPropertyName = "ConDID";
            this.ColConDID.HeaderText = "ConDID";
            this.ColConDID.Name = "ColConDID";
            this.ColConDID.Visible = false;
            this.ColConDID.Width = 66;
            // 
            // ColItemID
            // 
            this.ColItemID.DataPropertyName = "ItemID";
            this.ColItemID.HeaderText = "ItemID";
            this.ColItemID.Name = "ColItemID";
            this.ColItemID.Visible = false;
            this.ColItemID.Width = 66;
            // 
            // ColTypeName
            // 
            this.ColTypeName.DataPropertyName = "ItemTypeName";
            this.ColTypeName.HeaderText = "房产类型";
            this.ColTypeName.Name = "ColTypeName";
            this.ColTypeName.Width = 78;
            // 
            // ColBuilding
            // 
            this.ColBuilding.DataPropertyName = "Building";
            this.ColBuilding.HeaderText = "楼号";
            this.ColBuilding.Name = "ColBuilding";
            this.ColBuilding.ReadOnly = true;
            this.ColBuilding.Width = 54;
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
            // ColArea
            // 
            this.ColArea.DataPropertyName = "Area";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
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
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
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
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ColAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColAmount.HeaderText = "签约金额";
            this.ColAmount.Name = "ColAmount";
            this.ColAmount.ReadOnly = true;
            this.ColAmount.Width = 78;
            // 
            // ColNewArea
            // 
            this.ColNewArea.DataPropertyName = "ChangeArea";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "F0";
            dataGridViewCellStyle4.NullValue = "0";
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ColNewArea.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColNewArea.HeaderText = "变更面积";
            this.ColNewArea.Name = "ColNewArea";
            this.ColNewArea.Width = 78;
            // 
            // ColNewAmount
            // 
            this.ColNewAmount.DataPropertyName = "NewAmount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "F0";
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ColNewAmount.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColNewAmount.HeaderText = "变更金额";
            this.ColNewAmount.Name = "ColNewAmount";
            this.ColNewAmount.ReadOnly = true;
            this.ColNewAmount.Width = 78;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_Memo);
            this.groupBox2.Controls.Add(this.button_Installment);
            this.groupBox2.Controls.Add(this.comboBox_ConfirmType);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBox_Differ);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBox_NewTotalAmount);
            this.groupBox2.Controls.Add(this.textBox_NewDownPay);
            this.groupBox2.Controls.Add(this.textBox_NewLoan);
            this.groupBox2.Controls.Add(this.textBox_ContractNum);
            this.groupBox2.Controls.Add(this.dateTimePicker_ChangeDate);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 271);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(795, 97);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            // 
            // textBox_Memo
            // 
            this.textBox_Memo.Location = new System.Drawing.Point(71, 65);
            this.textBox_Memo.Name = "textBox_Memo";
            this.textBox_Memo.Size = new System.Drawing.Size(652, 21);
            this.textBox_Memo.TabIndex = 69;
            // 
            // button_Installment
            // 
            this.button_Installment.Enabled = false;
            this.button_Installment.Location = new System.Drawing.Point(643, 15);
            this.button_Installment.Name = "button_Installment";
            this.button_Installment.Size = new System.Drawing.Size(80, 23);
            this.button_Installment.TabIndex = 68;
            this.button_Installment.Text = "分期设置";
            this.button_Installment.UseVisualStyleBackColor = true;
            this.button_Installment.Click += new System.EventHandler(this.button_Installment_Click);
            // 
            // comboBox_ConfirmType
            // 
            this.comboBox_ConfirmType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ConfirmType.FormattingEnabled = true;
            this.comboBox_ConfirmType.Items.AddRange(new object[] {
            "面积变更",
            "预确权",
            "确权"});
            this.comboBox_ConfirmType.Location = new System.Drawing.Point(643, 40);
            this.comboBox_ConfirmType.Name = "comboBox_ConfirmType";
            this.comboBox_ConfirmType.Size = new System.Drawing.Size(80, 20);
            this.comboBox_ConfirmType.TabIndex = 67;
            this.comboBox_ConfirmType.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(584, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 62;
            this.label5.Text = "变更类型";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(383, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 62;
            this.label11.Text = "变更差额";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(383, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 62;
            this.label6.Text = "签约总额";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(208, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 63;
            this.label9.Text = "贷款金额";
            // 
            // textBox_Differ
            // 
            this.textBox_Differ.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Differ.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Differ.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Differ.Location = new System.Drawing.Point(442, 16);
            this.textBox_Differ.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.textBox_Differ.Name = "textBox_Differ";
            this.textBox_Differ.ReadOnly = true;
            this.textBox_Differ.Size = new System.Drawing.Size(130, 21);
            this.textBox_Differ.TabIndex = 65;
            this.textBox_Differ.Text = "0";
            this.textBox_Differ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 64;
            this.label12.Text = "变更说明";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 64;
            this.label10.Text = "应付首付";
            // 
            // textBox_NewTotalAmount
            // 
            this.textBox_NewTotalAmount.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_NewTotalAmount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_NewTotalAmount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_NewTotalAmount.Location = new System.Drawing.Point(442, 40);
            this.textBox_NewTotalAmount.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.textBox_NewTotalAmount.Name = "textBox_NewTotalAmount";
            this.textBox_NewTotalAmount.ReadOnly = true;
            this.textBox_NewTotalAmount.Size = new System.Drawing.Size(130, 21);
            this.textBox_NewTotalAmount.TabIndex = 65;
            this.textBox_NewTotalAmount.Text = "0";
            this.textBox_NewTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_NewDownPay
            // 
            this.textBox_NewDownPay.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_NewDownPay.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_NewDownPay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_NewDownPay.Location = new System.Drawing.Point(71, 40);
            this.textBox_NewDownPay.Name = "textBox_NewDownPay";
            this.textBox_NewDownPay.Size = new System.Drawing.Size(128, 21);
            this.textBox_NewDownPay.TabIndex = 61;
            this.textBox_NewDownPay.Text = "0";
            this.textBox_NewDownPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_NewDownPay.TextChanged += new System.EventHandler(this.textBox_NewDownPay_TextChanged);
            // 
            // textBox_NewLoan
            // 
            this.textBox_NewLoan.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_NewLoan.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_NewLoan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_NewLoan.Location = new System.Drawing.Point(267, 40);
            this.textBox_NewLoan.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.textBox_NewLoan.Name = "textBox_NewLoan";
            this.textBox_NewLoan.ReadOnly = true;
            this.textBox_NewLoan.Size = new System.Drawing.Size(110, 21);
            this.textBox_NewLoan.TabIndex = 66;
            this.textBox_NewLoan.Text = "0";
            this.textBox_NewLoan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_NewLoan.TextChanged += new System.EventHandler(this.textBox_NewLoan_TextChanged);
            // 
            // textBox_ContractNum
            // 
            this.textBox_ContractNum.Location = new System.Drawing.Point(267, 16);
            this.textBox_ContractNum.Name = "textBox_ContractNum";
            this.textBox_ContractNum.Size = new System.Drawing.Size(110, 21);
            this.textBox_ContractNum.TabIndex = 2;
            // 
            // dateTimePicker_ChangeDate
            // 
            this.dateTimePicker_ChangeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_ChangeDate.Location = new System.Drawing.Point(71, 16);
            this.dateTimePicker_ChangeDate.Name = "dateTimePicker_ChangeDate";
            this.dateTimePicker_ChangeDate.Size = new System.Drawing.Size(129, 21);
            this.dateTimePicker_ChangeDate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "签约编号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "变更日期";
            // 
            // FrmChangeAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 372);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.toolStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmChangeAdd";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增面积变更记录";
            this.Load += new System.EventHandler(this.FrmChangeAdd_Load);
            this.Shown += new System.EventHandler(this.FrmChangeAdd_Shown);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SaleItem)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox textBox_PaymentMode;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox_DownPayRate;
        private System.Windows.Forms.TextBox textBox_Loan;
        private System.Windows.Forms.TextBox textBox_DownPay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_TotalAmount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView_SaleItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_Installment;
        private System.Windows.Forms.ComboBox comboBox_ConfirmType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_Differ;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_NewTotalAmount;
        private System.Windows.Forms.TextBox textBox_NewDownPay;
        private System.Windows.Forms.TextBox textBox_NewLoan;
        private System.Windows.Forms.TextBox textBox_ContractNum;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ChangeDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_Memo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColConDID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBuilding;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNewArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNewAmount;
    }
}