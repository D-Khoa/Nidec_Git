namespace YieldMonitor.View
{
    partial class InspectCell
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
            this.lbYeild = new System.Windows.Forms.Label();
            this.lbOutput = new System.Windows.Forms.Label();
            this.lbInput = new System.Windows.Forms.Label();
            this.lb3 = new System.Windows.Forms.Label();
            this.lb2 = new System.Windows.Forms.Label();
            this.lb1 = new System.Windows.Forms.Label();
            this.lbInspectName = new System.Windows.Forms.Label();
            this.lbmodel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbYeild
            // 
            this.lbYeild.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbYeild.Location = new System.Drawing.Point(80, 130);
            this.lbYeild.Name = "lbYeild";
            this.lbYeild.Size = new System.Drawing.Size(78, 20);
            this.lbYeild.TabIndex = 6;
            this.lbYeild.Text = "Yeild";
            this.lbYeild.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbOutput
            // 
            this.lbOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOutput.Location = new System.Drawing.Point(80, 100);
            this.lbOutput.Name = "lbOutput";
            this.lbOutput.Size = new System.Drawing.Size(78, 20);
            this.lbOutput.TabIndex = 5;
            this.lbOutput.Text = "Output";
            this.lbOutput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbInput
            // 
            this.lbInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInput.Location = new System.Drawing.Point(80, 70);
            this.lbInput.Name = "lbInput";
            this.lbInput.Size = new System.Drawing.Size(78, 20);
            this.lbInput.TabIndex = 4;
            this.lbInput.Text = "Input";
            this.lbInput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb3
            // 
            this.lb3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb3.Location = new System.Drawing.Point(0, 130);
            this.lb3.Name = "lb3";
            this.lb3.Size = new System.Drawing.Size(78, 20);
            this.lb3.TabIndex = 3;
            this.lb3.Text = "Yeild :";
            this.lb3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb2
            // 
            this.lb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb2.Location = new System.Drawing.Point(0, 100);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(78, 20);
            this.lb2.TabIndex = 2;
            this.lb2.Text = "Output :";
            this.lb2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb1
            // 
            this.lb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb1.Location = new System.Drawing.Point(0, 70);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(78, 20);
            this.lb1.TabIndex = 1;
            this.lb1.Text = "Input :";
            this.lb1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbInspectName
            // 
            this.lbInspectName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbInspectName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbInspectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInspectName.Location = new System.Drawing.Point(0, 30);
            this.lbInspectName.Name = "lbInspectName";
            this.lbInspectName.Size = new System.Drawing.Size(158, 30);
            this.lbInspectName.TabIndex = 0;
            this.lbInspectName.Text = "Inspect Name";
            this.lbInspectName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbmodel
            // 
            this.lbmodel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbmodel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbmodel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbmodel.Location = new System.Drawing.Point(0, 0);
            this.lbmodel.Name = "lbmodel";
            this.lbmodel.Size = new System.Drawing.Size(158, 30);
            this.lbmodel.TabIndex = 7;
            this.lbmodel.Text = "Model";
            this.lbmodel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InspectCell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbInspectName);
            this.Controls.Add(this.lbYeild);
            this.Controls.Add(this.lb3);
            this.Controls.Add(this.lbOutput);
            this.Controls.Add(this.lbmodel);
            this.Controls.Add(this.lbInput);
            this.Controls.Add(this.lb2);
            this.Controls.Add(this.lb1);
            this.Name = "InspectCell";
            this.Size = new System.Drawing.Size(158, 158);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.InspectCell_Paint);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbOutput;
        private System.Windows.Forms.Label lbInput;
        private System.Windows.Forms.Label lb3;
        private System.Windows.Forms.Label lb2;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.Label lbmodel;
        public System.Windows.Forms.Label lbYeild;
        public System.Windows.Forms.Label lbInspectName;
    }
}
