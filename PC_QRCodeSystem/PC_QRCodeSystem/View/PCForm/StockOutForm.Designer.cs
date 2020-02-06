namespace PC_QRCodeSystem.View
{
    partial class StockOutForm
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
            this.grt_Main = new System.Windows.Forms.TabControl();
            this.tab_MainMenu = new System.Windows.Forms.TabPage();
            this.tab_Plan = new System.Windows.Forms.TabPage();
            this.tab_Request = new System.Windows.Forms.TabPage();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvStockOut = new System.Windows.Forms.DataGridView();
            this.tab_PrintList = new System.Windows.Forms.TabPage();
            this.grt_Main.SuspendLayout();
            this.tab_Request.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockOut)).BeginInit();
            this.SuspendLayout();
            // 
            // grt_Main
            // 
            this.grt_Main.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.grt_Main.Controls.Add(this.tab_MainMenu);
            this.grt_Main.Controls.Add(this.tab_Plan);
            this.grt_Main.Controls.Add(this.tab_Request);
            this.grt_Main.Controls.Add(this.tab_PrintList);
            this.grt_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grt_Main.Location = new System.Drawing.Point(150, 69);
            this.grt_Main.Name = "grt_Main";
            this.grt_Main.SelectedIndex = 0;
            this.grt_Main.Size = new System.Drawing.Size(614, 433);
            this.grt_Main.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.grt_Main.TabIndex = 22;
            // 
            // tab_MainMenu
            // 
            this.tab_MainMenu.Location = new System.Drawing.Point(4, 25);
            this.tab_MainMenu.Name = "tab_MainMenu";
            this.tab_MainMenu.Padding = new System.Windows.Forms.Padding(3);
            this.tab_MainMenu.Size = new System.Drawing.Size(606, 404);
            this.tab_MainMenu.TabIndex = 0;
            this.tab_MainMenu.Text = "Menu";
            this.tab_MainMenu.UseVisualStyleBackColor = true;
            // 
            // tab_Plan
            // 
            this.tab_Plan.Location = new System.Drawing.Point(4, 25);
            this.tab_Plan.Name = "tab_Plan";
            this.tab_Plan.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Plan.Size = new System.Drawing.Size(606, 404);
            this.tab_Plan.TabIndex = 1;
            this.tab_Plan.Text = "Plan";
            this.tab_Plan.UseVisualStyleBackColor = true;
            // 
            // tab_Request
            // 
            this.tab_Request.Controls.Add(this.dgvStockOut);
            this.tab_Request.Controls.Add(this.pnlButtons);
            this.tab_Request.Location = new System.Drawing.Point(4, 25);
            this.tab_Request.Name = "tab_Request";
            this.tab_Request.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Request.Size = new System.Drawing.Size(606, 404);
            this.tab_Request.TabIndex = 2;
            this.tab_Request.Text = "Request";
            this.tab_Request.UseVisualStyleBackColor = true;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSearch);
            this.pnlButtons.Controls.Add(this.btnUpdate);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnAdd);
            this.pnlButtons.Controls.Add(this.btnClear);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtons.Location = new System.Drawing.Point(3, 3);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(600, 50);
            this.pnlButtons.TabIndex = 22;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(40, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 40);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(260, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(80, 40);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(370, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 40);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(150, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 40);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(480, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 40);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // dgvStockOut
            // 
            this.dgvStockOut.AllowUserToAddRows = false;
            this.dgvStockOut.AllowUserToDeleteRows = false;
            this.dgvStockOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStockOut.Location = new System.Drawing.Point(3, 53);
            this.dgvStockOut.Name = "dgvStockOut";
            this.dgvStockOut.ReadOnly = true;
            this.dgvStockOut.Size = new System.Drawing.Size(600, 348);
            this.dgvStockOut.TabIndex = 23;
            // 
            // tab_PrintList
            // 
            this.tab_PrintList.Location = new System.Drawing.Point(4, 25);
            this.tab_PrintList.Name = "tab_PrintList";
            this.tab_PrintList.Padding = new System.Windows.Forms.Padding(3);
            this.tab_PrintList.Size = new System.Drawing.Size(606, 404);
            this.tab_PrintList.TabIndex = 3;
            this.tab_PrintList.Text = "Print List";
            this.tab_PrintList.UseVisualStyleBackColor = true;
            // 
            // StockOutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 502);
            this.Controls.Add(this.grt_Main);
            this.dept = "";
            this.logintime = new System.DateTime(((long)(0)));
            this.name = "";
            this.Name = "StockOutForm";
            this.position = "";
            this.Text = "StockOutForm";
            this.tittle = "FormCommon";
            this.Controls.SetChildIndex(this.grt_Main, 0);
            this.grt_Main.ResumeLayout(false);
            this.tab_Request.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockOut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl grt_Main;
        private System.Windows.Forms.TabPage tab_MainMenu;
        private System.Windows.Forms.TabPage tab_Plan;
        private System.Windows.Forms.TabPage tab_Request;
        private System.Windows.Forms.DataGridView dgvStockOut;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TabPage tab_PrintList;
    }
}