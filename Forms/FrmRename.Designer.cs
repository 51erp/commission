namespace Commission.Forms
{
    partial class FrmRename
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
            this.textBox_OrigCusPID = new System.Windows.Forms.TextBox();
            this.textBox_OrigCusPhone = new System.Windows.Forms.TextBox();
            this.textBox_OrigCusAddr = new System.Windows.Forms.TextBox();
            this.textBox_OrigCusName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker_ChangeNameDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_AgreementNum = new System.Windows.Forms.Label();
            this.textBox_Relation = new System.Windows.Forms.TextBox();
            this.textBox_Memo = new System.Windows.Forms.TextBox();
            this.textBox_AgreementNum = new System.Windows.Forms.TextBox();
            this.button_CusMore = new System.Windows.Forms.Button();
            this.textBox_CusPID = new System.Windows.Forms.TextBox();
            this.textBox_CusPhone = new System.Windows.Forms.TextBox();
            this.textBox_CusAddr = new System.Windows.Forms.TextBox();
            this.textBox_CusName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
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
            this.toolStripButton_Close});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(635, 31);
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
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel1.Size = new System.Drawing.Size(635, 82);
            this.panel1.TabIndex = 23;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_OrigCusPID);
            this.groupBox1.Controls.Add(this.textBox_OrigCusPhone);
            this.groupBox1.Controls.Add(this.textBox_OrigCusAddr);
            this.groupBox1.Controls.Add(this.textBox_OrigCusName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(635, 77);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "原客户信息";
            // 
            // textBox_OrigCusPID
            // 
            this.textBox_OrigCusPID.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_OrigCusPID.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_OrigCusPID.Location = new System.Drawing.Point(467, 44);
            this.textBox_OrigCusPID.Name = "textBox_OrigCusPID";
            this.textBox_OrigCusPID.ReadOnly = true;
            this.textBox_OrigCusPID.Size = new System.Drawing.Size(130, 21);
            this.textBox_OrigCusPID.TabIndex = 36;
            this.textBox_OrigCusPID.TabStop = false;
            // 
            // textBox_OrigCusPhone
            // 
            this.textBox_OrigCusPhone.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_OrigCusPhone.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_OrigCusPhone.Location = new System.Drawing.Point(467, 17);
            this.textBox_OrigCusPhone.Name = "textBox_OrigCusPhone";
            this.textBox_OrigCusPhone.ReadOnly = true;
            this.textBox_OrigCusPhone.Size = new System.Drawing.Size(130, 21);
            this.textBox_OrigCusPhone.TabIndex = 36;
            this.textBox_OrigCusPhone.TabStop = false;
            // 
            // textBox_OrigCusAddr
            // 
            this.textBox_OrigCusAddr.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_OrigCusAddr.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_OrigCusAddr.Location = new System.Drawing.Point(71, 44);
            this.textBox_OrigCusAddr.Name = "textBox_OrigCusAddr";
            this.textBox_OrigCusAddr.ReadOnly = true;
            this.textBox_OrigCusAddr.Size = new System.Drawing.Size(306, 21);
            this.textBox_OrigCusAddr.TabIndex = 36;
            this.textBox_OrigCusAddr.TabStop = false;
            // 
            // textBox_OrigCusName
            // 
            this.textBox_OrigCusName.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_OrigCusName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_OrigCusName.Location = new System.Drawing.Point(71, 17);
            this.textBox_OrigCusName.Name = "textBox_OrigCusName";
            this.textBox_OrigCusName.ReadOnly = true;
            this.textBox_OrigCusName.Size = new System.Drawing.Size(306, 21);
            this.textBox_OrigCusName.TabIndex = 36;
            this.textBox_OrigCusName.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(408, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 34;
            this.label2.Text = "身份证号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 33;
            this.label3.Text = "客户地址";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(408, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 32;
            this.label4.Text = "客户电话";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 31;
            this.label5.Text = "客户姓名";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 113);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel2.Size = new System.Drawing.Size(635, 132);
            this.panel2.TabIndex = 24;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTimePicker_ChangeNameDate);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label_AgreementNum);
            this.groupBox2.Controls.Add(this.textBox_Relation);
            this.groupBox2.Controls.Add(this.textBox_Memo);
            this.groupBox2.Controls.Add(this.textBox_AgreementNum);
            this.groupBox2.Controls.Add(this.button_CusMore);
            this.groupBox2.Controls.Add(this.textBox_CusPID);
            this.groupBox2.Controls.Add(this.textBox_CusPhone);
            this.groupBox2.Controls.Add(this.textBox_CusAddr);
            this.groupBox2.Controls.Add(this.textBox_CusName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(635, 127);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "新客户信息";
            // 
            // dateTimePicker_ChangeNameDate
            // 
            this.dateTimePicker_ChangeNameDate.Location = new System.Drawing.Point(467, 71);
            this.dateTimePicker_ChangeNameDate.Name = "dateTimePicker_ChangeNameDate";
            this.dateTimePicker_ChangeNameDate.Size = new System.Drawing.Size(130, 21);
            this.dateTimePicker_ChangeNameDate.TabIndex = 41;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(408, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 40;
            this.label7.Text = "变更关系";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 40;
            this.label6.Text = "备注说明";
            // 
            // label_AgreementNum
            // 
            this.label_AgreementNum.AutoSize = true;
            this.label_AgreementNum.Location = new System.Drawing.Point(12, 75);
            this.label_AgreementNum.Name = "label_AgreementNum";
            this.label_AgreementNum.Size = new System.Drawing.Size(53, 12);
            this.label_AgreementNum.TabIndex = 40;
            this.label_AgreementNum.Text = "签约编号";
            // 
            // textBox_Relation
            // 
            this.textBox_Relation.Location = new System.Drawing.Point(467, 98);
            this.textBox_Relation.Name = "textBox_Relation";
            this.textBox_Relation.Size = new System.Drawing.Size(130, 21);
            this.textBox_Relation.TabIndex = 39;
            // 
            // textBox_Memo
            // 
            this.textBox_Memo.Location = new System.Drawing.Point(71, 98);
            this.textBox_Memo.Name = "textBox_Memo";
            this.textBox_Memo.Size = new System.Drawing.Size(306, 21);
            this.textBox_Memo.TabIndex = 39;
            // 
            // textBox_AgreementNum
            // 
            this.textBox_AgreementNum.Location = new System.Drawing.Point(71, 71);
            this.textBox_AgreementNum.Name = "textBox_AgreementNum";
            this.textBox_AgreementNum.Size = new System.Drawing.Size(306, 21);
            this.textBox_AgreementNum.TabIndex = 39;
            // 
            // button_CusMore
            // 
            this.button_CusMore.Image = global::Commission.Properties.Resources.more;
            this.button_CusMore.Location = new System.Drawing.Point(603, 42);
            this.button_CusMore.Name = "button_CusMore";
            this.button_CusMore.Size = new System.Drawing.Size(26, 23);
            this.button_CusMore.TabIndex = 37;
            this.button_CusMore.UseVisualStyleBackColor = true;
            this.button_CusMore.Click += new System.EventHandler(this.button_CusMore_Click);
            // 
            // textBox_CusPID
            // 
            this.textBox_CusPID.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_CusPID.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_CusPID.Location = new System.Drawing.Point(467, 44);
            this.textBox_CusPID.Name = "textBox_CusPID";
            this.textBox_CusPID.ReadOnly = true;
            this.textBox_CusPID.Size = new System.Drawing.Size(130, 21);
            this.textBox_CusPID.TabIndex = 36;
            this.textBox_CusPID.TabStop = false;
            // 
            // textBox_CusPhone
            // 
            this.textBox_CusPhone.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_CusPhone.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_CusPhone.Location = new System.Drawing.Point(467, 17);
            this.textBox_CusPhone.Name = "textBox_CusPhone";
            this.textBox_CusPhone.ReadOnly = true;
            this.textBox_CusPhone.Size = new System.Drawing.Size(130, 21);
            this.textBox_CusPhone.TabIndex = 36;
            this.textBox_CusPhone.TabStop = false;
            // 
            // textBox_CusAddr
            // 
            this.textBox_CusAddr.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_CusAddr.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_CusAddr.Location = new System.Drawing.Point(71, 44);
            this.textBox_CusAddr.Name = "textBox_CusAddr";
            this.textBox_CusAddr.ReadOnly = true;
            this.textBox_CusAddr.Size = new System.Drawing.Size(306, 21);
            this.textBox_CusAddr.TabIndex = 36;
            this.textBox_CusAddr.TabStop = false;
            // 
            // textBox_CusName
            // 
            this.textBox_CusName.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_CusName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_CusName.Location = new System.Drawing.Point(71, 17);
            this.textBox_CusName.Name = "textBox_CusName";
            this.textBox_CusName.ReadOnly = true;
            this.textBox_CusName.Size = new System.Drawing.Size(306, 21);
            this.textBox_CusName.TabIndex = 36;
            this.textBox_CusName.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(408, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "更名日期";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(408, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 34;
            this.label14.Text = "身份证号";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 33;
            this.label13.Text = "客户地址";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(408, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 32;
            this.label12.Text = "客户电话";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 31;
            this.label11.Text = "客户姓名";
            // 
            // FrmRename
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 245);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRename";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "签约更名";
            this.Load += new System.EventHandler(this.FrmRename_Load);
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
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_CusMore;
        private System.Windows.Forms.TextBox textBox_CusPID;
        private System.Windows.Forms.TextBox textBox_CusPhone;
        private System.Windows.Forms.TextBox textBox_CusAddr;
        private System.Windows.Forms.TextBox textBox_CusName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_OrigCusPID;
        private System.Windows.Forms.TextBox textBox_OrigCusPhone;
        private System.Windows.Forms.TextBox textBox_OrigCusAddr;
        private System.Windows.Forms.TextBox textBox_OrigCusName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_AgreementNum;
        private System.Windows.Forms.TextBox textBox_AgreementNum;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ChangeNameDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Memo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Relation;
    }
}