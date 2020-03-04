using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertLB6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowserFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog opfrm = new OpenFileDialog();
            opfrm.Filter = "Text File (*.txt)|*.txt|CSV File (*.csv)|*.csv|All File (*.*)|*.*";
            if (opfrm.ShowDialog() == DialogResult.OK)
            {
                txtFileSource.Text = opfrm.FileName;
            }
        }

        private void btnBrowserTo_Click(object sender, EventArgs e)
        {
            OpenFileDialog opfrm = new OpenFileDialog();
            opfrm.Filter = "Text File (*.txt)|*.txt|CSV File (*.csv)|*.csv|All File (*.*)|*.*";
            if (opfrm.ShowDialog() == DialogResult.OK)
            {
                txtFileTo.Text = opfrm.FileName;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int n = 0;
            bool firstline = true;
            datafile dataf = new datafile();
            List<datafile> listData = new List<datafile>();
            foreach (string line in File.ReadLines(txtFileSource.Text))
            {
                if (!string.IsNullOrEmpty(line) && n == 0)
                {
                    dataf.serno = line;
                    n++;
                }
                if (line.Contains("JUDGE CW"))
                {
                    dataf.judgeCW = line.Split('=')[1].Trim();
                    n++;
                }
                if (line.Contains("JUDGE CCW"))
                {
                    dataf.judgeCW = line.Split('=')[1].Trim();
                    n++;
                }
                if (!line.Contains("<DATA>") && !firstline)
                {

                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    public class datafile
    {
        public string serno { get; set; }
        public string judgeCW { get; set; }
        public string judgeCCW { get; set; }
        public string col1 { get; set; }
        public string col2 { get; set; }
        public string col3 { get; set; }
        public string col4 { get; set; }
        public string col5 { get; set; }
        public string col6 { get; set; }
        public string col7 { get; set; }
        public string col8 { get; set; }
        public string col9 { get; set; }
        public string col10 { get; set; }
        public string col11 { get; set; }
        public string col12 { get; set; }
        public string col13 { get; set; }
        public string col14 { get; set; }
        public string col15 { get; set; }
        public string col16 { get; set; }
        public string col17 { get; set; }
        public string col18 { get; set; }
        public string col19 { get; set; }
        public string col20 { get; set; }
        public string model { get; set; }
    }
}