﻿namespace Commission.Report
{
    partial class FrmNameChange
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
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Begin = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_Export = new System.Windows.Forms.Button();
            this.button_Search = new System.Windows.Forms.Button();
            this.dataGridView_RepNameChange = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_OperType = new System.Windows.Forms.ComboBox();
            this.ColAgreementID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBuilding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOrigID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOrigName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOrigPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRelation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSalesID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSalesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNewID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNewName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSubscribeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExchangeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RepNameChange)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.panel1.Size = new System.Drawing.Size(979, 59);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_OperType);
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
            this.groupBox1.Size = new System.Drawing.Size(973, 51);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.Checked = false;
            this.dateTimePicker_End.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_End.Location = new System.Drawing.Point(206, 20);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.ShowCheckBox = true;
            this.dateTimePicker_End.Size = new System.Drawing.Size(100, 21);
            this.dateTimePicker_End.TabIndex = 27;
            // 
            // dateTimePicker_Begin
            // 
            this.dateTimePicker_Begin.Checked = false;
            this.dateTimePicker_Begin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Begin.Location = new System.Drawing.Point(68, 20);
            this.dateTimePicker_Begin.Name = "dateTimePicker_Begin";
            this.dateTimePicker_Begin.ShowCheckBox = true;
            this.dateTimePicker_Begin.Size = new System.Drawing.Size(120, 21);
            this.dateTimePicker_Begin.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "变更时间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(192, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "-";
            // 
            // button_Exit
            // 
            this.button_Exit.Image = global::Commission.Properties.Resources.exit;
            this.button_Exit.Location = new System.Drawing.Point(663, 19);
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
            this.button_Export.Location = new System.Drawing.Point(557, 19);
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
            this.button_Search.Location = new System.Drawing.Point(476, 19);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(75, 23);
            this.button_Search.TabIndex = 1;
            this.button_Search.Text = " 查询";
            this.button_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // dataGridView_RepNameChange
            // 
            this.dataGridView_RepNameChange.AllowUserToAddRows = false;
            this.dataGridView_RepNameChange.AllowUserToDeleteRows = false;
            this.dataGridView_RepNameChange.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_RepNameChange.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_RepNameChange.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColAgreementID,
            this.ColItemID,
            this.ColBuilding,
            this.ColUnit,
            this.ColItemNum,
            this.ColItemTypeName,
            this.ColOrigID,
            this.ColOrigName,
            this.ColOrigPhone,
            this.ColRelation,
            this.ColSalesID,
            this.ColSalesName,
            this.ColNewID,
            this.ColNewName,
            this.ColMemo,
            this.ColSubscribeDate,
            this.ColExchangeDate});
            this.dataGridView_RepNameChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_RepNameChange.Location = new System.Drawing.Point(0, 59);
            this.dataGridView_RepNameChange.Name = "dataGridView_RepNameChange";
            this.dataGridView_RepNameChange.ReadOnly = true;
            this.dataGridView_RepNameChange.RowHeadersWidth = 21;
            this.dataGridView_RepNameChange.RowTemplate.Height = 23;
            this.dataGridView_RepNameChange.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_RepNameChange.Size = new System.Drawing.Size(979, 438);
            this.dataGridView_RepNameChange.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(312, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "业务类型";
            // 
            // comboBox_OperType
            // 
            this.comboBox_OperType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_OperType.FormattingEnabled = true;
            this.comboBox_OperType.Items.AddRange(new object[] {
            "认购",
            "签约"});
            this.comboBox_OperType.Location = new System.Drawing.Point(371, 20);
            this.comboBox_OperType.Name = "comboBox_OperType";
            this.comboBox_OperType.Size = new System.Drawing.Size(87, 20);
            this.comboBox_OperType.TabIndex = 28;
            // 
            // ColAgreementID
            // 
            this.ColAgreementID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColAgreementID.DataPropertyName = "AgreementID";
            this.ColAgreementID.HeaderText = "AgreementID";
            this.ColAgreementID.Name = "ColAgreementID";
            this.ColAgreementID.ReadOnly = true;
            this.ColAgreementID.Visible = false;
            this.ColAgreementID.Width = 60;
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
            // ColItemTypeName
            // 
            this.ColItemTypeName.DataPropertyName = "ItemTypeName";
            this.ColItemTypeName.HeaderText = "房产类型";
            this.ColItemTypeName.Name = "ColItemTypeName";
            this.ColItemTypeName.ReadOnly = true;
            this.ColItemTypeName.Width = 78;
            // 
            // ColOrigID
            // 
            this.ColOrigID.DataPropertyName = "OrigID";
            this.ColOrigID.HeaderText = "OrigID";
            this.ColOrigID.Name = "ColOrigID";
            this.ColOrigID.ReadOnly = true;
            this.ColOrigID.Visible = false;
            this.ColOrigID.Width = 66;
            // 
            // ColOrigName
            // 
            this.ColOrigName.DataPropertyName = "OrigName";
            this.ColOrigName.HeaderText = "原客户名称";
            this.ColOrigName.Name = "ColOrigName";
            this.ColOrigName.ReadOnly = true;
            this.ColOrigName.Width = 90;
            // 
            // ColOrigPhone
            // 
            this.ColOrigPhone.DataPropertyName = "OrigPhone";
            this.ColOrigPhone.HeaderText = "原电话";
            this.ColOrigPhone.Name = "ColOrigPhone";
            this.ColOrigPhone.ReadOnly = true;
            this.ColOrigPhone.Width = 66;
            // 
            // ColRelation
            // 
            this.ColRelation.DataPropertyName = "Relation";
            this.ColRelation.HeaderText = "变更关系";
            this.ColRelation.Name = "ColRelation";
            this.ColRelation.ReadOnly = true;
            this.ColRelation.Width = 78;
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
            // ColSalesName
            // 
            this.ColSalesName.DataPropertyName = "SalesName";
            this.ColSalesName.HeaderText = "置业顾问";
            this.ColSalesName.Name = "ColSalesName";
            this.ColSalesName.ReadOnly = true;
            this.ColSalesName.Width = 78;
            // 
            // ColNewID
            // 
            this.ColNewID.DataPropertyName = "NewID";
            this.ColNewID.HeaderText = "NewID";
            this.ColNewID.Name = "ColNewID";
            this.ColNewID.ReadOnly = true;
            this.ColNewID.Visible = false;
            this.ColNewID.Width = 60;
            // 
            // ColNewName
            // 
            this.ColNewName.DataPropertyName = "NewName";
            this.ColNewName.HeaderText = "变更客户名称";
            this.ColNewName.Name = "ColNewName";
            this.ColNewName.ReadOnly = true;
            this.ColNewName.Width = 102;
            // 
            // ColMemo
            // 
            this.ColMemo.DataPropertyName = "Memo";
            this.ColMemo.HeaderText = "备注";
            this.ColMemo.Name = "ColMemo";
            this.ColMemo.ReadOnly = true;
            this.ColMemo.Width = 54;
            // 
            // ColSubscribeDate
            // 
            this.ColSubscribeDate.DataPropertyName = "SubscribeDate";
            this.ColSubscribeDate.HeaderText = "认购时间";
            this.ColSubscribeDate.Name = "ColSubscribeDate";
            this.ColSubscribeDate.ReadOnly = true;
            this.ColSubscribeDate.Width = 78;
            // 
            // ColExchangeDate
            // 
            this.ColExchangeDate.DataPropertyName = "ExchangeDate";
            this.ColExchangeDate.HeaderText = "变更时间";
            this.ColExchangeDate.Name = "ColExchangeDate";
            this.ColExchangeDate.ReadOnly = true;
            this.ColExchangeDate.Width = 78;
            // 
            // FrmNameChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 497);
            this.Controls.Add(this.dataGridView_RepNameChange);
            this.Controls.Add(this.panel1);
            this.Name = "FrmNameChange";
            this.Text = "更名明细";
            this.Load += new System.EventHandler(this.FrmNameChange_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RepNameChange)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_End;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Begin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Export;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView_RepNameChange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_OperType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAgreementID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBuilding;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOrigID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOrigName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOrigPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRelation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSalesID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSalesName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNewID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNewName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSubscribeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExchangeDate;

    }
}