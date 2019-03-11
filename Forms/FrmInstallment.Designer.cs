namespace Commission.Forms
{
    partial class FrmInstallment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Remove = new System.Windows.Forms.ToolStripButton();
            this.dataGridView_Installment = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_Unassigned = new System.Windows.Forms.TextBox();
            this.textBox_Amount = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ColSequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPayDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSettled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Installment)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Save,
            this.toolStripButton_Close});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(379, 31);
            this.toolStrip2.TabIndex = 23;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton_Save
            // 
            this.toolStripButton_Save.Image = global::Commission.Properties.Resources.save_24;
            this.toolStripButton_Save.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Save.Name = "toolStripButton_Save";
            this.toolStripButton_Save.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_Save.Text = "保存";
            this.toolStripButton_Save.Click += new System.EventHandler(this.toolStripButton_Save_Click);
            // 
            // toolStripButton_Close
            // 
            this.toolStripButton_Close.Image = global::Commission.Properties.Resources.exit_24;
            this.toolStripButton_Close.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Close.Name = "toolStripButton_Close";
            this.toolStripButton_Close.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_Close.Text = "关闭";
            this.toolStripButton_Close.Click += new System.EventHandler(this.toolStripButton_Close_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Add,
            this.toolStripButton_Remove});
            this.toolStrip1.Location = new System.Drawing.Point(0, 31);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(379, 25);
            this.toolStrip1.TabIndex = 24;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_Add
            // 
            this.toolStripButton_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Add.Image = global::Commission.Properties.Resources.Add_16px;
            this.toolStripButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Add.Name = "toolStripButton_Add";
            this.toolStripButton_Add.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Add.Text = "添加一个付款记录";
            this.toolStripButton_Add.Click += new System.EventHandler(this.toolStripButton_Add_Click);
            // 
            // toolStripButton_Remove
            // 
            this.toolStripButton_Remove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Remove.Image = global::Commission.Properties.Resources.remove2_16;
            this.toolStripButton_Remove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Remove.Name = "toolStripButton_Remove";
            this.toolStripButton_Remove.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Remove.Text = "移除一个付款记录";
            this.toolStripButton_Remove.Click += new System.EventHandler(this.toolStripButton_Remove_Click);
            // 
            // dataGridView_Installment
            // 
            this.dataGridView_Installment.AllowUserToAddRows = false;
            this.dataGridView_Installment.AllowUserToDeleteRows = false;
            this.dataGridView_Installment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Installment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSequence,
            this.ColAmount,
            this.ColPayDate,
            this.ColSettled});
            this.dataGridView_Installment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Installment.Location = new System.Drawing.Point(0, 56);
            this.dataGridView_Installment.MultiSelect = false;
            this.dataGridView_Installment.Name = "dataGridView_Installment";
            this.dataGridView_Installment.RowHeadersWidth = 21;
            this.dataGridView_Installment.RowTemplate.Height = 23;
            this.dataGridView_Installment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Installment.Size = new System.Drawing.Size(379, 189);
            this.dataGridView_Installment.TabIndex = 25;
            this.dataGridView_Installment.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Installment_CellEndEdit);
            this.dataGridView_Installment.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView_Installment_CellValidating);
            this.dataGridView_Installment.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView_Installment_RowsRemoved);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_Unassigned);
            this.panel1.Controls.Add(this.textBox_Amount);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 245);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(379, 35);
            this.panel1.TabIndex = 26;
            // 
            // textBox_Unassigned
            // 
            this.textBox_Unassigned.Location = new System.Drawing.Point(186, 8);
            this.textBox_Unassigned.Name = "textBox_Unassigned";
            this.textBox_Unassigned.ReadOnly = true;
            this.textBox_Unassigned.Size = new System.Drawing.Size(100, 21);
            this.textBox_Unassigned.TabIndex = 2;
            this.textBox_Unassigned.Text = "0";
            this.textBox_Unassigned.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_Amount
            // 
            this.textBox_Amount.Location = new System.Drawing.Point(47, 8);
            this.textBox_Amount.Name = "textBox_Amount";
            this.textBox_Amount.ReadOnly = true;
            this.textBox_Amount.Size = new System.Drawing.Size(100, 21);
            this.textBox_Amount.TabIndex = 2;
            this.textBox_Amount.Text = "0";
            this.textBox_Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(305, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "分配";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "剩余";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "金额";
            // 
            // ColSequence
            // 
            this.ColSequence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColSequence.DataPropertyName = "Sequence";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColSequence.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColSequence.HeaderText = "次序";
            this.ColSequence.Name = "ColSequence";
            this.ColSequence.ReadOnly = true;
            this.ColSequence.Width = 55;
            // 
            // ColAmount
            // 
            this.ColAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.NullValue = "0";
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ColAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColAmount.FillWeight = 150F;
            this.ColAmount.HeaderText = "付款金额";
            this.ColAmount.Name = "ColAmount";
            this.ColAmount.Width = 180;
            // 
            // ColPayDate
            // 
            this.ColPayDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColPayDate.DataPropertyName = "PayDate";
            dataGridViewCellStyle3.Format = "D";
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.ColPayDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColPayDate.HeaderText = "付款日期";
            this.ColPayDate.Name = "ColPayDate";
            // 
            // ColSettled
            // 
            this.ColSettled.DataPropertyName = "Settled";
            dataGridViewCellStyle4.NullValue = "0";
            this.ColSettled.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColSettled.HeaderText = "Settled";
            this.ColSettled.Name = "ColSettled";
            this.ColSettled.Visible = false;
            // 
            // FrmInstallment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 280);
            this.Controls.Add(this.dataGridView_Installment);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmInstallment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "分期付款";
            this.Load += new System.EventHandler(this.FrmInstallment_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Installment)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Save;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Add;
        private System.Windows.Forms.ToolStripButton toolStripButton_Remove;
        private System.Windows.Forms.DataGridView dataGridView_Installment;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_Unassigned;
        private System.Windows.Forms.TextBox textBox_Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSequence;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPayDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSettled;
    }
}