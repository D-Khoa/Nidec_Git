namespace PC_QRCodeSystem.View
{
    partial class StockOutputForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tc_StockOut = new System.Windows.Forms.TabControl();
            this.tab_Main = new System.Windows.Forms.TabPage();
            this.dgvMainStockOut = new System.Windows.Forms.DataGridView();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnInspection = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.cbSign = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSetNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWHQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtInvoice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbItemName = new System.Windows.Forms.Label();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.cmbIssue = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtStockOutQty = new System.Windows.Forms.TextBox();
            this.dtpStockOutDate = new System.Windows.Forms.DateTimePicker();
            this.lbUserName = new System.Windows.Forms.Label();
            this.txtUserCode = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbDestination = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.tab_ItemSet = new System.Windows.Forms.TabPage();
            this.pnlSetOptions = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSetOrderNum = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbSetHiItemName = new System.Windows.Forms.Label();
            this.txtSetHiItem = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSetOrderQty = new System.Windows.Forms.TextBox();
            this.dtpSetOrderDate = new System.Windows.Forms.DateTimePicker();
            this.lbSetUserName = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtSetLowItem = new System.Windows.Forms.TextBox();
            this.pnlSetButtons = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtSetUserCD = new System.Windows.Forms.TextBox();
            this.lbSetDesName = new System.Windows.Forms.Label();
            this.txtSetDesCode = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.dgvSetData = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSetInvoice = new System.Windows.Forms.TextBox();
            this.tc_StockOut.SuspendLayout();
            this.tab_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainStockOut)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.tab_ItemSet.SuspendLayout();
            this.pnlSetOptions.SuspendLayout();
            this.pnlSetButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetData)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(150, 469);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(703, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tc_StockOut
            // 
            this.tc_StockOut.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tc_StockOut.Controls.Add(this.tab_Main);
            this.tc_StockOut.Controls.Add(this.tab_ItemSet);
            this.tc_StockOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_StockOut.Location = new System.Drawing.Point(150, 70);
            this.tc_StockOut.Name = "tc_StockOut";
            this.tc_StockOut.SelectedIndex = 0;
            this.tc_StockOut.Size = new System.Drawing.Size(703, 399);
            this.tc_StockOut.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tc_StockOut.TabIndex = 6;
            // 
            // tab_Main
            // 
            this.tab_Main.Controls.Add(this.dgvMainStockOut);
            this.tab_Main.Controls.Add(this.pnlButtons);
            this.tab_Main.Controls.Add(this.pnlOptions);
            this.tab_Main.Location = new System.Drawing.Point(4, 25);
            this.tab_Main.Name = "tab_Main";
            this.tab_Main.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Main.Size = new System.Drawing.Size(695, 370);
            this.tab_Main.TabIndex = 0;
            this.tab_Main.Text = "Main";
            this.tab_Main.UseVisualStyleBackColor = true;
            // 
            // dgvMainStockOut
            // 
            this.dgvMainStockOut.AllowUserToAddRows = false;
            this.dgvMainStockOut.AllowUserToDeleteRows = false;
            this.dgvMainStockOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMainStockOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMainStockOut.Location = new System.Drawing.Point(3, 253);
            this.dgvMainStockOut.Margin = new System.Windows.Forms.Padding(4);
            this.dgvMainStockOut.MultiSelect = false;
            this.dgvMainStockOut.Name = "dgvMainStockOut";
            this.dgvMainStockOut.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMainStockOut.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMainStockOut.Size = new System.Drawing.Size(689, 114);
            this.dgvMainStockOut.TabIndex = 6;
            this.dgvMainStockOut.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMainStockOut_CellClick);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSearch);
            this.pnlButtons.Controls.Add(this.btnClear);
            this.pnlButtons.Controls.Add(this.btnInspection);
            this.pnlButtons.Controls.Add(this.btnRegister);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtons.Location = new System.Drawing.Point(3, 193);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(689, 60);
            this.pnlButtons.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(50, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 50);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(570, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 50);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnInspection
            // 
            this.btnInspection.Location = new System.Drawing.Point(480, 5);
            this.btnInspection.Name = "btnInspection";
            this.btnInspection.Size = new System.Drawing.Size(80, 50);
            this.btnInspection.TabIndex = 3;
            this.btnInspection.Text = "Inspection";
            this.btnInspection.UseVisualStyleBackColor = true;
            this.btnInspection.Click += new System.EventHandler(this.btnInspection_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(140, 5);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(80, 50);
            this.btnRegister.TabIndex = 0;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.cbSign);
            this.pnlOptions.Controls.Add(this.label6);
            this.pnlOptions.Controls.Add(this.txtSetNumber);
            this.pnlOptions.Controls.Add(this.label5);
            this.pnlOptions.Controls.Add(this.txtWHQty);
            this.pnlOptions.Controls.Add(this.label1);
            this.pnlOptions.Controls.Add(this.label4);
            this.pnlOptions.Controls.Add(this.label13);
            this.pnlOptions.Controls.Add(this.txtInvoice);
            this.pnlOptions.Controls.Add(this.label3);
            this.pnlOptions.Controls.Add(this.lbItemName);
            this.pnlOptions.Controls.Add(this.txtItemCode);
            this.pnlOptions.Controls.Add(this.cmbIssue);
            this.pnlOptions.Controls.Add(this.label15);
            this.pnlOptions.Controls.Add(this.txtStockOutQty);
            this.pnlOptions.Controls.Add(this.dtpStockOutDate);
            this.pnlOptions.Controls.Add(this.lbUserName);
            this.pnlOptions.Controls.Add(this.txtUserCode);
            this.pnlOptions.Controls.Add(this.label18);
            this.pnlOptions.Controls.Add(this.label20);
            this.pnlOptions.Controls.Add(this.cmbDestination);
            this.pnlOptions.Controls.Add(this.label22);
            this.pnlOptions.Controls.Add(this.txtComment);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOptions.Location = new System.Drawing.Point(3, 3);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(689, 190);
            this.pnlOptions.TabIndex = 7;
            // 
            // cbSign
            // 
            this.cbSign.AutoSize = true;
            this.cbSign.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cbSign.Location = new System.Drawing.Point(250, 130);
            this.cbSign.Name = "cbSign";
            this.cbSign.Size = new System.Drawing.Size(47, 17);
            this.cbSign.TabIndex = 41;
            this.cbSign.Text = "Sign";
            this.cbSign.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(460, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 20);
            this.label6.TabIndex = 40;
            this.label6.Text = "Set Number";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSetNumber
            // 
            this.txtSetNumber.Location = new System.Drawing.Point(550, 10);
            this.txtSetNumber.Name = "txtSetNumber";
            this.txtSetNumber.Size = new System.Drawing.Size(120, 20);
            this.txtSetNumber.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(460, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 38;
            this.label5.Text = "W/H Qty";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWHQty
            // 
            this.txtWHQty.Location = new System.Drawing.Point(550, 70);
            this.txtWHQty.Name = "txtWHQty";
            this.txtWHQty.ReadOnly = true;
            this.txtWHQty.Size = new System.Drawing.Size(120, 20);
            this.txtWHQty.TabIndex = 37;
            this.txtWHQty.TabStop = false;
            this.txtWHQty.Text = "0";
            this.txtWHQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWHQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Barcode/Item Code";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(460, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 36;
            this.label4.Text = "Invoice";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(10, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 20);
            this.label13.TabIndex = 27;
            this.label13.Text = "User Code";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInvoice
            // 
            this.txtInvoice.Location = new System.Drawing.Point(550, 40);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.ReadOnly = true;
            this.txtInvoice.Size = new System.Drawing.Size(120, 20);
            this.txtInvoice.TabIndex = 35;
            this.txtInvoice.TabStop = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(300, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "Comment";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbItemName
            // 
            this.lbItemName.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbItemName.Location = new System.Drawing.Point(260, 40);
            this.lbItemName.Name = "lbItemName";
            this.lbItemName.Size = new System.Drawing.Size(200, 20);
            this.lbItemName.TabIndex = 31;
            this.lbItemName.Text = "Item Name";
            this.lbItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtItemCode
            // 
            this.txtItemCode.Location = new System.Drawing.Point(120, 40);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(120, 20);
            this.txtItemCode.TabIndex = 30;
            this.txtItemCode.TabStop = false;
            this.txtItemCode.TextChanged += new System.EventHandler(this.txtNoPlanItemCD_TextChanged);
            this.txtItemCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNoPlanItemCD_KeyDown);
            // 
            // cmbIssue
            // 
            this.cmbIssue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIssue.FormattingEnabled = true;
            this.cmbIssue.Location = new System.Drawing.Point(120, 70);
            this.cmbIssue.Name = "cmbIssue";
            this.cmbIssue.Size = new System.Drawing.Size(340, 24);
            this.cmbIssue.TabIndex = 5;
            this.cmbIssue.SelectedIndexChanged += new System.EventHandler(this.cmbIssue_SelectedIndexChanged);
            this.cmbIssue.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbIssue_Format);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(10, 160);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 20);
            this.label15.TabIndex = 25;
            this.label15.Text = "Stock-Out Date";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtStockOutQty
            // 
            this.txtStockOutQty.Location = new System.Drawing.Point(120, 130);
            this.txtStockOutQty.Name = "txtStockOutQty";
            this.txtStockOutQty.Size = new System.Drawing.Size(120, 20);
            this.txtStockOutQty.TabIndex = 9;
            this.txtStockOutQty.Text = "0";
            this.txtStockOutQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtStockOutQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // dtpStockOutDate
            // 
            this.dtpStockOutDate.CustomFormat = "yyyy-MM-dd";
            this.dtpStockOutDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStockOutDate.Location = new System.Drawing.Point(120, 160);
            this.dtpStockOutDate.Name = "dtpStockOutDate";
            this.dtpStockOutDate.Size = new System.Drawing.Size(120, 20);
            this.dtpStockOutDate.TabIndex = 8;
            this.dtpStockOutDate.Value = new System.DateTime(2020, 3, 7, 0, 0, 0, 0);
            // 
            // lbUserName
            // 
            this.lbUserName.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName.Location = new System.Drawing.Point(260, 10);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(200, 20);
            this.lbUserName.TabIndex = 10;
            this.lbUserName.Text = "User Name";
            this.lbUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUserCode
            // 
            this.txtUserCode.Location = new System.Drawing.Point(120, 10);
            this.txtUserCode.Name = "txtUserCode";
            this.txtUserCode.Size = new System.Drawing.Size(120, 20);
            this.txtUserCode.TabIndex = 7;
            this.txtUserCode.TextChanged += new System.EventHandler(this.txtUserCode_TextChanged);
            this.txtUserCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserCode_KeyDown);
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(10, 130);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 20);
            this.label18.TabIndex = 8;
            this.label18.Text = "Stock-Out Q\'ty";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(10, 70);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(100, 20);
            this.label20.TabIndex = 6;
            this.label20.Text = "Issue Code";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDestination
            // 
            this.cmbDestination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDestination.FormattingEnabled = true;
            this.cmbDestination.Location = new System.Drawing.Point(120, 100);
            this.cmbDestination.Name = "cmbDestination";
            this.cmbDestination.Size = new System.Drawing.Size(340, 24);
            this.cmbDestination.TabIndex = 6;
            this.cmbDestination.SelectedIndexChanged += new System.EventHandler(this.cmbDestination_SelectedIndexChanged);
            this.cmbDestination.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbDestination_Format);
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(10, 100);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(100, 20);
            this.label22.TabIndex = 0;
            this.label22.Text = "Destination";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(390, 130);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(280, 50);
            this.txtComment.TabIndex = 11;
            // 
            // tab_ItemSet
            // 
            this.tab_ItemSet.Controls.Add(this.dgvSetData);
            this.tab_ItemSet.Controls.Add(this.pnlSetButtons);
            this.tab_ItemSet.Controls.Add(this.pnlSetOptions);
            this.tab_ItemSet.Location = new System.Drawing.Point(4, 25);
            this.tab_ItemSet.Name = "tab_ItemSet";
            this.tab_ItemSet.Padding = new System.Windows.Forms.Padding(3);
            this.tab_ItemSet.Size = new System.Drawing.Size(695, 370);
            this.tab_ItemSet.TabIndex = 1;
            this.tab_ItemSet.Text = "Item Set";
            this.tab_ItemSet.UseVisualStyleBackColor = true;
            // 
            // pnlSetOptions
            // 
            this.pnlSetOptions.Controls.Add(this.label7);
            this.pnlSetOptions.Controls.Add(this.txtSetInvoice);
            this.pnlSetOptions.Controls.Add(this.txtSetDesCode);
            this.pnlSetOptions.Controls.Add(this.lbSetDesName);
            this.pnlSetOptions.Controls.Add(this.txtSetUserCD);
            this.pnlSetOptions.Controls.Add(this.label2);
            this.pnlSetOptions.Controls.Add(this.txtSetOrderNum);
            this.pnlSetOptions.Controls.Add(this.label8);
            this.pnlSetOptions.Controls.Add(this.label10);
            this.pnlSetOptions.Controls.Add(this.label11);
            this.pnlSetOptions.Controls.Add(this.lbSetHiItemName);
            this.pnlSetOptions.Controls.Add(this.txtSetHiItem);
            this.pnlSetOptions.Controls.Add(this.label14);
            this.pnlSetOptions.Controls.Add(this.txtSetOrderQty);
            this.pnlSetOptions.Controls.Add(this.dtpSetOrderDate);
            this.pnlSetOptions.Controls.Add(this.lbSetUserName);
            this.pnlSetOptions.Controls.Add(this.label17);
            this.pnlSetOptions.Controls.Add(this.label21);
            this.pnlSetOptions.Controls.Add(this.txtSetLowItem);
            this.pnlSetOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSetOptions.Location = new System.Drawing.Point(3, 3);
            this.pnlSetOptions.Name = "pnlSetOptions";
            this.pnlSetOptions.Size = new System.Drawing.Size(689, 136);
            this.pnlSetOptions.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(460, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 40;
            this.label2.Text = "Order Number";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSetOrderNum
            // 
            this.txtSetOrderNum.Location = new System.Drawing.Point(550, 10);
            this.txtSetOrderNum.Name = "txtSetOrderNum";
            this.txtSetOrderNum.ReadOnly = true;
            this.txtSetOrderNum.Size = new System.Drawing.Size(120, 20);
            this.txtSetOrderNum.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(10, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 20);
            this.label8.TabIndex = 32;
            this.label8.Text = "Hi-Level Item";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(10, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 20);
            this.label10.TabIndex = 27;
            this.label10.Text = "User Code";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(10, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 20);
            this.label11.TabIndex = 34;
            this.label11.Text = "Item Code";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbSetHiItemName
            // 
            this.lbSetHiItemName.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbSetHiItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbSetHiItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSetHiItemName.Location = new System.Drawing.Point(260, 40);
            this.lbSetHiItemName.Name = "lbSetHiItemName";
            this.lbSetHiItemName.Size = new System.Drawing.Size(200, 20);
            this.lbSetHiItemName.TabIndex = 31;
            this.lbSetHiItemName.Text = "Item Name";
            this.lbSetHiItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSetHiItem
            // 
            this.txtSetHiItem.Location = new System.Drawing.Point(120, 40);
            this.txtSetHiItem.Name = "txtSetHiItem";
            this.txtSetHiItem.ReadOnly = true;
            this.txtSetHiItem.Size = new System.Drawing.Size(120, 20);
            this.txtSetHiItem.TabIndex = 30;
            this.txtSetHiItem.TabStop = false;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(460, 70);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 20);
            this.label14.TabIndex = 25;
            this.label14.Text = "Order Date";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSetOrderQty
            // 
            this.txtSetOrderQty.Location = new System.Drawing.Point(550, 40);
            this.txtSetOrderQty.Name = "txtSetOrderQty";
            this.txtSetOrderQty.ReadOnly = true;
            this.txtSetOrderQty.Size = new System.Drawing.Size(120, 20);
            this.txtSetOrderQty.TabIndex = 9;
            this.txtSetOrderQty.Text = "0";
            this.txtSetOrderQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtpSetOrderDate
            // 
            this.dtpSetOrderDate.CustomFormat = "yyyy-MM-dd";
            this.dtpSetOrderDate.Enabled = false;
            this.dtpSetOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSetOrderDate.Location = new System.Drawing.Point(550, 70);
            this.dtpSetOrderDate.Name = "dtpSetOrderDate";
            this.dtpSetOrderDate.Size = new System.Drawing.Size(120, 20);
            this.dtpSetOrderDate.TabIndex = 8;
            this.dtpSetOrderDate.Value = new System.DateTime(2020, 3, 7, 0, 0, 0, 0);
            // 
            // lbSetUserName
            // 
            this.lbSetUserName.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbSetUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbSetUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSetUserName.Location = new System.Drawing.Point(260, 10);
            this.lbSetUserName.Name = "lbSetUserName";
            this.lbSetUserName.Size = new System.Drawing.Size(200, 20);
            this.lbSetUserName.TabIndex = 10;
            this.lbSetUserName.Text = "User Name";
            this.lbSetUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(460, 40);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 20);
            this.label17.TabIndex = 8;
            this.label17.Text = "Order Qty";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(10, 70);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(100, 20);
            this.label21.TabIndex = 0;
            this.label21.Text = "Destination";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSetLowItem
            // 
            this.txtSetLowItem.Location = new System.Drawing.Point(120, 100);
            this.txtSetLowItem.Name = "txtSetLowItem";
            this.txtSetLowItem.Size = new System.Drawing.Size(340, 20);
            this.txtSetLowItem.TabIndex = 11;
            this.txtSetLowItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSetLowItem_KeyDown);
            // 
            // pnlSetButtons
            // 
            this.pnlSetButtons.Controls.Add(this.button5);
            this.pnlSetButtons.Controls.Add(this.button1);
            this.pnlSetButtons.Controls.Add(this.button2);
            this.pnlSetButtons.Controls.Add(this.button3);
            this.pnlSetButtons.Controls.Add(this.button4);
            this.pnlSetButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSetButtons.Location = new System.Drawing.Point(3, 139);
            this.pnlSetButtons.Name = "pnlSetButtons";
            this.pnlSetButtons.Size = new System.Drawing.Size(689, 60);
            this.pnlSetButtons.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(50, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 50);
            this.button1.TabIndex = 6;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(570, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 50);
            this.button2.TabIndex = 5;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(480, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 50);
            this.button3.TabIndex = 3;
            this.button3.Text = "Inspection";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(140, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 50);
            this.button4.TabIndex = 0;
            this.button4.Text = "Register";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // txtSetUserCD
            // 
            this.txtSetUserCD.Location = new System.Drawing.Point(120, 10);
            this.txtSetUserCD.Name = "txtSetUserCD";
            this.txtSetUserCD.ReadOnly = true;
            this.txtSetUserCD.Size = new System.Drawing.Size(120, 20);
            this.txtSetUserCD.TabIndex = 42;
            // 
            // lbSetDesName
            // 
            this.lbSetDesName.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbSetDesName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbSetDesName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSetDesName.Location = new System.Drawing.Point(260, 70);
            this.lbSetDesName.Name = "lbSetDesName";
            this.lbSetDesName.Size = new System.Drawing.Size(200, 20);
            this.lbSetDesName.TabIndex = 43;
            this.lbSetDesName.Text = "Destination";
            this.lbSetDesName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSetDesCode
            // 
            this.txtSetDesCode.Location = new System.Drawing.Point(120, 70);
            this.txtSetDesCode.Name = "txtSetDesCode";
            this.txtSetDesCode.ReadOnly = true;
            this.txtSetDesCode.Size = new System.Drawing.Size(120, 20);
            this.txtSetDesCode.TabIndex = 44;
            this.txtSetDesCode.TabStop = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(304, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(80, 50);
            this.button5.TabIndex = 7;
            this.button5.Text = "Inspection";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // dgvSetData
            // 
            this.dgvSetData.AllowUserToAddRows = false;
            this.dgvSetData.AllowUserToDeleteRows = false;
            this.dgvSetData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSetData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSetData.Location = new System.Drawing.Point(3, 199);
            this.dgvSetData.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSetData.MultiSelect = false;
            this.dgvSetData.Name = "dgvSetData";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSetData.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSetData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvSetData.Size = new System.Drawing.Size(689, 168);
            this.dgvSetData.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(460, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 20);
            this.label7.TabIndex = 46;
            this.label7.Text = "Invoice";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSetInvoice
            // 
            this.txtSetInvoice.Location = new System.Drawing.Point(550, 100);
            this.txtSetInvoice.Name = "txtSetInvoice";
            this.txtSetInvoice.ReadOnly = true;
            this.txtSetInvoice.Size = new System.Drawing.Size(120, 20);
            this.txtSetInvoice.TabIndex = 45;
            this.txtSetInvoice.TabStop = false;
            // 
            // StockOutputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 491);
            this.Controls.Add(this.tc_StockOut);
            this.Controls.Add(this.statusStrip1);
            this.dept = "";
            this.listper = null;
            this.logintime = new System.DateTime(((long)(0)));
            this.name = "";
            this.Name = "StockOutputForm";
            this.position = "";
            this.Text = "StockOutputForm";
            this.tittle = "FormCommon";
            this.Load += new System.EventHandler(this.StockOutputForm_Load);
            this.Controls.SetChildIndex(this.statusStrip1, 0);
            this.Controls.SetChildIndex(this.tc_StockOut, 0);
            this.tc_StockOut.ResumeLayout(false);
            this.tab_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainStockOut)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            this.tab_ItemSet.ResumeLayout(false);
            this.pnlSetOptions.ResumeLayout(false);
            this.pnlSetOptions.PerformLayout();
            this.pnlSetButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tc_StockOut;
        private System.Windows.Forms.TabPage tab_Main;
        private System.Windows.Forms.DataGridView dgvMainStockOut;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnInspection;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TabPage tab_ItemSet;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.CheckBox cbSign;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSetNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtWHQty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtInvoice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbItemName;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.ComboBox cmbIssue;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtStockOutQty;
        private System.Windows.Forms.DateTimePicker dtpStockOutDate;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.TextBox txtUserCode;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbDestination;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Panel pnlSetOptions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSetOrderNum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbSetHiItemName;
        private System.Windows.Forms.TextBox txtSetHiItem;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSetOrderQty;
        private System.Windows.Forms.DateTimePicker dtpSetOrderDate;
        private System.Windows.Forms.Label lbSetUserName;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtSetLowItem;
        private System.Windows.Forms.Panel pnlSetButtons;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtSetDesCode;
        private System.Windows.Forms.Label lbSetDesName;
        private System.Windows.Forms.TextBox txtSetUserCD;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView dgvSetData;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSetInvoice;
    }
}