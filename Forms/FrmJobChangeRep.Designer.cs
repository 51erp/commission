namespace Commission.Forms
{
    partial class FrmJobChangeRep
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_Exit = new System.Windows.Forms.Button();
            this.textBox_SalesName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button_Search = new System.Windows.Forms.Button();
            this.dataGridView_Employee = new System.Windows.Forms.DataGridView();
            this.ColSalesID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDeptID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSalesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColJobType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBeginDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Employee)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_Exit);
            this.groupBox1.Controls.Add(this.textBox_SalesName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.button_Search);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(898, 50);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // button_Exit
            // 
            this.button_Exit.Image = global::Commission.Properties.Resources.exit;
            this.button_Exit.Location = new System.Drawing.Point(259, 16);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(75, 23);
            this.button_Exit.TabIndex = 17;
            this.button_Exit.Text = " 关闭";
            this.button_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // textBox_SalesName
            // 
            this.textBox_SalesName.Location = new System.Drawing.Point(65, 17);
            this.textBox_SalesName.Name = "textBox_SalesName";
            this.textBox_SalesName.Size = new System.Drawing.Size(100, 21);
            this.textBox_SalesName.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "姓名";
            // 
            // button_Search
            // 
            this.button_Search.Image = global::Commission.Properties.Resources.Find_16;
            this.button_Search.Location = new System.Drawing.Point(171, 16);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(75, 23);
            this.button_Search.TabIndex = 1;
            this.button_Search.Text = " 查询";
            this.button_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // dataGridView_Employee
            // 
            this.dataGridView_Employee.AllowUserToAddRows = false;
            this.dataGridView_Employee.AllowUserToDeleteRows = false;
            this.dataGridView_Employee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Employee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSalesID,
            this.ColDeptID,
            this.ColSalesName,
            this.ColDeptName,
            this.ColJobType,
            this.ColBeginDate,
            this.ColEndDate});
            this.dataGridView_Employee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Employee.Location = new System.Drawing.Point(0, 50);
            this.dataGridView_Employee.Name = "dataGridView_Employee";
            this.dataGridView_Employee.ReadOnly = true;
            this.dataGridView_Employee.RowHeadersWidth = 20;
            this.dataGridView_Employee.RowTemplate.Height = 23;
            this.dataGridView_Employee.Size = new System.Drawing.Size(898, 442);
            this.dataGridView_Employee.TabIndex = 4;
            // 
            // ColSalesID
            // 
            this.ColSalesID.DataPropertyName = "SalesID";
            this.ColSalesID.HeaderText = "SalesID";
            this.ColSalesID.Name = "ColSalesID";
            this.ColSalesID.ReadOnly = true;
            this.ColSalesID.Visible = false;
            // 
            // ColDeptID
            // 
            this.ColDeptID.DataPropertyName = "DeptID";
            this.ColDeptID.HeaderText = "DeptID";
            this.ColDeptID.Name = "ColDeptID";
            this.ColDeptID.ReadOnly = true;
            this.ColDeptID.Visible = false;
            // 
            // ColSalesName
            // 
            this.ColSalesName.DataPropertyName = "SalesName";
            this.ColSalesName.HeaderText = "姓名";
            this.ColSalesName.Name = "ColSalesName";
            this.ColSalesName.ReadOnly = true;
            // 
            // ColDeptName
            // 
            this.ColDeptName.DataPropertyName = "DeptName";
            this.ColDeptName.HeaderText = "部门";
            this.ColDeptName.Name = "ColDeptName";
            this.ColDeptName.ReadOnly = true;
            // 
            // ColJobType
            // 
            this.ColJobType.DataPropertyName = "JobType";
            this.ColJobType.HeaderText = "岗位类型";
            this.ColJobType.Name = "ColJobType";
            this.ColJobType.ReadOnly = true;
            // 
            // ColBeginDate
            // 
            this.ColBeginDate.DataPropertyName = "BeginDate";
            this.ColBeginDate.HeaderText = "调入日期";
            this.ColBeginDate.Name = "ColBeginDate";
            this.ColBeginDate.ReadOnly = true;
            // 
            // ColEndDate
            // 
            this.ColEndDate.DataPropertyName = "EndDate";
            this.ColEndDate.HeaderText = "调离日期";
            this.ColEndDate.Name = "ColEndDate";
            this.ColEndDate.ReadOnly = true;
            // 
            // FrmJobChangeRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 492);
            this.Controls.Add(this.dataGridView_Employee);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmJobChangeRep";
            this.Text = "员工岗位变动记录";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Employee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.TextBox textBox_SalesName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.DataGridView dataGridView_Employee;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSalesID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDeptID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSalesName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDeptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColJobType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBeginDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEndDate;
    }
}