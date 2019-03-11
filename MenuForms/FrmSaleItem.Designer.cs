namespace Commission.MenuForms
{
    partial class FrmSaleItem
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
            this.dataGridView_Item = new System.Windows.Forms.DataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Del = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Edit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_UnBind = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Bind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_All = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_None = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_SaleState = new System.Windows.Forms.ComboBox();
            this.button_Exit = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_ItemType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_ItemNum = new System.Windows.Forms.TextBox();
            this.textBox_Unit = new System.Windows.Forms.TextBox();
            this.textBox_Building = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Search = new System.Windows.Forms.Button();
            this.ColItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColBuilding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSaleStateCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSaleState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIsBind = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel1.Size = new System.Drawing.Size(933, 481);
            this.panel1.TabIndex = 1;
            // 
            // dataGridView_Item
            // 
            this.dataGridView_Item.AllowUserToAddRows = false;
            this.dataGridView_Item.AllowUserToDeleteRows = false;
            this.dataGridView_Item.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Item.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColItemID,
            this.ColCheck,
            this.ColBuilding,
            this.ColUnit,
            this.ColNum,
            this.ColArea,
            this.ColPrice,
            this.ColAmount,
            this.ColItemType,
            this.ColItemTypeName,
            this.ColSaleStateCode,
            this.ColSaleState,
            this.ColIsBind});
            this.dataGridView_Item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Item.Location = new System.Drawing.Point(3, 92);
            this.dataGridView_Item.Name = "dataGridView_Item";
            this.dataGridView_Item.RowHeadersWidth = 21;
            this.dataGridView_Item.RowTemplate.Height = 23;
            this.dataGridView_Item.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Item.Size = new System.Drawing.Size(927, 386);
            this.dataGridView_Item.TabIndex = 2;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Add,
            this.toolStripButton_Del,
            this.toolStripButton_Edit,
            this.toolStripButton_UnBind,
            this.toolStripButton_Bind,
            this.toolStripSeparator1,
            this.toolStripButton_All,
            this.toolStripButton_None});
            this.toolStrip2.Location = new System.Drawing.Point(3, 61);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(927, 31);
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
            this.toolStripButton_Edit.ToolTipText = "仅修改光标定位的一条记录";
            this.toolStripButton_Edit.Click += new System.EventHandler(this.toolStripButton_Edit_Click);
            // 
            // toolStripButton_UnBind
            // 
            this.toolStripButton_UnBind.Image = global::Commission.Properties.Resources.file_apply_24;
            this.toolStripButton_UnBind.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_UnBind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_UnBind.Name = "toolStripButton_UnBind";
            this.toolStripButton_UnBind.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_UnBind.Text = "主售";
            this.toolStripButton_UnBind.ToolTipText = "仅修改光标定位的一条记录";
            this.toolStripButton_UnBind.Click += new System.EventHandler(this.toolStripButton_UnBind_Click);
            // 
            // toolStripButton_Bind
            // 
            this.toolStripButton_Bind.Image = global::Commission.Properties.Resources.file_lock_24;
            this.toolStripButton_Bind.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Bind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Bind.Name = "toolStripButton_Bind";
            this.toolStripButton_Bind.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_Bind.Text = "附属";
            this.toolStripButton_Bind.ToolTipText = "仅修改光标定位的一条记录";
            this.toolStripButton_Bind.Click += new System.EventHandler(this.toolStripButton_Bind_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
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
            this.groupBox1.Controls.Add(this.comboBox_ItemType);
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
            this.groupBox1.Size = new System.Drawing.Size(927, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "销售项目查询";
            // 
            // comboBox_SaleState
            // 
            this.comboBox_SaleState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SaleState.FormattingEnabled = true;
            this.comboBox_SaleState.Location = new System.Drawing.Point(473, 22);
            this.comboBox_SaleState.Name = "comboBox_SaleState";
            this.comboBox_SaleState.Size = new System.Drawing.Size(100, 20);
            this.comboBox_SaleState.TabIndex = 18;
            // 
            // button_Exit
            // 
            this.button_Exit.Image = global::Commission.Properties.Resources.exit;
            this.button_Exit.Location = new System.Drawing.Point(660, 20);
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
            this.label7.Location = new System.Drawing.Point(438, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "状态";
            // 
            // comboBox_ItemType
            // 
            this.comboBox_ItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ItemType.FormattingEnabled = true;
            this.comboBox_ItemType.Location = new System.Drawing.Point(332, 23);
            this.comboBox_ItemType.Name = "comboBox_ItemType";
            this.comboBox_ItemType.Size = new System.Drawing.Size(100, 20);
            this.comboBox_ItemType.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(297, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "类型";
            // 
            // textBox_ItemNum
            // 
            this.textBox_ItemNum.Location = new System.Drawing.Point(228, 22);
            this.textBox_ItemNum.Name = "textBox_ItemNum";
            this.textBox_ItemNum.Size = new System.Drawing.Size(63, 21);
            this.textBox_ItemNum.TabIndex = 8;
            // 
            // textBox_Unit
            // 
            this.textBox_Unit.Location = new System.Drawing.Point(137, 22);
            this.textBox_Unit.Name = "textBox_Unit";
            this.textBox_Unit.Size = new System.Drawing.Size(50, 21);
            this.textBox_Unit.TabIndex = 7;
            // 
            // textBox_Building
            // 
            this.textBox_Building.Location = new System.Drawing.Point(46, 22);
            this.textBox_Building.Name = "textBox_Building";
            this.textBox_Building.Size = new System.Drawing.Size(50, 21);
            this.textBox_Building.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(193, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "编号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "单元";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "楼号";
            // 
            // button_Search
            // 
            this.button_Search.Image = global::Commission.Properties.Resources.Find_16;
            this.button_Search.Location = new System.Drawing.Point(579, 20);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(75, 23);
            this.button_Search.TabIndex = 1;
            this.button_Search.Text = " 查询";
            this.button_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // ColItemID
            // 
            this.ColItemID.DataPropertyName = "ItemID";
            this.ColItemID.HeaderText = "ItemID";
            this.ColItemID.Name = "ColItemID";
            this.ColItemID.ReadOnly = true;
            this.ColItemID.Visible = false;
            // 
            // ColCheck
            // 
            this.ColCheck.DataPropertyName = "Choose";
            this.ColCheck.FalseValue = "0";
            this.ColCheck.FillWeight = 75F;
            this.ColCheck.HeaderText = "选择";
            this.ColCheck.Name = "ColCheck";
            this.ColCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColCheck.TrueValue = "1";
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
            this.ColNum.Width = 80;
            // 
            // ColArea
            // 
            this.ColArea.DataPropertyName = "Area";
            this.ColArea.HeaderText = "面积";
            this.ColArea.Name = "ColArea";
            this.ColArea.ReadOnly = true;
            // 
            // ColPrice
            // 
            this.ColPrice.DataPropertyName = "Price";
            this.ColPrice.HeaderText = "单价";
            this.ColPrice.Name = "ColPrice";
            this.ColPrice.ReadOnly = true;
            // 
            // ColAmount
            // 
            this.ColAmount.DataPropertyName = "Amount";
            this.ColAmount.HeaderText = "总价";
            this.ColAmount.Name = "ColAmount";
            this.ColAmount.ReadOnly = true;
            // 
            // ColItemType
            // 
            this.ColItemType.DataPropertyName = "ItemTypeCode";
            this.ColItemType.HeaderText = "类型编号";
            this.ColItemType.Name = "ColItemType";
            this.ColItemType.ReadOnly = true;
            this.ColItemType.Visible = false;
            // 
            // ColItemTypeName
            // 
            this.ColItemTypeName.DataPropertyName = "ItemTypeName";
            this.ColItemTypeName.HeaderText = "房源类型";
            this.ColItemTypeName.Name = "ColItemTypeName";
            this.ColItemTypeName.ReadOnly = true;
            this.ColItemTypeName.Width = 80;
            // 
            // ColSaleStateCode
            // 
            this.ColSaleStateCode.DataPropertyName = "SaleStateCode";
            this.ColSaleStateCode.HeaderText = "SaleStateCode";
            this.ColSaleStateCode.Name = "ColSaleStateCode";
            this.ColSaleStateCode.Visible = false;
            // 
            // ColSaleState
            // 
            this.ColSaleState.DataPropertyName = "SaleStateName";
            this.ColSaleState.HeaderText = "销售状态";
            this.ColSaleState.Name = "ColSaleState";
            // 
            // ColIsBind
            // 
            this.ColIsBind.DataPropertyName = "IsBind";
            this.ColIsBind.HeaderText = "附属物业";
            this.ColIsBind.Name = "ColIsBind";
            // 
            // FrmSaleItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 481);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSaleItem";
            this.Text = "楼盘信息";
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
        private System.Windows.Forms.ToolStripButton toolStripButton_All;
        private System.Windows.Forms.ComboBox comboBox_SaleState;
        private System.Windows.Forms.ToolStripButton toolStripButton_Bind;
        private System.Windows.Forms.ToolStripButton toolStripButton_UnBind;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBuilding;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSaleStateCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSaleState;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIsBind;
    }
}