namespace PC_QRCodeSystem.View
{
    partial class StockInForm
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
            this.grt_StockIn = new System.Windows.Forms.TabControl();
            this.tab_StockIn = new System.Windows.Forms.TabPage();
            this.dgvStockIn = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnManualPacking = new System.Windows.Forms.Button();
            this.btnAutoPacking = new System.Windows.Forms.Button();
            this.btnAddPremacItems = new System.Windows.Forms.Button();
            this.tab_Setting = new System.Windows.Forms.TabPage();
            this.btnSettingApply = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPremacFileBrowser = new System.Windows.Forms.Button();
            this.txtPremacURL = new System.Windows.Forms.TextBox();
            this.tab_Unit = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtUnitType = new System.Windows.Forms.TextBox();
            this.txtQtyUnit = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtItemNo = new System.Windows.Forms.TextBox();
            this.dgvUnit = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnDeleteUnitItem = new System.Windows.Forms.Button();
            this.btnUpdateUnitItem = new System.Windows.Forms.Button();
            this.btnAddUnitItem = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnPrinter = new System.Windows.Forms.Button();
            this.grt_StockIn.SuspendLayout();
            this.tab_StockIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockIn)).BeginInit();
            this.panel4.SuspendLayout();
            this.tab_Setting.SuspendLayout();
            this.tab_Unit.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnit)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // grt_StockIn
            // 
            this.grt_StockIn.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.grt_StockIn.Controls.Add(this.tab_StockIn);
            this.grt_StockIn.Controls.Add(this.tab_Setting);
            this.grt_StockIn.Controls.Add(this.tab_Unit);
            this.grt_StockIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grt_StockIn.Location = new System.Drawing.Point(145, 69);
            this.grt_StockIn.Name = "grt_StockIn";
            this.grt_StockIn.SelectedIndex = 0;
            this.grt_StockIn.Size = new System.Drawing.Size(839, 419);
            this.grt_StockIn.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.grt_StockIn.TabIndex = 2;
            // 
            // tab_StockIn
            // 
            this.tab_StockIn.Controls.Add(this.dgvStockIn);
            this.tab_StockIn.Controls.Add(this.panel4);
            this.tab_StockIn.Location = new System.Drawing.Point(4, 25);
            this.tab_StockIn.Name = "tab_StockIn";
            this.tab_StockIn.Padding = new System.Windows.Forms.Padding(3);
            this.tab_StockIn.Size = new System.Drawing.Size(831, 390);
            this.tab_StockIn.TabIndex = 0;
            this.tab_StockIn.Text = "Stock In";
            this.tab_StockIn.UseVisualStyleBackColor = true;
            // 
            // dgvStockIn
            // 
            this.dgvStockIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStockIn.Location = new System.Drawing.Point(3, 53);
            this.dgvStockIn.Name = "dgvStockIn";
            this.dgvStockIn.Size = new System.Drawing.Size(825, 334);
            this.dgvStockIn.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel9);
            this.panel4.Controls.Add(this.panel8);
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.btnSetting);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(825, 50);
            this.panel4.TabIndex = 2;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(3, 3);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(89, 41);
            this.btnRegister.TabIndex = 7;
            this.btnRegister.Text = "Register Packing";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Location = new System.Drawing.Point(98, 3);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(89, 41);
            this.btnImportExcel.TabIndex = 6;
            this.btnImportExcel.Text = "Get Items From Excel";
            this.btnImportExcel.UseVisualStyleBackColor = true;
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(193, 3);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(89, 41);
            this.btnAddItem.TabIndex = 5;
            this.btnAddItem.Text = "Add Item Manual";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(703, 3);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(89, 41);
            this.btnSetting.TabIndex = 4;
            this.btnSetting.Text = "Setting";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnManualPacking
            // 
            this.btnManualPacking.Location = new System.Drawing.Point(98, 3);
            this.btnManualPacking.Name = "btnManualPacking";
            this.btnManualPacking.Size = new System.Drawing.Size(89, 41);
            this.btnManualPacking.TabIndex = 3;
            this.btnManualPacking.Text = "Manual Packing";
            this.btnManualPacking.UseVisualStyleBackColor = true;
            this.btnManualPacking.Click += new System.EventHandler(this.btnManualPacking_Click);
            // 
            // btnAutoPacking
            // 
            this.btnAutoPacking.Location = new System.Drawing.Point(3, 3);
            this.btnAutoPacking.Name = "btnAutoPacking";
            this.btnAutoPacking.Size = new System.Drawing.Size(89, 41);
            this.btnAutoPacking.TabIndex = 2;
            this.btnAutoPacking.Text = "Auto Packing";
            this.btnAutoPacking.UseVisualStyleBackColor = true;
            this.btnAutoPacking.Click += new System.EventHandler(this.btnAutoPacking_Click);
            // 
            // btnAddPremacItems
            // 
            this.btnAddPremacItems.Location = new System.Drawing.Point(3, 3);
            this.btnAddPremacItems.Name = "btnAddPremacItems";
            this.btnAddPremacItems.Size = new System.Drawing.Size(89, 41);
            this.btnAddPremacItems.TabIndex = 1;
            this.btnAddPremacItems.Text = "Get Items From Premac";
            this.btnAddPremacItems.UseVisualStyleBackColor = true;
            this.btnAddPremacItems.Click += new System.EventHandler(this.btnAddPremacItems_Click);
            // 
            // tab_Setting
            // 
            this.tab_Setting.Controls.Add(this.btnSettingApply);
            this.tab_Setting.Controls.Add(this.label2);
            this.tab_Setting.Controls.Add(this.btnPremacFileBrowser);
            this.tab_Setting.Controls.Add(this.txtPremacURL);
            this.tab_Setting.Location = new System.Drawing.Point(4, 25);
            this.tab_Setting.Name = "tab_Setting";
            this.tab_Setting.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Setting.Size = new System.Drawing.Size(831, 390);
            this.tab_Setting.TabIndex = 1;
            this.tab_Setting.Text = "Setting";
            this.tab_Setting.UseVisualStyleBackColor = true;
            // 
            // btnSettingApply
            // 
            this.btnSettingApply.Location = new System.Drawing.Point(3, 355);
            this.btnSettingApply.Name = "btnSettingApply";
            this.btnSettingApply.Size = new System.Drawing.Size(64, 32);
            this.btnSettingApply.TabIndex = 4;
            this.btnSettingApply.Text = "Apply";
            this.btnSettingApply.UseVisualStyleBackColor = true;
            this.btnSettingApply.Click += new System.EventHandler(this.btnSettingApply_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Choose folder contains Premac file :";
            // 
            // btnPremacFileBrowser
            // 
            this.btnPremacFileBrowser.Location = new System.Drawing.Point(283, 27);
            this.btnPremacFileBrowser.Name = "btnPremacFileBrowser";
            this.btnPremacFileBrowser.Size = new System.Drawing.Size(75, 23);
            this.btnPremacFileBrowser.TabIndex = 2;
            this.btnPremacFileBrowser.Text = "Browser";
            this.btnPremacFileBrowser.UseVisualStyleBackColor = true;
            this.btnPremacFileBrowser.Click += new System.EventHandler(this.btnPremacFileBrowser_Click);
            // 
            // txtPremacURL
            // 
            this.txtPremacURL.Location = new System.Drawing.Point(9, 29);
            this.txtPremacURL.Name = "txtPremacURL";
            this.txtPremacURL.Size = new System.Drawing.Size(268, 20);
            this.txtPremacURL.TabIndex = 1;
            // 
            // tab_Unit
            // 
            this.tab_Unit.Controls.Add(this.panel6);
            this.tab_Unit.Controls.Add(this.dgvUnit);
            this.tab_Unit.Controls.Add(this.panel5);
            this.tab_Unit.Location = new System.Drawing.Point(4, 25);
            this.tab_Unit.Name = "tab_Unit";
            this.tab_Unit.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Unit.Size = new System.Drawing.Size(831, 390);
            this.tab_Unit.TabIndex = 2;
            this.tab_Unit.Text = "Unit";
            this.tab_Unit.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtUnitType);
            this.panel6.Controls.Add(this.txtQtyUnit);
            this.panel6.Controls.Add(this.txtItemName);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.txtItemNo);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(3, 53);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(222, 334);
            this.panel6.TabIndex = 7;
            // 
            // txtUnitType
            // 
            this.txtUnitType.Location = new System.Drawing.Point(80, 110);
            this.txtUnitType.Name = "txtUnitType";
            this.txtUnitType.Size = new System.Drawing.Size(121, 20);
            this.txtUnitType.TabIndex = 15;
            // 
            // txtQtyUnit
            // 
            this.txtQtyUnit.Location = new System.Drawing.Point(80, 80);
            this.txtQtyUnit.Name = "txtQtyUnit";
            this.txtQtyUnit.Size = new System.Drawing.Size(121, 20);
            this.txtQtyUnit.TabIndex = 14;
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(80, 50);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(121, 20);
            this.txtItemName.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Unit Type";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Qty per Unit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Item Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Item Number";
            // 
            // txtItemNo
            // 
            this.txtItemNo.Location = new System.Drawing.Point(80, 20);
            this.txtItemNo.Name = "txtItemNo";
            this.txtItemNo.Size = new System.Drawing.Size(121, 20);
            this.txtItemNo.TabIndex = 5;
            // 
            // dgvUnit
            // 
            this.dgvUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUnit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnit.Location = new System.Drawing.Point(231, 53);
            this.dgvUnit.Name = "dgvUnit";
            this.dgvUnit.Size = new System.Drawing.Size(597, 334);
            this.dgvUnit.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnDeleteUnitItem);
            this.panel5.Controls.Add(this.btnUpdateUnitItem);
            this.panel5.Controls.Add(this.btnAddUnitItem);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(825, 50);
            this.panel5.TabIndex = 4;
            // 
            // btnDeleteUnitItem
            // 
            this.btnDeleteUnitItem.Location = new System.Drawing.Point(193, 3);
            this.btnDeleteUnitItem.Name = "btnDeleteUnitItem";
            this.btnDeleteUnitItem.Size = new System.Drawing.Size(89, 41);
            this.btnDeleteUnitItem.TabIndex = 4;
            this.btnDeleteUnitItem.Text = "Delete";
            this.btnDeleteUnitItem.UseVisualStyleBackColor = true;
            // 
            // btnUpdateUnitItem
            // 
            this.btnUpdateUnitItem.Location = new System.Drawing.Point(98, 3);
            this.btnUpdateUnitItem.Name = "btnUpdateUnitItem";
            this.btnUpdateUnitItem.Size = new System.Drawing.Size(89, 41);
            this.btnUpdateUnitItem.TabIndex = 3;
            this.btnUpdateUnitItem.Text = "Update Item";
            this.btnUpdateUnitItem.UseVisualStyleBackColor = true;
            // 
            // btnAddUnitItem
            // 
            this.btnAddUnitItem.Location = new System.Drawing.Point(3, 3);
            this.btnAddUnitItem.Name = "btnAddUnitItem";
            this.btnAddUnitItem.Size = new System.Drawing.Size(89, 41);
            this.btnAddUnitItem.TabIndex = 2;
            this.btnAddUnitItem.Text = "Add Item";
            this.btnAddUnitItem.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnImportExcel);
            this.panel7.Controls.Add(this.btnAddPremacItems);
            this.panel7.Controls.Add(this.btnAddItem);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(285, 50);
            this.panel7.TabIndex = 3;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnAutoPacking);
            this.panel8.Controls.Add(this.btnManualPacking);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(285, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(194, 50);
            this.panel8.TabIndex = 3;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btnPrinter);
            this.panel9.Controls.Add(this.btnRegister);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(479, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(192, 50);
            this.panel9.TabIndex = 3;
            // 
            // btnPrinter
            // 
            this.btnPrinter.Location = new System.Drawing.Point(98, 3);
            this.btnPrinter.Name = "btnPrinter";
            this.btnPrinter.Size = new System.Drawing.Size(89, 41);
            this.btnPrinter.TabIndex = 8;
            this.btnPrinter.Text = "Printer Label";
            this.btnPrinter.UseVisualStyleBackColor = true;
            this.btnPrinter.Click += new System.EventHandler(this.btnPrinter_Click);
            // 
            // StockInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 488);
            this.Controls.Add(this.grt_StockIn);
            this.dept = "";
            this.logintime = new System.DateTime(((long)(0)));
            this.name = "";
            this.Name = "StockInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Input Stock";
            this.tittle = "FormCommon";
            this.Load += new System.EventHandler(this.StockInForm_Load);
            this.Controls.SetChildIndex(this.grt_StockIn, 0);
            this.grt_StockIn.ResumeLayout(false);
            this.tab_StockIn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockIn)).EndInit();
            this.panel4.ResumeLayout(false);
            this.tab_Setting.ResumeLayout(false);
            this.tab_Setting.PerformLayout();
            this.tab_Unit.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnit)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl grt_StockIn;
        private System.Windows.Forms.TabPage tab_StockIn;
        private System.Windows.Forms.TabPage tab_Setting;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPremacFileBrowser;
        private System.Windows.Forms.TextBox txtPremacURL;
        private System.Windows.Forms.Button btnSettingApply;
        private System.Windows.Forms.DataGridView dgvStockIn;
        private System.Windows.Forms.Button btnAddPremacItems;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnImportExcel;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnManualPacking;
        private System.Windows.Forms.Button btnAutoPacking;
        private System.Windows.Forms.TabPage tab_Unit;
        private System.Windows.Forms.DataGridView dgvUnit;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnDeleteUnitItem;
        private System.Windows.Forms.Button btnUpdateUnitItem;
        private System.Windows.Forms.Button btnAddUnitItem;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtQtyUnit;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtItemNo;
        private System.Windows.Forms.TextBox txtUnitType;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnPrinter;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
    }
}