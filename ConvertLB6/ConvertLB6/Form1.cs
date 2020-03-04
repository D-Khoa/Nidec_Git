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
            SaveFileDialog savefrm = new SaveFileDialog();
            savefrm.CheckFileExists = false;
            savefrm.CheckPathExists = false;
            savefrm.Filter = "Text File (*.txt)|*.txt|CSV File (*.csv)|*.csv|All File (*.*)|*.*";
            if (savefrm.ShowDialog() == DialogResult.OK)
            {
                txtFileTo.Text = savefrm.FileName;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                int n = 0;
                string cols = string.Empty;
                string dataline = string.Empty;
                List<string> filecontent = new List<string>();
                cols = "barcode;JUDGE CW;JUDGE CCW;";
                for (int i = 1; i < 21; i++)
                    cols += "data " + i + ";";
                cols += "model" + Environment.NewLine;
                filecontent.Add(cols);
                foreach (string line in File.ReadLines(txtFileSource.Text))
                {
                    if (!string.IsNullOrEmpty(line) && !line.Contains("<DATA>") && n < 24)
                    {
                        if (!string.IsNullOrEmpty(line) && n == 0)
                        {
                            dataline += line.Trim() + ";";                  //0
                        }
                        if (line.Contains("JUDGE CW"))
                        {
                            string temp = line.Replace(" ", string.Empty);  //1
                            temp = temp.Split('=')[1];
                            dataline += temp + ";";
                        }
                        if (line.Contains("JUDGE CCW"))                     //2
                        {
                            string temp = line.Replace(" ", string.Empty);
                            temp = temp.Split('=')[1];
                            dataline += temp + ";";
                        }
                        if (line.Contains(",") && (n > 2))                  //3~23
                        {
                            string temp = line.Split(',')[0];
                            dataline += temp + ";";
                        }
                        n++;
                    }
                    if (n == 24)                                            //24
                    {
                        string temp = line.Trim();
                        dataline += temp + Environment.NewLine;
                        filecontent.Add(dataline);
                        dataline = string.Empty;
                        n = 0;
                    }
                }
                File.WriteAllLines(txtFileTo.Text, filecontent);
                MessageBox.Show("Convert completed!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}