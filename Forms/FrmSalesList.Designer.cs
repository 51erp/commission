namespace Commission.Forms
{
    partial class FrmSalesList
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
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_OK = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_JobType = new System.Windows.Forms.ComboBox();
            this.dateTimePicker_OperationDate = new System.Windows.Forms.DateTimePicker();
            this.label_Job = new System.Windows.Forms.Label();
            this.label_date = new System.Windows.Forms.Label();
            this.dataGridView_Sales = new System.Windows.Forms.DataGridView();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSalesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColInDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOutDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Sales)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_OK,
            this.toolStripButton_Close});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Margin = new System.Windows.Forms.Padding(10);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(645, 31);
            this.toolStrip2.TabIndex = 6;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton_OK
            // 
            this.toolStripButton_OK.AutoSize = false;
            this.toolStripButton_OK.Image = global::Commission.Properties.Resources.check_16;
            this.toolStripButton_OK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_OK.Name = "toolStripButton_OK";
            this.toolStripButton_OK.Size = new System.Drawing.Size(52, 28);
            this.toolStripButton_OK.Text = "确定";
            this.toolStripButton_OK.Click += new System.EventHandler(this.toolStripButton_OK_Click);
            // 
            // toolStripButton_Close
            // 
            this.toolStripButton_Close.AutoSize = false;
            this.toolStripButton_Close.Image = global::Commission.Properties.Resources.exit;
            this.toolStripButton_Close.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Close.Name = "toolStripButton_Close";
            this.toolStripButton_Close.Size = new System.Drawing.Size(52, 28);
            this.toolStripButton_Close.Text = "关闭";
            this.toolStripButton_Close.Click += new System.EventHandler(this.toolStripButton_Close_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_JobType);
            this.groupBox1.Controls.Add(this.dateTimePicker_OperationDate);
            this.groupBox1.Controls.Add(this.label_Job);
            this.groupBox1.Controls.Add(this.label_date);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 31);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(645, 56);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // comboBox_JobType
            // 
            this.comboBox_JobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_JobType.FormattingEnabled = true;
            this.comboBox_JobType.Items.AddRange(new object[] {
            "员工",
            "主管"});
            this.comboBox_JobType.Location = new System.Drawing.Point(240, 20);
            this.comboBox_JobType.Name = "comboBox_JobType";
            this.comboBox_JobType.Size = new System.Drawing.Size(101, 20);
            this.comboBox_JobType.TabIndex = 75;
            // 
            // dateTimePicker_OperationDate
            // 
            this.dateTimePicker_OperationDate.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker_OperationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_OperationDate.Location = new System.Drawing.Point(67, 20);
            this.dateTimePicker_OperationDate.Name = "dateTimePicker_OperationDate";
            this.dateTimePicker_OperationDate.Size = new System.Drawing.Size(101, 21);
            this.dateTimePicker_OperationDate.TabIndex = 74;
            // 
            // label_Job
            // 
            this.label_Job.AutoSize = true;
            this.label_Job.Location = new System.Drawing.Point(181, 24);
            this.label_Job.Name = "label_Job";
            this.label_Job.Size = new System.Drawing.Size(53, 12);
            this.label_Job.TabIndex = 72;
            this.label_Job.Text = "调入岗位";
            // 
            // label_date
            // 
            this.label_date.AutoSize = true;
            this.label_date.Location = new System.Drawing.Point(8, 24);
            this.label_date.Name = "label_date";
            this.label_date.Size = new System.Drawing.Size(53, 12);
            this.label_date.TabIndex = 73;
            this.label_date.Text = "调入时间";
            // 
            // dataGridView_Sales
            // 
            this.dataGridView_Sales.AllowUserToAddRows = false;
            this.dataGridView_Sales.AllowUserToDeleteRows = false;
            this.dataGridView_Sales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Sales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColSalesName,
            this.ColPhone,
            this.ColInDate,
            this.ColOutDate,
            this.ColPosition,
            this.ColProjectName});
            this.dataGridView_Sales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Sales.Location = new System.Drawing.Point(0, 87);
            this.dataGridView_Sales.MultiSelect = false;
            this.dataGridView_Sales.Name = "dataGridView_Sales";
            this.dataGridView_Sales.ReadOnly = true;
            this.dataGridView_Sales.RowHeadersWidth = 21;
            this.dataGridView_Sales.RowTemplate.Height = 23;
            this.dataGridView_Sales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Sales.Size = new System.Drawing.Size(645, 391);
            this.dataGridView_Sales.TabIndex = 8;
            // 
            // ColID
            // 
            this.ColID.DataPropertyName = "SalesID";
            this.ColID.HeaderText = "ID";
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            this.ColID.Visible = false;
            // 
            // ColSalesName
            // 
            this.ColSalesName.DataPropertyName = "SalesName";
            this.ColSalesName.HeaderText = "姓名";
            this.ColSalesName.Name = "ColSalesName";
            this.ColSalesName.ReadOnly = true;
            // 
            // ColPhone
            // 
            this.ColPhone.DataPropertyName = "Phone";
            this.ColPhone.HeaderText = "电话";
            this.ColPhone.Name = "ColPhone";
            this.ColPhone.ReadOnly = true;
            // 
            // ColInDate
            // 
            this.ColInDate.DataPropertyName = "InDate";
            this.ColInDate.HeaderText = "入职时间";
            this.ColInDate.Name = "ColInDate";
            this.ColInDate.ReadOnly = true;
            // 
            // ColOutDate
            // 
            this.ColOutDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColOutDate.DataPropertyName = "OutDate";
            this.ColOutDate.HeaderText = "离职时间";
            this.ColOutDate.Name = "ColOutDate";
            this.ColOutDate.ReadOnly = true;
            // 
            // ColPosition
            // 
            this.ColPosition.DataPropertyName = "Position";
            this.ColPosition.HeaderText = "职位";
            this.ColPosition.Name = "ColPosition";
            this.ColPosition.ReadOnly = true;
            // 
            // ColProjectName
            // 
            this.ColProjectName.DataPropertyName = "ProjectName";
            this.ColProjectName.HeaderText = "归属项目";
            this.ColProjectName.Name = "ColProjectName";
            this.ColProjectName.ReadOnly = true;
            // 
            // FrmSalesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 478);
            this.Controls.Add(this.dataGridView_Sales);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSalesList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "置业顾问信息";
            this.Load += new System.EventHandler(this.FrmSalesList_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Sales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_OK;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView_Sales;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSalesName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColInDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOutDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProjectName;
        private System.Windows.Forms.ComboBox comboBox_JobType;
        private System.Windows.Forms.DateTimePicker dateTimePicker_OperationDate;
        private System.Windows.Forms.Label label_Job;
        private System.Windows.Forms.Label label_date;
    }
}