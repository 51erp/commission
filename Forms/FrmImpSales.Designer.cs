namespace Commission.Forms
{
    partial class FrmImpSales
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
            this.label_State = new System.Windows.Forms.Label();
            this.button_OpneExcel = new System.Windows.Forms.Button();
            this.button_ExportDict = new System.Windows.Forms.Button();
            this.button_Import = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.dataGridView_data = new System.Windows.Forms.DataGridView();
            this.openFileDialog_Excel = new System.Windows.Forms.OpenFileDialog();
            this.Col0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_data)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(469, 39);
            this.panel1.TabIndex = 2;
            // 
            // label_State
            // 
            this.label_State.AutoSize = true;
            this.label_State.Location = new System.Drawing.Point(183, 13);
            this.label_State.Name = "label_State";
            this.label_State.Size = new System.Drawing.Size(65, 12);
            this.label_State.TabIndex = 38;
            this.label_State.Text = "状态：准备";
            // 
            // button_OpneExcel
            // 
            this.button_OpneExcel.Image = global::Commission.Properties.Resources.excel_16;
            this.button_OpneExcel.Location = new System.Drawing.Point(12, 7);
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
            this.button_ExportDict.Location = new System.Drawing.Point(267, 7);
            this.button_ExportDict.Name = "button_ExportDict";
            this.button_ExportDict.Size = new System.Drawing.Size(90, 25);
            this.button_ExportDict.TabIndex = 41;
            this.button_ExportDict.Text = " 导出字典";
            this.button_ExportDict.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_ExportDict.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_ExportDict.UseVisualStyleBackColor = true;
            this.button_ExportDict.Visible = false;
            // 
            // button_Import
            // 
            this.button_Import.Image = global::Commission.Properties.Resources.import_16;
            this.button_Import.Location = new System.Drawing.Point(93, 7);
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
            this.button_Exit.Location = new System.Drawing.Point(363, 7);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(75, 25);
            this.button_Exit.TabIndex = 41;
            this.button_Exit.Text = " 关闭";
            this.button_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // dataGridView_data
            // 
            this.dataGridView_data.AllowUserToAddRows = false;
            this.dataGridView_data.AllowUserToDeleteRows = false;
            this.dataGridView_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col0,
            this.Col1,
            this.Col2,
            this.Col3});
            this.dataGridView_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_data.Location = new System.Drawing.Point(0, 39);
            this.dataGridView_data.Name = "dataGridView_data";
            this.dataGridView_data.ReadOnly = true;
            this.dataGridView_data.RowHeadersWidth = 21;
            this.dataGridView_data.RowTemplate.Height = 23;
            this.dataGridView_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_data.Size = new System.Drawing.Size(469, 430);
            this.dataGridView_data.TabIndex = 3;
            // 
            // openFileDialog_Excel
            // 
            this.openFileDialog_Excel.Filter = "Excel文件|*.xls;*.xlsx";
            // 
            // Col0
            // 
            this.Col0.DataPropertyName = "Col0";
            this.Col0.HeaderText = "姓名";
            this.Col0.Name = "Col0";
            this.Col0.ReadOnly = true;
            this.Col0.Width = 120;
            // 
            // Col1
            // 
            this.Col1.DataPropertyName = "Col1";
            this.Col1.HeaderText = "电话";
            this.Col1.Name = "Col1";
            this.Col1.ReadOnly = true;
            // 
            // Col2
            // 
            this.Col2.DataPropertyName = "Col2";
            this.Col2.HeaderText = "入职时间";
            this.Col2.Name = "Col2";
            this.Col2.ReadOnly = true;
            // 
            // Col3
            // 
            this.Col3.DataPropertyName = "Col3";
            this.Col3.HeaderText = "离职时间";
            this.Col3.Name = "Col3";
            this.Col3.ReadOnly = true;
            // 
            // FrmImpSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 469);
            this.Controls.Add(this.dataGridView_data);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmImpSales";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "置业顾问导入";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_OpneExcel;
        private System.Windows.Forms.Button button_ExportDict;
        private System.Windows.Forms.Button button_Import;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Label label_State;
        private System.Windows.Forms.DataGridView dataGridView_data;
        private System.Windows.Forms.OpenFileDialog openFileDialog_Excel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col3;
    }
}