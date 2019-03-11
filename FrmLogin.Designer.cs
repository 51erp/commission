namespace Commission
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.button_Login = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.textBox_User = new System.Windows.Forms.TextBox();
            this.textBox_Pwd = new System.Windows.Forms.TextBox();
            this.button_Config = new System.Windows.Forms.Button();
            this.comboBox_Project = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Login
            // 
            this.button_Login.Image = global::Commission.Properties.Resources.enter_16;
            this.button_Login.Location = new System.Drawing.Point(507, 232);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(74, 28);
            this.button_Login.TabIndex = 4;
            this.button_Login.Text = " 登录";
            this.button_Login.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Login.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Login.UseVisualStyleBackColor = true;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // button_Close
            // 
            this.button_Close.Image = global::Commission.Properties.Resources.power_16;
            this.button_Close.Location = new System.Drawing.Point(427, 232);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(74, 28);
            this.button_Close.TabIndex = 100;
            this.button_Close.Text = " 关闭";
            this.button_Close.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // textBox_User
            // 
            this.textBox_User.Location = new System.Drawing.Point(364, 123);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.Size = new System.Drawing.Size(187, 21);
            this.textBox_User.TabIndex = 1;
            this.textBox_User.Enter += new System.EventHandler(this.textBox_Enter_SelectAll);
            this.textBox_User.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_User_KeyDown);
            // 
            // textBox_Pwd
            // 
            this.textBox_Pwd.Location = new System.Drawing.Point(364, 154);
            this.textBox_Pwd.Name = "textBox_Pwd";
            this.textBox_Pwd.PasswordChar = '*';
            this.textBox_Pwd.Size = new System.Drawing.Size(187, 21);
            this.textBox_Pwd.TabIndex = 2;
            this.textBox_Pwd.Enter += new System.EventHandler(this.textBox_Enter_SelectAll);
            this.textBox_Pwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_User_KeyDown);
            // 
            // button_Config
            // 
            this.button_Config.Image = global::Commission.Properties.Resources.Tools_16;
            this.button_Config.Location = new System.Drawing.Point(265, 232);
            this.button_Config.Name = "button_Config";
            this.button_Config.Size = new System.Drawing.Size(74, 28);
            this.button_Config.TabIndex = 200;
            this.button_Config.Text = " 设置";
            this.button_Config.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Config.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Config.UseVisualStyleBackColor = true;
            this.button_Config.Click += new System.EventHandler(this.button_Config_Click);
            // 
            // comboBox_Project
            // 
            this.comboBox_Project.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Project.FormattingEnabled = true;
            this.comboBox_Project.Location = new System.Drawing.Point(364, 184);
            this.comboBox_Project.Name = "comboBox_Project";
            this.comboBox_Project.Size = new System.Drawing.Size(187, 20);
            this.comboBox_Project.TabIndex = 3;
            this.comboBox_Project.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_User_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(364, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 201;
            this.label1.Text = "数据库连接中....";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::Commission.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(640, 300);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Project);
            this.Controls.Add(this.button_Config);
            this.Controls.Add(this.button_Login);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.textBox_Pwd);
            this.Controls.Add(this.textBox_User);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLogin";
            this.Shown += new System.EventHandler(this.FrmLogin_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Login;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.TextBox textBox_User;
        private System.Windows.Forms.TextBox textBox_Pwd;
        private System.Windows.Forms.Button button_Config;
        private System.Windows.Forms.ComboBox comboBox_Project;
        private System.Windows.Forms.Label label1;
    }
}