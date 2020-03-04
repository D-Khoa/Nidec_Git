namespace ConvertLB6
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileSource = new System.Windows.Forms.TextBox();
            this.btnBrowserFile = new System.Windows.Forms.Button();
            this.btnBrowserTo = new System.Windows.Forms.Button();
            this.txtFileTo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source File";
            // 
            // txtFileSource
            // 
            this.txtFileSource.Location = new System.Drawing.Point(100, 30);
            this.txtFileSource.Name = "txtFileSource";
            this.txtFileSource.Size = new System.Drawing.Size(200, 20);
            this.txtFileSource.TabIndex = 1;
            // 
            // btnBrowserFile
            // 
            this.btnBrowserFile.Location = new System.Drawing.Point(320, 20);
            this.btnBrowserFile.Name = "btnBrowserFile";
            this.btnBrowserFile.Size = new System.Drawing.Size(80, 40);
            this.btnBrowserFile.TabIndex = 2;
            this.btnBrowserFile.Text = "Browser";
            this.btnBrowserFile.UseVisualStyleBackColor = true;
            this.btnBrowserFile.Click += new System.EventHandler(this.btnBrowserFile_Click);
            // 
            // btnBrowserTo
            // 
            this.btnBrowserTo.Location = new System.Drawing.Point(320, 66);
            this.btnBrowserTo.Name = "btnBrowserTo";
            this.btnBrowserTo.Size = new System.Drawing.Size(80, 40);
            this.btnBrowserTo.TabIndex = 5;
            this.btnBrowserTo.Text = "Browser";
            this.btnBrowserTo.UseVisualStyleBackColor = true;
            this.btnBrowserTo.Click += new System.EventHandler(this.btnBrowserTo_Click);
            // 
            // txtFileTo
            // 
            this.txtFileTo.Location = new System.Drawing.Point(100, 76);
            this.txtFileTo.Name = "txtFileTo";
            this.txtFileTo.Size = new System.Drawing.Size(200, 20);
            this.txtFileTo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Source File";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(100, 120);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 40);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Convert";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(220, 120);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 40);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 177);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnBrowserTo);
            this.Controls.Add(this.txtFileTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowserFile);
            this.Controls.Add(this.txtFileSource);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFileSource;
        private System.Windows.Forms.Button btnBrowserFile;
        private System.Windows.Forms.Button btnBrowserTo;
        private System.Windows.Forms.TextBox txtFileTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}

