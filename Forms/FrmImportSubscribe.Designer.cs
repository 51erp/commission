namespace Commission.Forms
{
    partial class FrmImportSubscribe
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Del = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_View = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Back = new System.Windows.Forms.ToolStripButton();
            this.dataGridView_Subscribe = new System.Windows.Forms.DataGridView();
            this.ColCustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCustomerPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBuilding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColContractDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSalesID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSalesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Subscribe)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Add,
            this.toolStripButton_Del,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton_View,
            this.toolStripSeparator2,
            this.toolStripButton_Back});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(642, 25);
            this.toolStrip2.TabIndex = 4;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton_Add
            // 
            this.toolStripButton_Add.Image = global::Commission.Properties.Resources.open_16;
            this.toolStripButton_Add.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Add.Name = "toolStripButton_Add";
            this.toolStripButton_Add.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton_Add.Text = "打开";
            this.toolStripButton_Add.ToolTipText = "新增一个认购协议";
            // 
            // toolStripButton_Del
            // 
            this.toolStripButton_Del.Image = global::Commission.Properties.Resources.import_16;
            this.toolStripButton_Del.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Del.Name = "toolStripButton_Del";
            this.toolStripButton_Del.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton_Del.Text = "导入";
            this.toolStripButton_Del.ToolTipText = "删除当前选定记录";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::Commission.Properties.Resources.table_16;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton1.Text = "客户";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::Commission.Properties.Resources.table_16;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton2.Text = "顾问";
            // 
            // toolStripButton_View
            // 
            this.toolStripButton_View.Image = global::Commission.Properties.Resources.table_16;
            this.toolStripButton_View.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_View.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_View.Name = "toolStripButton_View";
            this.toolStripButton_View.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton_View.Text = "房源";
            this.toolStripButton_View.ToolTipText = "仅修改当前选定的记录";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_Back
            // 
            this.toolStripButton_Back.Image = global::Commission.Properties.Resources.exit;
            this.toolStripButton_Back.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Back.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Back.Name = "toolStripButton_Back";
            this.toolStripButton_Back.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton_Back.Text = "退出";
            this.toolStripButton_Back.ToolTipText = "对选定信息执行退房操作";
            // 
            // dataGridView_Subscribe
            // 
            this.dataGridView_Subscribe.AllowUserToAddRows = false;
            this.dataGridView_Subscribe.AllowUserToDeleteRows = false;
            this.dataGridView_Subscribe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView_Subscribe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Subscribe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCustomerID,
            this.ColCustomerName,
            this.ColCustomerPhone,
            this.ColItemID,
            this.ColBuilding,
            this.ColUnit,
            this.ColItemNum,
            this.ColContractDate,
            this.ColArea,
            this.ColPrice,
            this.ColAmount,
            this.ColTotalAmount,
            this.ColSalesID,
            this.ColSalesName});
            this.dataGridView_Subscribe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Subscribe.Location = new System.Drawing.Point(0, 25);
            this.dataGridView_Subscribe.Name = "dataGridView_Subscribe";
            this.dataGridView_Subscribe.ReadOnly = true;
            this.dataGridView_Subscribe.RowHeadersWidth = 21;
            this.dataGridView_Subscribe.RowTemplate.Height = 23;
            this.dataGridView_Subscribe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Subscribe.Size = new System.Drawing.Size(642, 372);
            this.dataGridView_Subscribe.TabIndex = 5;
            // 
            // ColCustomerID
            // 
            this.ColCustomerID.DataPropertyName = "CustomerID";
            this.ColCustomerID.HeaderText = "客户ID";
            this.ColCustomerID.Name = "ColCustomerID";
            this.ColCustomerID.ReadOnly = true;
            this.ColCustomerID.Width = 66;
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
            // ColItemID
            // 
            this.ColItemID.DataPropertyName = "ItemID";
            this.ColItemID.HeaderText = "房源ID";
            this.ColItemID.Name = "ColItemID";
            this.ColItemID.ReadOnly = true;
            this.ColItemID.Width = 66;
            // 
            // ColBuilding
            // 
            this.ColBuilding.DataPropertyName = "Building";
            this.ColBuilding.HeaderText = "楼幢";
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
            // ColContractDate
            // 
            this.ColContractDate.DataPropertyName = "SubscribeDate";
            this.ColContractDate.HeaderText = "认购时间";
            this.ColContractDate.Name = "ColContractDate";
            this.ColContractDate.ReadOnly = true;
            this.ColContractDate.Width = 78;
            // 
            // ColArea
            // 
            this.ColArea.DataPropertyName = "Area";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "F2";
            this.ColArea.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColArea.HeaderText = "认购面积";
            this.ColArea.Name = "ColArea";
            this.ColArea.ReadOnly = true;
            this.ColArea.Width = 78;
            // 
            // ColPrice
            // 
            this.ColPrice.DataPropertyName = "Price";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "F4";
            this.ColPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColPrice.HeaderText = "认购单价";
            this.ColPrice.Name = "ColPrice";
            this.ColPrice.ReadOnly = true;
            this.ColPrice.Width = 78;
            // 
            // ColAmount
            // 
            this.ColAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "F0";
            this.ColAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColAmount.HeaderText = "认购金额";
            this.ColAmount.Name = "ColAmount";
            this.ColAmount.ReadOnly = true;
            this.ColAmount.Width = 78;
            // 
            // ColTotalAmount
            // 
            this.ColTotalAmount.DataPropertyName = "TotalAmount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "F0";
            this.ColTotalAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColTotalAmount.HeaderText = "认购总款";
            this.ColTotalAmount.Name = "ColTotalAmount";
            this.ColTotalAmount.ReadOnly = true;
            this.ColTotalAmount.Width = 78;
            // 
            // ColSalesID
            // 
            this.ColSalesID.DataPropertyName = "SalesID";
            this.ColSalesID.HeaderText = "置业顾问ID";
            this.ColSalesID.Name = "ColSalesID";
            this.ColSalesID.ReadOnly = true;
            this.ColSalesID.Width = 90;
            // 
            // ColSalesName
            // 
            this.ColSalesName.DataPropertyName = "SalesName";
            this.ColSalesName.HeaderText = "置业顾问";
            this.ColSalesName.Name = "ColSalesName";
            this.ColSalesName.ReadOnly = true;
            this.ColSalesName.Width = 78;
            // 
            // FrmImportSubscribe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 397);
            this.Controls.Add(this.dataGridView_Subscribe);
            this.Controls.Add(this.toolStrip2);
            this.Name = "FrmImportSubscribe";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "认购导入";
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Subscribe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Add;
        private System.Windows.Forms.ToolStripButton toolStripButton_Del;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton_View;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Back;
        private System.Windows.Forms.DataGridView dataGridView_Subscribe;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCustomerPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBuilding;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColContractDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSalesID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSalesName;
    }
}