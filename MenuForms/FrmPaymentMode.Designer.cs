namespace Commission.MenuForms
{
    partial class FrmPaymentMode
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
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Del = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Modify = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView_PaymentMode = new System.Windows.Forms.DataGridView();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPayType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPayTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDownPayRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStandardCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStandardName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBaseCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBaseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripButton_View = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PaymentMode)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Add,
            this.toolStripButton_Del,
            this.toolStripButton_Modify,
            this.toolStripButton_View,
            this.toolStripSeparator1,
            this.toolStripButton_Close});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(784, 31);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView_PaymentMode);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(784, 433);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "付款方式";
            // 
            // dataGridView_PaymentMode
            // 
            this.dataGridView_PaymentMode.AllowUserToAddRows = false;
            this.dataGridView_PaymentMode.AllowUserToDeleteRows = false;
            this.dataGridView_PaymentMode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_PaymentMode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColPayName,
            this.ColPayType,
            this.ColPayTypeName,
            this.ColDownPayRate,
            this.ColStandardCode,
            this.ColStandardName,
            this.ColBaseCode,
            this.ColBaseName,
            this.ColMemo});
            this.dataGridView_PaymentMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_PaymentMode.Location = new System.Drawing.Point(3, 17);
            this.dataGridView_PaymentMode.MultiSelect = false;
            this.dataGridView_PaymentMode.Name = "dataGridView_PaymentMode";
            this.dataGridView_PaymentMode.ReadOnly = true;
            this.dataGridView_PaymentMode.RowHeadersWidth = 20;
            this.dataGridView_PaymentMode.RowTemplate.Height = 23;
            this.dataGridView_PaymentMode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_PaymentMode.Size = new System.Drawing.Size(778, 413);
            this.dataGridView_PaymentMode.TabIndex = 0;
            // 
            // ColID
            // 
            this.ColID.DataPropertyName = "ID";
            this.ColID.HeaderText = "ID";
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            this.ColID.Visible = false;
            // 
            // ColPayName
            // 
            this.ColPayName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColPayName.DataPropertyName = "PayName";
            this.ColPayName.HeaderText = "付款方式";
            this.ColPayName.Name = "ColPayName";
            this.ColPayName.ReadOnly = true;
            this.ColPayName.Width = 200;
            // 
            // ColPayType
            // 
            this.ColPayType.DataPropertyName = "PayType";
            this.ColPayType.HeaderText = "PayType";
            this.ColPayType.Name = "ColPayType";
            this.ColPayType.ReadOnly = true;
            this.ColPayType.Visible = false;
            // 
            // ColPayTypeName
            // 
            this.ColPayTypeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColPayTypeName.DataPropertyName = "PayTypeName";
            this.ColPayTypeName.HeaderText = "付款类型";
            this.ColPayTypeName.Name = "ColPayTypeName";
            this.ColPayTypeName.ReadOnly = true;
            // 
            // ColDownPayRate
            // 
            this.ColDownPayRate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColDownPayRate.DataPropertyName = "DownPayRate";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ColDownPayRate.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColDownPayRate.HeaderText = "首付比例(%)";
            this.ColDownPayRate.Name = "ColDownPayRate";
            this.ColDownPayRate.ReadOnly = true;
            // 
            // ColStandardCode
            // 
            this.ColStandardCode.DataPropertyName = "StandardCode";
            this.ColStandardCode.HeaderText = "StandardCode";
            this.ColStandardCode.Name = "ColStandardCode";
            this.ColStandardCode.ReadOnly = true;
            this.ColStandardCode.Visible = false;
            // 
            // ColStandardName
            // 
            this.ColStandardName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColStandardName.DataPropertyName = "StandardName";
            this.ColStandardName.HeaderText = "结算条件";
            this.ColStandardName.Name = "ColStandardName";
            this.ColStandardName.ReadOnly = true;
            // 
            // ColBaseCode
            // 
            this.ColBaseCode.DataPropertyName = "BaseCode";
            this.ColBaseCode.HeaderText = "BaseCode";
            this.ColBaseCode.Name = "ColBaseCode";
            this.ColBaseCode.ReadOnly = true;
            this.ColBaseCode.Visible = false;
            // 
            // ColBaseName
            // 
            this.ColBaseName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColBaseName.DataPropertyName = "BaseName";
            this.ColBaseName.HeaderText = "结算基础";
            this.ColBaseName.Name = "ColBaseName";
            this.ColBaseName.ReadOnly = true;
            // 
            // ColMemo
            // 
            this.ColMemo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColMemo.DataPropertyName = "Memo";
            this.ColMemo.HeaderText = "备注说明";
            this.ColMemo.Name = "ColMemo";
            this.ColMemo.ReadOnly = true;
            this.ColMemo.Width = 150;
            // 
            // toolStripButton_View
            // 
            this.toolStripButton_View.AutoSize = false;
            this.toolStripButton_View.Image = global::Commission.Properties.Resources.view;
            this.toolStripButton_View.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_View.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_View.Name = "toolStripButton_View";
            this.toolStripButton_View.Size = new System.Drawing.Size(52, 28);
            this.toolStripButton_View.Text = "查看";
            this.toolStripButton_View.Click += new System.EventHandler(this.toolStripButton_View_Click);
            // 
            // FrmPaymentMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 464);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmPaymentMode";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "付款方式管理";
            this.Load += new System.EventHandler(this.FrmPaymentMode_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PaymentMode)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView_PaymentMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPayType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPayTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDownPayRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStandardCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStandardName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBaseCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBaseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMemo;
        private System.Windows.Forms.ToolStripButton toolStripButton_View;
    }
}