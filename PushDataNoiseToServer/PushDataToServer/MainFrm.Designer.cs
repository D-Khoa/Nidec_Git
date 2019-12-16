namespace PushDataToServer
{
    partial class MainFrm
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
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.btnPush = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.numTimer = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsTimer = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnBrowserFrom = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numTimer)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(48, 53);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(224, 20);
            this.txtFrom.TabIndex = 0;
            // 
            // btnPush
            // 
            this.btnPush.Location = new System.Drawing.Point(195, 91);
            this.btnPush.Name = "btnPush";
            this.btnPush.Size = new System.Drawing.Size(75, 23);
            this.btnPush.TabIndex = 1;
            this.btnPush.Text = "Push";
            this.btnPush.UseVisualStyleBackColor = true;
            this.btnPush.Click += new System.EventHandler(this.btnPush_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "From";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // numTimer
            // 
            this.numTimer.Location = new System.Drawing.Point(134, 92);
            this.numTimer.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numTimer.Name = "numTimer";
            this.numTimer.Size = new System.Drawing.Size(55, 20);
            this.numTimer.TabIndex = 10;
            this.numTimer.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Timer";
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(276, 91);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsTimer});
            this.statusStrip1.Location = new System.Drawing.Point(0, 127);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(366, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsTimer
            // 
            this.tsTimer.Name = "tsTimer";
            this.tsTimer.Size = new System.Drawing.Size(351, 17);
            this.tsTimer.Spring = true;
            this.tsTimer.Text = "0 s";
            // 
            // btnBrowserFrom
            // 
            this.btnBrowserFrom.Location = new System.Drawing.Point(278, 52);
            this.btnBrowserFrom.Name = "btnBrowserFrom";
            this.btnBrowserFrom.Size = new System.Drawing.Size(75, 23);
            this.btnBrowserFrom.TabIndex = 15;
            this.btnBrowserFrom.Text = "Browser";
            this.btnBrowserFrom.UseVisualStyleBackColor = true;
            this.btnBrowserFrom.Click += new System.EventHandler(this.btnBrowserFrom_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Model";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(48, 20);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(121, 20);
            this.txtModel.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(194, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "No";
            // 
            // txtNo
            // 
            this.txtNo.Location = new System.Drawing.Point(230, 20);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(121, 20);
            this.txtNo.TabIndex = 19;
            // 
            // MainFrm
            // 
            this.AcceptButton = this.btnPush;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 149);
            this.Controls.Add(this.txtNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBrowserFrom);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numTimer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPush);
            this.Controls.Add(this.txtFrom);
            this.Name = "MainFrm";
            this.Text = "Push Data To Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
            this.Load += new System.EventHandler(this.MainFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numTimer)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Button btnPush;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.NumericUpDown numTimer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsTimer;
        private System.Windows.Forms.Button btnBrowserFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNo;
    }
}

