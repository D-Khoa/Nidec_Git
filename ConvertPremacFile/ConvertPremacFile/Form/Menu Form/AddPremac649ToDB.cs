using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConvertPremacFile.Model;

namespace ConvertPremacFile
{
    public partial class AddPremac649ToDB : Form
    {
        pts_premac649 premacfile = new pts_premac649();
        public AddPremac649ToDB()
        {
            InitializeComponent();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openf = new OpenFileDialog();
                if (openf.ShowDialog() == DialogResult.OK)
                {
                    premacfile.GetListPremacItem(openf.FileName);
                    premacfile.WriteToDB(premacfile.listPremacItem);
                    MessageBox.Show("Complete");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
