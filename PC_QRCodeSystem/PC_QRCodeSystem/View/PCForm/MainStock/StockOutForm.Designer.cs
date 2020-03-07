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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tc_Main = new System.Windows.Forms.TabControl();
            this.tab_NoPlan = new System.Windows.Forms.TabPage();
            this.dgvNoPlan = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnNoPlanSearch = new System.Windows.Forms.Button();
            this.btnNoplanClear = new System.Windows.Forms.Button();
            this.btnNoPlanSetting = new System.Windows.Forms.Button();
            this.btnNoPlanInspection = new System.Windows.Forms.Button();
            this.btnNoPlanRegister = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cbSign = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNoPlanSetNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNoPlanWHQty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNoPlanInvoice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbNoPlanItem = new System.Windows.Forms.Label();
            this.txtNoPlanItemCD = new System.Windows.Forms.TextBox();
            this.cmbNoPlanIssueCD = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtNoPlanStockOutQty = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpNoPlanStockOutDate = new System.Windows.Forms.DateTimePicker();
            this.lbNoPlanUser = new System.Windows.Forms.Label();
            this.txtNoPlanUserCD = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbNoPlanDestinationCD = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtNoPlanComment = new System.Windows.Forms.TextBox();
            this.tab_Plan = new System.Windows.Forms.TabPage();
            this.dgvPlan = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPlanAddItem = new System.Windows.Forms.Button();
            this.btnPlanClear = new System.Windows.Forms.Button();
            this.btnPlanBack = new System.Windows.Forms.Button();
            this.btnPlanInspection = new System.Windows.Forms.Button();
            this.btnPlanReg = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lbPlanItem = new System.Windows.Forms.Label();
            this.txtPlanItemCD = new System.Windows.Forms.TextBox();
            this.tab_Request = new System.Windows.Forms.TabPage();
            this.dgvStockOut = new System.Windows.Forms.DataGridView();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.tab_Inspection = new System.Windows.Forms.TabPage();
            this.dgvPrintList = new System.Windows.Forms.DataGridView();
            this.dgvProcess = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnInspectionBack = new System.Windows.Forms.Button();
            this.btnPrintManual = new System.Windows.Forms.Button();
            this.btnInspectionClear = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnStockOutReg = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsRows = new System.Windows.Forms.ToolStripStatusLabel();
            this.tc_Main.SuspendLayout();
            this.tab_NoPlan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNoPlan)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tab_Plan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlan)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tab_Request.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockOut)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.tab_Inspection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrintList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcess)).BeginInit();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc_Main
            // 
            this.tc_Main.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tc_Main.Controls.Add(this.tab_NoPlan);
            this.tc_Main.Controls.Add(this.tab_Plan);
            this.tc_Main.Controls.Add(this.tab_Request);
            this.tc_Main.Controls.Add(this.tab_Inspection);
            this.tc_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_Main.Location = new System.Drawing.Point(150, 70);
            this.tc_Main.Margin = new System.Windows.Forms.Padding(4);
            this.tc_Main.Name = "tc_Main";
            this.tc_Main.SelectedIndex = 0;
            this.tc_Main.Size = new System.Drawing.Size(748, 526);
            this.tc_Main.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
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
            this.tab_NoPlan.Size = new System.Drawing.Size(740, 494);
            this.tab_NoPlan.TabIndex = 0;
            this.tab_NoPlan.Text = "No Planned";
            this.tab_NoPlan.UseVisualStyleBackColor = true;
            this.tab_NoPlan.Paint += new System.Windows.Forms.PaintEventHandler(this.tab_NoPlan_Paint);
            // 
            // dgvNoPlan
            // 
            this.dgvNoPlan.AllowUserToAddRows = false;
            this.dgvNoPlan.AllowUserToDeleteRows = false;
            this.dgvNoPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNoPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNoPlan.Location = new System.Drawing.Point(4, 284);
            this.dgvNoPlan.Margin = new System.Windows.Forms.Padding(4);
            this.dgvNoPlan.MultiSelect = false;
            this.dgvNoPlan.Name = "dgvNoPlan";
            this.dgvNoPlan.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNoPlan.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvNoPlan.Size = new System.Drawing.Size(732, 206);
            this.dgvNoPlan.TabIndex = 3;
            this.dgvNoPlan.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNoPlan_CellDoubleClick);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnNoPlanSearch);
            this.panel5.Controls.Add(this.btnNoplanClear);
            this.panel5.Controls.Add(this.btnNoPlanSetting);
            this.panel5.Controls.Add(this.btnNoPlanInspection);
            this.panel5.Controls.Add(this.btnNoPlanRegister);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(4, 224);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(732, 60);
            this.panel5.TabIndex = 2;
            // 
            // btnNoPlanSearch
            // 
            this.btnNoPlanSearch.Location = new System.Drawing.Point(50, 5);
            this.btnNoPlanSearch.Name = "btnNoPlanSearch";
            this.btnNoPlanSearch.Size = new System.Drawing.Size(80, 50);
            this.btnNoPlanSearch.TabIndex = 6;
            this.btnNoPlanSearch.Text = "Search";
            this.btnNoPlanSearch.UseVisualStyleBackColor = true;
            this.btnNoPlanSearch.Click += new System.EventHandler(this.btnNoPlanSearch_Click);
            // 
            // btnNoplanClear
            // 
            this.btnNoplanClear.Location = new System.Drawing.Point(570, 5);
            this.btnNoplanClear.Name = "btnNoplanClear";
            this.btnNoplanClear.Size = new System.Drawing.Size(80, 50);
            this.btnNoplanClear.TabIndex = 5;
            this.btnNoplanClear.Text = "Clear";
            this.btnNoplanClear.UseVisualStyleBackColor = true;
            this.btnNoplanClear.Click += new System.EventHandler(this.btnNoplanClear_Click);
            // 
            // btnNoPlanSetting
            // 
            this.btnNoPlanSetting.Location = new System.Drawing.Point(480, 5);
            this.btnNoPlanSetting.Name = "btnNoPlanSetting";
            this.btnNoPlanSetting.Size = new System.Drawing.Size(80, 50);
            this.btnNoPlanSetting.TabIndex = 4;
            this.btnNoPlanSetting.Text = "Setting";
            this.btnNoPlanSetting.UseVisualStyleBackColor = true;
            this.btnNoPlanSetting.Click += new System.EventHandler(this.btnNoPlanSetting_Click);
            // 
            // btnNoPlanInspection
            // 
            this.btnNoPlanInspection.Location = new System.Drawing.Point(390, 5);
            this.btnNoPlanInspection.Name = "btnNoPlanInspection";
            this.btnNoPlanInspection.Size = new System.Drawing.Size(80, 50);
            this.btnNoPlanInspection.TabIndex = 3;
            this.btnNoPlanInspection.Text = "Inspection";
            this.btnNoPlanInspection.UseVisualStyleBackColor = true;
            this.btnNoPlanInspection.Click += new System.EventHandler(this.btnNoPlanInspection_Click);
            // 
            // btnNoPlanRegister
            // 
            this.btnNoPlanRegister.Location = new System.Drawing.Point(140, 5);
            this.btnNoPlanRegister.Name = "btnNoPlanRegister";
            this.btnNoPlanRegister.Size = new System.Drawing.Size(80, 50);
            this.btnNoPlanRegister.TabIndex = 0;
            this.btnNoPlanRegister.Text = "Register";
            this.btnNoPlanRegister.UseVisualStyleBackColor = true;
            this.btnNoPlanRegister.Click += new System.EventHandler(this.btnNoPlanRegister_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cbSign);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.txtNoPlanSetNumber);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.txtNoPlanWHQty);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.txtNoPlanInvoice);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.lbNoPlanItem);
            this.panel6.Controls.Add(this.txtNoPlanItemCD);
            this.panel6.Controls.Add(this.cmbNoPlanIssueCD);
            this.panel6.Controls.Add(this.label13);
            this.panel6.Controls.Add(this.label15);
            this.panel6.Controls.Add(this.txtNoPlanStockOutQty);
            this.panel6.Controls.Add(this.label16);
            this.panel6.Controls.Add(this.dtpNoPlanStockOutDate);
            this.panel6.Controls.Add(this.lbNoPlanUser);
            this.panel6.Controls.Add(this.txtNoPlanUserCD);
            this.panel6.Controls.Add(this.label18);
            this.panel6.Controls.Add(this.label20);
            this.panel6.Controls.Add(this.cmbNoPlanDestinationCD);
            this.panel6.Controls.Add(this.label22);
            this.panel6.Controls.Add(this.txtNoPlanComment);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(4, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(732, 220);
            this.panel6.TabIndex = 1;
            // 
            // cbSign
            // 
            this.cbSign.AutoSize = true;
            this.cbSign.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cbSign.Location = new System.Drawing.Point(270, 130);
            this.cbSign.Name = "cbSign";
            this.cbSign.Size = new System.Drawing.Size(54, 20);
            this.cbSign.TabIndex = 41;
            this.cbSign.Text = "Sign";
            this.cbSign.UseVisualStyleBackColor = false;
            this.cbSign.CheckedChanged += new System.EventHandler(this.cbSign_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(480, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.TabIndex = 40;
            this.label6.Text = "Set Number";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNoPlanSetNumber
            // 
            this.txtNoPlanSetNumber.Location = new System.Drawing.Point(590, 10);
            this.txtNoPlanSetNumber.Name = "txtNoPlanSetNumber";
            this.txtNoPlanSetNumber.Size = new System.Drawing.Size(120, 22);
            this.txtNoPlanSetNumber.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(480, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 38;
            this.label5.Text = "W/H Qty";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNoPlanWHQty
            // 
            this.txtNoPlanWHQty.Location = new System.Drawing.Point(590, 100);
            this.txtNoPlanWHQty.Name = "txtNoPlanWHQty";
            this.txtNoPlanWHQty.ReadOnly = true;
            this.txtNoPlanWHQty.Size = new System.Drawing.Size(120, 22);
            this.txtNoPlanWHQty.TabIndex = 37;
            this.txtNoPlanWHQty.TabStop = false;
            this.txtNoPlanWHQty.Text = "0";
            this.txtNoPlanWHQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(480, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 36;
            this.label4.Text = "Invoice";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNoPlanInvoice
            // 
            this.txtNoPlanInvoice.Location = new System.Drawing.Point(590, 70);
            this.txtNoPlanInvoice.Name = "txtNoPlanInvoice";
            this.txtNoPlanInvoice.ReadOnly = true;
            this.txtNoPlanInvoice.Size = new System.Drawing.Size(120, 22);
            this.txtNoPlanInvoice.TabIndex = 35;
            this.txtNoPlanInvoice.TabStop = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "Comment";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 100);
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
            this.lbNoPlanItem.Location = new System.Drawing.Point(270, 100);
            this.lbNoPlanItem.Name = "lbNoPlanItem";
            this.lbNoPlanItem.Size = new System.Drawing.Size(200, 20);
            this.lbNoPlanItem.TabIndex = 31;
            this.lbNoPlanItem.Text = "Item Name";
            this.lbNoPlanItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNoPlanItemCD
            // 
            this.txtNoPlanItemCD.Location = new System.Drawing.Point(120, 100);
            this.txtNoPlanItemCD.Name = "txtNoPlanItemCD";
            this.txtNoPlanItemCD.Size = new System.Drawing.Size(120, 22);
            this.txtNoPlanItemCD.TabIndex = 30;
            this.txtNoPlanItemCD.TabStop = false;
            this.txtNoPlanItemCD.TextChanged += new System.EventHandler(this.txtItemCDStockOut_TextChanged);
            // 
            // cmbNoPlanIssueCD
            // 
            this.cmbNoPlanIssueCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNoPlanIssueCD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNoPlanIssueCD.FormattingEnabled = true;
            this.cmbNoPlanIssueCD.Location = new System.Drawing.Point(120, 10);
            this.cmbNoPlanIssueCD.Name = "cmbNoPlanIssueCD";
            this.cmbNoPlanIssueCD.Size = new System.Drawing.Size(350, 24);
            this.cmbNoPlanIssueCD.TabIndex = 5;
            this.cmbNoPlanIssueCD.SelectedIndexChanged += new System.EventHandler(this.cmbNoPlanIssueCD_SelectedIndexChanged);
            this.cmbNoPlanIssueCD.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbNoPlanIssueCD_Format);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(10, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 20);
            this.label13.TabIndex = 27;
            this.label13.Text = "User Code";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(480, 40);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 20);
            this.label15.TabIndex = 25;
            this.label15.Text = "Stock-Out Date";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNoPlanStockOutQty
            // 
            this.txtNoPlanStockOutQty.Location = new System.Drawing.Point(120, 130);
            this.txtNoPlanStockOutQty.Name = "txtNoPlanStockOutQty";
            this.txtNoPlanStockOutQty.Size = new System.Drawing.Size(120, 22);
            this.txtNoPlanStockOutQty.TabIndex = 9;
            this.txtNoPlanStockOutQty.Text = "0";
            this.txtNoPlanStockOutQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.dtpNoPlanStockOutDate.CustomFormat = "yyyy-MM-dd";
            this.dtpNoPlanStockOutDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNoPlanStockOutDate.Location = new System.Drawing.Point(590, 40);
            this.dtpNoPlanStockOutDate.Name = "dtpNoPlanStockOutDate";
            this.dtpNoPlanStockOutDate.Size = new System.Drawing.Size(120, 22);
            this.dtpNoPlanStockOutDate.TabIndex = 8;
            this.dtpNoPlanStockOutDate.Value = new System.DateTime(2020, 3, 7, 0, 0, 0, 0);
            // 
            // lbNoPlanUser
            // 
            this.lbNoPlanUser.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbNoPlanUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbNoPlanUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoPlanUser.Location = new System.Drawing.Point(270, 70);
            this.lbNoPlanUser.Name = "lbNoPlanUser";
            this.lbNoPlanUser.Size = new System.Drawing.Size(200, 20);
            this.lbNoPlanUser.TabIndex = 10;
            this.lbNoPlanUser.Text = "User Name";
            this.lbNoPlanUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNoPlanUserCD
            // 
            this.txtNoPlanUserCD.Location = new System.Drawing.Point(120, 70);
            this.txtNoPlanUserCD.Name = "txtNoPlanUserCD";
            this.txtNoPlanUserCD.Size = new System.Drawing.Size(120, 22);
            this.txtNoPlanUserCD.TabIndex = 7;
            this.txtNoPlanUserCD.TextChanged += new System.EventHandler(this.txtStockOutUser_TextChanged);
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
            this.label20.Location = new System.Drawing.Point(10, 10);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(100, 20);
            this.label20.TabIndex = 6;
            this.label20.Text = "Issue Code";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbNoPlanDestinationCD
            // 
            this.cmbNoPlanDestinationCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNoPlanDestinationCD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNoPlanDestinationCD.FormattingEnabled = true;
            this.cmbNoPlanDestinationCD.Location = new System.Drawing.Point(120, 40);
            this.cmbNoPlanDestinationCD.Name = "cmbNoPlanDestinationCD";
            this.cmbNoPlanDestinationCD.Size = new System.Drawing.Size(350, 24);
            this.cmbNoPlanDestinationCD.TabIndex = 6;
            this.cmbNoPlanDestinationCD.SelectedIndexChanged += new System.EventHandler(this.cmbNoPlanDestinationCD_SelectedIndexChanged);
            this.cmbNoPlanDestinationCD.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbNoPlanDestinationCD_Format);
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(10, 40);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(100, 20);
            this.label22.TabIndex = 0;
            this.label22.Text = "Destination";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNoPlanComment
            // 
            this.txtNoPlanComment.Location = new System.Drawing.Point(120, 160);
            this.txtNoPlanComment.Multiline = true;
            this.txtNoPlanComment.Name = "txtNoPlanComment";
            this.txtNoPlanComment.Size = new System.Drawing.Size(350, 50);
            this.txtNoPlanComment.TabIndex = 11;
            // 
            // tab_Plan
            // 
            this.tab_Plan.Controls.Add(this.dgvPlan);
            this.tab_Plan.Controls.Add(this.panel2);
            this.tab_Plan.Controls.Add(this.panel3);
            this.tab_Plan.Location = new System.Drawing.Point(4, 28);
            this.tab_Plan.Margin = new System.Windows.Forms.Padding(4);
            this.tab_Plan.Name = "tab_Plan";
            this.tab_Plan.Padding = new System.Windows.Forms.Padding(4);
            this.tab_Plan.Size = new System.Drawing.Size(740, 494);
            this.tab_Plan.TabIndex = 1;
            this.tab_Plan.Text = "Plan";
            this.tab_Plan.UseVisualStyleBackColor = true;
            // 
            // dgvPlan
            // 
            this.dgvPlan.AllowUserToAddRows = false;
            this.dgvPlan.AllowUserToDeleteRows = false;
            this.dgvPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlan.Location = new System.Drawing.Point(4, 116);
            this.dgvPlan.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPlan.MultiSelect = false;
            this.dgvPlan.Name = "dgvPlan";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlan.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPlan.Size = new System.Drawing.Size(732, 374);
            this.dgvPlan.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnPlanAddItem);
            this.panel2.Controls.Add(this.btnPlanClear);
            this.panel2.Controls.Add(this.btnPlanBack);
            this.panel2.Controls.Add(this.btnPlanInspection);
            this.panel2.Controls.Add(this.btnPlanReg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(4, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(732, 60);
            this.panel2.TabIndex = 5;
            // 
            // btnPlanAddItem
            // 
            this.btnPlanAddItem.Location = new System.Drawing.Point(50, 5);
            this.btnPlanAddItem.Name = "btnPlanAddItem";
            this.btnPlanAddItem.Size = new System.Drawing.Size(80, 50);
            this.btnPlanAddItem.TabIndex = 6;
            this.btnPlanAddItem.Text = "Add Item ";
            this.btnPlanAddItem.UseVisualStyleBackColor = true;
            this.btnPlanAddItem.Click += new System.EventHandler(this.btnPlanAddItem_Click);
            // 
            // btnPlanClear
            // 
            this.btnPlanClear.Location = new System.Drawing.Point(500, 5);
            this.btnPlanClear.Name = "btnPlanClear";
            this.btnPlanClear.Size = new System.Drawing.Size(80, 50);
            this.btnPlanClear.TabIndex = 5;
            this.btnPlanClear.Text = "Clear";
            this.btnPlanClear.UseVisualStyleBackColor = true;
            this.btnPlanClear.Click += new System.EventHandler(this.btnPlanClear_Click);
            // 
            // btnPlanBack
            // 
            this.btnPlanBack.Location = new System.Drawing.Point(600, 5);
            this.btnPlanBack.Name = "btnPlanBack";
            this.btnPlanBack.Size = new System.Drawing.Size(80, 50);
            this.btnPlanBack.TabIndex = 4;
            this.btnPlanBack.Text = "Back";
            this.btnPlanBack.UseVisualStyleBackColor = true;
            this.btnPlanBack.Click += new System.EventHandler(this.btnInspectionBack_Click);
            // 
            // btnPlanInspection
            // 
            this.btnPlanInspection.Location = new System.Drawing.Point(390, 5);
            this.btnPlanInspection.Name = "btnPlanInspection";
            this.btnPlanInspection.Size = new System.Drawing.Size(80, 50);
            this.btnPlanInspection.TabIndex = 3;
            this.btnPlanInspection.Text = "Inspection";
            this.btnPlanInspection.UseVisualStyleBackColor = true;
            this.btnPlanInspection.Click += new System.EventHandler(this.btnNoPlanInspection_Click);
            // 
            // btnPlanReg
            // 
            this.btnPlanReg.Location = new System.Drawing.Point(140, 5);
            this.btnPlanReg.Name = "btnPlanReg";
            this.btnPlanReg.Size = new System.Drawing.Size(80, 50);
            this.btnPlanReg.TabIndex = 0;
            this.btnPlanReg.Text = "Register";
            this.btnPlanReg.UseVisualStyleBackColor = true;
            this.btnPlanReg.Click += new System.EventHandler(this.btnPlanReg_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.lbPlanItem);
            this.panel3.Controls.Add(this.txtPlanItemCD);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(732, 52);
            this.panel3.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(10, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 20);
            this.label12.TabIndex = 27;
            this.label12.Text = "Item Code";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(856, 40);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(50, 20);
            this.label17.TabIndex = 18;
            this.label17.Text = "~";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPlanItem
            // 
            this.lbPlanItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbPlanItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPlanItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlanItem.Location = new System.Drawing.Point(270, 10);
            this.lbPlanItem.Name = "lbPlanItem";
            this.lbPlanItem.Size = new System.Drawing.Size(200, 20);
            this.lbPlanItem.TabIndex = 10;
            this.lbPlanItem.Text = "Item Name";
            this.lbPlanItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPlanItemCD
            // 
            this.txtPlanItemCD.Location = new System.Drawing.Point(120, 10);
            this.txtPlanItemCD.Name = "txtPlanItemCD";
            this.txtPlanItemCD.Size = new System.Drawing.Size(120, 22);
            this.txtPlanItemCD.TabIndex = 7;
            this.txtPlanItemCD.TextChanged += new System.EventHandler(this.txtItemCDStockOut_TextChanged);
            // 
            // tab_Request
            // 
            this.tab_Request.Controls.Add(this.dgvStockOut);
            this.tab_Request.Controls.Add(this.pnlButtons);
            this.tab_Request.Location = new System.Drawing.Point(4, 28);
            this.tab_Request.Margin = new System.Windows.Forms.Padding(4);
            this.tab_Request.Name = "tab_Request";
            this.tab_Request.Padding = new System.Windows.Forms.Padding(4);
            this.tab_Request.Size = new System.Drawing.Size(740, 494);
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
            this.dgvStockOut.Size = new System.Drawing.Size(732, 424);
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
            this.pnlButtons.Size = new System.Drawing.Size(732, 62);
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
            // tab_Inspection
            // 
            this.tab_Inspection.Controls.Add(this.dgvPrintList);
            this.tab_Inspection.Controls.Add(this.dgvProcess);
            this.tab_Inspection.Controls.Add(this.panel1);
            this.tab_Inspection.Location = new System.Drawing.Point(4, 28);
            this.tab_Inspection.Margin = new System.Windows.Forms.Padding(4);
            this.tab_Inspection.Name = "tab_Inspection";
            this.tab_Inspection.Padding = new System.Windows.Forms.Padding(4);
            this.tab_Inspection.Size = new System.Drawing.Size(740, 494);
            this.tab_Inspection.TabIndex = 3;
            this.tab_Inspection.Text = "Inspection";
            this.tab_Inspection.UseVisualStyleBackColor = true;
            // 
            // dgvPrintList
            // 
            this.dgvPrintList.AllowUserToAddRows = false;
            this.dgvPrintList.AllowUserToDeleteRows = false;
            this.dgvPrintList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrintList.Location = new System.Drawing.Point(4, 144);
            this.dgvPrintList.Name = "dgvPrintList";
            this.dgvPrintList.ReadOnly = true;
            this.dgvPrintList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvPrintList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrintList.Size = new System.Drawing.Size(732, 346);
            this.dgvPrintList.TabIndex = 3;
            // 
            // dgvProcess
            // 
            this.dgvProcess.AllowUserToAddRows = false;
            this.dgvProcess.AllowUserToDeleteRows = false;
            this.dgvProcess.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvProcess.Location = new System.Drawing.Point(4, 64);
            this.dgvProcess.Name = "dgvProcess";
            this.dgvProcess.ReadOnly = true;
            this.dgvProcess.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvProcess.Size = new System.Drawing.Size(732, 80);
            this.dgvProcess.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnInspectionBack);
            this.panel1.Controls.Add(this.btnPrintManual);
            this.panel1.Controls.Add(this.btnInspectionClear);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnStockOutReg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(732, 60);
            this.panel1.TabIndex = 1;
            // 
            // btnInspectionBack
            // 
            this.btnInspectionBack.Location = new System.Drawing.Point(578, 5);
            this.btnInspectionBack.Name = "btnInspectionBack";
            this.btnInspectionBack.Size = new System.Drawing.Size(80, 50);
            this.btnInspectionBack.TabIndex = 8;
            this.btnInspectionBack.Text = "Back";
            this.btnInspectionBack.UseVisualStyleBackColor = true;
            this.btnInspectionBack.Click += new System.EventHandler(this.btnInspectionBack_Click);
            // 
            // btnPrintManual
            // 
            this.btnPrintManual.Location = new System.Drawing.Point(314, 5);
            this.btnPrintManual.Name = "btnPrintManual";
            this.btnPrintManual.Size = new System.Drawing.Size(80, 50);
            this.btnPrintManual.TabIndex = 6;
            this.btnPrintManual.Text = "Print Manual";
            this.btnPrintManual.UseVisualStyleBackColor = true;
            this.btnPrintManual.Click += new System.EventHandler(this.btnPrintManual_Click);
            // 
            // btnInspectionClear
            // 
            this.btnInspectionClear.Location = new System.Drawing.Point(446, 5);
            this.btnInspectionClear.Name = "btnInspectionClear";
            this.btnInspectionClear.Size = new System.Drawing.Size(80, 50);
            this.btnInspectionClear.TabIndex = 7;
            this.btnInspectionClear.Text = "Clear";
            this.btnInspectionClear.UseVisualStyleBackColor = true;
            this.btnInspectionClear.Click += new System.EventHandler(this.btnInspectionClear_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(182, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 50);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "Print All";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnStockOutReg
            // 
            this.btnStockOutReg.Location = new System.Drawing.Point(50, 5);
            this.btnStockOutReg.Name = "btnStockOutReg";
            this.btnStockOutReg.Size = new System.Drawing.Size(80, 50);
            this.btnStockOutReg.TabIndex = 4;
            this.btnStockOutReg.Text = "Stock-Out Register";
            this.btnStockOutReg.UseVisualStyleBackColor = true;
            this.btnStockOutReg.Click += new System.EventHandler(this.btnStockOutReg_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.tsRows});
            this.statusStrip1.Location = new System.Drawing.Point(150, 596);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(748, 22);
            this.statusStrip1.TabIndex = 23;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(656, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(41, 17);
            this.toolStripStatusLabel2.Text = "Rows :";
            // 
            // tsRows
            // 
            this.tsRows.Name = "tsRows";
            this.tsRows.Size = new System.Drawing.Size(36, 17);
            this.tsRows.Text = "None";
            // 
            // StockOutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 618);
            this.Controls.Add(this.tc_Main);
            this.Controls.Add(this.statusStrip1);
            this.dept = "";
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listper = null;
            this.logintime = new System.DateTime(((long)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.name = "";
            this.Name = "StockOutForm";
            this.position = "";
            this.Text = "Stock Out";
            this.tittle = "FormCommon";
            this.Load += new System.EventHandler(this.StockOutForm_Load);
            this.Controls.SetChildIndex(this.statusStrip1, 0);
            this.Controls.SetChildIndex(this.tc_Main, 0);
            this.tc_Main.ResumeLayout(false);
            this.tab_NoPlan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNoPlan)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tab_Plan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlan)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tab_Request.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockOut)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.tab_Inspection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrintList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcess)).EndInit();
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tab_Inspection;
        private System.Windows.Forms.DataGridView dgvNoPlan;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnNoplanClear;
        private System.Windows.Forms.Button btnNoPlanSetting;
        private System.Windows.Forms.Button btnNoPlanInspection;
        private System.Windows.Forms.Button btnNoPlanRegister;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cmbNoPlanIssueCD;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtNoPlanStockOutQty;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtpNoPlanStockOutDate;
        private System.Windows.Forms.Label lbNoPlanUser;
        private System.Windows.Forms.TextBox txtNoPlanUserCD;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbNoPlanDestinationCD;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbNoPlanItem;
        private System.Windows.Forms.TextBox txtNoPlanItemCD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNoPlanComment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNoPlanInvoice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNoPlanWHQty;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsRows;
        private System.Windows.Forms.DataGridView dgvProcess;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnInspectionClear;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnStockOutReg;
        private System.Windows.Forms.Button btnPrintManual;
        private System.Windows.Forms.Button btnInspectionBack;
        private System.Windows.Forms.DataGridView dgvPrintList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNoPlanSetNumber;
        private System.Windows.Forms.CheckBox cbSign;
        private System.Windows.Forms.Button btnNoPlanSearch;
        private System.Windows.Forms.DataGridView dgvPlan;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPlanAddItem;
        private System.Windows.Forms.Button btnPlanClear;
        private System.Windows.Forms.Button btnPlanBack;
        private System.Windows.Forms.Button btnPlanInspection;
        private System.Windows.Forms.Button btnPlanReg;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbPlanItem;
        private System.Windows.Forms.TextBox txtPlanItemCD;
    }
}