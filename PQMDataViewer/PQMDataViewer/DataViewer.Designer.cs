namespace PQMDataViewer
{
    partial class DataViewer
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
            this.cbLine = new System.Windows.Forms.CheckBox();
            this.cmbLine = new System.Windows.Forms.ComboBox();
            this.cmbProcess = new System.Windows.Forms.ComboBox();
            this.cbProcess = new System.Windows.Forms.CheckBox();
            this.cbCheckDate = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.clInspect = new System.Windows.Forms.CheckedListBox();
            this.pnlBarcode = new System.Windows.Forms.Panel();
            this.rbSerial = new System.Windows.Forms.RadioButton();
            this.txtbarcode = new System.Windows.Forms.TextBox();
            this.rbLot = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsRows = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbInspect = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbData = new System.Windows.Forms.RadioButton();
            this.rbJudge = new System.Windows.Forms.RadioButton();
            this.tsProcessBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlDate.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.pnlBarcode.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbLine
            // 
            this.cbLine.AutoSize = true;
            this.cbLine.Location = new System.Drawing.Point(10, 50);
            this.cbLine.Name = "cbLine";
            this.cbLine.Size = new System.Drawing.Size(46, 17);
            this.cbLine.TabIndex = 0;
            this.cbLine.Text = "Line";
            this.cbLine.UseVisualStyleBackColor = true;
            // 
            // cmbLine
            // 
            this.cmbLine.FormattingEnabled = true;
            this.cmbLine.Location = new System.Drawing.Point(80, 50);
            this.cmbLine.Name = "cmbLine";
            this.cmbLine.Size = new System.Drawing.Size(120, 21);
            this.cmbLine.TabIndex = 1;
            // 
            // cmbProcess
            // 
            this.cmbProcess.FormattingEnabled = true;
            this.cmbProcess.Location = new System.Drawing.Point(80, 80);
            this.cmbProcess.Name = "cmbProcess";
            this.cmbProcess.Size = new System.Drawing.Size(120, 21);
            this.cmbProcess.TabIndex = 3;
            this.cmbProcess.SelectedIndexChanged += new System.EventHandler(this.cmbProcess_SelectedIndexChanged);
            // 
            // cbProcess
            // 
            this.cbProcess.AutoSize = true;
            this.cbProcess.Location = new System.Drawing.Point(10, 80);
            this.cbProcess.Name = "cbProcess";
            this.cbProcess.Size = new System.Drawing.Size(64, 17);
            this.cbProcess.TabIndex = 2;
            this.cbProcess.Text = "Process";
            this.cbProcess.UseVisualStyleBackColor = true;
            // 
            // cbCheckDate
            // 
            this.cbCheckDate.AutoSize = true;
            this.cbCheckDate.Location = new System.Drawing.Point(10, 110);
            this.cbCheckDate.Name = "cbCheckDate";
            this.cbCheckDate.Size = new System.Drawing.Size(83, 17);
            this.cbCheckDate.TabIndex = 6;
            this.cbCheckDate.Text = "Check Date";
            this.cbCheckDate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Model";
            // 
            // cmbModel
            // 
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Location = new System.Drawing.Point(80, 20);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(120, 21);
            this.cmbModel.TabIndex = 9;
            this.cmbModel.SelectedIndexChanged += new System.EventHandler(this.cmbModel_SelectedIndexChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(46, 10);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(140, 20);
            this.dtpFromDate.TabIndex = 10;
            this.dtpFromDate.Value = new System.DateTime(2020, 3, 16, 0, 0, 0, 0);
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(46, 40);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(140, 20);
            this.dtpToDate.TabIndex = 11;
            this.dtpToDate.Value = new System.DateTime(2020, 3, 16, 23, 59, 59, 0);
            // 
            // pnlDate
            // 
            this.pnlDate.Controls.Add(this.label3);
            this.pnlDate.Controls.Add(this.label2);
            this.pnlDate.Controls.Add(this.dtpFromDate);
            this.pnlDate.Controls.Add(this.dtpToDate);
            this.pnlDate.Location = new System.Drawing.Point(10, 140);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(200, 70);
            this.pnlDate.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "From";
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.cbInspect);
            this.pnlOptions.Controls.Add(this.clInspect);
            this.pnlOptions.Controls.Add(this.pnlBarcode);
            this.pnlOptions.Controls.Add(this.label1);
            this.pnlOptions.Controls.Add(this.pnlDate);
            this.pnlOptions.Controls.Add(this.cmbModel);
            this.pnlOptions.Controls.Add(this.cbCheckDate);
            this.pnlOptions.Controls.Add(this.cmbProcess);
            this.pnlOptions.Controls.Add(this.cbLine);
            this.pnlOptions.Controls.Add(this.cmbLine);
            this.pnlOptions.Controls.Add(this.cbProcess);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOptions.Location = new System.Drawing.Point(0, 0);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(640, 218);
            this.pnlOptions.TabIndex = 13;
            // 
            // clInspect
            // 
            this.clInspect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.clInspect.FormattingEnabled = true;
            this.clInspect.Location = new System.Drawing.Point(430, 40);
            this.clInspect.Name = "clInspect";
            this.clInspect.ScrollAlwaysVisible = true;
            this.clInspect.Size = new System.Drawing.Size(200, 169);
            this.clInspect.TabIndex = 17;
            // 
            // pnlBarcode
            // 
            this.pnlBarcode.Controls.Add(this.rbSerial);
            this.pnlBarcode.Controls.Add(this.txtbarcode);
            this.pnlBarcode.Controls.Add(this.rbLot);
            this.pnlBarcode.Location = new System.Drawing.Point(220, 20);
            this.pnlBarcode.Name = "pnlBarcode";
            this.pnlBarcode.Size = new System.Drawing.Size(200, 190);
            this.pnlBarcode.TabIndex = 16;
            // 
            // rbSerial
            // 
            this.rbSerial.AutoSize = true;
            this.rbSerial.Location = new System.Drawing.Point(5, 5);
            this.rbSerial.Name = "rbSerial";
            this.rbSerial.Size = new System.Drawing.Size(91, 17);
            this.rbSerial.TabIndex = 15;
            this.rbSerial.TabStop = true;
            this.rbSerial.Text = "Serial Number";
            this.rbSerial.UseVisualStyleBackColor = true;
            // 
            // txtbarcode
            // 
            this.txtbarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtbarcode.Location = new System.Drawing.Point(0, 30);
            this.txtbarcode.Multiline = true;
            this.txtbarcode.Name = "txtbarcode";
            this.txtbarcode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbarcode.Size = new System.Drawing.Size(200, 160);
            this.txtbarcode.TabIndex = 13;
            // 
            // rbLot
            // 
            this.rbLot.AutoSize = true;
            this.rbLot.Location = new System.Drawing.Point(110, 5);
            this.rbLot.Name = "rbLot";
            this.rbLot.Size = new System.Drawing.Size(80, 17);
            this.rbLot.TabIndex = 14;
            this.rbLot.TabStop = true;
            this.rbLot.Text = "Lot Number";
            this.rbLot.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(20, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 40);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.panel1);
            this.pnlButtons.Controls.Add(this.btnClear);
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Controls.Add(this.btnExport);
            this.pnlButtons.Controls.Add(this.btnSearch);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtons.Location = new System.Drawing.Point(0, 218);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(640, 60);
            this.pnlButtons.TabIndex = 20;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(440, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 40);
            this.btnClear.TabIndex = 22;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(540, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 40);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(120, 10);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(80, 40);
            this.btnExport.TabIndex = 20;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 278);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.Size = new System.Drawing.Size(640, 206);
            this.dgvData.TabIndex = 21;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsRows,
            this.tsProcessBar,
            this.toolStripStatusLabel4,
            this.tsTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 484);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(640, 22);
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(33, 18);
            this.toolStripStatusLabel1.Text = "Row:";
            // 
            // tsRows
            // 
            this.tsRows.Name = "tsRows";
            this.tsRows.Size = new System.Drawing.Size(36, 18);
            this.tsRows.Text = "None";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(37, 18);
            this.toolStripStatusLabel4.Text = "Time:";
            // 
            // tsTime
            // 
            this.tsTime.Name = "tsTime";
            this.tsTime.Size = new System.Drawing.Size(36, 18);
            this.tsTime.Text = "None";
            // 
            // cbInspect
            // 
            this.cbInspect.AutoSize = true;
            this.cbInspect.Location = new System.Drawing.Point(430, 20);
            this.cbInspect.Name = "cbInspect";
            this.cbInspect.Size = new System.Drawing.Size(61, 17);
            this.cbInspect.TabIndex = 18;
            this.cbInspect.Text = "Inspect";
            this.cbInspect.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbData);
            this.panel1.Controls.Add(this.rbJudge);
            this.panel1.Location = new System.Drawing.Point(220, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(64, 54);
            this.panel1.TabIndex = 23;
            // 
            // rbData
            // 
            this.rbData.AutoSize = true;
            this.rbData.Location = new System.Drawing.Point(5, 5);
            this.rbData.Name = "rbData";
            this.rbData.Size = new System.Drawing.Size(48, 17);
            this.rbData.TabIndex = 15;
            this.rbData.TabStop = true;
            this.rbData.Text = "Data";
            this.rbData.UseVisualStyleBackColor = true;
            // 
            // rbJudge
            // 
            this.rbJudge.AutoSize = true;
            this.rbJudge.Location = new System.Drawing.Point(5, 28);
            this.rbJudge.Name = "rbJudge";
            this.rbJudge.Size = new System.Drawing.Size(54, 17);
            this.rbJudge.TabIndex = 14;
            this.rbJudge.TabStop = true;
            this.rbJudge.Text = "Judge";
            this.rbJudge.UseVisualStyleBackColor = true;
            // 
            // tsProcessBar
            // 
            this.tsProcessBar.Name = "tsProcessBar";
            this.tsProcessBar.Size = new System.Drawing.Size(452, 17);
            this.tsProcessBar.Spring = true;
            // 
            // DataViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 506);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlOptions);
            this.Name = "DataViewer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Viewer";
            this.Load += new System.EventHandler(this.DataViewer_Load);
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            this.pnlBarcode.ResumeLayout(false);
            this.pnlBarcode.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbLine;
        private System.Windows.Forms.ComboBox cmbLine;
        private System.Windows.Forms.ComboBox cmbProcess;
        private System.Windows.Forms.CheckBox cbProcess;
        private System.Windows.Forms.CheckBox cbCheckDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Panel pnlDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Panel pnlBarcode;
        private System.Windows.Forms.RadioButton rbSerial;
        private System.Windows.Forms.TextBox txtbarcode;
        private System.Windows.Forms.RadioButton rbLot;
        private System.Windows.Forms.CheckedListBox clInspect;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsRows;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel tsTime;
        private System.Windows.Forms.CheckBox cbInspect;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbData;
        private System.Windows.Forms.RadioButton rbJudge;
        private System.Windows.Forms.ToolStripStatusLabel tsProcessBar;
    }
}

