namespace IQCManagementSystem.View.Formmain
{
    partial class Formmain
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
            this.btnEquipment = new System.Windows.Forms.Button();
            this.btnInventorycheck = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEquipment
            // 
            this.btnEquipment.Location = new System.Drawing.Point(183, 94);
            this.btnEquipment.Name = "btnEquipment";
            this.btnEquipment.Size = new System.Drawing.Size(183, 80);
            this.btnEquipment.TabIndex = 9;
            this.btnEquipment.Text = "Equipment Management";
            this.btnEquipment.UseVisualStyleBackColor = true;
            this.btnEquipment.Click += new System.EventHandler(this.btnEquipment_Click);
            // 
            // btnInventorycheck
            // 
            this.btnInventorycheck.Location = new System.Drawing.Point(183, 199);
            this.btnInventorycheck.Name = "btnInventorycheck";
            this.btnInventorycheck.Size = new System.Drawing.Size(183, 80);
            this.btnInventorycheck.TabIndex = 10;
            this.btnInventorycheck.Text = "Inventory Check";
            this.btnInventorycheck.UseVisualStyleBackColor = true;
            // 
            // Formmain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 500);
            this.code = "";
            this.Controls.Add(this.btnInventorycheck);
            this.Controls.Add(this.btnEquipment);
            this.name = "";
            this.Name = "Formmain";
            this.Text = "FormMain";
            this.tittle = "FormCommon";
            this.Controls.SetChildIndex(this.btnEquipment, 0);
            this.Controls.SetChildIndex(this.btnInventorycheck, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEquipment;
        private System.Windows.Forms.Button btnInventorycheck;
    }
}