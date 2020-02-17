namespace CreateNewProcessNSTV
{
    partial class PushDataIntoServer
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
            this.lsbAllFileCSV = new System.Windows.Forms.ListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnPush = new System.Windows.Forms.Button();
            this.btnCreateTable = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lsbAllFileCSV
            // 
            this.lsbAllFileCSV.FormattingEnabled = true;
            this.lsbAllFileCSV.HorizontalScrollbar = true;
            this.lsbAllFileCSV.Location = new System.Drawing.Point(12, 12);
            this.lsbAllFileCSV.Name = "lsbAllFileCSV";
            this.lsbAllFileCSV.Size = new System.Drawing.Size(458, 342);
            this.lsbAllFileCSV.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 360);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPush
            // 
            this.btnPush.Location = new System.Drawing.Point(93, 360);
            this.btnPush.Name = "btnPush";
            this.btnPush.Size = new System.Drawing.Size(75, 23);
            this.btnPush.TabIndex = 2;
            this.btnPush.Text = "Push";
            this.btnPush.UseVisualStyleBackColor = true;
            this.btnPush.Click += new System.EventHandler(this.btnPush_Click);
            // 
            // btnCreateTable
            // 
            this.btnCreateTable.Location = new System.Drawing.Point(174, 360);
            this.btnCreateTable.Name = "btnCreateTable";
            this.btnCreateTable.Size = new System.Drawing.Size(75, 23);
            this.btnCreateTable.TabIndex = 3;
            this.btnCreateTable.Text = "Create Table";
            this.btnCreateTable.UseVisualStyleBackColor = true;
            this.btnCreateTable.Click += new System.EventHandler(this.btnCreateTable_Click);
            // 
            // PushDataIntoServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 496);
            this.Controls.Add(this.btnCreateTable);
            this.Controls.Add(this.btnPush);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lsbAllFileCSV);
            this.Name = "PushDataIntoServer";
            this.Text = "PushDataIntoServer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lsbAllFileCSV;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnPush;
        private System.Windows.Forms.Button btnCreateTable;
    }
}