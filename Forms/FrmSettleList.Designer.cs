namespace Commission.Forms
{
    partial class FrmSettleList
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
            this.dataGridView_SettleMain = new System.Windows.Forms.DataGridView();
            this.ColSettleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSettlePeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SettleMain)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_OK,
            this.toolStripButton_Close});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(503, 31);
            this.toolStrip2.TabIndex = 6;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton_OK
            // 
            this.toolStripButton_OK.AutoSize = false;
            this.toolStripButton_OK.Image = global::Commission.Properties.Resources.OK;
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
            // dataGridView_SettleMain
            // 
            this.dataGridView_SettleMain.AllowUserToAddRows = false;
            this.dataGridView_SettleMain.AllowUserToDeleteRows = false;
            this.dataGridView_SettleMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SettleMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSettleID,
            this.ColProjectID,
            this.ColTableName,
            this.ColSettlePeriod});
            this.dataGridView_SettleMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_SettleMain.Location = new System.Drawing.Point(0, 31);
            this.dataGridView_SettleMain.MultiSelect = false;
            this.dataGridView_SettleMain.Name = "dataGridView_SettleMain";
            this.dataGridView_SettleMain.ReadOnly = true;
            this.dataGridView_SettleMain.RowHeadersWidth = 21;
            this.dataGridView_SettleMain.RowTemplate.Height = 23;
            this.dataGridView_SettleMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_SettleMain.Size = new System.Drawing.Size(503, 438);
            this.dataGridView_SettleMain.TabIndex = 7;
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
            // FrmSettleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 469);
            this.Controls.Add(this.dataGridView_SettleMain);
            this.Controls.Add(this.toolStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSettleList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择业绩报表";
            this.Load += new System.EventHandler(this.FrmSettleList_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SettleMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_OK;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.DataGridView dataGridView_SettleMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSettleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSettlePeriod;
    }
}