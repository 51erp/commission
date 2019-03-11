namespace Commission.MenuForms
{
    partial class FrmUser
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
            this.toolStripButton_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Del = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Edit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Reset = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView_User = new System.Windows.Forms.DataGridView();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_Role = new System.Windows.Forms.ComboBox();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Search = new System.Windows.Forms.Button();
            this.toolStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_User)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Add,
            this.toolStripButton_Del,
            this.toolStripButton_Edit,
            this.toolStripButton_Reset,
            this.toolStripSeparator1,
            this.toolStripButton_Close});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(623, 31);
            this.toolStrip2.TabIndex = 5;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton_Add
            // 
            this.toolStripButton_Add.AutoSize = false;
            this.toolStripButton_Add.Image = global::Commission.Properties.Resources.Add_16px;
            this.toolStripButton_Add.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Add.Name = "toolStripButton_Add";
            this.toolStripButton_Add.Size = new System.Drawing.Size(52, 28);
            this.toolStripButton_Add.Text = "新增";
            this.toolStripButton_Add.Click += new System.EventHandler(this.toolStripButton_Add_Click);
            // 
            // toolStripButton_Del
            // 
            this.toolStripButton_Del.AutoSize = false;
            this.toolStripButton_Del.Image = global::Commission.Properties.Resources.Del_16px;
            this.toolStripButton_Del.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Del.Name = "toolStripButton_Del";
            this.toolStripButton_Del.Size = new System.Drawing.Size(52, 28);
            this.toolStripButton_Del.Text = "删除";
            this.toolStripButton_Del.Click += new System.EventHandler(this.toolStripButton_Del_Click);
            // 
            // toolStripButton_Edit
            // 
            this.toolStripButton_Edit.AutoSize = false;
            this.toolStripButton_Edit.Image = global::Commission.Properties.Resources.Modify_16px;
            this.toolStripButton_Edit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Edit.Name = "toolStripButton_Edit";
            this.toolStripButton_Edit.Size = new System.Drawing.Size(52, 28);
            this.toolStripButton_Edit.Text = "修改";
            this.toolStripButton_Edit.Click += new System.EventHandler(this.toolStripButton_Edit_Click);
            // 
            // toolStripButton_Reset
            // 
            this.toolStripButton_Reset.AutoSize = false;
            this.toolStripButton_Reset.Image = global::Commission.Properties.Resources.config;
            this.toolStripButton_Reset.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Reset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Reset.Name = "toolStripButton_Reset";
            this.toolStripButton_Reset.Size = new System.Drawing.Size(52, 28);
            this.toolStripButton_Reset.Text = "重置";
            this.toolStripButton_Reset.ToolTipText = "重置密码";
            this.toolStripButton_Reset.Click += new System.EventHandler(this.toolStripButton_Reset_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButton_Close
            // 
            this.toolStripButton_Close.AutoSize = false;
            this.toolStripButton_Close.Image = global::Commission.Properties.Resources.exit;
            this.toolStripButton_Close.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Close.Name = "toolStripButton_Close";
            this.toolStripButton_Close.Size = new System.Drawing.Size(52, 28);
            this.toolStripButton_Close.Text = "关闭";
            this.toolStripButton_Close.Click += new System.EventHandler(this.toolStripButton_Close_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView_User);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(623, 250);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "楼盘信息";
            // 
            // dataGridView_User
            // 
            this.dataGridView_User.AllowUserToAddRows = false;
            this.dataGridView_User.AllowUserToDeleteRows = false;
            this.dataGridView_User.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_User.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColUserName,
            this.ColRoleName,
            this.ColProjectName,
            this.ColMemo});
            this.dataGridView_User.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_User.Location = new System.Drawing.Point(5, 19);
            this.dataGridView_User.Name = "dataGridView_User";
            this.dataGridView_User.ReadOnly = true;
            this.dataGridView_User.RowHeadersWidth = 21;
            this.dataGridView_User.RowTemplate.Height = 23;
            this.dataGridView_User.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_User.Size = new System.Drawing.Size(613, 226);
            this.dataGridView_User.TabIndex = 1;
            // 
            // ColID
            // 
            this.ColID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColID.DataPropertyName = "ID";
            this.ColID.HeaderText = "ID";
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            this.ColID.Visible = false;
            this.ColID.Width = 80;
            // 
            // ColUserName
            // 
            this.ColUserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColUserName.DataPropertyName = "UserName";
            this.ColUserName.HeaderText = "用户名称";
            this.ColUserName.Name = "ColUserName";
            this.ColUserName.ReadOnly = true;
            // 
            // ColRoleName
            // 
            this.ColRoleName.DataPropertyName = "RoleName";
            this.ColRoleName.HeaderText = "角色";
            this.ColRoleName.Name = "ColRoleName";
            this.ColRoleName.ReadOnly = true;
            this.ColRoleName.Width = 80;
            // 
            // ColProjectName
            // 
            this.ColProjectName.DataPropertyName = "ProjectName";
            this.ColProjectName.HeaderText = "归属项目";
            this.ColProjectName.Name = "ColProjectName";
            this.ColProjectName.ReadOnly = true;
            this.ColProjectName.Width = 200;
            // 
            // ColMemo
            // 
            this.ColMemo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColMemo.DataPropertyName = "Memo";
            this.ColMemo.HeaderText = "备注";
            this.ColMemo.Name = "ColMemo";
            this.ColMemo.ReadOnly = true;
            this.ColMemo.Width = 200;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_Role);
            this.groupBox2.Controls.Add(this.textBox_Name);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.button_Search);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(623, 43);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // comboBox_Role
            // 
            this.comboBox_Role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Role.FormattingEnabled = true;
            this.comboBox_Role.Items.AddRange(new object[] {
            "全部",
            "管理员",
            "操作员"});
            this.comboBox_Role.Location = new System.Drawing.Point(204, 16);
            this.comboBox_Role.Name = "comboBox_Role";
            this.comboBox_Role.Size = new System.Drawing.Size(98, 20);
            this.comboBox_Role.TabIndex = 56;
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(63, 15);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(100, 21);
            this.textBox_Name.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "角色";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "用户名称";
            // 
            // button_Search
            // 
            this.button_Search.Image = global::Commission.Properties.Resources.Find_16;
            this.button_Search.Location = new System.Drawing.Point(328, 14);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(75, 23);
            this.button_Search.TabIndex = 2;
            this.button_Search.Text = " 查询";
            this.button_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // FrmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 324);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.toolStrip2);
            this.Name = "FrmUser";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.FrmUser_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_User)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Add;
        private System.Windows.Forms.ToolStripButton toolStripButton_Del;
        private System.Windows.Forms.ToolStripButton toolStripButton_Edit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView_User;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.ComboBox comboBox_Role;
        private System.Windows.Forms.ToolStripButton toolStripButton_Reset;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRoleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMemo;
    }
}