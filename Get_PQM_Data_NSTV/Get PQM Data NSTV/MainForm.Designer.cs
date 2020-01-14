namespace Get_PQM_Data_NSTV
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
            this.pnlSetting = new System.Windows.Forms.Panel();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.dgvDataLog = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDataFolder = new System.Windows.Forms.TextBox();
            this.txtServerFolder = new System.Windows.Forms.TextBox();
            this.btnBrowserDataFolder = new System.Windows.Forms.Button();
            this.btnBrowserServerFolder = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.numCounter = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSetting.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCounter)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSetting
            // 
            this.pnlSetting.Controls.Add(this.btnBrowserServerFolder);
            this.pnlSetting.Controls.Add(this.btnBrowserDataFolder);
            this.pnlSetting.Controls.Add(this.txtServerFolder);
            this.pnlSetting.Controls.Add(this.txtDataFolder);
            this.pnlSetting.Controls.Add(this.label2);
            this.pnlSetting.Controls.Add(this.label1);
            this.pnlSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSetting.Location = new System.Drawing.Point(0, 0);
            this.pnlSetting.Name = "pnlSetting";
            this.pnlSetting.Size = new System.Drawing.Size(450, 60);
            this.pnlSetting.TabIndex = 0;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.label3);
            this.pnlButtons.Controls.Add(this.numCounter);
            this.pnlButtons.Controls.Add(this.btnStop);
            this.pnlButtons.Controls.Add(this.btnStart);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtons.Location = new System.Drawing.Point(0, 60);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(450, 50);
            this.pnlButtons.TabIndex = 1;
            // 
            // dgvDataLog
            // 
            this.dgvDataLog.AllowUserToAddRows = false;
            this.dgvDataLog.AllowUserToDeleteRows = false;
            this.dgvDataLog.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDataLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.status,
            this.comment});
            this.dgvDataLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataLog.Location = new System.Drawing.Point(0, 110);
            this.dgvDataLog.Name = "dgvDataLog";
            this.dgvDataLog.ReadOnly = true;
            this.dgvDataLog.Size = new System.Drawing.Size(450, 203);
            this.dgvDataLog.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Server folder";
            // 
            // txtDataFolder
            // 
            this.txtDataFolder.Location = new System.Drawing.Point(75, 7);
            this.txtDataFolder.Name = "txtDataFolder";
            this.txtDataFolder.Size = new System.Drawing.Size(300, 20);
            this.txtDataFolder.TabIndex = 2;
            // 
            // txtServerFolder
            // 
            this.txtServerFolder.Location = new System.Drawing.Point(75, 33);
            this.txtServerFolder.Name = "txtServerFolder";
            this.txtServerFolder.Size = new System.Drawing.Size(300, 20);
            this.txtServerFolder.TabIndex = 3;
            // 
            // btnBrowserDataFolder
            // 
            this.btnBrowserDataFolder.Location = new System.Drawing.Point(381, 7);
            this.btnBrowserDataFolder.Name = "btnBrowserDataFolder";
            this.btnBrowserDataFolder.Size = new System.Drawing.Size(60, 20);
            this.btnBrowserDataFolder.TabIndex = 4;
            this.btnBrowserDataFolder.Text = "Browser";
            this.btnBrowserDataFolder.UseVisualStyleBackColor = true;
            this.btnBrowserDataFolder.Click += new System.EventHandler(this.btnBrowserDataFolder_Click);
            // 
            // btnBrowserServerFolder
            // 
            this.btnBrowserServerFolder.Location = new System.Drawing.Point(381, 33);
            this.btnBrowserServerFolder.Name = "btnBrowserServerFolder";
            this.btnBrowserServerFolder.Size = new System.Drawing.Size(60, 20);
            this.btnBrowserServerFolder.TabIndex = 5;
            this.btnBrowserServerFolder.Text = "Browser";
            this.btnBrowserServerFolder.UseVisualStyleBackColor = true;
            this.btnBrowserServerFolder.Click += new System.EventHandler(this.btnBrowserServerFolder_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(10, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 40);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(100, 5);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 40);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // numCounter
            // 
            this.numCounter.Location = new System.Drawing.Point(181, 24);
            this.numCounter.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numCounter.Name = "numCounter";
            this.numCounter.Size = new System.Drawing.Size(60, 20);
            this.numCounter.TabIndex = 2;
            this.numCounter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numCounter.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(181, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Timer";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 313);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(450, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
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
            this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 62;
            // 
            // comment
            // 
            this.comment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.comment.HeaderText = "Comment";
            this.comment.Name = "comment";
            this.comment.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 335);
            this.Controls.Add(this.dgvDataLog);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlSetting);
            this.Name = "MainForm";
            this.Text = "Push Data FCT NSTV";
            this.pnlSetting.ResumeLayout(false);
            this.pnlSetting.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCounter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSetting;
        private System.Windows.Forms.TextBox txtServerFolder;
        private System.Windows.Forms.TextBox txtDataFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.DataGridView dgvDataLog;
        private System.Windows.Forms.Button btnBrowserDataFolder;
        private System.Windows.Forms.Button btnBrowserServerFolder;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.NumericUpDown numCounter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn comment;
    }
}

