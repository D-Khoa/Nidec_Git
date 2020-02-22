namespace PC_QRCodeSystem.View
{
    partial class StockOutForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tc_Main = new System.Windows.Forms.TabControl();
            this.tab_NoPlan = new System.Windows.Forms.TabPage();
            this.dgvNoPlan = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNoPlanInvoice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNoPlanComment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbNoPlanItem = new System.Windows.Forms.Label();
            this.txtNoPlanItemCD = new System.Windows.Forms.TextBox();
            this.cmbNoPlanIssueCD = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtNoPlanStockOutQty = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpNoPlanStockOutDate = new System.Windows.Forms.DateTimePicker();
            this.lbNoPlanUser = new System.Windows.Forms.Label();
            this.txtNoPlanUserCD = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.lbNoPlanIssue = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lbNoPlanDestination = new System.Windows.Forms.Label();
            this.cmbNoPlanDestinationCD = new System.Windows.Forms.ComboBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.tab_Plan = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rbtnDeliveryDate = new System.Windows.Forms.RadioButton();
            this.rbtnPlanDate = new System.Windows.Forms.RadioButton();
            this.rbtnNoCheckDate = new System.Windows.Forms.RadioButton();
            this.txtItemCD = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lbUserName = new System.Windows.Forms.Label();
            this.txtUserCD = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lbItemName = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbDestinationName = new System.Windows.Forms.Label();
            this.cmbDestinationCD = new System.Windows.Forms.ComboBox();
            this.txtSetNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tab_Request = new System.Windows.Forms.TabPage();
            this.dgvStockOut = new System.Windows.Forms.DataGridView();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.tab_PrintList = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNoPlanPackingCD = new System.Windows.Forms.TextBox();
            this.tc_Main.SuspendLayout();
            this.tab_NoPlan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNoPlan)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tab_Plan.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tab_Request.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockOut)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc_Main
            // 
            this.tc_Main.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tc_Main.Controls.Add(this.tab_NoPlan);
            this.tc_Main.Controls.Add(this.tab_Plan);
            this.tc_Main.Controls.Add(this.tab_Request);
            this.tc_Main.Controls.Add(this.tab_PrintList);
            this.tc_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_Main.Location = new System.Drawing.Point(150, 70);
            this.tc_Main.Margin = new System.Windows.Forms.Padding(4);
            this.tc_Main.Name = "tc_Main";
            this.tc_Main.SelectedIndex = 0;
            this.tc_Main.Size = new System.Drawing.Size(834, 548);
            this.tc_Main.TabIndex = 22;
            // 
            // tab_NoPlan
            // 
            this.tab_NoPlan.Controls.Add(this.dgvNoPlan);
            this.tab_NoPlan.Controls.Add(this.panel5);
            this.tab_NoPlan.Controls.Add(this.panel6);
            this.tab_NoPlan.Location = new System.Drawing.Point(4, 28);
            this.tab_NoPlan.Margin = new System.Windows.Forms.Padding(4);
            this.tab_NoPlan.Name = "tab_NoPlan";
            this.tab_NoPlan.Padding = new System.Windows.Forms.Padding(4);
            this.tab_NoPlan.Size = new System.Drawing.Size(826, 516);
            this.tab_NoPlan.TabIndex = 0;
            this.tab_NoPlan.Text = "No Planned";
            this.tab_NoPlan.UseVisualStyleBackColor = true;
            this.tab_NoPlan.Paint += new System.Windows.Forms.PaintEventHandler(this.tab_NoPlan_Paint);
            // 
            // dgvNoPlan
            // 
            this.dgvNoPlan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvNoPlan.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgvNoPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNoPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNoPlan.Location = new System.Drawing.Point(4, 284);
            this.dgvNoPlan.Margin = new System.Windows.Forms.Padding(4);
            this.dgvNoPlan.MultiSelect = false;
            this.dgvNoPlan.Name = "dgvNoPlan";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNoPlan.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNoPlan.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvNoPlan.Size = new System.Drawing.Size(818, 228);
            this.dgvNoPlan.TabIndex = 6;
            this.dgvNoPlan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNoPlan_CellClick);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnExport);
            this.panel5.Controls.Add(this.button1);
            this.panel5.Controls.Add(this.btnPrint);
            this.panel5.Controls.Add(this.button2);
            this.panel5.Controls.Add(this.button3);
            this.panel5.Controls.Add(this.button4);
            this.panel5.Controls.Add(this.button5);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(4, 224);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(818, 60);
            this.panel5.TabIndex = 8;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(392, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(80, 50);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(578, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 50);
            this.button1.TabIndex = 5;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(485, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 50);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(299, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 50);
            this.button2.TabIndex = 3;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(206, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 50);
            this.button3.TabIndex = 2;
            this.button3.Text = "Update";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(113, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 50);
            this.button4.TabIndex = 1;
            this.button4.Text = "Add";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(20, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(80, 50);
            this.button5.TabIndex = 0;
            this.button5.Text = "Search";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.txtNoPlanPackingCD);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.txtNoPlanInvoice);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.txtNoPlanComment);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.lbNoPlanItem);
            this.panel6.Controls.Add(this.txtNoPlanItemCD);
            this.panel6.Controls.Add(this.cmbNoPlanIssueCD);
            this.panel6.Controls.Add(this.label13);
            this.panel6.Controls.Add(this.label14);
            this.panel6.Controls.Add(this.label15);
            this.panel6.Controls.Add(this.txtNoPlanStockOutQty);
            this.panel6.Controls.Add(this.label16);
            this.panel6.Controls.Add(this.dtpNoPlanStockOutDate);
            this.panel6.Controls.Add(this.lbNoPlanUser);
            this.panel6.Controls.Add(this.txtNoPlanUserCD);
            this.panel6.Controls.Add(this.label18);
            this.panel6.Controls.Add(this.lbNoPlanIssue);
            this.panel6.Controls.Add(this.label20);
            this.panel6.Controls.Add(this.lbNoPlanDestination);
            this.panel6.Controls.Add(this.cmbNoPlanDestinationCD);
            this.panel6.Controls.Add(this.txtBarcode);
            this.panel6.Controls.Add(this.label22);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(4, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(818, 220);
            this.panel6.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(270, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 36;
            this.label4.Text = "Invoice";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNoPlanInvoice
            // 
            this.txtNoPlanInvoice.Location = new System.Drawing.Point(340, 160);
            this.txtNoPlanInvoice.Name = "txtNoPlanInvoice";
            this.txtNoPlanInvoice.ReadOnly = true;
            this.txtNoPlanInvoice.Size = new System.Drawing.Size(130, 22);
            this.txtNoPlanInvoice.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(480, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "Comment";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNoPlanComment
            // 
            this.txtNoPlanComment.Location = new System.Drawing.Point(480, 70);
            this.txtNoPlanComment.Multiline = true;
            this.txtNoPlanComment.Name = "txtNoPlanComment";
            this.txtNoPlanComment.Size = new System.Drawing.Size(200, 140);
            this.txtNoPlanComment.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Item Code";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbNoPlanItem
            // 
            this.lbNoPlanItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbNoPlanItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbNoPlanItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoPlanItem.Location = new System.Drawing.Point(270, 40);
            this.lbNoPlanItem.Name = "lbNoPlanItem";
            this.lbNoPlanItem.Size = new System.Drawing.Size(200, 20);
            this.lbNoPlanItem.TabIndex = 31;
            this.lbNoPlanItem.Text = "Item Name";
            this.lbNoPlanItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNoPlanItemCD
            // 
            this.txtNoPlanItemCD.Location = new System.Drawing.Point(120, 40);
            this.txtNoPlanItemCD.Name = "txtNoPlanItemCD";
            this.txtNoPlanItemCD.ReadOnly = true;
            this.txtNoPlanItemCD.Size = new System.Drawing.Size(120, 22);
            this.txtNoPlanItemCD.TabIndex = 30;
            this.txtNoPlanItemCD.TextChanged += new System.EventHandler(this.txtItemCDStockOut_TextChanged);
            // 
            // cmbNoPlanIssueCD
            // 
            this.cmbNoPlanIssueCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNoPlanIssueCD.FormattingEnabled = true;
            this.cmbNoPlanIssueCD.Location = new System.Drawing.Point(120, 70);
            this.cmbNoPlanIssueCD.Name = "cmbNoPlanIssueCD";
            this.cmbNoPlanIssueCD.Size = new System.Drawing.Size(120, 24);
            this.cmbNoPlanIssueCD.TabIndex = 28;
            this.cmbNoPlanIssueCD.SelectedIndexChanged += new System.EventHandler(this.cmbIssueStockOut_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(10, 130);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 20);
            this.label13.TabIndex = 27;
            this.label13.Text = "User Code";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(10, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 20);
            this.label14.TabIndex = 26;
            this.label14.Text = "Barcode";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // txtNoPlanStockOutQty
            // 
            this.txtNoPlanStockOutQty.Location = new System.Drawing.Point(120, 190);
            this.txtNoPlanStockOutQty.Name = "txtNoPlanStockOutQty";
            this.txtNoPlanStockOutQty.ReadOnly = true;
            this.txtNoPlanStockOutQty.Size = new System.Drawing.Size(120, 22);
            this.txtNoPlanStockOutQty.TabIndex = 21;
            this.txtNoPlanStockOutQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoPlanStockOutQty_KeyPress);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(856, 40);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 20);
            this.label16.TabIndex = 18;
            this.label16.Text = "~";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpNoPlanStockOutDate
            // 
            this.dtpNoPlanStockOutDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNoPlanStockOutDate.Location = new System.Drawing.Point(120, 160);
            this.dtpNoPlanStockOutDate.Name = "dtpNoPlanStockOutDate";
            this.dtpNoPlanStockOutDate.Size = new System.Drawing.Size(120, 22);
            this.dtpNoPlanStockOutDate.TabIndex = 15;
            // 
            // lbNoPlanUser
            // 
            this.lbNoPlanUser.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbNoPlanUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbNoPlanUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoPlanUser.Location = new System.Drawing.Point(270, 130);
            this.lbNoPlanUser.Name = "lbNoPlanUser";
            this.lbNoPlanUser.Size = new System.Drawing.Size(200, 20);
            this.lbNoPlanUser.TabIndex = 10;
            this.lbNoPlanUser.Text = "User Name";
            this.lbNoPlanUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNoPlanUserCD
            // 
            this.txtNoPlanUserCD.Location = new System.Drawing.Point(120, 130);
            this.txtNoPlanUserCD.Name = "txtNoPlanUserCD";
            this.txtNoPlanUserCD.Size = new System.Drawing.Size(120, 22);
            this.txtNoPlanUserCD.TabIndex = 9;
            this.txtNoPlanUserCD.TextChanged += new System.EventHandler(this.txtStockOutUser_TextChanged);
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(10, 190);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 20);
            this.label18.TabIndex = 8;
            this.label18.Text = "Stock-Out Q\'ty";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbNoPlanIssue
            // 
            this.lbNoPlanIssue.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbNoPlanIssue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbNoPlanIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoPlanIssue.Location = new System.Drawing.Point(270, 70);
            this.lbNoPlanIssue.Name = "lbNoPlanIssue";
            this.lbNoPlanIssue.Size = new System.Drawing.Size(200, 20);
            this.lbNoPlanIssue.TabIndex = 7;
            this.lbNoPlanIssue.Text = "Issue Name";
            this.lbNoPlanIssue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // lbNoPlanDestination
            // 
            this.lbNoPlanDestination.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbNoPlanDestination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbNoPlanDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoPlanDestination.Location = new System.Drawing.Point(270, 100);
            this.lbNoPlanDestination.Name = "lbNoPlanDestination";
            this.lbNoPlanDestination.Size = new System.Drawing.Size(200, 20);
            this.lbNoPlanDestination.TabIndex = 4;
            this.lbNoPlanDestination.Text = "Destination Name";
            this.lbNoPlanDestination.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbNoPlanDestinationCD
            // 
            this.cmbNoPlanDestinationCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNoPlanDestinationCD.FormattingEnabled = true;
            this.cmbNoPlanDestinationCD.Location = new System.Drawing.Point(120, 100);
            this.cmbNoPlanDestinationCD.Name = "cmbNoPlanDestinationCD";
            this.cmbNoPlanDestinationCD.Size = new System.Drawing.Size(120, 24);
            this.cmbNoPlanDestinationCD.TabIndex = 2;
            this.cmbNoPlanDestinationCD.SelectedIndexChanged += new System.EventHandler(this.cmbDestinationStockOut_SelectedIndexChanged);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(120, 10);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(350, 22);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
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
            // tab_Plan
            // 
            this.tab_Plan.Controls.Add(this.panel4);
            this.tab_Plan.Location = new System.Drawing.Point(4, 28);
            this.tab_Plan.Margin = new System.Windows.Forms.Padding(4);
            this.tab_Plan.Name = "tab_Plan";
            this.tab_Plan.Padding = new System.Windows.Forms.Padding(4);
            this.tab_Plan.Size = new System.Drawing.Size(826, 516);
            this.tab_Plan.TabIndex = 1;
            this.tab_Plan.Text = "Plan";
            this.tab_Plan.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.rbtnDeliveryDate);
            this.panel4.Controls.Add(this.rbtnPlanDate);
            this.panel4.Controls.Add(this.rbtnNoCheckDate);
            this.panel4.Controls.Add(this.txtItemCD);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.dtpToDate);
            this.panel4.Controls.Add(this.dtpFromDate);
            this.panel4.Controls.Add(this.lbUserName);
            this.panel4.Controls.Add(this.txtUserCD);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.lbItemName);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.lbDestinationName);
            this.panel4.Controls.Add(this.cmbDestinationCD);
            this.panel4.Controls.Add(this.txtSetNumber);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(818, 200);
            this.panel4.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(10, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 20);
            this.label12.TabIndex = 27;
            this.label12.Text = "Destination";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(10, 160);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 20);
            this.label11.TabIndex = 26;
            this.label11.Text = "To Date";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(10, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 20);
            this.label7.TabIndex = 25;
            this.label7.Text = "From Date";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbtnDeliveryDate
            // 
            this.rbtnDeliveryDate.AutoSize = true;
            this.rbtnDeliveryDate.Location = new System.Drawing.Point(260, 160);
            this.rbtnDeliveryDate.Name = "rbtnDeliveryDate";
            this.rbtnDeliveryDate.Size = new System.Drawing.Size(108, 20);
            this.rbtnDeliveryDate.TabIndex = 14;
            this.rbtnDeliveryDate.TabStop = true;
            this.rbtnDeliveryDate.Text = "Delivery Date";
            this.rbtnDeliveryDate.UseVisualStyleBackColor = true;
            // 
            // rbtnPlanDate
            // 
            this.rbtnPlanDate.AutoSize = true;
            this.rbtnPlanDate.Location = new System.Drawing.Point(260, 130);
            this.rbtnPlanDate.Name = "rbtnPlanDate";
            this.rbtnPlanDate.Size = new System.Drawing.Size(140, 20);
            this.rbtnPlanDate.TabIndex = 13;
            this.rbtnPlanDate.TabStop = true;
            this.rbtnPlanDate.Text = "Plan/Request Date";
            this.rbtnPlanDate.UseVisualStyleBackColor = true;
            // 
            // rbtnNoCheckDate
            // 
            this.rbtnNoCheckDate.AutoSize = true;
            this.rbtnNoCheckDate.Location = new System.Drawing.Point(260, 100);
            this.rbtnNoCheckDate.Name = "rbtnNoCheckDate";
            this.rbtnNoCheckDate.Size = new System.Drawing.Size(117, 20);
            this.rbtnNoCheckDate.TabIndex = 22;
            this.rbtnNoCheckDate.TabStop = true;
            this.rbtnNoCheckDate.Text = "No Check Date";
            this.rbtnNoCheckDate.UseVisualStyleBackColor = true;
            // 
            // txtItemCD
            // 
            this.txtItemCD.Location = new System.Drawing.Point(120, 40);
            this.txtItemCD.Name = "txtItemCD";
            this.txtItemCD.Size = new System.Drawing.Size(120, 22);
            this.txtItemCD.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(856, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "~";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(120, 157);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(120, 22);
            this.dtpToDate.TabIndex = 17;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(120, 129);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(120, 22);
            this.dtpFromDate.TabIndex = 15;
            // 
            // lbUserName
            // 
            this.lbUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName.Location = new System.Drawing.Point(260, 10);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(200, 20);
            this.lbUserName.TabIndex = 10;
            this.lbUserName.Text = "User Name";
            this.lbUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUserCD
            // 
            this.txtUserCD.Location = new System.Drawing.Point(120, 10);
            this.txtUserCD.Name = "txtUserCD";
            this.txtUserCD.Size = new System.Drawing.Size(120, 22);
            this.txtUserCD.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(10, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 20);
            this.label10.TabIndex = 8;
            this.label10.Text = "User Code";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbItemName
            // 
            this.lbItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbItemName.Location = new System.Drawing.Point(260, 40);
            this.lbItemName.Name = "lbItemName";
            this.lbItemName.Size = new System.Drawing.Size(200, 20);
            this.lbItemName.TabIndex = 7;
            this.lbItemName.Text = "Item Name";
            this.lbItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(10, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 20);
            this.label9.TabIndex = 6;
            this.label9.Text = "Item Code";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbDestinationName
            // 
            this.lbDestinationName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDestinationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDestinationName.Location = new System.Drawing.Point(260, 70);
            this.lbDestinationName.Name = "lbDestinationName";
            this.lbDestinationName.Size = new System.Drawing.Size(200, 20);
            this.lbDestinationName.TabIndex = 4;
            this.lbDestinationName.Text = "Destination Name";
            this.lbDestinationName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbDestinationCD
            // 
            this.cmbDestinationCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDestinationCD.FormattingEnabled = true;
            this.cmbDestinationCD.Location = new System.Drawing.Point(120, 70);
            this.cmbDestinationCD.Name = "cmbDestinationCD";
            this.cmbDestinationCD.Size = new System.Drawing.Size(120, 24);
            this.cmbDestinationCD.TabIndex = 2;
            // 
            // txtSetNumber
            // 
            this.txtSetNumber.Location = new System.Drawing.Point(120, 100);
            this.txtSetNumber.Name = "txtSetNumber";
            this.txtSetNumber.Size = new System.Drawing.Size(120, 22);
            this.txtSetNumber.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Set Number";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tab_Request
            // 
            this.tab_Request.Controls.Add(this.dgvStockOut);
            this.tab_Request.Controls.Add(this.pnlButtons);
            this.tab_Request.Location = new System.Drawing.Point(4, 28);
            this.tab_Request.Margin = new System.Windows.Forms.Padding(4);
            this.tab_Request.Name = "tab_Request";
            this.tab_Request.Padding = new System.Windows.Forms.Padding(4);
            this.tab_Request.Size = new System.Drawing.Size(826, 516);
            this.tab_Request.TabIndex = 2;
            this.tab_Request.Text = "Request";
            this.tab_Request.UseVisualStyleBackColor = true;
            // 
            // dgvStockOut
            // 
            this.dgvStockOut.AllowUserToAddRows = false;
            this.dgvStockOut.AllowUserToDeleteRows = false;
            this.dgvStockOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStockOut.Location = new System.Drawing.Point(4, 66);
            this.dgvStockOut.Margin = new System.Windows.Forms.Padding(4);
            this.dgvStockOut.Name = "dgvStockOut";
            this.dgvStockOut.ReadOnly = true;
            this.dgvStockOut.Size = new System.Drawing.Size(818, 446);
            this.dgvStockOut.TabIndex = 23;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSearch);
            this.pnlButtons.Controls.Add(this.btnUpdate);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnAdd);
            this.pnlButtons.Controls.Add(this.btnClear);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtons.Location = new System.Drawing.Point(4, 4);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(4);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(818, 62);
            this.pnlButtons.TabIndex = 22;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(53, 6);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(107, 49);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(347, 6);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(107, 49);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(493, 6);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(107, 49);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(200, 6);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(107, 49);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(640, 6);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(107, 49);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // tab_PrintList
            // 
            this.tab_PrintList.Location = new System.Drawing.Point(4, 28);
            this.tab_PrintList.Margin = new System.Windows.Forms.Padding(4);
            this.tab_PrintList.Name = "tab_PrintList";
            this.tab_PrintList.Padding = new System.Windows.Forms.Padding(4);
            this.tab_PrintList.Size = new System.Drawing.Size(826, 516);
            this.tab_PrintList.TabIndex = 3;
            this.tab_PrintList.Text = "Print List";
            this.tab_PrintList.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(150, 596);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(834, 22);
            this.statusStrip1.TabIndex = 23;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(270, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 38;
            this.label5.Text = "Packing";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNoPlanPackingCD
            // 
            this.txtNoPlanPackingCD.Location = new System.Drawing.Point(340, 190);
            this.txtNoPlanPackingCD.Name = "txtNoPlanPackingCD";
            this.txtNoPlanPackingCD.ReadOnly = true;
            this.txtNoPlanPackingCD.Size = new System.Drawing.Size(130, 22);
            this.txtNoPlanPackingCD.TabIndex = 37;
            // 
            // StockOutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 618);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tc_Main);
            this.dept = "";
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listper = null;
            this.logintime = new System.DateTime(((long)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.name = "";
            this.Name = "StockOutForm";
            this.position = "";
            this.Text = "StockOutForm";
            this.tittle = "FormCommon";
            this.Load += new System.EventHandler(this.StockOutForm_Load);
            this.Controls.SetChildIndex(this.tc_Main, 0);
            this.Controls.SetChildIndex(this.statusStrip1, 0);
            this.tc_Main.ResumeLayout(false);
            this.tab_NoPlan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNoPlan)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tab_Plan.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tab_Request.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockOut)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tc_Main;
        private System.Windows.Forms.TabPage tab_NoPlan;
        private System.Windows.Forms.TabPage tab_Plan;
        private System.Windows.Forms.TabPage tab_Request;
        private System.Windows.Forms.DataGridView dgvStockOut;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TabPage tab_PrintList;
        private System.Windows.Forms.DataGridView dgvNoPlan;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cmbNoPlanIssueCD;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtNoPlanStockOutQty;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtpNoPlanStockOutDate;
        private System.Windows.Forms.Label lbNoPlanUser;
        private System.Windows.Forms.TextBox txtNoPlanUserCD;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lbNoPlanIssue;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lbNoPlanDestination;
        private System.Windows.Forms.ComboBox cmbNoPlanDestinationCD;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbtnDeliveryDate;
        private System.Windows.Forms.RadioButton rbtnPlanDate;
        private System.Windows.Forms.RadioButton rbtnNoCheckDate;
        private System.Windows.Forms.TextBox txtItemCD;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.TextBox txtUserCD;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbItemName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbDestinationName;
        private System.Windows.Forms.ComboBox cmbDestinationCD;
        private System.Windows.Forms.TextBox txtSetNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbNoPlanItem;
        private System.Windows.Forms.TextBox txtNoPlanItemCD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNoPlanComment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNoPlanInvoice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNoPlanPackingCD;
    }
}