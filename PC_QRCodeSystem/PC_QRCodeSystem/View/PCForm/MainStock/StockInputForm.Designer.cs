namespace PC_QRCodeSystem.View
{
    partial class StockInputForm
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
            this.pnlOption = new System.Windows.Forms.Panel();
            this.btnMainClear = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.rbtnEven = new System.Windows.Forms.RadioButton();
            this.rbtnOdd = new System.Windows.Forms.RadioButton();
            this.btnPrintList = new System.Windows.Forms.Button();
            this.btnAutoPacking = new System.Windows.Forms.Button();
            this.btnManualPacking = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCapaciy = new System.Windows.Forms.TextBox();
            this.btnInspection = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnPremacImport = new System.Windows.Forms.Button();
            this.tc_Main = new System.Windows.Forms.TabControl();
            this.tab_Main = new System.Windows.Forms.TabPage();
            this.dgvPreInput = new System.Windows.Forms.DataGridView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.rbtnInvoice = new System.Windows.Forms.RadioButton();
            this.rbtnOrderNo = new System.Windows.Forms.RadioButton();
            this.rbtnSupplierCD = new System.Windows.Forms.RadioButton();
            this.rbtnItemNumber = new System.Windows.Forms.RadioButton();
            this.txtSearchCode = new System.Windows.Forms.TextBox();
            this.btnSearchPreInput = new System.Windows.Forms.Button();
            this.tab_Inspection = new System.Windows.Forms.TabPage();
            this.dgvInspection = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnInspectionClear = new System.Windows.Forms.Button();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.txtSupplierCD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInsBack = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.tab_Print = new System.Windows.Forms.TabPage();
            this.dgvPrintList = new System.Windows.Forms.DataGridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnPrintClear = new System.Windows.Forms.Button();
            this.btnManualPrint = new System.Windows.Forms.Button();
            this.btnPrintSelected = new System.Windows.Forms.Button();
            this.btnPrintAll = new System.Windows.Forms.Button();
            this.btnPrintBack = new System.Windows.Forms.Button();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsRow = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsTotalQty = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlOption.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tc_Main.SuspendLayout();
            this.tab_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreInput)).BeginInit();
            this.panel8.SuspendLayout();
            this.tab_Inspection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInspection)).BeginInit();
            this.panel4.SuspendLayout();
            this.tab_Print.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrintList)).BeginInit();
            this.panel7.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOption
            // 
            this.pnlOption.Controls.Add(this.btnMainClear);
            this.pnlOption.Controls.Add(this.panel6);
            this.pnlOption.Controls.Add(this.btnInspection);
            this.pnlOption.Controls.Add(this.btnSetting);
            this.pnlOption.Controls.Add(this.btnPremacImport);
            this.pnlOption.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOption.Location = new System.Drawing.Point(4, 4);
            this.pnlOption.Margin = new System.Windows.Forms.Padding(4);
            this.pnlOption.Name = "pnlOption";
            this.pnlOption.Size = new System.Drawing.Size(1000, 60);
            this.pnlOption.TabIndex = 2;
            // 
            // btnMainClear
            // 
            this.btnMainClear.Location = new System.Drawing.Point(890, 5);
            this.btnMainClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnMainClear.Name = "btnMainClear";
            this.btnMainClear.Size = new System.Drawing.Size(100, 50);
            this.btnMainClear.TabIndex = 24;
            this.btnMainClear.Text = "Clear";
            this.btnMainClear.UseVisualStyleBackColor = true;
            this.btnMainClear.Click += new System.EventHandler(this.btnMainClear_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.rbtnEven);
            this.panel6.Controls.Add(this.rbtnOdd);
            this.panel6.Controls.Add(this.btnPrintList);
            this.panel6.Controls.Add(this.btnAutoPacking);
            this.panel6.Controls.Add(this.btnManualPacking);
            this.panel6.Controls.Add(this.label14);
            this.panel6.Controls.Add(this.txtCapaciy);
            this.panel6.Location = new System.Drawing.Point(120, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(540, 60);
            this.panel6.TabIndex = 23;
            // 
            // rbtnEven
            // 
            this.rbtnEven.AutoSize = true;
            this.rbtnEven.BackColor = System.Drawing.Color.Lime;
            this.rbtnEven.Location = new System.Drawing.Point(300, 35);
            this.rbtnEven.Name = "rbtnEven";
            this.rbtnEven.Size = new System.Drawing.Size(58, 21);
            this.rbtnEven.TabIndex = 26;
            this.rbtnEven.TabStop = true;
            this.rbtnEven.Text = "Even";
            this.rbtnEven.UseVisualStyleBackColor = false;
            this.rbtnEven.CheckedChanged += new System.EventHandler(this.rbtnEven_CheckedChanged);
            // 
            // rbtnOdd
            // 
            this.rbtnOdd.AutoSize = true;
            this.rbtnOdd.BackColor = System.Drawing.Color.Yellow;
            this.rbtnOdd.Location = new System.Drawing.Point(367, 35);
            this.rbtnOdd.Name = "rbtnOdd";
            this.rbtnOdd.Size = new System.Drawing.Size(53, 21);
            this.rbtnOdd.TabIndex = 25;
            this.rbtnOdd.TabStop = true;
            this.rbtnOdd.Text = "Odd";
            this.rbtnOdd.UseVisualStyleBackColor = false;
            this.rbtnOdd.CheckedChanged += new System.EventHandler(this.rbtnEven_CheckedChanged);
            // 
            // btnPrintList
            // 
            this.btnPrintList.Location = new System.Drawing.Point(430, 5);
            this.btnPrintList.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintList.Name = "btnPrintList";
            this.btnPrintList.Size = new System.Drawing.Size(100, 50);
            this.btnPrintList.TabIndex = 24;
            this.btnPrintList.Text = "Print List";
            this.btnPrintList.UseVisualStyleBackColor = true;
            this.btnPrintList.Click += new System.EventHandler(this.btnPrintList_Click);
            // 
            // btnAutoPacking
            // 
            this.btnAutoPacking.Location = new System.Drawing.Point(10, 5);
            this.btnAutoPacking.Margin = new System.Windows.Forms.Padding(4);
            this.btnAutoPacking.Name = "btnAutoPacking";
            this.btnAutoPacking.Size = new System.Drawing.Size(100, 50);
            this.btnAutoPacking.TabIndex = 15;
            this.btnAutoPacking.Text = "Auto Packing";
            this.btnAutoPacking.UseVisualStyleBackColor = true;
            this.btnAutoPacking.Click += new System.EventHandler(this.btnAutoPacking_Click);
            // 
            // btnManualPacking
            // 
            this.btnManualPacking.Location = new System.Drawing.Point(120, 5);
            this.btnManualPacking.Margin = new System.Windows.Forms.Padding(4);
            this.btnManualPacking.Name = "btnManualPacking";
            this.btnManualPacking.Size = new System.Drawing.Size(100, 50);
            this.btnManualPacking.TabIndex = 18;
            this.btnManualPacking.Text = "Manual Packing";
            this.btnManualPacking.UseVisualStyleBackColor = true;
            this.btnManualPacking.Click += new System.EventHandler(this.btnManualPacking_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(230, 10);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 17);
            this.label14.TabIndex = 19;
            this.label14.Text = "Lot Size";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCapaciy
            // 
            this.txtCapaciy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapaciy.Location = new System.Drawing.Point(303, 5);
            this.txtCapaciy.Margin = new System.Windows.Forms.Padding(4);
            this.txtCapaciy.Name = "txtCapaciy";
            this.txtCapaciy.Size = new System.Drawing.Size(117, 23);
            this.txtCapaciy.TabIndex = 20;
            this.txtCapaciy.Text = "0";
            this.txtCapaciy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnInspection
            // 
            this.btnInspection.Location = new System.Drawing.Point(670, 5);
            this.btnInspection.Margin = new System.Windows.Forms.Padding(4);
            this.btnInspection.Name = "btnInspection";
            this.btnInspection.Size = new System.Drawing.Size(100, 50);
            this.btnInspection.TabIndex = 22;
            this.btnInspection.Text = "Inspection";
            this.btnInspection.UseVisualStyleBackColor = true;
            this.btnInspection.Click += new System.EventHandler(this.btnInspection_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(780, 5);
            this.btnSetting.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(100, 50);
            this.btnSetting.TabIndex = 21;
            this.btnSetting.Text = "Setting";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnPremacImport
            // 
            this.btnPremacImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPremacImport.Location = new System.Drawing.Point(10, 5);
            this.btnPremacImport.Margin = new System.Windows.Forms.Padding(4);
            this.btnPremacImport.Name = "btnPremacImport";
            this.btnPremacImport.Size = new System.Drawing.Size(100, 50);
            this.btnPremacImport.TabIndex = 16;
            this.btnPremacImport.Text = "Premac Import";
            this.btnPremacImport.UseVisualStyleBackColor = true;
            this.btnPremacImport.Click += new System.EventHandler(this.btnPremacImport_Click);
            // 
            // tc_Main
            // 
            this.tc_Main.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tc_Main.Controls.Add(this.tab_Main);
            this.tc_Main.Controls.Add(this.tab_Inspection);
            this.tc_Main.Controls.Add(this.tab_Print);
            this.tc_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_Main.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tc_Main.Location = new System.Drawing.Point(150, 70);
            this.tc_Main.Margin = new System.Windows.Forms.Padding(4);
            this.tc_Main.Name = "tc_Main";
            this.tc_Main.SelectedIndex = 0;
            this.tc_Main.Size = new System.Drawing.Size(1016, 475);
            this.tc_Main.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tc_Main.TabIndex = 3;
            // 
            // tab_Main
            // 
            this.tab_Main.Controls.Add(this.dgvPreInput);
            this.tab_Main.Controls.Add(this.panel8);
            this.tab_Main.Controls.Add(this.pnlOption);
            this.tab_Main.Location = new System.Drawing.Point(4, 28);
            this.tab_Main.Margin = new System.Windows.Forms.Padding(4);
            this.tab_Main.Name = "tab_Main";
            this.tab_Main.Padding = new System.Windows.Forms.Padding(4);
            this.tab_Main.Size = new System.Drawing.Size(1008, 443);
            this.tab_Main.TabIndex = 0;
            this.tab_Main.Text = "Main";
            this.tab_Main.UseVisualStyleBackColor = true;
            // 
            // dgvPreInput
            // 
            this.dgvPreInput.AllowUserToAddRows = false;
            this.dgvPreInput.AllowUserToDeleteRows = false;
            this.dgvPreInput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPreInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPreInput.Location = new System.Drawing.Point(184, 64);
            this.dgvPreInput.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPreInput.Name = "dgvPreInput";
            this.dgvPreInput.ReadOnly = true;
            this.dgvPreInput.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPreInput.Size = new System.Drawing.Size(820, 375);
            this.dgvPreInput.TabIndex = 3;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.rbtnInvoice);
            this.panel8.Controls.Add(this.rbtnOrderNo);
            this.panel8.Controls.Add(this.rbtnSupplierCD);
            this.panel8.Controls.Add(this.rbtnItemNumber);
            this.panel8.Controls.Add(this.txtSearchCode);
            this.panel8.Controls.Add(this.btnSearchPreInput);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(4, 64);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(180, 375);
            this.panel8.TabIndex = 28;
            // 
            // rbtnInvoice
            // 
            this.rbtnInvoice.AutoSize = true;
            this.rbtnInvoice.Location = new System.Drawing.Point(10, 130);
            this.rbtnInvoice.Name = "rbtnInvoice";
            this.rbtnInvoice.Size = new System.Drawing.Size(70, 21);
            this.rbtnInvoice.TabIndex = 5;
            this.rbtnInvoice.TabStop = true;
            this.rbtnInvoice.Text = "Invoice";
            this.rbtnInvoice.UseVisualStyleBackColor = true;
            // 
            // rbtnOrderNo
            // 
            this.rbtnOrderNo.AutoSize = true;
            this.rbtnOrderNo.Location = new System.Drawing.Point(10, 100);
            this.rbtnOrderNo.Name = "rbtnOrderNo";
            this.rbtnOrderNo.Size = new System.Drawing.Size(115, 21);
            this.rbtnOrderNo.TabIndex = 4;
            this.rbtnOrderNo.TabStop = true;
            this.rbtnOrderNo.Text = "Order number";
            this.rbtnOrderNo.UseVisualStyleBackColor = true;
            // 
            // rbtnSupplierCD
            // 
            this.rbtnSupplierCD.AutoSize = true;
            this.rbtnSupplierCD.Location = new System.Drawing.Point(10, 70);
            this.rbtnSupplierCD.Name = "rbtnSupplierCD";
            this.rbtnSupplierCD.Size = new System.Drawing.Size(113, 21);
            this.rbtnSupplierCD.TabIndex = 3;
            this.rbtnSupplierCD.TabStop = true;
            this.rbtnSupplierCD.Text = "Supplier code";
            this.rbtnSupplierCD.UseVisualStyleBackColor = true;
            // 
            // rbtnItemNumber
            // 
            this.rbtnItemNumber.AutoSize = true;
            this.rbtnItemNumber.Location = new System.Drawing.Point(10, 40);
            this.rbtnItemNumber.Name = "rbtnItemNumber";
            this.rbtnItemNumber.Size = new System.Drawing.Size(104, 21);
            this.rbtnItemNumber.TabIndex = 2;
            this.rbtnItemNumber.TabStop = true;
            this.rbtnItemNumber.Text = "Item number";
            this.rbtnItemNumber.UseVisualStyleBackColor = true;
            // 
            // txtSearchCode
            // 
            this.txtSearchCode.Location = new System.Drawing.Point(10, 10);
            this.txtSearchCode.Name = "txtSearchCode";
            this.txtSearchCode.Size = new System.Drawing.Size(160, 23);
            this.txtSearchCode.TabIndex = 1;
            // 
            // btnSearchPreInput
            // 
            this.btnSearchPreInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearchPreInput.Location = new System.Drawing.Point(40, 310);
            this.btnSearchPreInput.Name = "btnSearchPreInput";
            this.btnSearchPreInput.Size = new System.Drawing.Size(100, 50);
            this.btnSearchPreInput.TabIndex = 0;
            this.btnSearchPreInput.Text = "Search";
            this.btnSearchPreInput.UseVisualStyleBackColor = true;
            this.btnSearchPreInput.Click += new System.EventHandler(this.btnSearchPreInput_Click);
            // 
            // tab_Inspection
            // 
            this.tab_Inspection.Controls.Add(this.dgvInspection);
            this.tab_Inspection.Controls.Add(this.panel4);
            this.tab_Inspection.Location = new System.Drawing.Point(4, 28);
            this.tab_Inspection.Margin = new System.Windows.Forms.Padding(4);
            this.tab_Inspection.Name = "tab_Inspection";
            this.tab_Inspection.Padding = new System.Windows.Forms.Padding(4);
            this.tab_Inspection.Size = new System.Drawing.Size(1008, 443);
            this.tab_Inspection.TabIndex = 2;
            this.tab_Inspection.Text = "Inspection";
            this.tab_Inspection.UseVisualStyleBackColor = true;
            this.tab_Inspection.Paint += new System.Windows.Forms.PaintEventHandler(this.tab_Inspection_Paint);
            // 
            // dgvInspection
            // 
            this.dgvInspection.AllowUserToAddRows = false;
            this.dgvInspection.AllowUserToDeleteRows = false;
            this.dgvInspection.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvInspection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInspection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInspection.Location = new System.Drawing.Point(4, 84);
            this.dgvInspection.Margin = new System.Windows.Forms.Padding(4);
            this.dgvInspection.Name = "dgvInspection";
            this.dgvInspection.ReadOnly = true;
            this.dgvInspection.Size = new System.Drawing.Size(1000, 355);
            this.dgvInspection.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.btnAddItem);
            this.panel4.Controls.Add(this.btnInspectionClear);
            this.panel4.Controls.Add(this.txtSupplierName);
            this.panel4.Controls.Add(this.txtSupplierCD);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.btnInsBack);
            this.panel4.Controls.Add(this.btnDelete);
            this.panel4.Controls.Add(this.btnRegister);
            this.panel4.Controls.Add(this.txtBarcode);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(4, 4);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1000, 80);
            this.panel4.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 30);
            this.label1.TabIndex = 24;
            this.label1.Text = "Barcode";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.Location = new System.Drawing.Point(530, 10);
            this.btnAddItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(80, 60);
            this.btnAddItem.TabIndex = 4;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnInspectionClear
            // 
            this.btnInspectionClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInspectionClear.Location = new System.Drawing.Point(800, 10);
            this.btnInspectionClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnInspectionClear.Name = "btnInspectionClear";
            this.btnInspectionClear.Size = new System.Drawing.Size(80, 60);
            this.btnInspectionClear.TabIndex = 7;
            this.btnInspectionClear.Text = "Clear";
            this.btnInspectionClear.UseVisualStyleBackColor = true;
            this.btnInspectionClear.Click += new System.EventHandler(this.btnInspectionClear_Click);
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierName.Location = new System.Drawing.Point(280, 40);
            this.txtSupplierName.Margin = new System.Windows.Forms.Padding(4);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(240, 23);
            this.txtSupplierName.TabIndex = 3;
            this.txtSupplierName.Text = "Supplier Name";
            this.txtSupplierName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSupplierCD
            // 
            this.txtSupplierCD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierCD.Location = new System.Drawing.Point(120, 40);
            this.txtSupplierCD.Margin = new System.Windows.Forms.Padding(4);
            this.txtSupplierCD.Name = "txtSupplierCD";
            this.txtSupplierCD.Size = new System.Drawing.Size(120, 23);
            this.txtSupplierCD.TabIndex = 2;
            this.txtSupplierCD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupplierCD_KeyDown);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 30);
            this.label2.TabIndex = 23;
            this.label2.Text = "Supplier Code";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnInsBack
            // 
            this.btnInsBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsBack.Location = new System.Drawing.Point(890, 10);
            this.btnInsBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnInsBack.Name = "btnInsBack";
            this.btnInsBack.Size = new System.Drawing.Size(80, 60);
            this.btnInsBack.TabIndex = 8;
            this.btnInsBack.Text = "Back";
            this.btnInsBack.UseVisualStyleBackColor = true;
            this.btnInsBack.Click += new System.EventHandler(this.btnPrintBack_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(710, 10);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 60);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(620, 10);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(80, 60);
            this.btnRegister.TabIndex = 5;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(120, 10);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(4);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(400, 23);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // tab_Print
            // 
            this.tab_Print.Controls.Add(this.dgvPrintList);
            this.tab_Print.Controls.Add(this.panel7);
            this.tab_Print.Location = new System.Drawing.Point(4, 28);
            this.tab_Print.Margin = new System.Windows.Forms.Padding(4);
            this.tab_Print.Name = "tab_Print";
            this.tab_Print.Padding = new System.Windows.Forms.Padding(4);
            this.tab_Print.Size = new System.Drawing.Size(1008, 443);
            this.tab_Print.TabIndex = 3;
            this.tab_Print.Text = "Print";
            this.tab_Print.UseVisualStyleBackColor = true;
            // 
            // dgvPrintList
            // 
            this.dgvPrintList.AllowUserToAddRows = false;
            this.dgvPrintList.AllowUserToDeleteRows = false;
            this.dgvPrintList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPrintList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrintList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrintList.Location = new System.Drawing.Point(4, 64);
            this.dgvPrintList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPrintList.Name = "dgvPrintList";
            this.dgvPrintList.ReadOnly = true;
            this.dgvPrintList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrintList.Size = new System.Drawing.Size(1000, 375);
            this.dgvPrintList.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnPrintClear);
            this.panel7.Controls.Add(this.btnManualPrint);
            this.panel7.Controls.Add(this.btnPrintSelected);
            this.panel7.Controls.Add(this.btnPrintAll);
            this.panel7.Controls.Add(this.btnPrintBack);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(4, 4);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1000, 60);
            this.panel7.TabIndex = 1;
            // 
            // btnPrintClear
            // 
            this.btnPrintClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintClear.Location = new System.Drawing.Point(780, 5);
            this.btnPrintClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintClear.Name = "btnPrintClear";
            this.btnPrintClear.Size = new System.Drawing.Size(100, 50);
            this.btnPrintClear.TabIndex = 4;
            this.btnPrintClear.Text = "Clear";
            this.btnPrintClear.UseVisualStyleBackColor = true;
            this.btnPrintClear.Click += new System.EventHandler(this.btnPrintClear_Click);
            // 
            // btnManualPrint
            // 
            this.btnManualPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManualPrint.Location = new System.Drawing.Point(230, 5);
            this.btnManualPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnManualPrint.Name = "btnManualPrint";
            this.btnManualPrint.Size = new System.Drawing.Size(100, 50);
            this.btnManualPrint.TabIndex = 3;
            this.btnManualPrint.Text = "Print One Label";
            this.btnManualPrint.UseVisualStyleBackColor = true;
            this.btnManualPrint.Click += new System.EventHandler(this.btnManualPrint_Click);
            // 
            // btnPrintSelected
            // 
            this.btnPrintSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintSelected.Location = new System.Drawing.Point(10, 5);
            this.btnPrintSelected.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintSelected.Name = "btnPrintSelected";
            this.btnPrintSelected.Size = new System.Drawing.Size(100, 50);
            this.btnPrintSelected.TabIndex = 2;
            this.btnPrintSelected.Text = "Print Selected";
            this.btnPrintSelected.UseVisualStyleBackColor = true;
            this.btnPrintSelected.Click += new System.EventHandler(this.btnPrintSelected_Click);
            // 
            // btnPrintAll
            // 
            this.btnPrintAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintAll.Location = new System.Drawing.Point(120, 5);
            this.btnPrintAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintAll.Name = "btnPrintAll";
            this.btnPrintAll.Size = new System.Drawing.Size(100, 50);
            this.btnPrintAll.TabIndex = 1;
            this.btnPrintAll.Text = "Print All";
            this.btnPrintAll.UseVisualStyleBackColor = true;
            this.btnPrintAll.Click += new System.EventHandler(this.btnPrintAll_Click);
            // 
            // btnPrintBack
            // 
            this.btnPrintBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintBack.Location = new System.Drawing.Point(890, 5);
            this.btnPrintBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintBack.Name = "btnPrintBack";
            this.btnPrintBack.Size = new System.Drawing.Size(100, 50);
            this.btnPrintBack.TabIndex = 0;
            this.btnPrintBack.Text = "Back";
            this.btnPrintBack.UseVisualStyleBackColor = true;
            this.btnPrintBack.Click += new System.EventHandler(this.btnPrintBack_Click);
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel4,
            this.tsRow,
            this.tsTime,
            this.toolStripStatusLabel5,
            this.tsTotalQty});
            this.statusStrip2.Location = new System.Drawing.Point(150, 545);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1016, 24);
            this.statusStrip2.TabIndex = 27;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(40, 19);
            this.toolStripStatusLabel4.Text = "Row :";
            // 
            // tsRow
            // 
            this.tsRow.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsRow.Name = "tsRow";
            this.tsRow.Size = new System.Drawing.Size(40, 19);
            this.tsRow.Text = "None";
            // 
            // tsTime
            // 
            this.tsTime.Name = "tsTime";
            this.tsTime.Size = new System.Drawing.Size(816, 19);
            this.tsTime.Spring = true;
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(69, 19);
            this.toolStripStatusLabel5.Text = "Total Q\'ty :";
            // 
            // tsTotalQty
            // 
            this.tsTotalQty.Name = "tsTotalQty";
            this.tsTotalQty.Size = new System.Drawing.Size(36, 19);
            this.tsTotalQty.Text = "None";
            // 
            // StockInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 569);
            this.Controls.Add(this.tc_Main);
            this.Controls.Add(this.statusStrip2);
            this.dept = "";
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listper = null;
            this.logintime = new System.DateTime(((long)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.name = "";
            this.Name = "StockInputForm";
            this.position = "";
            this.Text = "Stock-In";
            this.tittle = "FormCommon";
            this.Load += new System.EventHandler(this.StockInputForm_Load);
            this.Controls.SetChildIndex(this.statusStrip2, 0);
            this.Controls.SetChildIndex(this.tc_Main, 0);
            this.pnlOption.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tc_Main.ResumeLayout(false);
            this.tab_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreInput)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.tab_Inspection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInspection)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tab_Print.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrintList)).EndInit();
            this.panel7.ResumeLayout(false);
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlOption;
        private System.Windows.Forms.TabControl tc_Main;
        private System.Windows.Forms.TabPage tab_Main;
        private System.Windows.Forms.TabPage tab_Inspection;
        private System.Windows.Forms.Button btnManualPacking;
        private System.Windows.Forms.Button btnPremacImport;
        private System.Windows.Forms.Button btnAutoPacking;
        private System.Windows.Forms.DataGridView dgvPreInput;
        private System.Windows.Forms.DataGridView dgvInspection;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtCapaciy;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnInspection;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TabPage tab_Print;
        private System.Windows.Forms.DataGridView dgvPrintList;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnPrintBack;
        private System.Windows.Forms.Button btnPrintList;
        private System.Windows.Forms.Button btnPrintSelected;
        private System.Windows.Forms.Button btnPrintAll;
        private System.Windows.Forms.Button btnInsBack;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.TextBox txtSupplierCD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnManualPrint;
        private System.Windows.Forms.Button btnMainClear;
        private System.Windows.Forms.Button btnInspectionClear;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnPrintClear;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.RadioButton rbtnOrderNo;
        private System.Windows.Forms.RadioButton rbtnSupplierCD;
        private System.Windows.Forms.RadioButton rbtnItemNumber;
        private System.Windows.Forms.TextBox txtSearchCode;
        private System.Windows.Forms.Button btnSearchPreInput;
        private System.Windows.Forms.RadioButton rbtnInvoice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel tsTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel tsRow;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel tsTotalQty;
        private System.Windows.Forms.RadioButton rbtnEven;
        private System.Windows.Forms.RadioButton rbtnOdd;
    }
}