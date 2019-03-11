namespace Commission.Forms
{
    partial class FrmSupplement
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_TotalAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_DownPayRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_DownPay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_DP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Loan = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_NewDP = new System.Windows.Forms.TextBox();
            this.textBox_LoanTotal = new System.Windows.Forms.TextBox();
            this.textBox_DownPayTotal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_Supplement = new System.Windows.Forms.TextBox();
            this.comboBox_DownPayRate = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_ContractCode = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dateTimePicker_ContractDate = new System.Windows.Forms.DateTimePicker();
            this.toolStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.toolStrip2.Size = new System.Drawing.Size(379, 31);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.panel1.Size = new System.Drawing.Size(379, 109);
            this.panel1.TabIndex = 25;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_DownPay);
            this.groupBox1.Controls.Add(this.textBox_Loan);
            this.groupBox1.Controls.Add(this.textBox_DP);
            this.groupBox1.Controls.Add(this.textBox_DownPayRate);
            this.groupBox1.Controls.Add(this.textBox_TotalAmount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 101);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "签约信息";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 140);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.panel2.Size = new System.Drawing.Size(379, 134);
            this.panel2.TabIndex = 26;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTimePicker_ContractDate);
            this.groupBox2.Controls.Add(this.comboBox_DownPayRate);
            this.groupBox2.Controls.Add(this.textBox_ContractCode);
            this.groupBox2.Controls.Add(this.textBox_Supplement);
            this.groupBox2.Controls.Add(this.textBox_DownPayTotal);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox_LoanTotal);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox_NewDP);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(373, 126);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "付款信息";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "签约总款";
            // 
            // textBox_TotalAmount
            // 
            this.textBox_TotalAmount.Location = new System.Drawing.Point(69, 18);
            this.textBox_TotalAmount.Name = "textBox_TotalAmount";
            this.textBox_TotalAmount.ReadOnly = true;
            this.textBox_TotalAmount.Size = new System.Drawing.Size(100, 21);
            this.textBox_TotalAmount.TabIndex = 1;
            this.textBox_TotalAmount.TabStop = false;
            this.textBox_TotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "首付比例";
            // 
            // textBox_DownPayRate
            // 
            this.textBox_DownPayRate.Location = new System.Drawing.Point(69, 45);
            this.textBox_DownPayRate.Name = "textBox_DownPayRate";
            this.textBox_DownPayRate.ReadOnly = true;
            this.textBox_DownPayRate.Size = new System.Drawing.Size(100, 21);
            this.textBox_DownPayRate.TabIndex = 1;
            this.textBox_DownPayRate.TabStop = false;
            this.textBox_DownPayRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "应付首付";
            // 
            // textBox_DownPay
            // 
            this.textBox_DownPay.Location = new System.Drawing.Point(69, 71);
            this.textBox_DownPay.Name = "textBox_DownPay";
            this.textBox_DownPay.ReadOnly = true;
            this.textBox_DownPay.Size = new System.Drawing.Size(100, 21);
            this.textBox_DownPay.TabIndex = 1;
            this.textBox_DownPay.TabStop = false;
            this.textBox_DownPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(203, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "首付金额";
            // 
            // textBox_DP
            // 
            this.textBox_DP.Location = new System.Drawing.Point(262, 45);
            this.textBox_DP.Name = "textBox_DP";
            this.textBox_DP.ReadOnly = true;
            this.textBox_DP.Size = new System.Drawing.Size(100, 21);
            this.textBox_DP.TabIndex = 1;
            this.textBox_DP.TabStop = false;
            this.textBox_DP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "贷款金额";
            // 
            // textBox_Loan
            // 
            this.textBox_Loan.Location = new System.Drawing.Point(262, 71);
            this.textBox_Loan.Name = "textBox_Loan";
            this.textBox_Loan.ReadOnly = true;
            this.textBox_Loan.Size = new System.Drawing.Size(100, 21);
            this.textBox_Loan.TabIndex = 1;
            this.textBox_Loan.TabStop = false;
            this.textBox_Loan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "首付比例";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(203, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "首付金额";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(203, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "贷款金额";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "首付总额";
            // 
            // textBox_NewDP
            // 
            this.textBox_NewDP.Location = new System.Drawing.Point(262, 21);
            this.textBox_NewDP.Name = "textBox_NewDP";
            this.textBox_NewDP.ReadOnly = true;
            this.textBox_NewDP.Size = new System.Drawing.Size(100, 21);
            this.textBox_NewDP.TabIndex = 1;
            this.textBox_NewDP.TabStop = false;
            this.textBox_NewDP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_LoanTotal
            // 
            this.textBox_LoanTotal.Location = new System.Drawing.Point(262, 47);
            this.textBox_LoanTotal.Name = "textBox_LoanTotal";
            this.textBox_LoanTotal.ReadOnly = true;
            this.textBox_LoanTotal.Size = new System.Drawing.Size(100, 21);
            this.textBox_LoanTotal.TabIndex = 1;
            this.textBox_LoanTotal.TabStop = false;
            this.textBox_LoanTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_DownPayTotal
            // 
            this.textBox_DownPayTotal.Location = new System.Drawing.Point(69, 47);
            this.textBox_DownPayTotal.Name = "textBox_DownPayTotal";
            this.textBox_DownPayTotal.ReadOnly = true;
            this.textBox_DownPayTotal.Size = new System.Drawing.Size(100, 21);
            this.textBox_DownPayTotal.TabIndex = 1;
            this.textBox_DownPayTotal.TabStop = false;
            this.textBox_DownPayTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "补交首付";
            // 
            // textBox_Supplement
            // 
            this.textBox_Supplement.Location = new System.Drawing.Point(69, 72);
            this.textBox_Supplement.Name = "textBox_Supplement";
            this.textBox_Supplement.Size = new System.Drawing.Size(100, 21);
            this.textBox_Supplement.TabIndex = 2;
            this.textBox_Supplement.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_Supplement.TextChanged += new System.EventHandler(this.textBox_Supplement_TextChanged);
            this.textBox_Supplement.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Supplement_KeyPress);
            // 
            // comboBox_DownPayRate
            // 
            this.comboBox_DownPayRate.FormattingEnabled = true;
            this.comboBox_DownPayRate.Items.AddRange(new object[] {
            "20",
            "30",
            "50"});
            this.comboBox_DownPayRate.Location = new System.Drawing.Point(69, 21);
            this.comboBox_DownPayRate.Name = "comboBox_DownPayRate";
            this.comboBox_DownPayRate.Size = new System.Drawing.Size(100, 20);
            this.comboBox_DownPayRate.TabIndex = 1;
            this.comboBox_DownPayRate.Text = "20";
            this.comboBox_DownPayRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_DownPayRate_KeyPress);
            this.comboBox_DownPayRate.Validating += new System.ComponentModel.CancelEventHandler(this.comboBox_DownPayRate_Validating);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(171, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "%";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(171, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "%";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 102);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "签约编号";
            // 
            // textBox_ContractCode
            // 
            this.textBox_ContractCode.Location = new System.Drawing.Point(69, 99);
            this.textBox_ContractCode.Name = "textBox_ContractCode";
            this.textBox_ContractCode.Size = new System.Drawing.Size(100, 21);
            this.textBox_ContractCode.TabIndex = 2;
            this.textBox_ContractCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_ContractCode.TextChanged += new System.EventHandler(this.textBox_Supplement_TextChanged);
            this.textBox_ContractCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Supplement_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(203, 102);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 0;
            this.label14.Text = "签约日期";
            // 
            // dateTimePicker_ContractDate
            // 
            this.dateTimePicker_ContractDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_ContractDate.Location = new System.Drawing.Point(262, 99);
            this.dateTimePicker_ContractDate.Name = "dateTimePicker_ContractDate";
            this.dateTimePicker_ContractDate.Size = new System.Drawing.Size(100, 21);
            this.dateTimePicker_ContractDate.TabIndex = 3;
            // 
            // FrmSupplement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 274);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSupplement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "补交首付款";
            this.Load += new System.EventHandler(this.FrmSupplement_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_TotalAmount;
        private System.Windows.Forms.TextBox textBox_DownPay;
        private System.Windows.Forms.TextBox textBox_Loan;
        private System.Windows.Forms.TextBox textBox_DP;
        private System.Windows.Forms.TextBox textBox_DownPayRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Supplement;
        private System.Windows.Forms.TextBox textBox_DownPayTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_LoanTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_NewDP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox_DownPayRate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_ContractCode;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ContractDate;
    }
}