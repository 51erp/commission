namespace Commission.MenuForms
{
    partial class FrmSubReceipt
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker_Period = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_Export = new System.Windows.Forms.Button();
            this.button_Search = new System.Windows.Forms.Button();
            this.dataGridView_Report = new System.Windows.Forms.DataGridView();
            this.ColSubscribeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCustomerPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBuilding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSubscribeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSalesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLastRecDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPreRecTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPeriodRecAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPeriodReturn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExtField0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExtField1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExtField2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExtField3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExtField4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExtField5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExtField6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExtField7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExtField8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExtField9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Report)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.panel1.Size = new System.Drawing.Size(905, 67);
            this.panel1.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker_Period);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.button_Exit);
            this.groupBox1.Controls.Add(this.button_Export);
            this.groupBox1.Controls.Add(this.button_Search);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(899, 59);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // dateTimePicker_Period
            // 
            this.dateTimePicker_Period.CustomFormat = "yyyy-MM";
            this.dateTimePicker_Period.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_Period.Location = new System.Drawing.Point(90, 22);
            this.dateTimePicker_Period.Name = "dateTimePicker_Period";
            this.dateTimePicker_Period.ShowUpDown = true;
            this.dateTimePicker_Period.Size = new System.Drawing.Size(67, 21);
            this.dateTimePicker_Period.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "收款期间";
            // 
            // button_Exit
            // 
            this.button_Exit.Image = global::Commission.Properties.Resources.exit;
            this.button_Exit.Location = new System.Drawing.Point(389, 21);
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
            this.button_Export.Location = new System.Drawing.Point(283, 21);
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
            this.button_Search.Location = new System.Drawing.Point(202, 21);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(75, 23);
            this.button_Search.TabIndex = 1;
            this.button_Search.Text = " 查询";
            this.button_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // dataGridView_Report
            // 
            this.dataGridView_Report.AllowUserToAddRows = false;
            this.dataGridView_Report.AllowUserToDeleteRows = false;
            this.dataGridView_Report.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_Report.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_Report.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSubscribeID,
            this.ColItemID,
            this.ColCustomerName,
            this.ColCustomerPhone,
            this.ColBuilding,
            this.ColUnit,
            this.ColItemNum,
            this.ColArea,
            this.ColPrice,
            this.ColAmount,
            this.ColTotalAmount,
            this.ColSubscribeDate,
            this.ColSalesName,
            this.ColLastRecDate,
            this.ColPreRecTotal,
            this.ColPeriodRecAmount,
            this.ColPeriodReturn,
            this.ColExtField0,
            this.ColExtField1,
            this.ColExtField2,
            this.ColExtField3,
            this.ColExtField4,
            this.ColExtField5,
            this.ColExtField6,
            this.ColExtField7,
            this.ColExtField8,
            this.ColExtField9});
            this.dataGridView_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Report.Location = new System.Drawing.Point(0, 67);
            this.dataGridView_Report.Name = "dataGridView_Report";
            this.dataGridView_Report.ReadOnly = true;
            this.dataGridView_Report.RowHeadersWidth = 20;
            this.dataGridView_Report.RowTemplate.Height = 23;
            this.dataGridView_Report.Size = new System.Drawing.Size(905, 354);
            this.dataGridView_Report.TabIndex = 9;
            // 
            // ColSubscribeID
            // 
            this.ColSubscribeID.DataPropertyName = "SubscribeID";
            this.ColSubscribeID.HeaderText = "SubscribeID";
            this.ColSubscribeID.Name = "ColSubscribeID";
            this.ColSubscribeID.ReadOnly = true;
            this.ColSubscribeID.Visible = false;
            this.ColSubscribeID.Width = 96;
            // 
            // ColItemID
            // 
            this.ColItemID.DataPropertyName = "ItemID";
            this.ColItemID.HeaderText = "ItemID";
            this.ColItemID.Name = "ColItemID";
            this.ColItemID.ReadOnly = true;
            this.ColItemID.Visible = false;
            this.ColItemID.Width = 66;
            // 
            // ColCustomerName
            // 
            this.ColCustomerName.DataPropertyName = "CustomerName";
            this.ColCustomerName.HeaderText = "客户名称";
            this.ColCustomerName.Name = "ColCustomerName";
            this.ColCustomerName.ReadOnly = true;
            this.ColCustomerName.Width = 78;
            // 
            // ColCustomerPhone
            // 
            this.ColCustomerPhone.DataPropertyName = "CustomerPhone";
            this.ColCustomerPhone.HeaderText = "客户电话";
            this.ColCustomerPhone.Name = "ColCustomerPhone";
            this.ColCustomerPhone.ReadOnly = true;
            this.ColCustomerPhone.Width = 78;
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
            // ColArea
            // 
            this.ColArea.DataPropertyName = "Area";
            this.ColArea.HeaderText = "面积";
            this.ColArea.Name = "ColArea";
            this.ColArea.ReadOnly = true;
            this.ColArea.Width = 54;
            // 
            // ColPrice
            // 
            this.ColPrice.DataPropertyName = "Price";
            this.ColPrice.HeaderText = "单价";
            this.ColPrice.Name = "ColPrice";
            this.ColPrice.ReadOnly = true;
            this.ColPrice.Width = 54;
            // 
            // ColAmount
            // 
            this.ColAmount.DataPropertyName = "Amount";
            this.ColAmount.HeaderText = "认购总价";
            this.ColAmount.Name = "ColAmount";
            this.ColAmount.ReadOnly = true;
            this.ColAmount.Width = 78;
            // 
            // ColTotalAmount
            // 
            this.ColTotalAmount.DataPropertyName = "TotalAmount";
            this.ColTotalAmount.HeaderText = "认购总额";
            this.ColTotalAmount.Name = "ColTotalAmount";
            this.ColTotalAmount.ReadOnly = true;
            this.ColTotalAmount.Width = 78;
            // 
            // ColSubscribeDate
            // 
            this.ColSubscribeDate.DataPropertyName = "SubscribeDate";
            this.ColSubscribeDate.HeaderText = "认购时间";
            this.ColSubscribeDate.Name = "ColSubscribeDate";
            this.ColSubscribeDate.ReadOnly = true;
            this.ColSubscribeDate.Width = 78;
            // 
            // ColSalesName
            // 
            this.ColSalesName.DataPropertyName = "SalesName";
            this.ColSalesName.HeaderText = "置业顾问";
            this.ColSalesName.Name = "ColSalesName";
            this.ColSalesName.ReadOnly = true;
            this.ColSalesName.Width = 78;
            // 
            // ColLastRecDate
            // 
            this.ColLastRecDate.DataPropertyName = "LastRecDate";
            this.ColLastRecDate.HeaderText = "回款日期";
            this.ColLastRecDate.Name = "ColLastRecDate";
            this.ColLastRecDate.ReadOnly = true;
            this.ColLastRecDate.Width = 78;
            // 
            // ColPreRecTotal
            // 
            this.ColPreRecTotal.DataPropertyName = "PreRecTotal";
            this.ColPreRecTotal.HeaderText = "前期累计";
            this.ColPreRecTotal.Name = "ColPreRecTotal";
            this.ColPreRecTotal.ReadOnly = true;
            this.ColPreRecTotal.Width = 78;
            // 
            // ColPeriodRecAmount
            // 
            this.ColPeriodRecAmount.DataPropertyName = "PeriodRecAmount";
            this.ColPeriodRecAmount.HeaderText = "当期收款";
            this.ColPeriodRecAmount.Name = "ColPeriodRecAmount";
            this.ColPeriodRecAmount.ReadOnly = true;
            this.ColPeriodRecAmount.Width = 78;
            // 
            // ColPeriodReturn
            // 
            this.ColPeriodReturn.DataPropertyName = "PeriodReturn";
            this.ColPeriodReturn.HeaderText = "当期退房";
            this.ColPeriodReturn.Name = "ColPeriodReturn";
            this.ColPeriodReturn.ReadOnly = true;
            this.ColPeriodReturn.Width = 78;
            // 
            // ColExtField0
            // 
            this.ColExtField0.DataPropertyName = "ExtField0";
            this.ColExtField0.HeaderText = "备注0";
            this.ColExtField0.Name = "ColExtField0";
            this.ColExtField0.ReadOnly = true;
            this.ColExtField0.Width = 60;
            // 
            // ColExtField1
            // 
            this.ColExtField1.DataPropertyName = "ExtField1";
            this.ColExtField1.HeaderText = "备注1";
            this.ColExtField1.Name = "ColExtField1";
            this.ColExtField1.ReadOnly = true;
            this.ColExtField1.Width = 60;
            // 
            // ColExtField2
            // 
            this.ColExtField2.DataPropertyName = "ExtField2";
            this.ColExtField2.HeaderText = "备注2";
            this.ColExtField2.Name = "ColExtField2";
            this.ColExtField2.ReadOnly = true;
            this.ColExtField2.Width = 60;
            // 
            // ColExtField3
            // 
            this.ColExtField3.DataPropertyName = "ExtField3";
            this.ColExtField3.HeaderText = "备注3";
            this.ColExtField3.Name = "ColExtField3";
            this.ColExtField3.ReadOnly = true;
            this.ColExtField3.Width = 60;
            // 
            // ColExtField4
            // 
            this.ColExtField4.DataPropertyName = "ExtField4";
            this.ColExtField4.HeaderText = "备注4";
            this.ColExtField4.Name = "ColExtField4";
            this.ColExtField4.ReadOnly = true;
            this.ColExtField4.Width = 60;
            // 
            // ColExtField5
            // 
            this.ColExtField5.DataPropertyName = "ExtField5";
            this.ColExtField5.HeaderText = "备注5";
            this.ColExtField5.Name = "ColExtField5";
            this.ColExtField5.ReadOnly = true;
            this.ColExtField5.Width = 60;
            // 
            // ColExtField6
            // 
            this.ColExtField6.DataPropertyName = "ExtField6";
            this.ColExtField6.HeaderText = "备注6";
            this.ColExtField6.Name = "ColExtField6";
            this.ColExtField6.ReadOnly = true;
            this.ColExtField6.Width = 60;
            // 
            // ColExtField7
            // 
            this.ColExtField7.DataPropertyName = "ExtField7";
            this.ColExtField7.HeaderText = "备注7";
            this.ColExtField7.Name = "ColExtField7";
            this.ColExtField7.ReadOnly = true;
            this.ColExtField7.Width = 60;
            // 
            // ColExtField8
            // 
            this.ColExtField8.DataPropertyName = "ExtField8";
            this.ColExtField8.HeaderText = "备注8";
            this.ColExtField8.Name = "ColExtField8";
            this.ColExtField8.ReadOnly = true;
            this.ColExtField8.Width = 60;
            // 
            // ColExtField9
            // 
            this.ColExtField9.DataPropertyName = "ExtField9";
            this.ColExtField9.HeaderText = "备注9";
            this.ColExtField9.Name = "ColExtField9";
            this.ColExtField9.ReadOnly = true;
            this.ColExtField9.Width = 60;
            // 
            // FrmSubReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 421);
            this.Controls.Add(this.dataGridView_Report);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSubReceipt";
            this.Text = "认购回款";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Report)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Period;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Export;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.DataGridView dataGridView_Report;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSubscribeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCustomerPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBuilding;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSubscribeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSalesName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLastRecDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPreRecTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPeriodRecAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPeriodReturn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExtField0;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExtField1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExtField2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExtField3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExtField4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExtField5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExtField6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExtField7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExtField8;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExtField9;

    }
}