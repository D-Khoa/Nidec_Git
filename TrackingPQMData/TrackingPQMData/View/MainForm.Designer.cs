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
            this.grt_Main = new System.Windows.Forms.TabControl();
            this.tab_Main = new System.Windows.Forms.TabPage();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trvProcess = new System.Windows.Forms.TreeView();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.pnlButtonMain = new System.Windows.Forms.Panel();
            this.btnChartMain = new System.Windows.Forms.Button();
            this.btnDataMain = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.tab_Chart = new System.Windows.Forms.TabPage();
            this.flp_Chart = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlButtonChart = new System.Windows.Forms.Panel();
            this.btnDataChart = new System.Windows.Forms.Button();
            this.btnMainMenuChart = new System.Windows.Forms.Button();
            this.tab_Data = new System.Windows.Forms.TabPage();
            this.flp_Data = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlButtonData = new System.Windows.Forms.Panel();
            this.btnChartData = new System.Windows.Forms.Button();
            this.btnMainData = new System.Windows.Forms.Button();
            this.stt_Main = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.numTimer = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.grt_Main.SuspendLayout();
            this.tab_Main.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlButtonMain.SuspendLayout();
            this.tab_Chart.SuspendLayout();
            this.pnlButtonChart.SuspendLayout();
            this.tab_Data.SuspendLayout();
            this.pnlButtonData.SuspendLayout();
            this.stt_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimer)).BeginInit();
            this.SuspendLayout();
            // 
            // grt_Main
            // 
            this.grt_Main.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.grt_Main.Controls.Add(this.tab_Main);
            this.grt_Main.Controls.Add(this.tab_Chart);
            this.grt_Main.Controls.Add(this.tab_Data);
            this.grt_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grt_Main.Location = new System.Drawing.Point(0, 69);
            this.grt_Main.Name = "grt_Main";
            this.grt_Main.SelectedIndex = 0;
            this.grt_Main.Size = new System.Drawing.Size(829, 391);
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
            this.tab_Main.Size = new System.Drawing.Size(821, 362);
            this.tab_Main.TabIndex = 0;
            this.tab_Main.Text = "Main";
            this.tab_Main.UseVisualStyleBackColor = true;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label7);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.numTimer);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.dtpEnd);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.trvProcess);
            this.pnlMain.Controls.Add(this.dtpBegin);
            this.pnlMain.Controls.Add(this.dtpDate);
            this.pnlMain.Controls.Add(this.cmbModel);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(3, 53);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(815, 306);
            this.pnlMain.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Date";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "HH:mm";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(120, 100);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.ShowUpDown = true;
            this.dtpEnd.Size = new System.Drawing.Size(120, 20);
            this.dtpEnd.TabIndex = 9;
            this.dtpEnd.Value = new System.DateTime(2020, 1, 4, 23, 59, 0, 0);
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
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Begin";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "End";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Model";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trvProcess
            // 
            this.trvProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvProcess.Location = new System.Drawing.Point(370, 10);
            this.trvProcess.Name = "trvProcess";
            this.trvProcess.Size = new System.Drawing.Size(440, 280);
            this.trvProcess.TabIndex = 3;
            // 
            // dtpBegin
            // 
            this.dtpBegin.CustomFormat = "HH:mm";
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBegin.Location = new System.Drawing.Point(120, 70);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.ShowUpDown = true;
            this.dtpBegin.Size = new System.Drawing.Size(120, 20);
            this.dtpBegin.TabIndex = 5;
            this.dtpBegin.Value = new System.DateTime(2020, 1, 4, 0, 0, 0, 0);
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "yyyy-MM-dd";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(120, 40);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(120, 20);
            this.dtpDate.TabIndex = 4;
            // 
            // cmbModel
            // 
            this.cmbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Location = new System.Drawing.Point(120, 10);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(120, 21);
            this.cmbModel.TabIndex = 0;
            // 
            // pnlButtonMain
            // 
            this.pnlButtonMain.Controls.Add(this.btnChartMain);
            this.pnlButtonMain.Controls.Add(this.btnDataMain);
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
            this.btnChartMain.Location = new System.Drawing.Point(725, 5);
            this.btnChartMain.Name = "btnChartMain";
            this.btnChartMain.Size = new System.Drawing.Size(80, 40);
            this.btnChartMain.TabIndex = 3;
            this.btnChartMain.Text = "Chart";
            this.btnChartMain.UseVisualStyleBackColor = true;
            this.btnChartMain.Click += new System.EventHandler(this.OpenChart);
            // 
            // btnDataMain
            // 
            this.btnDataMain.Location = new System.Drawing.Point(635, 5);
            this.btnDataMain.Name = "btnDataMain";
            this.btnDataMain.Size = new System.Drawing.Size(80, 40);
            this.btnDataMain.TabIndex = 2;
            this.btnDataMain.Text = "Data";
            this.btnDataMain.UseVisualStyleBackColor = true;
            this.btnDataMain.Click += new System.EventHandler(this.OpenData);
            // 
            // btnStop
            // 
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
            this.tab_Chart.Size = new System.Drawing.Size(821, 362);
            this.tab_Chart.TabIndex = 1;
            this.tab_Chart.Text = "Chart";
            this.tab_Chart.UseVisualStyleBackColor = true;
            // 
            // flp_Chart
            // 
            this.flp_Chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_Chart.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_Chart.Location = new System.Drawing.Point(3, 53);
            this.flp_Chart.Name = "flp_Chart";
            this.flp_Chart.Size = new System.Drawing.Size(815, 306);
            this.flp_Chart.TabIndex = 0;
            // 
            // pnlButtonChart
            // 
            this.pnlButtonChart.Controls.Add(this.btnDataChart);
            this.pnlButtonChart.Controls.Add(this.btnMainMenuChart);
            this.pnlButtonChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtonChart.Location = new System.Drawing.Point(3, 3);
            this.pnlButtonChart.Name = "pnlButtonChart";
            this.pnlButtonChart.Size = new System.Drawing.Size(815, 50);
            this.pnlButtonChart.TabIndex = 0;
            // 
            // btnDataChart
            // 
            this.btnDataChart.Location = new System.Drawing.Point(635, 5);
            this.btnDataChart.Name = "btnDataChart";
            this.btnDataChart.Size = new System.Drawing.Size(80, 40);
            this.btnDataChart.TabIndex = 3;
            this.btnDataChart.Text = "Data";
            this.btnDataChart.UseVisualStyleBackColor = true;
            this.btnDataChart.Click += new System.EventHandler(this.OpenData);
            // 
            // btnMainMenuChart
            // 
            this.btnMainMenuChart.Location = new System.Drawing.Point(725, 5);
            this.btnMainMenuChart.Name = "btnMainMenuChart";
            this.btnMainMenuChart.Size = new System.Drawing.Size(80, 40);
            this.btnMainMenuChart.TabIndex = 1;
            this.btnMainMenuChart.Text = "Main Menu";
            this.btnMainMenuChart.UseVisualStyleBackColor = true;
            this.btnMainMenuChart.Click += new System.EventHandler(this.OpenMainMenu);
            // 
            // tab_Data
            // 
            this.tab_Data.Controls.Add(this.flp_Data);
            this.tab_Data.Controls.Add(this.pnlButtonData);
            this.tab_Data.Location = new System.Drawing.Point(4, 25);
            this.tab_Data.Name = "tab_Data";
            this.tab_Data.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Data.Size = new System.Drawing.Size(821, 362);
            this.tab_Data.TabIndex = 2;
            this.tab_Data.Text = "Data";
            this.tab_Data.UseVisualStyleBackColor = true;
            // 
            // flp_Data
            // 
            this.flp_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_Data.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_Data.Location = new System.Drawing.Point(3, 53);
            this.flp_Data.Name = "flp_Data";
            this.flp_Data.Size = new System.Drawing.Size(815, 306);
            this.flp_Data.TabIndex = 2;
            // 
            // pnlButtonData
            // 
            this.pnlButtonData.Controls.Add(this.btnChartData);
            this.pnlButtonData.Controls.Add(this.btnMainData);
            this.pnlButtonData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtonData.Location = new System.Drawing.Point(3, 3);
            this.pnlButtonData.Name = "pnlButtonData";
            this.pnlButtonData.Size = new System.Drawing.Size(815, 50);
            this.pnlButtonData.TabIndex = 1;
            // 
            // btnChartData
            // 
            this.btnChartData.Location = new System.Drawing.Point(635, 5);
            this.btnChartData.Name = "btnChartData";
            this.btnChartData.Size = new System.Drawing.Size(80, 40);
            this.btnChartData.TabIndex = 3;
            this.btnChartData.Text = "Chart";
            this.btnChartData.UseVisualStyleBackColor = true;
            this.btnChartData.Click += new System.EventHandler(this.OpenChart);
            // 
            // btnMainData
            // 
            this.btnMainData.Location = new System.Drawing.Point(725, 5);
            this.btnMainData.Name = "btnMainData";
            this.btnMainData.Size = new System.Drawing.Size(80, 40);
            this.btnMainData.TabIndex = 1;
            this.btnMainData.Text = "Main Menu";
            this.btnMainData.UseVisualStyleBackColor = true;
            this.btnMainData.Click += new System.EventHandler(this.OpenMainMenu);
            // 
            // stt_Main
            // 
            this.stt_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.stt_Main.Location = new System.Drawing.Point(0, 460);
            this.stt_Main.Name = "stt_Main";
            this.stt_Main.Size = new System.Drawing.Size(829, 22);
            this.stt_Main.TabIndex = 3;
            this.stt_Main.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(738, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(40, 17);
            this.toolStripStatusLabel2.Text = "Time :";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(36, 17);
            this.toolStripStatusLabel3.Text = "None";
            // 
            // numTimer
            // 
            this.numTimer.Location = new System.Drawing.Point(120, 130);
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
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(10, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Timer";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(190, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "(min)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Controls.SetChildIndex(this.stt_Main, 0);
            this.Controls.SetChildIndex(this.grt_Main, 0);
            this.grt_Main.ResumeLayout(false);
            this.tab_Main.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlButtonMain.ResumeLayout(false);
            this.tab_Chart.ResumeLayout(false);
            this.pnlButtonChart.ResumeLayout(false);
            this.tab_Data.ResumeLayout(false);
            this.pnlButtonData.ResumeLayout(false);
            this.stt_Main.ResumeLayout(false);
            this.stt_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimer)).EndInit();
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
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnMainMenuChart;
        private System.Windows.Forms.Button btnChartMain;
        private System.Windows.Forms.Button btnDataMain;
        private System.Windows.Forms.Button btnDataChart;
        private System.Windows.Forms.TabPage tab_Data;
        private System.Windows.Forms.Panel pnlButtonData;
        private System.Windows.Forms.Button btnChartData;
        private System.Windows.Forms.Button btnMainData;
        private System.Windows.Forms.FlowLayoutPanel flp_Data;
        private System.Windows.Forms.NumericUpDown numTimer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}