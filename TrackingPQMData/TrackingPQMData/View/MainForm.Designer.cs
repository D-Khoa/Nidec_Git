namespace TrackingPQMData.View
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
            this.components = new System.ComponentModel.Container();
            this.grt_Main = new System.Windows.Forms.TabControl();
            this.tab_Main = new System.Windows.Forms.TabPage();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlSetting = new System.Windows.Forms.Panel();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numTimer = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.btnAOI5 = new System.Windows.Forms.Button();
            this.btnAOI6 = new System.Windows.Forms.Button();
            this.btnAOI1 = new System.Windows.Forms.Button();
            this.btnAOI4 = new System.Windows.Forms.Button();
            this.btnAOI2 = new System.Windows.Forms.Button();
            this.btnAOI3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.trvProcess = new System.Windows.Forms.TreeView();
            this.pnlButtonMain = new System.Windows.Forms.Panel();
            this.btnChartMain = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.tab_Chart = new System.Windows.Forms.TabPage();
            this.flp_Chart = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlButtonChart = new System.Windows.Forms.Panel();
            this.btnSpDown = new System.Windows.Forms.Button();
            this.btnSpUp = new System.Windows.Forms.Button();
            this.btnAutoScroll = new System.Windows.Forms.Button();
            this.btnStop2 = new System.Windows.Forms.Button();
            this.btnStart2 = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.tab_AOI = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvAOI1 = new System.Windows.Forms.DataGridView();
            this.pnlButtonData = new System.Windows.Forms.Panel();
            this.btnBack1 = new System.Windows.Forms.Button();
            this.stt_Main = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsTimerCounter = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsRes = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsDataRows = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStopwatch = new System.Windows.Forms.ToolStripStatusLabel();
            this.bwTimer = new System.ComponentModel.BackgroundWorker();
            this.timerScroll = new System.Windows.Forms.Timer(this.components);
            this.grt_Main.SuspendLayout();
            this.tab_Main.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimer)).BeginInit();
            this.pnlButton.SuspendLayout();
            this.pnlButtonMain.SuspendLayout();
            this.tab_Chart.SuspendLayout();
            this.pnlButtonChart.SuspendLayout();
            this.tab_AOI.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAOI1)).BeginInit();
            this.pnlButtonData.SuspendLayout();
            this.stt_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // grt_Main
            // 
            this.grt_Main.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.grt_Main.Controls.Add(this.tab_Main);
            this.grt_Main.Controls.Add(this.tab_Chart);
            this.grt_Main.Controls.Add(this.tab_AOI);
            this.grt_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grt_Main.Location = new System.Drawing.Point(0, 69);
            this.grt_Main.Name = "grt_Main";
            this.grt_Main.SelectedIndex = 0;
            this.grt_Main.Size = new System.Drawing.Size(829, 389);
            this.grt_Main.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.grt_Main.TabIndex = 1;
            // 
            // tab_Main
            // 
            this.tab_Main.Controls.Add(this.pnlMain);
            this.tab_Main.Controls.Add(this.pnlButtonMain);
            this.tab_Main.Location = new System.Drawing.Point(4, 25);
            this.tab_Main.Name = "tab_Main";
            this.tab_Main.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Main.Size = new System.Drawing.Size(821, 360);
            this.tab_Main.TabIndex = 0;
            this.tab_Main.Text = "Main";
            this.tab_Main.UseVisualStyleBackColor = true;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlSetting);
            this.pnlMain.Controls.Add(this.pnlButton);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.trvProcess);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(3, 53);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(815, 304);
            this.pnlMain.TabIndex = 6;
            // 
            // pnlSetting
            // 
            this.pnlSetting.Controls.Add(this.cmbModel);
            this.pnlSetting.Controls.Add(this.dtpDate);
            this.pnlSetting.Controls.Add(this.label7);
            this.pnlSetting.Controls.Add(this.dtpBegin);
            this.pnlSetting.Controls.Add(this.label6);
            this.pnlSetting.Controls.Add(this.label1);
            this.pnlSetting.Controls.Add(this.numTimer);
            this.pnlSetting.Controls.Add(this.label2);
            this.pnlSetting.Controls.Add(this.label5);
            this.pnlSetting.Controls.Add(this.label3);
            this.pnlSetting.Controls.Add(this.dtpEnd);
            this.pnlSetting.Location = new System.Drawing.Point(13, 6);
            this.pnlSetting.Name = "pnlSetting";
            this.pnlSetting.Size = new System.Drawing.Size(280, 168);
            this.pnlSetting.TabIndex = 14;
            // 
            // cmbModel
            // 
            this.cmbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Location = new System.Drawing.Point(121, 5);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(120, 21);
            this.cmbModel.TabIndex = 0;
            this.cmbModel.TextChanged += new System.EventHandler(this.cmbModel_TextChanged);
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "yyyy-MM-dd";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(121, 35);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(120, 20);
            this.dtpDate.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(191, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "(min)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpBegin
            // 
            this.dtpBegin.CustomFormat = "HH:mm";
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBegin.Location = new System.Drawing.Point(121, 65);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.ShowUpDown = true;
            this.dtpBegin.Size = new System.Drawing.Size(120, 20);
            this.dtpBegin.TabIndex = 5;
            this.dtpBegin.Value = new System.DateTime(2020, 1, 4, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(11, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Timer";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Model";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numTimer
            // 
            this.numTimer.Location = new System.Drawing.Point(121, 125);
            this.numTimer.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numTimer.Name = "numTimer";
            this.numTimer.Size = new System.Drawing.Size(60, 20);
            this.numTimer.TabIndex = 4;
            this.numTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTimer.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "End";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(11, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Date";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Begin";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "HH:mm";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(121, 95);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.ShowUpDown = true;
            this.dtpEnd.Size = new System.Drawing.Size(120, 20);
            this.dtpEnd.TabIndex = 9;
            this.dtpEnd.Value = new System.DateTime(2020, 1, 4, 23, 59, 0, 0);
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnAOI5);
            this.pnlButton.Controls.Add(this.btnAOI6);
            this.pnlButton.Controls.Add(this.btnAOI1);
            this.pnlButton.Controls.Add(this.btnAOI4);
            this.pnlButton.Controls.Add(this.btnAOI2);
            this.pnlButton.Controls.Add(this.btnAOI3);
            this.pnlButton.Location = new System.Drawing.Point(13, 180);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(280, 110);
            this.pnlButton.TabIndex = 13;
            // 
            // btnAOI5
            // 
            this.btnAOI5.Location = new System.Drawing.Point(100, 60);
            this.btnAOI5.Name = "btnAOI5";
            this.btnAOI5.Size = new System.Drawing.Size(80, 40);
            this.btnAOI5.TabIndex = 8;
            this.btnAOI5.Text = "AOI5";
            this.btnAOI5.UseVisualStyleBackColor = true;
            this.btnAOI5.Click += new System.EventHandler(this.btnAOI5_Click);
            // 
            // btnAOI6
            // 
            this.btnAOI6.Location = new System.Drawing.Point(190, 60);
            this.btnAOI6.Name = "btnAOI6";
            this.btnAOI6.Size = new System.Drawing.Size(80, 40);
            this.btnAOI6.TabIndex = 2;
            this.btnAOI6.Text = "AOI6";
            this.btnAOI6.UseVisualStyleBackColor = true;
            this.btnAOI6.Click += new System.EventHandler(this.btnAOI6_Click);
            // 
            // btnAOI1
            // 
            this.btnAOI1.Location = new System.Drawing.Point(10, 10);
            this.btnAOI1.Name = "btnAOI1";
            this.btnAOI1.Size = new System.Drawing.Size(80, 40);
            this.btnAOI1.TabIndex = 4;
            this.btnAOI1.Text = "AOI1";
            this.btnAOI1.UseVisualStyleBackColor = true;
            this.btnAOI1.Click += new System.EventHandler(this.btnAOI1_Click);
            // 
            // btnAOI4
            // 
            this.btnAOI4.Location = new System.Drawing.Point(10, 60);
            this.btnAOI4.Name = "btnAOI4";
            this.btnAOI4.Size = new System.Drawing.Size(80, 40);
            this.btnAOI4.TabIndex = 7;
            this.btnAOI4.Text = "AOI4";
            this.btnAOI4.UseVisualStyleBackColor = true;
            this.btnAOI4.Click += new System.EventHandler(this.btnAOI4_Click);
            // 
            // btnAOI2
            // 
            this.btnAOI2.Location = new System.Drawing.Point(100, 10);
            this.btnAOI2.Name = "btnAOI2";
            this.btnAOI2.Size = new System.Drawing.Size(80, 40);
            this.btnAOI2.TabIndex = 6;
            this.btnAOI2.Text = "AOI2";
            this.btnAOI2.UseVisualStyleBackColor = true;
            this.btnAOI2.Click += new System.EventHandler(this.btnAOI2_Click);
            // 
            // btnAOI3
            // 
            this.btnAOI3.Location = new System.Drawing.Point(190, 10);
            this.btnAOI3.Name = "btnAOI3";
            this.btnAOI3.Size = new System.Drawing.Size(80, 40);
            this.btnAOI3.TabIndex = 5;
            this.btnAOI3.Text = "AOI3";
            this.btnAOI3.UseVisualStyleBackColor = true;
            this.btnAOI3.Click += new System.EventHandler(this.btnAOI3_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(260, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Process";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trvProcess
            // 
            this.trvProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvProcess.CheckBoxes = true;
            this.trvProcess.Location = new System.Drawing.Point(370, 10);
            this.trvProcess.Name = "trvProcess";
            this.trvProcess.Size = new System.Drawing.Size(440, 278);
            this.trvProcess.TabIndex = 3;
            this.trvProcess.Visible = false;
            this.trvProcess.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trvProcess_AfterCheck);
            this.trvProcess.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvProcess_AfterCheck);
            this.trvProcess.VisibleChanged += new System.EventHandler(this.trvProcess_VisibleChanged);
            // 
            // pnlButtonMain
            // 
            this.pnlButtonMain.Controls.Add(this.btnChartMain);
            this.pnlButtonMain.Controls.Add(this.btnStop);
            this.pnlButtonMain.Controls.Add(this.btnStart);
            this.pnlButtonMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtonMain.Location = new System.Drawing.Point(3, 3);
            this.pnlButtonMain.Name = "pnlButtonMain";
            this.pnlButtonMain.Size = new System.Drawing.Size(815, 50);
            this.pnlButtonMain.TabIndex = 2;
            // 
            // btnChartMain
            // 
            this.btnChartMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChartMain.Location = new System.Drawing.Point(730, 5);
            this.btnChartMain.Name = "btnChartMain";
            this.btnChartMain.Size = new System.Drawing.Size(80, 40);
            this.btnChartMain.TabIndex = 3;
            this.btnChartMain.Text = "Chart";
            this.btnChartMain.UseVisualStyleBackColor = true;
            this.btnChartMain.Click += new System.EventHandler(this.OpenChart);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(100, 5);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(80, 40);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(10, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(80, 40);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tab_Chart
            // 
            this.tab_Chart.Controls.Add(this.flp_Chart);
            this.tab_Chart.Controls.Add(this.pnlButtonChart);
            this.tab_Chart.Location = new System.Drawing.Point(4, 25);
            this.tab_Chart.Name = "tab_Chart";
            this.tab_Chart.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Chart.Size = new System.Drawing.Size(821, 360);
            this.tab_Chart.TabIndex = 1;
            this.tab_Chart.Text = "Chart";
            this.tab_Chart.UseVisualStyleBackColor = true;
            // 
            // flp_Chart
            // 
            this.flp_Chart.AutoScroll = true;
            this.flp_Chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_Chart.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_Chart.Location = new System.Drawing.Point(3, 53);
            this.flp_Chart.Name = "flp_Chart";
            this.flp_Chart.Size = new System.Drawing.Size(815, 304);
            this.flp_Chart.TabIndex = 0;
            this.flp_Chart.WrapContents = false;
            // 
            // pnlButtonChart
            // 
            this.pnlButtonChart.Controls.Add(this.btnSpDown);
            this.pnlButtonChart.Controls.Add(this.btnSpUp);
            this.pnlButtonChart.Controls.Add(this.btnAutoScroll);
            this.pnlButtonChart.Controls.Add(this.btnStop2);
            this.pnlButtonChart.Controls.Add(this.btnStart2);
            this.pnlButtonChart.Controls.Add(this.btnBack);
            this.pnlButtonChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtonChart.Location = new System.Drawing.Point(3, 3);
            this.pnlButtonChart.Name = "pnlButtonChart";
            this.pnlButtonChart.Size = new System.Drawing.Size(815, 50);
            this.pnlButtonChart.TabIndex = 0;
            // 
            // btnSpDown
            // 
            this.btnSpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSpDown.Location = new System.Drawing.Point(550, 5);
            this.btnSpDown.Name = "btnSpDown";
            this.btnSpDown.Size = new System.Drawing.Size(80, 40);
            this.btnSpDown.TabIndex = 6;
            this.btnSpDown.Text = "Speed Down";
            this.btnSpDown.UseVisualStyleBackColor = true;
            this.btnSpDown.Visible = false;
            this.btnSpDown.Click += new System.EventHandler(this.btnSpDown_Click);
            // 
            // btnSpUp
            // 
            this.btnSpUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSpUp.Location = new System.Drawing.Point(460, 5);
            this.btnSpUp.Name = "btnSpUp";
            this.btnSpUp.Size = new System.Drawing.Size(80, 40);
            this.btnSpUp.TabIndex = 5;
            this.btnSpUp.Text = "Speed Up";
            this.btnSpUp.UseVisualStyleBackColor = true;
            this.btnSpUp.Visible = false;
            this.btnSpUp.Click += new System.EventHandler(this.btnSpUp_Click);
            // 
            // btnAutoScroll
            // 
            this.btnAutoScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoScroll.Location = new System.Drawing.Point(640, 5);
            this.btnAutoScroll.Name = "btnAutoScroll";
            this.btnAutoScroll.Size = new System.Drawing.Size(80, 40);
            this.btnAutoScroll.TabIndex = 4;
            this.btnAutoScroll.Text = "AutoScroll";
            this.btnAutoScroll.UseVisualStyleBackColor = true;
            this.btnAutoScroll.Click += new System.EventHandler(this.btnAutoScroll_Click);
            // 
            // btnStop2
            // 
            this.btnStop2.Enabled = false;
            this.btnStop2.Location = new System.Drawing.Point(100, 5);
            this.btnStop2.Name = "btnStop2";
            this.btnStop2.Size = new System.Drawing.Size(80, 40);
            this.btnStop2.TabIndex = 3;
            this.btnStop2.Text = "Stop";
            this.btnStop2.UseVisualStyleBackColor = true;
            this.btnStop2.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart2
            // 
            this.btnStart2.Location = new System.Drawing.Point(10, 5);
            this.btnStart2.Name = "btnStart2";
            this.btnStart2.Size = new System.Drawing.Size(80, 40);
            this.btnStart2.TabIndex = 2;
            this.btnStart2.Text = "Start";
            this.btnStart2.UseVisualStyleBackColor = true;
            this.btnStart2.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(730, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 40);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.OpenMainMenu);
            // 
            // tab_AOI
            // 
            this.tab_AOI.Controls.Add(this.panel3);
            this.tab_AOI.Controls.Add(this.pnlButtonData);
            this.tab_AOI.Location = new System.Drawing.Point(4, 25);
            this.tab_AOI.Name = "tab_AOI";
            this.tab_AOI.Padding = new System.Windows.Forms.Padding(3);
            this.tab_AOI.Size = new System.Drawing.Size(821, 360);
            this.tab_AOI.TabIndex = 2;
            this.tab_AOI.Text = "AOI Data";
            this.tab_AOI.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvAOI1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 53);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(815, 304);
            this.panel3.TabIndex = 2;
            // 
            // dgvAOI1
            // 
            this.dgvAOI1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAOI1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAOI1.Location = new System.Drawing.Point(0, 0);
            this.dgvAOI1.Name = "dgvAOI1";
            this.dgvAOI1.Size = new System.Drawing.Size(815, 304);
            this.dgvAOI1.TabIndex = 0;
            // 
            // pnlButtonData
            // 
            this.pnlButtonData.Controls.Add(this.btnBack1);
            this.pnlButtonData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtonData.Location = new System.Drawing.Point(3, 3);
            this.pnlButtonData.Name = "pnlButtonData";
            this.pnlButtonData.Size = new System.Drawing.Size(815, 50);
            this.pnlButtonData.TabIndex = 1;
            // 
            // btnBack1
            // 
            this.btnBack1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack1.Location = new System.Drawing.Point(725, 5);
            this.btnBack1.Name = "btnBack1";
            this.btnBack1.Size = new System.Drawing.Size(80, 40);
            this.btnBack1.TabIndex = 1;
            this.btnBack1.Text = "Back";
            this.btnBack1.UseVisualStyleBackColor = true;
            this.btnBack1.Click += new System.EventHandler(this.OpenMainMenu);
            // 
            // stt_Main
            // 
            this.stt_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.tsTimerCounter,
            this.tsRes,
            this.toolStripStatusLabel3,
            this.tsDataRows,
            this.toolStripStatusLabel5,
            this.tsStopwatch});
            this.stt_Main.Location = new System.Drawing.Point(0, 458);
            this.stt_Main.Name = "stt_Main";
            this.stt_Main.Size = new System.Drawing.Size(829, 24);
            this.stt_Main.TabIndex = 3;
            this.stt_Main.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(60, 19);
            this.toolStripStatusLabel2.Text = "Counter :";
            // 
            // tsTimerCounter
            // 
            this.tsTimerCounter.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsTimerCounter.Name = "tsTimerCounter";
            this.tsTimerCounter.Size = new System.Drawing.Size(40, 19);
            this.tsTimerCounter.Text = "None";
            // 
            // tsRes
            // 
            this.tsRes.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tsRes.Name = "tsRes";
            this.tsRes.Size = new System.Drawing.Size(486, 19);
            this.tsRes.Spring = true;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(69, 19);
            this.toolStripStatusLabel3.Text = "Data rows :";
            // 
            // tsDataRows
            // 
            this.tsDataRows.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsDataRows.Name = "tsDataRows";
            this.tsDataRows.Size = new System.Drawing.Size(40, 19);
            this.tsDataRows.Text = "None";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(79, 19);
            this.toolStripStatusLabel5.Text = "Query Time :";
            // 
            // tsStopwatch
            // 
            this.tsStopwatch.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsStopwatch.Name = "tsStopwatch";
            this.tsStopwatch.Size = new System.Drawing.Size(40, 19);
            this.tsStopwatch.Text = "None";
            // 
            // bwTimer
            // 
            this.bwTimer.WorkerReportsProgress = true;
            this.bwTimer.WorkerSupportsCancellation = true;
            this.bwTimer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwTimer_DoWork);
            this.bwTimer.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwTimer_ProgressChanged);
            this.bwTimer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwTimer_RunWorkerCompleted);
            // 
            // timerScroll
            // 
            this.timerScroll.Interval = 30;
            this.timerScroll.Tick += new System.EventHandler(this.timerScroll_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 482);
            this.Controls.Add(this.grt_Main);
            this.Controls.Add(this.stt_Main);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.tittle = "FormCommon";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.Controls.SetChildIndex(this.stt_Main, 0);
            this.Controls.SetChildIndex(this.grt_Main, 0);
            this.grt_Main.ResumeLayout(false);
            this.tab_Main.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlSetting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numTimer)).EndInit();
            this.pnlButton.ResumeLayout(false);
            this.pnlButtonMain.ResumeLayout(false);
            this.tab_Chart.ResumeLayout(false);
            this.pnlButtonChart.ResumeLayout(false);
            this.tab_AOI.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAOI1)).EndInit();
            this.pnlButtonData.ResumeLayout(false);
            this.stt_Main.ResumeLayout(false);
            this.stt_Main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl grt_Main;
        private System.Windows.Forms.TabPage tab_Main;
        private System.Windows.Forms.TabPage tab_Chart;
        private System.Windows.Forms.FlowLayoutPanel flp_Chart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.Panel pnlButtonChart;
        private System.Windows.Forms.Panel pnlButtonMain;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TreeView trvProcess;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.StatusStrip stt_Main;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsTimerCounter;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnChartMain;
        private System.Windows.Forms.Button btnAOI6;
        private System.Windows.Forms.TabPage tab_AOI;
        private System.Windows.Forms.Panel pnlButtonData;
        private System.Windows.Forms.Button btnBack1;
        private System.Windows.Forms.NumericUpDown numTimer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.ComponentModel.BackgroundWorker bwTimer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvAOI1;
        private System.Windows.Forms.Button btnAOI5;
        private System.Windows.Forms.Button btnAOI4;
        private System.Windows.Forms.Button btnAOI2;
        private System.Windows.Forms.Button btnAOI3;
        private System.Windows.Forms.Button btnAOI1;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.ToolStripStatusLabel tsRes;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel tsDataRows;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel tsStopwatch;
        private System.Windows.Forms.Panel pnlSetting;
        private System.Windows.Forms.Button btnStop2;
        private System.Windows.Forms.Button btnStart2;
        private System.Windows.Forms.Button btnAutoScroll;
        private System.Windows.Forms.Timer timerScroll;
        private System.Windows.Forms.Button btnSpDown;
        private System.Windows.Forms.Button btnSpUp;
    }
}