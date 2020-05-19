namespace PC_QRCodeSystem.View
{
    partial class StockOutLogForm
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
            this.tc_Main = new System.Windows.Forms.TabControl();
            this.tab_Inspection = new System.Windows.Forms.TabPage();
            this.dgvInspection = new System.Windows.Forms.DataGridView();
            this.pnlInspection = new System.Windows.Forms.Panel();
            this.txtInQty = new System.Windows.Forms.TextBox();
            this.txtDeliveryDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtItemNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInsInvoice = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btnInsBack = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txtLabelQty = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInspectionClear = new System.Windows.Forms.Button();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsRow = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsTotalQty = new System.Windows.Forms.ToolStripStatusLabel();
            this.tc_Main.SuspendLayout();
            this.tab_Inspection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInspection)).BeginInit();
            this.pnlInspection.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc_Main
            // 
            this.tc_Main.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tc_Main.Controls.Add(this.tab_Inspection);
            this.tc_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_Main.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tc_Main.Location = new System.Drawing.Point(150, 70);
            this.tc_Main.Margin = new System.Windows.Forms.Padding(4);
            this.tc_Main.Name = "tc_Main";
            this.tc_Main.SelectedIndex = 0;
            this.tc_Main.Size = new System.Drawing.Size(1102, 412);
            this.tc_Main.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tc_Main.TabIndex = 4;
            // 
            // tab_Inspection
            // 
            this.tab_Inspection.Controls.Add(this.dgvInspection);
            this.tab_Inspection.Controls.Add(this.pnlInspection);
            this.tab_Inspection.Location = new System.Drawing.Point(4, 28);
            this.tab_Inspection.Margin = new System.Windows.Forms.Padding(4);
            this.tab_Inspection.Name = "tab_Inspection";
            this.tab_Inspection.Padding = new System.Windows.Forms.Padding(4);
            this.tab_Inspection.Size = new System.Drawing.Size(1094, 380);
            this.tab_Inspection.TabIndex = 2;
            this.tab_Inspection.Text = "Inspection";
            this.tab_Inspection.UseVisualStyleBackColor = true;
            // 
            // dgvInspection
            // 
            this.dgvInspection.AllowUserToAddRows = false;
            this.dgvInspection.AllowUserToDeleteRows = false;
            this.dgvInspection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInspection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInspection.Location = new System.Drawing.Point(4, 218);
            this.dgvInspection.Margin = new System.Windows.Forms.Padding(4);
            this.dgvInspection.Name = "dgvInspection";
            this.dgvInspection.ReadOnly = true;
            this.dgvInspection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInspection.Size = new System.Drawing.Size(1086, 158);
            this.dgvInspection.TabIndex = 9;
            // 
            // pnlInspection
            // 
            this.pnlInspection.Controls.Add(this.txtInQty);
            this.pnlInspection.Controls.Add(this.txtDeliveryDate);
            this.pnlInspection.Controls.Add(this.label6);
            this.pnlInspection.Controls.Add(this.txtItemNumber);
            this.pnlInspection.Controls.Add(this.label5);
            this.pnlInspection.Controls.Add(this.label4);
            this.pnlInspection.Controls.Add(this.txtInsInvoice);
            this.pnlInspection.Controls.Add(this.label18);
            this.pnlInspection.Controls.Add(this.txtItemName);
            this.pnlInspection.Controls.Add(this.label3);
            this.pnlInspection.Controls.Add(this.label19);
            this.pnlInspection.Controls.Add(this.btnInsBack);
            this.pnlInspection.Controls.Add(this.label16);
            this.pnlInspection.Controls.Add(this.txtLabelQty);
            this.pnlInspection.Controls.Add(this.label11);
            this.pnlInspection.Controls.Add(this.label1);
            this.pnlInspection.Controls.Add(this.btnInspectionClear);
            this.pnlInspection.Controls.Add(this.txtSupplierName);
            this.pnlInspection.Controls.Add(this.label2);
            this.pnlInspection.Controls.Add(this.btnDelete);
            this.pnlInspection.Controls.Add(this.btnPrint);
            this.pnlInspection.Controls.Add(this.txtBarcode);
            this.pnlInspection.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInspection.Location = new System.Drawing.Point(4, 4);
            this.pnlInspection.Margin = new System.Windows.Forms.Padding(4);
            this.pnlInspection.Name = "pnlInspection";
            this.pnlInspection.Size = new System.Drawing.Size(1086, 214);
            this.pnlInspection.TabIndex = 2;
            // 
            // txtInQty
            // 
            this.txtInQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInQty.Location = new System.Drawing.Point(748, 19);
            this.txtInQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtInQty.Name = "txtInQty";
            this.txtInQty.Size = new System.Drawing.Size(120, 50);
            this.txtInQty.TabIndex = 4;
            this.txtInQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInQty_KeyDown);
            // 
            // txtDeliveryDate
            // 
            this.txtDeliveryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeliveryDate.Location = new System.Drawing.Point(354, 179);
            this.txtDeliveryDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtDeliveryDate.Name = "txtDeliveryDate";
            this.txtDeliveryDate.ReadOnly = true;
            this.txtDeliveryDate.Size = new System.Drawing.Size(292, 23);
            this.txtDeliveryDate.TabIndex = 40;
            this.txtDeliveryDate.TabStop = false;
            this.txtDeliveryDate.Text = "Delivery Date";
            this.txtDeliveryDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(253, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 17);
            this.label6.TabIndex = 39;
            this.label6.Text = "Delivery Date";
            // 
            // txtItemNumber
            // 
            this.txtItemNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemNumber.Location = new System.Drawing.Point(354, 114);
            this.txtItemNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtItemNumber.Name = "txtItemNumber";
            this.txtItemNumber.ReadOnly = true;
            this.txtItemNumber.Size = new System.Drawing.Size(292, 23);
            this.txtItemNumber.TabIndex = 37;
            this.txtItemNumber.TabStop = false;
            this.txtItemNumber.Text = "Item Number";
            this.txtItemNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(246, 117);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 25);
            this.label5.TabIndex = 38;
            this.label5.Text = "Item Number";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label4.Location = new System.Drawing.Point(699, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 36;
            this.label4.Text = "Enter";
            // 
            // txtInsInvoice
            // 
            this.txtInsInvoice.Location = new System.Drawing.Point(118, 149);
            this.txtInsInvoice.Name = "txtInsInvoice";
            this.txtInsInvoice.ReadOnly = true;
            this.txtInsInvoice.Size = new System.Drawing.Size(120, 23);
            this.txtInsInvoice.TabIndex = 35;
            this.txtInsInvoice.TabStop = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(58, 152);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(52, 17);
            this.label18.TabIndex = 34;
            this.label18.Text = "Invoice";
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(354, 77);
            this.txtItemName.Margin = new System.Windows.Forms.Padding(4);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(292, 23);
            this.txtItemName.TabIndex = 33;
            this.txtItemName.TabStop = false;
            this.txtItemName.Text = "Item Name";
            this.txtItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(246, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 32;
            this.label3.Text = "Item Name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(695, 29);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(46, 17);
            this.label19.TabIndex = 30;
            this.label19.Text = "2. Qty";
            // 
            // btnInsBack
            // 
            this.btnInsBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsBack.Location = new System.Drawing.Point(1002, 149);
            this.btnInsBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnInsBack.Name = "btnInsBack";
            this.btnInsBack.Size = new System.Drawing.Size(100, 50);
            this.btnInsBack.TabIndex = 2;
            this.btnInsBack.Text = "Back\r\nTrờ Lại";
            this.btnInsBack.UseVisualStyleBackColor = true;
            this.btnInsBack.Click += new System.EventHandler(this.btnInsBack_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label16.Location = new System.Drawing.Point(68, 35);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 17);
            this.label16.TabIndex = 28;
            this.label16.Text = "Enter";
            // 
            // txtLabelQty
            // 
            this.txtLabelQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLabelQty.Location = new System.Drawing.Point(118, 69);
            this.txtLabelQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtLabelQty.Name = "txtLabelQty";
            this.txtLabelQty.Size = new System.Drawing.Size(120, 50);
            this.txtLabelQty.TabIndex = 5;
            this.txtLabelQty.Text = "1";
            this.txtLabelQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(10, 71);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 40);
            this.label11.TabIndex = 26;
            this.label11.Text = " Label Qty\r\n";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 24;
            this.label1.Text = "1. Barcode";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnInspectionClear
            // 
            this.btnInspectionClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInspectionClear.Location = new System.Drawing.Point(886, 149);
            this.btnInspectionClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnInspectionClear.Name = "btnInspectionClear";
            this.btnInspectionClear.Size = new System.Drawing.Size(100, 50);
            this.btnInspectionClear.TabIndex = 8;
            this.btnInspectionClear.Text = "Clear All\r\nXóa Hết";
            this.btnInspectionClear.UseVisualStyleBackColor = true;
            this.btnInspectionClear.Click += new System.EventHandler(this.btnInspectionClear_Click);
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierName.Location = new System.Drawing.Point(354, 149);
            this.txtSupplierName.Margin = new System.Windows.Forms.Padding(4);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.ReadOnly = true;
            this.txtSupplierName.Size = new System.Drawing.Size(292, 23);
            this.txtSupplierName.TabIndex = 8;
            this.txtSupplierName.TabStop = false;
            this.txtSupplierName.Text = "Supplier Name";
            this.txtSupplierName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(246, 152);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 25);
            this.label2.TabIndex = 23;
            this.label2.Text = " Supplier";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(770, 149);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 50);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "4. Delete\r\nXóa Tem";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(654, 152);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 50);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "3. Print        In Tem";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(120, 10);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(4);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(550, 53);
            this.txtBarcode.TabIndex = 3;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel4,
            this.tsRow,
            this.tsTime,
            this.toolStripStatusLabel5,
            this.tsTotalQty});
            this.statusStrip2.Location = new System.Drawing.Point(150, 458);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1102, 24);
            this.statusStrip2.TabIndex = 28;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(40, 19);
            this.toolStripStatusLabel4.Text = "Row :";
            // 
            // tsRow
            // 
            this.tsRow.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsRow.Name = "tsRow";
            this.tsRow.Size = new System.Drawing.Size(40, 19);
            this.tsRow.Text = "None";
            // 
            // tsTime
            // 
            this.tsTime.Name = "tsTime";
            this.tsTime.Size = new System.Drawing.Size(902, 19);
            this.tsTime.Spring = true;
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(69, 19);
            this.toolStripStatusLabel5.Text = "Total Q\'ty :";
            // 
            // tsTotalQty
            // 
            this.tsTotalQty.Name = "tsTotalQty";
            this.tsTotalQty.Size = new System.Drawing.Size(36, 19);
            this.tsTotalQty.Text = "None";
            // 
            // StockOutLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 482);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.tc_Main);
            this.dept = "";
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listper = null;
            this.logintime = new System.DateTime(((long)(0)));
            this.name = "";
            this.Name = "StockOutLogForm";
            this.position = "";
            this.Text = "StockOutForm";
            this.tittle = "FormCommon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.StockOutLogForm_Load);
            this.Controls.SetChildIndex(this.tc_Main, 0);
            this.Controls.SetChildIndex(this.statusStrip2, 0);
            this.tc_Main.ResumeLayout(false);
            this.tab_Inspection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInspection)).EndInit();
            this.pnlInspection.ResumeLayout(false);
            this.pnlInspection.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tc_Main;
        private System.Windows.Forms.TabPage tab_Inspection;
        private System.Windows.Forms.DataGridView dgvInspection;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel tsRow;
        private System.Windows.Forms.ToolStripStatusLabel tsTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel tsTotalQty;
        private System.Windows.Forms.Panel pnlInspection;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnInsBack;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtLabelQty;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInspectionClear;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.TextBox txtInsInvoice;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtItemNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDeliveryDate;
        private System.Windows.Forms.TextBox txtInQty;
    }
}