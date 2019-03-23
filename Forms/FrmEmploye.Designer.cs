namespace Commission.Forms
{
    partial class FrmEmploye
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmploye));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView_Dept = new System.Windows.Forms.TreeView();
            this.dataGridView_Employe = new System.Windows.Forms.DataGridView();
            this.toolStripButton_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Del = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Edit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_ChangeJob = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_JobIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_JobOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Dimission = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSalesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColInDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOutDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColJobType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Employe)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 31);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView_Dept);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView_Employe);
            this.splitContainer1.Size = new System.Drawing.Size(909, 459);
            this.splitContainer1.SplitterDistance = 188;
            this.splitContainer1.TabIndex = 3;
            // 
            // treeView_Dept
            // 
            this.treeView_Dept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_Dept.Location = new System.Drawing.Point(0, 0);
            this.treeView_Dept.Name = "treeView_Dept";
            this.treeView_Dept.Size = new System.Drawing.Size(188, 459);
            this.treeView_Dept.TabIndex = 0;
            this.treeView_Dept.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Dept_AfterSelect);
            // 
            // dataGridView_Employe
            // 
            this.dataGridView_Employe.AllowUserToAddRows = false;
            this.dataGridView_Employe.AllowUserToDeleteRows = false;
            this.dataGridView_Employe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Employe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColSalesName,
            this.ColPhone,
            this.ColInDate,
            this.ColOutDate,
            this.ColPosition,
            this.ColJobType,
            this.ColMemo});
            this.dataGridView_Employe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Employe.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Employe.MultiSelect = false;
            this.dataGridView_Employe.Name = "dataGridView_Employe";
            this.dataGridView_Employe.ReadOnly = true;
            this.dataGridView_Employe.RowHeadersWidth = 21;
            this.dataGridView_Employe.RowTemplate.Height = 23;
            this.dataGridView_Employe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Employe.Size = new System.Drawing.Size(717, 459);
            this.dataGridView_Employe.TabIndex = 3;
            // 
            // toolStripButton_Add
            // 
            this.toolStripButton_Add.Image = global::Commission.Properties.Resources.file_new;
            this.toolStripButton_Add.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Add.Name = "toolStripButton_Add";
            this.toolStripButton_Add.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_Add.Text = "新增";
            this.toolStripButton_Add.Click += new System.EventHandler(this.toolStripButton_Add_Click);
            // 
            // toolStripButton_Del
            // 
            this.toolStripButton_Del.Image = global::Commission.Properties.Resources.file_del;
            this.toolStripButton_Del.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Del.Name = "toolStripButton_Del";
            this.toolStripButton_Del.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_Del.Text = "删除";
            this.toolStripButton_Del.Click += new System.EventHandler(this.toolStripButton_Del_Click);
            // 
            // toolStripButton_Edit
            // 
            this.toolStripButton_Edit.Image = global::Commission.Properties.Resources.file_edit;
            this.toolStripButton_Edit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Edit.Name = "toolStripButton_Edit";
            this.toolStripButton_Edit.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_Edit.Text = "修改";
            this.toolStripButton_Edit.ToolTipText = "仅修改光标定位的一条记录";
            this.toolStripButton_Edit.Click += new System.EventHandler(this.toolStripButton_Edit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButton_ChangeJob
            // 
            this.toolStripButton_ChangeJob.Image = global::Commission.Properties.Resources.ChangeJob;
            this.toolStripButton_ChangeJob.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_ChangeJob.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ChangeJob.Name = "toolStripButton_ChangeJob";
            this.toolStripButton_ChangeJob.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_ChangeJob.Text = "调岗";
            this.toolStripButton_ChangeJob.Click += new System.EventHandler(this.toolStripButton_ChangeJob_Click);
            // 
            // toolStripButton_JobIn
            // 
            this.toolStripButton_JobIn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_JobIn.Image")));
            this.toolStripButton_JobIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_JobIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_JobIn.Name = "toolStripButton_JobIn";
            this.toolStripButton_JobIn.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_JobIn.Text = "调入";
            this.toolStripButton_JobIn.Click += new System.EventHandler(this.toolStripButton_JobIn_Click);
            // 
            // toolStripButton_JobOut
            // 
            this.toolStripButton_JobOut.Image = global::Commission.Properties.Resources.out_24;
            this.toolStripButton_JobOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_JobOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_JobOut.Name = "toolStripButton_JobOut";
            this.toolStripButton_JobOut.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_JobOut.Text = "调出";
            this.toolStripButton_JobOut.Click += new System.EventHandler(this.toolStripButton_JobOut_Click);
            // 
            // toolStripButton_Dimission
            // 
            this.toolStripButton_Dimission.Image = global::Commission.Properties.Resources.leave;
            this.toolStripButton_Dimission.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Dimission.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Dimission.Name = "toolStripButton_Dimission";
            this.toolStripButton_Dimission.Size = new System.Drawing.Size(60, 28);
            this.toolStripButton_Dimission.Text = "离职";
            this.toolStripButton_Dimission.Click += new System.EventHandler(this.toolStripButton_Dimission_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Add,
            this.toolStripButton_Del,
            this.toolStripButton_Edit,
            this.toolStripSeparator1,
            this.toolStripButton_ChangeJob,
            this.toolStripButton_JobIn,
            this.toolStripButton_JobOut,
            this.toolStripButton_Dimission,
            this.toolStripSeparator2,
            this.toolStripButton_Close});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(909, 31);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButton_Close
            // 
            this.toolStripButton_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Close.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Close.Image")));
            this.toolStripButton_Close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Close.Name = "toolStripButton_Close";
            this.toolStripButton_Close.Size = new System.Drawing.Size(23, 28);
            this.toolStripButton_Close.Text = "toolStripButton1";
            this.toolStripButton_Close.Click += new System.EventHandler(this.toolStripButton_Close_Click);
            // 
            // ColID
            // 
            this.ColID.DataPropertyName = "SalesID";
            this.ColID.HeaderText = "ID";
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            this.ColID.Visible = false;
            // 
            // ColSalesName
            // 
            this.ColSalesName.DataPropertyName = "SalesName";
            this.ColSalesName.HeaderText = "姓名";
            this.ColSalesName.Name = "ColSalesName";
            this.ColSalesName.ReadOnly = true;
            // 
            // ColPhone
            // 
            this.ColPhone.DataPropertyName = "Phone";
            this.ColPhone.HeaderText = "电话";
            this.ColPhone.Name = "ColPhone";
            this.ColPhone.ReadOnly = true;
            // 
            // ColInDate
            // 
            this.ColInDate.DataPropertyName = "InDate";
            this.ColInDate.HeaderText = "入职时间";
            this.ColInDate.Name = "ColInDate";
            this.ColInDate.ReadOnly = true;
            // 
            // ColOutDate
            // 
            this.ColOutDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColOutDate.DataPropertyName = "BeginDate";
            this.ColOutDate.HeaderText = "调入时间";
            this.ColOutDate.Name = "ColOutDate";
            this.ColOutDate.ReadOnly = true;
            // 
            // ColPosition
            // 
            this.ColPosition.DataPropertyName = "Position";
            this.ColPosition.HeaderText = "职位";
            this.ColPosition.Name = "ColPosition";
            this.ColPosition.ReadOnly = true;
            // 
            // ColJobType
            // 
            this.ColJobType.DataPropertyName = "JobType";
            this.ColJobType.HeaderText = "岗位类型";
            this.ColJobType.Name = "ColJobType";
            this.ColJobType.ReadOnly = true;
            // 
            // ColMemo
            // 
            this.ColMemo.DataPropertyName = "Memo";
            this.ColMemo.HeaderText = "备注";
            this.ColMemo.Name = "ColMemo";
            this.ColMemo.ReadOnly = true;
            this.ColMemo.Width = 200;
            // 
            // FrmEmploye
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 490);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip2);
            this.Name = "FrmEmploye";
            this.Text = "置业顾问管理";
            this.Load += new System.EventHandler(this.FrmEmploye_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Employe)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView_Dept;
        private System.Windows.Forms.DataGridView dataGridView_Employe;
        private System.Windows.Forms.ToolStripButton toolStripButton_Add;
        private System.Windows.Forms.ToolStripButton toolStripButton_Del;
        private System.Windows.Forms.ToolStripButton toolStripButton_Edit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_ChangeJob;
        private System.Windows.Forms.ToolStripButton toolStripButton_JobIn;
        private System.Windows.Forms.ToolStripButton toolStripButton_JobOut;
        private System.Windows.Forms.ToolStripButton toolStripButton_Dimission;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSalesName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColInDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOutDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColJobType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMemo;
    }
}