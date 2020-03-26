namespace NewModelCheckingResult.View
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
            this.tbpMain = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtPartNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxID = new System.Windows.Forms.TextBox();
            this.txtInvoice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPurpose = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtVender = new System.Windows.Forms.TextBox();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.cbCheckDate = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAddBox = new System.Windows.Forms.Button();
            this.btnOpenBox = new System.Windows.Forms.Button();
            this.tbpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnMeasurement = new System.Windows.Forms.Button();
            this.btnDeletebox = new System.Windows.Forms.Button();
            this.txtLot = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.tbpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.tbpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbpMain
            // 
            this.tbpMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tbpMain.ColumnCount = 4;
            this.tbpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbpMain.Controls.Add(this.label4, 0, 2);
            this.tbpMain.Controls.Add(this.txtInvoice, 1, 2);
            this.tbpMain.Controls.Add(this.label1, 0, 1);
            this.tbpMain.Controls.Add(this.txtPartNumber, 1, 1);
            this.tbpMain.Controls.Add(this.label5, 0, 0);
            this.tbpMain.Controls.Add(this.txtBoxID, 1, 0);
            this.tbpMain.Controls.Add(this.label3, 2, 1);
            this.tbpMain.Controls.Add(this.txtPartName, 3, 1);
            this.tbpMain.Controls.Add(this.label2, 2, 0);
            this.tbpMain.Controls.Add(this.txtModel, 3, 0);
            this.tbpMain.Controls.Add(this.label6, 2, 2);
            this.tbpMain.Controls.Add(this.txtVender, 3, 2);
            this.tbpMain.Controls.Add(this.label7, 0, 3);
            this.tbpMain.Controls.Add(this.txtLot, 1, 3);
            this.tbpMain.Controls.Add(this.label9, 2, 3);
            this.tbpMain.Controls.Add(this.txtQty, 3, 3);
            this.tbpMain.Controls.Add(this.label8, 0, 4);
            this.tbpMain.Controls.Add(this.txtPurpose, 1, 4);
            this.tbpMain.Controls.Add(this.cbCheckDate, 2, 4);
            this.tbpMain.Controls.Add(this.dtpDate, 3, 4);
            this.tbpMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbpMain.Location = new System.Drawing.Point(150, 70);
            this.tbpMain.Margin = new System.Windows.Forms.Padding(5);
            this.tbpMain.Name = "tbpMain";
            this.tbpMain.RowCount = 5;
            this.tbpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbpMain.Size = new System.Drawing.Size(747, 200);
            this.tbpMain.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 34);
            this.label5.TabIndex = 15;
            this.label5.Text = "Box Code\r\nMã Hộp Dữ Liệu";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(376, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Part Name / Tên Linh Kiện";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(376, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Model";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(563, 5);
            this.txtModel.Margin = new System.Windows.Forms.Padding(4);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(178, 23);
            this.txtModel.TabIndex = 2;
            // 
            // txtPartNumber
            // 
            this.txtPartNumber.Location = new System.Drawing.Point(191, 46);
            this.txtPartNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtPartNumber.Name = "txtPartNumber";
            this.txtPartNumber.Size = new System.Drawing.Size(177, 23);
            this.txtPartNumber.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 34);
            this.label1.TabIndex = 10;
            this.label1.Text = "Part Number\r\nMã Số Linh Kiện";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 34);
            this.label4.TabIndex = 12;
            this.label4.Text = "Invoice\r\nHóa Đơn";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtBoxID
            // 
            this.txtBoxID.Location = new System.Drawing.Point(191, 5);
            this.txtBoxID.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxID.Name = "txtBoxID";
            this.txtBoxID.Size = new System.Drawing.Size(177, 23);
            this.txtBoxID.TabIndex = 4;
            // 
            // txtInvoice
            // 
            this.txtInvoice.Location = new System.Drawing.Point(191, 87);
            this.txtInvoice.Margin = new System.Windows.Forms.Padding(4);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(177, 23);
            this.txtInvoice.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 17);
            this.label8.TabIndex = 20;
            this.label8.Text = "Purpose / Mục Đích";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtPurpose
            // 
            this.txtPurpose.Location = new System.Drawing.Point(191, 169);
            this.txtPurpose.Margin = new System.Windows.Forms.Padding(4);
            this.txtPurpose.Name = "txtPurpose";
            this.txtPurpose.Size = new System.Drawing.Size(177, 23);
            this.txtPurpose.TabIndex = 9;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "yyyy-MM-dd";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(563, 169);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(179, 23);
            this.dtpDate.TabIndex = 7;
            this.dtpDate.Value = new System.DateTime(2020, 3, 21, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(376, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Vender / Nhà Sản Xuất";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtVender
            // 
            this.txtVender.Location = new System.Drawing.Point(563, 87);
            this.txtVender.Margin = new System.Windows.Forms.Padding(4);
            this.txtVender.Name = "txtVender";
            this.txtVender.Size = new System.Drawing.Size(179, 23);
            this.txtVender.TabIndex = 8;
            // 
            // txtPartName
            // 
            this.txtPartName.Location = new System.Drawing.Point(563, 46);
            this.txtPartName.Margin = new System.Windows.Forms.Padding(4);
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.Size = new System.Drawing.Size(179, 23);
            this.txtPartName.TabIndex = 5;
            // 
            // cbCheckDate
            // 
            this.cbCheckDate.AutoSize = true;
            this.cbCheckDate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbCheckDate.Location = new System.Drawing.Point(376, 168);
            this.cbCheckDate.Name = "cbCheckDate";
            this.cbCheckDate.Size = new System.Drawing.Size(147, 21);
            this.cbCheckDate.TabIndex = 6;
            this.cbCheckDate.Text = "Date / Ngày Tháng";
            this.cbCheckDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.cbCheckDate.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearch.Location = new System.Drawing.Point(3, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(109, 54);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search / Tìm Kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.Location = new System.Drawing.Point(150, 330);
            this.dgvMain.MultiSelect = false;
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(747, 164);
            this.dgvMain.TabIndex = 14;
            this.dgvMain.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellDoubleClick);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(655, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(89, 54);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear / Xóa";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAddBox
            // 
            this.btnAddBox.Location = new System.Drawing.Point(118, 3);
            this.btnAddBox.Name = "btnAddBox";
            this.btnAddBox.Size = new System.Drawing.Size(109, 54);
            this.btnAddBox.TabIndex = 11;
            this.btnAddBox.Text = "Add Box / Thêm Hộp";
            this.btnAddBox.UseVisualStyleBackColor = true;
            this.btnAddBox.Click += new System.EventHandler(this.btnAddBox_Click);
            // 
            // btnOpenBox
            // 
            this.btnOpenBox.Location = new System.Drawing.Point(233, 3);
            this.btnOpenBox.Name = "btnOpenBox";
            this.btnOpenBox.Size = new System.Drawing.Size(109, 54);
            this.btnOpenBox.TabIndex = 12;
            this.btnOpenBox.Text = "Open Box / Mở Hộp";
            this.btnOpenBox.UseVisualStyleBackColor = true;
            this.btnOpenBox.Click += new System.EventHandler(this.btnOpenBox_Click);
            // 
            // tbpButtons
            // 
            this.tbpButtons.ColumnCount = 7;
            this.tbpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tbpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tbpButtons.Controls.Add(this.btnSearch, 0, 0);
            this.tbpButtons.Controls.Add(this.btnAddBox, 1, 0);
            this.tbpButtons.Controls.Add(this.btnOpenBox, 2, 0);
            this.tbpButtons.Controls.Add(this.btnMeasurement, 4, 0);
            this.tbpButtons.Controls.Add(this.btnDeletebox, 3, 0);
            this.tbpButtons.Controls.Add(this.btnClear, 6, 0);
            this.tbpButtons.Controls.Add(this.btnExport, 5, 0);
            this.tbpButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbpButtons.Location = new System.Drawing.Point(150, 270);
            this.tbpButtons.Name = "tbpButtons";
            this.tbpButtons.RowCount = 1;
            this.tbpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbpButtons.Size = new System.Drawing.Size(747, 60);
            this.tbpButtons.TabIndex = 15;
            // 
            // btnMeasurement
            // 
            this.btnMeasurement.Location = new System.Drawing.Point(463, 3);
            this.btnMeasurement.Name = "btnMeasurement";
            this.btnMeasurement.Size = new System.Drawing.Size(101, 51);
            this.btnMeasurement.TabIndex = 14;
            this.btnMeasurement.Text = "Measurement";
            this.btnMeasurement.UseVisualStyleBackColor = true;
            this.btnMeasurement.Click += new System.EventHandler(this.btnMeasurement_Click);
            // 
            // btnDeletebox
            // 
            this.btnDeletebox.Location = new System.Drawing.Point(348, 3);
            this.btnDeletebox.Name = "btnDeletebox";
            this.btnDeletebox.Size = new System.Drawing.Size(91, 51);
            this.btnDeletebox.TabIndex = 15;
            this.btnDeletebox.Text = "Delete Box";
            this.btnDeletebox.UseVisualStyleBackColor = true;
            this.btnDeletebox.Click += new System.EventHandler(this.btnDeletebox_Click);
            // 
            // txtLot
            // 
            this.txtLot.Location = new System.Drawing.Point(191, 128);
            this.txtLot.Margin = new System.Windows.Forms.Padding(4);
            this.txtLot.Name = "txtLot";
            this.txtLot.Size = new System.Drawing.Size(177, 23);
            this.txtLot.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "Lot";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(563, 128);
            this.txtQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(100, 23);
            this.txtQty.TabIndex = 23;
            this.txtQty.Text = "0";
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(376, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 17);
            this.label9.TabIndex = 24;
            this.label9.Text = "Qty";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(578, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(71, 23);
            this.btnExport.TabIndex = 16;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 494);
            this.code = "";
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.tbpButtons);
            this.Controls.Add(this.tbpMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name = "";
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Form";
            this.tittle = "FormCommon";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.Controls.SetChildIndex(this.tbpMain, 0);
            this.Controls.SetChildIndex(this.tbpButtons, 0);
            this.Controls.SetChildIndex(this.dgvMain, 0);
            this.tbpMain.ResumeLayout(false);
            this.tbpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.tbpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbpMain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtPartNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxID;
        private System.Windows.Forms.TextBox txtInvoice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPurpose;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtVender;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnOpenBox;
        private System.Windows.Forms.Button btnAddBox;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox cbCheckDate;
        private System.Windows.Forms.TableLayoutPanel tbpButtons;
        private System.Windows.Forms.Button btnMeasurement;
        private System.Windows.Forms.Button btnDeletebox;
        private System.Windows.Forms.TextBox txtLot;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnExport;
    }
}