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

namespace Convert_Supplier
{
    public partial class ConvertSupplier : Form
    {
        OpenFileDialog chooseFolder;
        List<string> setString;
        string[] filePath;
        string settingfile;
        string file;
        int c;
        #region LOAD FILE
        public ConvertSupplier()
        {
            InitializeComponent();
            setString = new List<string>();
            settingfile = @"C:\ConvertSupplier\ini.txt";
        }

        private void ConvertSupplier_Load(object sender, EventArgs e)
        {
            if (File.Exists(settingfile))
            {
                setString = File.ReadLines(settingfile).ToList();
            }
            txtFrom.Text = setString[0].Trim().Split('=')[1];
            txtTo.Text = setString[1].Trim().Split('=')[1];

        }
        #endregion
        #region CHOOSE FOLDER DATA

        private void btnFromFolder_Click(object sender, EventArgs e)
        {
            txtFrom.Text = ChooseFolder();
        }

        private void btnToFolder_Click(object sender, EventArgs e)
        {
            txtTo.Text = ChooseFolder();
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
        #region BACKGROUNDWORKER SETUP
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
                    tsStatus.Text = "Convert Data...";
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
        #region CONVERT FILE

        private void EditAndSendFile()
        {
            try
            {
                filePath = Directory.GetFiles(txtFrom.Text, "*.txt");
            }
            catch { }
        }
        #endregion
        #region BUTTON
        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                if (!backgroundWorker1.IsBusy)
                {
                    btnConvert.Enabled = false;
                    btnStop.Enabled = true;
                    txtFrom.ReadOnly = true;
                    btnFromFolder.Enabled = false;
                    txtTo.Enabled = false;
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

        }
        #endregion
        #region FORM CLOSING
        private void ConvertSupplier_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (btnStop.Enabled)
                    e.Cancel = true;
                setString.Clear();
                setString.Add("From Folder =" + txtFrom.Text);
                setString.Add("To Folder =" + txtTo.Text);
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

     
    }

}
