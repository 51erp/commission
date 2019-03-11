namespace Commission.MenuForms
{
    partial class FrmRole
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
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox_Role = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_Clear = new System.Windows.Forms.Button();
            this.button_SelAll = new System.Windows.Forms.Button();
            this.treeView_MenuList = new System.Windows.Forms.TreeView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_RoleName = new System.Windows.Forms.TextBox();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Save,
            this.toolStripButton_Close});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(724, 31);
            this.toolStrip2.TabIndex = 24;
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 31);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(724, 480);
            this.splitContainer1.SplitterDistance = 259;
            this.splitContainer1.TabIndex = 25;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.listBox_Role);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(259, 480);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "角色列表";
            // 
            // listBox_Role
            // 
            this.listBox_Role.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBox_Role.FormattingEnabled = true;
            this.listBox_Role.ItemHeight = 12;
            this.listBox_Role.Location = new System.Drawing.Point(5, 19);
            this.listBox_Role.Name = "listBox_Role";
            this.listBox_Role.Size = new System.Drawing.Size(249, 412);
            this.listBox_Role.TabIndex = 0;
            this.listBox_Role.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox_Role_MouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_Clear);
            this.groupBox2.Controls.Add(this.button_SelAll);
            this.groupBox2.Controls.Add(this.treeView_MenuList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(461, 480);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "权限列表";
            // 
            // button_Clear
            // 
            this.button_Clear.Image = global::Commission.Properties.Resources.none_12;
            this.button_Clear.Location = new System.Drawing.Point(327, 446);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(60, 23);
            this.button_Clear.TabIndex = 32;
            this.button_Clear.Text = "全清";
            this.button_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Clear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // button_SelAll
            // 
            this.button_SelAll.Image = global::Commission.Properties.Resources.all_12;
            this.button_SelAll.Location = new System.Drawing.Point(396, 446);
            this.button_SelAll.Name = "button_SelAll";
            this.button_SelAll.Size = new System.Drawing.Size(60, 23);
            this.button_SelAll.TabIndex = 31;
            this.button_SelAll.Text = "全选";
            this.button_SelAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_SelAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_SelAll.UseVisualStyleBackColor = true;
            this.button_SelAll.Click += new System.EventHandler(this.button_SelAll_Click);
            // 
            // treeView_MenuList
            // 
            this.treeView_MenuList.CheckBoxes = true;
            this.treeView_MenuList.Dock = System.Windows.Forms.DockStyle.Top;
            this.treeView_MenuList.Location = new System.Drawing.Point(5, 19);
            this.treeView_MenuList.Name = "treeView_MenuList";
            this.treeView_MenuList.Size = new System.Drawing.Size(451, 414);
            this.treeView_MenuList.TabIndex = 0;
            this.treeView_MenuList.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_MenuList_NodeMouseClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_RoleName);
            this.groupBox3.Controls.Add(this.button_Delete);
            this.groupBox3.Controls.Add(this.button_Add);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(5, 431);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(249, 44);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // textBox_RoleName
            // 
            this.textBox_RoleName.Location = new System.Drawing.Point(7, 15);
            this.textBox_RoleName.Name = "textBox_RoleName";
            this.textBox_RoleName.Size = new System.Drawing.Size(100, 21);
            this.textBox_RoleName.TabIndex = 34;
            // 
            // button_Delete
            // 
            this.button_Delete.Image = global::Commission.Properties.Resources.Del_16px;
            this.button_Delete.Location = new System.Drawing.Point(180, 14);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(60, 23);
            this.button_Delete.TabIndex = 33;
            this.button_Delete.Text = "删除";
            this.button_Delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // button_Add
            // 
            this.button_Add.Image = global::Commission.Properties.Resources.Add_16px;
            this.button_Add.Location = new System.Drawing.Point(113, 14);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(60, 23);
            this.button_Add.TabIndex = 32;
            this.button_Add.Text = "新增";
            this.button_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // FrmRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 511);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmRole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "角色及权限管理";
            this.Load += new System.EventHandler(this.FrmRole_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Save;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBox_Role;
        private System.Windows.Forms.TreeView treeView_MenuList;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Button button_SelAll;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_RoleName;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_Add;
    }
}