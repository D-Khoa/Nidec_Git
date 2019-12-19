namespace YieldMonitor.View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsCounter = new System.Windows.Forms.ToolStripStatusLabel();
            this.bwSend = new System.ComponentModel.BackgroundWorker();
            this.btnRun = new System.Windows.Forms.Button();
            this.flpnlYeildShow = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSetting = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numCounter = new System.Windows.Forms.NumericUpDown();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.grt_Main = new System.Windows.Forms.TabControl();
            this.tab_YieldMonitor = new System.Windows.Forms.TabPage();
            this.tab_Track = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbTotalInput = new System.Windows.Forms.Label();
            this.lbTotalOutput = new System.Windows.Forms.Label();
            this.lbTotalYield = new System.Windows.Forms.Label();
            this.dgvDataTracking = new System.Windows.Forms.DataGridView();
            this.assy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.process = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.process_in = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.process_out = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ng_product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ng_rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTrackSetting = new System.Windows.Forms.Button();
            this.lbModel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCounter)).BeginInit();
            this.grt_Main.SuspendLayout();
            this.tab_YieldMonitor.SuspendLayout();
            this.tab_Track.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTracking)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatus,
            this.tsCounter});
            this.statusStrip1.Location = new System.Drawing.Point(0, 382);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(883, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsStatus
            // 
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(832, 17);
            this.tsStatus.Spring = true;
            // 
            // tsCounter
            // 
            this.tsCounter.Name = "tsCounter";
            this.tsCounter.Size = new System.Drawing.Size(36, 17);
            this.tsCounter.Text = "None";
            // 
            // bwSend
            // 
            this.bwSend.WorkerReportsProgress = true;
            this.bwSend.WorkerSupportsCancellation = true;
            this.bwSend.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSend_DoWork);
            this.bwSend.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwSend_ProgressChanged);
            this.bwSend.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwSend_RunWorkerCompleted);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(412, 6);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 72);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // flpnlYeildShow
            // 
            this.flpnlYeildShow.AutoScroll = true;
            this.flpnlYeildShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpnlYeildShow.Location = new System.Drawing.Point(3, 91);
            this.flpnlYeildShow.Name = "flpnlYeildShow";
            this.flpnlYeildShow.Size = new System.Drawing.Size(869, 259);
            this.flpnlYeildShow.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSetting);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.numCounter);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpDateTo);
            this.panel1.Controls.Add(this.dtpDateFrom);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbModel);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(869, 88);
            this.panel1.TabIndex = 3;
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(233, 56);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(77, 23);
            this.btnSetting.TabIndex = 13;
            this.btnSetting.Text = "Setting";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(640, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(229, 88);
            this.panel2.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Silver;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(115, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 27);
            this.label8.TabIndex = 3;
            this.label8.Text = "No Run";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Red;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(115, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 27);
            this.label7.TabIndex = 2;
            this.label7.Text = "Alarm [<50%]";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Yellow;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 27);
            this.label6.TabIndex = 1;
            this.label6.Text = "Alarm [50%~85%]";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 27);
            this.label5.TabIndex = 0;
            this.label5.Text = "OK [>85%]";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(233, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Timer (s)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numCounter
            // 
            this.numCounter.Location = new System.Drawing.Point(233, 32);
            this.numCounter.Name = "numCounter";
            this.numCounter.Size = new System.Drawing.Size(77, 20);
            this.numCounter.TabIndex = 10;
            this.numCounter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numCounter.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(493, 6);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 72);
            this.btnStop.TabIndex = 9;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(330, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 72);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Date To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Date From";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(74, 59);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(139, 20);
            this.dtpDateTo.TabIndex = 5;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(74, 33);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(139, 20);
            this.dtpDateFrom.TabIndex = 4;
            this.dtpDateFrom.ValueChanged += new System.EventHandler(this.dtpDateFrom_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Model";
            // 
            // cmbModel
            // 
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Location = new System.Drawing.Point(74, 6);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(139, 21);
            this.cmbModel.TabIndex = 2;
            this.cmbModel.TextChanged += new System.EventHandler(this.cmbModel_TextChanged);
            // 
            // grt_Main
            // 
            this.grt_Main.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.grt_Main.Controls.Add(this.tab_YieldMonitor);
            this.grt_Main.Controls.Add(this.tab_Track);
            this.grt_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grt_Main.Location = new System.Drawing.Point(0, 0);
            this.grt_Main.Name = "grt_Main";
            this.grt_Main.SelectedIndex = 0;
            this.grt_Main.Size = new System.Drawing.Size(883, 382);
            this.grt_Main.TabIndex = 3;
            // 
            // tab_YieldMonitor
            // 
            this.tab_YieldMonitor.Controls.Add(this.flpnlYeildShow);
            this.tab_YieldMonitor.Controls.Add(this.panel1);
            this.tab_YieldMonitor.Location = new System.Drawing.Point(4, 25);
            this.tab_YieldMonitor.Name = "tab_YieldMonitor";
            this.tab_YieldMonitor.Padding = new System.Windows.Forms.Padding(3);
            this.tab_YieldMonitor.Size = new System.Drawing.Size(875, 353);
            this.tab_YieldMonitor.TabIndex = 0;
            this.tab_YieldMonitor.Text = "Yield Monitor";
            this.tab_YieldMonitor.UseVisualStyleBackColor = true;
            // 
            // tab_Track
            // 
            this.tab_Track.Controls.Add(this.lbModel);
            this.tab_Track.Controls.Add(this.label13);
            this.tab_Track.Controls.Add(this.btnTrackSetting);
            this.tab_Track.Controls.Add(this.dgvDataTracking);
            this.tab_Track.Controls.Add(this.lbTotalYield);
            this.tab_Track.Controls.Add(this.lbTotalOutput);
            this.tab_Track.Controls.Add(this.lbTotalInput);
            this.tab_Track.Controls.Add(this.label11);
            this.tab_Track.Controls.Add(this.label10);
            this.tab_Track.Controls.Add(this.label9);
            this.tab_Track.Location = new System.Drawing.Point(4, 25);
            this.tab_Track.Name = "tab_Track";
            this.tab_Track.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Track.Size = new System.Drawing.Size(875, 353);
            this.tab_Track.TabIndex = 1;
            this.tab_Track.Text = "Tracking Data";
            this.tab_Track.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(24, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 24);
            this.label9.TabIndex = 0;
            this.label9.Text = "Total Input :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(8, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 24);
            this.label10.TabIndex = 1;
            this.label10.Text = "Total Output :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(75, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 24);
            this.label11.TabIndex = 2;
            this.label11.Text = "Yield :";
            // 
            // lbTotalInput
            // 
            this.lbTotalInput.AutoSize = true;
            this.lbTotalInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalInput.Location = new System.Drawing.Point(150, 35);
            this.lbTotalInput.Name = "lbTotalInput";
            this.lbTotalInput.Size = new System.Drawing.Size(56, 24);
            this.lbTotalInput.TabIndex = 3;
            this.lbTotalInput.Text = "Input";
            // 
            // lbTotalOutput
            // 
            this.lbTotalOutput.AutoSize = true;
            this.lbTotalOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalOutput.Location = new System.Drawing.Point(150, 59);
            this.lbTotalOutput.Name = "lbTotalOutput";
            this.lbTotalOutput.Size = new System.Drawing.Size(72, 24);
            this.lbTotalOutput.TabIndex = 4;
            this.lbTotalOutput.Text = "Output";
            // 
            // lbTotalYield
            // 
            this.lbTotalYield.AutoSize = true;
            this.lbTotalYield.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalYield.Location = new System.Drawing.Point(150, 83);
            this.lbTotalYield.Name = "lbTotalYield";
            this.lbTotalYield.Size = new System.Drawing.Size(57, 24);
            this.lbTotalYield.TabIndex = 5;
            this.lbTotalYield.Text = "Yield";
            // 
            // dgvDataTracking
            // 
            this.dgvDataTracking.AllowUserToAddRows = false;
            this.dgvDataTracking.AllowUserToDeleteRows = false;
            this.dgvDataTracking.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDataTracking.BackgroundColor = System.Drawing.Color.White;
            this.dgvDataTracking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataTracking.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.assy,
            this.process,
            this.process_in,
            this.process_out,
            this.ng_product,
            this.ng_rate});
            this.dgvDataTracking.Location = new System.Drawing.Point(228, 6);
            this.dgvDataTracking.Name = "dgvDataTracking";
            this.dgvDataTracking.ReadOnly = true;
            this.dgvDataTracking.Size = new System.Drawing.Size(646, 341);
            this.dgvDataTracking.TabIndex = 6;
            // 
            // assy
            // 
            this.assy.HeaderText = "Assy";
            this.assy.Name = "assy";
            this.assy.ReadOnly = true;
            // 
            // process
            // 
            this.process.HeaderText = "Process";
            this.process.Name = "process";
            this.process.ReadOnly = true;
            // 
            // process_in
            // 
            this.process_in.HeaderText = "Input";
            this.process_in.Name = "process_in";
            this.process_in.ReadOnly = true;
            // 
            // process_out
            // 
            this.process_out.HeaderText = "Output";
            this.process_out.Name = "process_out";
            this.process_out.ReadOnly = true;
            // 
            // ng_product
            // 
            this.ng_product.HeaderText = "NG Product";
            this.ng_product.Name = "ng_product";
            this.ng_product.ReadOnly = true;
            // 
            // ng_rate
            // 
            this.ng_rate.HeaderText = "NG Rate";
            this.ng_rate.Name = "ng_rate";
            this.ng_rate.ReadOnly = true;
            // 
            // btnTrackSetting
            // 
            this.btnTrackSetting.Image = ((System.Drawing.Image)(resources.GetObject("btnTrackSetting.Image")));
            this.btnTrackSetting.Location = new System.Drawing.Point(6, 326);
            this.btnTrackSetting.Name = "btnTrackSetting";
            this.btnTrackSetting.Size = new System.Drawing.Size(44, 24);
            this.btnTrackSetting.TabIndex = 7;
            this.btnTrackSetting.UseVisualStyleBackColor = true;
            // 
            // lbModel
            // 
            this.lbModel.AutoSize = true;
            this.lbModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbModel.Location = new System.Drawing.Point(150, 11);
            this.lbModel.Name = "lbModel";
            this.lbModel.Size = new System.Drawing.Size(68, 24);
            this.lbModel.TabIndex = 9;
            this.lbModel.Text = "Model";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(64, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 24);
            this.label13.TabIndex = 8;
            this.label13.Text = "Model :";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 404);
            this.Controls.Add(this.grt_Main);
            this.Controls.Add(this.statusStrip1);
            this.Name = "MainForm";
            this.Text = "Yield Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numCounter)).EndInit();
            this.grt_Main.ResumeLayout(false);
            this.tab_YieldMonitor.ResumeLayout(false);
            this.tab_Track.ResumeLayout(false);
            this.tab_Track.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTracking)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.ComponentModel.BackgroundWorker bwSend;
        private System.Windows.Forms.ToolStripStatusLabel tsStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsCounter;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.FlowLayoutPanel flpnlYeildShow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numCounter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.TabControl grt_Main;
        private System.Windows.Forms.TabPage tab_YieldMonitor;
        private System.Windows.Forms.TabPage tab_Track;
        private System.Windows.Forms.Label lbTotalYield;
        private System.Windows.Forms.Label lbTotalOutput;
        private System.Windows.Forms.Label lbTotalInput;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvDataTracking;
        private System.Windows.Forms.DataGridViewTextBoxColumn assy;
        private System.Windows.Forms.DataGridViewTextBoxColumn process;
        private System.Windows.Forms.DataGridViewTextBoxColumn process_in;
        private System.Windows.Forms.DataGridViewTextBoxColumn process_out;
        private System.Windows.Forms.DataGridViewTextBoxColumn ng_product;
        private System.Windows.Forms.DataGridViewTextBoxColumn ng_rate;
        private System.Windows.Forms.Button btnTrackSetting;
        private System.Windows.Forms.Label lbModel;
        private System.Windows.Forms.Label label13;
    }
}

