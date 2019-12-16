namespace FinalCheck
{
    partial class Main
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
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.grt_Main = new System.Windows.Forms.TabControl();
            this.tab_Run = new System.Windows.Forms.TabPage();
            this.tab_Setting = new System.Windows.Forms.TabPage();
            this.btnSettingApply = new System.Windows.Forms.Button();
            this.tab_Password = new System.Windows.Forms.TabPage();
            this.btnPassOK = new System.Windows.Forms.Button();
            this.txtPassBox = new System.Windows.Forms.TextBox();
            this.btnPassCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSettingCancel = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbCounter = new System.Windows.Forms.Label();
            this.lbModel = new System.Windows.Forms.Label();
            this.grCounter = new System.Windows.Forms.GroupBox();
            this.grTimeCheck = new System.Windows.Forms.GroupBox();
            this.lbNumberofTest = new System.Windows.Forms.Label();
            this.btnSetting = new System.Windows.Forms.Button();
            this.picStatus = new System.Windows.Forms.PictureBox();
            this.grt_Main.SuspendLayout();
            this.tab_Run.SuspendLayout();
            this.tab_Setting.SuspendLayout();
            this.tab_Password.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.grCounter.SuspendLayout();
            this.grTimeCheck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(221, 46);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(186, 20);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(424, 44);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(150, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Barcode";
            // 
            // grt_Main
            // 
            this.grt_Main.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.grt_Main.Controls.Add(this.tab_Run);
            this.grt_Main.Controls.Add(this.tab_Setting);
            this.grt_Main.Controls.Add(this.tab_Password);
            this.grt_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grt_Main.Location = new System.Drawing.Point(0, 0);
            this.grt_Main.Name = "grt_Main";
            this.grt_Main.SelectedIndex = 0;
            this.grt_Main.Size = new System.Drawing.Size(681, 460);
            this.grt_Main.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.grt_Main.TabIndex = 6;
            // 
            // tab_Run
            // 
            this.tab_Run.Controls.Add(this.picStatus);
            this.tab_Run.Controls.Add(this.btnSetting);
            this.tab_Run.Controls.Add(this.grTimeCheck);
            this.tab_Run.Controls.Add(this.grCounter);
            this.tab_Run.Controls.Add(this.lbModel);
            this.tab_Run.Controls.Add(this.label5);
            this.tab_Run.Controls.Add(this.dgvData);
            this.tab_Run.Controls.Add(this.btnCheck);
            this.tab_Run.Controls.Add(this.label2);
            this.tab_Run.Controls.Add(this.txtBarcode);
            this.tab_Run.Location = new System.Drawing.Point(4, 25);
            this.tab_Run.Name = "tab_Run";
            this.tab_Run.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Run.Size = new System.Drawing.Size(673, 431);
            this.tab_Run.TabIndex = 0;
            this.tab_Run.UseVisualStyleBackColor = true;
            this.tab_Run.Paint += new System.Windows.Forms.PaintEventHandler(this.tab_Run_Paint);
            // 
            // tab_Setting
            // 
            this.tab_Setting.Controls.Add(this.label1);
            this.tab_Setting.Controls.Add(this.cmbModel);
            this.tab_Setting.Controls.Add(this.btnSettingCancel);
            this.tab_Setting.Controls.Add(this.btnSettingApply);
            this.tab_Setting.Location = new System.Drawing.Point(4, 25);
            this.tab_Setting.Name = "tab_Setting";
            this.tab_Setting.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Setting.Size = new System.Drawing.Size(673, 431);
            this.tab_Setting.TabIndex = 1;
            this.tab_Setting.UseVisualStyleBackColor = true;
            // 
            // btnSettingApply
            // 
            this.btnSettingApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettingApply.Location = new System.Drawing.Point(509, 400);
            this.btnSettingApply.Name = "btnSettingApply";
            this.btnSettingApply.Size = new System.Drawing.Size(75, 23);
            this.btnSettingApply.TabIndex = 6;
            this.btnSettingApply.Text = "Apply";
            this.btnSettingApply.UseVisualStyleBackColor = true;
            this.btnSettingApply.Click += new System.EventHandler(this.btnSettingApply_Click);
            // 
            // tab_Password
            // 
            this.tab_Password.Controls.Add(this.label3);
            this.tab_Password.Controls.Add(this.btnPassCancel);
            this.tab_Password.Controls.Add(this.txtPassBox);
            this.tab_Password.Controls.Add(this.btnPassOK);
            this.tab_Password.Location = new System.Drawing.Point(4, 25);
            this.tab_Password.Name = "tab_Password";
            this.tab_Password.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Password.Size = new System.Drawing.Size(673, 431);
            this.tab_Password.TabIndex = 2;
            this.tab_Password.UseVisualStyleBackColor = true;
            // 
            // btnPassOK
            // 
            this.btnPassOK.Location = new System.Drawing.Point(205, 208);
            this.btnPassOK.Name = "btnPassOK";
            this.btnPassOK.Size = new System.Drawing.Size(75, 23);
            this.btnPassOK.TabIndex = 0;
            this.btnPassOK.Text = "OK";
            this.btnPassOK.UseVisualStyleBackColor = true;
            this.btnPassOK.Click += new System.EventHandler(this.btnPassOK_Click);
            // 
            // txtPassBox
            // 
            this.txtPassBox.Location = new System.Drawing.Point(261, 156);
            this.txtPassBox.Name = "txtPassBox";
            this.txtPassBox.Size = new System.Drawing.Size(164, 20);
            this.txtPassBox.TabIndex = 1;
            this.txtPassBox.UseSystemPasswordChar = true;
            this.txtPassBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassBox_KeyDown);
            // 
            // btnPassCancel
            // 
            this.btnPassCancel.Location = new System.Drawing.Point(350, 208);
            this.btnPassCancel.Name = "btnPassCancel";
            this.btnPassCancel.Size = new System.Drawing.Size(75, 23);
            this.btnPassCancel.TabIndex = 2;
            this.btnPassCancel.Text = "Cancel";
            this.btnPassCancel.UseVisualStyleBackColor = true;
            this.btnPassCancel.Click += new System.EventHandler(this.btnPassCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password";
            // 
            // btnSettingCancel
            // 
            this.btnSettingCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettingCancel.Location = new System.Drawing.Point(590, 400);
            this.btnSettingCancel.Name = "btnSettingCancel";
            this.btnSettingCancel.Size = new System.Drawing.Size(75, 23);
            this.btnSettingCancel.TabIndex = 7;
            this.btnSettingCancel.Text = "Cancel";
            this.btnSettingCancel.UseVisualStyleBackColor = true;
            this.btnSettingCancel.Click += new System.EventHandler(this.btnSettingCancel_Click);
            // 
            // dgvData
            // 
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(3, 241);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(664, 187);
            this.dgvData.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Model";
            // 
            // cmbModel
            // 
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Location = new System.Drawing.Point(59, 6);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(186, 21);
            this.cmbModel.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(150, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Model";
            // 
            // lbCounter
            // 
            this.lbCounter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCounter.Location = new System.Drawing.Point(3, 16);
            this.lbCounter.Name = "lbCounter";
            this.lbCounter.Size = new System.Drawing.Size(135, 61);
            this.lbCounter.TabIndex = 11;
            this.lbCounter.Text = "0";
            this.lbCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbModel
            // 
            this.lbModel.AutoSize = true;
            this.lbModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbModel.Location = new System.Drawing.Point(217, 14);
            this.lbModel.Name = "lbModel";
            this.lbModel.Size = new System.Drawing.Size(51, 20);
            this.lbModel.TabIndex = 12;
            this.lbModel.Text = "None";
            // 
            // grCounter
            // 
            this.grCounter.Controls.Add(this.lbCounter);
            this.grCounter.Location = new System.Drawing.Point(3, 6);
            this.grCounter.Name = "grCounter";
            this.grCounter.Size = new System.Drawing.Size(141, 80);
            this.grCounter.TabIndex = 13;
            this.grCounter.TabStop = false;
            this.grCounter.Text = "Counter";
            // 
            // grTimeCheck
            // 
            this.grTimeCheck.Controls.Add(this.lbNumberofTest);
            this.grTimeCheck.Location = new System.Drawing.Point(524, 6);
            this.grTimeCheck.Name = "grTimeCheck";
            this.grTimeCheck.Size = new System.Drawing.Size(141, 80);
            this.grTimeCheck.TabIndex = 14;
            this.grTimeCheck.TabStop = false;
            this.grTimeCheck.Text = "Number of test";
            // 
            // lbNumberofTest
            // 
            this.lbNumberofTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNumberofTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumberofTest.Location = new System.Drawing.Point(3, 16);
            this.lbNumberofTest.Name = "lbNumberofTest";
            this.lbNumberofTest.Size = new System.Drawing.Size(135, 61);
            this.lbNumberofTest.TabIndex = 11;
            this.lbNumberofTest.Text = "0";
            this.lbNumberofTest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(424, 14);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(75, 23);
            this.btnSetting.TabIndex = 15;
            this.btnSetting.Text = "Setting";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // picStatus
            // 
            this.picStatus.Location = new System.Drawing.Point(221, 72);
            this.picStatus.Name = "picStatus";
            this.picStatus.Size = new System.Drawing.Size(186, 163);
            this.picStatus.TabIndex = 16;
            this.picStatus.TabStop = false;
            // 
            // Main
            // 
            this.AcceptButton = this.btnCheck;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 460);
            this.Controls.Add(this.grt_Main);
            this.Name = "Main";
            this.Text = "Final Check";
            this.Load += new System.EventHandler(this.Main_Load);
            this.grt_Main.ResumeLayout(false);
            this.tab_Run.ResumeLayout(false);
            this.tab_Run.PerformLayout();
            this.tab_Setting.ResumeLayout(false);
            this.tab_Setting.PerformLayout();
            this.tab_Password.ResumeLayout(false);
            this.tab_Password.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.grCounter.ResumeLayout(false);
            this.grTimeCheck.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl grt_Main;
        private System.Windows.Forms.TabPage tab_Run;
        private System.Windows.Forms.TabPage tab_Setting;
        private System.Windows.Forms.Button btnSettingApply;
        private System.Windows.Forms.TabPage tab_Password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPassCancel;
        private System.Windows.Forms.TextBox txtPassBox;
        private System.Windows.Forms.Button btnPassOK;
        private System.Windows.Forms.Button btnSettingCancel;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.Label lbCounter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbModel;
        private System.Windows.Forms.GroupBox grTimeCheck;
        private System.Windows.Forms.Label lbNumberofTest;
        private System.Windows.Forms.GroupBox grCounter;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.PictureBox picStatus;
    }
}

