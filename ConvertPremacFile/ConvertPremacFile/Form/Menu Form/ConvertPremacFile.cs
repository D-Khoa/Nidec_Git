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


namespace ConvertPremacFile
{
    public partial class Menu_Form : Form
    {
        OpenFileDialog chooseFolder;
        List<string> setString;
        string settingfile;
        int c;
        public Menu_Form()
        {
            InitializeComponent();
            setString = new List<string>();
            settingfile = @"C:\Convert Premac File\ini.txt";
        }
        #region FORM LOAD
        private void Menu_Form_Load(object sender, EventArgs e)
        {
            if (File.Exists(settingfile))
            {
                setString = File.ReadLines(settingfile).ToList();
            }
            txtSupplier.Text = setString[0].Trim().Split('=')[1];
            txtItem.Text = setString[1].Trim().Split('=')[1];
        }

        private void Menu_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (btnStop.Enabled)
                    e.Cancel = true;
                setString.Clear();
                setString.Add("SUPPLIER FOLDER =" + txtSupplier.Text);
                setString.Add("ITEM FOLDER =" + txtItem.Text);
                if (!Directory.Exists(Path.GetDirectoryName(settingfile)))
                    Directory.CreateDirectory(Path.GetDirectoryName(settingfile));
                File.WriteAllLines(settingfile, setString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


        #region BACKGROUNDWORKER  
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            c = (int)numTimer.Value;
            for (int i = c; i >= 0; i--)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    backgroundWorker1.ReportProgress(c);
                    return;
                }
                backgroundWorker1.ReportProgress(i);
                Thread.Sleep(1000);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tsStatus.Text = "Waiting...";
            tsTimer.Text = e.ProgressPercentage.ToString() + " S";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                tsStatus.Text = "Stop Convert Data!!!!";
            }
            else if (e.Error != null)
            {
                MessageBox.Show(e.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    tsStatus.Text = "Sending Data...";
                    EditAndSendFile();
                    backgroundWorker1.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion
        #region EDIT & SEND FILE
        private void EditAndSendFile()
        {

        }
        #endregion
        #region BUTTON CONVERT    
        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                if (!backgroundWorker1.IsBusy)
                {
                    btnConvert.Enabled = false;
                    btnStop.Enabled = true;
                    txtSupplier.Enabled = false;
                    txtItem.Enabled = false;
                    btnBrowserSupplier.Enabled = false;     
                    btnBrowserItem.Enabled = false;
                    backgroundWorker1.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnConvert.Enabled = true;
            btnStop.Enabled = false;
            txtSupplier.Enabled = true;
            txtItem.Enabled = true;
            btnBrowserItem.Enabled = true;
            btnBrowserSupplier.Enabled = true;
            backgroundWorker1.CancelAsync();
        }
        #endregion

        #region CHOOSE FOLDER DATA
        private void btnBrowserSupplier_Click(object sender, EventArgs e)
        {
            txtSupplier.Text = ChooseFolder();
        }

        private void btnBrowserItem_Click(object sender, EventArgs e)
        {
            txtItem.Text = ChooseFolder();
        }
        private string ChooseFolder()
        {
            chooseFolder = new OpenFileDialog();
            chooseFolder.CheckFileExists = false;
            chooseFolder.CheckPathExists = false;
            chooseFolder.ShowReadOnly = true;
            chooseFolder.FileName = "Select Folder";
            if (chooseFolder.ShowDialog() == DialogResult.OK)
            {
                return Path.GetDirectoryName(chooseFolder.FileName) + @"\";
            }
            else
                return "";
        }
        #endregion
    }
}
