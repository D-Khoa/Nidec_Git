namespace Push_EN2_Data_LD20
{
    partial class MainForm
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
            this.txtDataFolder = new System.Windows.Forms.TextBox();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSetting = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowserServer = new System.Windows.Forms.Button();
            this.txtServerFolder = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.dgvDataLog = new System.Windows.Forms.DataGridView();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.error = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.numCounter = new System.Windows.Forms.NumericUpDown();
            this.btnStop = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsCounter = new System.Windows.Forms.ToolStripStatusLabel();
            this.bwSendData = new System.ComponentModel.BackgroundWorker();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsSpeed = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataLog)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCounter)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDataFolder
            // 
            this.txtDataFolder.Location = new System.Drawing.Point(100, 10);
            this.txtDataFolder.Name = "txtDataFolder";
            this.txtDataFolder.Size = new System.Drawing.Size(300, 20);
            this.txtDataFolder.TabIndex = 0;
            // 
            // btnBrowser
            // 
            this.btnBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowser.Location = new System.Drawing.Point(410, 10);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(60, 20);
            this.btnBrowser.TabIndex = 1;
            this.btnBrowser.Text = "Browser";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Data folder";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlSetting
            // 
            this.pnlSetting.Controls.Add(this.label2);
            this.pnlSetting.Controls.Add(this.btnBrowserServer);
            this.pnlSetting.Controls.Add(this.txtServerFolder);
            this.pnlSetting.Controls.Add(this.label1);
            this.pnlSetting.Controls.Add(this.btnBrowser);
            this.pnlSetting.Controls.Add(this.txtDataFolder);
            this.pnlSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSetting.Location = new System.Drawing.Point(0, 0);
            this.pnlSetting.Name = "pnlSetting";
            this.pnlSetting.Size = new System.Drawing.Size(480, 70);
            this.pnlSetting.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Server folder";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBrowserServer
            // 
            this.btnBrowserServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowserServer.Location = new System.Drawing.Point(410, 40);
            this.btnBrowserServer.Name = "btnBrowserServer";
            this.btnBrowserServer.Size = new System.Drawing.Size(60, 20);
            this.btnBrowserServer.TabIndex = 5;
            this.btnBrowserServer.Text = "Browser";
            this.btnBrowserServer.UseVisualStyleBackColor = true;
            this.btnBrowserServer.Click += new System.EventHandler(this.btnBrowserServer_Click);
            // 
            // txtServerFolder
            // 
            this.txtServerFolder.Location = new System.Drawing.Point(100, 40);
            this.txtServerFolder.Name = "txtServerFolder";
            this.txtServerFolder.Size = new System.Drawing.Size(300, 20);
            this.txtServerFolder.TabIndex = 4;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(10, 80);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(80, 50);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // dgvDataLog
            // 
            this.dgvDataLog.AllowUserToAddRows = false;
            this.dgvDataLog.AllowUserToDeleteRows = false;
            this.dgvDataLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.status,
            this.error});
            this.dgvDataLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataLog.Location = new System.Drawing.Point(0, 140);
            this.dgvDataLog.Name = "dgvDataLog";
            this.dgvDataLog.ReadOnly = true;
            this.dgvDataLog.Size = new System.Drawing.Size(480, 180);
            this.dgvDataLog.TabIndex = 4;
            // 
            // date
            // 
            this.date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.date.HeaderText = "Date";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 55;
            // 
            // status
            // 
            this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 62;
            // 
            // error
            // 
            this.error.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.error.HeaderText = "Error";
            this.error.Name = "error";
            this.error.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.numCounter);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.pnlSetting);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 140);
            this.panel1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(190, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Counter";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numCounter
            // 
            this.numCounter.Location = new System.Drawing.Point(193, 110);
            this.numCounter.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCounter.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numCounter.Name = "numCounter";
            this.numCounter.Size = new System.Drawing.Size(77, 20);
            this.numCounter.TabIndex = 5;
            this.numCounter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numCounter.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(100, 80);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(80, 50);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.tsSpeed,
            this.tsStatus,
            this.toolStripStatusLabel1,
            this.tsCounter});
            this.statusStrip1.Location = new System.Drawing.Point(0, 320);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(480, 24);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsStatus
            // 
            this.tsStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(249, 19);
            this.tsStatus.Spring = true;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(60, 19);
            this.toolStripStatusLabel1.Text = "Counter :";
            // 
            // tsCounter
            // 
            this.tsCounter.Name = "tsCounter";
            this.tsCounter.Size = new System.Drawing.Size(36, 19);
            this.tsCounter.Text = "None";
            // 
            // bwSendData
            // 
            this.bwSendData.WorkerReportsProgress = true;
            this.bwSendData.WorkerSupportsCancellation = true;
            this.bwSendData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSendData_DoWork);
            this.bwSendData.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwSendData_ProgressChanged);
            this.bwSendData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwSendData_RunWorkerCompleted);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(49, 19);
            this.toolStripStatusLabel2.Text = "Speed :";
            // 
            // tsSpeed
            // 
            this.tsSpeed.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsSpeed.Name = "tsSpeed";
            this.tsSpeed.Size = new System.Drawing.Size(40, 19);
            this.tsSpeed.Text = "None";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 344);
            this.Controls.Add(this.dgvDataLog);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "MainForm";
            this.Text = "Convert and push EN2 data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlSetting.ResumeLayout(false);
            this.pnlSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataLog)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numCounter)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDataFolder;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlSetting;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.DataGridView dgvDataLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowserServer;
        private System.Windows.Forms.TextBox txtServerFolder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsCounter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numCounter;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn error;
        private System.ComponentModel.BackgroundWorker bwSendData;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsSpeed;
    }
}

