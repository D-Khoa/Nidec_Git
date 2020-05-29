namespace PC_QRCodeSystem.View
{
    partial class Form1
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
            this.pnlInspection = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPrintItems = new System.Windows.Forms.Button();
            this.dgvOldData = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnInsBack = new System.Windows.Forms.Button();
            this.btnInspectionClear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtLabelQty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOld = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInQty = new System.Windows.Forms.TextBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.dgvInspection = new System.Windows.Forms.DataGridView();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsRow = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsTotalQty = new System.Windows.Forms.ToolStripStatusLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlInspection.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOldData)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInspection)).BeginInit();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlInspection
            // 
            this.pnlInspection.Controls.Add(this.panel2);
            this.pnlInspection.Controls.Add(this.panel1);
            this.pnlInspection.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInspection.Location = new System.Drawing.Point(150, 70);
            this.pnlInspection.Margin = new System.Windows.Forms.Padding(4);
            this.pnlInspection.Name = "pnlInspection";
            this.pnlInspection.Size = new System.Drawing.Size(1208, 214);
            this.pnlInspection.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnPrintItems);
            this.panel2.Controls.Add(this.dgvOldData);
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnInsBack);
            this.panel2.Controls.Add(this.btnInspectionClear);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 104);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1208, 110);
            this.panel2.TabIndex = 38;
            // 
            // btnPrintItems
            // 
            this.btnPrintItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintItems.Location = new System.Drawing.Point(127, 10);
            this.btnPrintItems.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintItems.Name = "btnPrintItems";
            this.btnPrintItems.Size = new System.Drawing.Size(100, 50);
            this.btnPrintItems.TabIndex = 7;
            this.btnPrintItems.Text = "4. Print Item    In Từng Tem";
            this.btnPrintItems.UseVisualStyleBackColor = true;
            this.btnPrintItems.Click += new System.EventHandler(this.btnPrintItems_Click);
            // 
            // dgvOldData
            // 
            this.dgvOldData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOldData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvOldData.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvOldData.Location = new System.Drawing.Point(569, 0);
            this.dgvOldData.Name = "dgvOldData";
            this.dgvOldData.Size = new System.Drawing.Size(639, 110);
            this.dgvOldData.TabIndex = 9;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Item_Number";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Item_Name";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Supplier_Name";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Invoice";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Qty";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Delivery_Date";
            this.Column6.Name = "Column6";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(7, 10);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 50);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "3. Print All       In Tất Cả";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(247, 10);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 50);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "5. Delete\r\nXóa Tem";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnInsBack
            // 
            this.btnInsBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsBack.Location = new System.Drawing.Point(487, 10);
            this.btnInsBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnInsBack.Name = "btnInsBack";
            this.btnInsBack.Size = new System.Drawing.Size(100, 50);
            this.btnInsBack.TabIndex = 10;
            this.btnInsBack.Text = "7. Back\r\nTrờ Lại";
            this.btnInsBack.UseVisualStyleBackColor = true;
            this.btnInsBack.Click += new System.EventHandler(this.btnInsBack_Click);
            // 
            // btnInspectionClear
            // 
            this.btnInspectionClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInspectionClear.Location = new System.Drawing.Point(367, 10);
            this.btnInspectionClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnInspectionClear.Name = "btnInspectionClear";
            this.btnInspectionClear.Size = new System.Drawing.Size(100, 50);
            this.btnInspectionClear.TabIndex = 9;
            this.btnInspectionClear.Text = "6. Clear All\r\nXóa Hết";
            this.btnInspectionClear.UseVisualStyleBackColor = true;
            this.btnInspectionClear.Click += new System.EventHandler(this.btnInspectionClear_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtLabelQty);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtOld);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtInQty);
            this.panel1.Controls.Add(this.txtBarcode);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1208, 104);
            this.panel1.TabIndex = 37;
            // 
            // txtLabelQty
            // 
            this.txtLabelQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLabelQty.Location = new System.Drawing.Point(761, 30);
            this.txtLabelQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtLabelQty.Name = "txtLabelQty";
            this.txtLabelQty.Size = new System.Drawing.Size(120, 50);
            this.txtLabelQty.TabIndex = 2;
            this.txtLabelQty.Text = "1";
            this.txtLabelQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLabelQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLabelQty_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(690, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "3. Label Qty";
            // 
            // txtOld
            // 
            this.txtOld.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOld.Location = new System.Drawing.Point(1124, 28);
            this.txtOld.Margin = new System.Windows.Forms.Padding(4);
            this.txtOld.Name = "txtOld";
            this.txtOld.Size = new System.Drawing.Size(120, 50);
            this.txtOld.TabIndex = 37;
            this.txtOld.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOld.Visible = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 24;
            this.label1.Text = "1. Barcode";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInQty
            // 
            this.txtInQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInQty.Location = new System.Drawing.Point(983, 30);
            this.txtInQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtInQty.Name = "txtInQty";
            this.txtInQty.Size = new System.Drawing.Size(120, 50);
            this.txtInQty.TabIndex = 4;
            this.txtInQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInQty_KeyDown);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(114, 30);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(4);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(550, 53);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label4.Location = new System.Drawing.Point(944, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Enter";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label16.Location = new System.Drawing.Point(62, 55);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 13);
            this.label16.TabIndex = 28;
            this.label16.Text = "Enter";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(941, 36);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 13);
            this.label19.TabIndex = 30;
            this.label19.Text = "2. Qty";
            // 
            // dgvInspection
            // 
            this.dgvInspection.AllowUserToAddRows = false;
            this.dgvInspection.AllowUserToDeleteRows = false;
            this.dgvInspection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInspection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInspection.Location = new System.Drawing.Point(150, 284);
            this.dgvInspection.Margin = new System.Windows.Forms.Padding(4);
            this.dgvInspection.Name = "dgvInspection";
            this.dgvInspection.ReadOnly = true;
            this.dgvInspection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInspection.Size = new System.Drawing.Size(1208, 171);
            this.dgvInspection.TabIndex = 10;
            this.dgvInspection.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInspection_CellDoubleClick_1);
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel4,
            this.tsRow,
            this.tsTime,
            this.toolStripStatusLabel5,
            this.tsTotalQty});
            this.statusStrip2.Location = new System.Drawing.Point(150, 455);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1208, 24);
            this.statusStrip2.TabIndex = 30;
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
            this.tsTime.Size = new System.Drawing.Size(1008, 19);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label2.Location = new System.Drawing.Point(703, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Enter";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 479);
            this.Controls.Add(this.dgvInspection);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.pnlInspection);
            this.dept = "";
            this.listper = null;
            this.logintime = new System.DateTime(((long)(0)));
            this.name = "";
            this.Name = "Form1";
            this.position = "";
            this.Text = "Stockout";
            this.tittle = "FormCommon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.pnlInspection, 0);
            this.Controls.SetChildIndex(this.statusStrip2, 0);
            this.Controls.SetChildIndex(this.dgvInspection, 0);
            this.pnlInspection.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOldData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInspection)).EndInit();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlInspection;
        private System.Windows.Forms.TextBox txtInQty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnInsBack;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInspectionClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.DataGridView dgvInspection;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel tsRow;
        private System.Windows.Forms.ToolStripStatusLabel tsTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel tsTotalQty;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPrintItems;
        private System.Windows.Forms.DataGridView dgvOldData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.TextBox txtOld;
        private System.Windows.Forms.TextBox txtLabelQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}