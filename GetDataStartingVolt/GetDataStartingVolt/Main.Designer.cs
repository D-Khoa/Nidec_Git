namespace GetDataStartingVolt
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnConnect = new System.Windows.Forms.Button();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtxtData = new System.Windows.Forms.RichTextBox();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbPortStatus = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.serPort = new System.IO.Ports.SerialPort(this.components);
            this.timerCheckPort = new System.Windows.Forms.Timer(this.components);
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowserOutput = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rtxtLogs = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(116, 70);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(80, 40);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cmbPort
            // 
            this.cmbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(70, 10);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(121, 21);
            this.cmbPort.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM Port";
            // 
            // rtxtData
            // 
            this.rtxtData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtData.Location = new System.Drawing.Point(3, 3);
            this.rtxtData.Name = "rtxtData";
            this.rtxtData.ReadOnly = true;
            this.rtxtData.Size = new System.Drawing.Size(496, 290);
            this.rtxtData.TabIndex = 6;
            this.rtxtData.Text = "";
            this.rtxtData.TextChanged += new System.EventHandler(this.rtxtData_TextChanged);
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Location = new System.Drawing.Point(70, 40);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(121, 21);
            this.cmbBaudRate.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Baud rate";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbPortStatus);
            this.panel1.Controls.Add(this.btnConnect);
            this.panel1.Controls.Add(this.cmbBaudRate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbPort);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 114);
            this.panel1.TabIndex = 6;
            // 
            // lbPortStatus
            // 
            this.lbPortStatus.AutoSize = true;
            this.lbPortStatus.BackColor = System.Drawing.Color.Yellow;
            this.lbPortStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPortStatus.ForeColor = System.Drawing.Color.Red;
            this.lbPortStatus.Location = new System.Drawing.Point(10, 80);
            this.lbPortStatus.Name = "lbPortStatus";
            this.lbPortStatus.Size = new System.Drawing.Size(94, 17);
            this.lbPortStatus.TabIndex = 5;
            this.lbPortStatus.Text = "Disconnected";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtBarcode);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnBrowserOutput);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtOutputFolder);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1004, 114);
            this.panel2.TabIndex = 7;
            // 
            // serPort
            // 
            this.serPort.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.serPort_ErrorReceived);
            // 
            // timerCheckPort
            // 
            this.timerCheckPort.Interval = 1000;
            this.timerCheckPort.Tick += new System.EventHandler(this.timerCheckPort_Tick);
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Location = new System.Drawing.Point(300, 10);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.ReadOnly = true;
            this.txtOutputFolder.Size = new System.Drawing.Size(300, 20);
            this.txtOutputFolder.TabIndex = 7;
            this.txtOutputFolder.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Output Folder";
            // 
            // btnBrowserOutput
            // 
            this.btnBrowserOutput.Location = new System.Drawing.Point(606, 10);
            this.btnBrowserOutput.Name = "btnBrowserOutput";
            this.btnBrowserOutput.Size = new System.Drawing.Size(80, 21);
            this.btnBrowserOutput.TabIndex = 2;
            this.btnBrowserOutput.Text = "Browser";
            this.btnBrowserOutput.UseVisualStyleBackColor = true;
            this.btnBrowserOutput.Click += new System.EventHandler(this.btnBrowserOutput_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 410);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1004, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(953, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // tsTime
            // 
            this.tsTime.Name = "tsTime";
            this.tsTime.Size = new System.Drawing.Size(36, 17);
            this.tsTime.Text = "None";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.rtxtData, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rtxtLogs, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 114);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1004, 296);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // rtxtLogs
            // 
            this.rtxtLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtLogs.Location = new System.Drawing.Point(505, 3);
            this.rtxtLogs.Name = "rtxtLogs";
            this.rtxtLogs.ReadOnly = true;
            this.rtxtLogs.Size = new System.Drawing.Size(496, 290);
            this.rtxtLogs.TabIndex = 7;
            this.rtxtLogs.Text = "";
            this.rtxtLogs.TextChanged += new System.EventHandler(this.rtxtLogs_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Barcode";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(300, 50);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(300, 53);
            this.txtBarcode.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 432);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Starting Volt Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtxtData;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbPortStatus;
        private System.Windows.Forms.Panel panel2;
        private System.IO.Ports.SerialPort serPort;
        private System.Windows.Forms.Timer timerCheckPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Button btnBrowserOutput;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox rtxtLogs;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label4;
    }
}

