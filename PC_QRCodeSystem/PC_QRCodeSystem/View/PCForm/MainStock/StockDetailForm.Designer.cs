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
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tc_MainStockDetail = new System.Windows.Forms.TabControl();
            this.tab_StockDetail = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbpMain = new System.Windows.Forms.TableLayoutPanel();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtItemNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtInvoice = new System.Windows.Forms.TextBox();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbRemark = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tc_MainStockDetail.SuspendLayout();
            this.tab_StockDetail.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.tbpMain.SuspendLayout();
            this.SuspendLayout();
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
            // tc_MainStockDetail
            // 
            this.tc_MainStockDetail.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tc_MainStockDetail.Controls.Add(this.tab_StockDetail);
            this.tc_MainStockDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_MainStockDetail.Location = new System.Drawing.Point(150, 70);
            this.tc_MainStockDetail.Margin = new System.Windows.Forms.Padding(4);
            this.tc_MainStockDetail.Name = "tc_MainStockDetail";
            this.tc_MainStockDetail.SelectedIndex = 0;
            this.tc_MainStockDetail.Size = new System.Drawing.Size(915, 680);
            this.tc_MainStockDetail.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tc_MainStockDetail.TabIndex = 2;
            // 
            // tab_StockDetail
            // 
            this.tab_StockDetail.Controls.Add(this.panel1);
            this.tab_StockDetail.Controls.Add(this.tbpMain);
            this.tab_StockDetail.Location = new System.Drawing.Point(4, 28);
            this.tab_StockDetail.Margin = new System.Windows.Forms.Padding(4);
            this.tab_StockDetail.Name = "tab_StockDetail";
            this.tab_StockDetail.Padding = new System.Windows.Forms.Padding(4);
            this.tab_StockDetail.Size = new System.Drawing.Size(907, 648);
            this.tab_StockDetail.TabIndex = 0;
            this.tab_StockDetail.Text = "Stock Detail";
            this.tab_StockDetail.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvData);
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 273);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(899, 352);
            this.panel1.TabIndex = 6;
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(899, 328);
            this.dgvData.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsTime,
            this.toolStripStatusLabel2,
            this.tsTotal});
            this.statusStrip1.Location = new System.Drawing.Point(0, 328);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(899, 24);
            this.statusStrip1.TabIndex = 116;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsTime
            // 
            this.tsTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tsTime.Name = "tsTime";
            this.tsTime.Size = new System.Drawing.Size(795, 19);
            this.tsTime.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(44, 19);
            this.toolStripStatusLabel2.Text = "Total :";
            // 
            // tsTotal
            // 
            this.tsTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsTotal.Name = "tsTotal";
            this.tsTotal.Size = new System.Drawing.Size(40, 19);
            this.tsTotal.Text = "None";
            // 
            // tbpMain
            // 
            this.tbpMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tbpMain.ColumnCount = 4;
            this.tbpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbpMain.Controls.Add(this.dtpToDate, 3, 4);
            this.tbpMain.Controls.Add(this.btnClear, 2, 5);
            this.tbpMain.Controls.Add(this.txtQty, 3, 2);
            this.tbpMain.Controls.Add(this.label3, 0, 0);
            this.tbpMain.Controls.Add(this.txtBarcode, 1, 0);
            this.tbpMain.Controls.Add(this.label2, 0, 1);
            this.tbpMain.Controls.Add(this.txtItemNumber, 1, 1);
            this.tbpMain.Controls.Add(this.label4, 2, 1);
            this.tbpMain.Controls.Add(this.txtItemName, 3, 1);
            this.tbpMain.Controls.Add(this.label9, 0, 2);
            this.tbpMain.Controls.Add(this.txtSupplierName, 1, 2);
            this.tbpMain.Controls.Add(this.label7, 0, 3);
            this.tbpMain.Controls.Add(this.txtInvoice, 1, 3);
            this.tbpMain.Controls.Add(this.dtpFromDate, 1, 4);
            this.tbpMain.Controls.Add(this.label8, 0, 4);
            this.tbpMain.Controls.Add(this.btnBack, 3, 5);
            this.tbpMain.Controls.Add(this.label6, 2, 2);
            this.tbpMain.Controls.Add(this.label11, 2, 3);
            this.tbpMain.Controls.Add(this.cmbRemark, 3, 3);
            this.tbpMain.Controls.Add(this.label10, 2, 4);
            this.tbpMain.Controls.Add(this.btnExport, 1, 5);
            this.tbpMain.Controls.Add(this.btnSearch, 0, 5);
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
            this.tbpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbpMain.Size = new System.Drawing.Size(899, 269);
            this.tbpMain.TabIndex = 5;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "yyyy-MM-dd";
            this.dtpToDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(676, 169);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.ShowCheckBox = true;
            this.dtpToDate.Size = new System.Drawing.Size(213, 22);
            this.dtpToDate.TabIndex = 57;
            this.dtpToDate.Value = new System.DateTime(2020, 5, 21, 0, 0, 0, 0);
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(454, 210);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(213, 54);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear \r\nXóa Thông Tin";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtQty
            // 
            this.txtQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQty.Location = new System.Drawing.Point(676, 87);
            this.txtQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(213, 22);
            this.txtQty.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(9, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 40);
            this.label3.TabIndex = 46;
            this.label3.Text = "Barcode";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBarcode
            // 
            this.tbpMain.SetColumnSpan(this.txtBarcode, 3);
            this.txtBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(231, 4);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(659, 38);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 40);
            this.label2.TabIndex = 3;
            this.label2.Text = "Item Number\r\nMã nguyên liệu";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItemNumber
            // 
            this.txtItemNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtItemNumber.Location = new System.Drawing.Point(232, 46);
            this.txtItemNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtItemNumber.Name = "txtItemNumber";
            this.txtItemNumber.Size = new System.Drawing.Size(213, 22);
            this.txtItemNumber.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(454, 42);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 40);
            this.label4.TabIndex = 48;
            this.label4.Text = "Item Name\r\nTên nguyên liệu";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItemName
            // 
            this.txtItemName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtItemName.Location = new System.Drawing.Point(676, 46);
            this.txtItemName.Margin = new System.Windows.Forms.Padding(4);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(213, 22);
            this.txtItemName.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 83);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(213, 40);
            this.label9.TabIndex = 7;
            this.label9.Text = "Supplier Name\r\nTên NSX";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSupplierName.Location = new System.Drawing.Point(232, 87);
            this.txtSupplierName.Margin = new System.Windows.Forms.Padding(4);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(213, 22);
            this.txtSupplierName.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 124);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(213, 40);
            this.label7.TabIndex = 11;
            this.label7.Text = "Invoice\r\nHóa đơn";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInvoice
            // 
            this.txtInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInvoice.Location = new System.Drawing.Point(232, 128);
            this.txtInvoice.Margin = new System.Windows.Forms.Padding(4);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(213, 22);
            this.txtInvoice.TabIndex = 5;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "yyyy-MM-dd";
            this.dtpFromDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(232, 169);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.ShowCheckBox = true;
            this.dtpFromDate.Size = new System.Drawing.Size(213, 22);
            this.dtpFromDate.TabIndex = 7;
            this.dtpFromDate.Value = new System.DateTime(2020, 5, 7, 0, 0, 0, 0);
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 165);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(213, 40);
            this.label8.TabIndex = 51;
            this.label8.Text = "From Date";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBack
            // 
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(676, 210);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(213, 54);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "Back\r\nTrở Lại";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(454, 83);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(213, 40);
            this.label6.TabIndex = 50;
            this.label6.Text = "Qty\r\nSố Lượng";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(453, 124);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(215, 40);
            this.label11.TabIndex = 55;
            this.label11.Text = "Remark";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbRemark
            // 
            this.cmbRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbRemark.FormattingEnabled = true;
            this.cmbRemark.Location = new System.Drawing.Point(675, 127);
            this.cmbRemark.Name = "cmbRemark";
            this.cmbRemark.Size = new System.Drawing.Size(215, 24);
            this.cmbRemark.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(453, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(215, 40);
            this.label10.TabIndex = 56;
            this.label10.Text = "To Date";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(232, 210);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(213, 54);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "Export Excel \r\nXuất Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(10, 210);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(213, 54);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search\r\nTìm Kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // StockDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 750);
            this.Controls.Add(this.tc_MainStockDetail);
            this.dept = "";
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listper = null;
            this.logintime = new System.DateTime(((long)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.name = "";
            this.Name = "StockDetailForm";
            this.position = "";
            this.Text = "StockDetail";
            this.tittle = "FormCommon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.StockDetailForm_Load);
            this.Controls.SetChildIndex(this.tc_MainStockDetail, 0);
            this.tc_MainStockDetail.ResumeLayout(false);
            this.tab_StockDetail.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tbpMain.ResumeLayout(false);
            this.tbpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tc_MainStockDetail;
        private System.Windows.Forms.TabPage tab_StockDetail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.TableLayoutPanel tbpMain;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtItemNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtInvoice;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbRemark;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label10;
    }
}