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
            this.tab_Setting = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.grPrinter = new System.Windows.Forms.GroupBox();
            this.btnPrinterCheck = new System.Windows.Forms.Button();
            this.lbPrinterStatus = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbPrinter = new System.Windows.Forms.ComboBox();
            this.grPremacFolder = new System.Windows.Forms.GroupBox();
            this.btnBrowserPremac = new System.Windows.Forms.Button();
            this.txtPremacFolder = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tab_Inspection = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsLabelNumber = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvInspection = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.txtSupplierCD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInsBack = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tab_Print = new System.Windows.Forms.TabPage();
            this.dgvPacking = new System.Windows.Forms.DataGridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnManualPrint = new System.Windows.Forms.Button();
            this.btnPrintSelected = new System.Windows.Forms.Button();
            this.btnPrintAll = new System.Windows.Forms.Button();
            this.btnPrintBack = new System.Windows.Forms.Button();
            this.btnInspectionClear = new System.Windows.Forms.Button();
            this.pnlOption.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tc_Main.SuspendLayout();
            this.tab_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreInput)).BeginInit();
            this.tab_Setting.SuspendLayout();
            this.panel5.SuspendLayout();
            this.grPrinter.SuspendLayout();
            this.grPremacFolder.SuspendLayout();
            this.tab_Inspection.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInspection)).BeginInit();
            this.panel4.SuspendLayout();
            this.tab_Print.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacking)).BeginInit();
            this.panel7.SuspendLayout();
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
            this.btnMainClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(230, 15);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 30);
            this.label14.TabIndex = 19;
            this.label14.Text = "Lot Size";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCapaciy
            // 
            this.txtCapaciy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapaciy.Location = new System.Drawing.Point(320, 20);
            this.txtCapaciy.Margin = new System.Windows.Forms.Padding(4);
            this.txtCapaciy.Name = "txtCapaciy";
            this.txtCapaciy.Size = new System.Drawing.Size(100, 23);
            this.txtCapaciy.TabIndex = 20;
            this.txtCapaciy.Text = "0";
            this.txtCapaciy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnInspection
            // 
            this.btnInspection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.tc_Main.Controls.Add(this.tab_Setting);
            this.tc_Main.Controls.Add(this.tab_Inspection);
            this.tc_Main.Controls.Add(this.tab_Print);
            this.tc_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_Main.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tc_Main.Location = new System.Drawing.Point(150, 69);
            this.tc_Main.Margin = new System.Windows.Forms.Padding(4);
            this.tc_Main.Name = "tc_Main";
            this.tc_Main.SelectedIndex = 0;
            this.tc_Main.Size = new System.Drawing.Size(1016, 500);
            this.tc_Main.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tc_Main.TabIndex = 3;
            // 
            // tab_Main
            // 
            this.tab_Main.Controls.Add(this.dgvPreInput);
            this.tab_Main.Controls.Add(this.pnlOption);
            this.tab_Main.Location = new System.Drawing.Point(4, 28);
            this.tab_Main.Margin = new System.Windows.Forms.Padding(4);
            this.tab_Main.Name = "tab_Main";
            this.tab_Main.Padding = new System.Windows.Forms.Padding(4);
            this.tab_Main.Size = new System.Drawing.Size(1008, 468);
            this.tab_Main.TabIndex = 0;
            this.tab_Main.Text = "Main";
            this.tab_Main.UseVisualStyleBackColor = true;
            // 
            // dgvPreInput
            // 
            this.dgvPreInput.AllowUserToAddRows = false;
            this.dgvPreInput.AllowUserToDeleteRows = false;
            this.dgvPreInput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvPreInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPreInput.Location = new System.Drawing.Point(4, 64);
            this.dgvPreInput.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPreInput.Name = "dgvPreInput";
            this.dgvPreInput.ReadOnly = true;
            this.dgvPreInput.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPreInput.Size = new System.Drawing.Size(1000, 400);
            this.dgvPreInput.TabIndex = 3;
            // 
            // tab_Setting
            // 
            this.tab_Setting.Controls.Add(this.panel5);
            this.tab_Setting.Controls.Add(this.grPrinter);
            this.tab_Setting.Controls.Add(this.grPremacFolder);
            this.tab_Setting.Location = new System.Drawing.Point(4, 28);
            this.tab_Setting.Margin = new System.Windows.Forms.Padding(4);
            this.tab_Setting.Name = "tab_Setting";
            this.tab_Setting.Padding = new System.Windows.Forms.Padding(4);
            this.tab_Setting.Size = new System.Drawing.Size(1008, 468);
            this.tab_Setting.TabIndex = 1;
            this.tab_Setting.Text = "Setting";
            this.tab_Setting.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnApply);
            this.panel5.Controls.Add(this.btnBack);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(4, 404);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1000, 60);
            this.panel5.TabIndex = 4;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(30, 5);
            this.btnApply.Margin = new System.Windows.Forms.Padding(4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 50);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(870, 5);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 50);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // grPrinter
            // 
            this.grPrinter.Controls.Add(this.btnPrinterCheck);
            this.grPrinter.Controls.Add(this.lbPrinterStatus);
            this.grPrinter.Controls.Add(this.label13);
            this.grPrinter.Controls.Add(this.label12);
            this.grPrinter.Controls.Add(this.cmbPrinter);
            this.grPrinter.Dock = System.Windows.Forms.DockStyle.Top;
            this.grPrinter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grPrinter.Location = new System.Drawing.Point(4, 102);
            this.grPrinter.Margin = new System.Windows.Forms.Padding(4);
            this.grPrinter.Name = "grPrinter";
            this.grPrinter.Padding = new System.Windows.Forms.Padding(4);
            this.grPrinter.Size = new System.Drawing.Size(1000, 123);
            this.grPrinter.TabIndex = 0;
            this.grPrinter.TabStop = false;
            this.grPrinter.Text = "Printer";
            // 
            // btnPrinterCheck
            // 
            this.btnPrinterCheck.Location = new System.Drawing.Point(355, 33);
            this.btnPrinterCheck.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrinterCheck.Name = "btnPrinterCheck";
            this.btnPrinterCheck.Size = new System.Drawing.Size(100, 28);
            this.btnPrinterCheck.TabIndex = 4;
            this.btnPrinterCheck.Text = "Check";
            this.btnPrinterCheck.UseVisualStyleBackColor = true;
            this.btnPrinterCheck.Click += new System.EventHandler(this.btnPrinterCheck_Click);
            // 
            // lbPrinterStatus
            // 
            this.lbPrinterStatus.AutoSize = true;
            this.lbPrinterStatus.Location = new System.Drawing.Point(187, 74);
            this.lbPrinterStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPrinterStatus.Name = "lbPrinterStatus";
            this.lbPrinterStatus.Size = new System.Drawing.Size(42, 17);
            this.lbPrinterStatus.TabIndex = 3;
            this.lbPrinterStatus.Text = "None";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(40, 74);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 17);
            this.label13.TabIndex = 2;
            this.label13.Text = "Status";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(40, 37);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 17);
            this.label12.TabIndex = 1;
            this.label12.Text = "Printer";
            // 
            // cmbPrinter
            // 
            this.cmbPrinter.FormattingEnabled = true;
            this.cmbPrinter.Location = new System.Drawing.Point(187, 33);
            this.cmbPrinter.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPrinter.Name = "cmbPrinter";
            this.cmbPrinter.Size = new System.Drawing.Size(159, 24);
            this.cmbPrinter.TabIndex = 0;
            this.cmbPrinter.SelectedIndexChanged += new System.EventHandler(this.cmbPrinter_SelectedIndexChanged);
            // 
            // grPremacFolder
            // 
            this.grPremacFolder.Controls.Add(this.btnBrowserPremac);
            this.grPremacFolder.Controls.Add(this.txtPremacFolder);
            this.grPremacFolder.Controls.Add(this.label11);
            this.grPremacFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.grPremacFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grPremacFolder.Location = new System.Drawing.Point(4, 4);
            this.grPremacFolder.Margin = new System.Windows.Forms.Padding(4);
            this.grPremacFolder.Name = "grPremacFolder";
            this.grPremacFolder.Padding = new System.Windows.Forms.Padding(4);
            this.grPremacFolder.Size = new System.Drawing.Size(1000, 98);
            this.grPremacFolder.TabIndex = 1;
            this.grPremacFolder.TabStop = false;
            this.grPremacFolder.Text = "Premac Folder";
            // 
            // btnBrowserPremac
            // 
            this.btnBrowserPremac.Location = new System.Drawing.Point(533, 37);
            this.btnBrowserPremac.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowserPremac.Name = "btnBrowserPremac";
            this.btnBrowserPremac.Size = new System.Drawing.Size(100, 28);
            this.btnBrowserPremac.TabIndex = 2;
            this.btnBrowserPremac.Text = "Browser";
            this.btnBrowserPremac.UseVisualStyleBackColor = true;
            this.btnBrowserPremac.Click += new System.EventHandler(this.btnBrowserPremac_Click);
            // 
            // txtPremacFolder
            // 
            this.txtPremacFolder.Location = new System.Drawing.Point(187, 37);
            this.txtPremacFolder.Margin = new System.Windows.Forms.Padding(4);
            this.txtPremacFolder.Name = "txtPremacFolder";
            this.txtPremacFolder.Size = new System.Drawing.Size(319, 23);
            this.txtPremacFolder.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(40, 37);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Premac Folder";
            // 
            // tab_Inspection
            // 
            this.tab_Inspection.Controls.Add(this.statusStrip1);
            this.tab_Inspection.Controls.Add(this.dgvInspection);
            this.tab_Inspection.Controls.Add(this.panel4);
            this.tab_Inspection.Location = new System.Drawing.Point(4, 28);
            this.tab_Inspection.Margin = new System.Windows.Forms.Padding(4);
            this.tab_Inspection.Name = "tab_Inspection";
            this.tab_Inspection.Padding = new System.Windows.Forms.Padding(4);
            this.tab_Inspection.Size = new System.Drawing.Size(1008, 468);
            this.tab_Inspection.TabIndex = 2;
            this.tab_Inspection.Text = "Inspection";
            this.tab_Inspection.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.tsLabelNumber});
            this.statusStrip1.Location = new System.Drawing.Point(4, 442);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1000, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(858, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(86, 17);
            this.toolStripStatusLabel2.Text = "Label number :";
            // 
            // tsLabelNumber
            // 
            this.tsLabelNumber.Name = "tsLabelNumber";
            this.tsLabelNumber.Size = new System.Drawing.Size(36, 17);
            this.tsLabelNumber.Text = "None";
            // 
            // dgvInspection
            // 
            this.dgvInspection.AllowUserToAddRows = false;
            this.dgvInspection.AllowUserToDeleteRows = false;
            this.dgvInspection.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvInspection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInspection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInspection.Location = new System.Drawing.Point(4, 84);
            this.dgvInspection.Margin = new System.Windows.Forms.Padding(4);
            this.dgvInspection.Name = "dgvInspection";
            this.dgvInspection.ReadOnly = true;
            this.dgvInspection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInspection.Size = new System.Drawing.Size(1000, 380);
            this.dgvInspection.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnInspectionClear);
            this.panel4.Controls.Add(this.txtSupplierName);
            this.panel4.Controls.Add(this.txtSupplierCD);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.btnInsBack);
            this.panel4.Controls.Add(this.btnDelete);
            this.panel4.Controls.Add(this.btnRegister);
            this.panel4.Controls.Add(this.txtBarcode);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(4, 4);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1000, 80);
            this.panel4.TabIndex = 0;
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierName.Location = new System.Drawing.Point(280, 40);
            this.txtSupplierName.Margin = new System.Windows.Forms.Padding(4);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(240, 23);
            this.txtSupplierName.TabIndex = 25;
            this.txtSupplierName.Text = "Supplier Name";
            // 
            // txtSupplierCD
            // 
            this.txtSupplierCD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierCD.Location = new System.Drawing.Point(120, 40);
            this.txtSupplierCD.Margin = new System.Windows.Forms.Padding(4);
            this.txtSupplierCD.Name = "txtSupplierCD";
            this.txtSupplierCD.Size = new System.Drawing.Size(150, 23);
            this.txtSupplierCD.TabIndex = 24;
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
            this.btnInsBack.Location = new System.Drawing.Point(890, 15);
            this.btnInsBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnInsBack.Name = "btnInsBack";
            this.btnInsBack.Size = new System.Drawing.Size(100, 50);
            this.btnInsBack.TabIndex = 22;
            this.btnInsBack.Text = "Back";
            this.btnInsBack.UseVisualStyleBackColor = true;
            this.btnInsBack.Click += new System.EventHandler(this.btnPrintBack_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(650, 15);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 50);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(540, 15);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(100, 50);
            this.btnRegister.TabIndex = 20;
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
            this.txtBarcode.TabIndex = 19;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 10);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 30);
            this.label5.TabIndex = 18;
            this.label5.Text = "Barcode";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tab_Print
            // 
            this.tab_Print.Controls.Add(this.dgvPacking);
            this.tab_Print.Controls.Add(this.panel7);
            this.tab_Print.Location = new System.Drawing.Point(4, 28);
            this.tab_Print.Margin = new System.Windows.Forms.Padding(4);
            this.tab_Print.Name = "tab_Print";
            this.tab_Print.Padding = new System.Windows.Forms.Padding(4);
            this.tab_Print.Size = new System.Drawing.Size(1008, 468);
            this.tab_Print.TabIndex = 3;
            this.tab_Print.Text = "Print";
            this.tab_Print.UseVisualStyleBackColor = true;
            // 
            // dgvPacking
            // 
            this.dgvPacking.AllowUserToAddRows = false;
            this.dgvPacking.AllowUserToDeleteRows = false;
            this.dgvPacking.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvPacking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPacking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPacking.Location = new System.Drawing.Point(4, 64);
            this.dgvPacking.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPacking.Name = "dgvPacking";
            this.dgvPacking.ReadOnly = true;
            this.dgvPacking.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPacking.Size = new System.Drawing.Size(1000, 400);
            this.dgvPacking.TabIndex = 0;
            // 
            // panel7
            // 
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
            // btnManualPrint
            // 
            this.btnManualPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManualPrint.Location = new System.Drawing.Point(230, 5);
            this.btnManualPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnManualPrint.Name = "btnManualPrint";
            this.btnManualPrint.Size = new System.Drawing.Size(100, 50);
            this.btnManualPrint.TabIndex = 3;
            this.btnManualPrint.Text = "Manual Print";
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
            // btnInspectionClear
            // 
            this.btnInspectionClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInspectionClear.Location = new System.Drawing.Point(760, 15);
            this.btnInspectionClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnInspectionClear.Name = "btnInspectionClear";
            this.btnInspectionClear.Size = new System.Drawing.Size(100, 50);
            this.btnInspectionClear.TabIndex = 26;
            this.btnInspectionClear.Text = "Clear";
            this.btnInspectionClear.UseVisualStyleBackColor = true;
            this.btnInspectionClear.Click += new System.EventHandler(this.btnInspectionClear_Click);
            // 
            // StockInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 569);
            this.Controls.Add(this.tc_Main);
            this.dept = "";
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logintime = new System.DateTime(((long)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.name = "";
            this.Name = "StockInputForm";
            this.position = "";
            this.Text = "StockInputForm";
            this.tittle = "FormCommon";
            this.Load += new System.EventHandler(this.StockInputForm_Load);
            this.Controls.SetChildIndex(this.tc_Main, 0);
            this.pnlOption.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tc_Main.ResumeLayout(false);
            this.tab_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreInput)).EndInit();
            this.tab_Setting.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.grPrinter.ResumeLayout(false);
            this.grPrinter.PerformLayout();
            this.grPremacFolder.ResumeLayout(false);
            this.grPremacFolder.PerformLayout();
            this.tab_Inspection.ResumeLayout(false);
            this.tab_Inspection.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInspection)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tab_Print.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacking)).EndInit();
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlOption;
        private System.Windows.Forms.TabControl tc_Main;
        private System.Windows.Forms.TabPage tab_Main;
        private System.Windows.Forms.TabPage tab_Setting;
        private System.Windows.Forms.GroupBox grPrinter;
        private System.Windows.Forms.GroupBox grPremacFolder;
        private System.Windows.Forms.TabPage tab_Inspection;
        private System.Windows.Forms.Button btnManualPacking;
        private System.Windows.Forms.Button btnPremacImport;
        private System.Windows.Forms.Button btnAutoPacking;
        private System.Windows.Forms.DataGridView dgvPreInput;
        private System.Windows.Forms.DataGridView dgvInspection;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnBrowserPremac;
        private System.Windows.Forms.TextBox txtPremacFolder;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbPrinterStatus;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbPrinter;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtCapaciy;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnInspection;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnPrinterCheck;
        private System.Windows.Forms.TabPage tab_Print;
        private System.Windows.Forms.DataGridView dgvPacking;
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsLabelNumber;
        private System.Windows.Forms.Button btnInspectionClear;
    }
}