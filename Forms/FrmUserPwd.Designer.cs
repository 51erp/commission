namespace Commission.Forms
{
    partial class FrmUserPwd
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_ConfirmPwd = new System.Windows.Forms.TextBox();
            this.textBox_NewPwd = new System.Windows.Forms.TextBox();
            this.textBox_OldPwd = new System.Windows.Forms.TextBox();
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.toolStrip2.SuspendLayout();
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
            this.toolStrip2.Size = new System.Drawing.Size(249, 31);
            this.toolStrip2.TabIndex = 24;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_ConfirmPwd);
            this.groupBox1.Controls.Add(this.textBox_NewPwd);
            this.groupBox1.Controls.Add(this.textBox_OldPwd);
            this.groupBox1.Controls.Add(this.textBox_UserName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 150);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "密码修改";
            // 
            // textBox_ConfirmPwd
            // 
            this.textBox_ConfirmPwd.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_ConfirmPwd.Location = new System.Drawing.Point(72, 112);
            this.textBox_ConfirmPwd.Name = "textBox_ConfirmPwd";
            this.textBox_ConfirmPwd.PasswordChar = '*';
            this.textBox_ConfirmPwd.Size = new System.Drawing.Size(165, 21);
            this.textBox_ConfirmPwd.TabIndex = 3;
            // 
            // textBox_NewPwd
            // 
            this.textBox_NewPwd.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_NewPwd.Location = new System.Drawing.Point(72, 86);
            this.textBox_NewPwd.Name = "textBox_NewPwd";
            this.textBox_NewPwd.PasswordChar = '*';
            this.textBox_NewPwd.Size = new System.Drawing.Size(165, 21);
            this.textBox_NewPwd.TabIndex = 2;
            // 
            // textBox_OldPwd
            // 
            this.textBox_OldPwd.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_OldPwd.Location = new System.Drawing.Point(72, 59);
            this.textBox_OldPwd.Name = "textBox_OldPwd";
            this.textBox_OldPwd.PasswordChar = '*';
            this.textBox_OldPwd.Size = new System.Drawing.Size(165, 21);
            this.textBox_OldPwd.TabIndex = 1;
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_UserName.Location = new System.Drawing.Point(72, 29);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.ReadOnly = true;
            this.textBox_UserName.Size = new System.Drawing.Size(165, 21);
            this.textBox_UserName.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 54;
            this.label3.Text = "确认密码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 54;
            this.label2.Text = "新密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 54;
            this.label1.Text = "原密码";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 54;
            this.label15.Text = "用户名称";
            // 
            // FrmUserPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 181);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmUserPwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户密码修改";
            this.Load += new System.EventHandler(this.FrmUserPwd_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Save;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox_OldPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_ConfirmPwd;
        private System.Windows.Forms.TextBox textBox_NewPwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}