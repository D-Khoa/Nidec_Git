namespace SoftPrintLabel
{
    partial class SoftPrintLabel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoftPrintLabel));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.btnPrintAll = new System.Windows.Forms.Button();
            this.btnPrintItem = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.btnLoadFile, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtFile, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPrintAll, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnBrowser, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPrintItem, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvData, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 326F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(562, 418);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "File";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFile
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtFile, 2);
            this.txtFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFile.Location = new System.Drawing.Point(143, 3);
            this.txtFile.Multiline = true;
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(274, 40);
            this.txtFile.TabIndex = 1;
            this.txtFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(423, 3);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(119, 40);
            this.btnBrowser.TabIndex = 2;
            this.btnBrowser.Text = "Browser";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // btnPrintAll
            // 
            this.btnPrintAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrintAll.Location = new System.Drawing.Point(283, 49);
            this.btnPrintAll.Name = "btnPrintAll";
            this.btnPrintAll.Size = new System.Drawing.Size(134, 40);
            this.btnPrintAll.TabIndex = 3;
            this.btnPrintAll.Text = "Print All";
            this.btnPrintAll.UseVisualStyleBackColor = true;
            this.btnPrintAll.Click += new System.EventHandler(this.btnPrintAll_Click);
            // 
            // btnPrintItem
            // 
            this.btnPrintItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrintItem.Location = new System.Drawing.Point(143, 49);
            this.btnPrintItem.Name = "btnPrintItem";
            this.btnPrintItem.Size = new System.Drawing.Size(134, 40);
            this.btnPrintItem.TabIndex = 4;
            this.btnPrintItem.Text = "Print Item";
            this.btnPrintItem.UseVisualStyleBackColor = true;
            this.btnPrintItem.Click += new System.EventHandler(this.btnPrintItem_Click);
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dgvData, 4);
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(3, 95);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(556, 320);
            this.dgvData.TabIndex = 5;
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadFile.Location = new System.Drawing.Point(3, 49);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(134, 40);
            this.btnLoadFile.TabIndex = 6;
            this.btnLoadFile.Text = "Load File";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // SoftPrintLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 418);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SoftPrintLabel";
            this.Text = "Soft Print Label";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.Button btnPrintAll;
        private System.Windows.Forms.Button btnPrintItem;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnLoadFile;
    }
}

