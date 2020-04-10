namespace ConvertPremacFile
{
    partial class AddPremac649ToDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPremac649ToDB));
            this.txtStockIn649 = new System.Windows.Forms.TextBox();
            this.btnBrowserStockIn649 = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsExecuteTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dtpTimeConvert = new System.Windows.Forms.DateTimePicker();
            this.dgvLogs = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClear = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rbtnTimeSet = new System.Windows.Forms.RadioButton();
            this.txtIssue655 = new System.Windows.Forms.TextBox();
            this.cbIssue655 = new System.Windows.Forms.CheckBox();
            this.dtpTimeConvert2 = new System.Windows.Forms.DateTimePicker();
            this.txtStockIn6123 = new System.Windows.Forms.TextBox();
            this.cbStockIn6123 = new System.Windows.Forms.CheckBox();
            this.cbStockIn649 = new System.Windows.Forms.CheckBox();
            this.cbStruct223 = new System.Windows.Forms.CheckBox();
            this.txtStruct223 = new System.Windows.Forms.TextBox();
            this.cbSupplier232 = new System.Windows.Forms.CheckBox();
            this.cbItem212 = new System.Windows.Forms.CheckBox();
            this.cbStockOut649 = new System.Windows.Forms.CheckBox();
            this.txtStockOut649 = new System.Windows.Forms.TextBox();
            this.txtSupplier232 = new System.Windows.Forms.TextBox();
            this.txtItem212 = new System.Windows.Forms.TextBox();
            this.numTimer = new System.Windows.Forms.NumericUpDown();
            this.rbtnTimer = new System.Windows.Forms.RadioButton();
            this.btnBrowserStockOut649 = new System.Windows.Forms.Button();
            this.btnBrowseritem = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.btnBrowserStruct223 = new System.Windows.Forms.Button();
            this.btnBrowserIssue655 = new System.Windows.Forms.Button();
            this.btnBrowserStockIn6123 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimer)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStockIn649
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtStockIn649, 3);
            this.txtStockIn649.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStockIn649.Location = new System.Drawing.Point(175, 3);
            this.txtStockIn649.Name = "txtStockIn649";
            this.txtStockIn649.Size = new System.Drawing.Size(510, 20);
            this.txtStockIn649.TabIndex = 1;
            // 
            // btnBrowserStockIn649
            // 
            this.btnBrowserStockIn649.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBrowserStockIn649.Location = new System.Drawing.Point(692, 0);
            this.btnBrowserStockIn649.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnBrowserStockIn649.Name = "btnBrowserStockIn649";
            this.btnBrowserStockIn649.Size = new System.Drawing.Size(100, 30);
            this.btnBrowserStockIn649.TabIndex = 2;
            this.btnBrowserStockIn649.Text = "Browser";
            this.btnBrowserStockIn649.UseVisualStyleBackColor = true;
            this.btnBrowserStockIn649.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConvert.Location = new System.Drawing.Point(305, 3);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(296, 59);
            this.btnConvert.TabIndex = 11;
            this.btnConvert.Text = "Convert Now";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnStart
            // 
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStart.Location = new System.Drawing.Point(3, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(296, 59);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsVersion,
            this.tsStatus,
            this.tsExecuteTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 453);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(864, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsVersion
            // 
            this.tsVersion.Name = "tsVersion";
            this.tsVersion.Size = new System.Drawing.Size(86, 17);
            this.tsVersion.Text = "VERSION : 1_00";
            // 
            // tsStatus
            // 
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(727, 17);
            this.tsStatus.Spring = true;
            // 
            // tsExecuteTime
            // 
            this.tsExecuteTime.Name = "tsExecuteTime";
            this.tsExecuteTime.Size = new System.Drawing.Size(36, 17);
            this.tsExecuteTime.Text = "None";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dtpTimeConvert
            // 
            this.dtpTimeConvert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpTimeConvert.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeConvert.Location = new System.Drawing.Point(175, 213);
            this.dtpTimeConvert.Name = "dtpTimeConvert";
            this.dtpTimeConvert.ShowUpDown = true;
            this.dtpTimeConvert.Size = new System.Drawing.Size(166, 20);
            this.dtpTimeConvert.TabIndex = 9;
            // 
            // dgvLogs
            // 
            this.dgvLogs.AllowUserToAddRows = false;
            this.dgvLogs.AllowUserToDeleteRows = false;
            this.dgvLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLogs.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLogs.Location = new System.Drawing.Point(0, 337);
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.ReadOnly = true;
            this.dgvLogs.RowHeadersVisible = false;
            this.dgvLogs.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgvLogs.Size = new System.Drawing.Size(864, 116);
            this.dgvLogs.TabIndex = 8;
            this.dgvLogs.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 337);
            this.panel1.TabIndex = 9;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Controls.Add(this.btnStart, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnClear, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnConvert, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 270);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(864, 65);
            this.tableLayoutPanel2.TabIndex = 27;
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Location = new System.Drawing.Point(607, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(254, 59);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.rbtnTimeSet, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtIssue655, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.cbIssue655, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.dtpTimeConvert2, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtStockIn6123, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.cbStockIn6123, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.cbStockIn649, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbStruct223, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.dtpTimeConvert, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtStockIn649, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtStruct223, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbSupplier232, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbItem212, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbStockOut649, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtStockOut649, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSupplier232, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtItem212, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.numTimer, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.rbtnTimer, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnBrowserStockIn649, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnBrowserStockOut649, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnBrowseritem, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSupplier, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnBrowserStruct223, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnBrowserIssue655, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnBrowserStockIn6123, 4, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(864, 270);
            this.tableLayoutPanel1.TabIndex = 26;
            // 
            // rbtnTimeSet
            // 
            this.rbtnTimeSet.AutoSize = true;
            this.rbtnTimeSet.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtnTimeSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbtnTimeSet.Location = new System.Drawing.Point(3, 213);
            this.rbtnTimeSet.Name = "rbtnTimeSet";
            this.rbtnTimeSet.Size = new System.Drawing.Size(166, 24);
            this.rbtnTimeSet.TabIndex = 36;
            this.rbtnTimeSet.TabStop = true;
            this.rbtnTimeSet.Text = "Time Set";
            this.rbtnTimeSet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtnTimeSet.UseVisualStyleBackColor = true;
            // 
            // txtIssue655
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtIssue655, 3);
            this.txtIssue655.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtIssue655.Location = new System.Drawing.Point(175, 153);
            this.txtIssue655.Name = "txtIssue655";
            this.txtIssue655.Size = new System.Drawing.Size(510, 20);
            this.txtIssue655.TabIndex = 31;
            // 
            // cbIssue655
            // 
            this.cbIssue655.AutoSize = true;
            this.cbIssue655.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbIssue655.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbIssue655.Location = new System.Drawing.Point(3, 153);
            this.cbIssue655.Name = "cbIssue655";
            this.cbIssue655.Size = new System.Drawing.Size(166, 24);
            this.cbIssue655.TabIndex = 30;
            this.cbIssue655.Text = "Issue 655";
            this.cbIssue655.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbIssue655.UseVisualStyleBackColor = true;
            // 
            // dtpTimeConvert2
            // 
            this.dtpTimeConvert2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpTimeConvert2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeConvert2.Location = new System.Drawing.Point(347, 213);
            this.dtpTimeConvert2.Name = "dtpTimeConvert2";
            this.dtpTimeConvert2.ShowUpDown = true;
            this.dtpTimeConvert2.Size = new System.Drawing.Size(166, 20);
            this.dtpTimeConvert2.TabIndex = 29;
            // 
            // txtStockIn6123
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtStockIn6123, 3);
            this.txtStockIn6123.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStockIn6123.Location = new System.Drawing.Point(175, 183);
            this.txtStockIn6123.Name = "txtStockIn6123";
            this.txtStockIn6123.Size = new System.Drawing.Size(510, 20);
            this.txtStockIn6123.TabIndex = 27;
            // 
            // cbStockIn6123
            // 
            this.cbStockIn6123.AutoSize = true;
            this.cbStockIn6123.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbStockIn6123.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbStockIn6123.Location = new System.Drawing.Point(3, 183);
            this.cbStockIn6123.Name = "cbStockIn6123";
            this.cbStockIn6123.Size = new System.Drawing.Size(166, 24);
            this.cbStockIn6123.TabIndex = 26;
            this.cbStockIn6123.Text = "Stock-In 6-12-3";
            this.cbStockIn6123.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbStockIn6123.UseVisualStyleBackColor = true;
            // 
            // cbStockIn649
            // 
            this.cbStockIn649.AutoSize = true;
            this.cbStockIn649.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbStockIn649.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbStockIn649.Location = new System.Drawing.Point(3, 3);
            this.cbStockIn649.Name = "cbStockIn649";
            this.cbStockIn649.Size = new System.Drawing.Size(166, 24);
            this.cbStockIn649.TabIndex = 21;
            this.cbStockIn649.Text = "Stock-In 649";
            this.cbStockIn649.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbStockIn649.UseVisualStyleBackColor = true;
            // 
            // cbStruct223
            // 
            this.cbStruct223.AutoSize = true;
            this.cbStruct223.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbStruct223.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbStruct223.Location = new System.Drawing.Point(3, 123);
            this.cbStruct223.Name = "cbStruct223";
            this.cbStruct223.Size = new System.Drawing.Size(166, 24);
            this.cbStruct223.TabIndex = 25;
            this.cbStruct223.Text = "Struct 223";
            this.cbStruct223.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbStruct223.UseVisualStyleBackColor = true;
            // 
            // txtStruct223
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtStruct223, 3);
            this.txtStruct223.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStruct223.Location = new System.Drawing.Point(175, 123);
            this.txtStruct223.Name = "txtStruct223";
            this.txtStruct223.Size = new System.Drawing.Size(510, 20);
            this.txtStruct223.TabIndex = 18;
            // 
            // cbSupplier232
            // 
            this.cbSupplier232.AutoSize = true;
            this.cbSupplier232.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbSupplier232.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSupplier232.Location = new System.Drawing.Point(3, 93);
            this.cbSupplier232.Name = "cbSupplier232";
            this.cbSupplier232.Size = new System.Drawing.Size(166, 24);
            this.cbSupplier232.TabIndex = 24;
            this.cbSupplier232.Text = "Supplier 232";
            this.cbSupplier232.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbSupplier232.UseVisualStyleBackColor = true;
            // 
            // cbItem212
            // 
            this.cbItem212.AutoSize = true;
            this.cbItem212.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbItem212.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbItem212.Location = new System.Drawing.Point(3, 63);
            this.cbItem212.Name = "cbItem212";
            this.cbItem212.Size = new System.Drawing.Size(166, 24);
            this.cbItem212.TabIndex = 23;
            this.cbItem212.Text = "Item 212";
            this.cbItem212.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbItem212.UseVisualStyleBackColor = true;
            // 
            // cbStockOut649
            // 
            this.cbStockOut649.AutoSize = true;
            this.cbStockOut649.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbStockOut649.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbStockOut649.Location = new System.Drawing.Point(3, 33);
            this.cbStockOut649.Name = "cbStockOut649";
            this.cbStockOut649.Size = new System.Drawing.Size(166, 24);
            this.cbStockOut649.TabIndex = 22;
            this.cbStockOut649.Text = "Stock-Out 649";
            this.cbStockOut649.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbStockOut649.UseVisualStyleBackColor = true;
            // 
            // txtStockOut649
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtStockOut649, 3);
            this.txtStockOut649.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStockOut649.Location = new System.Drawing.Point(175, 33);
            this.txtStockOut649.Name = "txtStockOut649";
            this.txtStockOut649.Size = new System.Drawing.Size(510, 20);
            this.txtStockOut649.TabIndex = 3;
            // 
            // txtSupplier232
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtSupplier232, 3);
            this.txtSupplier232.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSupplier232.Location = new System.Drawing.Point(175, 93);
            this.txtSupplier232.Name = "txtSupplier232";
            this.txtSupplier232.Size = new System.Drawing.Size(510, 20);
            this.txtSupplier232.TabIndex = 7;
            // 
            // txtItem212
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtItem212, 3);
            this.txtItem212.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtItem212.Location = new System.Drawing.Point(175, 63);
            this.txtItem212.Name = "txtItem212";
            this.txtItem212.Size = new System.Drawing.Size(510, 20);
            this.txtItem212.TabIndex = 5;
            // 
            // numTimer
            // 
            this.numTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numTimer.Location = new System.Drawing.Point(175, 243);
            this.numTimer.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numTimer.Name = "numTimer";
            this.numTimer.Size = new System.Drawing.Size(166, 20);
            this.numTimer.TabIndex = 34;
            this.numTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rbtnTimer
            // 
            this.rbtnTimer.AutoSize = true;
            this.rbtnTimer.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtnTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbtnTimer.Location = new System.Drawing.Point(3, 243);
            this.rbtnTimer.Name = "rbtnTimer";
            this.rbtnTimer.Size = new System.Drawing.Size(166, 24);
            this.rbtnTimer.TabIndex = 35;
            this.rbtnTimer.TabStop = true;
            this.rbtnTimer.Text = "Timer";
            this.rbtnTimer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtnTimer.UseVisualStyleBackColor = true;
            // 
            // btnBrowserStockOut649
            // 
            this.btnBrowserStockOut649.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBrowserStockOut649.Location = new System.Drawing.Point(692, 30);
            this.btnBrowserStockOut649.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnBrowserStockOut649.Name = "btnBrowserStockOut649";
            this.btnBrowserStockOut649.Size = new System.Drawing.Size(100, 30);
            this.btnBrowserStockOut649.TabIndex = 4;
            this.btnBrowserStockOut649.Text = "Browser";
            this.btnBrowserStockOut649.UseVisualStyleBackColor = true;
            this.btnBrowserStockOut649.Click += new System.EventHandler(this.btnBrowserStockOut649_Click);
            // 
            // btnBrowseritem
            // 
            this.btnBrowseritem.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBrowseritem.Location = new System.Drawing.Point(692, 60);
            this.btnBrowseritem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnBrowseritem.Name = "btnBrowseritem";
            this.btnBrowseritem.Size = new System.Drawing.Size(100, 30);
            this.btnBrowseritem.TabIndex = 6;
            this.btnBrowseritem.Text = "Browser";
            this.btnBrowseritem.UseVisualStyleBackColor = true;
            this.btnBrowseritem.Click += new System.EventHandler(this.btnBrowseritem_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSupplier.Location = new System.Drawing.Point(692, 90);
            this.btnSupplier.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(100, 30);
            this.btnSupplier.TabIndex = 8;
            this.btnSupplier.Text = "Browser";
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnBrowserStruct223
            // 
            this.btnBrowserStruct223.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBrowserStruct223.Location = new System.Drawing.Point(692, 120);
            this.btnBrowserStruct223.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnBrowserStruct223.Name = "btnBrowserStruct223";
            this.btnBrowserStruct223.Size = new System.Drawing.Size(100, 30);
            this.btnBrowserStruct223.TabIndex = 19;
            this.btnBrowserStruct223.Text = "Browser";
            this.btnBrowserStruct223.UseVisualStyleBackColor = true;
            this.btnBrowserStruct223.Click += new System.EventHandler(this.btnBrowserStruct223_Click);
            // 
            // btnBrowserIssue655
            // 
            this.btnBrowserIssue655.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBrowserIssue655.Location = new System.Drawing.Point(692, 150);
            this.btnBrowserIssue655.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnBrowserIssue655.Name = "btnBrowserIssue655";
            this.btnBrowserIssue655.Size = new System.Drawing.Size(100, 30);
            this.btnBrowserIssue655.TabIndex = 32;
            this.btnBrowserIssue655.Text = "Browser";
            this.btnBrowserIssue655.UseVisualStyleBackColor = true;
            this.btnBrowserIssue655.Click += new System.EventHandler(this.btnBrowserIssue655_Click);
            // 
            // btnBrowserStockIn6123
            // 
            this.btnBrowserStockIn6123.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBrowserStockIn6123.Location = new System.Drawing.Point(692, 180);
            this.btnBrowserStockIn6123.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnBrowserStockIn6123.Name = "btnBrowserStockIn6123";
            this.btnBrowserStockIn6123.Size = new System.Drawing.Size(100, 30);
            this.btnBrowserStockIn6123.TabIndex = 28;
            this.btnBrowserStockIn6123.Text = "Browser";
            this.btnBrowserStockIn6123.UseVisualStyleBackColor = true;
            this.btnBrowserStockIn6123.Click += new System.EventHandler(this.btnBrowserStockIn6123_Click);
            // 
            // AddPremac649ToDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 475);
            this.Controls.Add(this.dgvLogs);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddPremac649ToDB";
            this.Text = "Add Premac To Database";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddPremac649ToDB_FormClosing);
            this.Load += new System.EventHandler(this.AddPremac649ToDB_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStockIn649;
        private System.Windows.Forms.Button btnBrowserStockIn649;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsStatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DateTimePicker dtpTimeConvert;
        private System.Windows.Forms.DataGridView dgvLogs;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.TextBox txtSupplier232;
        private System.Windows.Forms.Button btnBrowseritem;
        private System.Windows.Forms.TextBox txtItem212;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ToolStripStatusLabel tsVersion;
        private System.Windows.Forms.Button btnBrowserStockOut649;
        private System.Windows.Forms.TextBox txtStockOut649;
        private System.Windows.Forms.Button btnBrowserStruct223;
        private System.Windows.Forms.TextBox txtStruct223;
        private System.Windows.Forms.CheckBox cbStruct223;
        private System.Windows.Forms.CheckBox cbSupplier232;
        private System.Windows.Forms.CheckBox cbItem212;
        private System.Windows.Forms.CheckBox cbStockOut649;
        private System.Windows.Forms.CheckBox cbStockIn649;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DateTimePicker dtpTimeConvert2;
        private System.Windows.Forms.Button btnBrowserStockIn6123;
        private System.Windows.Forms.TextBox txtStockIn6123;
        private System.Windows.Forms.CheckBox cbStockIn6123;
        private System.Windows.Forms.Button btnBrowserIssue655;
        private System.Windows.Forms.TextBox txtIssue655;
        private System.Windows.Forms.CheckBox cbIssue655;
        private System.Windows.Forms.RadioButton rbtnTimeSet;
        private System.Windows.Forms.NumericUpDown numTimer;
        private System.Windows.Forms.RadioButton rbtnTimer;
        private System.Windows.Forms.ToolStripStatusLabel tsExecuteTime;
    }
}