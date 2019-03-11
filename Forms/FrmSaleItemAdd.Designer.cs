namespace Commission.Forms
{
    partial class FrmSaleItemAdd
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
            this.checkBox_SaleType = new System.Windows.Forms.CheckBox();
            this.comboBox_ItemType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_Area = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Amount = new System.Windows.Forms.TextBox();
            this.textBox_Price = new System.Windows.Forms.TextBox();
            this.textBox_Building = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Unit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_ItemNum = new System.Windows.Forms.TextBox();
            this.toolStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.toolStrip2.Size = new System.Drawing.Size(467, 31);
            this.toolStrip2.TabIndex = 21;
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
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.panel1.Size = new System.Drawing.Size(467, 120);
            this.panel1.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_SaleType);
            this.groupBox1.Controls.Add(this.comboBox_ItemType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox_Area);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_Amount);
            this.groupBox1.Controls.Add(this.textBox_Price);
            this.groupBox1.Controls.Add(this.textBox_Building);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox_Unit);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_ItemNum);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 112);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "销售项目信息";
            // 
            // checkBox_SaleType
            // 
            this.checkBox_SaleType.AutoSize = true;
            this.checkBox_SaleType.Location = new System.Drawing.Point(209, 82);
            this.checkBox_SaleType.Name = "checkBox_SaleType";
            this.checkBox_SaleType.Size = new System.Drawing.Size(72, 16);
            this.checkBox_SaleType.TabIndex = 47;
            this.checkBox_SaleType.Text = "附属物业";
            this.checkBox_SaleType.UseVisualStyleBackColor = true;
            // 
            // comboBox_ItemType
            // 
            this.comboBox_ItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ItemType.FormattingEnabled = true;
            this.comboBox_ItemType.Items.AddRange(new object[] {
            "房产",
            "商业",
            "地下室",
            "车位"});
            this.comboBox_ItemType.Location = new System.Drawing.Point(68, 79);
            this.comboBox_ItemType.Name = "comboBox_ItemType";
            this.comboBox_ItemType.Size = new System.Drawing.Size(100, 20);
            this.comboBox_ItemType.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 46;
            this.label1.Text = "项目类型";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 40;
            this.label8.Text = "面积";
            // 
            // textBox_Area
            // 
            this.textBox_Area.Location = new System.Drawing.Point(68, 50);
            this.textBox_Area.Name = "textBox_Area";
            this.textBox_Area.Size = new System.Drawing.Size(100, 21);
            this.textBox_Area.TabIndex = 4;
            this.textBox_Area.Text = "0";
            this.textBox_Area.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_Area.TextChanged += new System.EventHandler(this.CalcAmount);
            this.textBox_Area.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_OnlyNumeric);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 40;
            this.label2.Text = "楼号";
            // 
            // textBox_Amount
            // 
            this.textBox_Amount.Location = new System.Drawing.Point(350, 51);
            this.textBox_Amount.Name = "textBox_Amount";
            this.textBox_Amount.Size = new System.Drawing.Size(100, 21);
            this.textBox_Amount.TabIndex = 6;
            this.textBox_Amount.Text = "0";
            this.textBox_Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_Amount.TextChanged += new System.EventHandler(this.CalcAmount);
            this.textBox_Amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_OnlyNumeric);
            // 
            // textBox_Price
            // 
            this.textBox_Price.Location = new System.Drawing.Point(209, 50);
            this.textBox_Price.Name = "textBox_Price";
            this.textBox_Price.Size = new System.Drawing.Size(100, 21);
            this.textBox_Price.TabIndex = 5;
            this.textBox_Price.Text = "0";
            this.textBox_Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_Price.TextChanged += new System.EventHandler(this.CalcAmount);
            this.textBox_Price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_OnlyNumeric);
            // 
            // textBox_Building
            // 
            this.textBox_Building.Location = new System.Drawing.Point(68, 22);
            this.textBox_Building.Name = "textBox_Building";
            this.textBox_Building.Size = new System.Drawing.Size(100, 21);
            this.textBox_Building.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(315, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 41;
            this.label6.Text = "总价";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(174, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 41;
            this.label5.Text = "单价";
            // 
            // textBox_Unit
            // 
            this.textBox_Unit.Location = new System.Drawing.Point(209, 22);
            this.textBox_Unit.Name = "textBox_Unit";
            this.textBox_Unit.Size = new System.Drawing.Size(100, 21);
            this.textBox_Unit.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 41;
            this.label3.Text = "单元";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(315, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 42;
            this.label4.Text = "编号";
            // 
            // textBox_ItemNum
            // 
            this.textBox_ItemNum.Location = new System.Drawing.Point(350, 22);
            this.textBox_ItemNum.Name = "textBox_ItemNum";
            this.textBox_ItemNum.Size = new System.Drawing.Size(100, 21);
            this.textBox_ItemNum.TabIndex = 3;
            // 
            // FrmSaleItemAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 151);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSaleItemAdd";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增房源";
            this.Load += new System.EventHandler(this.FrmSaleItemAdd_Load);
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Building;
        private System.Windows.Forms.TextBox textBox_Unit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_ItemNum;
        private System.Windows.Forms.ComboBox comboBox_ItemType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_Area;
        private System.Windows.Forms.TextBox textBox_Price;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox_SaleType;
        private System.Windows.Forms.TextBox textBox_Amount;
        private System.Windows.Forms.Label label6;
    }
}