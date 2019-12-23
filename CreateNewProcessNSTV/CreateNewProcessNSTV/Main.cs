using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CreateNewProcessNSTV.Model;

namespace CreateNewProcessNSTV
{
    public partial class Main : Form
    {
        DataTable dt = new DataTable();
        string[] a;
        string[] b;
        string model, site, factory, line, process, procname;

        public Main()
        {
            InitializeComponent();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "CSV Files (*.csv)|*.csv";
            if (of.ShowDialog() == DialogResult.OK)
            {
                GetData.GetProcessCSV(ref a, ref b, of.FileName);
                model = Path.GetFileName(of.FileName).Split('_')[1];
                lbModel.Text = model;
                lsbAfter.Items.Clear();
                lsbBefore.Items.Clear();
                foreach (string item in b)
                {
                    lsbBefore.Items.Add(item.Replace(" ", string.Empty));
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int i = lsbBefore.SelectedIndex;
            lsbAfter.Items.Add(lsbBefore.SelectedItem);
            lsbBefore.Items.Remove(lsbBefore.SelectedItem);
            if (lsbBefore.Items.Count > i)
                lsbBefore.SelectedIndex = i;
            else if (lsbBefore.Items.Count > 0)
                lsbBefore.SelectedIndex = i - 1;
            Thread.Sleep(100);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int i = lsbAfter.SelectedIndex;
            lsbBefore.Items.Add(lsbAfter.SelectedItem);
            lsbAfter.Items.Remove(lsbAfter.SelectedItem);
            if (lsbAfter.Items.Count > i)
                lsbAfter.SelectedIndex = i;
            else if (lsbAfter.Items.Count > 0)
                lsbAfter.SelectedIndex = i - 1;
            Thread.Sleep(100);
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            foreach (string item in lsbBefore.Items)
            {
                lsbAfter.Items.Add(item);
            }
            lsbBefore.Items.Clear();
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            foreach (string item in lsbAfter.Items)
            {
                lsbBefore.Items.Add(item);
            }
            lsbAfter.Items.Clear();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                GetData insertDB = new GetData();
                site = "NSTV";
                factory = "2B";
                line = "L01";
                process = "FCT";
                procname = "FCT and Noise";
                insertDB.InsertProcessDB(model, site, factory, line, process, procname, "", DateTime.Now);
                foreach (string item in lsbAfter.Items)
                {
                    insertDB.InsertInspectDB(model, site, factory, line, process, item, item, DateTime.Now);
                }
                MessageBox.Show("Complete!");
            }
            catch { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
