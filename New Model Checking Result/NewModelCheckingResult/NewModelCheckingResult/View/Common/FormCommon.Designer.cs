namespace NewModelCheckingResult.View.Common
{
    partial class FormCommon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCommon));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTittle = new System.Windows.Forms.Label();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.lbUserCode = new System.Windows.Forms.Label();
            this.lbCode = new System.Windows.Forms.Label();
            this.btnCreatAccount = new System.Windows.Forms.Button();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.lbNameUser = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::NewModelCheckingResult.Properties.Resources.NIDEC_Logo_small_1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.lbTittle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(897, 70);
            this.panel1.TabIndex = 6;
            // 
            // lbTittle
            // 
            this.lbTittle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTittle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbTittle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTittle.Location = new System.Drawing.Point(150, 0);
            this.lbTittle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbTittle.Name = "lbTittle";
            this.lbTittle.Size = new System.Drawing.Size(747, 70);
            this.lbTittle.TabIndex = 4;
            this.lbTittle.Text = "Title";
            this.lbTittle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlUser
            // 
            this.pnlUser.BackColor = System.Drawing.SystemColors.Control;
            this.pnlUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUser.Controls.Add(this.lbUserCode);
            this.pnlUser.Controls.Add(this.lbCode);
            this.pnlUser.Controls.Add(this.btnCreatAccount);
            this.pnlUser.Controls.Add(this.btnCloseForm);
            this.pnlUser.Controls.Add(this.btnChangePassword);
            this.pnlUser.Controls.Add(this.lbNameUser);
            this.pnlUser.Controls.Add(this.lbName);
            this.pnlUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlUser.ForeColor = System.Drawing.Color.Black;
            this.pnlUser.Location = new System.Drawing.Point(0, 70);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(150, 424);
            this.pnlUser.TabIndex = 7;
            // 
            // lbUserCode
            // 
            this.lbUserCode.AutoSize = true;
            this.lbUserCode.Location = new System.Drawing.Point(12, 13);
            this.lbUserCode.Name = "lbUserCode";
            this.lbUserCode.Size = new System.Drawing.Size(74, 13);
            this.lbUserCode.TabIndex = 12;
            this.lbUserCode.Text = "User Code :";
            // 
            // lbCode
            // 
            this.lbCode.AutoSize = true;
            this.lbCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lbCode.Location = new System.Drawing.Point(12, 33);
            this.lbCode.Name = "lbCode";
            this.lbCode.Size = new System.Drawing.Size(36, 13);
            this.lbCode.TabIndex = 11;
            this.lbCode.Text = "Code";
            // 
            // btnCreatAccount
            // 
            this.btnCreatAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreatAccount.Location = new System.Drawing.Point(15, 214);
            this.btnCreatAccount.Name = "btnCreatAccount";
            this.btnCreatAccount.Size = new System.Drawing.Size(120, 50);
            this.btnCreatAccount.TabIndex = 10;
            this.btnCreatAccount.TabStop = false;
            this.btnCreatAccount.Text = "Creat Account";
            this.btnCreatAccount.UseVisualStyleBackColor = true;
            this.btnCreatAccount.Click += new System.EventHandler(this.btnCreatAccount_Click);
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseForm.Location = new System.Drawing.Point(15, 354);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(120, 50);
            this.btnCloseForm.TabIndex = 9;
            this.btnCloseForm.TabStop = false;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangePassword.Location = new System.Drawing.Point(15, 284);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(120, 50);
            this.btnChangePassword.TabIndex = 6;
            this.btnChangePassword.TabStop = false;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // lbNameUser
            // 
            this.lbNameUser.AutoSize = true;
            this.lbNameUser.Location = new System.Drawing.Point(12, 61);
            this.lbNameUser.Name = "lbNameUser";
            this.lbNameUser.Size = new System.Drawing.Size(77, 13);
            this.lbNameUser.TabIndex = 4;
            this.lbNameUser.Text = "User Name :";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lbName.Location = new System.Drawing.Point(12, 81);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(39, 13);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Name";
            // 
            // FormCommon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 494);
            this.Controls.Add(this.pnlUser);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCommon";
            this.Text = "FormCommon";
            this.Load += new System.EventHandler(this.FormCommon_Load);
            this.panel1.ResumeLayout(false);
            this.pnlUser.ResumeLayout(false);
            this.pnlUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbTittle;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Label lbNameUser;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Button btnCreatAccount;
        private System.Windows.Forms.Label lbUserCode;
        private System.Windows.Forms.Label lbCode;
    }
}