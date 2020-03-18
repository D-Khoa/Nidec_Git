namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.IPQCForm
{
    partial class Scale
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scale));
            this.dgvBuffer = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUsl = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLsl = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.cmbPortName = new System.Windows.Forms.ComboBox();
            this.dtpLotTo = new System.Windows.Forms.DateTimePicker();
            this.dtpLotFrom = new System.Windows.Forms.DateTimePicker();
            this.txtInspect = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpLotInput = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnZero = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtProcess = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbLine = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.inspect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inspectdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qc_user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.r = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExport = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.btnSearch = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.btnRegister = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.btnMeasure = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.btnDelete = new Com.Nidec.Mes.Framework.ButtonCommon();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuffer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBuffer
            // 
            this.dgvBuffer.AllowUserToAddRows = false;
            this.dgvBuffer.AllowUserToDeleteRows = false;
            this.dgvBuffer.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvBuffer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuffer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBuffer.Location = new System.Drawing.Point(0, 0);
            this.dgvBuffer.Name = "dgvBuffer";
            this.dgvBuffer.ReadOnly = true;
            this.dgvBuffer.RowTemplate.Height = 21;
            this.dgvBuffer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvBuffer.Size = new System.Drawing.Size(922, 145);
            this.dgvBuffer.TabIndex = 10;
            this.dgvBuffer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBuffer_CellContentClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(762, 166);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 24);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(551, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "USL: ";
            // 
            // txtUsl
            // 
            this.txtUsl.Enabled = false;
            this.txtUsl.Location = new System.Drawing.Point(597, 139);
            this.txtUsl.Name = "txtUsl";
            this.txtUsl.Size = new System.Drawing.Size(83, 20);
            this.txtUsl.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(551, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "LSL: ";
            // 
            // txtLsl
            // 
            this.txtLsl.Enabled = false;
            this.txtLsl.Location = new System.Drawing.Point(597, 113);
            this.txtLsl.Name = "txtLsl";
            this.txtLsl.Size = new System.Drawing.Size(83, 20);
            this.txtLsl.TabIndex = 16;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(710, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Com Port";
            // 
            // cmbPortName
            // 
            this.cmbPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPortName.FormattingEnabled = true;
            this.cmbPortName.Location = new System.Drawing.Point(781, 137);
            this.cmbPortName.Name = "cmbPortName";
            this.cmbPortName.Size = new System.Drawing.Size(83, 21);
            this.cmbPortName.TabIndex = 24;
            this.cmbPortName.SelectedIndexChanged += new System.EventHandler(this.cmbPortName_SelectedIndexChanged);
            // 
            // dtpLotTo
            // 
            this.dtpLotTo.CustomFormat = "yyyy/MM/dd HH:mm";
            this.dtpLotTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLotTo.Location = new System.Drawing.Point(237, 139);
            this.dtpLotTo.Name = "dtpLotTo";
            this.dtpLotTo.ShowUpDown = true;
            this.dtpLotTo.Size = new System.Drawing.Size(120, 20);
            this.dtpLotTo.TabIndex = 37;
            // 
            // dtpLotFrom
            // 
            this.dtpLotFrom.CustomFormat = "yyyy/MM/dd HH:mm";
            this.dtpLotFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLotFrom.Location = new System.Drawing.Point(78, 139);
            this.dtpLotFrom.Name = "dtpLotFrom";
            this.dtpLotFrom.ShowUpDown = true;
            this.dtpLotFrom.Size = new System.Drawing.Size(120, 20);
            this.dtpLotFrom.TabIndex = 38;
            // 
            // txtInspect
            // 
            this.txtInspect.Enabled = false;
            this.txtInspect.Location = new System.Drawing.Point(435, 113);
            this.txtInspect.Name = "txtInspect";
            this.txtInspect.Size = new System.Drawing.Size(83, 20);
            this.txtInspect.TabIndex = 26;
            // 
            // txtUser
            // 
            this.txtUser.Enabled = false;
            this.txtUser.Location = new System.Drawing.Point(781, 113);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(83, 20);
            this.txtUser.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Line: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(710, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "User: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "to: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "from: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(381, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Inspect: ";
            // 
            // dtpLotInput
            // 
            this.dtpLotInput.CustomFormat = "yyyy/MM/dd HH:mm";
            this.dtpLotInput.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLotInput.Location = new System.Drawing.Point(78, 169);
            this.dtpLotInput.Name = "dtpLotInput";
            this.dtpLotInput.ShowUpDown = true;
            this.dtpLotInput.Size = new System.Drawing.Size(120, 20);
            this.dtpLotInput.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "input: ";
            // 
            // btnZero
            // 
            this.btnZero.Location = new System.Drawing.Point(520, 166);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(44, 24);
            this.btnZero.TabIndex = 12;
            this.btnZero.Text = "Zero";
            this.btnZero.UseVisualStyleBackColor = true;
            this.btnZero.Click += new System.EventHandler(this.btnZero_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 173);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "Lot: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Lot: ";
            // 
            // txtModel
            // 
            this.txtModel.Enabled = false;
            this.txtModel.Location = new System.Drawing.Point(78, 113);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(83, 20);
            this.txtModel.TabIndex = 42;
            // 
            // txtProcess
            // 
            this.txtProcess.Enabled = false;
            this.txtProcess.Location = new System.Drawing.Point(255, 113);
            this.txtProcess.Name = "txtProcess";
            this.txtProcess.Size = new System.Drawing.Size(83, 20);
            this.txtProcess.TabIndex = 43;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 116);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 44;
            this.label13.Text = "Model: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(201, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 45;
            this.label11.Text = "Process: ";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(78, 196);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(249, 20);
            this.txtStatus.TabIndex = 48;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 199);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 13);
            this.label14.TabIndex = 47;
            this.label14.Text = "Status";
            // 
            // cmbLine
            // 
            this.cmbLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLine.FormattingEnabled = true;
            this.cmbLine.Location = new System.Drawing.Point(435, 139);
            this.cmbLine.Name = "cmbLine";
            this.cmbLine.Size = new System.Drawing.Size(83, 21);
            this.cmbLine.TabIndex = 49;
            this.cmbLine.SelectedIndexChanged += new System.EventHandler(this.cmbLine_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.Location = new System.Drawing.Point(0, 225);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvBuffer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvHistory);
            this.splitContainer1.Size = new System.Drawing.Size(922, 518);
            this.splitContainer1.SplitterDistance = 145;
            this.splitContainer1.TabIndex = 50;
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.AllowUserToResizeColumns = false;
            this.dgvHistory.AllowUserToResizeRows = false;
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvHistory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.inspect,
            this.lot,
            this.inspectdate,
            this.line,
            this.qc_user,
            this.status,
            this.m1,
            this.m2,
            this.m3,
            this.m4,
            this.m5,
            this.x,
            this.r});
            this.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistory.Location = new System.Drawing.Point(0, 0);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowTemplate.Height = 21;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvHistory.Size = new System.Drawing.Size(922, 369);
            this.dgvHistory.TabIndex = 12;
            this.dgvHistory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistory_CellContentClick);
            // 
            // inspect
            // 
            this.inspect.DataPropertyName = "Inspect";
            this.inspect.HeaderText = "Inspect";
            this.inspect.Name = "inspect";
            this.inspect.ReadOnly = true;
            this.inspect.Width = 67;
            // 
            // lot
            // 
            this.lot.DataPropertyName = "Lot";
            this.lot.HeaderText = "Lot";
            this.lot.Name = "lot";
            this.lot.ReadOnly = true;
            this.lot.Width = 47;
            // 
            // inspectdate
            // 
            this.inspectdate.DataPropertyName = "Inspectdate";
            this.inspectdate.HeaderText = "Inspectdate";
            this.inspectdate.Name = "inspectdate";
            this.inspectdate.ReadOnly = true;
            this.inspectdate.Width = 88;
            // 
            // line
            // 
            this.line.DataPropertyName = "Line";
            this.line.HeaderText = "Line";
            this.line.Name = "line";
            this.line.ReadOnly = true;
            this.line.Width = 52;
            // 
            // qc_user
            // 
            this.qc_user.DataPropertyName = "qc_user";
            this.qc_user.HeaderText = "User";
            this.qc_user.Name = "qc_user";
            this.qc_user.ReadOnly = true;
            this.qc_user.Width = 54;
            // 
            // status
            // 
            this.status.DataPropertyName = "Status";
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 62;
            // 
            // m1
            // 
            this.m1.DataPropertyName = "m1";
            this.m1.HeaderText = "m1";
            this.m1.Name = "m1";
            this.m1.ReadOnly = true;
            this.m1.Width = 46;
            // 
            // m2
            // 
            this.m2.DataPropertyName = "m2";
            this.m2.HeaderText = "m2";
            this.m2.Name = "m2";
            this.m2.ReadOnly = true;
            this.m2.Width = 46;
            // 
            // m3
            // 
            this.m3.DataPropertyName = "m3";
            this.m3.HeaderText = "m3";
            this.m3.Name = "m3";
            this.m3.ReadOnly = true;
            this.m3.Width = 46;
            // 
            // m4
            // 
            this.m4.DataPropertyName = "m4";
            this.m4.HeaderText = "m4";
            this.m4.Name = "m4";
            this.m4.ReadOnly = true;
            this.m4.Width = 46;
            // 
            // m5
            // 
            this.m5.DataPropertyName = "m5";
            this.m5.HeaderText = "m5";
            this.m5.Name = "m5";
            this.m5.ReadOnly = true;
            this.m5.Width = 46;
            // 
            // x
            // 
            this.x.DataPropertyName = "x";
            this.x.HeaderText = "x";
            this.x.Name = "x";
            this.x.ReadOnly = true;
            this.x.Width = 37;
            // 
            // r
            // 
            this.r.DataPropertyName = "r";
            this.r.HeaderText = "r";
            this.r.Name = "r";
            this.r.ReadOnly = true;
            this.r.Width = 35;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.SystemColors.Control;
            this.btnExport.ControlId = "cbis005";
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnExport.Location = new System.Drawing.Point(666, 166);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(90, 24);
            this.btnExport.TabIndex = 66;
            this.btnExport.Text = "Excel Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearch.ControlId = "cbis004";
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSearch.Location = new System.Drawing.Point(570, 166);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 24);
            this.btnSearch.TabIndex = 65;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.SystemColors.Control;
            this.btnRegister.ControlId = "cbis003";
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnRegister.Location = new System.Drawing.Point(424, 166);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(90, 24);
            this.btnRegister.TabIndex = 64;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnMeasure
            // 
            this.btnMeasure.BackColor = System.Drawing.SystemColors.Control;
            this.btnMeasure.ControlId = "cbis002";
            this.btnMeasure.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMeasure.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnMeasure.Location = new System.Drawing.Point(328, 166);
            this.btnMeasure.Name = "btnMeasure";
            this.btnMeasure.Size = new System.Drawing.Size(90, 24);
            this.btnMeasure.TabIndex = 63;
            this.btnMeasure.Text = "Measure New";
            this.btnMeasure.UseVisualStyleBackColor = false;
            this.btnMeasure.Click += new System.EventHandler(this.btnMeasure_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.ControlId = "cbis001";
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnDelete.Location = new System.Drawing.Point(232, 166);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 24);
            this.btnDelete.TabIndex = 62;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Scale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(922, 743);
            this.ControlId = "fsca001";
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnMeasure);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cmbLine);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.txtProcess);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dtpLotTo);
            this.Controls.Add(this.dtpLotInput);
            this.Controls.Add(this.dtpLotFrom);
            this.Controls.Add(this.txtInspect);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbPortName);
            this.Controls.Add(this.txtLsl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUsl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnZero);
            this.Controls.Add(this.btnCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Scale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Measurement Data Scale";
            this.TitleText = "SCALE";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmScale_FormClosed);
            this.Load += new System.EventHandler(this.frmScale_Load);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnZero, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtUsl, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtLsl, 0);
            this.Controls.SetChildIndex(this.cmbPortName, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtUser, 0);
            this.Controls.SetChildIndex(this.txtInspect, 0);
            this.Controls.SetChildIndex(this.dtpLotFrom, 0);
            this.Controls.SetChildIndex(this.dtpLotInput, 0);
            this.Controls.SetChildIndex(this.dtpLotTo, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.txtProcess, 0);
            this.Controls.SetChildIndex(this.txtModel, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.cmbLine, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnMeasure, 0);
            this.Controls.SetChildIndex(this.btnRegister, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.btnExport, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuffer)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBuffer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUsl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLsl;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbPortName;
        private System.Windows.Forms.DateTimePicker dtpLotTo;
        private System.Windows.Forms.DateTimePicker dtpLotFrom;
        private System.Windows.Forms.TextBox txtInspect;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpLotInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnZero;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtProcess;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbLine;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Framework.ButtonCommon btnExport;
        private Framework.ButtonCommon btnSearch;
        private Framework.ButtonCommon btnRegister;
        private Framework.ButtonCommon btnMeasure;
        private Framework.ButtonCommon btnDelete;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn inspect;
        private System.Windows.Forms.DataGridViewTextBoxColumn lot;
        private System.Windows.Forms.DataGridViewTextBoxColumn inspectdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn line;
        private System.Windows.Forms.DataGridViewTextBoxColumn qc_user;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn m1;
        private System.Windows.Forms.DataGridViewTextBoxColumn m2;
        private System.Windows.Forms.DataGridViewTextBoxColumn m3;
        private System.Windows.Forms.DataGridViewTextBoxColumn m4;
        private System.Windows.Forms.DataGridViewTextBoxColumn m5;
        private System.Windows.Forms.DataGridViewTextBoxColumn x;
        private System.Windows.Forms.DataGridViewTextBoxColumn r;
    }
}

