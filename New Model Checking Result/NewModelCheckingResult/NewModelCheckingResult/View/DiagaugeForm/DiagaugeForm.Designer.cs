namespace NewModelCheckingResult.View.DiagaugeForm
{
    partial class DiagaugeForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEditMaster = new System.Windows.Forms.Button();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tcDiagauge = new System.Windows.Forms.TabControl();
            this.tabModel = new System.Windows.Forms.TabPage();
            this.tabData = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtLotno = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtInvoice = new System.Windows.Forms.TextBox();
            this.txtInputor = new System.Windows.Forms.TextBox();
            this.txtInspector = new System.Windows.Forms.TextBox();
            this.txtVendorName = new System.Windows.Forms.TextBox();
            this.txtPurpose = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtPartNo = new System.Windows.Forms.TextBox();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.tcDiagauge.SuspendLayout();
            this.tabModel.SuspendLayout();
            this.tabData.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnEditMaster);
            this.panel2.Controls.Add(this.cmbModel);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(875, 78);
            this.panel2.TabIndex = 8;
            // 
            // btnEditMaster
            // 
            this.btnEditMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditMaster.Location = new System.Drawing.Point(294, 6);
            this.btnEditMaster.Name = "btnEditMaster";
            this.btnEditMaster.Size = new System.Drawing.Size(97, 47);
            this.btnEditMaster.TabIndex = 2;
            this.btnEditMaster.Text = "Edit Master";
            this.btnEditMaster.UseVisualStyleBackColor = true;
            this.btnEditMaster.Click += new System.EventHandler(this.btnEditMaster_Click);
            // 
            // cmbModel
            // 
            this.cmbModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Location = new System.Drawing.Point(67, 17);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(146, 24);
            this.cmbModel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Model";
            // 
            // tcDiagauge
            // 
            this.tcDiagauge.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tcDiagauge.Controls.Add(this.tabModel);
            this.tcDiagauge.Controls.Add(this.tabData);
            this.tcDiagauge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDiagauge.Location = new System.Drawing.Point(150, 70);
            this.tcDiagauge.Name = "tcDiagauge";
            this.tcDiagauge.SelectedIndex = 0;
            this.tcDiagauge.Size = new System.Drawing.Size(889, 424);
            this.tcDiagauge.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tcDiagauge.TabIndex = 9;
            // 
            // tabModel
            // 
            this.tabModel.Controls.Add(this.panel2);
            this.tabModel.Location = new System.Drawing.Point(4, 25);
            this.tabModel.Name = "tabModel";
            this.tabModel.Padding = new System.Windows.Forms.Padding(3);
            this.tabModel.Size = new System.Drawing.Size(881, 395);
            this.tabModel.TabIndex = 0;
            this.tabModel.Text = "Model";
            this.tabModel.UseVisualStyleBackColor = true;
            // 
            // tabData
            // 
            this.tabData.Controls.Add(this.panel4);
            this.tabData.Location = new System.Drawing.Point(4, 25);
            this.tabData.Name = "tabData";
            this.tabData.Padding = new System.Windows.Forms.Padding(3);
            this.tabData.Size = new System.Drawing.Size(881, 395);
            this.tabData.TabIndex = 1;
            this.tabData.Text = "Data";
            this.tabData.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dtpDate);
            this.panel4.Controls.Add(this.txtLotno);
            this.panel4.Controls.Add(this.txtQuantity);
            this.panel4.Controls.Add(this.txtInvoice);
            this.panel4.Controls.Add(this.txtInputor);
            this.panel4.Controls.Add(this.txtInspector);
            this.panel4.Controls.Add(this.txtVendorName);
            this.panel4.Controls.Add(this.txtPurpose);
            this.panel4.Controls.Add(this.txtModel);
            this.panel4.Controls.Add(this.txtPartNo);
            this.panel4.Controls.Add(this.txtPartName);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(875, 146);
            this.panel4.TabIndex = 3;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(677, 10);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(154, 23);
            this.dtpDate.TabIndex = 8;
            // 
            // txtLotno
            // 
            this.txtLotno.Location = new System.Drawing.Point(360, 70);
            this.txtLotno.Name = "txtLotno";
            this.txtLotno.Size = new System.Drawing.Size(154, 23);
            this.txtLotno.TabIndex = 7;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(360, 40);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(154, 23);
            this.txtQuantity.TabIndex = 6;
            // 
            // txtInvoice
            // 
            this.txtInvoice.Location = new System.Drawing.Point(360, 10);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(154, 23);
            this.txtInvoice.TabIndex = 5;
            // 
            // txtInputor
            // 
            this.txtInputor.Location = new System.Drawing.Point(677, 100);
            this.txtInputor.Name = "txtInputor";
            this.txtInputor.Size = new System.Drawing.Size(154, 23);
            this.txtInputor.TabIndex = 11;
            // 
            // txtInspector
            // 
            this.txtInspector.Location = new System.Drawing.Point(677, 70);
            this.txtInspector.Name = "txtInspector";
            this.txtInspector.Size = new System.Drawing.Size(154, 23);
            this.txtInspector.TabIndex = 10;
            // 
            // txtVendorName
            // 
            this.txtVendorName.Location = new System.Drawing.Point(677, 40);
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.Size = new System.Drawing.Size(154, 23);
            this.txtVendorName.TabIndex = 9;
            // 
            // txtPurpose
            // 
            this.txtPurpose.Location = new System.Drawing.Point(90, 100);
            this.txtPurpose.Name = "txtPurpose";
            this.txtPurpose.Size = new System.Drawing.Size(154, 23);
            this.txtPurpose.TabIndex = 4;
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(90, 70);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(154, 23);
            this.txtModel.TabIndex = 3;
            // 
            // txtPartNo
            // 
            this.txtPartNo.Location = new System.Drawing.Point(90, 40);
            this.txtPartNo.Name = "txtPartNo";
            this.txtPartNo.Size = new System.Drawing.Size(154, 23);
            this.txtPartNo.TabIndex = 2;
            // 
            // txtPartName
            // 
            this.txtPartName.Location = new System.Drawing.Point(90, 10);
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.Size = new System.Drawing.Size(154, 23);
            this.txtPartName.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(575, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 17);
            this.label9.TabIndex = 10;
            this.label9.Text = "Inputor";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(575, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 17);
            this.label13.TabIndex = 9;
            this.label13.Text = "Inspector";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(575, 40);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 17);
            this.label14.TabIndex = 8;
            this.label14.Text = "Vendor Name";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(575, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 17);
            this.label15.TabIndex = 7;
            this.label15.Text = "Date";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(300, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 17);
            this.label10.TabIndex = 6;
            this.label10.Text = "Lot no";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(300, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 17);
            this.label11.TabIndex = 5;
            this.label11.Text = "Quantity";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(300, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 17);
            this.label12.TabIndex = 4;
            this.label12.Text = "Invoice";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 17);
            this.label8.TabIndex = 3;
            this.label8.Text = "Purpose";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Model";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Part No";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Part Name";
            // 
            // DiagaugeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 494);
            this.Controls.Add(this.tcDiagauge);
            this.name = "";
            this.Name = "DiagaugeForm";
            this.Text = "DiagaugeForm";
            this.tittle = "FormCommon";
            this.Load += new System.EventHandler(this.DiagaugeForm_Load);
            this.Controls.SetChildIndex(this.tcDiagauge, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tcDiagauge.ResumeLayout(false);
            this.tabModel.ResumeLayout(false);
            this.tabData.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tcDiagauge;
        private System.Windows.Forms.TabPage tabModel;
        private System.Windows.Forms.TabPage tabData;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtLotno;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtInvoice;
        private System.Windows.Forms.TextBox txtInputor;
        private System.Windows.Forms.TextBox txtInspector;
        private System.Windows.Forms.TextBox txtVendorName;
        private System.Windows.Forms.TextBox txtPurpose;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtPartNo;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnEditMaster;
    }
}