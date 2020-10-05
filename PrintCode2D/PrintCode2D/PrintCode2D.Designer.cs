namespace PrintCode2D
{
    partial class PrintCode2D
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintCode2D));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSerinumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxCode = new System.Windows.Forms.GroupBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.dtpMonth = new System.Windows.Forms.DateTimePicker();
            this.dtpyear = new System.Windows.Forms.DateTimePicker();
            this.btnEditCode = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ckAuto = new System.Windows.Forms.CheckBox();
            this.groupBoxCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Code:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Year:";
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Location = new System.Drawing.Point(129, 29);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(96, 21);
            this.txtCustomerCode.TabIndex = 2;
            this.txtCustomerCode.Text = "TLR2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Month:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Date:";
            // 
            // txtSerinumber
            // 
            this.txtSerinumber.Location = new System.Drawing.Point(129, 181);
            this.txtSerinumber.MaxLength = 5;
            this.txtSerinumber.Name = "txtSerinumber";
            this.txtSerinumber.Size = new System.Drawing.Size(96, 21);
            this.txtSerinumber.TabIndex = 9;
            this.txtSerinumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerinumber_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Serinumber:";
            // 
            // groupBoxCode
            // 
            this.groupBoxCode.Controls.Add(this.dtpDate);
            this.groupBoxCode.Controls.Add(this.dtpMonth);
            this.groupBoxCode.Controls.Add(this.dtpyear);
            this.groupBoxCode.Controls.Add(this.label1);
            this.groupBoxCode.Controls.Add(this.txtSerinumber);
            this.groupBoxCode.Controls.Add(this.label2);
            this.groupBoxCode.Controls.Add(this.label5);
            this.groupBoxCode.Controls.Add(this.txtCustomerCode);
            this.groupBoxCode.Controls.Add(this.label4);
            this.groupBoxCode.Controls.Add(this.label3);
            this.groupBoxCode.Location = new System.Drawing.Point(16, 36);
            this.groupBoxCode.Name = "groupBoxCode";
            this.groupBoxCode.Size = new System.Drawing.Size(273, 219);
            this.groupBoxCode.TabIndex = 10;
            this.groupBoxCode.TabStop = false;
            this.groupBoxCode.Text = "2D Code Setting";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(129, 140);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(96, 21);
            this.dtpDate.TabIndex = 12;
            // 
            // dtpMonth
            // 
            this.dtpMonth.CustomFormat = "MM";
            this.dtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonth.Location = new System.Drawing.Point(129, 102);
            this.dtpMonth.Name = "dtpMonth";
            this.dtpMonth.Size = new System.Drawing.Size(96, 21);
            this.dtpMonth.TabIndex = 11;
            // 
            // dtpyear
            // 
            this.dtpyear.CustomFormat = "yyyy";
            this.dtpyear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpyear.Location = new System.Drawing.Point(129, 63);
            this.dtpyear.Name = "dtpyear";
            this.dtpyear.Size = new System.Drawing.Size(96, 21);
            this.dtpyear.TabIndex = 10;
            // 
            // btnEditCode
            // 
            this.btnEditCode.Location = new System.Drawing.Point(121, 273);
            this.btnEditCode.Name = "btnEditCode";
            this.btnEditCode.Size = new System.Drawing.Size(120, 40);
            this.btnEditCode.TabIndex = 12;
            this.btnEditCode.Text = "Edit Code";
            this.btnEditCode.UseVisualStyleBackColor = true;
            this.btnEditCode.Click += new System.EventHandler(this.btnEditCode_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(263, 273);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(120, 40);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(263, 331);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 40);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(121, 331);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 40);
            this.btnReset.TabIndex = 17;
            this.btnReset.Text = "Reset Label";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(310, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(177, 149);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(310, 206);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(177, 21);
            this.txtResult.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(307, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "Label Name:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(310, 241);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(177, 21);
            this.textBox1.TabIndex = 21;
            this.textBox1.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 12);
            this.label10.TabIndex = 72;
            this.label10.Text = "FA Department © 2020 NCVP";
            // 
            // ckAuto
            // 
            this.ckAuto.AutoSize = true;
            this.ckAuto.Checked = true;
            this.ckAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckAuto.Location = new System.Drawing.Point(16, 285);
            this.ckAuto.Name = "ckAuto";
            this.ckAuto.Size = new System.Drawing.Size(78, 19);
            this.ckAuto.TabIndex = 73;
            this.ckAuto.Text = "Print Auto";
            this.ckAuto.UseVisualStyleBackColor = true;
            // 
            // PrintCode2D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 402);
            this.Controls.Add(this.ckAuto);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnEditCode);
            this.Controls.Add(this.groupBoxCode);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrintCode2D";
            this.Text = "BMD-0088 Print Label";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxCode.ResumeLayout(false);
            this.groupBoxCode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSerinumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBoxCode;
        private System.Windows.Forms.Button btnEditCode;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.DateTimePicker dtpMonth;
        private System.Windows.Forms.DateTimePicker dtpyear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox ckAuto;
    }
}

