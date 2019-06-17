namespace Commission.MenuForms
{
    partial class FrmNoJob
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
            this.comboBox_OperationType = new System.Windows.Forms.ComboBox();
            this.button_Exit = new System.Windows.Forms.Button();
            this.textBox_SalesName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button_Search = new System.Windows.Forms.Button();
            this.dataGridView_Employe = new System.Windows.Forms.DataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_JobIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Dimission = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Return = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_All = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_None = new System.Windows.Forms.ToolStripButton();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSalesID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDeptID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSalesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColInDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBeginDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOutDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColJobType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOperationType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Employe)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel1.Size = new System.Drawing.Size(1195, 57);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_OperationType);
            this.groupBox1.Controls.Add(this.button_Exit);
            this.groupBox1.Controls.Add(this.textBox_SalesName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.button_Search);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1195, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询信息";
            // 
            // comboBox_OperationType
            // 
            this.comboBox_OperationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_OperationType.FormattingEnabled = true;
            this.comboBox_OperationType.Items.AddRange(new object[] {
            "调出",
            "离职"});
            this.comboBox_OperationType.Location = new System.Drawing.Point(219, 21);
            this.comboBox_OperationType.Name = "comboBox_OperationType";
            this.comboBox_OperationType.Size = new System.Drawing.Size(100, 20);
            this.comboBox_OperationType.TabIndex = 23;
            // 
            // button_Exit
            // 
            this.button_Exit.Image = global::Commission.Properties.Resources.exit;
            this.button_Exit.Location = new System.Drawing.Point(440, 18);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(75, 25);
            this.button_Exit.TabIndex = 22;
            this.button_Exit.Text = " 关闭";
            this.button_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // textBox_SalesName
            // 
            this.textBox_SalesName.Location = new System.Drawing.Point(69, 21);
            this.textBox_SalesName.Name = "textBox_SalesName";
            this.textBox_SalesName.Size = new System.Drawing.Size(100, 21);
            this.textBox_SalesName.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "姓名";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "姓名";
            // 
            // button_Search
            // 
            this.button_Search.Image = global::Commission.Properties.Resources.Find_16;
            this.button_Search.Location = new System.Drawing.Point(359, 18);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(75, 25);
            this.button_Search.TabIndex = 19;
            this.button_Search.Text = " 查询";
            this.button_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // dataGridView_Employe
            // 
            this.dataGridView_Employe.AllowUserToAddRows = false;
            this.dataGridView_Employe.AllowUserToDeleteRows = false;
            this.dataGridView_Employe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Employe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColSalesID,
            this.ColDeptID,
            this.ColSalesName,
            this.ColPhone,
            this.ColInDate,
            this.ColBeginDate,
            this.ColEndDate,
            this.ColOutDate,
            this.ColDeptName,
            this.ColPosition,
            this.ColJobType,
            this.ColOperationType,
            this.ColMemo});
            this.dataGridView_Employe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Employe.Location = new System.Drawing.Point(0, 88);
            this.dataGridView_Employe.MultiSelect = false;
            this.dataGridView_Employe.Name = "dataGridView_Employe";
            this.dataGridView_Employe.ReadOnly = true;
            this.dataGridView_Employe.RowHeadersWidth = 21;
            this.dataGridView_Employe.RowTemplate.Height = 23;
            this.dataGridView_Employe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Employe.Size = new System.Drawing.Size(1195, 464);
            this.dataGridView_Employe.TabIndex = 4;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_JobIn,
            this.toolStripButton_Dimission,
            this.toolStripButton_Return,
            this.toolStripSeparator1,
            this.toolStripButton_All,
            this.toolStripButton_None});
            this.toolStrip2.Location = new System.Drawing.Point(0, 57);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1195, 31);
            this.toolStrip2.TabIndex = 10;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton_JobIn
            // 
            this.toolStripButton_JobIn.Image = global::Commission.Properties.Resources.file_new;
            this.toolStripButton_JobIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_JobIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_JobIn.Name = "toolStripButton_JobIn";
            this.toolStripButton_JobIn.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_JobIn.Text = "调入";
            this.toolStripButton_JobIn.Click += new System.EventHandler(this.toolStripButton_JobIn_Click);
            // 
            // toolStripButton_Dimission
            // 
            this.toolStripButton_Dimission.Image = global::Commission.Properties.Resources.file_del;
            this.toolStripButton_Dimission.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Dimission.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Dimission.Name = "toolStripButton_Dimission";
            this.toolStripButton_Dimission.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_Dimission.Text = "离职";
            this.toolStripButton_Dimission.Click += new System.EventHandler(this.toolStripButton_Dimission_Click);
            // 
            // toolStripButton_Return
            // 
            this.toolStripButton_Return.Image = global::Commission.Properties.Resources.in_241;
            this.toolStripButton_Return.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Return.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Return.Name = "toolStripButton_Return";
            this.toolStripButton_Return.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_Return.Text = "复职";
            this.toolStripButton_Return.Click += new System.EventHandler(this.toolStripButton_Return_Click);
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
            // 
            // toolStripButton_None
            // 
            this.toolStripButton_None.Image = global::Commission.Properties.Resources.Nolist;
            this.toolStripButton_None.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_None.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_None.Name = "toolStripButton_None";
            this.toolStripButton_None.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_None.Text = "全清";
            // 
            // ColID
            // 
            this.ColID.DataPropertyName = "ID";
            this.ColID.HeaderText = "ID";
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            this.ColID.Visible = false;
            // 
            // ColSalesID
            // 
            this.ColSalesID.DataPropertyName = "SalesID";
            this.ColSalesID.HeaderText = "SalesID";
            this.ColSalesID.Name = "ColSalesID";
            this.ColSalesID.ReadOnly = true;
            this.ColSalesID.Visible = false;
            // 
            // ColDeptID
            // 
            this.ColDeptID.DataPropertyName = "DeptID";
            this.ColDeptID.HeaderText = "DeptID";
            this.ColDeptID.Name = "ColDeptID";
            this.ColDeptID.ReadOnly = true;
            this.ColDeptID.Visible = false;
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
            // ColBeginDate
            // 
            this.ColBeginDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColBeginDate.DataPropertyName = "BeginDate";
            this.ColBeginDate.HeaderText = "调入时间";
            this.ColBeginDate.Name = "ColBeginDate";
            this.ColBeginDate.ReadOnly = true;
            // 
            // ColEndDate
            // 
            this.ColEndDate.DataPropertyName = "EndDate";
            this.ColEndDate.HeaderText = "调出时间";
            this.ColEndDate.Name = "ColEndDate";
            this.ColEndDate.ReadOnly = true;
            // 
            // ColOutDate
            // 
            this.ColOutDate.DataPropertyName = "OutDate";
            this.ColOutDate.HeaderText = "离职时间";
            this.ColOutDate.Name = "ColOutDate";
            this.ColOutDate.ReadOnly = true;
            // 
            // ColDeptName
            // 
            this.ColDeptName.DataPropertyName = "DeptName";
            this.ColDeptName.HeaderText = "部门";
            this.ColDeptName.Name = "ColDeptName";
            this.ColDeptName.ReadOnly = true;
            // 
            // ColPosition
            // 
            this.ColPosition.DataPropertyName = "Position";
            this.ColPosition.HeaderText = "职位";
            this.ColPosition.Name = "ColPosition";
            this.ColPosition.ReadOnly = true;
            // 
            // ColJobType
            // 
            this.ColJobType.DataPropertyName = "JobType";
            this.ColJobType.HeaderText = "岗位类型";
            this.ColJobType.Name = "ColJobType";
            this.ColJobType.ReadOnly = true;
            // 
            // ColOperationType
            // 
            this.ColOperationType.DataPropertyName = "OperationType";
            this.ColOperationType.HeaderText = "岗位状态";
            this.ColOperationType.Name = "ColOperationType";
            this.ColOperationType.ReadOnly = true;
            // 
            // ColMemo
            // 
            this.ColMemo.DataPropertyName = "Memo";
            this.ColMemo.HeaderText = "备注";
            this.ColMemo.Name = "ColMemo";
            this.ColMemo.ReadOnly = true;
            this.ColMemo.Width = 200;
            // 
            // FrmNoJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 552);
            this.Controls.Add(this.dataGridView_Employe);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmNoJob";
            this.Text = "离职调出";
            this.Load += new System.EventHandler(this.FrmNoJob_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Employe)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.TextBox textBox_SalesName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_OperationType;
        private System.Windows.Forms.DataGridView dataGridView_Employe;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_JobIn;
        private System.Windows.Forms.ToolStripButton toolStripButton_Return;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_All;
        private System.Windows.Forms.ToolStripButton toolStripButton_None;
        private System.Windows.Forms.ToolStripButton toolStripButton_Dimission;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSalesID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDeptID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSalesName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColInDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBeginDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOutDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDeptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColJobType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOperationType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMemo;
    }
}