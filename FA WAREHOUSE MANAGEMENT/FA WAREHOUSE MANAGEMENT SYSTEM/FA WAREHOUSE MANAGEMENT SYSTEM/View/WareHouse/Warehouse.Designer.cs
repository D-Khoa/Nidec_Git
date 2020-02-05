namespace FA_WAREHOUSE_MANAGEMENT_SYSTEM.View
{
    partial class Warehouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Warehouse));
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnWHOutput = new System.Windows.Forms.Button();
            this.btnWHInput = new System.Windows.Forms.Button();
            this.btnWHEquipment = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnWHOutput);
            this.panel4.Controls.Add(this.btnWHInput);
            this.panel4.Controls.Add(this.btnWHEquipment);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(145, 69);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(656, 263);
            this.panel4.TabIndex = 3;
            // 
            // btnWHOutput
            // 
            this.btnWHOutput.Location = new System.Drawing.Point(53, 138);
            this.btnWHOutput.Name = "btnWHOutput";
            this.btnWHOutput.Size = new System.Drawing.Size(133, 57);
            this.btnWHOutput.TabIndex = 2;
            this.btnWHOutput.Text = "Warehouse Output";
            this.btnWHOutput.UseVisualStyleBackColor = true;
            this.btnWHOutput.Click += new System.EventHandler(this.btnWHOutput_Click);
            // 
            // btnWHInput
            // 
            this.btnWHInput.Location = new System.Drawing.Point(254, 29);
            this.btnWHInput.Name = "btnWHInput";
            this.btnWHInput.Size = new System.Drawing.Size(133, 57);
            this.btnWHInput.TabIndex = 1;
            this.btnWHInput.Text = "Warehouse Input";
            this.btnWHInput.UseVisualStyleBackColor = true;
            this.btnWHInput.Click += new System.EventHandler(this.btnWHInput_Click);
            // 
            // btnWHEquipment
            // 
            this.btnWHEquipment.Location = new System.Drawing.Point(53, 31);
            this.btnWHEquipment.Name = "btnWHEquipment";
            this.btnWHEquipment.Size = new System.Drawing.Size(133, 57);
            this.btnWHEquipment.TabIndex = 0;
            this.btnWHEquipment.Text = "Warehouse Equipment";
            this.btnWHEquipment.UseVisualStyleBackColor = true;
            this.btnWHEquipment.Click += new System.EventHandler(this.btnWHEquipment_Click);
            // 
            // Warehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 451);
            this.Controls.Add(this.panel4);
            this.dept = "";
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.logintime = new System.DateTime(((long)(0)));
            this.name = "";
            this.Name = "Warehouse";
            this.Text = "FA WAREHOUSE MANAGEMENT SYSTEM";
            this.tittle = "FormCommon";
//            this.Load += new System.EventHandler(this.Warehouse_Load);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnWHOutput;
        private System.Windows.Forms.Button btnWHInput;
        private System.Windows.Forms.Button btnWHEquipment;
    }
}