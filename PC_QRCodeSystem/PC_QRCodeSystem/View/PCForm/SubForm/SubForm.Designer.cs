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
            this.txtItem = new System.Windows.Forms.TextBox();
            this.cmbItemLocation = new System.Windows.Forms.ComboBox();
            this.cmbItemType = new System.Windows.Forms.ComboBox();
            this.lbItem1 = new System.Windows.Forms.Label();
            this.lbItem2 = new System.Windows.Forms.Label();
            this.lbItem3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbItemLocationName = new System.Windows.Forms.Label();
            this.lbItemTypeName = new System.Windows.Forms.Label();
            this.lbItemName = new System.Windows.Forms.Label();
            this.grt_SubForm = new System.Windows.Forms.TabControl();
            this.tab_Item = new System.Windows.Forms.TabPage();
            this.tab_AddItem = new System.Windows.Forms.TabPage();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.panel4.SuspendLayout();
            this.grt_SubForm.SuspendLayout();
            this.tab_Item.SuspendLayout();
            this.tab_AddItem.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.tsNumberTotal});
            this.statusStrip1.Location = new System.Drawing.Point(145, 440);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(600, 24);
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
            this.dgvData.Location = new System.Drawing.Point(145, 254);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(600, 186);
            this.dgvData.TabIndex = 4;
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(140, 10);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(120, 20);
            this.txtItem.TabIndex = 0;
            this.txtItem.TextChanged += new System.EventHandler(this.txtItem_TextChanged);
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
            // cmbItemType
            // 
            this.cmbItemType.FormattingEnabled = true;
            this.cmbItemType.Location = new System.Drawing.Point(140, 40);
            this.cmbItemType.Name = "cmbItemType";
            this.cmbItemType.Size = new System.Drawing.Size(120, 21);
            this.cmbItemType.TabIndex = 2;
            this.cmbItemType.TextChanged += new System.EventHandler(this.cmbItemType_TextChanged);
            // 
            // lbItem1
            // 
            this.lbItem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbItem1.Location = new System.Drawing.Point(10, 10);
            this.lbItem1.Name = "lbItem1";
            this.lbItem1.Size = new System.Drawing.Size(120, 20);
            this.lbItem1.TabIndex = 3;
            this.lbItem1.Text = "Item Code";
            this.lbItem1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbItem2
            // 
            this.lbItem2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbItem2.Location = new System.Drawing.Point(10, 40);
            this.lbItem2.Name = "lbItem2";
            this.lbItem2.Size = new System.Drawing.Size(120, 20);
            this.lbItem2.TabIndex = 4;
            this.lbItem2.Text = "Item Type";
            this.lbItem2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbItem3
            // 
            this.lbItem3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbItem3.Location = new System.Drawing.Point(10, 70);
            this.lbItem3.Name = "lbItem3";
            this.lbItem3.Size = new System.Drawing.Size(120, 20);
            this.lbItem3.TabIndex = 5;
            this.lbItem3.Text = "Item Location";
            this.lbItem3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lbItemLocationName);
            this.panel4.Controls.Add(this.lbItemTypeName);
            this.panel4.Controls.Add(this.lbItemName);
            this.panel4.Controls.Add(this.cmbItemType);
            this.panel4.Controls.Add(this.lbItem3);
            this.panel4.Controls.Add(this.txtItem);
            this.panel4.Controls.Add(this.cmbItemLocation);
            this.panel4.Controls.Add(this.lbItem2);
            this.panel4.Controls.Add(this.lbItem1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(586, 100);
            this.panel4.TabIndex = 18;
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
            // grt_SubForm
            // 
            this.grt_SubForm.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.grt_SubForm.Controls.Add(this.tab_Item);
            this.grt_SubForm.Controls.Add(this.tab_AddItem);
            this.grt_SubForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.grt_SubForm.Location = new System.Drawing.Point(145, 69);
            this.grt_SubForm.Name = "grt_SubForm";
            this.grt_SubForm.SelectedIndex = 0;
            this.grt_SubForm.Size = new System.Drawing.Size(600, 135);
            this.grt_SubForm.TabIndex = 19;
            // 
            // tab_Item
            // 
            this.tab_Item.Controls.Add(this.panel4);
            this.tab_Item.Location = new System.Drawing.Point(4, 25);
            this.tab_Item.Name = "tab_Item";
            this.tab_Item.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Item.Size = new System.Drawing.Size(592, 106);
            this.tab_Item.TabIndex = 0;
            this.tab_Item.Text = "Item";
            this.tab_Item.UseVisualStyleBackColor = true;
            // 
            // tab_AddItem
            // 
            this.tab_AddItem.Controls.Add(this.textBox2);
            this.tab_AddItem.Controls.Add(this.label2);
            this.tab_AddItem.Controls.Add(this.textBox1);
            this.tab_AddItem.Controls.Add(this.label1);
            this.tab_AddItem.Location = new System.Drawing.Point(4, 25);
            this.tab_AddItem.Name = "tab_AddItem";
            this.tab_AddItem.Padding = new System.Windows.Forms.Padding(3);
            this.tab_AddItem.Size = new System.Drawing.Size(592, 106);
            this.tab_AddItem.TabIndex = 1;
            this.tab_AddItem.Text = "Add Item";
            this.tab_AddItem.UseVisualStyleBackColor = true;
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
            this.pnlButtons.Location = new System.Drawing.Point(145, 204);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(144, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Item Code";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(144, 66);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(120, 20);
            this.textBox2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Item Code";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 464);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.grt_SubForm);
            this.Controls.Add(this.statusStrip1);
            this.dept = "";
            this.logintime = new System.DateTime(((long)(0)));
            this.name = "";
            this.Name = "SubForm";
            this.Text = "SubForm";
            this.tittle = "FormCommon";
            this.Load += new System.EventHandler(this.SubForm_Load);
            this.Controls.SetChildIndex(this.statusStrip1, 0);
            this.Controls.SetChildIndex(this.grt_SubForm, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.dgvData, 0);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.grt_SubForm.ResumeLayout(false);
            this.tab_Item.ResumeLayout(false);
            this.tab_AddItem.ResumeLayout(false);
            this.tab_AddItem.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsNumberTotal;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label lbItem3;
        private System.Windows.Forms.Label lbItem2;
        private System.Windows.Forms.Label lbItem1;
        private System.Windows.Forms.ComboBox cmbItemType;
        private System.Windows.Forms.ComboBox cmbItemLocation;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TabControl grt_SubForm;
        private System.Windows.Forms.TabPage tab_Item;
        private System.Windows.Forms.TabPage tab_AddItem;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lbItemLocationName;
        private System.Windows.Forms.Label lbItemTypeName;
        private System.Windows.Forms.Label lbItemName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}