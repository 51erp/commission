namespace Commission.Forms
{
    partial class FrmEmployeAdd
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_Position = new System.Windows.Forms.ComboBox();
            this.dateTimePicker_JobBeginDate = new System.Windows.Forms.DateTimePicker();
            this.textBox_Phone = new System.Windows.Forms.TextBox();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Memo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_DeptName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_JobType = new System.Windows.Forms.ComboBox();
            this.toolStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Save,
            this.toolStripSeparator1,
            this.toolStripButton_Close});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(382, 31);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
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
            this.groupBox1.Controls.Add(this.comboBox_JobType);
            this.groupBox1.Controls.Add(this.comboBox_Position);
            this.groupBox1.Controls.Add(this.dateTimePicker_JobBeginDate);
            this.groupBox1.Controls.Add(this.textBox_Phone);
            this.groupBox1.Controls.Add(this.textBox_Name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_Memo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_DeptName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.groupBox1.Size = new System.Drawing.Size(382, 132);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // comboBox_Position
            // 
            this.comboBox_Position.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Position.FormattingEnabled = true;
            this.comboBox_Position.Items.AddRange(new object[] {
            "置业顾问",
            "销售经理",
            "项目总监",
            "策划",
            "财务"});
            this.comboBox_Position.Location = new System.Drawing.Point(244, 41);
            this.comboBox_Position.Name = "comboBox_Position";
            this.comboBox_Position.Size = new System.Drawing.Size(120, 20);
            this.comboBox_Position.TabIndex = 66;
            // 
            // dateTimePicker_JobBeginDate
            // 
            this.dateTimePicker_JobBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_JobBeginDate.Location = new System.Drawing.Point(71, 67);
            this.dateTimePicker_JobBeginDate.Name = "dateTimePicker_JobBeginDate";
            this.dateTimePicker_JobBeginDate.Size = new System.Drawing.Size(120, 21);
            this.dateTimePicker_JobBeginDate.TabIndex = 65;
            // 
            // textBox_Phone
            // 
            this.textBox_Phone.Location = new System.Drawing.Point(244, 15);
            this.textBox_Phone.Name = "textBox_Phone";
            this.textBox_Phone.Size = new System.Drawing.Size(120, 21);
            this.textBox_Phone.TabIndex = 57;
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(71, 15);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(120, 21);
            this.textBox_Name.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 62;
            this.label1.Text = "备注";
            // 
            // textBox_Memo
            // 
            this.textBox_Memo.Location = new System.Drawing.Point(71, 93);
            this.textBox_Memo.Name = "textBox_Memo";
            this.textBox_Memo.Size = new System.Drawing.Size(293, 21);
            this.textBox_Memo.TabIndex = 59;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 63;
            this.label4.Text = "职位";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 63;
            this.label5.Text = "部门";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 64;
            this.label3.Text = "入职时间";
            // 
            // textBox_DeptName
            // 
            this.textBox_DeptName.Location = new System.Drawing.Point(71, 41);
            this.textBox_DeptName.Name = "textBox_DeptName";
            this.textBox_DeptName.ReadOnly = true;
            this.textBox_DeptName.Size = new System.Drawing.Size(120, 21);
            this.textBox_DeptName.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 60;
            this.label2.Text = "电话";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 61;
            this.label15.Text = "姓名";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(209, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 63;
            this.label6.Text = "类型";
            // 
            // comboBox_JobType
            // 
            this.comboBox_JobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_JobType.FormattingEnabled = true;
            this.comboBox_JobType.Items.AddRange(new object[] {
            "员工",
            "主管"});
            this.comboBox_JobType.Location = new System.Drawing.Point(244, 67);
            this.comboBox_JobType.Name = "comboBox_JobType";
            this.comboBox_JobType.Size = new System.Drawing.Size(120, 20);
            this.comboBox_JobType.TabIndex = 66;
            // 
            // FrmEmployeAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 163);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmEmployeAdd";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增置业顾问";
            this.Load += new System.EventHandler(this.FrmEmployeAdd_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        public System.Windows.Forms.ToolStripButton toolStripButton_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        public System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_Position;
        private System.Windows.Forms.DateTimePicker dateTimePicker_JobBeginDate;
        private System.Windows.Forms.TextBox textBox_Phone;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Memo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_DeptName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_JobType;
        private System.Windows.Forms.Label label6;
    }
}