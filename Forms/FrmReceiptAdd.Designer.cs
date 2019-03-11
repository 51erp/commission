namespace Commission.Forms
{
    partial class FrmReceiptAdd
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
            this.dateTimePicker_Receipt = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_RecAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_ReceiptType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Memo = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_ReceiptType);
            this.groupBox1.Controls.Add(this.textBox_Memo);
            this.groupBox1.Controls.Add(this.textBox_RecAmount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.dateTimePicker_Receipt);
            this.groupBox1.Size = new System.Drawing.Size(407, 109);
            this.groupBox1.Text = "款项信息";
            // 
            // dateTimePicker_Receipt
            // 
            this.dateTimePicker_Receipt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Receipt.Location = new System.Drawing.Point(280, 51);
            this.dateTimePicker_Receipt.Name = "dateTimePicker_Receipt";
            this.dateTimePicker_Receipt.Size = new System.Drawing.Size(102, 21);
            this.dateTimePicker_Receipt.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(221, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 52;
            this.label15.Text = "收款时间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 52;
            this.label1.Text = "收款金额";
            // 
            // textBox_RecAmount
            // 
            this.textBox_RecAmount.Location = new System.Drawing.Point(79, 25);
            this.textBox_RecAmount.Name = "textBox_RecAmount";
            this.textBox_RecAmount.Size = new System.Drawing.Size(121, 21);
            this.textBox_RecAmount.TabIndex = 1;
            this.textBox_RecAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_RecAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNumeric);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 52;
            this.label2.Text = "收款类型";
            // 
            // comboBox_ReceiptType
            // 
            this.comboBox_ReceiptType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ReceiptType.FormattingEnabled = true;
            this.comboBox_ReceiptType.Location = new System.Drawing.Point(79, 52);
            this.comboBox_ReceiptType.Name = "comboBox_ReceiptType";
            this.comboBox_ReceiptType.Size = new System.Drawing.Size(121, 20);
            this.comboBox_ReceiptType.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 52;
            this.label3.Text = "备注说明";
            // 
            // textBox_Memo
            // 
            this.textBox_Memo.Location = new System.Drawing.Point(79, 79);
            this.textBox_Memo.Name = "textBox_Memo";
            this.textBox_Memo.Size = new System.Drawing.Size(303, 21);
            this.textBox_Memo.TabIndex = 4;
            // 
            // FrmReceiptAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 151);
            this.Name = "FrmReceiptAdd";
            this.ShowInTaskbar = false;
            this.Text = "新增收款信息";
            this.Load += new System.EventHandler(this.FrmReceiptAdd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker_Receipt;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox_RecAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_ReceiptType;
        private System.Windows.Forms.TextBox textBox_Memo;
        private System.Windows.Forms.Label label3;
    }
}