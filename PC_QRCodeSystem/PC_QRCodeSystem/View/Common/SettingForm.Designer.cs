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
            this.checkSave = new System.Windows.Forms.CheckBox();
            this.cbReceive = new System.Windows.Forms.CheckBox();
            this.dtpDateTest = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtInvoiceTest = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQtyTest = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSupplierTest = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtItemCDTest = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtItemNameTest = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrintTest = new System.Windows.Forms.Button();
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
            this.grOutFolder = new System.Windows.Forms.GroupBox();
            this.btnBrowserBackup = new System.Windows.Forms.Button();
            this.txtBackupFolder = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnBrowserOutput = new System.Windows.Forms.Button();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grPass = new System.Windows.Forms.GroupBox();
            this.btnPasswordOK = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkPrint = new System.Windows.Forms.CheckBox();
            this.grPrinter.SuspendLayout();
            this.grPremacFolder.SuspendLayout();
            this.panel5.SuspendLayout();
            this.grOutFolder.SuspendLayout();
            this.grPass.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(211, 31);
            this.btnReset.Margin = new System.Windows.Forms.Padding(5);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 60);
            this.btnReset.TabIndex = 23;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // grPrinter
            // 
            this.grPrinter.Controls.Add(this.checkSave);
            this.grPrinter.Controls.Add(this.cbReceive);
            this.grPrinter.Controls.Add(this.dtpDateTest);
            this.grPrinter.Controls.Add(this.label7);
            this.grPrinter.Controls.Add(this.txtInvoiceTest);
            this.grPrinter.Controls.Add(this.label6);
            this.grPrinter.Controls.Add(this.txtQtyTest);
            this.grPrinter.Controls.Add(this.label5);
            this.grPrinter.Controls.Add(this.txtSupplierTest);
            this.grPrinter.Controls.Add(this.label4);
            this.grPrinter.Controls.Add(this.txtItemCDTest);
            this.grPrinter.Controls.Add(this.label3);
            this.grPrinter.Controls.Add(this.txtItemNameTest);
            this.grPrinter.Controls.Add(this.label2);
            this.grPrinter.Controls.Add(this.btnPrintTest);
            this.grPrinter.Controls.Add(this.btnPrinterCheck);
            this.grPrinter.Controls.Add(this.lbPrinterStatus);
            this.grPrinter.Controls.Add(this.label13);
            this.grPrinter.Controls.Add(this.label12);
            this.grPrinter.Controls.Add(this.cmbPrinter);
            this.grPrinter.Dock = System.Windows.Forms.DockStyle.Top;
            this.grPrinter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grPrinter.Location = new System.Drawing.Point(0, 265);
            this.grPrinter.Margin = new System.Windows.Forms.Padding(5);
            this.grPrinter.Name = "grPrinter";
            this.grPrinter.Padding = new System.Windows.Forms.Padding(5);
            this.grPrinter.Size = new System.Drawing.Size(614, 264);
            this.grPrinter.TabIndex = 4;
            this.grPrinter.TabStop = false;
            this.grPrinter.Text = "Printer";
            // 
            // checkSave
            // 
            this.checkSave.AutoSize = true;
            this.checkSave.Location = new System.Drawing.Point(390, 100);
            this.checkSave.Name = "checkSave";
            this.checkSave.Size = new System.Drawing.Size(124, 21);
            this.checkSave.TabIndex = 22;
            this.checkSave.Text = "Save Database";
            this.checkSave.UseVisualStyleBackColor = true;
            this.checkSave.CheckedChanged += new System.EventHandler(this.checkSave_CheckedChanged);
            // 
            // cbReceive
            // 
            this.cbReceive.AutoSize = true;
            this.cbReceive.Location = new System.Drawing.Point(390, 216);
            this.cbReceive.Name = "cbReceive";
            this.cbReceive.Size = new System.Drawing.Size(86, 21);
            this.cbReceive.TabIndex = 20;
            this.cbReceive.Text = "Received";
            this.cbReceive.UseVisualStyleBackColor = true;
            // 
            // dtpDateTest
            // 
            this.dtpDateTest.CustomFormat = "yyyy-MM-dd";
            this.dtpDateTest.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTest.Location = new System.Drawing.Point(390, 157);
            this.dtpDateTest.Name = "dtpDateTest";
            this.dtpDateTest.Size = new System.Drawing.Size(150, 23);
            this.dtpDateTest.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(320, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Date";
            // 
            // txtInvoiceTest
            // 
            this.txtInvoiceTest.Location = new System.Drawing.Point(390, 127);
            this.txtInvoiceTest.Name = "txtInvoiceTest";
            this.txtInvoiceTest.Size = new System.Drawing.Size(150, 23);
            this.txtInvoiceTest.TabIndex = 17;
            this.txtInvoiceTest.Text = "Invoice";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(320, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Invoice";
            // 
            // txtQtyTest
            // 
            this.txtQtyTest.Location = new System.Drawing.Point(390, 187);
            this.txtQtyTest.Name = "txtQtyTest";
            this.txtQtyTest.Size = new System.Drawing.Size(150, 23);
            this.txtQtyTest.TabIndex = 19;
            this.txtQtyTest.Text = "1";
            this.txtQtyTest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtyTest_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(320, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Qty";
            // 
            // txtSupplierTest
            // 
            this.txtSupplierTest.Location = new System.Drawing.Point(150, 187);
            this.txtSupplierTest.Name = "txtSupplierTest";
            this.txtSupplierTest.Size = new System.Drawing.Size(150, 23);
            this.txtSupplierTest.TabIndex = 16;
            this.txtSupplierTest.Text = "Supplier Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Supplier";
            // 
            // txtItemCDTest
            // 
            this.txtItemCDTest.Location = new System.Drawing.Point(150, 157);
            this.txtItemCDTest.Name = "txtItemCDTest";
            this.txtItemCDTest.Size = new System.Drawing.Size(150, 23);
            this.txtItemCDTest.TabIndex = 15;
            this.txtItemCDTest.Text = "Item Number / User ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Item Number";
            // 
            // txtItemNameTest
            // 
            this.txtItemNameTest.Location = new System.Drawing.Point(150, 127);
            this.txtItemNameTest.Name = "txtItemNameTest";
            this.txtItemNameTest.Size = new System.Drawing.Size(150, 23);
            this.txtItemNameTest.TabIndex = 14;
            this.txtItemNameTest.Text = "Item / User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Item Name";
            // 
            // btnPrintTest
            // 
            this.btnPrintTest.Location = new System.Drawing.Point(30, 217);
            this.btnPrintTest.Margin = new System.Windows.Forms.Padding(5);
            this.btnPrintTest.Name = "btnPrintTest";
            this.btnPrintTest.Size = new System.Drawing.Size(100, 30);
            this.btnPrintTest.TabIndex = 21;
            this.btnPrintTest.Text = "Print Test";
            this.btnPrintTest.UseVisualStyleBackColor = true;
            this.btnPrintTest.Click += new System.EventHandler(this.btnPrintTest_Click);
            // 
            // btnPrinterCheck
            // 
            this.btnPrinterCheck.Location = new System.Drawing.Point(387, 30);
            this.btnPrinterCheck.Margin = new System.Windows.Forms.Padding(5);
            this.btnPrinterCheck.Name = "btnPrinterCheck";
            this.btnPrinterCheck.Size = new System.Drawing.Size(100, 30);
            this.btnPrinterCheck.TabIndex = 13;
            this.btnPrinterCheck.Text = "Check";
            this.btnPrinterCheck.UseVisualStyleBackColor = true;
            this.btnPrinterCheck.Click += new System.EventHandler(this.btnPrinterCheck_Click);
            // 
            // lbPrinterStatus
            // 
            this.lbPrinterStatus.AutoSize = true;
            this.lbPrinterStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrinterStatus.Location = new System.Drawing.Point(150, 97);
            this.lbPrinterStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbPrinterStatus.Name = "lbPrinterStatus";
            this.lbPrinterStatus.Size = new System.Drawing.Size(46, 17);
            this.lbPrinterStatus.TabIndex = 3;
            this.lbPrinterStatus.Text = "None";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(30, 97);
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
            this.cmbPrinter.TabIndex = 12;
            // 
            // grPremacFolder
            // 
            this.grPremacFolder.Controls.Add(this.btnBrowserPremac);
            this.grPremacFolder.Controls.Add(this.txtPremacFolder);
            this.grPremacFolder.Controls.Add(this.label11);
            this.grPremacFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.grPremacFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grPremacFolder.Location = new System.Drawing.Point(0, 80);
            this.grPremacFolder.Margin = new System.Windows.Forms.Padding(5);
            this.grPremacFolder.Name = "grPremacFolder";
            this.grPremacFolder.Padding = new System.Windows.Forms.Padding(5);
            this.grPremacFolder.Size = new System.Drawing.Size(614, 80);
            this.grPremacFolder.TabIndex = 2;
            this.grPremacFolder.TabStop = false;
            this.grPremacFolder.Text = "Premac Folder";
            // 
            // btnBrowserPremac
            // 
            this.btnBrowserPremac.Location = new System.Drawing.Point(470, 26);
            this.btnBrowserPremac.Margin = new System.Windows.Forms.Padding(5);
            this.btnBrowserPremac.Name = "btnBrowserPremac";
            this.btnBrowserPremac.Size = new System.Drawing.Size(100, 30);
            this.btnBrowserPremac.TabIndex = 9;
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
            this.txtPremacFolder.TabIndex = 8;
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
            this.btnOK.Location = new System.Drawing.Point(389, 31);
            this.btnOK.Margin = new System.Windows.Forms.Padding(5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(120, 60);
            this.btnOK.TabIndex = 22;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.checkPrint);
            this.panel5.Controls.Add(this.btnReset);
            this.panel5.Controls.Add(this.btnOK);
            this.panel5.Controls.Add(this.btnCancel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 529);
            this.panel5.Margin = new System.Windows.Forms.Padding(5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(614, 150);
            this.panel5.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(33, 31);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 60);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grOutFolder
            // 
            this.grOutFolder.Controls.Add(this.btnBrowserBackup);
            this.grOutFolder.Controls.Add(this.txtBackupFolder);
            this.grOutFolder.Controls.Add(this.label9);
            this.grOutFolder.Controls.Add(this.btnBrowserOutput);
            this.grOutFolder.Controls.Add(this.txtOutputFolder);
            this.grOutFolder.Controls.Add(this.label1);
            this.grOutFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.grOutFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grOutFolder.Location = new System.Drawing.Point(0, 160);
            this.grOutFolder.Margin = new System.Windows.Forms.Padding(5);
            this.grOutFolder.Name = "grOutFolder";
            this.grOutFolder.Padding = new System.Windows.Forms.Padding(5);
            this.grOutFolder.Size = new System.Drawing.Size(614, 105);
            this.grOutFolder.TabIndex = 3;
            this.grOutFolder.TabStop = false;
            this.grOutFolder.Text = "Output Folder";
            this.grOutFolder.Visible = false;
            // 
            // btnBrowserBackup
            // 
            this.btnBrowserBackup.Location = new System.Drawing.Point(470, 65);
            this.btnBrowserBackup.Margin = new System.Windows.Forms.Padding(5);
            this.btnBrowserBackup.Name = "btnBrowserBackup";
            this.btnBrowserBackup.Size = new System.Drawing.Size(100, 30);
            this.btnBrowserBackup.TabIndex = 14;
            this.btnBrowserBackup.Text = "Browser";
            this.btnBrowserBackup.UseVisualStyleBackColor = true;
            this.btnBrowserBackup.Click += new System.EventHandler(this.btnBrowserBackup_Click);
            // 
            // txtBackupFolder
            // 
            this.txtBackupFolder.Location = new System.Drawing.Point(150, 69);
            this.txtBackupFolder.Margin = new System.Windows.Forms.Padding(5);
            this.txtBackupFolder.Name = "txtBackupFolder";
            this.txtBackupFolder.Size = new System.Drawing.Size(300, 23);
            this.txtBackupFolder.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 69);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 17);
            this.label9.TabIndex = 12;
            this.label9.Text = "Backup Folder";
            // 
            // btnBrowserOutput
            // 
            this.btnBrowserOutput.Location = new System.Drawing.Point(470, 26);
            this.btnBrowserOutput.Margin = new System.Windows.Forms.Padding(5);
            this.btnBrowserOutput.Name = "btnBrowserOutput";
            this.btnBrowserOutput.Size = new System.Drawing.Size(100, 30);
            this.btnBrowserOutput.TabIndex = 11;
            this.btnBrowserOutput.Text = "Browser";
            this.btnBrowserOutput.UseVisualStyleBackColor = true;
            this.btnBrowserOutput.Click += new System.EventHandler(this.btnBrowserOutput_Click);
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Location = new System.Drawing.Point(150, 30);
            this.txtOutputFolder.Margin = new System.Windows.Forms.Padding(5);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.Size = new System.Drawing.Size(300, 23);
            this.txtOutputFolder.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Output Folder";
            // 
            // grPass
            // 
            this.grPass.Controls.Add(this.btnPasswordOK);
            this.grPass.Controls.Add(this.txtPassword);
            this.grPass.Controls.Add(this.label8);
            this.grPass.Dock = System.Windows.Forms.DockStyle.Top;
            this.grPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grPass.Location = new System.Drawing.Point(0, 0);
            this.grPass.Margin = new System.Windows.Forms.Padding(5);
            this.grPass.Name = "grPass";
            this.grPass.Padding = new System.Windows.Forms.Padding(5);
            this.grPass.Size = new System.Drawing.Size(614, 80);
            this.grPass.TabIndex = 1;
            this.grPass.TabStop = false;
            this.grPass.Text = "Unlock Setting";
            // 
            // btnPasswordOK
            // 
            this.btnPasswordOK.Location = new System.Drawing.Point(470, 26);
            this.btnPasswordOK.Margin = new System.Windows.Forms.Padding(5);
            this.btnPasswordOK.Name = "btnPasswordOK";
            this.btnPasswordOK.Size = new System.Drawing.Size(100, 30);
            this.btnPasswordOK.TabIndex = 7;
            this.btnPasswordOK.Text = "OK";
            this.btnPasswordOK.UseVisualStyleBackColor = true;
            this.btnPasswordOK.Click += new System.EventHandler(this.btnPasswordOK_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(150, 30);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(300, 23);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 30);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Password";
            // 
            // checkPrint
            // 
            this.checkPrint.AutoSize = true;
            this.checkPrint.Location = new System.Drawing.Point(390, 3);
            this.checkPrint.Name = "checkPrint";
            this.checkPrint.Size = new System.Drawing.Size(91, 20);
            this.checkPrint.TabIndex = 25;
            this.checkPrint.Text = "Print Large";
            this.checkPrint.UseVisualStyleBackColor = true;
            // 
            // SettingForm
            // 
            this.AcceptButton = this.btnPasswordOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(614, 676);
            this.ControlBox = false;
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.grPrinter);
            this.Controls.Add(this.grOutFolder);
            this.Controls.Add(this.grPremacFolder);
            this.Controls.Add(this.grPass);
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
            this.panel5.PerformLayout();
            this.grOutFolder.ResumeLayout(false);
            this.grOutFolder.PerformLayout();
            this.grPass.ResumeLayout(false);
            this.grPass.PerformLayout();
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
        private System.Windows.Forms.Button btnPrintTest;
        private System.Windows.Forms.GroupBox grOutFolder;
        private System.Windows.Forms.Button btnBrowserOutput;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtInvoiceTest;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtQtyTest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSupplierTest;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtItemCDTest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtItemNameTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDateTest;
        private System.Windows.Forms.GroupBox grPass;
        private System.Windows.Forms.Button btnPasswordOK;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbReceive;
        private System.Windows.Forms.Button btnBrowserBackup;
        private System.Windows.Forms.TextBox txtBackupFolder;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkSave;
        private System.Windows.Forms.CheckBox checkPrint;
    }
}