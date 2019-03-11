namespace Commission.Forms
{
    partial class FrmItemTypeMng
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
            this.toolStripButton_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Del = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.dataGridView_ItemType = new System.Windows.Forms.DataGridView();
            this.ColCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ItemType)).BeginInit();
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
            this.toolStrip2.Size = new System.Drawing.Size(396, 31);
            this.toolStrip2.TabIndex = 6;
            this.toolStrip2.Text = "toolStrip2";
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
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
            // dataGridView_ItemType
            // 
            this.dataGridView_ItemType.AllowUserToAddRows = false;
            this.dataGridView_ItemType.AllowUserToDeleteRows = false;
            this.dataGridView_ItemType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ItemType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCode,
            this.ColName,
            this.ColPID});
            this.dataGridView_ItemType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_ItemType.Location = new System.Drawing.Point(0, 31);
            this.dataGridView_ItemType.MultiSelect = false;
            this.dataGridView_ItemType.Name = "dataGridView_ItemType";
            this.dataGridView_ItemType.ReadOnly = true;
            this.dataGridView_ItemType.RowHeadersWidth = 21;
            this.dataGridView_ItemType.RowTemplate.Height = 23;
            this.dataGridView_ItemType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_ItemType.Size = new System.Drawing.Size(396, 383);
            this.dataGridView_ItemType.TabIndex = 7;
            // 
            // ColCode
            // 
            this.ColCode.DataPropertyName = "Code";
            this.ColCode.HeaderText = "编码";
            this.ColCode.Name = "ColCode";
            this.ColCode.ReadOnly = true;
            // 
            // ColName
            // 
            this.ColName.DataPropertyName = "Name";
            this.ColName.HeaderText = "名称";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            // 
            // ColPID
            // 
            this.ColPID.DataPropertyName = "Memo";
            this.ColPID.HeaderText = "备注";
            this.ColPID.Name = "ColPID";
            this.ColPID.ReadOnly = true;
            // 
            // FrmItemTypeMng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 414);
            this.Controls.Add(this.dataGridView_ItemType);
            this.Controls.Add(this.toolStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmItemTypeMng";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "物业类型管理";
            this.Load += new System.EventHandler(this.FrmItemTypeMng_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ItemType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Add;
        private System.Windows.Forms.ToolStripButton toolStripButton_Del;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.DataGridView dataGridView_ItemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPID;
    }
}