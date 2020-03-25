namespace PC_QRCodeSystem.View
{
    partial class StockDetailForm
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
            this.tc_MainStockDetail = new System.Windows.Forms.TabControl();
            this.tab_StockDetail = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dgvItemInfo = new System.Windows.Forms.DataGridView();
            this.btnLogs = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.dgvStockDetail = new System.Windows.Forms.DataGridView();
            this.tbpMain = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtInvoice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtInCharge = new System.Windows.Forms.TextBox();
            this.lbInchagre = new System.Windows.Forms.Label();
            this.lbSupplierName = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSupplierCD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtItemCD = new System.Windows.Forms.TextBox();
            this.lbItemName = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.cbSearchDate = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtStockInQty = new System.Windows.Forms.TextBox();
            this.txtPackingQty = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPackingCD = new System.Windows.Forms.TextBox();
            this.lbItemTypeName = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tab_LogDetail = new System.Windows.Forms.TabPage();
            this.dgvLogDetail = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogsBack = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStockDetailRows = new System.Windows.Forms.ToolStripStatusLabel();
            this.tc_MainStockDetail.SuspendLayout();
            this.tab_StockDetail.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockDetail)).BeginInit();
            this.tbpMain.SuspendLayout();
            this.tab_LogDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogDetail)).BeginInit();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc_MainStockDetail
            // 
            this.tc_MainStockDetail.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tc_MainStockDetail.Controls.Add(this.tab_StockDetail);
            this.tc_MainStockDetail.Controls.Add(this.tab_LogDetail);
            this.tc_MainStockDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_MainStockDetail.Location = new System.Drawing.Point(150, 70);
            this.tc_MainStockDetail.Margin = new System.Windows.Forms.Padding(4);
            this.tc_MainStockDetail.Name = "tc_MainStockDetail";
            this.tc_MainStockDetail.SelectedIndex = 0;
            this.tc_MainStockDetail.Size = new System.Drawing.Size(834, 468);
            this.tc_MainStockDetail.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tc_MainStockDetail.TabIndex = 2;
            // 
            // tab_StockDetail
            // 
            this.tab_StockDetail.Controls.Add(this.tableLayoutPanel1);
            this.tab_StockDetail.Controls.Add(this.tbpMain);
            this.tab_StockDetail.Location = new System.Drawing.Point(4, 28);
            this.tab_StockDetail.Margin = new System.Windows.Forms.Padding(4);
            this.tab_StockDetail.Name = "tab_StockDetail";
            this.tab_StockDetail.Padding = new System.Windows.Forms.Padding(4);
            this.tab_StockDetail.Size = new System.Drawing.Size(826, 436);
            this.tab_StockDetail.TabIndex = 0;
            this.tab_StockDetail.Text = "Stock Detail";
            this.tab_StockDetail.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.btnSearch, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnClear, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnUpdate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvItemInfo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnLogs, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDelete, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnExport, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvStockDetail, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 254);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(818, 178);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(4, 4);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(155, 52);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Search\r\nTìm Kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(696, 4);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(118, 52);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Reset\r\nXóa Thông Tin";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(167, 4);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(114, 52);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Update\r\nCập Nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dgvItemInfo
            // 
            this.dgvItemInfo.AllowUserToAddRows = false;
            this.dgvItemInfo.AllowUserToDeleteRows = false;
            this.dgvItemInfo.AllowUserToResizeRows = false;
            this.dgvItemInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dgvItemInfo, 6);
            this.dgvItemInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItemInfo.Location = new System.Drawing.Point(3, 63);
            this.dgvItemInfo.MultiSelect = false;
            this.dgvItemInfo.Name = "dgvItemInfo";
            this.dgvItemInfo.ReadOnly = true;
            this.dgvItemInfo.RowHeadersVisible = false;
            this.dgvItemInfo.Size = new System.Drawing.Size(812, 74);
            this.dgvItemInfo.TabIndex = 17;
            // 
            // btnLogs
            // 
            this.btnLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogs.Location = new System.Drawing.Point(574, 4);
            this.btnLogs.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(114, 52);
            this.btnLogs.TabIndex = 15;
            this.btnLogs.Text = "History\r\nLịch Sử";
            this.btnLogs.UseVisualStyleBackColor = true;
            this.btnLogs.Click += new System.EventHandler(this.btnLogs_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(289, 4);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(114, 52);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete Packing\r\nXóa Gói Hàng";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(411, 4);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(155, 52);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "Export CSV\r\nXuất CSV";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dgvStockDetail
            // 
            this.dgvStockDetail.AllowUserToAddRows = false;
            this.dgvStockDetail.AllowUserToDeleteRows = false;
            this.dgvStockDetail.AllowUserToResizeRows = false;
            this.dgvStockDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dgvStockDetail, 6);
            this.dgvStockDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStockDetail.Location = new System.Drawing.Point(4, 144);
            this.dgvStockDetail.Margin = new System.Windows.Forms.Padding(4);
            this.dgvStockDetail.MultiSelect = false;
            this.dgvStockDetail.Name = "dgvStockDetail";
            this.dgvStockDetail.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStockDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStockDetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvStockDetail.Size = new System.Drawing.Size(810, 100);
            this.dgvStockDetail.TabIndex = 18;
            this.dgvStockDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStockDetail_CellClick);
            this.dgvStockDetail.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvStockDetail_DataBindingComplete);
            // 
            // tbpMain
            // 
            this.tbpMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tbpMain.ColumnCount = 6;
            this.tbpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tbpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tbpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tbpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tbpMain.Controls.Add(this.label3, 0, 0);
            this.tbpMain.Controls.Add(this.txtBarcode, 1, 0);
            this.tbpMain.Controls.Add(this.label7, 0, 5);
            this.tbpMain.Controls.Add(this.txtInvoice, 1, 5);
            this.tbpMain.Controls.Add(this.label8, 0, 4);
            this.tbpMain.Controls.Add(this.txtOrderNo, 1, 4);
            this.tbpMain.Controls.Add(this.label13, 0, 3);
            this.tbpMain.Controls.Add(this.txtInCharge, 1, 3);
            this.tbpMain.Controls.Add(this.lbInchagre, 2, 3);
            this.tbpMain.Controls.Add(this.lbSupplierName, 2, 2);
            this.tbpMain.Controls.Add(this.label9, 0, 2);
            this.tbpMain.Controls.Add(this.txtSupplierCD, 1, 2);
            this.tbpMain.Controls.Add(this.label2, 0, 1);
            this.tbpMain.Controls.Add(this.txtItemCD, 1, 1);
            this.tbpMain.Controls.Add(this.lbItemName, 2, 1);
            this.tbpMain.Controls.Add(this.label10, 3, 4);
            this.tbpMain.Controls.Add(this.dtpToDate, 3, 5);
            this.tbpMain.Controls.Add(this.dtpFromDate, 2, 5);
            this.tbpMain.Controls.Add(this.cbSearchDate, 2, 4);
            this.tbpMain.Controls.Add(this.label16, 4, 5);
            this.tbpMain.Controls.Add(this.label15, 4, 4);
            this.tbpMain.Controls.Add(this.txtStockInQty, 5, 4);
            this.tbpMain.Controls.Add(this.txtPackingQty, 5, 5);
            this.tbpMain.Controls.Add(this.label14, 4, 3);
            this.tbpMain.Controls.Add(this.txtPackingCD, 5, 3);
            this.tbpMain.Controls.Add(this.lbItemTypeName, 5, 2);
            this.tbpMain.Controls.Add(this.label11, 4, 2);
            this.tbpMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbpMain.Location = new System.Drawing.Point(4, 4);
            this.tbpMain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tbpMain.Name = "tbpMain";
            this.tbpMain.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.tbpMain.RowCount = 6;
            this.tbpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbpMain.Size = new System.Drawing.Size(818, 250);
            this.tbpMain.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(9, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 40);
            this.label3.TabIndex = 46;
            this.label3.Text = "Barcode";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBarcode
            // 
            this.tbpMain.SetColumnSpan(this.txtBarcode, 4);
            this.txtBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(130, 4);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(557, 38);
            this.txtBarcode.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 206);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 43);
            this.label7.TabIndex = 11;
            this.label7.Text = "Invoice\r\nHóa đơn";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInvoice
            // 
            this.txtInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInvoice.Location = new System.Drawing.Point(131, 210);
            this.txtInvoice.Margin = new System.Windows.Forms.Padding(4);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(152, 22);
            this.txtInvoice.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 165);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 40);
            this.label8.TabIndex = 35;
            this.label8.Text = "Order No\r\nMã đặt hàng";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOrderNo.Location = new System.Drawing.Point(131, 169);
            this.txtOrderNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(152, 22);
            this.txtOrderNo.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(10, 124);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 40);
            this.label13.TabIndex = 40;
            this.label13.Text = "User Code\r\nMã số nhân viên";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInCharge
            // 
            this.txtInCharge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInCharge.Location = new System.Drawing.Point(131, 128);
            this.txtInCharge.Margin = new System.Windows.Forms.Padding(4);
            this.txtInCharge.Name = "txtInCharge";
            this.txtInCharge.Size = new System.Drawing.Size(152, 22);
            this.txtInCharge.TabIndex = 3;
            this.txtInCharge.Validated += new System.EventHandler(this.txtInCharge_Validated);
            // 
            // lbInchagre
            // 
            this.lbInchagre.BackColor = System.Drawing.SystemColors.Control;
            this.tbpMain.SetColumnSpan(this.lbInchagre, 2);
            this.lbInchagre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbInchagre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInchagre.Location = new System.Drawing.Point(292, 124);
            this.lbInchagre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbInchagre.Name = "lbInchagre";
            this.lbInchagre.Size = new System.Drawing.Size(273, 40);
            this.lbInchagre.TabIndex = 29;
            this.lbInchagre.Text = "User In Charge";
            this.lbInchagre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSupplierName
            // 
            this.lbSupplierName.BackColor = System.Drawing.SystemColors.Control;
            this.tbpMain.SetColumnSpan(this.lbSupplierName, 2);
            this.lbSupplierName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSupplierName.Location = new System.Drawing.Point(292, 83);
            this.lbSupplierName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSupplierName.Name = "lbSupplierName";
            this.lbSupplierName.Size = new System.Drawing.Size(273, 40);
            this.lbSupplierName.TabIndex = 33;
            this.lbSupplierName.Text = "Supplier Name";
            this.lbSupplierName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 83);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 40);
            this.label9.TabIndex = 7;
            this.label9.Text = "Supplier Code\r\nMã NSX";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSupplierCD
            // 
            this.txtSupplierCD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSupplierCD.Location = new System.Drawing.Point(131, 87);
            this.txtSupplierCD.Margin = new System.Windows.Forms.Padding(4);
            this.txtSupplierCD.Name = "txtSupplierCD";
            this.txtSupplierCD.Size = new System.Drawing.Size(152, 22);
            this.txtSupplierCD.TabIndex = 2;
            this.txtSupplierCD.Validated += new System.EventHandler(this.txtSupplierCD_Validated);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 40);
            this.label2.TabIndex = 3;
            this.label2.Text = "Item Code\r\nMã nguyên liệu";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItemCD
            // 
            this.txtItemCD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtItemCD.Location = new System.Drawing.Point(131, 46);
            this.txtItemCD.Margin = new System.Windows.Forms.Padding(4);
            this.txtItemCD.Name = "txtItemCD";
            this.txtItemCD.Size = new System.Drawing.Size(152, 22);
            this.txtItemCD.TabIndex = 1;
            this.txtItemCD.Validated += new System.EventHandler(this.txtItemCD_Validated);
            // 
            // lbItemName
            // 
            this.lbItemName.BackColor = System.Drawing.SystemColors.Control;
            this.tbpMain.SetColumnSpan(this.lbItemName, 2);
            this.lbItemName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbItemName.Location = new System.Drawing.Point(292, 42);
            this.lbItemName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbItemName.Name = "lbItemName";
            this.lbItemName.Size = new System.Drawing.Size(273, 40);
            this.lbItemName.TabIndex = 5;
            this.lbItemName.Text = "Item Name";
            this.lbItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(453, 165);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 40);
            this.label10.TabIndex = 13;
            this.label10.Text = "To Date\r\nTìm đến ngày";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "yyyy-MM-dd";
            this.dtpToDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(453, 210);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(112, 22);
            this.dtpToDate.TabIndex = 7;
            this.dtpToDate.Value = new System.DateTime(2020, 3, 16, 0, 0, 0, 0);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "yyyy-MM-dd";
            this.dtpFromDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(292, 210);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(152, 22);
            this.dtpFromDate.TabIndex = 6;
            this.dtpFromDate.Value = new System.DateTime(2020, 3, 16, 0, 0, 0, 0);
            // 
            // cbSearchDate
            // 
            this.cbSearchDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSearchDate.Location = new System.Drawing.Point(291, 165);
            this.cbSearchDate.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.cbSearchDate.Name = "cbSearchDate";
            this.cbSearchDate.Size = new System.Drawing.Size(154, 40);
            this.cbSearchDate.TabIndex = 13;
            this.cbSearchDate.Text = "Stock-In Date\r\nNgày nhập hàng";
            this.cbSearchDate.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(574, 206);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(112, 43);
            this.label16.TabIndex = 45;
            this.label16.Text = "Packing Q\'ty\r\nSL tồn trong gói";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(574, 165);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(112, 40);
            this.label15.TabIndex = 43;
            this.label15.Text = "Stock-In Q\'ty\r\nSố lượng nhập vào";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtStockInQty
            // 
            this.txtStockInQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStockInQty.Location = new System.Drawing.Point(695, 169);
            this.txtStockInQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtStockInQty.Name = "txtStockInQty";
            this.txtStockInQty.Size = new System.Drawing.Size(113, 22);
            this.txtStockInQty.TabIndex = 9;
            // 
            // txtPackingQty
            // 
            this.txtPackingQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPackingQty.Location = new System.Drawing.Point(695, 210);
            this.txtPackingQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtPackingQty.Name = "txtPackingQty";
            this.txtPackingQty.Size = new System.Drawing.Size(113, 22);
            this.txtPackingQty.TabIndex = 10;
            // 
            // label14
            // 
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(574, 124);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 40);
            this.label14.TabIndex = 41;
            this.label14.Text = "Packing Code\r\nMã gói NL";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPackingCD
            // 
            this.txtPackingCD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPackingCD.Location = new System.Drawing.Point(695, 128);
            this.txtPackingCD.Margin = new System.Windows.Forms.Padding(4);
            this.txtPackingCD.Name = "txtPackingCD";
            this.txtPackingCD.Size = new System.Drawing.Size(113, 22);
            this.txtPackingCD.TabIndex = 8;
            // 
            // lbItemTypeName
            // 
            this.lbItemTypeName.BackColor = System.Drawing.SystemColors.Control;
            this.lbItemTypeName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbItemTypeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbItemTypeName.Location = new System.Drawing.Point(695, 83);
            this.lbItemTypeName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbItemTypeName.Name = "lbItemTypeName";
            this.lbItemTypeName.Size = new System.Drawing.Size(113, 40);
            this.lbItemTypeName.TabIndex = 39;
            this.lbItemTypeName.Text = "Item Type Name";
            this.lbItemTypeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(574, 83);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 40);
            this.label11.TabIndex = 38;
            this.label11.Text = "Item Type\r\nLoại nguyên liệu\r\n";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tab_LogDetail
            // 
            this.tab_LogDetail.Controls.Add(this.dgvLogDetail);
            this.tab_LogDetail.Controls.Add(this.panel1);
            this.tab_LogDetail.Location = new System.Drawing.Point(4, 28);
            this.tab_LogDetail.Margin = new System.Windows.Forms.Padding(4);
            this.tab_LogDetail.Name = "tab_LogDetail";
            this.tab_LogDetail.Padding = new System.Windows.Forms.Padding(4);
            this.tab_LogDetail.Size = new System.Drawing.Size(826, 436);
            this.tab_LogDetail.TabIndex = 1;
            this.tab_LogDetail.Text = "Logs Detail";
            this.tab_LogDetail.UseVisualStyleBackColor = true;
            // 
            // dgvLogDetail
            // 
            this.dgvLogDetail.AllowUserToAddRows = false;
            this.dgvLogDetail.AllowUserToDeleteRows = false;
            this.dgvLogDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLogDetail.Location = new System.Drawing.Point(4, 64);
            this.dgvLogDetail.Name = "dgvLogDetail";
            this.dgvLogDetail.ReadOnly = true;
            this.dgvLogDetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvLogDetail.Size = new System.Drawing.Size(818, 368);
            this.dgvLogDetail.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLogsBack);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(818, 60);
            this.panel1.TabIndex = 2;
            // 
            // btnLogsBack
            // 
            this.btnLogsBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogsBack.Location = new System.Drawing.Point(690, 5);
            this.btnLogsBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogsBack.Name = "btnLogsBack";
            this.btnLogsBack.Size = new System.Drawing.Size(100, 50);
            this.btnLogsBack.TabIndex = 1;
            this.btnLogsBack.Text = "Back\r\nTrở Lại";
            this.btnLogsBack.UseVisualStyleBackColor = true;
            this.btnLogsBack.Click += new System.EventHandler(this.btnLogsBack_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 70);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 25);
            this.label5.TabIndex = 30;
            this.label5.Text = "User Code";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "In Charge";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.tsStockDetailRows});
            this.statusStrip1.Location = new System.Drawing.Point(150, 538);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(834, 24);
            this.statusStrip1.TabIndex = 42;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(738, 19);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(45, 19);
            this.toolStripStatusLabel2.Text = "Rows :";
            // 
            // tsStockDetailRows
            // 
            this.tsStockDetailRows.Name = "tsStockDetailRows";
            this.tsStockDetailRows.Size = new System.Drawing.Size(36, 19);
            this.tsStockDetailRows.Text = "None";
            // 
            // StockDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.tc_MainStockDetail);
            this.Controls.Add(this.statusStrip1);
            this.dept = "";
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listper = null;
            this.logintime = new System.DateTime(((long)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.name = "";
            this.Name = "StockDetailForm";
            this.position = "";
            this.Text = "Stock Detail";
            this.tittle = "FormCommon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.StockDetailForm_Load);
            this.Controls.SetChildIndex(this.statusStrip1, 0);
            this.Controls.SetChildIndex(this.tc_MainStockDetail, 0);
            this.tc_MainStockDetail.ResumeLayout(false);
            this.tab_StockDetail.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockDetail)).EndInit();
            this.tbpMain.ResumeLayout(false);
            this.tbpMain.PerformLayout();
            this.tab_LogDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogDetail)).EndInit();
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tc_MainStockDetail;
        private System.Windows.Forms.TabPage tab_StockDetail;
        private System.Windows.Forms.TabPage tab_LogDetail;
        private System.Windows.Forms.DataGridView dgvStockDetail;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbInchagre;
        private System.Windows.Forms.TextBox txtInCharge;
        private System.Windows.Forms.TextBox txtInvoice;
        private System.Windows.Forms.TextBox txtItemCD;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbItemName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbSupplierName;
        private System.Windows.Forms.CheckBox cbSearchDate;
        private System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSupplierCD;
        private System.Windows.Forms.DataGridView dgvItemInfo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsStockDetailRows;
        private System.Windows.Forms.DataGridView dgvLogDetail;
        private System.Windows.Forms.Button btnLogs;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLogsBack;
        private System.Windows.Forms.TableLayoutPanel tbpMain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtStockInQty;
        private System.Windows.Forms.TextBox txtPackingQty;
        private System.Windows.Forms.TextBox txtPackingCD;
        private System.Windows.Forms.Label lbItemTypeName;
    }
}