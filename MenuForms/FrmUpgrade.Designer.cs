namespace Commission.MenuForms
{
    partial class FrmUpgrade
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
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Del = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Modify = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Detail = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_OK = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_No = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView_Rate = new System.Windows.Forms.DataGridView();
            this.ColUpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUpBaseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIsSubscribe = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColBaseRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBeginDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Rate)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Add,
            this.toolStripButton_Del,
            this.toolStripButton_Modify,
            this.toolStripButton_Detail,
            this.toolStripSeparator1,
            this.toolStripButton_OK,
            this.toolStripButton_No,
            this.toolStripButton_Close});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(714, 31);
            this.toolStrip2.TabIndex = 8;
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
            // toolStripButton_Modify
            // 
            this.toolStripButton_Modify.AutoSize = false;
            this.toolStripButton_Modify.Image = global::Commission.Properties.Resources.Modify_16px;
            this.toolStripButton_Modify.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Modify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Modify.Name = "toolStripButton_Modify";
            this.toolStripButton_Modify.Size = new System.Drawing.Size(52, 28);
            this.toolStripButton_Modify.Text = "修改";
            this.toolStripButton_Modify.Click += new System.EventHandler(this.toolStripButton_Modify_Click);
            // 
            // toolStripButton_Detail
            // 
            this.toolStripButton_Detail.AutoSize = false;
            this.toolStripButton_Detail.Image = global::Commission.Properties.Resources.view_16;
            this.toolStripButton_Detail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Detail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Detail.Name = "toolStripButton_Detail";
            this.toolStripButton_Detail.Size = new System.Drawing.Size(52, 28);
            this.toolStripButton_Detail.Text = "详细";
            this.toolStripButton_Detail.ToolTipText = "设置项目默认提点";
            this.toolStripButton_Detail.Click += new System.EventHandler(this.toolStripButton_Detail_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButton_OK
            // 
            this.toolStripButton_OK.AutoSize = false;
            this.toolStripButton_OK.Image = global::Commission.Properties.Resources.OK;
            this.toolStripButton_OK.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_OK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_OK.Name = "toolStripButton_OK";
            this.toolStripButton_OK.Size = new System.Drawing.Size(52, 28);
            this.toolStripButton_OK.Text = "确定";
            this.toolStripButton_OK.Click += new System.EventHandler(this.toolStripButton_OK_Click);
            // 
            // toolStripButton_No
            // 
            this.toolStripButton_No.AutoSize = false;
            this.toolStripButton_No.Image = global::Commission.Properties.Resources.Del_16px;
            this.toolStripButton_No.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_No.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_No.Name = "toolStripButton_No";
            this.toolStripButton_No.Size = new System.Drawing.Size(52, 28);
            this.toolStripButton_No.Text = "移除";
            this.toolStripButton_No.Click += new System.EventHandler(this.toolStripButton_No_Click);
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
            this.groupBox1.Controls.Add(this.dataGridView_Rate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 10);
            this.groupBox1.Size = new System.Drawing.Size(714, 431);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // dataGridView_Rate
            // 
            this.dataGridView_Rate.AllowUserToAddRows = false;
            this.dataGridView_Rate.AllowUserToDeleteRows = false;
            this.dataGridView_Rate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Rate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColUpID,
            this.ColUpName,
            this.ColUpBaseName,
            this.ColIsSubscribe,
            this.ColBaseRate,
            this.ColBeginDate,
            this.ColEndDate});
            this.dataGridView_Rate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Rate.Location = new System.Drawing.Point(3, 19);
            this.dataGridView_Rate.MultiSelect = false;
            this.dataGridView_Rate.Name = "dataGridView_Rate";
            this.dataGridView_Rate.ReadOnly = true;
            this.dataGridView_Rate.RowHeadersWidth = 20;
            this.dataGridView_Rate.RowTemplate.Height = 23;
            this.dataGridView_Rate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Rate.Size = new System.Drawing.Size(708, 402);
            this.dataGridView_Rate.TabIndex = 0;
            // 
            // ColUpID
            // 
            this.ColUpID.DataPropertyName = "UPID";
            this.ColUpID.HeaderText = "UPID";
            this.ColUpID.Name = "ColUpID";
            this.ColUpID.ReadOnly = true;
            this.ColUpID.Visible = false;
            // 
            // ColUpName
            // 
            this.ColUpName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColUpName.DataPropertyName = "UpName";
            this.ColUpName.HeaderText = "跳点名称";
            this.ColUpName.Name = "ColUpName";
            this.ColUpName.ReadOnly = true;
            this.ColUpName.Width = 180;
            // 
            // ColUpBaseName
            // 
            this.ColUpBaseName.DataPropertyName = "UpBaseName";
            this.ColUpBaseName.HeaderText = "跳点基础";
            this.ColUpBaseName.Name = "ColUpBaseName";
            this.ColUpBaseName.ReadOnly = true;
            // 
            // ColIsSubscribe
            // 
            this.ColIsSubscribe.DataPropertyName = "IsSubscribe";
            this.ColIsSubscribe.FalseValue = "0";
            this.ColIsSubscribe.HeaderText = "含认购";
            this.ColIsSubscribe.Name = "ColIsSubscribe";
            this.ColIsSubscribe.ReadOnly = true;
            this.ColIsSubscribe.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColIsSubscribe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColIsSubscribe.TrueValue = "1";
            this.ColIsSubscribe.Width = 80;
            // 
            // ColBaseRate
            // 
            this.ColBaseRate.DataPropertyName = "BaseRate";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "F2";
            dataGridViewCellStyle1.NullValue = "0";
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ColBaseRate.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColBaseRate.HeaderText = "当前提点(%)";
            this.ColBaseRate.Name = "ColBaseRate";
            this.ColBaseRate.ReadOnly = true;
            // 
            // ColBeginDate
            // 
            this.ColBeginDate.DataPropertyName = "BeginDate";
            this.ColBeginDate.HeaderText = "开始日期";
            this.ColBeginDate.Name = "ColBeginDate";
            this.ColBeginDate.ReadOnly = true;
            // 
            // ColEndDate
            // 
            this.ColEndDate.DataPropertyName = "EndDate";
            this.ColEndDate.HeaderText = "结束日期";
            this.ColEndDate.Name = "ColEndDate";
            this.ColEndDate.ReadOnly = true;
            // 
            // FrmUpgrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 462);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmUpgrade";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "跳点管理";
            this.Load += new System.EventHandler(this.FrmUpgrade_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Rate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Add;
        private System.Windows.Forms.ToolStripButton toolStripButton_Del;
        private System.Windows.Forms.ToolStripButton toolStripButton_Modify;
        private System.Windows.Forms.ToolStripButton toolStripButton_Detail;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView_Rate;
        private System.Windows.Forms.ToolStripButton toolStripButton_OK;
        private System.Windows.Forms.ToolStripButton toolStripButton_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUpBaseName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColIsSubscribe;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBaseRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBeginDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEndDate;
    }
}