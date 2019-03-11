namespace Commission.Report
{
    partial class RepInterval
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Begin = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_Export = new System.Windows.Forms.Button();
            this.button_Search = new System.Windows.Forms.Button();
            this.dataGridView_RepInterval = new System.Windows.Forms.DataGridView();
            this.ColSubscribeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBuilding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCustomerPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSubscribeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLastContractDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIntervalDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSalesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RepInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker_End);
            this.groupBox1.Controls.Add(this.dateTimePicker_Begin);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button_Exit);
            this.groupBox1.Controls.Add(this.button_Export);
            this.groupBox1.Controls.Add(this.button_Search);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(884, 51);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.Checked = false;
            this.dateTimePicker_End.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_End.Location = new System.Drawing.Point(207, 20);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.ShowCheckBox = true;
            this.dateTimePicker_End.Size = new System.Drawing.Size(100, 21);
            this.dateTimePicker_End.TabIndex = 27;
            // 
            // dateTimePicker_Begin
            // 
            this.dateTimePicker_Begin.Checked = false;
            this.dateTimePicker_Begin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Begin.Location = new System.Drawing.Point(69, 20);
            this.dateTimePicker_Begin.Name = "dateTimePicker_Begin";
            this.dateTimePicker_Begin.ShowCheckBox = true;
            this.dateTimePicker_Begin.Size = new System.Drawing.Size(120, 21);
            this.dateTimePicker_Begin.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "认购时间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(193, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "-";
            // 
            // button_Exit
            // 
            this.button_Exit.Image = global::Commission.Properties.Resources.exit;
            this.button_Exit.Location = new System.Drawing.Point(500, 19);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(75, 23);
            this.button_Exit.TabIndex = 17;
            this.button_Exit.Text = " 关闭";
            this.button_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_Export
            // 
            this.button_Export.Image = global::Commission.Properties.Resources.excel;
            this.button_Export.Location = new System.Drawing.Point(394, 19);
            this.button_Export.Name = "button_Export";
            this.button_Export.Size = new System.Drawing.Size(75, 23);
            this.button_Export.TabIndex = 1;
            this.button_Export.Text = " 导出";
            this.button_Export.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Export.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Export.UseVisualStyleBackColor = true;
            this.button_Export.Click += new System.EventHandler(this.button_Export_Click);
            // 
            // button_Search
            // 
            this.button_Search.Image = global::Commission.Properties.Resources.Find_16;
            this.button_Search.Location = new System.Drawing.Point(313, 19);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(75, 23);
            this.button_Search.TabIndex = 1;
            this.button_Search.Text = " 查询";
            this.button_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // dataGridView_RepInterval
            // 
            this.dataGridView_RepInterval.AllowUserToAddRows = false;
            this.dataGridView_RepInterval.AllowUserToDeleteRows = false;
            this.dataGridView_RepInterval.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_RepInterval.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_RepInterval.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSubscribeID,
            this.ColItemID,
            this.ColBuilding,
            this.ColUnit,
            this.ColItemNum,
            this.ColItemTypeName,
            this.ColCustomerName,
            this.ColCustomerPhone,
            this.ColSubscribeDate,
            this.ColLastContractDate,
            this.ColIntervalDays,
            this.ColSalesName});
            this.dataGridView_RepInterval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_RepInterval.Location = new System.Drawing.Point(0, 51);
            this.dataGridView_RepInterval.Name = "dataGridView_RepInterval";
            this.dataGridView_RepInterval.ReadOnly = true;
            this.dataGridView_RepInterval.RowHeadersWidth = 21;
            this.dataGridView_RepInterval.RowTemplate.Height = 23;
            this.dataGridView_RepInterval.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_RepInterval.Size = new System.Drawing.Size(884, 434);
            this.dataGridView_RepInterval.TabIndex = 6;
            // 
            // ColSubscribeID
            // 
            this.ColSubscribeID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColSubscribeID.DataPropertyName = "SubscribeID";
            this.ColSubscribeID.HeaderText = "SubscribeID";
            this.ColSubscribeID.Name = "ColSubscribeID";
            this.ColSubscribeID.ReadOnly = true;
            this.ColSubscribeID.Visible = false;
            this.ColSubscribeID.Width = 60;
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
            // ColItemTypeName
            // 
            this.ColItemTypeName.DataPropertyName = "ItemTypeName";
            this.ColItemTypeName.HeaderText = "房产类型";
            this.ColItemTypeName.Name = "ColItemTypeName";
            this.ColItemTypeName.ReadOnly = true;
            this.ColItemTypeName.Width = 78;
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
            this.ColCustomerPhone.ReadOnly = true;
            this.ColCustomerPhone.Width = 78;
            // 
            // ColSubscribeDate
            // 
            this.ColSubscribeDate.DataPropertyName = "SubscribeDate";
            this.ColSubscribeDate.HeaderText = "认购时间";
            this.ColSubscribeDate.Name = "ColSubscribeDate";
            this.ColSubscribeDate.ReadOnly = true;
            this.ColSubscribeDate.Width = 78;
            // 
            // ColLastContractDate
            // 
            this.ColLastContractDate.DataPropertyName = "LastContractDate";
            this.ColLastContractDate.HeaderText = "签约预期";
            this.ColLastContractDate.Name = "ColLastContractDate";
            this.ColLastContractDate.ReadOnly = true;
            this.ColLastContractDate.Width = 78;
            // 
            // ColIntervalDays
            // 
            this.ColIntervalDays.DataPropertyName = "IntervalDays";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ColIntervalDays.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColIntervalDays.HeaderText = "逾期天数";
            this.ColIntervalDays.Name = "ColIntervalDays";
            this.ColIntervalDays.ReadOnly = true;
            this.ColIntervalDays.Width = 78;
            // 
            // ColSalesName
            // 
            this.ColSalesName.DataPropertyName = "SalesName";
            this.ColSalesName.HeaderText = "置业顾问";
            this.ColSalesName.Name = "ColSalesName";
            this.ColSalesName.ReadOnly = true;
            this.ColSalesName.Width = 78;
            // 
            // RepInterval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 485);
            this.Controls.Add(this.dataGridView_RepInterval);
            this.Controls.Add(this.groupBox1);
            this.Name = "RepInterval";
            this.Text = "签约逾期表";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RepInterval)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_End;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Begin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Export;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.DataGridView dataGridView_RepInterval;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSubscribeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBuilding;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCustomerPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSubscribeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLastContractDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIntervalDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSalesName;
    }
}