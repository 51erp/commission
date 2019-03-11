namespace Commission.MenuForms
{
    partial class FrmReSettleReport
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
            this.button_Search = new System.Windows.Forms.Button();
            this.toolStripButton_Del = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Detail = new System.Windows.Forms.ToolStripButton();
            this.button_Exit = new System.Windows.Forms.Button();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_CheckState = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView_SettleMain = new System.Windows.Forms.DataGridView();
            this.ColFullSettleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSettleDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTableMaker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColChecker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCheckDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripButton_Restore = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SettleMain)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Search
            // 
            this.button_Search.Image = global::Commission.Properties.Resources.Find_16;
            this.button_Search.Location = new System.Drawing.Point(167, 21);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(75, 23);
            this.button_Search.TabIndex = 1;
            this.button_Search.Text = " 查询";
            this.button_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
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
            // toolStripButton_Detail
            // 
            this.toolStripButton_Detail.Image = global::Commission.Properties.Resources.details_24;
            this.toolStripButton_Detail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Detail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Detail.Name = "toolStripButton_Detail";
            this.toolStripButton_Detail.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_Detail.Text = "显示";
            this.toolStripButton_Detail.ToolTipText = "查看详细并审核";
            this.toolStripButton_Detail.Click += new System.EventHandler(this.toolStripButton_Detail_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.Image = global::Commission.Properties.Resources.exit;
            this.button_Exit.Location = new System.Drawing.Point(248, 21);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(75, 23);
            this.button_Exit.TabIndex = 17;
            this.button_Exit.Text = " 关闭";
            this.button_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Del,
            this.toolStripButton_Restore,
            this.toolStripButton_Detail});
            this.toolStrip2.Location = new System.Drawing.Point(0, 67);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(867, 31);
            this.toolStrip2.TabIndex = 6;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "审核状态";
            // 
            // comboBox_CheckState
            // 
            this.comboBox_CheckState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CheckState.FormattingEnabled = true;
            this.comboBox_CheckState.Items.AddRange(new object[] {
            "全部",
            "未审",
            "已审"});
            this.comboBox_CheckState.Location = new System.Drawing.Point(68, 23);
            this.comboBox_CheckState.Name = "comboBox_CheckState";
            this.comboBox_CheckState.Size = new System.Drawing.Size(83, 20);
            this.comboBox_CheckState.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_Exit);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboBox_CheckState);
            this.groupBox1.Controls.Add(this.button_Search);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(861, 53);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.panel1.Size = new System.Drawing.Size(867, 67);
            this.panel1.TabIndex = 5;
            // 
            // dataGridView_SettleMain
            // 
            this.dataGridView_SettleMain.AllowUserToAddRows = false;
            this.dataGridView_SettleMain.AllowUserToDeleteRows = false;
            this.dataGridView_SettleMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SettleMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColFullSettleID,
            this.ColProjectID,
            this.ColTableName,
            this.ColSettleDate,
            this.ColTableMaker,
            this.ColChecker,
            this.ColCheckDate});
            this.dataGridView_SettleMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_SettleMain.Location = new System.Drawing.Point(0, 98);
            this.dataGridView_SettleMain.MultiSelect = false;
            this.dataGridView_SettleMain.Name = "dataGridView_SettleMain";
            this.dataGridView_SettleMain.ReadOnly = true;
            this.dataGridView_SettleMain.RowHeadersWidth = 21;
            this.dataGridView_SettleMain.RowTemplate.Height = 23;
            this.dataGridView_SettleMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_SettleMain.Size = new System.Drawing.Size(867, 324);
            this.dataGridView_SettleMain.TabIndex = 7;
            // 
            // ColFullSettleID
            // 
            this.ColFullSettleID.DataPropertyName = "FullSettleID";
            this.ColFullSettleID.HeaderText = "FullSettleID";
            this.ColFullSettleID.Name = "ColFullSettleID";
            this.ColFullSettleID.ReadOnly = true;
            this.ColFullSettleID.Visible = false;
            // 
            // ColProjectID
            // 
            this.ColProjectID.DataPropertyName = "ProjectID";
            this.ColProjectID.HeaderText = "ProjectID";
            this.ColProjectID.Name = "ColProjectID";
            this.ColProjectID.ReadOnly = true;
            this.ColProjectID.Visible = false;
            // 
            // ColTableName
            // 
            this.ColTableName.DataPropertyName = "TableName";
            this.ColTableName.HeaderText = "报表名称";
            this.ColTableName.Name = "ColTableName";
            this.ColTableName.ReadOnly = true;
            this.ColTableName.Width = 250;
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
            this.ColCheckDate.HeaderText = "审核日期";
            this.ColCheckDate.Name = "ColCheckDate";
            this.ColCheckDate.ReadOnly = true;
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
            // FrmReSettleReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 422);
            this.Controls.Add(this.dataGridView_SettleMain);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmReSettleReport";
            this.Text = "确权结算报表";
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SettleMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.ToolStripButton toolStripButton_Del;
        private System.Windows.Forms.ToolStripButton toolStripButton_Detail;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_CheckState;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView_SettleMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFullSettleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSettleDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTableMaker;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChecker;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCheckDate;
        private System.Windows.Forms.ToolStripButton toolStripButton_Restore;
    }
}