﻿namespace PC_QRCodeSystem
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCommon));
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lbTittle = new System.Windows.Forms.Label();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.lbOnlineTime = new System.Windows.Forms.Label();
            this.lbOnlineUser = new System.Windows.Forms.Label();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.lbPosUser = new System.Windows.Forms.Label();
            this.lbPosition = new System.Windows.Forms.Label();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.lbDept = new System.Windows.Forms.Label();
            this.lbNameUser = new System.Windows.Forms.Label();
            this.lbLoginTime = new System.Windows.Forms.Label();
            this.lbLogUser = new System.Windows.Forms.Label();
            this.lbDeptUser = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.timerFormLoad = new System.Windows.Forms.Timer(this.components);
            this.pnlTitle.SuspendLayout();
            this.pnlUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pnlTitle.Controls.Add(this.lbTittle);
            this.pnlTitle.Controls.Add(this.pnlLogo);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(750, 70);
            this.pnlTitle.TabIndex = 0;
            // 
            // lbTittle
            // 
            this.lbTittle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTittle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTittle.Location = new System.Drawing.Point(150, 0);
            this.lbTittle.Name = "lbTittle";
            this.lbTittle.Size = new System.Drawing.Size(600, 70);
            this.lbTittle.TabIndex = 1;
            this.lbTittle.Text = "Title";
            this.lbTittle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackgroundImage = global::PC_QRCodeSystem.Properties.Resources.NIDEC_Logo_small_1;
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(150, 70);
            this.pnlLogo.TabIndex = 0;
            // 
            // pnlUser
            // 
            this.pnlUser.BackColor = System.Drawing.SystemColors.Control;
            this.pnlUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUser.Controls.Add(this.label10);
            this.pnlUser.Controls.Add(this.lbOnlineTime);
            this.pnlUser.Controls.Add(this.lbOnlineUser);
            this.pnlUser.Controls.Add(this.btnCloseForm);
            this.pnlUser.Controls.Add(this.lbPosUser);
            this.pnlUser.Controls.Add(this.lbPosition);
            this.pnlUser.Controls.Add(this.btnChangePassword);
            this.pnlUser.Controls.Add(this.btnLogOut);
            this.pnlUser.Controls.Add(this.lbDept);
            this.pnlUser.Controls.Add(this.lbNameUser);
            this.pnlUser.Controls.Add(this.lbLoginTime);
            this.pnlUser.Controls.Add(this.lbLogUser);
            this.pnlUser.Controls.Add(this.lbDeptUser);
            this.pnlUser.Controls.Add(this.lbName);
            this.pnlUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlUser.ForeColor = System.Drawing.Color.Black;
            this.pnlUser.Location = new System.Drawing.Point(0, 70);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(150, 504);
            this.pnlUser.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 12);
            this.label10.TabIndex = 71;
            this.label10.Text = "FA Department © 2020 NCVP";
            // 
            // lbOnlineTime
            // 
            this.lbOnlineTime.AutoSize = true;
            this.lbOnlineTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lbOnlineTime.Location = new System.Drawing.Point(8, 205);
            this.lbOnlineTime.Name = "lbOnlineTime";
            this.lbOnlineTime.Size = new System.Drawing.Size(63, 13);
            this.lbOnlineTime.TabIndex = 11;
            this.lbOnlineTime.Text = "HH:mm:ss";
            // 
            // lbOnlineUser
            // 
            this.lbOnlineUser.AutoSize = true;
            this.lbOnlineUser.Location = new System.Drawing.Point(8, 185);
            this.lbOnlineUser.Name = "lbOnlineUser";
            this.lbOnlineUser.Size = new System.Drawing.Size(82, 13);
            this.lbOnlineUser.TabIndex = 10;
            this.lbOnlineUser.Text = "Online Time :";
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseForm.Location = new System.Drawing.Point(15, 435);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(120, 50);
            this.btnCloseForm.TabIndex = 3;
            this.btnCloseForm.TabStop = false;
            this.btnCloseForm.Text = "Close\r\nĐóng";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // lbPosUser
            // 
            this.lbPosUser.AutoSize = true;
            this.lbPosUser.Location = new System.Drawing.Point(8, 65);
            this.lbPosUser.Name = "lbPosUser";
            this.lbPosUser.Size = new System.Drawing.Size(116, 13);
            this.lbPosUser.TabIndex = 8;
            this.lbPosUser.Text = "Position (Chức Vụ):";
            // 
            // lbPosition
            // 
            this.lbPosition.AutoSize = true;
            this.lbPosition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lbPosition.Location = new System.Drawing.Point(8, 85);
            this.lbPosition.Name = "lbPosition";
            this.lbPosition.Size = new System.Drawing.Size(88, 13);
            this.lbPosition.TabIndex = 7;
            this.lbPosition.Text = "Position Name";
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangePassword.Location = new System.Drawing.Point(15, 315);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(120, 50);
            this.btnChangePassword.TabIndex = 1;
            this.btnChangePassword.TabStop = false;
            this.btnChangePassword.Text = "Change Password\r\nĐổi Mật Khẩu";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogOut.Location = new System.Drawing.Point(15, 375);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(120, 50);
            this.btnLogOut.TabIndex = 2;
            this.btnLogOut.TabStop = false;
            this.btnLogOut.Text = "Log Out\r\nĐăng Xuất";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // lbDept
            // 
            this.lbDept.AutoSize = true;
            this.lbDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lbDept.Location = new System.Drawing.Point(8, 125);
            this.lbDept.Name = "lbDept";
            this.lbDept.Size = new System.Drawing.Size(34, 13);
            this.lbDept.TabIndex = 5;
            this.lbDept.Text = "Dept";
            // 
            // lbNameUser
            // 
            this.lbNameUser.AutoSize = true;
            this.lbNameUser.Location = new System.Drawing.Point(8, 25);
            this.lbNameUser.Name = "lbNameUser";
            this.lbNameUser.Size = new System.Drawing.Size(127, 13);
            this.lbNameUser.TabIndex = 4;
            this.lbNameUser.Text = "User Name (Họ Tên):";
            // 
            // lbLoginTime
            // 
            this.lbLoginTime.AutoSize = true;
            this.lbLoginTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lbLoginTime.Location = new System.Drawing.Point(8, 165);
            this.lbLoginTime.Name = "lbLoginTime";
            this.lbLoginTime.Size = new System.Drawing.Size(133, 13);
            this.lbLoginTime.TabIndex = 3;
            this.lbLoginTime.Text = "yyyy-MM-dd HH:mm:ss";
            // 
            // lbLogUser
            // 
            this.lbLogUser.AutoSize = true;
            this.lbLogUser.Location = new System.Drawing.Point(8, 145);
            this.lbLogUser.Name = "lbLogUser";
            this.lbLogUser.Size = new System.Drawing.Size(77, 13);
            this.lbLogUser.TabIndex = 2;
            this.lbLogUser.Text = "Login Time :";
            // 
            // lbDeptUser
            // 
            this.lbDeptUser.AutoSize = true;
            this.lbDeptUser.Location = new System.Drawing.Point(8, 105);
            this.lbDeptUser.Name = "lbDeptUser";
            this.lbDeptUser.Size = new System.Drawing.Size(136, 13);
            this.lbDeptUser.TabIndex = 1;
            this.lbDeptUser.Text = "Department (Bộ Phận):";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lbName.Location = new System.Drawing.Point(8, 45);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(39, 13);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Name";
            // 
            // timerFormLoad
            // 
            this.timerFormLoad.Interval = 500;
            this.timerFormLoad.Tick += new System.EventHandler(this.timerFormLoad_Tick);
            // 
            // FormCommon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 574);
            this.Controls.Add(this.pnlUser);
            this.Controls.Add(this.pnlTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCommon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCommon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCommon_FormClosing);
            this.Load += new System.EventHandler(this.FormCommon_Load);
            this.Shown += new System.EventHandler(this.FormCommon_Shown);
            this.pnlTitle.ResumeLayout(false);
            this.pnlUser.ResumeLayout(false);
            this.pnlUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lbTittle;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.Label lbDept;
        private System.Windows.Forms.Label lbNameUser;
        private System.Windows.Forms.Label lbLoginTime;
        private System.Windows.Forms.Label lbLogUser;
        private System.Windows.Forms.Label lbDeptUser;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Label lbPosUser;
        private System.Windows.Forms.Label lbPosition;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Label lbOnlineTime;
        private System.Windows.Forms.Label lbOnlineUser;
        protected System.Windows.Forms.Timer timerFormLoad;
        private System.Windows.Forms.Label label10;
    }
}