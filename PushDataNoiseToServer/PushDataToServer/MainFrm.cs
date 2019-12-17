using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace PushDataToServer
{
    public partial class MainFrm : Form
    {
        OpenFileDialog chooseFolder;
        List<string> setString;
        string[] filePath;
        string settingfile, Model;
        string serverfolder = @"\\192.168.145.7\nstvnoise$\FCT_NOISE\";
        string file;
        int c;

        public MainFrm()
        {
            InitializeComponent();
            setString = new List<string>();
            settingfile = @"C:\PushData\ini.txt";
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            if (File.Exists(settingfile))
            {
                setString = File.ReadLines(settingfile).ToList();
            }
            txtNo.Text = setString[0].Trim().Split('=')[1];
            txtFrom.Text = setString[1].Trim().Split('=')[1];
            if(!string.IsNullOrEmpty(setString[2].Trim().Split('=')[1]))
            serverfolder = setString[2].Trim().Split('=')[1];
        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            try
            {
                if (!backgroundWorker1.IsBusy)
                {
                    btnPush.Enabled = false;
                    btnStop.Enabled = true;
                    txtFrom.ReadOnly = true;
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
            btnPush.Enabled = true;
            btnStop.Enabled = false;
            txtFrom.ReadOnly = false;
            backgroundWorker1.CancelAsync();
        }

        #region BACKGROUND WORKER SETUP
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
                tsStatus.Text = "Stop Push Data!!!!";
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

        #region CHOOSE FOLDER DATA FROM
        private void btnBrowserFrom_Click(object sender, EventArgs e)
        {
            txtFrom.Text = ChooseFolder();
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

        private void EditAndSendFile()
        {
            filePath = Directory.GetFiles(txtFrom.Text, "*.csv");
            if (filePath != null)
            {
                foreach (string path in filePath)
                {
                    file = Path.GetFileName(path);
                    Model = file.Split('_')[1];
                    string date = file.Split('_')[2];

                    string modelfile = serverfolder + Model;
                    string No = modelfile + @"\" + txtNo.Text;
                    string fileserveryear = No + @"\" + date.Split('-')[0];
                    string fileservermonth = fileserveryear + @"\" + date.Split('-')[1];
                    if (!Directory.Exists(modelfile))
                        Directory.CreateDirectory(Model);
                    if (!Directory.Exists(No))
                        Directory.CreateDirectory(No);
                    if (!Directory.Exists(fileserveryear))
                        Directory.CreateDirectory(fileserveryear);
                    if (!Directory.Exists(fileservermonth))
                        Directory.CreateDirectory(fileservermonth);

                    if (File.Exists(path))
                    {
                        File.Delete(fileservermonth + @"\" + file);
                    }

                    File.Move(path, fileservermonth + @"\" + file);
                }
            }
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (btnStop.Enabled)
                    e.Cancel = true;
                setString.Clear();
                setString.Add("No =" + txtNo.Text);
                setString.Add("From Folder =" + txtFrom.Text);
                setString.Add("Folder Server =" + serverfolder);
                if (!Directory.Exists(Path.GetDirectoryName(settingfile)))
                    Directory.CreateDirectory(Path.GetDirectoryName(settingfile));
                File.WriteAllLines(settingfile, setString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}