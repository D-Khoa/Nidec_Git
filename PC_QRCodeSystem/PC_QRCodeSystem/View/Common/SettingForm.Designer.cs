namespace PC_QRCodeSystem.View
{
    partial class SettingForm
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
            this.btnReset = new System.Windows.Forms.Button();
            this.grPrinter = new System.Windows.Forms.GroupBox();
            this.btnPrinterCheck = new System.Windows.Forms.Button();
            this.lbPrinterStatus = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbPrinter = new System.Windows.Forms.ComboBox();
            this.grPremacFolder = new System.Windows.Forms.GroupBox();
            this.btnBrowserPremac = new System.Windows.Forms.Button();
            this.txtPremacFolder = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grPrinter.SuspendLayout();
            this.grPremacFolder.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(40, 190);
            this.btnReset.Margin = new System.Windows.Forms.Padding(5);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 60);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // grPrinter
            // 
            this.grPrinter.Controls.Add(this.btnPrinterCheck);
            this.grPrinter.Controls.Add(this.lbPrinterStatus);
            this.grPrinter.Controls.Add(this.label13);
            this.grPrinter.Controls.Add(this.label12);
            this.grPrinter.Controls.Add(this.cmbPrinter);
            this.grPrinter.Dock = System.Windows.Forms.DockStyle.Top;
            this.grPrinter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grPrinter.Location = new System.Drawing.Point(0, 80);
            this.grPrinter.Margin = new System.Windows.Forms.Padding(5);
            this.grPrinter.Name = "grPrinter";
            this.grPrinter.Padding = new System.Windows.Forms.Padding(5);
            this.grPrinter.Size = new System.Drawing.Size(584, 100);
            this.grPrinter.TabIndex = 5;
            this.grPrinter.TabStop = false;
            this.grPrinter.Text = "Printer";
            // 
            // btnPrinterCheck
            // 
            this.btnPrinterCheck.Location = new System.Drawing.Point(470, 26);
            this.btnPrinterCheck.Margin = new System.Windows.Forms.Padding(5);
            this.btnPrinterCheck.Name = "btnPrinterCheck";
            this.btnPrinterCheck.Size = new System.Drawing.Size(100, 30);
            this.btnPrinterCheck.TabIndex = 4;
            this.btnPrinterCheck.Text = "Check";
            this.btnPrinterCheck.UseVisualStyleBackColor = true;
            this.btnPrinterCheck.Click += new System.EventHandler(this.btnPrinterCheck_Click);
            // 
            // lbPrinterStatus
            // 
            this.lbPrinterStatus.AutoSize = true;
            this.lbPrinterStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrinterStatus.Location = new System.Drawing.Point(150, 70);
            this.lbPrinterStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbPrinterStatus.Name = "lbPrinterStatus";
            this.lbPrinterStatus.Size = new System.Drawing.Size(46, 17);
            this.lbPrinterStatus.TabIndex = 3;
            this.lbPrinterStatus.Text = "None";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(30, 70);
            this.label13.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 17);
            this.label13.TabIndex = 2;
            this.label13.Text = "Status";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(30, 30);
            this.label12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 17);
            this.label12.TabIndex = 1;
            this.label12.Text = "Printer";
            // 
            // cmbPrinter
            // 
            this.cmbPrinter.FormattingEnabled = true;
            this.cmbPrinter.Location = new System.Drawing.Point(150, 30);
            this.cmbPrinter.Margin = new System.Windows.Forms.Padding(5);
            this.cmbPrinter.Name = "cmbPrinter";
            this.cmbPrinter.Size = new System.Drawing.Size(200, 24);
            this.cmbPrinter.TabIndex = 0;
            // 
            // grPremacFolder
            // 
            this.grPremacFolder.Controls.Add(this.btnBrowserPremac);
            this.grPremacFolder.Controls.Add(this.txtPremacFolder);
            this.grPremacFolder.Controls.Add(this.label11);
            this.grPremacFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.grPremacFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grPremacFolder.Location = new System.Drawing.Point(0, 0);
            this.grPremacFolder.Margin = new System.Windows.Forms.Padding(5);
            this.grPremacFolder.Name = "grPremacFolder";
            this.grPremacFolder.Padding = new System.Windows.Forms.Padding(5);
            this.grPremacFolder.Size = new System.Drawing.Size(584, 80);
            this.grPremacFolder.TabIndex = 6;
            this.grPremacFolder.TabStop = false;
            this.grPremacFolder.Text = "Premac Folder";
            // 
            // btnBrowserPremac
            // 
            this.btnBrowserPremac.Location = new System.Drawing.Point(470, 26);
            this.btnBrowserPremac.Margin = new System.Windows.Forms.Padding(5);
            this.btnBrowserPremac.Name = "btnBrowserPremac";
            this.btnBrowserPremac.Size = new System.Drawing.Size(100, 30);
            this.btnBrowserPremac.TabIndex = 2;
            this.btnBrowserPremac.Text = "Browser";
            this.btnBrowserPremac.UseVisualStyleBackColor = true;
            this.btnBrowserPremac.Click += new System.EventHandler(this.btnBrowserPremac_Click);
            // 
            // txtPremacFolder
            // 
            this.txtPremacFolder.Location = new System.Drawing.Point(150, 30);
            this.txtPremacFolder.Margin = new System.Windows.Forms.Padding(5);
            this.txtPremacFolder.Name = "txtPremacFolder";
            this.txtPremacFolder.Size = new System.Drawing.Size(300, 23);
            this.txtPremacFolder.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(30, 30);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Premac Folder";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(420, 10);
            this.btnOK.Margin = new System.Windows.Forms.Padding(5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(120, 60);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnOK);
            this.panel5.Controls.Add(this.btnCancel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 259);
            this.panel5.Margin = new System.Windows.Forms.Padding(5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(584, 80);
            this.panel5.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(40, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 60);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 339);
            this.ControlBox = false;
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.grPrinter);
            this.Controls.Add(this.grPremacFolder);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.grPrinter.ResumeLayout(false);
            this.grPrinter.PerformLayout();
            this.grPremacFolder.ResumeLayout(false);
            this.grPremacFolder.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox grPrinter;
        private System.Windows.Forms.Button btnPrinterCheck;
        private System.Windows.Forms.Label lbPrinterStatus;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbPrinter;
        private System.Windows.Forms.GroupBox grPremacFolder;
        private System.Windows.Forms.Button btnBrowserPremac;
        private System.Windows.Forms.TextBox txtPremacFolder;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnCancel;
    }
}