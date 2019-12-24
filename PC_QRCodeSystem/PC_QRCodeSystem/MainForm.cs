using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;
using PC_QRCodeSystem.View;

namespace PC_QRCodeSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (!UserData.role_permision.Contains(control.Tag))
                {
                    control.Enabled = false;
                }
            }
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            PCForm pcf = new PCForm();
            pcf.ShowDialog();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {

        }
    }
}
