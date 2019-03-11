namespace Commission.MenuForms
{
    partial class FrmRate
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
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView_Rate = new System.Windows.Forms.DataGridView();
            this.toolStripButton_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Del = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Modify = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemTypeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.toolStripSeparator1,
            this.toolStripButton_Close});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(784, 31);
            this.toolStrip2.TabIndex = 7;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView_Rate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 10);
            this.groupBox1.Size = new System.Drawing.Size(784, 433);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // dataGridView_Rate
            // 
            this.dataGridView_Rate.AllowUserToAddRows = false;
            this.dataGridView_Rate.AllowUserToDeleteRows = false;
            this.dataGridView_Rate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Rate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColRateName,
            this.ColItemTypeCode,
            this.ColItemTypeName,
            this.ColRate,
            this.ColAmount,
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
            this.dataGridView_Rate.Size = new System.Drawing.Size(778, 404);
            this.dataGridView_Rate.TabIndex = 0;
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
            // ColRateName
            // 
            this.ColRateName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColRateName.DataPropertyName = "RateName";
            this.ColRateName.HeaderText = "提点名称";
            this.ColRateName.Name = "ColRateName";
            this.ColRateName.ReadOnly = true;
            this.ColRateName.Width = 180;
            // 
            // ColItemTypeCode
            // 
            this.ColItemTypeCode.DataPropertyName = "ItemTypeCode";
            this.ColItemTypeCode.HeaderText = "ItemTypeCode";
            this.ColItemTypeCode.Name = "ColItemTypeCode";
            this.ColItemTypeCode.ReadOnly = true;
            this.ColItemTypeCode.Visible = false;
            // 
            // ColItemTypeName
            // 
            this.ColItemTypeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColItemTypeName.DataPropertyName = "ItemTypeName";
            this.ColItemTypeName.HeaderText = "物业类型";
            this.ColItemTypeName.Name = "ColItemTypeName";
            this.ColItemTypeName.ReadOnly = true;
            this.ColItemTypeName.Width = 80;
            // 
            // ColRate
            // 
            this.ColRate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColRate.DataPropertyName = "Rate";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0";
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ColRate.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColRate.HeaderText = "佣金比例(%)";
            this.ColRate.Name = "ColRate";
            this.ColRate.ReadOnly = true;
            // 
            // ColAmount
            // 
            this.ColAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ColAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColAmount.HeaderText = "佣金金额";
            this.ColAmount.Name = "ColAmount";
            this.ColAmount.ReadOnly = true;
            this.ColAmount.Width = 80;
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
            // FrmRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 464);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提点管理";
            this.Load += new System.EventHandler(this.FrmRate_Load);
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView_Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemTypeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBeginDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEndDate;
    }
}