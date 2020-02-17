namespace ConvertAndSendData.View
{
    partial class History
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbInspectNameH = new System.Windows.Forms.Label();
            this.lbmodel = new System.Windows.Forms.Label();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // lbInspectNameH
            // 
            this.lbInspectNameH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbInspectNameH.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbInspectNameH.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInspectNameH.Location = new System.Drawing.Point(0, 30);
            this.lbInspectNameH.Name = "lbInspectNameH";
            this.lbInspectNameH.Size = new System.Drawing.Size(375, 30);
            this.lbInspectNameH.TabIndex = 8;
            this.lbInspectNameH.Text = "Inspect Name";
            this.lbInspectNameH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbmodel
            // 
            this.lbmodel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbmodel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbmodel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbmodel.Location = new System.Drawing.Point(0, 0);
            this.lbmodel.Name = "lbmodel";
            this.lbmodel.Size = new System.Drawing.Size(375, 30);
            this.lbmodel.TabIndex = 9;
            this.lbmodel.Text = "Model";
            this.lbmodel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvHistory
            // 
            this.dgvHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistory.Location = new System.Drawing.Point(0, 60);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.Size = new System.Drawing.Size(375, 152);
            this.dgvHistory.TabIndex = 10;
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvHistory);
            this.Controls.Add(this.lbInspectNameH);
            this.Controls.Add(this.lbmodel);
            this.Name = "History";
            this.Size = new System.Drawing.Size(375, 212);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.History_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbInspectNameH;
        private System.Windows.Forms.Label lbmodel;
        private System.Windows.Forms.DataGridView dgvHistory;
    }
}
