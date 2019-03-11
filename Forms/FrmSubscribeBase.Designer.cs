namespace Commission.Forms
{
    partial class FrmSubscribeBase
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
            this.toolStrip_Menu = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_OK = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Canel = new System.Windows.Forms.ToolStripButton();
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
            this.button_Search = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_SubscribeMain = new System.Windows.Forms.DataGridView();
            this.ColSubscribeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCustomerPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSubscribeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSalesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView_SubscribeDetail = new System.Windows.Forms.DataGridView();
            this.ColTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBuilding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip_Menu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SubscribeMain)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SubscribeDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip_Menu
            // 
            this.toolStrip_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_OK,
            this.toolStripButton_Canel});
            this.toolStrip_Menu.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_Menu.Name = "toolStrip_Menu";
            this.toolStrip_Menu.Size = new System.Drawing.Size(760, 25);
            this.toolStrip_Menu.TabIndex = 2;
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
            this.groupBox1.Controls.Add(this.button_Search);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 73);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // textBox_Phone
            // 
            this.textBox_Phone.Location = new System.Drawing.Point(266, 19);
            this.textBox_Phone.Name = "textBox_Phone";
            this.textBox_Phone.Size = new System.Drawing.Size(100, 21);
            this.textBox_Phone.TabIndex = 15;
            // 
            // textBox_CusName
            // 
            this.textBox_CusName.Location = new System.Drawing.Point(77, 19);
            this.textBox_CusName.Name = "textBox_CusName";
            this.textBox_CusName.Size = new System.Drawing.Size(121, 21);
            this.textBox_CusName.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(207, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "联系电话";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "客户姓名";
            // 
            // textBox_ItemNum
            // 
            this.textBox_ItemNum.Location = new System.Drawing.Point(407, 45);
            this.textBox_ItemNum.Name = "textBox_ItemNum";
            this.textBox_ItemNum.Size = new System.Drawing.Size(100, 21);
            this.textBox_ItemNum.TabIndex = 8;
            // 
            // textBox_Unit
            // 
            this.textBox_Unit.Location = new System.Drawing.Point(266, 45);
            this.textBox_Unit.Name = "textBox_Unit";
            this.textBox_Unit.Size = new System.Drawing.Size(100, 21);
            this.textBox_Unit.TabIndex = 7;
            // 
            // textBox_Building
            // 
            this.textBox_Building.Location = new System.Drawing.Point(77, 45);
            this.textBox_Building.Name = "textBox_Building";
            this.textBox_Building.Size = new System.Drawing.Size(121, 21);
            this.textBox_Building.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(372, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "编号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(207, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "单元";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "楼号";
            // 
            // button_Search
            // 
            this.button_Search.Image = global::Commission.Properties.Resources.Find_16;
            this.button_Search.Location = new System.Drawing.Point(513, 44);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(75, 23);
            this.button_Search.TabIndex = 1;
            this.button_Search.Text = " 查询";
            this.button_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 98);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.splitContainer1.Size = new System.Drawing.Size(760, 431);
            this.splitContainer1.SplitterDistance = 254;
            this.splitContainer1.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView_SubscribeMain);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.groupBox2.Size = new System.Drawing.Size(760, 251);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "认购信息";
            // 
            // dataGridView_SubscribeMain
            // 
            this.dataGridView_SubscribeMain.AllowUserToAddRows = false;
            this.dataGridView_SubscribeMain.AllowUserToDeleteRows = false;
            this.dataGridView_SubscribeMain.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView_SubscribeMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SubscribeMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSubscribeID,
            this.ColCustomerName,
            this.ColCustomerPhone,
            this.ColTotal,
            this.ColSubscribeDate,
            this.ColSalesName});
            this.dataGridView_SubscribeMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_SubscribeMain.Location = new System.Drawing.Point(3, 19);
            this.dataGridView_SubscribeMain.MultiSelect = false;
            this.dataGridView_SubscribeMain.Name = "dataGridView_SubscribeMain";
            this.dataGridView_SubscribeMain.ReadOnly = true;
            this.dataGridView_SubscribeMain.RowHeadersWidth = 21;
            this.dataGridView_SubscribeMain.RowTemplate.Height = 23;
            this.dataGridView_SubscribeMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_SubscribeMain.Size = new System.Drawing.Size(754, 229);
            this.dataGridView_SubscribeMain.TabIndex = 1;
            this.dataGridView_SubscribeMain.SelectionChanged += new System.EventHandler(this.dataGridView_Transaction_SelectionChanged);
            this.dataGridView_SubscribeMain.DoubleClick += new System.EventHandler(this.toolStripButton_OK_Click);
            // 
            // ColSubscribeID
            // 
            this.ColSubscribeID.DataPropertyName = "SubscribeID";
            this.ColSubscribeID.HeaderText = "SubscribeID";
            this.ColSubscribeID.Name = "ColSubscribeID";
            this.ColSubscribeID.ReadOnly = true;
            this.ColSubscribeID.Visible = false;
            // 
            // ColCustomerName
            // 
            this.ColCustomerName.DataPropertyName = "CustomerName";
            this.ColCustomerName.HeaderText = "客户名称";
            this.ColCustomerName.Name = "ColCustomerName";
            this.ColCustomerName.ReadOnly = true;
            // 
            // ColCustomerPhone
            // 
            this.ColCustomerPhone.DataPropertyName = "CustomerPhone";
            this.ColCustomerPhone.HeaderText = "客户电话";
            this.ColCustomerPhone.Name = "ColCustomerPhone";
            this.ColCustomerPhone.ReadOnly = true;
            // 
            // ColTotal
            // 
            this.ColTotal.DataPropertyName = "TotalAmount";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "F0";
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ColTotal.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColTotal.HeaderText = "认购总额";
            this.ColTotal.Name = "ColTotal";
            this.ColTotal.ReadOnly = true;
            // 
            // ColSubscribeDate
            // 
            this.ColSubscribeDate.DataPropertyName = "SubscribeDate";
            this.ColSubscribeDate.HeaderText = "认购时间";
            this.ColSubscribeDate.Name = "ColSubscribeDate";
            this.ColSubscribeDate.ReadOnly = true;
            // 
            // ColSalesName
            // 
            this.ColSalesName.DataPropertyName = "SalesName";
            this.ColSalesName.HeaderText = "置业顾问";
            this.ColSalesName.Name = "ColSalesName";
            this.ColSalesName.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView_SubscribeDetail);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.groupBox3.Size = new System.Drawing.Size(760, 170);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "房产明细信息";
            // 
            // dataGridView_SubscribeDetail
            // 
            this.dataGridView_SubscribeDetail.AllowUserToAddRows = false;
            this.dataGridView_SubscribeDetail.AllowUserToDeleteRows = false;
            this.dataGridView_SubscribeDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView_SubscribeDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SubscribeDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColTypeName,
            this.ColItemID,
            this.ColBuilding,
            this.ColUnit,
            this.ColItemNum,
            this.ColArea,
            this.ColPrice,
            this.ColAmount});
            this.dataGridView_SubscribeDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_SubscribeDetail.Location = new System.Drawing.Point(3, 19);
            this.dataGridView_SubscribeDetail.MultiSelect = false;
            this.dataGridView_SubscribeDetail.Name = "dataGridView_SubscribeDetail";
            this.dataGridView_SubscribeDetail.ReadOnly = true;
            this.dataGridView_SubscribeDetail.RowHeadersWidth = 21;
            this.dataGridView_SubscribeDetail.RowTemplate.Height = 23;
            this.dataGridView_SubscribeDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_SubscribeDetail.Size = new System.Drawing.Size(754, 148);
            this.dataGridView_SubscribeDetail.TabIndex = 1;
            // 
            // ColTypeName
            // 
            this.ColTypeName.DataPropertyName = "ItemTypeName";
            this.ColTypeName.HeaderText = "房产类型";
            this.ColTypeName.Name = "ColTypeName";
            this.ColTypeName.ReadOnly = true;
            this.ColTypeName.Width = 78;
            // 
            // ColItemID
            // 
            this.ColItemID.DataPropertyName = "ItemID";
            this.ColItemID.HeaderText = "ItemID";
            this.ColItemID.Name = "ColItemID";
            this.ColItemID.ReadOnly = true;
            this.ColItemID.Visible = false;
            this.ColItemID.Width = 66;
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
            // ColArea
            // 
            this.ColArea.DataPropertyName = "Area";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ColArea.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColArea.HeaderText = "面积";
            this.ColArea.Name = "ColArea";
            this.ColArea.ReadOnly = true;
            this.ColArea.Width = 54;
            // 
            // ColPrice
            // 
            this.ColPrice.DataPropertyName = "Price";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "F0";
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ColPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColPrice.HeaderText = "单价";
            this.ColPrice.Name = "ColPrice";
            this.ColPrice.ReadOnly = true;
            this.ColPrice.Width = 54;
            // 
            // ColAmount
            // 
            this.ColAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "F0";
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ColAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColAmount.HeaderText = "金额";
            this.ColAmount.Name = "ColAmount";
            this.ColAmount.ReadOnly = true;
            this.ColAmount.Width = 54;
            // 
            // FrmSubscribeBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 529);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip_Menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSubscribeBase";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "房产认购基本信息";
            this.toolStrip_Menu.ResumeLayout(false);
            this.toolStrip_Menu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SubscribeMain)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SubscribeDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip_Menu;
        private System.Windows.Forms.ToolStripButton toolStripButton_OK;
        private System.Windows.Forms.ToolStripButton toolStripButton_Canel;
        private System.Windows.Forms.GroupBox groupBox1;
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
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_SubscribeMain;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView_SubscribeDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBuilding;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSubscribeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCustomerPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSubscribeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSalesName;
    }
}