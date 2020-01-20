namespace PC_QRCodeSystem.View
{
    partial class DestinationManager
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmbDepartmentCode = new System.Windows.Forms.ComboBox();
            this.cmbDestinationCode = new System.Windows.Forms.ComboBox();
            this.txtDepartmantName = new System.Windows.Forms.TextBox();
            this.txtDestinationName = new System.Windows.Forms.TextBox();
            this.rbtnDepartMent = new System.Windows.Forms.RadioButton();
            this.rbtnDestinationCode = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMUserCode = new System.Windows.Forms.TextBox();
            this.txtGMUserCode = new System.Windows.Forms.TextBox();
            this.txtMUserName = new System.Windows.Forms.TextBox();
            this.txtGMUserName = new System.Windows.Forms.TextBox();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtGMUserName);
            this.panel4.Controls.Add(this.txtMUserName);
            this.panel4.Controls.Add(this.txtGMUserCode);
            this.panel4.Controls.Add(this.txtMUserCode);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.btnOK);
            this.panel4.Controls.Add(this.btnCancel);
            this.panel4.Controls.Add(this.rbtnDepartMent);
            this.panel4.Controls.Add(this.rbtnDestinationCode);
            this.panel4.Controls.Add(this.txtDestinationName);
            this.panel4.Controls.Add(this.txtDepartmantName);
            this.panel4.Controls.Add(this.cmbDestinationCode);
            this.panel4.Controls.Add(this.cmbDepartmentCode);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(145, 69);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(639, 150);
            this.panel4.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnSearch);
            this.panel5.Controls.Add(this.btnClose);
            this.panel5.Controls.Add(this.btnUpdate);
            this.panel5.Controls.Add(this.btnDelete);
            this.panel5.Controls.Add(this.btnAdd);
            this.panel5.Controls.Add(this.btnClear);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(145, 219);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(639, 50);
            this.panel5.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(145, 269);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(639, 213);
            this.dataGridView1.TabIndex = 4;
            // 
            // cmbDepartmentCode
            // 
            this.cmbDepartmentCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartmentCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDepartmentCode.FormattingEnabled = true;
            this.cmbDepartmentCode.Location = new System.Drawing.Point(160, 20);
            this.cmbDepartmentCode.Name = "cmbDepartmentCode";
            this.cmbDepartmentCode.Size = new System.Drawing.Size(120, 24);
            this.cmbDepartmentCode.TabIndex = 0;
            this.cmbDepartmentCode.SelectedIndexChanged += new System.EventHandler(this.cmbDepartmentCode_SelectedIndexChanged);
            // 
            // cmbDestinationCode
            // 
            this.cmbDestinationCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDestinationCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDestinationCode.FormattingEnabled = true;
            this.cmbDestinationCode.Location = new System.Drawing.Point(160, 50);
            this.cmbDestinationCode.Name = "cmbDestinationCode";
            this.cmbDestinationCode.Size = new System.Drawing.Size(120, 24);
            this.cmbDestinationCode.TabIndex = 2;
            this.cmbDestinationCode.SelectedIndexChanged += new System.EventHandler(this.cmbDestinationCode_SelectedIndexChanged);
            // 
            // txtDepartmantName
            // 
            this.txtDepartmantName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepartmantName.Location = new System.Drawing.Point(300, 20);
            this.txtDepartmantName.Name = "txtDepartmantName";
            this.txtDepartmantName.ReadOnly = true;
            this.txtDepartmantName.Size = new System.Drawing.Size(200, 23);
            this.txtDepartmantName.TabIndex = 4;
            // 
            // txtDestinationName
            // 
            this.txtDestinationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestinationName.Location = new System.Drawing.Point(300, 50);
            this.txtDestinationName.Name = "txtDestinationName";
            this.txtDestinationName.ReadOnly = true;
            this.txtDestinationName.Size = new System.Drawing.Size(200, 23);
            this.txtDestinationName.TabIndex = 5;
            // 
            // rbtnDepartMent
            // 
            this.rbtnDepartMent.AutoSize = true;
            this.rbtnDepartMent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnDepartMent.Location = new System.Drawing.Point(20, 20);
            this.rbtnDepartMent.Name = "rbtnDepartMent";
            this.rbtnDepartMent.Size = new System.Drawing.Size(100, 21);
            this.rbtnDepartMent.TabIndex = 0;
            this.rbtnDepartMent.TabStop = true;
            this.rbtnDepartMent.Text = "Department";
            this.rbtnDepartMent.UseVisualStyleBackColor = true;
            this.rbtnDepartMent.CheckedChanged += new System.EventHandler(this.rbtnDepartMent_CheckedChanged);
            // 
            // rbtnDestinationCode
            // 
            this.rbtnDestinationCode.AutoSize = true;
            this.rbtnDestinationCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnDestinationCode.Location = new System.Drawing.Point(20, 50);
            this.rbtnDestinationCode.Name = "rbtnDestinationCode";
            this.rbtnDestinationCode.Size = new System.Drawing.Size(134, 21);
            this.rbtnDestinationCode.TabIndex = 1;
            this.rbtnDestinationCode.TabStop = true;
            this.rbtnDestinationCode.Text = "Destination Code";
            this.rbtnDestinationCode.UseVisualStyleBackColor = true;
            this.rbtnDestinationCode.CheckedChanged += new System.EventHandler(this.rbtnDepartMent_CheckedChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(20, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 40);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(520, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 40);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(220, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(80, 40);
            this.btnUpdate.TabIndex = 22;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(320, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 40);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(120, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 40);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(420, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 40);
            this.btnClear.TabIndex = 24;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(520, 10);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 40);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(520, 50);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 40);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Manager";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(124, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "GM";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMUserCode
            // 
            this.txtMUserCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMUserCode.Location = new System.Drawing.Point(160, 80);
            this.txtMUserCode.Name = "txtMUserCode";
            this.txtMUserCode.ReadOnly = true;
            this.txtMUserCode.Size = new System.Drawing.Size(120, 23);
            this.txtMUserCode.TabIndex = 20;
            // 
            // txtGMUserCode
            // 
            this.txtGMUserCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGMUserCode.Location = new System.Drawing.Point(160, 110);
            this.txtGMUserCode.Name = "txtGMUserCode";
            this.txtGMUserCode.ReadOnly = true;
            this.txtGMUserCode.Size = new System.Drawing.Size(120, 23);
            this.txtGMUserCode.TabIndex = 21;
            // 
            // txtMUserName
            // 
            this.txtMUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMUserName.Location = new System.Drawing.Point(300, 80);
            this.txtMUserName.Name = "txtMUserName";
            this.txtMUserName.ReadOnly = true;
            this.txtMUserName.Size = new System.Drawing.Size(200, 23);
            this.txtMUserName.TabIndex = 22;
            // 
            // txtGMUserName
            // 
            this.txtGMUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGMUserName.Location = new System.Drawing.Point(300, 110);
            this.txtGMUserName.Name = "txtGMUserName";
            this.txtGMUserName.ReadOnly = true;
            this.txtGMUserName.Size = new System.Drawing.Size(200, 23);
            this.txtGMUserName.TabIndex = 23;
            // 
            // DestinationManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 482);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.dept = "";
            this.logintime = new System.DateTime(((long)(0)));
            this.name = "";
            this.Name = "DestinationManager";
            this.Text = "Destination Manager";
            this.tittle = "FormCommon";
            this.Controls.SetChildIndex(this.panel4, 0);
            this.Controls.SetChildIndex(this.panel5, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbDestinationCode;
        private System.Windows.Forms.ComboBox cmbDepartmentCode;
        private System.Windows.Forms.TextBox txtDestinationName;
        private System.Windows.Forms.TextBox txtDepartmantName;
        private System.Windows.Forms.RadioButton rbtnDestinationCode;
        private System.Windows.Forms.RadioButton rbtnDepartMent;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGMUserCode;
        private System.Windows.Forms.TextBox txtMUserCode;
        private System.Windows.Forms.TextBox txtGMUserName;
        private System.Windows.Forms.TextBox txtMUserName;
    }
}