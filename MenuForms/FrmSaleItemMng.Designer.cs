namespace Commission.MenuForms
{
    partial class FrmSaleItemMng
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSaleItemMng));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView_Item = new System.Windows.Forms.DataGridView();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColBuilding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIsBind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSaleStateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPayModeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPayModeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPayTypeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPayTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSettleStandardName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSettleBaseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSettleRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSpecialAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIsLocking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBottomPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBottomPriceRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBottomPriceLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Del = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Edit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Export = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Settle = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Bottom = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Up = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Rate = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Locking = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Unlock = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_CloseCase = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Recovery = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_All = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_None = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_SaleState = new System.Windows.Forms.ComboBox();
            this.button_Exit = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_PayType = new System.Windows.Forms.ComboBox();
            this.comboBox_ItemType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_ItemNum = new System.Windows.Forms.TextBox();
            this.textBox_Unit = new System.Windows.Forms.TextBox();
            this.textBox_Building = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Search = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Item)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView_Item);
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.panel1.Size = new System.Drawing.Size(1016, 492);
            this.panel1.TabIndex = 1;
            // 
            // dataGridView_Item
            // 
            this.dataGridView_Item.AllowUserToAddRows = false;
            this.dataGridView_Item.AllowUserToDeleteRows = false;
            this.dataGridView_Item.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Item.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColCheck,
            this.ColBuilding,
            this.ColUnit,
            this.ColNum,
            this.ColArea,
            this.ColPrice,
            this.ColAmount,
            this.ColItemTypeName,
            this.ColIsBind,
            this.ColSaleStateName,
            this.ColPayModeID,
            this.ColPayModeName,
            this.ColPayTypeCode,
            this.ColPayTypeName,
            this.ColSettleStandardName,
            this.ColSettleBaseName,
            this.ColSettleRate,
            this.ColSpecialAmount,
            this.ColIsLocking,
            this.ColUpName,
            this.ColBottomPrice,
            this.ColBottomPriceRate,
            this.ColBottomPriceLimit});
            this.dataGridView_Item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Item.Location = new System.Drawing.Point(3, 93);
            this.dataGridView_Item.Name = "dataGridView_Item";
            this.dataGridView_Item.RowHeadersWidth = 21;
            this.dataGridView_Item.RowTemplate.Height = 23;
            this.dataGridView_Item.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Item.Size = new System.Drawing.Size(1010, 396);
            this.dataGridView_Item.TabIndex = 2;
            // 
            // ColID
            // 
            this.ColID.DataPropertyName = "ItemID";
            this.ColID.HeaderText = "ID";
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            this.ColID.Visible = false;
            // 
            // ColCheck
            // 
            this.ColCheck.DataPropertyName = "Choose";
            this.ColCheck.FalseValue = "false";
            this.ColCheck.FillWeight = 75F;
            this.ColCheck.HeaderText = "选择";
            this.ColCheck.Name = "ColCheck";
            this.ColCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColCheck.TrueValue = "true";
            this.ColCheck.Width = 60;
            // 
            // ColBuilding
            // 
            this.ColBuilding.DataPropertyName = "Building";
            this.ColBuilding.HeaderText = "楼号";
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
            this.ColUnit.Width = 60;
            // 
            // ColNum
            // 
            this.ColNum.DataPropertyName = "ItemNum";
            this.ColNum.HeaderText = "房号";
            this.ColNum.Name = "ColNum";
            this.ColNum.ReadOnly = true;
            this.ColNum.Width = 60;
            // 
            // ColArea
            // 
            this.ColArea.DataPropertyName = "Area";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0";
            this.ColArea.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColArea.FillWeight = 60F;
            this.ColArea.HeaderText = "面积";
            this.ColArea.Name = "ColArea";
            this.ColArea.ReadOnly = true;
            this.ColArea.Width = 60;
            // 
            // ColPrice
            // 
            this.ColPrice.DataPropertyName = "Price";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.NullValue = "0";
            this.ColPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColPrice.HeaderText = "单价";
            this.ColPrice.Name = "ColPrice";
            this.ColPrice.ReadOnly = true;
            this.ColPrice.Width = 60;
            // 
            // ColAmount
            // 
            this.ColAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "G0";
            this.ColAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColAmount.HeaderText = "总价";
            this.ColAmount.Name = "ColAmount";
            this.ColAmount.ReadOnly = true;
            this.ColAmount.Width = 80;
            // 
            // ColItemTypeName
            // 
            this.ColItemTypeName.DataPropertyName = "ItemTypeName";
            this.ColItemTypeName.HeaderText = "类型";
            this.ColItemTypeName.Name = "ColItemTypeName";
            this.ColItemTypeName.ReadOnly = true;
            this.ColItemTypeName.Width = 80;
            // 
            // ColIsBind
            // 
            this.ColIsBind.DataPropertyName = "IsBind";
            this.ColIsBind.HeaderText = "附属物业";
            this.ColIsBind.Name = "ColIsBind";
            this.ColIsBind.Visible = false;
            this.ColIsBind.Width = 80;
            // 
            // ColSaleStateName
            // 
            this.ColSaleStateName.DataPropertyName = "SaleStateName";
            this.ColSaleStateName.HeaderText = "销售状态";
            this.ColSaleStateName.Name = "ColSaleStateName";
            this.ColSaleStateName.ReadOnly = true;
            this.ColSaleStateName.Width = 80;
            // 
            // ColPayModeID
            // 
            this.ColPayModeID.DataPropertyName = "PayModeID";
            this.ColPayModeID.HeaderText = "PayModeID";
            this.ColPayModeID.Name = "ColPayModeID";
            this.ColPayModeID.Visible = false;
            // 
            // ColPayModeName
            // 
            this.ColPayModeName.DataPropertyName = "PayModeName";
            this.ColPayModeName.HeaderText = "付款方式";
            this.ColPayModeName.Name = "ColPayModeName";
            // 
            // ColPayTypeCode
            // 
            this.ColPayTypeCode.DataPropertyName = "PayTypeCode";
            this.ColPayTypeCode.HeaderText = "PayTypeCode";
            this.ColPayTypeCode.Name = "ColPayTypeCode";
            this.ColPayTypeCode.Visible = false;
            // 
            // ColPayTypeName
            // 
            this.ColPayTypeName.DataPropertyName = "PayTypeName";
            this.ColPayTypeName.HeaderText = "付款类型";
            this.ColPayTypeName.Name = "ColPayTypeName";
            // 
            // ColSettleStandardName
            // 
            this.ColSettleStandardName.DataPropertyName = "SettleStandardName";
            this.ColSettleStandardName.HeaderText = "结算条件";
            this.ColSettleStandardName.Name = "ColSettleStandardName";
            this.ColSettleStandardName.ReadOnly = true;
            this.ColSettleStandardName.Width = 80;
            // 
            // ColSettleBaseName
            // 
            this.ColSettleBaseName.DataPropertyName = "SettleBaseName";
            this.ColSettleBaseName.HeaderText = "结算基数";
            this.ColSettleBaseName.Name = "ColSettleBaseName";
            this.ColSettleBaseName.ReadOnly = true;
            this.ColSettleBaseName.Width = 80;
            // 
            // ColSettleRate
            // 
            this.ColSettleRate.DataPropertyName = "SettleRate";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColSettleRate.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColSettleRate.HeaderText = "结算比例";
            this.ColSettleRate.Name = "ColSettleRate";
            this.ColSettleRate.ReadOnly = true;
            this.ColSettleRate.Width = 80;
            // 
            // ColSpecialAmount
            // 
            this.ColSpecialAmount.DataPropertyName = "SettleAmount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "F0";
            this.ColSpecialAmount.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColSpecialAmount.HeaderText = "单套金额";
            this.ColSpecialAmount.Name = "ColSpecialAmount";
            this.ColSpecialAmount.ReadOnly = true;
            this.ColSpecialAmount.Width = 80;
            // 
            // ColIsLocking
            // 
            this.ColIsLocking.DataPropertyName = "IsLocking";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColIsLocking.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColIsLocking.HeaderText = "提点锁定";
            this.ColIsLocking.Name = "ColIsLocking";
            // 
            // ColUpName
            // 
            this.ColUpName.DataPropertyName = "UpName";
            this.ColUpName.HeaderText = "跳点名称";
            this.ColUpName.Name = "ColUpName";
            this.ColUpName.Width = 80;
            // 
            // ColBottomPrice
            // 
            this.ColBottomPrice.DataPropertyName = "BottomPrice";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "F4";
            dataGridViewCellStyle7.NullValue = "0";
            this.ColBottomPrice.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColBottomPrice.HeaderText = "底价";
            this.ColBottomPrice.Name = "ColBottomPrice";
            this.ColBottomPrice.ReadOnly = true;
            this.ColBottomPrice.Width = 80;
            // 
            // ColBottomPriceRate
            // 
            this.ColBottomPriceRate.DataPropertyName = "BottomPriceRate";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColBottomPriceRate.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColBottomPriceRate.HeaderText = "溢价分成";
            this.ColBottomPriceRate.Name = "ColBottomPriceRate";
            this.ColBottomPriceRate.ReadOnly = true;
            this.ColBottomPriceRate.Width = 80;
            // 
            // ColBottomPriceLimit
            // 
            this.ColBottomPriceLimit.DataPropertyName = "BottomPriceLimit";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "F0";
            this.ColBottomPriceLimit.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColBottomPriceLimit.HeaderText = "溢价限价";
            this.ColBottomPriceLimit.Name = "ColBottomPriceLimit";
            this.ColBottomPriceLimit.ReadOnly = true;
            this.ColBottomPriceLimit.Width = 80;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Add,
            this.toolStripButton_Del,
            this.toolStripButton_Edit,
            this.toolStripButton_Export,
            this.toolStripSeparator1,
            this.toolStripButton_Bottom,
            this.toolStripButton_Settle,
            this.toolStripButton_Rate,
            this.toolStripButton_Up,
            this.toolStripButton_Locking,
            this.toolStripButton_Unlock,
            this.toolStripButton_CloseCase,
            this.toolStripButton_Recovery,
            this.toolStripSeparator2,
            this.toolStripButton_All,
            this.toolStripButton_None});
            this.toolStrip2.Location = new System.Drawing.Point(3, 62);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1010, 31);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton_Add
            // 
            this.toolStripButton_Add.Image = global::Commission.Properties.Resources.file_new;
            this.toolStripButton_Add.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Add.Name = "toolStripButton_Add";
            this.toolStripButton_Add.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_Add.Text = "新增";
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
            this.toolStripButton_Del.Click += new System.EventHandler(this.toolStripButton_Del_Click);
            // 
            // toolStripButton_Edit
            // 
            this.toolStripButton_Edit.Image = global::Commission.Properties.Resources.file_edit;
            this.toolStripButton_Edit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Edit.Name = "toolStripButton_Edit";
            this.toolStripButton_Edit.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_Edit.Text = "修改";
            this.toolStripButton_Edit.Click += new System.EventHandler(this.toolStripButton_Edit_Click);
            // 
            // toolStripButton_Export
            // 
            this.toolStripButton_Export.Image = global::Commission.Properties.Resources.export_24;
            this.toolStripButton_Export.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Export.Name = "toolStripButton_Export";
            this.toolStripButton_Export.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_Export.Text = "导出";
            this.toolStripButton_Export.Click += new System.EventHandler(this.toolStripButton_Export_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButton_Settle
            // 
            this.toolStripButton_Settle.Image = global::Commission.Properties.Resources.calculator;
            this.toolStripButton_Settle.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Settle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Settle.Name = "toolStripButton_Settle";
            this.toolStripButton_Settle.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_Settle.Text = "结算";
            this.toolStripButton_Settle.Click += new System.EventHandler(this.toolStripButton_Settle_Click);
            // 
            // toolStripButton_Bottom
            // 
            this.toolStripButton_Bottom.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Bottom.Image")));
            this.toolStripButton_Bottom.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Bottom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Bottom.Name = "toolStripButton_Bottom";
            this.toolStripButton_Bottom.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_Bottom.Text = "底价";
            this.toolStripButton_Bottom.Click += new System.EventHandler(this.toolStripButton_Bottom_Click);
            // 
            // toolStripButton_Up
            // 
            this.toolStripButton_Up.Image = global::Commission.Properties.Resources.chart_up1_24;
            this.toolStripButton_Up.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Up.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Up.Name = "toolStripButton_Up";
            this.toolStripButton_Up.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_Up.Text = "跳点";
            this.toolStripButton_Up.Click += new System.EventHandler(this.toolStripButton_Up_Click);
            // 
            // toolStripButton_Rate
            // 
            this.toolStripButton_Rate.Image = global::Commission.Properties.Resources.checkmark_24;
            this.toolStripButton_Rate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Rate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Rate.Name = "toolStripButton_Rate";
            this.toolStripButton_Rate.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_Rate.Text = "提点";
            this.toolStripButton_Rate.Click += new System.EventHandler(this.toolStripButton_Rate_Click);
            // 
            // toolStripButton_Locking
            // 
            this.toolStripButton_Locking.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Locking.Image")));
            this.toolStripButton_Locking.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Locking.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Locking.Name = "toolStripButton_Locking";
            this.toolStripButton_Locking.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_Locking.Text = "锁定";
            this.toolStripButton_Locking.Click += new System.EventHandler(this.toolStripButton_Locking_Click);
            // 
            // toolStripButton_Unlock
            // 
            this.toolStripButton_Unlock.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Unlock.Image")));
            this.toolStripButton_Unlock.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Unlock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Unlock.Name = "toolStripButton_Unlock";
            this.toolStripButton_Unlock.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_Unlock.Text = "解锁";
            this.toolStripButton_Unlock.Click += new System.EventHandler(this.toolStripButton_Unlock_Click);
            // 
            // toolStripButton_CloseCase
            // 
            this.toolStripButton_CloseCase.Image = global::Commission.Properties.Resources.checkmark_24;
            this.toolStripButton_CloseCase.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_CloseCase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_CloseCase.Name = "toolStripButton_CloseCase";
            this.toolStripButton_CloseCase.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_CloseCase.Text = "结案";
            this.toolStripButton_CloseCase.Visible = false;
            this.toolStripButton_CloseCase.Click += new System.EventHandler(this.toolStripButton_CloseCase_Click);
            // 
            // toolStripButton_Recovery
            // 
            this.toolStripButton_Recovery.Image = global::Commission.Properties.Resources.recycle_24;
            this.toolStripButton_Recovery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Recovery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Recovery.Name = "toolStripButton_Recovery";
            this.toolStripButton_Recovery.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_Recovery.Text = "恢复";
            this.toolStripButton_Recovery.Visible = false;
            this.toolStripButton_Recovery.Click += new System.EventHandler(this.toolStripButton_Recovery_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_SaleState);
            this.groupBox1.Controls.Add(this.button_Exit);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.comboBox_PayType);
            this.groupBox1.Controls.Add(this.comboBox_ItemType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox_ItemNum);
            this.groupBox1.Controls.Add(this.textBox_Unit);
            this.groupBox1.Controls.Add(this.textBox_Building);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button_Search);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1010, 57);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "销售项目查询";
            // 
            // comboBox_SaleState
            // 
            this.comboBox_SaleState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SaleState.FormattingEnabled = true;
            this.comboBox_SaleState.Location = new System.Drawing.Point(684, 23);
            this.comboBox_SaleState.Name = "comboBox_SaleState";
            this.comboBox_SaleState.Size = new System.Drawing.Size(100, 20);
            this.comboBox_SaleState.TabIndex = 18;
            // 
            // button_Exit
            // 
            this.button_Exit.Image = global::Commission.Properties.Resources.exit;
            this.button_Exit.Location = new System.Drawing.Point(871, 21);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(75, 23);
            this.button_Exit.TabIndex = 17;
            this.button_Exit.Text = " 关闭";
            this.button_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(625, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "销售状态";
            // 
            // comboBox_PayType
            // 
            this.comboBox_PayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_PayType.FormattingEnabled = true;
            this.comboBox_PayType.Location = new System.Drawing.Point(519, 23);
            this.comboBox_PayType.Name = "comboBox_PayType";
            this.comboBox_PayType.Size = new System.Drawing.Size(100, 20);
            this.comboBox_PayType.TabIndex = 10;
            // 
            // comboBox_ItemType
            // 
            this.comboBox_ItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ItemType.FormattingEnabled = true;
            this.comboBox_ItemType.Location = new System.Drawing.Point(354, 23);
            this.comboBox_ItemType.Name = "comboBox_ItemType";
            this.comboBox_ItemType.Size = new System.Drawing.Size(100, 20);
            this.comboBox_ItemType.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(460, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "付款类型";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(295, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "房源类型";
            // 
            // textBox_ItemNum
            // 
            this.textBox_ItemNum.Location = new System.Drawing.Point(226, 23);
            this.textBox_ItemNum.Name = "textBox_ItemNum";
            this.textBox_ItemNum.Size = new System.Drawing.Size(63, 21);
            this.textBox_ItemNum.TabIndex = 8;
            // 
            // textBox_Unit
            // 
            this.textBox_Unit.Location = new System.Drawing.Point(135, 23);
            this.textBox_Unit.Name = "textBox_Unit";
            this.textBox_Unit.Size = new System.Drawing.Size(50, 21);
            this.textBox_Unit.TabIndex = 7;
            // 
            // textBox_Building
            // 
            this.textBox_Building.Location = new System.Drawing.Point(44, 23);
            this.textBox_Building.Name = "textBox_Building";
            this.textBox_Building.Size = new System.Drawing.Size(50, 21);
            this.textBox_Building.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(191, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "编号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "单元";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "楼号";
            // 
            // button_Search
            // 
            this.button_Search.Image = global::Commission.Properties.Resources.Find_16;
            this.button_Search.Location = new System.Drawing.Point(790, 22);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(75, 23);
            this.button_Search.TabIndex = 1;
            this.button_Search.Text = " 查询";
            this.button_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // FrmSaleItemMng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 492);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSaleItemMng";
            this.Text = "楼盘设置";
            this.Shown += new System.EventHandler(this.FrmSaleItem_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Item)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Add;
        private System.Windows.Forms.ToolStripButton toolStripButton_None;
        private System.Windows.Forms.DataGridView dataGridView_Item;
        private System.Windows.Forms.ToolStripButton toolStripButton_Del;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.TextBox textBox_ItemNum;
        private System.Windows.Forms.TextBox textBox_Unit;
        private System.Windows.Forms.TextBox textBox_Building;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Edit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_ItemType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Settle;
        private System.Windows.Forms.ToolStripButton toolStripButton_Bottom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_All;
        private System.Windows.Forms.ComboBox comboBox_SaleState;
        private System.Windows.Forms.ToolStripButton toolStripButton_CloseCase;
        private System.Windows.Forms.ToolStripButton toolStripButton_Recovery;
        private System.Windows.Forms.ToolStripButton toolStripButton_Up;
        private System.Windows.Forms.ToolStripButton toolStripButton_Export;
        private System.Windows.Forms.ComboBox comboBox_PayType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Unlock;
        private System.Windows.Forms.ToolStripButton toolStripButton_Rate;
        private System.Windows.Forms.ToolStripButton toolStripButton_Locking;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBuilding;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIsBind;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSaleStateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPayModeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPayModeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPayTypeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPayTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSettleStandardName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSettleBaseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSettleRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSpecialAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIsLocking;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBottomPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBottomPriceRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBottomPriceLimit;
    }
}