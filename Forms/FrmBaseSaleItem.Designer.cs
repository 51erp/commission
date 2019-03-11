namespace Commission.Forms
{
    partial class FrmBaseSaleItem
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
            this.toolStrip_Menu = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_OK = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Canel = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_ItemType = new System.Windows.Forms.ComboBox();
            this.button_Search = new System.Windows.Forms.Button();
            this.textBox_ItemNum = new System.Windows.Forms.TextBox();
            this.textBox_Unit = new System.Windows.Forms.TextBox();
            this.textBox_Building = new System.Windows.Forms.TextBox();
            this.label_ItemType = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView_Item = new System.Windows.Forms.DataGridView();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBuilding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIsBind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip_Menu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Item)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip_Menu
            // 
            this.toolStrip_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_OK,
            this.toolStripButton_Canel});
            this.toolStrip_Menu.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_Menu.Name = "toolStrip_Menu";
            this.toolStrip_Menu.Size = new System.Drawing.Size(617, 25);
            this.toolStrip_Menu.TabIndex = 1;
            this.toolStrip_Menu.Text = "toolStrip1";
            // 
            // toolStripButton_OK
            // 
            this.toolStripButton_OK.Image = global::Commission.Properties.Resources.OK;
            this.toolStripButton_OK.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_OK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_OK.Name = "toolStripButton_OK";
            this.toolStripButton_OK.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton_OK.Text = "确认";
            this.toolStripButton_OK.Click += new System.EventHandler(this.toolStripButton_OK_Click);
            // 
            // toolStripButton_Canel
            // 
            this.toolStripButton_Canel.Image = global::Commission.Properties.Resources.back;
            this.toolStripButton_Canel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Canel.Name = "toolStripButton_Canel";
            this.toolStripButton_Canel.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton_Canel.Text = "取消";
            this.toolStripButton_Canel.Click += new System.EventHandler(this.toolStripButton_Canel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(617, 48);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_ItemType);
            this.groupBox1.Controls.Add(this.button_Search);
            this.groupBox1.Controls.Add(this.textBox_ItemNum);
            this.groupBox1.Controls.Add(this.textBox_Unit);
            this.groupBox1.Controls.Add(this.textBox_Building);
            this.groupBox1.Controls.Add(this.label_ItemType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(617, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // comboBox_ItemType
            // 
            this.comboBox_ItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ItemType.FormattingEnabled = true;
            this.comboBox_ItemType.Location = new System.Drawing.Point(424, 13);
            this.comboBox_ItemType.Name = "comboBox_ItemType";
            this.comboBox_ItemType.Size = new System.Drawing.Size(100, 20);
            this.comboBox_ItemType.TabIndex = 16;
            // 
            // button_Search
            // 
            this.button_Search.Image = global::Commission.Properties.Resources.Find_16;
            this.button_Search.Location = new System.Drawing.Point(530, 12);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(75, 23);
            this.button_Search.TabIndex = 15;
            this.button_Search.Text = " 查询";
            this.button_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // textBox_ItemNum
            // 
            this.textBox_ItemNum.Location = new System.Drawing.Point(283, 13);
            this.textBox_ItemNum.Name = "textBox_ItemNum";
            this.textBox_ItemNum.Size = new System.Drawing.Size(100, 21);
            this.textBox_ItemNum.TabIndex = 14;
            // 
            // textBox_Unit
            // 
            this.textBox_Unit.Location = new System.Drawing.Point(162, 13);
            this.textBox_Unit.Name = "textBox_Unit";
            this.textBox_Unit.Size = new System.Drawing.Size(80, 21);
            this.textBox_Unit.TabIndex = 13;
            // 
            // textBox_Building
            // 
            this.textBox_Building.Location = new System.Drawing.Point(41, 13);
            this.textBox_Building.Name = "textBox_Building";
            this.textBox_Building.Size = new System.Drawing.Size(80, 21);
            this.textBox_Building.TabIndex = 12;
            // 
            // label_ItemType
            // 
            this.label_ItemType.AutoSize = true;
            this.label_ItemType.Location = new System.Drawing.Point(389, 18);
            this.label_ItemType.Name = "label_ItemType";
            this.label_ItemType.Size = new System.Drawing.Size(29, 12);
            this.label_ItemType.TabIndex = 11;
            this.label_ItemType.Text = "类型";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(248, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "房号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "单元";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "楼号";
            // 
            // dataGridView_Item
            // 
            this.dataGridView_Item.AllowUserToAddRows = false;
            this.dataGridView_Item.AllowUserToDeleteRows = false;
            this.dataGridView_Item.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Item.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColBuilding,
            this.ColUnit,
            this.ColNum,
            this.ColArea,
            this.ColPrice,
            this.ColItemType,
            this.ColIsBind});
            this.dataGridView_Item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Item.Location = new System.Drawing.Point(0, 73);
            this.dataGridView_Item.MultiSelect = false;
            this.dataGridView_Item.Name = "dataGridView_Item";
            this.dataGridView_Item.ReadOnly = true;
            this.dataGridView_Item.RowHeadersWidth = 21;
            this.dataGridView_Item.RowTemplate.Height = 23;
            this.dataGridView_Item.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Item.Size = new System.Drawing.Size(617, 355);
            this.dataGridView_Item.TabIndex = 4;
            this.dataGridView_Item.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Item_CellDoubleClick);
            // 
            // ColID
            // 
            this.ColID.DataPropertyName = "ItemID";
            this.ColID.HeaderText = "ID";
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            this.ColID.Visible = false;
            // 
            // ColBuilding
            // 
            this.ColBuilding.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColBuilding.DataPropertyName = "Building";
            this.ColBuilding.HeaderText = "楼号";
            this.ColBuilding.Name = "ColBuilding";
            this.ColBuilding.ReadOnly = true;
            this.ColBuilding.Width = 60;
            // 
            // ColUnit
            // 
            this.ColUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColUnit.DataPropertyName = "Unit";
            this.ColUnit.HeaderText = "单元";
            this.ColUnit.Name = "ColUnit";
            this.ColUnit.ReadOnly = true;
            this.ColUnit.Width = 60;
            // 
            // ColNum
            // 
            this.ColNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
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
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ColArea.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColArea.HeaderText = "面积";
            this.ColArea.Name = "ColArea";
            this.ColArea.ReadOnly = true;
            // 
            // ColPrice
            // 
            this.ColPrice.DataPropertyName = "Price";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "F0";
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ColPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColPrice.HeaderText = "单价";
            this.ColPrice.Name = "ColPrice";
            this.ColPrice.ReadOnly = true;
            // 
            // ColItemType
            // 
            this.ColItemType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColItemType.DataPropertyName = "ItemTypeName";
            this.ColItemType.HeaderText = "类型";
            this.ColItemType.Name = "ColItemType";
            this.ColItemType.ReadOnly = true;
            this.ColItemType.Width = 80;
            // 
            // ColIsBind
            // 
            this.ColIsBind.DataPropertyName = "IsBind";
            this.ColIsBind.HeaderText = "附属物业";
            this.ColIsBind.Name = "ColIsBind";
            this.ColIsBind.ReadOnly = true;
            this.ColIsBind.Width = 80;
            // 
            // FrmBaseSaleItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 428);
            this.Controls.Add(this.dataGridView_Item);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip_Menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmBaseSaleItem";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "房源基本信息";
            this.Load += new System.EventHandler(this.FrmBaseSaleItem_Load);
            this.toolStrip_Menu.ResumeLayout(false);
            this.toolStrip_Menu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Item)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip_Menu;
        private System.Windows.Forms.ToolStripButton toolStripButton_OK;
        private System.Windows.Forms.ToolStripButton toolStripButton_Canel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_ItemNum;
        private System.Windows.Forms.TextBox textBox_Unit;
        private System.Windows.Forms.TextBox textBox_Building;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.DataGridView dataGridView_Item;
        private System.Windows.Forms.Label label_ItemType;
        private System.Windows.Forms.ComboBox comboBox_ItemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBuilding;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIsBind;
    }
}