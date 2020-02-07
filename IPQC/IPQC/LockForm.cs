using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPQC
{
    public partial class LockForm : Form
    {
        public LockForm()
        {
            InitializeComponent();
           // txtPass.Text = "ncvp2222";
        }

        private void LockForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("Do you want to exit?", "Waring", MessageBoxButtons.YesNo) == DialogResult.No)
            //    e.Cancel = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtPass.Text == "ncvp2222")
            {
                //FormAddModel fomadd = new FormAddModel();
                //fomadd.ShowDialog();
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Password not correct","ERROR", MessageBoxButtons.OK);
        }

       
    }
}
