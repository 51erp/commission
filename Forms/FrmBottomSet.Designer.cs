namespace Commission.Forms
{
    partial class FrmBottomSet
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
            this.toolStripButton_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.tabControl_Bottom = new System.Windows.Forms.TabControl();
            this.tabPage_Base = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_BottomPriceRate = new System.Windows.Forms.TextBox();
            this.textBox_BottomPriceLimit = new System.Windows.Forms.TextBox();
            this.textBox_BottomAmount = new System.Windows.Forms.TextBox();
            this.textBox_BottomPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage_Range = new System.Windows.Forms.TabPage();
            this.textBox_Range = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.toolStrip2.SuspendLayout();
            this.tabControl_Bottom.SuspendLayout();
            this.tabPage_Base.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage_Range.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Save,
            this.toolStripButton_Close});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(227, 31);
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
            // tabControl_Bottom
            // 
            this.tabControl_Bottom.Controls.Add(this.tabPage_Base);
            this.tabControl_Bottom.Controls.Add(this.tabPage_Range);
            this.tabControl_Bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Bottom.Location = new System.Drawing.Point(0, 31);
            this.tabControl_Bottom.Name = "tabControl_Bottom";
            this.tabControl_Bottom.SelectedIndex = 0;
            this.tabControl_Bottom.Size = new System.Drawing.Size(227, 179);
            this.tabControl_Bottom.TabIndex = 24;
            // 
            // tabPage_Base
            // 
            this.tabPage_Base.Controls.Add(this.groupBox1);
            this.tabPage_Base.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Base.Name = "tabPage_Base";
            this.tabPage_Base.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Base.Size = new System.Drawing.Size(219, 153);
            this.tabPage_Base.TabIndex = 0;
            this.tabPage_Base.Text = "基础";
            this.tabPage_Base.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_BottomPriceRate);
            this.groupBox1.Controls.Add(this.textBox_BottomPriceLimit);
            this.groupBox1.Controls.Add(this.textBox_BottomAmount);
            this.groupBox1.Controls.Add(this.textBox_BottomPrice);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 147);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "底价设置";
            // 
            // textBox_BottomPriceRate
            // 
            this.textBox_BottomPriceRate.Location = new System.Drawing.Point(78, 111);
            this.textBox_BottomPriceRate.Name = "textBox_BottomPriceRate";
            this.textBox_BottomPriceRate.Size = new System.Drawing.Size(101, 21);
            this.textBox_BottomPriceRate.TabIndex = 3;
            this.textBox_BottomPriceRate.Text = "0";
            this.textBox_BottomPriceRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_BottomPriceLimit
            // 
            this.textBox_BottomPriceLimit.Location = new System.Drawing.Point(78, 82);
            this.textBox_BottomPriceLimit.Name = "textBox_BottomPriceLimit";
            this.textBox_BottomPriceLimit.Size = new System.Drawing.Size(101, 21);
            this.textBox_BottomPriceLimit.TabIndex = 2;
            this.textBox_BottomPriceLimit.Text = "0";
            this.textBox_BottomPriceLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_BottomAmount
            // 
            this.textBox_BottomAmount.Location = new System.Drawing.Point(78, 53);
            this.textBox_BottomAmount.Name = "textBox_BottomAmount";
            this.textBox_BottomAmount.Size = new System.Drawing.Size(101, 21);
            this.textBox_BottomAmount.TabIndex = 1;
            this.textBox_BottomAmount.Text = "0";
            this.textBox_BottomAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_BottomPrice
            // 
            this.textBox_BottomPrice.Location = new System.Drawing.Point(78, 24);
            this.textBox_BottomPrice.Name = "textBox_BottomPrice";
            this.textBox_BottomPrice.Size = new System.Drawing.Size(101, 21);
            this.textBox_BottomPrice.TabIndex = 0;
            this.textBox_BottomPrice.Text = "0";
            this.textBox_BottomPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "总价底价";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "单价底价";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "底价限价";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "溢价分成";
            // 
            // tabPage_Range
            // 
            this.tabPage_Range.Controls.Add(this.textBox_Range);
            this.tabPage_Range.Controls.Add(this.label5);
            this.tabPage_Range.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Range.Name = "tabPage_Range";
            this.tabPage_Range.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Range.Size = new System.Drawing.Size(219, 153);
            this.tabPage_Range.TabIndex = 1;
            this.tabPage_Range.Text = "幅度";
            this.tabPage_Range.UseVisualStyleBackColor = true;
            // 
            // textBox_Range
            // 
            this.textBox_Range.Location = new System.Drawing.Point(80, 28);
            this.textBox_Range.Name = "textBox_Range";
            this.textBox_Range.Size = new System.Drawing.Size(101, 21);
            this.textBox_Range.TabIndex = 2;
            this.textBox_Range.Text = "0";
            this.textBox_Range.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "底价增幅";
            // 
            // FrmBottomSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 210);
            this.Controls.Add(this.tabControl_Bottom);
            this.Controls.Add(this.toolStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmBottomSet";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "底价设置";
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabControl_Bottom.ResumeLayout(false);
            this.tabPage_Base.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage_Range.ResumeLayout(false);
            this.tabPage_Range.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Save;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.TabControl tabControl_Bottom;
        private System.Windows.Forms.TabPage tabPage_Base;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_BottomPriceRate;
        private System.Windows.Forms.TextBox textBox_BottomPriceLimit;
        private System.Windows.Forms.TextBox textBox_BottomAmount;
        private System.Windows.Forms.TextBox textBox_BottomPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage_Range;
        private System.Windows.Forms.TextBox textBox_Range;
        private System.Windows.Forms.Label label5;
    }
}