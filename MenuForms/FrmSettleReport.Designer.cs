namespace Commission.MenuForms
{
    partial class FrmSettleReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker_Period = new System.Windows.Forms.DateTimePicker();
            this.button_Exit = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_CheckState = new System.Windows.Forms.ComboBox();
            this.button_Search = new System.Windows.Forms.Button();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Del = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Restore = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Detail = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Performance = new System.Windows.Forms.ToolStripButton();
            this.dataGridView_SettleMain = new System.Windows.Forms.DataGridView();
            this.ColSettleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSettlePeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSettleDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTableMaker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColChecker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCheckDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPerformance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SettleMain)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.panel1.Size = new System.Drawing.Size(1072, 67);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker_Period);
            this.groupBox1.Controls.Add(this.button_Exit);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.comboBox_CheckState);
            this.groupBox1.Controls.Add(this.button_Search);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1066, 53);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // dateTimePicker_Period
            // 
            this.dateTimePicker_Period.CustomFormat = "yyyy-MM";
            this.dateTimePicker_Period.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_Period.Location = new System.Drawing.Point(66, 24);
            this.dateTimePicker_Period.Name = "dateTimePicker_Period";
            this.dateTimePicker_Period.ShowUpDown = true;
            this.dateTimePicker_Period.Size = new System.Drawing.Size(68, 21);
            this.dateTimePicker_Period.TabIndex = 19;
            // 
            // button_Exit
            // 
            this.button_Exit.Image = global::Commission.Properties.Resources.exit;
            this.button_Exit.Location = new System.Drawing.Point(389, 23);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(75, 23);
            this.button_Exit.TabIndex = 17;
            this.button_Exit.Text = " 关闭";
            this.button_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(160, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "审核状态";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "结算期间";
            // 
            // comboBox_CheckState
            // 
            this.comboBox_CheckState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CheckState.FormattingEnabled = true;
            this.comboBox_CheckState.Items.AddRange(new object[] {
            "全部",
            "未审",
            "已审"});
            this.comboBox_CheckState.Location = new System.Drawing.Point(219, 24);
            this.comboBox_CheckState.Name = "comboBox_CheckState";
            this.comboBox_CheckState.Size = new System.Drawing.Size(83, 20);
            this.comboBox_CheckState.TabIndex = 2;
            // 
            // button_Search
            // 
            this.button_Search.Image = global::Commission.Properties.Resources.Find_16;
            this.button_Search.Location = new System.Drawing.Point(308, 23);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(75, 23);
            this.button_Search.TabIndex = 1;
            this.button_Search.Text = " 查询";
            this.button_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Del,
            this.toolStripButton_Restore,
            this.toolStripButton_Detail,
            this.toolStripButton_Performance});
            this.toolStrip2.Location = new System.Drawing.Point(0, 67);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1072, 31);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
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
            // toolStripButton_Restore
            // 
            this.toolStripButton_Restore.Image = global::Commission.Properties.Resources.wand;
            this.toolStripButton_Restore.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Restore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Restore.Name = "toolStripButton_Restore";
            this.toolStripButton_Restore.Size = new System.Drawing.Size(52, 28);
            this.toolStripButton_Restore.Text = "反审";
            this.toolStripButton_Restore.ToolTipText = "删除当前选定记录";
            this.toolStripButton_Restore.Click += new System.EventHandler(this.toolStripButton_Restore_Click);
            // 
            // toolStripButton_Detail
            // 
            this.toolStripButton_Detail.Image = global::Commission.Properties.Resources.view1;
            this.toolStripButton_Detail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Detail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Detail.Name = "toolStripButton_Detail";
            this.toolStripButton_Detail.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_Detail.Text = "显示";
            this.toolStripButton_Detail.ToolTipText = "查看详细并审核";
            this.toolStripButton_Detail.Click += new System.EventHandler(this.toolStripButton_Detail_Click);
            // 
            // toolStripButton_Performance
            // 
            this.toolStripButton_Performance.Image = global::Commission.Properties.Resources.medal_24;
            this.toolStripButton_Performance.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Performance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Performance.Name = "toolStripButton_Performance";
            this.toolStripButton_Performance.Size = new System.Drawing.Size(50, 28);
            this.toolStripButton_Performance.Text = "业绩";
            this.toolStripButton_Performance.ToolTipText = "生成业绩报表";
            this.toolStripButton_Performance.Click += new System.EventHandler(this.toolStripButton_Performance_Click);
            // 
            // dataGridView_SettleMain
            // 
            this.dataGridView_SettleMain.AllowUserToAddRows = false;
            this.dataGridView_SettleMain.AllowUserToDeleteRows = false;
            this.dataGridView_SettleMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SettleMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSettleID,
            this.ColProjectID,
            this.ColProjectName,
            this.ColTableName,
            this.ColSettlePeriod,
            this.ColSettleDate,
            this.ColTableMaker,
            this.ColChecker,
            this.ColCheckDate,
            this.ColPerformance});
            this.dataGridView_SettleMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_SettleMain.Location = new System.Drawing.Point(0, 98);
            this.dataGridView_SettleMain.MultiSelect = false;
            this.dataGridView_SettleMain.Name = "dataGridView_SettleMain";
            this.dataGridView_SettleMain.ReadOnly = true;
            this.dataGridView_SettleMain.RowHeadersWidth = 21;
            this.dataGridView_SettleMain.RowTemplate.Height = 23;
            this.dataGridView_SettleMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_SettleMain.Size = new System.Drawing.Size(1072, 354);
            this.dataGridView_SettleMain.TabIndex = 4;
            this.dataGridView_SettleMain.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_SettleMain_CellMouseDoubleClick);
            // 
            // ColSettleID
            // 
            this.ColSettleID.DataPropertyName = "SettleID";
            this.ColSettleID.HeaderText = "SettleID";
            this.ColSettleID.Name = "ColSettleID";
            this.ColSettleID.ReadOnly = true;
            this.ColSettleID.Visible = false;
            // 
            // ColProjectID
            // 
            this.ColProjectID.DataPropertyName = "ProjectID";
            this.ColProjectID.HeaderText = "ProjectID";
            this.ColProjectID.Name = "ColProjectID";
            this.ColProjectID.ReadOnly = true;
            this.ColProjectID.Visible = false;
            // 
            // ColProjectName
            // 
            this.ColProjectName.DataPropertyName = "ProjectName";
            this.ColProjectName.HeaderText = "项目名称";
            this.ColProjectName.Name = "ColProjectName";
            this.ColProjectName.ReadOnly = true;
            this.ColProjectName.Width = 150;
            // 
            // ColTableName
            // 
            this.ColTableName.DataPropertyName = "TableName";
            this.ColTableName.HeaderText = "报表名称";
            this.ColTableName.Name = "ColTableName";
            this.ColTableName.ReadOnly = true;
            this.ColTableName.Width = 250;
            // 
            // ColSettlePeriod
            // 
            this.ColSettlePeriod.DataPropertyName = "SettlePeriod";
            this.ColSettlePeriod.HeaderText = "结算期间";
            this.ColSettlePeriod.Name = "ColSettlePeriod";
            this.ColSettlePeriod.ReadOnly = true;
            // 
            // ColSettleDate
            // 
            this.ColSettleDate.DataPropertyName = "SettleDate";
            this.ColSettleDate.HeaderText = "结算日期";
            this.ColSettleDate.Name = "ColSettleDate";
            this.ColSettleDate.ReadOnly = true;
            // 
            // ColTableMaker
            // 
            this.ColTableMaker.DataPropertyName = "TableMaker";
            this.ColTableMaker.HeaderText = "制表人";
            this.ColTableMaker.Name = "ColTableMaker";
            this.ColTableMaker.ReadOnly = true;
            // 
            // ColChecker
            // 
            this.ColChecker.DataPropertyName = "Checker";
            this.ColChecker.HeaderText = "审核人";
            this.ColChecker.Name = "ColChecker";
            this.ColChecker.ReadOnly = true;
            // 
            // ColCheckDate
            // 
            this.ColCheckDate.DataPropertyName = "CheckDate";
            dataGridViewCellStyle2.NullValue = null;
            this.ColCheckDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColCheckDate.HeaderText = "审核日期";
            this.ColCheckDate.Name = "ColCheckDate";
            this.ColCheckDate.ReadOnly = true;
            // 
            // ColPerformance
            // 
            this.ColPerformance.DataPropertyName = "Performance";
            this.ColPerformance.HeaderText = "业绩报表";
            this.ColPerformance.Name = "ColPerformance";
            this.ColPerformance.ReadOnly = true;
            // 
            // FrmSettleReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 452);
            this.Controls.Add(this.dataGridView_SettleMain);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSettleReport";
            this.Text = "结算报表管理";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SettleMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_CheckState;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Del;
        private System.Windows.Forms.ToolStripButton toolStripButton_Detail;
        private System.Windows.Forms.DataGridView dataGridView_SettleMain;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Period;
        private System.Windows.Forms.ToolStripButton toolStripButton_Restore;
        private System.Windows.Forms.ToolStripButton toolStripButton_Performance;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSettleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSettlePeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSettleDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTableMaker;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChecker;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCheckDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPerformance;
    }
}