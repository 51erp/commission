﻿namespace Commission.Report
{
    partial class AchSalesDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_RecType = new System.Windows.Forms.ComboBox();
            this.button_Save = new System.Windows.Forms.Button();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Begin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_Export = new System.Windows.Forms.Button();
            this.button_Search = new System.Windows.Forms.Button();
            this.dataGridView_Achievement = new System.Windows.Forms.DataGridView();
            this.ColContractID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSalesID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBuilding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSubscribeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColContractDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColReceiptDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPayPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAchievement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSalesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Achievement)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.panel1.Size = new System.Drawing.Size(973, 59);
            this.panel1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_RecType);
            this.groupBox1.Controls.Add(this.button_Save);
            this.groupBox1.Controls.Add(this.dateTimePicker_End);
            this.groupBox1.Controls.Add(this.dateTimePicker_Begin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button_Exit);
            this.groupBox1.Controls.Add(this.button_Export);
            this.groupBox1.Controls.Add(this.button_Search);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(967, 51);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // comboBox_RecType
            // 
            this.comboBox_RecType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_RecType.FormattingEnabled = true;
            this.comboBox_RecType.Location = new System.Drawing.Point(358, 18);
            this.comboBox_RecType.Name = "comboBox_RecType";
            this.comboBox_RecType.Size = new System.Drawing.Size(88, 20);
            this.comboBox_RecType.TabIndex = 29;
            // 
            // button_Save
            // 
            this.button_Save.Image = global::Commission.Properties.Resources.save_16;
            this.button_Save.Location = new System.Drawing.Point(839, 16);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 28;
            this.button_Save.Text = " 保存";
            this.button_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Visible = false;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.Checked = false;
            this.dateTimePicker_End.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_End.Location = new System.Drawing.Point(193, 18);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(100, 21);
            this.dateTimePicker_End.TabIndex = 27;
            // 
            // dateTimePicker_Begin
            // 
            this.dateTimePicker_Begin.Checked = false;
            this.dateTimePicker_Begin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Begin.Location = new System.Drawing.Point(69, 18);
            this.dateTimePicker_Begin.Name = "dateTimePicker_Begin";
            this.dateTimePicker_Begin.Size = new System.Drawing.Size(101, 21);
            this.dateTimePicker_Begin.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(299, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "收款类型";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "统计期间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(176, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "-";
            // 
            // button_Exit
            // 
            this.button_Exit.Image = global::Commission.Properties.Resources.exit;
            this.button_Exit.Location = new System.Drawing.Point(663, 17);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(75, 23);
            this.button_Exit.TabIndex = 17;
            this.button_Exit.Text = " 关闭";
            this.button_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_Export
            // 
            this.button_Export.Image = global::Commission.Properties.Resources.excel;
            this.button_Export.Location = new System.Drawing.Point(544, 17);
            this.button_Export.Name = "button_Export";
            this.button_Export.Size = new System.Drawing.Size(75, 23);
            this.button_Export.TabIndex = 1;
            this.button_Export.Text = " 导出";
            this.button_Export.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Export.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Export.UseVisualStyleBackColor = true;
            this.button_Export.Click += new System.EventHandler(this.button_Export_Click);
            // 
            // button_Search
            // 
            this.button_Search.Image = global::Commission.Properties.Resources.Find_16;
            this.button_Search.Location = new System.Drawing.Point(463, 17);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(75, 23);
            this.button_Search.TabIndex = 1;
            this.button_Search.Text = " 查询";
            this.button_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // dataGridView_Achievement
            // 
            this.dataGridView_Achievement.AllowUserToAddRows = false;
            this.dataGridView_Achievement.AllowUserToDeleteRows = false;
            this.dataGridView_Achievement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_Achievement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_Achievement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColContractID,
            this.ColSalesID,
            this.ColCustomerName,
            this.ColBuilding,
            this.ColUnit,
            this.ColItemNum,
            this.ColSubscribeDate,
            this.ColContractDate,
            this.ColReceiptDate,
            this.ColArea,
            this.ColPrice,
            this.ColAmount,
            this.ColTotalAmount,
            this.ColPayPercent,
            this.ColAchievement,
            this.ColSalesName});
            this.dataGridView_Achievement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Achievement.Location = new System.Drawing.Point(0, 59);
            this.dataGridView_Achievement.Name = "dataGridView_Achievement";
            this.dataGridView_Achievement.ReadOnly = true;
            this.dataGridView_Achievement.RowHeadersWidth = 21;
            this.dataGridView_Achievement.RowTemplate.Height = 23;
            this.dataGridView_Achievement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Achievement.Size = new System.Drawing.Size(973, 373);
            this.dataGridView_Achievement.TabIndex = 8;
            // 
            // ColContractID
            // 
            this.ColContractID.DataPropertyName = "ContractID";
            this.ColContractID.HeaderText = "ContractID";
            this.ColContractID.Name = "ColContractID";
            this.ColContractID.ReadOnly = true;
            this.ColContractID.Visible = false;
            this.ColContractID.Width = 90;
            // 
            // ColSalesID
            // 
            this.ColSalesID.DataPropertyName = "SalesID";
            this.ColSalesID.HeaderText = "SalesID";
            this.ColSalesID.Name = "ColSalesID";
            this.ColSalesID.ReadOnly = true;
            this.ColSalesID.Visible = false;
            this.ColSalesID.Width = 72;
            // 
            // ColCustomerName
            // 
            this.ColCustomerName.DataPropertyName = "CustomerName";
            this.ColCustomerName.HeaderText = "客户";
            this.ColCustomerName.Name = "ColCustomerName";
            this.ColCustomerName.ReadOnly = true;
            this.ColCustomerName.Width = 54;
            // 
            // ColBuilding
            // 
            this.ColBuilding.DataPropertyName = "Building";
            this.ColBuilding.HeaderText = "楼号";
            this.ColBuilding.Name = "ColBuilding";
            this.ColBuilding.ReadOnly = true;
            this.ColBuilding.Width = 54;
            // 
            // ColUnit
            // 
            this.ColUnit.DataPropertyName = "Unit";
            this.ColUnit.HeaderText = "单元";
            this.ColUnit.Name = "ColUnit";
            this.ColUnit.ReadOnly = true;
            this.ColUnit.Width = 54;
            // 
            // ColItemNum
            // 
            this.ColItemNum.DataPropertyName = "ItemNum";
            this.ColItemNum.HeaderText = "房号";
            this.ColItemNum.Name = "ColItemNum";
            this.ColItemNum.ReadOnly = true;
            this.ColItemNum.Width = 54;
            // 
            // ColSubscribeDate
            // 
            this.ColSubscribeDate.DataPropertyName = "SubscribeDate";
            this.ColSubscribeDate.HeaderText = "认购日期";
            this.ColSubscribeDate.Name = "ColSubscribeDate";
            this.ColSubscribeDate.ReadOnly = true;
            this.ColSubscribeDate.Width = 78;
            // 
            // ColContractDate
            // 
            this.ColContractDate.DataPropertyName = "ContractDate";
            this.ColContractDate.HeaderText = "签约日期";
            this.ColContractDate.Name = "ColContractDate";
            this.ColContractDate.ReadOnly = true;
            this.ColContractDate.Width = 78;
            // 
            // ColReceiptDate
            // 
            this.ColReceiptDate.DataPropertyName = "ReceiptDate";
            this.ColReceiptDate.HeaderText = "收款日期";
            this.ColReceiptDate.Name = "ColReceiptDate";
            this.ColReceiptDate.ReadOnly = true;
            this.ColReceiptDate.Width = 78;
            // 
            // ColArea
            // 
            this.ColArea.DataPropertyName = "Area";
            this.ColArea.HeaderText = "签约面积";
            this.ColArea.Name = "ColArea";
            this.ColArea.ReadOnly = true;
            this.ColArea.Width = 78;
            // 
            // ColPrice
            // 
            this.ColPrice.DataPropertyName = "Price";
            this.ColPrice.HeaderText = "签约单价";
            this.ColPrice.Name = "ColPrice";
            this.ColPrice.ReadOnly = true;
            this.ColPrice.Width = 78;
            // 
            // ColAmount
            // 
            this.ColAmount.DataPropertyName = "Amount";
            this.ColAmount.HeaderText = "签约总价";
            this.ColAmount.Name = "ColAmount";
            this.ColAmount.ReadOnly = true;
            this.ColAmount.Width = 78;
            // 
            // ColTotalAmount
            // 
            this.ColTotalAmount.DataPropertyName = "TotalAmount";
            this.ColTotalAmount.HeaderText = "签约总款";
            this.ColTotalAmount.Name = "ColTotalAmount";
            this.ColTotalAmount.ReadOnly = true;
            this.ColTotalAmount.Width = 78;
            // 
            // ColPayPercent
            // 
            this.ColPayPercent.DataPropertyName = "PayPercent";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "F2";
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ColPayPercent.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColPayPercent.HeaderText = "付款百分比(%)";
            this.ColPayPercent.Name = "ColPayPercent";
            this.ColPayPercent.ReadOnly = true;
            this.ColPayPercent.Width = 108;
            // 
            // ColAchievement
            // 
            this.ColAchievement.DataPropertyName = "Achievement";
            this.ColAchievement.HeaderText = "业绩回款";
            this.ColAchievement.Name = "ColAchievement";
            this.ColAchievement.ReadOnly = true;
            this.ColAchievement.Width = 78;
            // 
            // ColSalesName
            // 
            this.ColSalesName.DataPropertyName = "SalesName";
            this.ColSalesName.HeaderText = "置业顾问";
            this.ColSalesName.Name = "ColSalesName";
            this.ColSalesName.ReadOnly = true;
            this.ColSalesName.Width = 78;
            // 
            // AchSalesDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 432);
            this.Controls.Add(this.dataGridView_Achievement);
            this.Controls.Add(this.panel1);
            this.Name = "AchSalesDetail";
            this.Text = "置业顾问个人业绩统计";
            this.Load += new System.EventHandler(this.AchSalesOwn_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Achievement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_End;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Begin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Export;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.DataGridView dataGridView_Achievement;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColContractID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSalesID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBuilding;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSubscribeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColContractDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColReceiptDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPayPercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAchievement;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSalesName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_RecType;
    }
}