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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dtpTimeConvert = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvLogs = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBrowserStruct223 = new System.Windows.Forms.Button();
            this.txtStruct223 = new System.Windows.Forms.TextBox();
            this.btnBrowserStockOut649 = new System.Windows.Forms.Button();
            this.txtStockOut649 = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.txtSupplier232 = new System.Windows.Forms.TextBox();
            this.btnBrowseritem = new System.Windows.Forms.Button();
            this.txtItem212 = new System.Windows.Forms.TextBox();
            this.cbStockIn649 = new System.Windows.Forms.CheckBox();
            this.cbStockOut649 = new System.Windows.Forms.CheckBox();
            this.cbItem212 = new System.Windows.Forms.CheckBox();
            this.cbSupplier232 = new System.Windows.Forms.CheckBox();
            this.cbStruct223 = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStockIn649
            // 
            this.txtStockIn649.Location = new System.Drawing.Point(110, 10);
            this.txtStockIn649.Name = "txtStockIn649";
            this.txtStockIn649.Size = new System.Drawing.Size(400, 20);
            this.txtStockIn649.TabIndex = 1;
            // 
            // btnBrowserStockIn649
            // 
            this.btnBrowserStockIn649.Location = new System.Drawing.Point(520, 10);
            this.btnBrowserStockIn649.Name = "btnBrowserStockIn649";
            this.btnBrowserStockIn649.Size = new System.Drawing.Size(80, 23);
            this.btnBrowserStockIn649.TabIndex = 2;
            this.btnBrowserStockIn649.Text = "Browser";
            this.btnBrowserStockIn649.UseVisualStyleBackColor = true;
            this.btnBrowserStockIn649.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(200, 176);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(80, 50);
            this.btnConvert.TabIndex = 11;
            this.btnConvert.Text = "Convert Now";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(110, 176);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(80, 50);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsVersion,
            this.tsStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 437);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(648, 22);
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
            this.tsStatus.Size = new System.Drawing.Size(547, 17);
            this.tsStatus.Spring = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dtpTimeConvert
            // 
            this.dtpTimeConvert.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeConvert.Location = new System.Drawing.Point(10, 206);
            this.dtpTimeConvert.Name = "dtpTimeConvert";
            this.dtpTimeConvert.ShowUpDown = true;
            this.dtpTimeConvert.Size = new System.Drawing.Size(80, 20);
            this.dtpTimeConvert.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Time Set:";
            // 
            // dgvLogs
            // 
            this.dgvLogs.AllowUserToAddRows = false;
            this.dgvLogs.AllowUserToDeleteRows = false;
            this.dgvLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLogs.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLogs.Location = new System.Drawing.Point(0, 277);
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.ReadOnly = true;
            this.dgvLogs.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgvLogs.Size = new System.Drawing.Size(648, 160);
            this.dgvLogs.TabIndex = 8;
            this.dgvLogs.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbStruct223);
            this.panel1.Controls.Add(this.cbSupplier232);
            this.panel1.Controls.Add(this.cbItem212);
            this.panel1.Controls.Add(this.cbStockOut649);
            this.panel1.Controls.Add(this.cbStockIn649);
            this.panel1.Controls.Add(this.btnBrowserStruct223);
            this.panel1.Controls.Add(this.txtStruct223);
            this.panel1.Controls.Add(this.btnBrowserStockOut649);
            this.panel1.Controls.Add(this.txtStockOut649);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnSupplier);
            this.panel1.Controls.Add(this.txtSupplier232);
            this.panel1.Controls.Add(this.btnBrowseritem);
            this.panel1.Controls.Add(this.txtItem212);
            this.panel1.Controls.Add(this.btnBrowserStockIn649);
            this.panel1.Controls.Add(this.txtStockIn649);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpTimeConvert);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.btnConvert);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(648, 277);
            this.panel1.TabIndex = 9;
            // 
            // btnBrowserStruct223
            // 
            this.btnBrowserStruct223.Location = new System.Drawing.Point(520, 130);
            this.btnBrowserStruct223.Name = "btnBrowserStruct223";
            this.btnBrowserStruct223.Size = new System.Drawing.Size(80, 23);
            this.btnBrowserStruct223.TabIndex = 19;
            this.btnBrowserStruct223.Text = "Browser";
            this.btnBrowserStruct223.UseVisualStyleBackColor = true;
            this.btnBrowserStruct223.Click += new System.EventHandler(this.btnBrowserStruct223_Click);
            // 
            // txtStruct223
            // 
            this.txtStruct223.Location = new System.Drawing.Point(110, 130);
            this.txtStruct223.Name = "txtStruct223";
            this.txtStruct223.Size = new System.Drawing.Size(400, 20);
            this.txtStruct223.TabIndex = 18;
            // 
            // btnBrowserStockOut649
            // 
            this.btnBrowserStockOut649.Location = new System.Drawing.Point(520, 40);
            this.btnBrowserStockOut649.Name = "btnBrowserStockOut649";
            this.btnBrowserStockOut649.Size = new System.Drawing.Size(80, 23);
            this.btnBrowserStockOut649.TabIndex = 4;
            this.btnBrowserStockOut649.Text = "Browser";
            this.btnBrowserStockOut649.UseVisualStyleBackColor = true;
            this.btnBrowserStockOut649.Click += new System.EventHandler(this.btnBrowserStockOut649_Click);
            // 
            // txtStockOut649
            // 
            this.txtStockOut649.Location = new System.Drawing.Point(110, 40);
            this.txtStockOut649.Name = "txtStockOut649";
            this.txtStockOut649.Size = new System.Drawing.Size(400, 20);
            this.txtStockOut649.TabIndex = 3;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(290, 176);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 50);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.Location = new System.Drawing.Point(520, 100);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(80, 23);
            this.btnSupplier.TabIndex = 8;
            this.btnSupplier.Text = "Browser";
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // txtSupplier232
            // 
            this.txtSupplier232.Location = new System.Drawing.Point(110, 100);
            this.txtSupplier232.Name = "txtSupplier232";
            this.txtSupplier232.Size = new System.Drawing.Size(400, 20);
            this.txtSupplier232.TabIndex = 7;
            // 
            // btnBrowseritem
            // 
            this.btnBrowseritem.Location = new System.Drawing.Point(520, 70);
            this.btnBrowseritem.Name = "btnBrowseritem";
            this.btnBrowseritem.Size = new System.Drawing.Size(80, 23);
            this.btnBrowseritem.TabIndex = 6;
            this.btnBrowseritem.Text = "Browser";
            this.btnBrowseritem.UseVisualStyleBackColor = true;
            this.btnBrowseritem.Click += new System.EventHandler(this.btnBrowseritem_Click);
            // 
            // txtItem212
            // 
            this.txtItem212.Location = new System.Drawing.Point(110, 70);
            this.txtItem212.Name = "txtItem212";
            this.txtItem212.Size = new System.Drawing.Size(400, 20);
            this.txtItem212.TabIndex = 5;
            // 
            // cbStockIn649
            // 
            this.cbStockIn649.AutoSize = true;
            this.cbStockIn649.Location = new System.Drawing.Point(10, 10);
            this.cbStockIn649.Name = "cbStockIn649";
            this.cbStockIn649.Size = new System.Drawing.Size(87, 17);
            this.cbStockIn649.TabIndex = 21;
            this.cbStockIn649.Text = "Stock-In 649";
            this.cbStockIn649.UseVisualStyleBackColor = true;
            // 
            // cbStockOut649
            // 
            this.cbStockOut649.AutoSize = true;
            this.cbStockOut649.Location = new System.Drawing.Point(10, 40);
            this.cbStockOut649.Name = "cbStockOut649";
            this.cbStockOut649.Size = new System.Drawing.Size(95, 17);
            this.cbStockOut649.TabIndex = 22;
            this.cbStockOut649.Text = "Stock-Out 649";
            this.cbStockOut649.UseVisualStyleBackColor = true;
            // 
            // cbItem212
            // 
            this.cbItem212.AutoSize = true;
            this.cbItem212.Location = new System.Drawing.Point(10, 70);
            this.cbItem212.Name = "cbItem212";
            this.cbItem212.Size = new System.Drawing.Size(67, 17);
            this.cbItem212.TabIndex = 23;
            this.cbItem212.Text = "Item 212";
            this.cbItem212.UseVisualStyleBackColor = true;
            // 
            // cbSupplier232
            // 
            this.cbSupplier232.AutoSize = true;
            this.cbSupplier232.Location = new System.Drawing.Point(10, 100);
            this.cbSupplier232.Name = "cbSupplier232";
            this.cbSupplier232.Size = new System.Drawing.Size(85, 17);
            this.cbSupplier232.TabIndex = 24;
            this.cbSupplier232.Text = "Supplier 232";
            this.cbSupplier232.UseVisualStyleBackColor = true;
            // 
            // cbStruct223
            // 
            this.cbStruct223.AutoSize = true;
            this.cbStruct223.Location = new System.Drawing.Point(10, 130);
            this.cbStruct223.Name = "cbStruct223";
            this.cbStruct223.Size = new System.Drawing.Size(75, 17);
            this.cbStruct223.TabIndex = 25;
            this.cbStruct223.Text = "Struct 223";
            this.cbStruct223.UseVisualStyleBackColor = true;
            // 
            // AddPremac649ToDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 459);
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
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Label label2;
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
    }
}