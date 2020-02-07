namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.FA_Management_System
{
    partial class Warehouse_Equipment_Form
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
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("Asset Model");
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("Asset Type");
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("Invoice");
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("Label Status");
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("Account Code");
            System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("Rank");
            System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("Section");
            System.Windows.Forms.TreeNode treeNode50 = new System.Windows.Forms.TreeNode("Now Location");
            System.Windows.Forms.TreeNode treeNode51 = new System.Windows.Forms.TreeNode("Inventory Time");
            System.Windows.Forms.TreeNode treeNode52 = new System.Windows.Forms.TreeNode("Valid");
            System.Windows.Forms.TreeNode treeNode53 = new System.Windows.Forms.TreeNode("Expired");
            System.Windows.Forms.TreeNode treeNode54 = new System.Windows.Forms.TreeNode("Net Value", new System.Windows.Forms.TreeNode[] {
            treeNode52,
            treeNode53});
            System.Windows.Forms.TreeNode treeNode55 = new System.Windows.Forms.TreeNode("Factory");
            System.Windows.Forms.TreeNode treeNode56 = new System.Windows.Forms.TreeNode("Unit");
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle57 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle52 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle53 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle54 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle55 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle56 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle58 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle59 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle60 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grt_Option = new Com.Nidec.Mes.Framework.TabControlCommon();
            this.tab_Search = new System.Windows.Forms.TabPage();
            this.trvAsset = new Com.Nidec.Mes.Framework.TreeViewCommon();
            this.trvOther = new Com.Nidec.Mes.Framework.TreeViewCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.txtAssetName = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.txtAssetCode = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.tab_depreciation = new System.Windows.Forms.TabPage();
            this.dgvDeprCalc = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.tab_TotalCost = new System.Windows.Forms.TabPage();
            this.dgvAccCounter = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.aquisition_cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.month_depr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.curr_depr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accum_depr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.net_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventoried = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_machine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons1 = new Com.Nidec.Mes.Framework.PanelCommon();
            this.btnClear = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.btnClose = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.btnExport = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.pnlButtons2 = new Com.Nidec.Mes.Framework.PanelCommon();
            this.btnRankDepr = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.btnTransferAsset = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.btnAccDepr = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.btnUpdate = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.btnAdd = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.btnSearch = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.dgvAccountData = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.sttStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsRowCounter = new System.Windows.Forms.ToolStripStatusLabel();
            this.grt_Option.SuspendLayout();
            this.tab_Search.SuspendLayout();
            this.tab_depreciation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeprCalc)).BeginInit();
            this.tab_TotalCost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccCounter)).BeginInit();
            this.pnlButtons1.SuspendLayout();
            this.pnlButtons2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountData)).BeginInit();
            this.sttStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // grt_Option
            // 
            this.grt_Option.ControlId = null;
            this.grt_Option.Controls.Add(this.tab_Search);
            this.grt_Option.Controls.Add(this.tab_depreciation);
            this.grt_Option.Controls.Add(this.tab_TotalCost);
            this.grt_Option.Dock = System.Windows.Forms.DockStyle.Top;
            this.grt_Option.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grt_Option.Location = new System.Drawing.Point(0, 107);
            this.grt_Option.Name = "grt_Option";
            this.grt_Option.SelectedIndex = 0;
            this.grt_Option.Size = new System.Drawing.Size(915, 187);
            this.grt_Option.TabIndex = 23;
            // 
            // tab_Search
            // 
            this.tab_Search.BackColor = System.Drawing.SystemColors.Control;
            this.tab_Search.Controls.Add(this.trvAsset);
            this.tab_Search.Controls.Add(this.trvOther);
            this.tab_Search.Controls.Add(this.labelCommon2);
            this.tab_Search.Controls.Add(this.txtAssetName);
            this.tab_Search.Controls.Add(this.labelCommon1);
            this.tab_Search.Controls.Add(this.txtAssetCode);
            this.tab_Search.Location = new System.Drawing.Point(4, 24);
            this.tab_Search.Name = "tab_Search";
            this.tab_Search.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Search.Size = new System.Drawing.Size(907, 159);
            this.tab_Search.TabIndex = 0;
            this.tab_Search.Text = "Search";
            // 
            // trvAsset
            // 
            this.trvAsset.CheckBoxes = true;
            this.trvAsset.ControlId = null;
            this.trvAsset.Dock = System.Windows.Forms.DockStyle.Right;
            this.trvAsset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvAsset.Location = new System.Drawing.Point(356, 3);
            this.trvAsset.Name = "trvAsset";
            treeNode43.Name = "asset_model";
            treeNode43.Text = "Asset Model";
            treeNode44.Name = "asset_type";
            treeNode44.Text = "Asset Type";
            treeNode45.Name = "asset_invoice";
            treeNode45.Text = "Invoice";
            treeNode46.Name = "label_status";
            treeNode46.Text = "Label Status";
            this.trvAsset.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode43,
            treeNode44,
            treeNode45,
            treeNode46});
            this.trvAsset.Size = new System.Drawing.Size(294, 153);
            this.trvAsset.TabIndex = 3;
            this.trvAsset.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trvAsset_AfterCheck);
            // 
            // trvOther
            // 
            this.trvOther.CheckBoxes = true;
            this.trvOther.ControlId = null;
            this.trvOther.Dock = System.Windows.Forms.DockStyle.Right;
            this.trvOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvOther.Location = new System.Drawing.Point(650, 3);
            this.trvOther.Name = "trvOther";
            treeNode47.Name = "account_cd";
            treeNode47.Text = "Account Code";
            treeNode48.Name = "rank_cd";
            treeNode48.Text = "Rank";
            treeNode49.Name = "account_location_cd";
            treeNode49.Text = "Section";
            treeNode50.Name = "location_cd";
            treeNode50.Text = "Now Location";
            treeNode51.Name = "invertory_time_cd";
            treeNode51.Text = "Inventory Time";
            treeNode52.Name = "valid";
            treeNode52.Text = "Valid";
            treeNode53.Name = "expired";
            treeNode53.Text = "Expired";
            treeNode54.Name = "net_value";
            treeNode54.Text = "Net Value";
            treeNode55.Name = "factory_cd";
            treeNode55.Text = "Factory";
            treeNode56.Name = "unit_cd";
            treeNode56.Text = "Unit";
            this.trvOther.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode47,
            treeNode48,
            treeNode49,
            treeNode50,
            treeNode51,
            treeNode54,
            treeNode55,
            treeNode56});
            this.trvOther.Size = new System.Drawing.Size(254, 153);
            this.trvOther.TabIndex = 4;
            this.trvOther.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trvOther_AfterCheck);
            // 
            // labelCommon2
            // 
            this.labelCommon2.AutoSize = true;
            this.labelCommon2.ControlId = null;
            this.labelCommon2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommon2.Location = new System.Drawing.Point(6, 42);
            this.labelCommon2.Name = "labelCommon2";
            this.labelCommon2.Size = new System.Drawing.Size(75, 15);
            this.labelCommon2.TabIndex = 9;
            this.labelCommon2.Text = "Asset Name";
            // 
            // txtAssetName
            // 
            this.txtAssetName.ControlId = null;
            this.txtAssetName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssetName.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.txtAssetName.Location = new System.Drawing.Point(83, 39);
            this.txtAssetName.Name = "txtAssetName";
            this.txtAssetName.Size = new System.Drawing.Size(209, 21);
            this.txtAssetName.TabIndex = 2;
            // 
            // labelCommon1
            // 
            this.labelCommon1.AutoSize = true;
            this.labelCommon1.ControlId = null;
            this.labelCommon1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommon1.Location = new System.Drawing.Point(6, 15);
            this.labelCommon1.Name = "labelCommon1";
            this.labelCommon1.Size = new System.Drawing.Size(71, 15);
            this.labelCommon1.TabIndex = 2;
            this.labelCommon1.Text = "Asset Code";
            // 
            // txtAssetCode
            // 
            this.txtAssetCode.ControlId = null;
            this.txtAssetCode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssetCode.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.txtAssetCode.Location = new System.Drawing.Point(83, 12);
            this.txtAssetCode.Name = "txtAssetCode";
            this.txtAssetCode.Size = new System.Drawing.Size(209, 21);
            this.txtAssetCode.TabIndex = 1;
            this.txtAssetCode.TextChanged += new System.EventHandler(this.txtAssetCode_TextChanged);
            // 
            // tab_depreciation
            // 
            this.tab_depreciation.BackColor = System.Drawing.SystemColors.Control;
            this.tab_depreciation.Controls.Add(this.dgvDeprCalc);
            this.tab_depreciation.Location = new System.Drawing.Point(4, 24);
            this.tab_depreciation.Name = "tab_depreciation";
            this.tab_depreciation.Padding = new System.Windows.Forms.Padding(3);
            this.tab_depreciation.Size = new System.Drawing.Size(907, 159);
            this.tab_depreciation.TabIndex = 1;
            this.tab_depreciation.Text = "Depreciation";
            // 
            // dgvDeprCalc
            // 
            this.dgvDeprCalc.AllowUserToAddRows = false;
            this.dgvDeprCalc.AllowUserToDeleteRows = false;
            dataGridViewCellStyle46.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle46.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle46.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle46.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle46.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle46.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeprCalc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle46;
            this.dgvDeprCalc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeprCalc.ControlId = null;
            this.dgvDeprCalc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDeprCalc.Location = new System.Drawing.Point(3, 3);
            this.dgvDeprCalc.Name = "dgvDeprCalc";
            this.dgvDeprCalc.ReadOnly = true;
            dataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle47.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle47.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle47.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle47.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle47.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeprCalc.RowHeadersDefaultCellStyle = dataGridViewCellStyle47;
            this.dgvDeprCalc.Size = new System.Drawing.Size(901, 153);
            this.dgvDeprCalc.TabIndex = 0;
            // 
            // tab_TotalCost
            // 
            this.tab_TotalCost.Controls.Add(this.dgvAccCounter);
            this.tab_TotalCost.Location = new System.Drawing.Point(4, 24);
            this.tab_TotalCost.Name = "tab_TotalCost";
            this.tab_TotalCost.Padding = new System.Windows.Forms.Padding(3);
            this.tab_TotalCost.Size = new System.Drawing.Size(907, 159);
            this.tab_TotalCost.TabIndex = 2;
            this.tab_TotalCost.Text = "Total Cost";
            this.tab_TotalCost.UseVisualStyleBackColor = true;
            // 
            // dgvAccCounter
            // 
            this.dgvAccCounter.AllowUserToAddRows = false;
            this.dgvAccCounter.AllowUserToDeleteRows = false;
            dataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvAccCounter.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle48;
            dataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle49.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle49.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle49.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle49.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle49.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAccCounter.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle49;
            this.dgvAccCounter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccCounter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aquisition_cost,
            this.month_depr,
            this.curr_depr,
            this.accum_depr,
            this.net_value,
            this.inventoried,
            this.total_machine});
            this.dgvAccCounter.ControlId = null;
            this.dgvAccCounter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAccCounter.Location = new System.Drawing.Point(3, 3);
            this.dgvAccCounter.Name = "dgvAccCounter";
            this.dgvAccCounter.ReadOnly = true;
            dataGridViewCellStyle57.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle57.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle57.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle57.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle57.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle57.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle57.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAccCounter.RowHeadersDefaultCellStyle = dataGridViewCellStyle57;
            this.dgvAccCounter.Size = new System.Drawing.Size(901, 153);
            this.dgvAccCounter.TabIndex = 0;
            // 
            // aquisition_cost
            // 
            dataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle50.Format = "N3";
            dataGridViewCellStyle50.NullValue = null;
            this.aquisition_cost.DefaultCellStyle = dataGridViewCellStyle50;
            this.aquisition_cost.HeaderText = "Aquisition Cost ($)";
            this.aquisition_cost.Name = "aquisition_cost";
            this.aquisition_cost.ReadOnly = true;
            // 
            // month_depr
            // 
            dataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle51.Format = "N3";
            dataGridViewCellStyle51.NullValue = null;
            this.month_depr.DefaultCellStyle = dataGridViewCellStyle51;
            this.month_depr.HeaderText = "Monthly Depreciation ($)";
            this.month_depr.Name = "month_depr";
            this.month_depr.ReadOnly = true;
            // 
            // curr_depr
            // 
            dataGridViewCellStyle52.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle52.Format = "N3";
            dataGridViewCellStyle52.NullValue = null;
            this.curr_depr.DefaultCellStyle = dataGridViewCellStyle52;
            this.curr_depr.HeaderText = "Current Depreciation ($)";
            this.curr_depr.Name = "curr_depr";
            this.curr_depr.ReadOnly = true;
            // 
            // accum_depr
            // 
            dataGridViewCellStyle53.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle53.Format = "N3";
            dataGridViewCellStyle53.NullValue = null;
            this.accum_depr.DefaultCellStyle = dataGridViewCellStyle53;
            this.accum_depr.HeaderText = "Accum Depreciation ($)";
            this.accum_depr.Name = "accum_depr";
            this.accum_depr.ReadOnly = true;
            // 
            // net_value
            // 
            dataGridViewCellStyle54.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle54.Format = "N3";
            dataGridViewCellStyle54.NullValue = null;
            this.net_value.DefaultCellStyle = dataGridViewCellStyle54;
            this.net_value.HeaderText = "Netbooks ($)";
            this.net_value.Name = "net_value";
            this.net_value.ReadOnly = true;
            // 
            // inventoried
            // 
            dataGridViewCellStyle55.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.inventoried.DefaultCellStyle = dataGridViewCellStyle55;
            this.inventoried.HeaderText = "Inventoried(Qty)";
            this.inventoried.Name = "inventoried";
            this.inventoried.ReadOnly = true;
            // 
            // total_machine
            // 
            dataGridViewCellStyle56.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.total_machine.DefaultCellStyle = dataGridViewCellStyle56;
            this.total_machine.HeaderText = "Total Machine(Qty)";
            this.total_machine.Name = "total_machine";
            this.total_machine.ReadOnly = true;
            // 
            // pnlButtons1
            // 
            this.pnlButtons1.ControlId = null;
            this.pnlButtons1.Controls.Add(this.btnClear);
            this.pnlButtons1.Controls.Add(this.btnClose);
            this.pnlButtons1.Controls.Add(this.btnExport);
            this.pnlButtons1.Controls.Add(this.pnlButtons2);
            this.pnlButtons1.Controls.Add(this.btnUpdate);
            this.pnlButtons1.Controls.Add(this.btnAdd);
            this.pnlButtons1.Controls.Add(this.btnSearch);
            this.pnlButtons1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtons1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlButtons1.Location = new System.Drawing.Point(0, 294);
            this.pnlButtons1.Name = "pnlButtons1";
            this.pnlButtons1.Size = new System.Drawing.Size(915, 49);
            this.pnlButtons1.TabIndex = 24;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.Control;
            this.btnClear.ControlId = null;
            this.btnClear.Font = new System.Drawing.Font("Arial", 9F);
            this.btnClear.Location = new System.Drawing.Point(372, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(86, 40);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.ControlId = null;
            this.btnClose.Font = new System.Drawing.Font("Arial", 9F);
            this.btnClose.Location = new System.Drawing.Point(745, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 40);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.SystemColors.Control;
            this.btnExport.ControlId = null;
            this.btnExport.Font = new System.Drawing.Font("Arial", 9F);
            this.btnExport.Location = new System.Drawing.Point(280, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(86, 40);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // pnlButtons2
            // 
            this.pnlButtons2.ControlId = null;
            this.pnlButtons2.Controls.Add(this.btnRankDepr);
            this.pnlButtons2.Controls.Add(this.btnTransferAsset);
            this.pnlButtons2.Controls.Add(this.btnAccDepr);
            this.pnlButtons2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlButtons2.Location = new System.Drawing.Point(471, 0);
            this.pnlButtons2.Name = "pnlButtons2";
            this.pnlButtons2.Size = new System.Drawing.Size(268, 49);
            this.pnlButtons2.TabIndex = 25;
            // 
            // btnRankDepr
            // 
            this.btnRankDepr.BackColor = System.Drawing.SystemColors.Control;
            this.btnRankDepr.ControlId = null;
            this.btnRankDepr.Font = new System.Drawing.Font("Arial", 9F);
            this.btnRankDepr.Location = new System.Drawing.Point(91, 4);
            this.btnRankDepr.Name = "btnRankDepr";
            this.btnRankDepr.Size = new System.Drawing.Size(86, 40);
            this.btnRankDepr.TabIndex = 11;
            this.btnRankDepr.Text = "Rank Depr";
            this.btnRankDepr.UseVisualStyleBackColor = false;
            this.btnRankDepr.Click += new System.EventHandler(this.btnRankDepr_Click);
            // 
            // btnTransferAsset
            // 
            this.btnTransferAsset.BackColor = System.Drawing.SystemColors.Control;
            this.btnTransferAsset.ControlId = null;
            this.btnTransferAsset.Font = new System.Drawing.Font("Arial", 9F);
            this.btnTransferAsset.Location = new System.Drawing.Point(179, 3);
            this.btnTransferAsset.Name = "btnTransferAsset";
            this.btnTransferAsset.Size = new System.Drawing.Size(86, 40);
            this.btnTransferAsset.TabIndex = 12;
            this.btnTransferAsset.Text = "Transfer Asset";
            this.btnTransferAsset.UseVisualStyleBackColor = false;
            this.btnTransferAsset.Click += new System.EventHandler(this.btnTransferAsset_Click);
            // 
            // btnAccDepr
            // 
            this.btnAccDepr.BackColor = System.Drawing.SystemColors.Control;
            this.btnAccDepr.ControlId = null;
            this.btnAccDepr.Font = new System.Drawing.Font("Arial", 9F);
            this.btnAccDepr.Location = new System.Drawing.Point(3, 4);
            this.btnAccDepr.Name = "btnAccDepr";
            this.btnAccDepr.Size = new System.Drawing.Size(86, 40);
            this.btnAccDepr.TabIndex = 10;
            this.btnAccDepr.Text = "Account Depr";
            this.btnAccDepr.UseVisualStyleBackColor = false;
            this.btnAccDepr.Click += new System.EventHandler(this.btnAccDepr_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.btnUpdate.ControlId = null;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Font = new System.Drawing.Font("Arial", 9F);
            this.btnUpdate.Location = new System.Drawing.Point(187, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(86, 40);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.ControlId = null;
            this.btnAdd.Font = new System.Drawing.Font("Arial", 9F);
            this.btnAdd.Location = new System.Drawing.Point(95, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(86, 40);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearch.ControlId = null;
            this.btnSearch.Font = new System.Drawing.Font("Arial", 9F);
            this.btnSearch.Location = new System.Drawing.Point(3, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(86, 40);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvAccountData
            // 
            this.dgvAccountData.AllowUserToAddRows = false;
            this.dgvAccountData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle58.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle58.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle58.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle58.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle58.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle58.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAccountData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle58;
            this.dgvAccountData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccountData.ControlId = null;
            dataGridViewCellStyle59.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle59.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle59.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle59.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle59.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle59.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle59.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAccountData.DefaultCellStyle = dataGridViewCellStyle59;
            this.dgvAccountData.Location = new System.Drawing.Point(0, 343);
            this.dgvAccountData.Name = "dgvAccountData";
            dataGridViewCellStyle60.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle60.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle60.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle60.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle60.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle60.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAccountData.RowHeadersDefaultCellStyle = dataGridViewCellStyle60;
            this.dgvAccountData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccountData.Size = new System.Drawing.Size(915, 124);
            this.dgvAccountData.TabIndex = 27;
            this.dgvAccountData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAccountData_CellClick);
            this.dgvAccountData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAccountData_CellDoubleClick);
            // 
            // sttStrip
            // 
            this.sttStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsRowCounter});
            this.sttStrip.Location = new System.Drawing.Point(0, 478);
            this.sttStrip.Name = "sttStrip";
            this.sttStrip.Size = new System.Drawing.Size(915, 22);
            this.sttStrip.TabIndex = 28;
            this.sttStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(864, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // tsRowCounter
            // 
            this.tsRowCounter.Name = "tsRowCounter";
            this.tsRowCounter.Size = new System.Drawing.Size(36, 17);
            this.tsRowCounter.Text = "None";
            // 
            // Warehouse_Equipment_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 500);
            this.Controls.Add(this.sttStrip);
            this.Controls.Add(this.dgvAccountData);
            this.Controls.Add(this.pnlButtons1);
            this.Controls.Add(this.grt_Option);
            this.Name = "Warehouse_Equipment_Form";
            this.Text = "Warehouse Equipment Form";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.Warehouse_Equipment_Form_Load);
            this.Controls.SetChildIndex(this.grt_Option, 0);
            this.Controls.SetChildIndex(this.pnlButtons1, 0);
            this.Controls.SetChildIndex(this.dgvAccountData, 0);
            this.Controls.SetChildIndex(this.sttStrip, 0);
            this.grt_Option.ResumeLayout(false);
            this.tab_Search.ResumeLayout(false);
            this.tab_Search.PerformLayout();
            this.tab_depreciation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeprCalc)).EndInit();
            this.tab_TotalCost.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccCounter)).EndInit();
            this.pnlButtons1.ResumeLayout(false);
            this.pnlButtons2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountData)).EndInit();
            this.sttStrip.ResumeLayout(false);
            this.sttStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.TabControlCommon grt_Option;
        private System.Windows.Forms.TabPage tab_Search;
        private Framework.TreeViewCommon trvAsset;
        private Framework.TreeViewCommon trvOther;
        private Framework.LabelCommon labelCommon2;
        private Framework.TextBoxCommon txtAssetName;
        private Framework.LabelCommon labelCommon1;
        private Framework.TextBoxCommon txtAssetCode;
        private System.Windows.Forms.TabPage tab_depreciation;
        private Framework.DataGridViewCommon dgvDeprCalc;
        private System.Windows.Forms.TabPage tab_TotalCost;
        private Framework.DataGridViewCommon dgvAccCounter;
        private System.Windows.Forms.DataGridViewTextBoxColumn aquisition_cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn month_depr;
        private System.Windows.Forms.DataGridViewTextBoxColumn curr_depr;
        private System.Windows.Forms.DataGridViewTextBoxColumn accum_depr;
        private System.Windows.Forms.DataGridViewTextBoxColumn net_value;
        private System.Windows.Forms.DataGridViewTextBoxColumn inventoried;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_machine;
        private Framework.PanelCommon pnlButtons1;
        private Framework.ButtonCommon btnClear;
        private Framework.ButtonCommon btnExport;
        private Framework.ButtonCommon btnUpdate;
        private Framework.ButtonCommon btnAdd;
        private Framework.ButtonCommon btnSearch;
        private Framework.PanelCommon pnlButtons2;
        private Framework.ButtonCommon btnRankDepr;
        private Framework.ButtonCommon btnTransferAsset;
        private Framework.ButtonCommon btnAccDepr;
        private Framework.ButtonCommon btnClose;
        private Framework.DataGridViewCommon dgvAccountData;
        private System.Windows.Forms.StatusStrip sttStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsRowCounter;
    }
}