namespace ConvertAndSendData.View
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
            this.btnExport = new System.Windows.Forms.Button();
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
            this.tabexport = new System.Windows.Forms.TabControl();
            this.tabYieldMonitor = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnExportChart = new System.Windows.Forms.Button();
            this.btnSettingChart = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.numCouterChart = new System.Windows.Forms.NumericUpDown();
            this.btnStopChart = new System.Windows.Forms.Button();
            this.btnSearchChart = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpDateToChart = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFromChart = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbModelChart = new System.Windows.Forms.ComboBox();
            this.btnRunChart = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCounter)).BeginInit();
            this.tabexport.SuspendLayout();
            this.tabYieldMonitor.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCouterChart)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatus,
            this.tsCounter});
            this.statusStrip1.Location = new System.Drawing.Point(0, 382);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(891, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsStatus
            // 
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(840, 17);
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
            this.btnRun.Location = new System.Drawing.Point(423, 18);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(64, 55);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // flpnlYeildShow
            // 
            this.flpnlYeildShow.AutoScroll = true;
            this.flpnlYeildShow.Location = new System.Drawing.Point(3, 96);
            this.flpnlYeildShow.Name = "flpnlYeildShow";
            this.flpnlYeildShow.Size = new System.Drawing.Size(874, 286);
            this.flpnlYeildShow.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExport);
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
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(885, 87);
            this.panel1.TabIndex = 3;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(563, 18);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(64, 55);
            this.btnExport.TabIndex = 17;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
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
            this.panel2.Location = new System.Drawing.Point(656, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(229, 87);
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
            this.btnStop.Location = new System.Drawing.Point(493, 18);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(64, 55);
            this.btnStop.TabIndex = 9;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(353, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(64, 55);
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
            this.dtpDateTo.CustomFormat = "yyyy-MM-dd";
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(74, 59);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(139, 20);
            this.dtpDateTo.TabIndex = 5;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = "yyyy-MM-dd";
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
            this.cmbModel.SelectedIndexChanged += new System.EventHandler(this.cmbModel_SelectedIndexChanged);
            this.cmbModel.TextChanged += new System.EventHandler(this.cmbModel_TextChanged);
            // 
            // tabexport
            // 
            this.tabexport.Controls.Add(this.tabYieldMonitor);
            this.tabexport.Controls.Add(this.tabPage1);
            this.tabexport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabexport.Location = new System.Drawing.Point(0, 0);
            this.tabexport.Name = "tabexport";
            this.tabexport.SelectedIndex = 0;
            this.tabexport.Size = new System.Drawing.Size(891, 382);
            this.tabexport.TabIndex = 4;
            // 
            // tabYieldMonitor
            // 
            this.tabYieldMonitor.Controls.Add(this.flpnlYeildShow);
            this.tabYieldMonitor.Controls.Add(this.panel1);
            this.tabYieldMonitor.Location = new System.Drawing.Point(4, 22);
            this.tabYieldMonitor.Name = "tabYieldMonitor";
            this.tabYieldMonitor.Padding = new System.Windows.Forms.Padding(3);
            this.tabYieldMonitor.Size = new System.Drawing.Size(883, 356);
            this.tabYieldMonitor.TabIndex = 0;
            this.tabYieldMonitor.Text = "Yield Mornitor ";
            this.tabYieldMonitor.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(883, 356);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Chart";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnExportChart);
            this.panel3.Controls.Add(this.btnSettingChart);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.numCouterChart);
            this.panel3.Controls.Add(this.btnStopChart);
            this.panel3.Controls.Add(this.btnSearchChart);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.dtpDateToChart);
            this.panel3.Controls.Add(this.dtpDateFromChart);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.cmbModelChart);
            this.panel3.Controls.Add(this.btnRunChart);
            this.panel3.Location = new System.Drawing.Point(0, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(883, 89);
            this.panel3.TabIndex = 0;
            // 
            // btnExportChart
            // 
            this.btnExportChart.Location = new System.Drawing.Point(559, 21);
            this.btnExportChart.Name = "btnExportChart";
            this.btnExportChart.Size = new System.Drawing.Size(64, 55);
            this.btnExportChart.TabIndex = 30;
            this.btnExportChart.Text = "Export";
            this.btnExportChart.UseVisualStyleBackColor = true;
            // 
            // btnSettingChart
            // 
            this.btnSettingChart.Location = new System.Drawing.Point(229, 59);
            this.btnSettingChart.Name = "btnSettingChart";
            this.btnSettingChart.Size = new System.Drawing.Size(77, 23);
            this.btnSettingChart.TabIndex = 29;
            this.btnSettingChart.Text = "Setting";
            this.btnSettingChart.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(229, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 20);
            this.label9.TabIndex = 28;
            this.label9.Text = "Timer (s)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numCouterChart
            // 
            this.numCouterChart.Location = new System.Drawing.Point(229, 35);
            this.numCouterChart.Name = "numCouterChart";
            this.numCouterChart.Size = new System.Drawing.Size(77, 20);
            this.numCouterChart.TabIndex = 27;
            this.numCouterChart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numCouterChart.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnStopChart
            // 
            this.btnStopChart.Enabled = false;
            this.btnStopChart.Location = new System.Drawing.Point(489, 21);
            this.btnStopChart.Name = "btnStopChart";
            this.btnStopChart.Size = new System.Drawing.Size(64, 55);
            this.btnStopChart.TabIndex = 26;
            this.btnStopChart.Text = "Stop";
            this.btnStopChart.UseVisualStyleBackColor = true;
            // 
            // btnSearchChart
            // 
            this.btnSearchChart.Location = new System.Drawing.Point(349, 21);
            this.btnSearchChart.Name = "btnSearchChart";
            this.btnSearchChart.Size = new System.Drawing.Size(64, 55);
            this.btnSearchChart.TabIndex = 25;
            this.btnSearchChart.Text = "Search";
            this.btnSearchChart.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Date To";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Date From";
            // 
            // dtpDateToChart
            // 
            this.dtpDateToChart.CustomFormat = "yyyy-MM-dd";
            this.dtpDateToChart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateToChart.Location = new System.Drawing.Point(70, 62);
            this.dtpDateToChart.Name = "dtpDateToChart";
            this.dtpDateToChart.Size = new System.Drawing.Size(139, 20);
            this.dtpDateToChart.TabIndex = 22;
            // 
            // dtpDateFromChart
            // 
            this.dtpDateFromChart.CustomFormat = "yyyy-MM-dd";
            this.dtpDateFromChart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFromChart.Location = new System.Drawing.Point(70, 36);
            this.dtpDateFromChart.Name = "dtpDateFromChart";
            this.dtpDateFromChart.Size = new System.Drawing.Size(139, 20);
            this.dtpDateFromChart.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Model";
            // 
            // cmbModelChart
            // 
            this.cmbModelChart.FormattingEnabled = true;
            this.cmbModelChart.Location = new System.Drawing.Point(70, 9);
            this.cmbModelChart.Name = "cmbModelChart";
            this.cmbModelChart.Size = new System.Drawing.Size(139, 21);
            this.cmbModelChart.TabIndex = 19;
            this.cmbModelChart.TextChanged += new System.EventHandler(this.cmbModel_TextChanged);
            // 
            // btnRunChart
            // 
            this.btnRunChart.Location = new System.Drawing.Point(419, 21);
            this.btnRunChart.Name = "btnRunChart";
            this.btnRunChart.Size = new System.Drawing.Size(64, 55);
            this.btnRunChart.TabIndex = 18;
            this.btnRunChart.Text = "Run";
            this.btnRunChart.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 404);
            this.Controls.Add(this.tabexport);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Yield Monitor Noise NSTV";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numCounter)).EndInit();
            this.tabexport.ResumeLayout(false);
            this.tabYieldMonitor.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCouterChart)).EndInit();
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
        private System.Windows.Forms.TabControl tabexport;
        private System.Windows.Forms.TabPage tabYieldMonitor;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnExportChart;
        private System.Windows.Forms.Button btnSettingChart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numCouterChart;
        private System.Windows.Forms.Button btnStopChart;
        private System.Windows.Forms.Button btnSearchChart;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpDateToChart;
        private System.Windows.Forms.DateTimePicker dtpDateFromChart;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbModelChart;
        private System.Windows.Forms.Button btnRunChart;
    }
}

