namespace NewModelCheckingResult.View
{
    partial class MasterFrm
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
            this.tcMaster = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.tbpMain = new System.Windows.Forms.TableLayoutPanel();
            this.cmbTools = new System.Windows.Forms.ComboBox();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPartNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAddMaster = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelMaster = new System.Windows.Forms.Button();
            this.tabAddMaster = new System.Windows.Forms.TabPage();
            this.tbpAddMaster = new System.Windows.Forms.TableLayoutPanel();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnInsClear = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtInsMinus = new System.Windows.Forms.TextBox();
            this.txtInsPlus = new System.Windows.Forms.TextBox();
            this.txtInsSpec = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInsCode = new System.Windows.Forms.TextBox();
            this.txtInsPart = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInsName = new System.Windows.Forms.TextBox();
            this.cmbInsTool = new System.Windows.Forms.ComboBox();
            this.tcMaster.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tbpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.tabAddMaster.SuspendLayout();
            this.tbpAddMaster.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMaster
            // 
            this.tcMaster.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tcMaster.Controls.Add(this.tabMain);
            this.tcMaster.Controls.Add(this.tabAddMaster);
            this.tcMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMaster.Location = new System.Drawing.Point(150, 70);
            this.tcMaster.Margin = new System.Windows.Forms.Padding(4);
            this.tcMaster.Name = "tcMaster";
            this.tcMaster.SelectedIndex = 0;
            this.tcMaster.Size = new System.Drawing.Size(834, 392);
            this.tcMaster.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tcMaster.TabIndex = 8;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tbpMain);
            this.tabMain.Location = new System.Drawing.Point(4, 28);
            this.tabMain.Margin = new System.Windows.Forms.Padding(4);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(4);
            this.tabMain.Size = new System.Drawing.Size(826, 360);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // tbpMain
            // 
            this.tbpMain.ColumnCount = 4;
            this.tbpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbpMain.Controls.Add(this.cmbTools, 3, 0);
            this.tbpMain.Controls.Add(this.dgvMain, 0, 2);
            this.tbpMain.Controls.Add(this.label3, 2, 0);
            this.tbpMain.Controls.Add(this.txtPartNumber, 1, 0);
            this.tbpMain.Controls.Add(this.label1, 0, 0);
            this.tbpMain.Controls.Add(this.btnSearch, 0, 1);
            this.tbpMain.Controls.Add(this.btnAddMaster, 1, 1);
            this.tbpMain.Controls.Add(this.btnClear, 3, 1);
            this.tbpMain.Controls.Add(this.btnDelMaster, 2, 1);
            this.tbpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbpMain.Location = new System.Drawing.Point(4, 4);
            this.tbpMain.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.tbpMain.Name = "tbpMain";
            this.tbpMain.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.tbpMain.RowCount = 3;
            this.tbpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbpMain.Size = new System.Drawing.Size(818, 352);
            this.tbpMain.TabIndex = 10;
            // 
            // cmbTools
            // 
            this.cmbTools.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbTools.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTools.FormattingEnabled = true;
            this.cmbTools.Location = new System.Drawing.Point(613, 3);
            this.cmbTools.Name = "cmbTools";
            this.cmbTools.Size = new System.Drawing.Size(195, 24);
            this.cmbTools.TabIndex = 13;
            this.cmbTools.SelectedIndexChanged += new System.EventHandler(this.cmbTools_SelectedIndexChanged);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbpMain.SetColumnSpan(this.dgvMain, 4);
            this.dgvMain.Location = new System.Drawing.Point(11, 133);
            this.dgvMain.Margin = new System.Windows.Forms.Padding(4);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(796, 215);
            this.dgvMain.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(413, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 31);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tools / Thiết Bị Đo";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPartNumber
            // 
            this.txtPartNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPartNumber.Location = new System.Drawing.Point(212, 4);
            this.txtPartNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtPartNumber.Name = "txtPartNumber";
            this.txtPartNumber.Size = new System.Drawing.Size(193, 23);
            this.txtPartNumber.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(11, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 31);
            this.label1.TabIndex = 10;
            this.label1.Text = "Part Number / Số Linh Kiện";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.Location = new System.Drawing.Point(11, 35);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(193, 90);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search / Tìm Kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAddMaster
            // 
            this.btnAddMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddMaster.Location = new System.Drawing.Point(212, 35);
            this.btnAddMaster.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddMaster.Name = "btnAddMaster";
            this.btnAddMaster.Size = new System.Drawing.Size(193, 90);
            this.btnAddMaster.TabIndex = 4;
            this.btnAddMaster.Text = "Add Master / Thêm Hạng Mục";
            this.btnAddMaster.UseVisualStyleBackColor = true;
            this.btnAddMaster.Click += new System.EventHandler(this.btnAddMaster_Click);
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Location = new System.Drawing.Point(614, 35);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(193, 90);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear / Xóa";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelMaster
            // 
            this.btnDelMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelMaster.Location = new System.Drawing.Point(413, 35);
            this.btnDelMaster.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelMaster.Name = "btnDelMaster";
            this.btnDelMaster.Size = new System.Drawing.Size(193, 90);
            this.btnDelMaster.TabIndex = 5;
            this.btnDelMaster.Text = "Delete Master / Xóa Hạng Mục";
            this.btnDelMaster.UseVisualStyleBackColor = true;
            this.btnDelMaster.Click += new System.EventHandler(this.btnDelMaster_Click);
            // 
            // tabAddMaster
            // 
            this.tabAddMaster.Controls.Add(this.tbpAddMaster);
            this.tabAddMaster.Location = new System.Drawing.Point(4, 28);
            this.tabAddMaster.Margin = new System.Windows.Forms.Padding(4);
            this.tabAddMaster.Name = "tabAddMaster";
            this.tabAddMaster.Padding = new System.Windows.Forms.Padding(4);
            this.tabAddMaster.Size = new System.Drawing.Size(826, 360);
            this.tabAddMaster.TabIndex = 1;
            this.tabAddMaster.Text = "AddMaster";
            this.tabAddMaster.UseVisualStyleBackColor = true;
            // 
            // tbpAddMaster
            // 
            this.tbpAddMaster.ColumnCount = 4;
            this.tbpAddMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbpAddMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbpAddMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbpAddMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbpAddMaster.Controls.Add(this.btnRegister, 1, 4);
            this.tbpAddMaster.Controls.Add(this.btnInsClear, 2, 4);
            this.tbpAddMaster.Controls.Add(this.btnBack, 3, 4);
            this.tbpAddMaster.Controls.Add(this.txtInsMinus, 3, 3);
            this.tbpAddMaster.Controls.Add(this.txtInsPlus, 3, 2);
            this.tbpAddMaster.Controls.Add(this.txtInsSpec, 3, 1);
            this.tbpAddMaster.Controls.Add(this.label9, 2, 3);
            this.tbpAddMaster.Controls.Add(this.label10, 2, 2);
            this.tbpAddMaster.Controls.Add(this.label2, 2, 1);
            this.tbpAddMaster.Controls.Add(this.label5, 2, 0);
            this.tbpAddMaster.Controls.Add(this.txtInsCode, 1, 1);
            this.tbpAddMaster.Controls.Add(this.txtInsPart, 1, 0);
            this.tbpAddMaster.Controls.Add(this.label6, 0, 1);
            this.tbpAddMaster.Controls.Add(this.label7, 0, 0);
            this.tbpAddMaster.Controls.Add(this.label4, 0, 2);
            this.tbpAddMaster.Controls.Add(this.txtInsName, 1, 2);
            this.tbpAddMaster.Controls.Add(this.cmbInsTool, 3, 0);
            this.tbpAddMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbpAddMaster.Location = new System.Drawing.Point(4, 4);
            this.tbpAddMaster.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.tbpAddMaster.Name = "tbpAddMaster";
            this.tbpAddMaster.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.tbpAddMaster.RowCount = 6;
            this.tbpAddMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tbpAddMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tbpAddMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tbpAddMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tbpAddMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tbpAddMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbpAddMaster.Size = new System.Drawing.Size(818, 352);
            this.tbpAddMaster.TabIndex = 10;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.SystemColors.Control;
            this.btnRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRegister.Location = new System.Drawing.Point(212, 124);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(193, 92);
            this.btnRegister.TabIndex = 8;
            this.btnRegister.Text = "Add / Thêm";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnInsClear
            // 
            this.btnInsClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInsClear.Location = new System.Drawing.Point(413, 124);
            this.btnInsClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnInsClear.Name = "btnInsClear";
            this.btnInsClear.Size = new System.Drawing.Size(193, 92);
            this.btnInsClear.TabIndex = 9;
            this.btnInsClear.Text = "Clear / Xóa";
            this.btnInsClear.UseVisualStyleBackColor = true;
            this.btnInsClear.Click += new System.EventHandler(this.btnInsClear_Click);
            // 
            // btnBack
            // 
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBack.Location = new System.Drawing.Point(614, 124);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(193, 92);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Back / Trở Lại";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtInsMinus
            // 
            this.txtInsMinus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInsMinus.Location = new System.Drawing.Point(614, 94);
            this.txtInsMinus.Margin = new System.Windows.Forms.Padding(4);
            this.txtInsMinus.Name = "txtInsMinus";
            this.txtInsMinus.Size = new System.Drawing.Size(193, 23);
            this.txtInsMinus.TabIndex = 7;
            // 
            // txtInsPlus
            // 
            this.txtInsPlus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInsPlus.Location = new System.Drawing.Point(614, 64);
            this.txtInsPlus.Margin = new System.Windows.Forms.Padding(4);
            this.txtInsPlus.Name = "txtInsPlus";
            this.txtInsPlus.Size = new System.Drawing.Size(193, 23);
            this.txtInsPlus.TabIndex = 6;
            // 
            // txtInsSpec
            // 
            this.txtInsSpec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInsSpec.Location = new System.Drawing.Point(614, 34);
            this.txtInsSpec.Margin = new System.Windows.Forms.Padding(4);
            this.txtInsSpec.Name = "txtInsSpec";
            this.txtInsSpec.Size = new System.Drawing.Size(193, 23);
            this.txtInsSpec.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(413, 90);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(193, 30);
            this.label9.TabIndex = 16;
            this.label9.Text = "Tol (-)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(413, 60);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(193, 30);
            this.label10.TabIndex = 29;
            this.label10.Text = "Tol (+)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(413, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 30);
            this.label2.TabIndex = 9;
            this.label2.Text = "Spec";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(413, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 30);
            this.label5.TabIndex = 15;
            this.label5.Text = "Inspect Tool";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInsCode
            // 
            this.txtInsCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInsCode.Location = new System.Drawing.Point(212, 34);
            this.txtInsCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtInsCode.Name = "txtInsCode";
            this.txtInsCode.Size = new System.Drawing.Size(193, 23);
            this.txtInsCode.TabIndex = 2;
            // 
            // txtInsPart
            // 
            this.txtInsPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInsPart.Location = new System.Drawing.Point(212, 4);
            this.txtInsPart.Margin = new System.Windows.Forms.Padding(4);
            this.txtInsPart.Name = "txtInsPart";
            this.txtInsPart.Size = new System.Drawing.Size(193, 23);
            this.txtInsPart.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(11, 30);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(193, 30);
            this.label6.TabIndex = 10;
            this.label6.Text = "Inspect Code";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(11, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(193, 30);
            this.label7.TabIndex = 12;
            this.label7.Text = "Part Number";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(11, 60);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 30);
            this.label4.TabIndex = 11;
            this.label4.Text = "Inspect Name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInsName
            // 
            this.txtInsName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInsName.Location = new System.Drawing.Point(212, 64);
            this.txtInsName.Margin = new System.Windows.Forms.Padding(4);
            this.txtInsName.Multiline = true;
            this.txtInsName.Name = "txtInsName";
            this.tbpAddMaster.SetRowSpan(this.txtInsName, 2);
            this.txtInsName.Size = new System.Drawing.Size(193, 52);
            this.txtInsName.TabIndex = 3;
            // 
            // cmbInsTool
            // 
            this.cmbInsTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbInsTool.FormattingEnabled = true;
            this.cmbInsTool.Location = new System.Drawing.Point(613, 3);
            this.cmbInsTool.Name = "cmbInsTool";
            this.cmbInsTool.Size = new System.Drawing.Size(195, 24);
            this.cmbInsTool.TabIndex = 30;
            // 
            // MasterFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.tcMaster);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.name = "";
            this.Name = "MasterFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MasterFrm";
            this.tittle = "FormCommon";
            this.Load += new System.EventHandler(this.MasterFrm_Load);
            this.Controls.SetChildIndex(this.tcMaster, 0);
            this.tcMaster.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tbpMain.ResumeLayout(false);
            this.tbpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.tabAddMaster.ResumeLayout(false);
            this.tbpAddMaster.ResumeLayout(false);
            this.tbpAddMaster.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMaster;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabAddMaster;
        private System.Windows.Forms.TableLayoutPanel tbpMain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPartNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAddMaster;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TableLayoutPanel tbpAddMaster;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInsName;
        private System.Windows.Forms.TextBox txtInsCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtInsPart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtInsMinus;
        private System.Windows.Forms.TextBox txtInsSpec;
        private System.Windows.Forms.Button btnInsClear;
        private System.Windows.Forms.TextBox txtInsPlus;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnDelMaster;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.ComboBox cmbTools;
        private System.Windows.Forms.ComboBox cmbInsTool;
    }
}