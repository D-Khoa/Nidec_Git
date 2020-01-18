namespace PC_QRCodeSystem.View
{
    partial class SubForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsNumberTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rbtnItemCode = new System.Windows.Forms.RadioButton();
            this.rbtnItemLocation = new System.Windows.Forms.RadioButton();
            this.rbtnItemType = new System.Windows.Forms.RadioButton();
            this.cmbItemLocation = new System.Windows.Forms.ComboBox();
            this.lbItemLocationName = new System.Windows.Forms.Label();
            this.cmbItemType = new System.Windows.Forms.ComboBox();
            this.lbItemTypeName = new System.Windows.Forms.Label();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.lbItemName = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.tsNumberTotal});
            this.statusStrip1.Location = new System.Drawing.Point(0, 440);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(745, 24);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(501, 19);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(44, 19);
            this.toolStripStatusLabel2.Text = "Total :";
            // 
            // tsNumberTotal
            // 
            this.tsNumberTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsNumberTotal.Name = "tsNumberTotal";
            this.tsNumberTotal.Size = new System.Drawing.Size(40, 19);
            this.tsNumberTotal.Text = "None";
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(745, 440);
            this.dgvData.TabIndex = 4;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSearch);
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Controls.Add(this.btnUpdate);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnAdd);
            this.pnlButtons.Controls.Add(this.btnClear);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtons.Location = new System.Drawing.Point(145, 169);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(600, 50);
            this.pnlButtons.TabIndex = 20;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(30, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 40);
            this.btnSearch.TabIndex = 24;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(490, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 40);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(214, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(80, 40);
            this.btnUpdate.TabIndex = 22;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(306, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 40);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(122, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 40);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(398, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 40);
            this.btnClear.TabIndex = 19;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rbtnItemLocation);
            this.panel4.Controls.Add(this.rbtnItemType);
            this.panel4.Controls.Add(this.rbtnItemCode);
            this.panel4.Controls.Add(this.lbItemLocationName);
            this.panel4.Controls.Add(this.lbItemTypeName);
            this.panel4.Controls.Add(this.lbItemName);
            this.panel4.Controls.Add(this.cmbItemType);
            this.panel4.Controls.Add(this.txtItem);
            this.panel4.Controls.Add(this.cmbItemLocation);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(145, 69);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(600, 100);
            this.panel4.TabIndex = 21;
            // 
            // rbtnItemCode
            // 
            this.rbtnItemCode.AutoSize = true;
            this.rbtnItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnItemCode.Location = new System.Drawing.Point(10, 10);
            this.rbtnItemCode.Name = "rbtnItemCode";
            this.rbtnItemCode.Size = new System.Drawing.Size(89, 21);
            this.rbtnItemCode.TabIndex = 9;
            this.rbtnItemCode.TabStop = true;
            this.rbtnItemCode.Text = "Item Code";
            this.rbtnItemCode.UseVisualStyleBackColor = true;
            this.rbtnItemCode.CheckedChanged += new System.EventHandler(this.rbtnItemCode_CheckedChanged);
            // 
            // rbtnItemLocation
            // 
            this.rbtnItemLocation.AutoSize = true;
            this.rbtnItemLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnItemLocation.Location = new System.Drawing.Point(10, 70);
            this.rbtnItemLocation.Name = "rbtnItemLocation";
            this.rbtnItemLocation.Size = new System.Drawing.Size(110, 21);
            this.rbtnItemLocation.TabIndex = 11;
            this.rbtnItemLocation.TabStop = true;
            this.rbtnItemLocation.Text = "Item Location";
            this.rbtnItemLocation.UseVisualStyleBackColor = true;
            this.rbtnItemLocation.CheckedChanged += new System.EventHandler(this.rbtnItemCode_CheckedChanged);
            // 
            // rbtnItemType
            // 
            this.rbtnItemType.AutoSize = true;
            this.rbtnItemType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnItemType.Location = new System.Drawing.Point(10, 40);
            this.rbtnItemType.Name = "rbtnItemType";
            this.rbtnItemType.Size = new System.Drawing.Size(88, 21);
            this.rbtnItemType.TabIndex = 10;
            this.rbtnItemType.TabStop = true;
            this.rbtnItemType.Text = "Item Type";
            this.rbtnItemType.UseVisualStyleBackColor = true;
            this.rbtnItemType.CheckedChanged += new System.EventHandler(this.rbtnItemCode_CheckedChanged);
            // 
            // cmbItemLocation
            // 
            this.cmbItemLocation.FormattingEnabled = true;
            this.cmbItemLocation.Location = new System.Drawing.Point(140, 70);
            this.cmbItemLocation.Name = "cmbItemLocation";
            this.cmbItemLocation.Size = new System.Drawing.Size(120, 21);
            this.cmbItemLocation.TabIndex = 1;
            this.cmbItemLocation.TextChanged += new System.EventHandler(this.cmbItemLocation_TextChanged);
            // 
            // lbItemLocationName
            // 
            this.lbItemLocationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbItemLocationName.Location = new System.Drawing.Point(300, 70);
            this.lbItemLocationName.Name = "lbItemLocationName";
            this.lbItemLocationName.Size = new System.Drawing.Size(200, 20);
            this.lbItemLocationName.TabIndex = 8;
            this.lbItemLocationName.Text = "None";
            this.lbItemLocationName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbItemType
            // 
            this.cmbItemType.FormattingEnabled = true;
            this.cmbItemType.Location = new System.Drawing.Point(140, 40);
            this.cmbItemType.Name = "cmbItemType";
            this.cmbItemType.Size = new System.Drawing.Size(120, 21);
            this.cmbItemType.TabIndex = 2;
            this.cmbItemType.TextChanged += new System.EventHandler(this.cmbItemType_TextChanged);
            // 
            // lbItemTypeName
            // 
            this.lbItemTypeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbItemTypeName.Location = new System.Drawing.Point(300, 40);
            this.lbItemTypeName.Name = "lbItemTypeName";
            this.lbItemTypeName.Size = new System.Drawing.Size(200, 20);
            this.lbItemTypeName.TabIndex = 7;
            this.lbItemTypeName.Text = "None";
            this.lbItemTypeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(140, 10);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(120, 20);
            this.txtItem.TabIndex = 0;
            this.txtItem.TextChanged += new System.EventHandler(this.txtItem_TextChanged);
            // 
            // lbItemName
            // 
            this.lbItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbItemName.Location = new System.Drawing.Point(300, 10);
            this.lbItemName.Name = "lbItemName";
            this.lbItemName.Size = new System.Drawing.Size(200, 20);
            this.lbItemName.TabIndex = 6;
            this.lbItemName.Text = "None";
            this.lbItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 464);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.statusStrip1);
            this.dept = "";
            this.logintime = new System.DateTime(((long)(0)));
            this.name = "";
            this.Name = "SubForm";
            this.Text = "SubForm";
            this.tittle = "FormCommon";
            this.Load += new System.EventHandler(this.SubForm_Load);
            this.Controls.SetChildIndex(this.statusStrip1, 0);
            this.Controls.SetChildIndex(this.dgvData, 0);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsNumberTotal;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rbtnItemCode;
        private System.Windows.Forms.RadioButton rbtnItemLocation;
        private System.Windows.Forms.RadioButton rbtnItemType;
        private System.Windows.Forms.Label lbItemLocationName;
        private System.Windows.Forms.Label lbItemTypeName;
        private System.Windows.Forms.Label lbItemName;
        private System.Windows.Forms.ComboBox cmbItemType;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.ComboBox cmbItemLocation;
    }
}