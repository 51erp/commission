﻿namespace Commission.Forms
{
    partial class FrmSettleSet
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_Stardard = new System.Windows.Forms.ComboBox();
            this.comboBox_Base = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Save,
            this.toolStripButton_Close});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(234, 31);
            this.toolStrip2.TabIndex = 22;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.panel1.Size = new System.Drawing.Size(234, 112);
            this.panel1.TabIndex = 23;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_Stardard);
            this.groupBox1.Controls.Add(this.comboBox_Base);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 101);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "结算基础和条件";
            // 
            // comboBox_Stardard
            // 
            this.comboBox_Stardard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Stardard.FormattingEnabled = true;
            this.comboBox_Stardard.Location = new System.Drawing.Point(67, 26);
            this.comboBox_Stardard.Name = "comboBox_Stardard";
            this.comboBox_Stardard.Size = new System.Drawing.Size(149, 20);
            this.comboBox_Stardard.TabIndex = 2;
            this.comboBox_Stardard.SelectedIndexChanged += new System.EventHandler(this.comboBox_Stardard_SelectedIndexChanged);
            // 
            // comboBox_Base
            // 
            this.comboBox_Base.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Base.FormattingEnabled = true;
            this.comboBox_Base.Location = new System.Drawing.Point(67, 61);
            this.comboBox_Base.Name = "comboBox_Base";
            this.comboBox_Base.Size = new System.Drawing.Size(149, 20);
            this.comboBox_Base.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "结算条件";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "结算基础";
            // 
            // FrmSettleSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 143);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSettleSet";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "结算设置";
            this.Load += new System.EventHandler(this.FrmSettleSet_Load);
            this.Shown += new System.EventHandler(this.FrmSettleSet_Shown);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Save;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Stardard;
        private System.Windows.Forms.ComboBox comboBox_Base;
    }
}