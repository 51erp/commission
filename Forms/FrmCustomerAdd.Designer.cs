namespace Commission.Forms
{
    partial class FrmCustomerAdd
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
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_PID = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox_Addr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Phone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_CusType = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_CusType);
            this.groupBox1.Controls.Add(this.textBox_Phone);
            this.groupBox1.Controls.Add(this.textBox_Name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_Addr);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_PID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Size = new System.Drawing.Size(365, 159);
            this.groupBox1.Text = "客户信息";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(68, 21);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(281, 21);
            this.textBox_Name.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 45;
            this.label3.Text = "身份证号";
            // 
            // textBox_PID
            // 
            this.textBox_PID.Location = new System.Drawing.Point(68, 75);
            this.textBox_PID.Name = "textBox_PID";
            this.textBox_PID.Size = new System.Drawing.Size(281, 21);
            this.textBox_PID.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 44;
            this.label15.Text = "客户名称";
            // 
            // textBox_Addr
            // 
            this.textBox_Addr.Location = new System.Drawing.Point(68, 102);
            this.textBox_Addr.Name = "textBox_Addr";
            this.textBox_Addr.Size = new System.Drawing.Size(281, 21);
            this.textBox_Addr.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 45;
            this.label1.Text = "地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 44;
            this.label2.Text = "电话";
            // 
            // textBox_Phone
            // 
            this.textBox_Phone.Location = new System.Drawing.Point(68, 48);
            this.textBox_Phone.Name = "textBox_Phone";
            this.textBox_Phone.Size = new System.Drawing.Size(281, 21);
            this.textBox_Phone.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 45;
            this.label4.Text = "客户类型";
            // 
            // textBox_CusType
            // 
            this.textBox_CusType.Location = new System.Drawing.Point(68, 129);
            this.textBox_CusType.Name = "textBox_CusType";
            this.textBox_CusType.Size = new System.Drawing.Size(281, 21);
            this.textBox_CusType.TabIndex = 46;
            // 
            // FrmCustomerAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 201);
            this.Name = "FrmCustomerAdd";
            this.ShowInTaskbar = false;
            this.Text = "添加客户信息";
            this.Load += new System.EventHandler(this.FrmCustomerAdd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_PID;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox_Phone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Addr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_CusType;
    }
}