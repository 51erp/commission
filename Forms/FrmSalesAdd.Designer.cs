namespace Commission.Forms
{
    partial class FrmSalesAdd
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
            this.textBox_Phone = new System.Windows.Forms.TextBox();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Memo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Position = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dateTimePicker_In = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_Position = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_Position);
            this.groupBox1.Controls.Add(this.dateTimePicker_In);
            this.groupBox1.Controls.Add(this.textBox_Phone);
            this.groupBox1.Controls.Add(this.textBox_Name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_Memo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_Position);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Size = new System.Drawing.Size(398, 132);
            this.groupBox1.Text = "置业顾问信息";
            // 
            // textBox_Phone
            // 
            this.textBox_Phone.Location = new System.Drawing.Point(265, 21);
            this.textBox_Phone.Name = "textBox_Phone";
            this.textBox_Phone.Size = new System.Drawing.Size(120, 21);
            this.textBox_Phone.TabIndex = 47;
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(80, 21);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(120, 21);
            this.textBox_Name.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 52;
            this.label1.Text = "备注";
            // 
            // textBox_Memo
            // 
            this.textBox_Memo.Location = new System.Drawing.Point(80, 98);
            this.textBox_Memo.Name = "textBox_Memo";
            this.textBox_Memo.Size = new System.Drawing.Size(305, 21);
            this.textBox_Memo.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 53;
            this.label3.Text = "入职时间";
            // 
            // textBox_Position
            // 
            this.textBox_Position.Location = new System.Drawing.Point(265, 46);
            this.textBox_Position.Name = "textBox_Position";
            this.textBox_Position.Size = new System.Drawing.Size(120, 21);
            this.textBox_Position.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 50;
            this.label2.Text = "电话";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 51;
            this.label15.Text = "姓名";
            // 
            // dateTimePicker_In
            // 
            this.dateTimePicker_In.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_In.Location = new System.Drawing.Point(80, 71);
            this.dateTimePicker_In.Name = "dateTimePicker_In";
            this.dateTimePicker_In.Size = new System.Drawing.Size(120, 21);
            this.dateTimePicker_In.TabIndex = 54;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 53;
            this.label5.Text = "职位";
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
            this.comboBox_Position.Location = new System.Drawing.Point(80, 46);
            this.comboBox_Position.Name = "comboBox_Position";
            this.comboBox_Position.Size = new System.Drawing.Size(120, 20);
            this.comboBox_Position.TabIndex = 55;
            // 
            // FrmSalesAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 174);
            this.Name = "FrmSalesAdd";
            this.ShowInTaskbar = false;
            this.Text = "添加置业顾问信息";
            this.Load += new System.EventHandler(this.FrmSalesAdd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Phone;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Memo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Position;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dateTimePicker_In;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_Position;
    }
}