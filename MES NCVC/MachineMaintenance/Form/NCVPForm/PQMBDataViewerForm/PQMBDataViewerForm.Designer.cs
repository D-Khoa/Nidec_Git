namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    partial class PQMBDataViewerForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBoxCommon1 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.trInspect = new Com.Nidec.Mes.Framework.TreeViewCommon();
            this.panelCommon1 = new Com.Nidec.Mes.Framework.PanelCommon();
            this.btnBySerno = new System.Windows.Forms.RadioButton();
            this.btnByLot = new System.Windows.Forms.RadioButton();
            this.btnClear = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.txtBarcode = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.cmbModel = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoad = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.btnSearch = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.btnCSV = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.groupBoxCommon4 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.btnBrowser = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.txtURL = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.groupBoxCommon3 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.dtDatet = new Com.Nidec.Mes.Framework.CommonControls.DateTimePickerControl();
            this.groupBoxCommon2 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.dtDatef = new Com.Nidec.Mes.Framework.CommonControls.DateTimePickerControl();
            this.dgvdt = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsSernoRows = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsSpace = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.sfSaveCSV = new System.Windows.Forms.SaveFileDialog();
            this.ofCSV = new System.Windows.Forms.OpenFileDialog();
            this.bgwGetData = new System.ComponentModel.BackgroundWorker();
            this.groupBoxCommon1.SuspendLayout();
            this.panelCommon1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxCommon4.SuspendLayout();
            this.groupBoxCommon3.SuspendLayout();
            this.groupBoxCommon2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdt)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCommon1
            // 
            this.groupBoxCommon1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCommon1.ControlId = null;
            this.groupBoxCommon1.Controls.Add(this.trInspect);
            this.groupBoxCommon1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon1.Location = new System.Drawing.Point(709, 3);
            this.groupBoxCommon1.Name = "groupBoxCommon1";
            this.groupBoxCommon1.Size = new System.Drawing.Size(216, 191);
            this.groupBoxCommon1.TabIndex = 25;
            this.groupBoxCommon1.TabStop = false;
            this.groupBoxCommon1.Text = "Inspect";
            // 
            // trInspect
            // 
            this.trInspect.CheckBoxes = true;
            this.trInspect.ControlId = null;
            this.trInspect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trInspect.Location = new System.Drawing.Point(3, 17);
            this.trInspect.Name = "trInspect";
            this.trInspect.Size = new System.Drawing.Size(210, 180);
            this.trInspect.TabIndex = 0;
            this.trInspect.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trInspect_AfterCheck);
            // 
            // panelCommon1
            // 
            this.panelCommon1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCommon1.ControlId = null;
            this.panelCommon1.Controls.Add(this.btnBySerno);
            this.panelCommon1.Controls.Add(this.btnByLot);
            this.panelCommon1.Controls.Add(this.btnClear);
            this.panelCommon1.Controls.Add(this.txtBarcode);
            this.panelCommon1.Controls.Add(this.labelCommon1);
            this.panelCommon1.Controls.Add(this.cmbModel);
            this.panelCommon1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelCommon1.Location = new System.Drawing.Point(264, 6);
            this.panelCommon1.Name = "panelCommon1";
            this.panelCommon1.Size = new System.Drawing.Size(439, 194);
            this.panelCommon1.TabIndex = 26;
            // 
            // btnBySerno
            // 
            this.btnBySerno.AutoSize = true;
            this.btnBySerno.Checked = true;
            this.btnBySerno.Location = new System.Drawing.Point(6, 53);
            this.btnBySerno.Name = "btnBySerno";
            this.btnBySerno.Size = new System.Drawing.Size(118, 19);
            this.btnBySerno.TabIndex = 36;
            this.btnBySerno.TabStop = true;
            this.btnBySerno.Text = "By serial number";
            this.btnBySerno.UseVisualStyleBackColor = true;
            // 
            // btnByLot
            // 
            this.btnByLot.AutoSize = true;
            this.btnByLot.Location = new System.Drawing.Point(6, 33);
            this.btnByLot.Name = "btnByLot";
            this.btnByLot.Size = new System.Drawing.Size(58, 19);
            this.btnByLot.TabIndex = 35;
            this.btnByLot.Text = "By Lot";
            this.btnByLot.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.SystemColors.Control;
            this.btnClear.ControlId = null;
            this.btnClear.Font = new System.Drawing.Font("Arial", 9F);
            this.btnClear.Location = new System.Drawing.Point(365, 33);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(71, 36);
            this.btnClear.TabIndex = 34;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcode.ControlId = null;
            this.txtBarcode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.txtBarcode.Location = new System.Drawing.Point(3, 75);
            this.txtBarcode.Multiline = true;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(433, 113);
            this.txtBarcode.TabIndex = 2;
            // 
            // labelCommon1
            // 
            this.labelCommon1.AutoSize = true;
            this.labelCommon1.ControlId = null;
            this.labelCommon1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommon1.Location = new System.Drawing.Point(3, 7);
            this.labelCommon1.Name = "labelCommon1";
            this.labelCommon1.Size = new System.Drawing.Size(40, 15);
            this.labelCommon1.TabIndex = 1;
            this.labelCommon1.Text = "Model";
            // 
            // cmbModel
            // 
            this.cmbModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbModel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbModel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbModel.ControlId = null;
            this.cmbModel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Location = new System.Drawing.Point(49, 4);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(387, 23);
            this.cmbModel.TabIndex = 0;
            this.cmbModel.SelectedIndexChanged += new System.EventHandler(this.cmbModel_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnCSV);
            this.panel1.Controls.Add(this.groupBoxCommon4);
            this.panel1.Controls.Add(this.groupBoxCommon3);
            this.panel1.Controls.Add(this.groupBoxCommon2);
            this.panel1.Controls.Add(this.panelCommon1);
            this.panel1.Controls.Add(this.groupBoxCommon1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(938, 208);
            this.panel1.TabIndex = 27;
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.SystemColors.Control;
            this.btnLoad.ControlId = null;
            this.btnLoad.Font = new System.Drawing.Font("Arial", 9F);
            this.btnLoad.Location = new System.Drawing.Point(186, 173);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(71, 27);
            this.btnLoad.TabIndex = 36;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearch.ControlId = null;
            this.btnSearch.Font = new System.Drawing.Font("Arial", 9F);
            this.btnSearch.Location = new System.Drawing.Point(3, 173);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 27);
            this.btnSearch.TabIndex = 35;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCSV
            // 
            this.btnCSV.BackColor = System.Drawing.SystemColors.Control;
            this.btnCSV.ControlId = null;
            this.btnCSV.Font = new System.Drawing.Font("Arial", 9F);
            this.btnCSV.Location = new System.Drawing.Point(96, 173);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(87, 27);
            this.btnCSV.TabIndex = 34;
            this.btnCSV.Text = "Export CSV";
            this.btnCSV.UseVisualStyleBackColor = false;
            this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);
            // 
            // groupBoxCommon4
            // 
            this.groupBoxCommon4.ControlId = null;
            this.groupBoxCommon4.Controls.Add(this.btnBrowser);
            this.groupBoxCommon4.Controls.Add(this.txtURL);
            this.groupBoxCommon4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon4.Location = new System.Drawing.Point(3, 120);
            this.groupBoxCommon4.Name = "groupBoxCommon4";
            this.groupBoxCommon4.Size = new System.Drawing.Size(258, 47);
            this.groupBoxCommon4.TabIndex = 31;
            this.groupBoxCommon4.TabStop = false;
            this.groupBoxCommon4.Text = "Serial from CSV";
            // 
            // btnBrowser
            // 
            this.btnBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowser.BackColor = System.Drawing.SystemColors.Control;
            this.btnBrowser.ControlId = null;
            this.btnBrowser.Font = new System.Drawing.Font("Arial", 9F);
            this.btnBrowser.Location = new System.Drawing.Point(195, 19);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(57, 22);
            this.btnBrowser.TabIndex = 31;
            this.btnBrowser.Text = "Browser";
            this.btnBrowser.UseVisualStyleBackColor = false;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // txtURL
            // 
            this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtURL.ControlId = null;
            this.txtURL.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtURL.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.txtURL.Location = new System.Drawing.Point(6, 20);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(183, 21);
            this.txtURL.TabIndex = 0;
            // 
            // groupBoxCommon3
            // 
            this.groupBoxCommon3.ControlId = null;
            this.groupBoxCommon3.Controls.Add(this.dtDatet);
            this.groupBoxCommon3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon3.Location = new System.Drawing.Point(0, 63);
            this.groupBoxCommon3.Name = "groupBoxCommon3";
            this.groupBoxCommon3.Size = new System.Drawing.Size(258, 51);
            this.groupBoxCommon3.TabIndex = 30;
            this.groupBoxCommon3.TabStop = false;
            this.groupBoxCommon3.Text = "To date";
            // 
            // dtDatet
            // 
            this.dtDatet.ControlId = null;
            this.dtDatet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtDatet.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtDatet.InputType = Com.Nidec.Mes.Framework.CommonControls.DateTimePickerControl.InputTypeList.ToDate;
            this.dtDatet.Location = new System.Drawing.Point(3, 17);
            this.dtDatet.Name = "dtDatet";
            this.dtDatet.Size = new System.Drawing.Size(252, 31);
            this.dtDatet.TabIndex = 29;
            // 
            // groupBoxCommon2
            // 
            this.groupBoxCommon2.ControlId = null;
            this.groupBoxCommon2.Controls.Add(this.dtDatef);
            this.groupBoxCommon2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon2.Location = new System.Drawing.Point(0, 6);
            this.groupBoxCommon2.Name = "groupBoxCommon2";
            this.groupBoxCommon2.Size = new System.Drawing.Size(258, 51);
            this.groupBoxCommon2.TabIndex = 29;
            this.groupBoxCommon2.TabStop = false;
            this.groupBoxCommon2.Text = "From date";
            // 
            // dtDatef
            // 
            this.dtDatef.ControlId = null;
            this.dtDatef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtDatef.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtDatef.InputType = Com.Nidec.Mes.Framework.CommonControls.DateTimePickerControl.InputTypeList.FromDate;
            this.dtDatef.Location = new System.Drawing.Point(3, 17);
            this.dtDatef.Name = "dtDatef";
            this.dtDatef.Size = new System.Drawing.Size(252, 31);
            this.dtDatef.TabIndex = 28;
            // 
            // dgvdt
            // 
            this.dgvdt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvdt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdt.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvdt.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvdt.Location = new System.Drawing.Point(-3, 307);
            this.dgvdt.Name = "dgvdt";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdt.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvdt.Size = new System.Drawing.Size(938, 129);
            this.dgvdt.TabIndex = 28;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsSernoRows,
            this.tsSpace,
            this.toolStripStatusLabel3,
            this.tsTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(938, 24);
            this.statusStrip1.TabIndex = 29;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(88, 19);
            this.toolStripStatusLabel1.Text = "Serial numbers:";
            // 
            // tsSernoRows
            // 
            this.tsSernoRows.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsSernoRows.Name = "tsSernoRows";
            this.tsSernoRows.Size = new System.Drawing.Size(45, 19);
            this.tsSernoRows.Text = "0 rows";
            // 
            // tsSpace
            // 
            this.tsSpace.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tsSpace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSpace.Name = "tsSpace";
            this.tsSpace.Size = new System.Drawing.Size(724, 19);
            this.tsSpace.Spring = true;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(41, 19);
            this.toolStripStatusLabel3.Text = "Time:";
            // 
            // tsTime
            // 
            this.tsTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsTime.Name = "tsTime";
            this.tsTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsTime.Size = new System.Drawing.Size(25, 19);
            this.tsTime.Text = "0 s";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // sfSaveCSV
            // 
            this.sfSaveCSV.CheckFileExists = true;
            this.sfSaveCSV.DefaultExt = "csv";
            this.sfSaveCSV.InitialDirectory = "D:\\";
            // 
            // ofCSV
            // 
            this.ofCSV.FileName = "openFileDialog1";
            // 
            // PQMBDataViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 463);
            this.Controls.Add(this.dgvdt);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "PQMBDataViewerForm";
            this.Text = "PQMBDataViewerForm";
            this.TitleText = "FormCommon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PQMBDataViewerForm_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.statusStrip1, 0);
            this.Controls.SetChildIndex(this.dgvdt, 0);
            this.groupBoxCommon1.ResumeLayout(false);
            this.panelCommon1.ResumeLayout(false);
            this.panelCommon1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBoxCommon4.ResumeLayout(false);
            this.groupBoxCommon4.PerformLayout();
            this.groupBoxCommon3.ResumeLayout(false);
            this.groupBoxCommon2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdt)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.GroupBoxCommon groupBoxCommon1;
        private Framework.TreeViewCommon trInspect;
        private Framework.PanelCommon panelCommon1;
        private System.Windows.Forms.RadioButton btnBySerno;
        private System.Windows.Forms.RadioButton btnByLot;
        private Framework.ButtonCommon btnClear;
        private Framework.TextBoxCommon txtBarcode;
        private Framework.LabelCommon labelCommon1;
        private Framework.ComboBoxCommon cmbModel;
        private System.Windows.Forms.Panel panel1;
        private Framework.GroupBoxCommon groupBoxCommon2;
        private Framework.CommonControls.DateTimePickerControl dtDatef;
        private Framework.GroupBoxCommon groupBoxCommon3;
        private Framework.CommonControls.DateTimePickerControl dtDatet;
        private Framework.GroupBoxCommon groupBoxCommon4;
        private Framework.ButtonCommon btnBrowser;
        private Framework.TextBoxCommon txtURL;
        private Framework.ButtonCommon btnLoad;
        private Framework.ButtonCommon btnSearch;
        private Framework.ButtonCommon btnCSV;
        private Framework.DataGridViewCommon dgvdt;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsSernoRows;
        private System.Windows.Forms.ToolStripStatusLabel tsSpace;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel tsTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.SaveFileDialog sfSaveCSV;
        private System.Windows.Forms.OpenFileDialog ofCSV;
        private System.ComponentModel.BackgroundWorker bgwGetData;
    }
}