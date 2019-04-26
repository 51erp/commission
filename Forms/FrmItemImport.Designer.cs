namespace Commission.Forms
{
    partial class FrmItemImport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_OpneExcel = new System.Windows.Forms.Button();
            this.button_ExportDict = new System.Windows.Forms.Button();
            this.button_Import = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.label_State = new System.Windows.Forms.Label();
            this.dataGridView_SaleItem = new System.Windows.Forms.DataGridView();
            this.ColBuilding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog_Excel = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Count = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SaleItem)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_OpneExcel);
            this.panel1.Controls.Add(this.button_ExportDict);
            this.panel1.Controls.Add(this.button_Import);
            this.panel1.Controls.Add(this.button_Exit);
            this.panel1.Controls.Add(this.label_State);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 39);
            this.panel1.TabIndex = 0;
            // 
            // button_OpneExcel
            // 
            this.button_OpneExcel.Image = global::Commission.Properties.Resources.excel_16;
            this.button_OpneExcel.Location = new System.Drawing.Point(151, 7);
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
            this.button_ExportDict.Location = new System.Drawing.Point(12, 7);
            this.button_ExportDict.Name = "button_ExportDict";
            this.button_ExportDict.Size = new System.Drawing.Size(133, 25);
            this.button_ExportDict.TabIndex = 41;
            this.button_ExportDict.Text = " 导出房源类型字典";
            this.button_ExportDict.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_ExportDict.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_ExportDict.UseVisualStyleBackColor = true;
            this.button_ExportDict.Click += new System.EventHandler(this.button_ExportDict_Click);
            // 
            // button_Import
            // 
            this.button_Import.Image = global::Commission.Properties.Resources.import_16;
            this.button_Import.Location = new System.Drawing.Point(232, 7);
            this.button_Import.Name = "button_Import";
            this.button_Import.Size = new System.Drawing.Size(75, 25);
            this.button_Import.TabIndex = 41;
            this.button_Import.Text = " 导入";
            this.button_Import.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Import.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Import.UseVisualStyleBackColor = true;
            this.button_Import.Click += new System.EventHandler(this.button_Import_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.Image = global::Commission.Properties.Resources.exit;
            this.button_Exit.Location = new System.Drawing.Point(535, 7);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(75, 25);
            this.button_Exit.TabIndex = 41;
            this.button_Exit.Text = " 关闭";
            this.button_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // label_State
            // 
            this.label_State.AutoSize = true;
            this.label_State.Location = new System.Drawing.Point(322, 13);
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
            this.ColAmount,
            this.ColType});
            this.dataGridView_SaleItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_SaleItem.Location = new System.Drawing.Point(0, 39);
            this.dataGridView_SaleItem.Name = "dataGridView_SaleItem";
            this.dataGridView_SaleItem.ReadOnly = true;
            this.dataGridView_SaleItem.RowHeadersWidth = 21;
            this.dataGridView_SaleItem.RowTemplate.Height = 23;
            this.dataGridView_SaleItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_SaleItem.Size = new System.Drawing.Size(647, 542);
            this.dataGridView_SaleItem.TabIndex = 1;
            // 
            // ColBuilding
            // 
            this.ColBuilding.DataPropertyName = "Building";
            this.ColBuilding.HeaderText = "楼号";
            this.ColBuilding.Name = "ColBuilding";
            this.ColBuilding.ReadOnly = true;
            this.ColBuilding.Width = 80;
            // 
            // ColUnit
            // 
            this.ColUnit.DataPropertyName = "Unit";
            this.ColUnit.HeaderText = "单元";
            this.ColUnit.Name = "ColUnit";
            this.ColUnit.ReadOnly = true;
            this.ColUnit.Width = 80;
            // 
            // ColItemNum
            // 
            this.ColItemNum.DataPropertyName = "ItemNum";
            this.ColItemNum.HeaderText = "房号";
            this.ColItemNum.Name = "ColItemNum";
            this.ColItemNum.ReadOnly = true;
            this.ColItemNum.Width = 80;
            // 
            // ColArea
            // 
            this.ColArea.DataPropertyName = "Area";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "F2";
            dataGridViewCellStyle4.NullValue = "0";
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ColArea.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColArea.HeaderText = "面积";
            this.ColArea.Name = "ColArea";
            this.ColArea.ReadOnly = true;
            this.ColArea.Width = 80;
            // 
            // ColPrice
            // 
            this.ColPrice.DataPropertyName = "Price";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "F4";
            dataGridViewCellStyle5.NullValue = "0";
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ColPrice.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColPrice.HeaderText = "单价";
            this.ColPrice.Name = "ColPrice";
            this.ColPrice.ReadOnly = true;
            this.ColPrice.Width = 80;
            // 
            // ColAmount
            // 
            this.ColAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "F0";
            dataGridViewCellStyle6.NullValue = "0";
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ColAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColAmount.HeaderText = "总价";
            this.ColAmount.Name = "ColAmount";
            this.ColAmount.ReadOnly = true;
            // 
            // ColType
            // 
            this.ColType.DataPropertyName = "ItemType";
            this.ColType.HeaderText = "类型";
            this.ColType.Name = "ColType";
            this.ColType.ReadOnly = true;
            // 
            // openFileDialog_Excel
            // 
            this.openFileDialog_Excel.Filter = "Excel文件|*.xls;*.xlsx";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel_Count});
            this.statusStrip1.Location = new System.Drawing.Point(0, 559);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(647, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(75, 17);
            this.toolStripStatusLabel1.Text = "   套数合计: ";
            // 
            // toolStripStatusLabel_Count
            // 
            this.toolStripStatusLabel_Count.Name = "toolStripStatusLabel_Count";
            this.toolStripStatusLabel_Count.Size = new System.Drawing.Size(15, 17);
            this.toolStripStatusLabel_Count.Text = "0";
            // 
            // FrmItemImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 581);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridView_SaleItem);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmItemImport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "楼盘导入";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SaleItem)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView_SaleItem;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_OpneExcel;
        private System.Windows.Forms.Button button_Import;
        private System.Windows.Forms.OpenFileDialog openFileDialog_Excel;
        private System.Windows.Forms.Label label_State;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBuilding;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColType;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Count;
        private System.Windows.Forms.Button button_ExportDict;
    }
}