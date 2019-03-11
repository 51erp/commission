namespace Commission.Forms
{
    partial class FrmContractDateMng
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dataGridView_Days = new System.Windows.Forms.DataGridView();
            this.toolStripButton_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Del = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIntervalDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Days)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Add,
            this.toolStripButton_Del,
            this.toolStripSeparator1,
            this.toolStripButton_Close});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(266, 31);
            this.toolStrip2.TabIndex = 8;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // dataGridView_Days
            // 
            this.dataGridView_Days.AllowUserToAddRows = false;
            this.dataGridView_Days.AllowUserToDeleteRows = false;
            this.dataGridView_Days.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Days.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColItemTypeName,
            this.ColIntervalDays});
            this.dataGridView_Days.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Days.Location = new System.Drawing.Point(0, 31);
            this.dataGridView_Days.MultiSelect = false;
            this.dataGridView_Days.Name = "dataGridView_Days";
            this.dataGridView_Days.ReadOnly = true;
            this.dataGridView_Days.RowHeadersWidth = 20;
            this.dataGridView_Days.RowTemplate.Height = 23;
            this.dataGridView_Days.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Days.Size = new System.Drawing.Size(266, 243);
            this.dataGridView_Days.TabIndex = 9;
            // 
            // toolStripButton_Add
            // 
            this.toolStripButton_Add.AutoSize = false;
            this.toolStripButton_Add.Image = global::Commission.Properties.Resources.Add_16px;
            this.toolStripButton_Add.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Add.Name = "toolStripButton_Add";
            this.toolStripButton_Add.Size = new System.Drawing.Size(52, 28);
            this.toolStripButton_Add.Text = "新增";
            this.toolStripButton_Add.Click += new System.EventHandler(this.toolStripButton_Add_Click);
            // 
            // toolStripButton_Del
            // 
            this.toolStripButton_Del.AutoSize = false;
            this.toolStripButton_Del.Image = global::Commission.Properties.Resources.Del_16px;
            this.toolStripButton_Del.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Del.Name = "toolStripButton_Del";
            this.toolStripButton_Del.Size = new System.Drawing.Size(52, 28);
            this.toolStripButton_Del.Text = "删除";
            this.toolStripButton_Del.Click += new System.EventHandler(this.toolStripButton_Del_Click);
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
            // ColID
            // 
            this.ColID.DataPropertyName = "ID";
            this.ColID.HeaderText = "ID";
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            this.ColID.Visible = false;
            // 
            // ColItemTypeName
            // 
            this.ColItemTypeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColItemTypeName.DataPropertyName = "ItemTypeName";
            this.ColItemTypeName.HeaderText = "物业类型";
            this.ColItemTypeName.Name = "ColItemTypeName";
            this.ColItemTypeName.ReadOnly = true;
            this.ColItemTypeName.Width = 120;
            // 
            // ColIntervalDays
            // 
            this.ColIntervalDays.DataPropertyName = "IntervalDays";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ColIntervalDays.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColIntervalDays.HeaderText = "递延天数";
            this.ColIntervalDays.Name = "ColIntervalDays";
            this.ColIntervalDays.ReadOnly = true;
            // 
            // FrmContractDateMng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 274);
            this.Controls.Add(this.dataGridView_Days);
            this.Controls.Add(this.toolStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmContractDateMng";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "签约日期管理";
            this.Load += new System.EventHandler(this.FrmContractDateMng_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Days)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Add;
        private System.Windows.Forms.ToolStripButton toolStripButton_Del;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.DataGridView dataGridView_Days;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIntervalDays;
    }
}