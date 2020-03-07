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
            this.txtPremac649Path = new System.Windows.Forms.TextBox();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
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
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.txtSupplier232 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBrowseritem = new System.Windows.Forms.Button();
            this.txtItem212 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPremac649Path
            // 
            this.txtPremac649Path.Location = new System.Drawing.Point(100, 10);
            this.txtPremac649Path.Name = "txtPremac649Path";
            this.txtPremac649Path.Size = new System.Drawing.Size(400, 20);
            this.txtPremac649Path.TabIndex = 0;
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(520, 10);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(80, 23);
            this.btnBrowser.TabIndex = 1;
            this.btnBrowser.Text = "Browser";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "PREMAC 6-4-9";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(186, 121);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(80, 50);
            this.btnConvert.TabIndex = 3;
            this.btnConvert.Text = "Convert Now";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(100, 121);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(80, 50);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsVersion,
            this.tsStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 378);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(614, 22);
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
            this.tsStatus.Size = new System.Drawing.Size(513, 17);
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
            this.dtpTimeConvert.Location = new System.Drawing.Point(13, 137);
            this.dtpTimeConvert.Name = "dtpTimeConvert";
            this.dtpTimeConvert.ShowUpDown = true;
            this.dtpTimeConvert.Size = new System.Drawing.Size(80, 20);
            this.dtpTimeConvert.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 121);
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
            this.dgvLogs.Location = new System.Drawing.Point(0, 177);
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.ReadOnly = true;
            this.dgvLogs.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgvLogs.Size = new System.Drawing.Size(614, 201);
            this.dgvLogs.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnSupplier);
            this.panel1.Controls.Add(this.txtSupplier232);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnBrowseritem);
            this.panel1.Controls.Add(this.txtItem212);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnBrowser);
            this.panel1.Controls.Add(this.txtPremac649Path);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpTimeConvert);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.btnConvert);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(614, 177);
            this.panel1.TabIndex = 9;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(272, 121);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 50);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.Location = new System.Drawing.Point(520, 80);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(80, 23);
            this.btnSupplier.TabIndex = 12;
            this.btnSupplier.Text = "Browser";
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // txtSupplier232
            // 
            this.txtSupplier232.Location = new System.Drawing.Point(99, 80);
            this.txtSupplier232.Name = "txtSupplier232";
            this.txtSupplier232.Size = new System.Drawing.Size(400, 20);
            this.txtSupplier232.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "SUPPLIER 2-3-2";
            // 
            // btnBrowseritem
            // 
            this.btnBrowseritem.Location = new System.Drawing.Point(520, 45);
            this.btnBrowseritem.Name = "btnBrowseritem";
            this.btnBrowseritem.Size = new System.Drawing.Size(80, 23);
            this.btnBrowseritem.TabIndex = 9;
            this.btnBrowseritem.Text = "Browser";
            this.btnBrowseritem.UseVisualStyleBackColor = true;
            this.btnBrowseritem.Click += new System.EventHandler(this.btnBrowseritem_Click);
            // 
            // txtItem212
            // 
            this.txtItem212.Location = new System.Drawing.Point(99, 45);
            this.txtItem212.Name = "txtItem212";
            this.txtItem212.Size = new System.Drawing.Size(400, 20);
            this.txtItem212.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "ITEM 2-1-2";
            // 
            // AddPremac649ToDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 400);
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

        private System.Windows.Forms.TextBox txtPremac649Path;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBrowseritem;
        private System.Windows.Forms.TextBox txtItem212;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ToolStripStatusLabel tsVersion;
    }
}