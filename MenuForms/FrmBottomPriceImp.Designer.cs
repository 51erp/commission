namespace Commission.MenuForms
{
    partial class FrmBottomPriceImp
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Close = new System.Windows.Forms.Button();
            this.button_OpneExcel = new System.Windows.Forms.Button();
            this.button_ExportDict = new System.Windows.Forms.Button();
            this.button_Import = new System.Windows.Forms.Button();
            this.label_State = new System.Windows.Forms.Label();
            this.dataGridView_SaleItem = new System.Windows.Forms.DataGridView();
            this.ColBuilding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog_Excel = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView_item = new System.Windows.Forms.DataGridView();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBottomPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBottomPriceRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBottomPriceLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SaleItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_item)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_Close);
            this.panel1.Controls.Add(this.button_OpneExcel);
            this.panel1.Controls.Add(this.button_ExportDict);
            this.panel1.Controls.Add(this.button_Import);
            this.panel1.Controls.Add(this.label_State);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 39);
            this.panel1.TabIndex = 2;
            // 
            // button_Close
            // 
            this.button_Close.Image = global::Commission.Properties.Resources.exit;
            this.button_Close.Location = new System.Drawing.Point(451, 8);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 25);
            this.button_Close.TabIndex = 42;
            this.button_Close.Text = " 关闭";
            this.button_Close.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // button_OpneExcel
            // 
            this.button_OpneExcel.Image = global::Commission.Properties.Resources.excel_16;
            this.button_OpneExcel.Location = new System.Drawing.Point(126, 8);
            this.button_OpneExcel.Name = "button_OpneExcel";
            this.button_OpneExcel.Size = new System.Drawing.Size(75, 25);
            this.button_OpneExcel.TabIndex = 41;
            this.button_OpneExcel.Text = " 打开";
            this.button_OpneExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_OpneExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_OpneExcel.UseVisualStyleBackColor = true;
            this.button_OpneExcel.Click += new System.EventHandler(this.button_OpneExcel_Click);
            // 
            // button_ExportDict
            // 
            this.button_ExportDict.Image = global::Commission.Properties.Resources.import_16;
            this.button_ExportDict.Location = new System.Drawing.Point(12, 8);
            this.button_ExportDict.Name = "button_ExportDict";
            this.button_ExportDict.Size = new System.Drawing.Size(108, 25);
            this.button_ExportDict.TabIndex = 41;
            this.button_ExportDict.Text = " 导出房源模板";
            this.button_ExportDict.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_ExportDict.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_ExportDict.UseVisualStyleBackColor = true;
            this.button_ExportDict.Click += new System.EventHandler(this.button_ExportDict_Click);
            // 
            // button_Import
            // 
            this.button_Import.Image = global::Commission.Properties.Resources.import_16;
            this.button_Import.Location = new System.Drawing.Point(207, 8);
            this.button_Import.Name = "button_Import";
            this.button_Import.Size = new System.Drawing.Size(75, 25);
            this.button_Import.TabIndex = 41;
            this.button_Import.Text = " 导入";
            this.button_Import.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Import.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Import.UseVisualStyleBackColor = true;
            this.button_Import.Click += new System.EventHandler(this.button_Import_Click);
            // 
            // label_State
            // 
            this.label_State.AutoSize = true;
            this.label_State.Location = new System.Drawing.Point(302, 14);
            this.label_State.Name = "label_State";
            this.label_State.Size = new System.Drawing.Size(65, 12);
            this.label_State.TabIndex = 38;
            this.label_State.Text = "状态：准备";
            // 
            // dataGridView_SaleItem
            // 
            this.dataGridView_SaleItem.AllowUserToAddRows = false;
            this.dataGridView_SaleItem.AllowUserToDeleteRows = false;
            this.dataGridView_SaleItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SaleItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColBuilding,
            this.ColUnit,
            this.ColItemNum,
            this.ColArea,
            this.ColPrice,
            this.ColType});
            this.dataGridView_SaleItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_SaleItem.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_SaleItem.Name = "dataGridView_SaleItem";
            this.dataGridView_SaleItem.ReadOnly = true;
            this.dataGridView_SaleItem.RowHeadersWidth = 21;
            this.dataGridView_SaleItem.RowTemplate.Height = 23;
            this.dataGridView_SaleItem.Size = new System.Drawing.Size(724, 534);
            this.dataGridView_SaleItem.TabIndex = 3;
            // 
            // ColBuilding
            // 
            this.ColBuilding.DataPropertyName = "Col0";
            this.ColBuilding.HeaderText = "楼号";
            this.ColBuilding.Name = "ColBuilding";
            this.ColBuilding.ReadOnly = true;
            // 
            // ColUnit
            // 
            this.ColUnit.DataPropertyName = "Col1";
            this.ColUnit.HeaderText = "单元";
            this.ColUnit.Name = "ColUnit";
            this.ColUnit.ReadOnly = true;
            // 
            // ColItemNum
            // 
            this.ColItemNum.DataPropertyName = "Col2";
            this.ColItemNum.HeaderText = "房号";
            this.ColItemNum.Name = "ColItemNum";
            this.ColItemNum.ReadOnly = true;
            // 
            // ColArea
            // 
            this.ColArea.DataPropertyName = "Col3";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.NullValue = "0";
            this.ColArea.DefaultCellStyle = dataGridViewCellStyle11;
            this.ColArea.HeaderText = "面积";
            this.ColArea.Name = "ColArea";
            this.ColArea.ReadOnly = true;
            // 
            // ColPrice
            // 
            this.ColPrice.DataPropertyName = "Col4";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.NullValue = "0";
            this.ColPrice.DefaultCellStyle = dataGridViewCellStyle12;
            this.ColPrice.HeaderText = "单价";
            this.ColPrice.Name = "ColPrice";
            this.ColPrice.ReadOnly = true;
            // 
            // ColType
            // 
            this.ColType.DataPropertyName = "Col5";
            this.ColType.HeaderText = "类型";
            this.ColType.Name = "ColType";
            this.ColType.ReadOnly = true;
            // 
            // openFileDialog_Excel
            // 
            this.openFileDialog_Excel.Filter = "Excel文件|*.xls;*.xlsx";
            // 
            // dataGridView_item
            // 
            this.dataGridView_item.AllowUserToAddRows = false;
            this.dataGridView_item.AllowUserToDeleteRows = false;
            this.dataGridView_item.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_item.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.ColBottomPrice,
            this.ColBottomPriceRate,
            this.ColBottomPriceLimit});
            this.dataGridView_item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_item.Location = new System.Drawing.Point(0, 39);
            this.dataGridView_item.Name = "dataGridView_item";
            this.dataGridView_item.ReadOnly = true;
            this.dataGridView_item.RowHeadersWidth = 21;
            this.dataGridView_item.RowTemplate.Height = 23;
            this.dataGridView_item.Size = new System.Drawing.Size(724, 495);
            this.dataGridView_item.TabIndex = 4;
            // 
            // ColID
            // 
            this.ColID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColID.DataPropertyName = "Col0";
            this.ColID.HeaderText = "ID";
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            this.ColID.Width = 75;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Col1";
            this.dataGridViewTextBoxColumn1.HeaderText = "楼号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Col2";
            this.dataGridViewTextBoxColumn2.HeaderText = "单元";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Col3";
            this.dataGridViewTextBoxColumn3.HeaderText = "房号";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // ColBottomPrice
            // 
            this.ColBottomPrice.DataPropertyName = "Col4";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColBottomPrice.DefaultCellStyle = dataGridViewCellStyle13;
            this.ColBottomPrice.HeaderText = "底价";
            this.ColBottomPrice.Name = "ColBottomPrice";
            this.ColBottomPrice.ReadOnly = true;
            // 
            // ColBottomPriceRate
            // 
            this.ColBottomPriceRate.DataPropertyName = "Col5";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColBottomPriceRate.DefaultCellStyle = dataGridViewCellStyle14;
            this.ColBottomPriceRate.HeaderText = "溢价分成(%)";
            this.ColBottomPriceRate.Name = "ColBottomPriceRate";
            this.ColBottomPriceRate.ReadOnly = true;
            // 
            // ColBottomPriceLimit
            // 
            this.ColBottomPriceLimit.DataPropertyName = "Col6";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColBottomPriceLimit.DefaultCellStyle = dataGridViewCellStyle15;
            this.ColBottomPriceLimit.HeaderText = "溢价限价";
            this.ColBottomPriceLimit.Name = "ColBottomPriceLimit";
            this.ColBottomPriceLimit.ReadOnly = true;
            // 
            // FrmBottomPriceImp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 534);
            this.Controls.Add(this.dataGridView_item);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView_SaleItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmBottomPriceImp";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "底价导入";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SaleItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_item)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_OpneExcel;
        private System.Windows.Forms.Button button_Import;
        private System.Windows.Forms.Label label_State;
        private System.Windows.Forms.DataGridView dataGridView_SaleItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBuilding;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColType;
        private System.Windows.Forms.OpenFileDialog openFileDialog_Excel;
        private System.Windows.Forms.DataGridView dataGridView_item;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Button button_ExportDict;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBottomPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBottomPriceRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBottomPriceLimit;
    }
}