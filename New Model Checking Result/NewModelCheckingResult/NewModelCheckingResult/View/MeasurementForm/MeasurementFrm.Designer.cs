namespace NewModelCheckingResult.View
{
    partial class MeasurementFrm
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
            this.btnOpenMaster = new System.Windows.Forms.Button();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPartNumber = new System.Windows.Forms.TextBox();
            this.btnOpenMeasure = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxID = new System.Windows.Forms.TextBox();
            this.cmbTools = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // tbpMain
            // 
            this.tbpMain.ColumnCount = 4;
            this.tbpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbpMain.Controls.Add(this.btnOpenMaster, 0, 2);
            this.tbpMain.Controls.Add(this.dgvMain, 0, 4);
            this.tbpMain.Controls.Add(this.label3, 2, 1);
            this.tbpMain.Controls.Add(this.txtPartNumber, 1, 1);
            this.tbpMain.Controls.Add(this.btnOpenMeasure, 3, 2);
            this.tbpMain.Controls.Add(this.btnSearch, 2, 2);
            this.tbpMain.Controls.Add(this.label2, 0, 0);
            this.tbpMain.Controls.Add(this.txtBoxID, 1, 0);
            this.tbpMain.Controls.Add(this.cmbTools, 3, 1);
            this.tbpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbpMain.Location = new System.Drawing.Point(150, 70);
            this.tbpMain.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.tbpMain.Name = "tbpMain";
            this.tbpMain.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.tbpMain.RowCount = 6;
            this.tbpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tbpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tbpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tbpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbpMain.Size = new System.Drawing.Size(827, 424);
            this.tbpMain.TabIndex = 11;
            // 
            // btnOpenMaster
            // 
            this.btnOpenMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenMaster.Location = new System.Drawing.Point(11, 64);
            this.btnOpenMaster.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenMaster.Name = "btnOpenMaster";
            this.btnOpenMaster.Size = new System.Drawing.Size(195, 92);
            this.btnOpenMaster.TabIndex = 4;
            this.btnOpenMaster.Text = "Open Master / Tùy Chỉnh Hạng Mục";
            this.btnOpenMaster.UseVisualStyleBackColor = true;
            this.btnOpenMaster.Click += new System.EventHandler(this.btnOpenMaster_Click);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbpMain.SetColumnSpan(this.dgvMain, 4);
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.Location = new System.Drawing.Point(11, 164);
            this.dgvMain.Margin = new System.Windows.Forms.Padding(4);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.tbpMain.SetRowSpan(this.dgvMain, 2);
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(805, 256);
            this.dgvMain.TabIndex = 5;
            this.dgvMain.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(417, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 30);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tools / Thiết Bị Đo";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPartNumber
            // 
            this.txtPartNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPartNumber.Location = new System.Drawing.Point(214, 34);
            this.txtPartNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtPartNumber.Name = "txtPartNumber";
            this.txtPartNumber.Size = new System.Drawing.Size(195, 23);
            this.txtPartNumber.TabIndex = 9;
            this.txtPartNumber.TabStop = false;
            // 
            // btnOpenMeasure
            // 
            this.btnOpenMeasure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenMeasure.Location = new System.Drawing.Point(620, 64);
            this.btnOpenMeasure.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenMeasure.Name = "btnOpenMeasure";
            this.btnOpenMeasure.Size = new System.Drawing.Size(196, 92);
            this.btnOpenMeasure.TabIndex = 3;
            this.btnOpenMeasure.Text = "Measure / Đo hạng mục";
            this.btnOpenMeasure.UseVisualStyleBackColor = true;
            this.btnOpenMeasure.Click += new System.EventHandler(this.btnOpenMeasure_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.Location = new System.Drawing.Point(417, 64);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(195, 92);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search / Tìm Kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(10, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 30);
            this.label2.TabIndex = 33;
            this.label2.Text = "Box Code / Mã Hộp Dữ Liệu";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBoxID
            // 
            this.txtBoxID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxID.Location = new System.Drawing.Point(213, 3);
            this.txtBoxID.Name = "txtBoxID";
            this.txtBoxID.ReadOnly = true;
            this.txtBoxID.Size = new System.Drawing.Size(197, 23);
            this.txtBoxID.TabIndex = 34;
            this.txtBoxID.TabStop = false;
            // 
            // cmbTools
            // 
            this.cmbTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTools.FormattingEnabled = true;
            this.cmbTools.Location = new System.Drawing.Point(619, 33);
            this.cmbTools.Name = "cmbTools";
            this.cmbTools.Size = new System.Drawing.Size(198, 24);
            this.cmbTools.TabIndex = 1;
            this.cmbTools.SelectedIndexChanged += new System.EventHandler(this.cmbTools_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(11, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 30);
            this.label1.TabIndex = 10;
            this.label1.Text = "Part Number / Số Linh Kiện";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MeasurementFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 494);
            this.code = "";
            this.Controls.Add(this.tbpMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name = "";
            this.Name = "MeasurementFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Measurement";
            this.tittle = "FormCommon";
            this.Load += new System.EventHandler(this.MeasurementFrm_Load);
            this.Controls.SetChildIndex(this.tbpMain, 0);
            this.tbpMain.ResumeLayout(false);
            this.tbpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbpMain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPartNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnOpenMeasure;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Button btnOpenMaster;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxID;
        private System.Windows.Forms.ComboBox cmbTools;
    }
}