namespace FA_WAREHOUSE_MANAGEMENT_SYSTEM.View
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Account Code");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Rank");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Section");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Now Location");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Inventory Time");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Valid");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Expired");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Net Value", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Factory");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Unit");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Asset Model");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Asset Type");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Invoice");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Label Status");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Warehouse_Equipment_Form));
            this.grt_Option = new System.Windows.Forms.TabControl();
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.trvOther = new System.Windows.Forms.TreeView();
            this.trvAsset = new System.Windows.Forms.TreeView();
            this.txtAssetName = new System.Windows.Forms.TextBox();
            this.txtAssetCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tab_depreciation = new System.Windows.Forms.TabPage();
            this.dgvDeprCalc = new System.Windows.Forms.DataGridView();
            this.tab_TotalCost = new System.Windows.Forms.TabPage();
            this.dgvAccCounter = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnlButton1 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlButton2 = new System.Windows.Forms.Panel();
            this.btnTransferAsset = new System.Windows.Forms.Button();
            this.btnAccDepr = new System.Windows.Forms.Button();
            this.btnRankDepr = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grt_Option.SuspendLayout();
            this.tabSearch.SuspendLayout();
            this.tab_depreciation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeprCalc)).BeginInit();
            this.tab_TotalCost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccCounter)).BeginInit();
            this.pnlButton1.SuspendLayout();
            this.pnlButton2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grt_Option
            // 
            this.grt_Option.Controls.Add(this.tabSearch);
            this.grt_Option.Controls.Add(this.tab_depreciation);
            this.grt_Option.Controls.Add(this.tab_TotalCost);
            this.grt_Option.Dock = System.Windows.Forms.DockStyle.Top;
            this.grt_Option.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grt_Option.Location = new System.Drawing.Point(145, 69);
            this.grt_Option.Name = "grt_Option";
            this.grt_Option.SelectedIndex = 0;
            this.grt_Option.Size = new System.Drawing.Size(1117, 205);
            this.grt_Option.TabIndex = 0;
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.trvOther);
            this.tabSearch.Controls.Add(this.trvAsset);
            this.tabSearch.Controls.Add(this.txtAssetName);
            this.tabSearch.Controls.Add(this.txtAssetCode);
            this.tabSearch.Controls.Add(this.label2);
            this.tabSearch.Controls.Add(this.label1);
            this.tabSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSearch.Location = new System.Drawing.Point(4, 25);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearch.Size = new System.Drawing.Size(1109, 176);
            this.tabSearch.TabIndex = 0;
            this.tabSearch.Text = "Search";
            this.tabSearch.UseVisualStyleBackColor = true;
            // 
            // trvOther
            // 
            this.trvOther.CheckBoxes = true;
            this.trvOther.Dock = System.Windows.Forms.DockStyle.Right;
            this.trvOther.Location = new System.Drawing.Point(706, 3);
            this.trvOther.Name = "trvOther";
            treeNode1.Name = "account_cd";
            treeNode1.Text = "Account Code";
            treeNode2.Name = "rank_cd";
            treeNode2.Text = "Rank";
            treeNode3.Name = "account_location_cd";
            treeNode3.Text = "Section";
            treeNode4.Name = "location_cd";
            treeNode4.Text = "Now Location";
            treeNode5.Name = "invertory_time_cd";
            treeNode5.Text = "Inventory Time";
            treeNode6.Name = "valid";
            treeNode6.Text = "Valid";
            treeNode7.Name = "expired";
            treeNode7.Text = "Expired";
            treeNode8.Name = "net_value";
            treeNode8.Text = "Net Value";
            treeNode9.Name = "factory_cd";
            treeNode9.Text = "Factory";
            treeNode10.Name = "unit_cd";
            treeNode10.Text = "Unit";
            this.trvOther.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode8,
            treeNode9,
            treeNode10});
            this.trvOther.Size = new System.Drawing.Size(203, 170);
            this.trvOther.TabIndex = 5;
            // 
            // trvAsset
            // 
            this.trvAsset.CheckBoxes = true;
            this.trvAsset.Dock = System.Windows.Forms.DockStyle.Right;
            this.trvAsset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvAsset.Location = new System.Drawing.Point(909, 3);
            this.trvAsset.Name = "trvAsset";
            treeNode11.Name = "asset_model";
            treeNode11.Text = "Asset Model";
            treeNode12.Name = "asset_type";
            treeNode12.Text = "Asset Type";
            treeNode13.Name = "asset_invoice";
            treeNode13.Text = "Invoice";
            treeNode14.Name = "label_status";
            treeNode14.Text = "Label Status";
            this.trvAsset.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14});
            this.trvAsset.Size = new System.Drawing.Size(197, 170);
            this.trvAsset.TabIndex = 4;
            // 
            // txtAssetName
            // 
            this.txtAssetName.Location = new System.Drawing.Point(110, 56);
            this.txtAssetName.Name = "txtAssetName";
            this.txtAssetName.Size = new System.Drawing.Size(167, 23);
            this.txtAssetName.TabIndex = 3;
            // 
            // txtAssetCode
            // 
            this.txtAssetCode.Location = new System.Drawing.Point(110, 16);
            this.txtAssetCode.Name = "txtAssetCode";
            this.txtAssetCode.Size = new System.Drawing.Size(167, 23);
            this.txtAssetCode.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Asset Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asset Code";
            // 
            // tab_depreciation
            // 
            this.tab_depreciation.Controls.Add(this.dgvDeprCalc);
            this.tab_depreciation.Location = new System.Drawing.Point(4, 25);
            this.tab_depreciation.Name = "tab_depreciation";
            this.tab_depreciation.Padding = new System.Windows.Forms.Padding(3);
            this.tab_depreciation.Size = new System.Drawing.Size(840, 176);
            this.tab_depreciation.TabIndex = 1;
            this.tab_depreciation.Text = "Depreciation";
            this.tab_depreciation.UseVisualStyleBackColor = true;
            // 
            // dgvDeprCalc
            // 
            this.dgvDeprCalc.AllowUserToAddRows = false;
            this.dgvDeprCalc.AllowUserToDeleteRows = false;
            this.dgvDeprCalc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeprCalc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDeprCalc.Location = new System.Drawing.Point(3, 3);
            this.dgvDeprCalc.Name = "dgvDeprCalc";
            this.dgvDeprCalc.ReadOnly = true;
            this.dgvDeprCalc.Size = new System.Drawing.Size(834, 170);
            this.dgvDeprCalc.TabIndex = 0;
            // 
            // tab_TotalCost
            // 
            this.tab_TotalCost.Controls.Add(this.dgvAccCounter);
            this.tab_TotalCost.Location = new System.Drawing.Point(4, 25);
            this.tab_TotalCost.Name = "tab_TotalCost";
            this.tab_TotalCost.Padding = new System.Windows.Forms.Padding(3);
            this.tab_TotalCost.Size = new System.Drawing.Size(840, 176);
            this.tab_TotalCost.TabIndex = 2;
            this.tab_TotalCost.Text = "Total Cost";
            this.tab_TotalCost.UseVisualStyleBackColor = true;
            // 
            // dgvAccCounter
            // 
            this.dgvAccCounter.AllowUserToAddRows = false;
            this.dgvAccCounter.AllowUserToDeleteRows = false;
            this.dgvAccCounter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccCounter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAccCounter.Location = new System.Drawing.Point(3, 3);
            this.dgvAccCounter.Name = "dgvAccCounter";
            this.dgvAccCounter.ReadOnly = true;
            this.dgvAccCounter.Size = new System.Drawing.Size(834, 170);
            this.dgvAccCounter.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(145, 274);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1117, 10);
            this.panel4.TabIndex = 3;
            // 
            // pnlButton1
            // 
            this.pnlButton1.Controls.Add(this.btnClear);
            this.pnlButton1.Controls.Add(this.btnExport);
            this.pnlButton1.Controls.Add(this.btnUpdate);
            this.pnlButton1.Controls.Add(this.btnAdd);
            this.pnlButton1.Controls.Add(this.btnSearch);
            this.pnlButton1.Location = new System.Drawing.Point(145, 286);
            this.pnlButton1.Name = "pnlButton1";
            this.pnlButton1.Size = new System.Drawing.Size(597, 58);
            this.pnlButton1.TabIndex = 4;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(486, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 45);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(366, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 45);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(246, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 45);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(126, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 45);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(6, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 45);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // pnlButton2
            // 
            this.pnlButton2.Controls.Add(this.btnTransferAsset);
            this.pnlButton2.Controls.Add(this.btnAccDepr);
            this.pnlButton2.Controls.Add(this.btnRankDepr);
            this.pnlButton2.Location = new System.Drawing.Point(748, 286);
            this.pnlButton2.Name = "pnlButton2";
            this.pnlButton2.Size = new System.Drawing.Size(360, 58);
            this.pnlButton2.TabIndex = 5;
            // 
            // btnTransferAsset
            // 
            this.btnTransferAsset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransferAsset.Location = new System.Drawing.Point(243, 4);
            this.btnTransferAsset.Name = "btnTransferAsset";
            this.btnTransferAsset.Size = new System.Drawing.Size(100, 45);
            this.btnTransferAsset.TabIndex = 6;
            this.btnTransferAsset.Text = "Transfer Asset";
            this.btnTransferAsset.UseVisualStyleBackColor = true;
            // 
            // btnAccDepr
            // 
            this.btnAccDepr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccDepr.Location = new System.Drawing.Point(3, 4);
            this.btnAccDepr.Name = "btnAccDepr";
            this.btnAccDepr.Size = new System.Drawing.Size(100, 45);
            this.btnAccDepr.TabIndex = 5;
            this.btnAccDepr.Text = "Account Depr";
            this.btnAccDepr.UseVisualStyleBackColor = true;
            // 
            // btnRankDepr
            // 
            this.btnRankDepr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRankDepr.Location = new System.Drawing.Point(123, 4);
            this.btnRankDepr.Name = "btnRankDepr";
            this.btnRankDepr.Size = new System.Drawing.Size(100, 45);
            this.btnRankDepr.TabIndex = 4;
            this.btnRankDepr.Text = "Rank Depr";
            this.btnRankDepr.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1123, 290);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 45);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // Warehouse_Equipment_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 529);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlButton2);
            this.Controls.Add(this.pnlButton1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.grt_Option);
            this.dept = "";
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.logintime = new System.DateTime(((long)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.name = "";
            this.Name = "Warehouse_Equipment_Form";
            this.Text = "Warehouse Equipment Form";
            this.tittle = "FormCommon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Warehouse_Equipment_Form_Load);
            this.Controls.SetChildIndex(this.grt_Option, 0);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.Controls.SetChildIndex(this.pnlButton1, 0);
            this.Controls.SetChildIndex(this.pnlButton2, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.grt_Option.ResumeLayout(false);
            this.tabSearch.ResumeLayout(false);
            this.tabSearch.PerformLayout();
            this.tab_depreciation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeprCalc)).EndInit();
            this.tab_TotalCost.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccCounter)).EndInit();
            this.pnlButton1.ResumeLayout(false);
            this.pnlButton2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl grt_Option;
        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.TabPage tab_depreciation;
        private System.Windows.Forms.DataGridView dgvDeprCalc;
        private System.Windows.Forms.TabPage tab_TotalCost;
        private System.Windows.Forms.DataGridView dgvAccCounter;
        private System.Windows.Forms.TreeView trvOther;
        private System.Windows.Forms.TreeView trvAsset;
        private System.Windows.Forms.TextBox txtAssetName;
        private System.Windows.Forms.TextBox txtAssetCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel pnlButton1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlButton2;
        private System.Windows.Forms.Button btnTransferAsset;
        private System.Windows.Forms.Button btnAccDepr;
        private System.Windows.Forms.Button btnRankDepr;
        private System.Windows.Forms.Button btnClose;
    }
}