using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Push_EN2_Data_LD20
{
    public partial class MainForm : Form
    {
        int c = 0;
        DataItem dataitem = new DataItem();
        List<string> setlist = new List<string>();
        List<DataItem> dataItems = new List<DataItem>();
        string setfile = @"C:\PushDataLD20\Setting.ini";
        string backupfolder = @"C:\PushDataLD20\Backup";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Load setting file
            if (File.Exists(setfile))
            {
                foreach (string line in File.ReadLines(setfile))
                {
                    if (line.Contains("From")) txtDataFolder.Text = line.Split('=')[1];
                    if (line.Contains("To")) txtServerFolder.Text = line.Split('=')[1];
                }
            }
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog of = new FolderBrowserDialog();
            if (of.ShowDialog() == DialogResult.OK)
                txtDataFolder.Text = of.SelectedPath + "\\";
        }

        private void btnBrowserServer_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog()
            {
                Multiselect = false,
                ReadOnlyChecked = true,
                CheckPathExists = false,
                CheckFileExists = false,
                FileName = "Select Server Folder",
            };
            if (of.ShowDialog() == DialogResult.OK)
                txtServerFolder.Text = Path.GetDirectoryName(of.FileName) + "\\";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!bwSendData.IsBusy)
            {
                btnStop.Enabled = true;
                btnStart.Enabled = false;
                pnlSetting.Enabled = false;
                c = (int)numCounter.Value;
                bwSendData.RunWorkerAsync();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (bwSendData.IsBusy)
            {
                btnStop.Enabled = false;
                btnStart.Enabled = true;
                pnlSetting.Enabled = true;
                bwSendData.CancelAsync();
            }
        }

        private void bwSendData_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = c; i >= 0; i--)
            {
                if (bwSendData.CancellationPending)
                {
                    bwSendData.ReportProgress(c);
                    e.Cancel = true;
                    return;
                }
                bwSendData.ReportProgress(i);
                Thread.Sleep(1000);
            }
            bwSendData.ReportProgress(0);
        }

        private void bwSendData_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tsCounter.Text = e.ProgressPercentage + " s";
            tsStatus.Text = "Waiting";
        }

        private void bwSendData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                //When click stop button
                tsStatus.Text = "Stop";
            else if (e.Error != null)
                //When get an error
                tsStatus.Text = e.Error.Message;
            else
            {
                //When complete 1 cycle
                System.Diagnostics.Stopwatch speed = new System.Diagnostics.Stopwatch();
                this.Cursor = Cursors.WaitCursor;
                tsStatus.Text = "Send Data";
                speed.Start();
                //Send data
                SendData();
                speed.Stop();
                this.Cursor = Cursors.Default;
                tsSpeed.Text = ((double)speed.ElapsedMilliseconds / 1000).ToString("0.00") + " ms";
                //Start new cycle
                bwSendData.RunWorkerAsync();
            }
        }

        private void SendData()
        {
            DateTime filedate = new DateTime();
            DataTable dt = new DataTable();
            DirectoryInfo dataFolder = new DirectoryInfo(txtDataFolder.Text);
            FileInfo[] dataFiles = dataFolder.GetFiles("*.csv", SearchOption.AllDirectories);
            foreach (FileInfo file in dataFiles)
            {
                try
                {
                    //Get date of file data
                    filedate = DateTime.Parse(file.Name.Split('_')[2].Remove(11));
                    //Get items list from csv file
                    dataItems = dataitem.GetItemsFromCSV(file.FullName);
                    //Write inspect of all items into csv file
                    dataitem.ItemsExportToCSV(dataItems, txtServerFolder.Text);
                    //Add data log
                    dgvDataLog.Rows.Add(filedate, "OK", "");
                }
                catch (Exception ex)
                {
                    dgvDataLog.Rows.Add(filedate, "Error", ex.Message);
                }
                dgvDataLog.Refresh();
                if (!Directory.Exists(backupfolder))
                    Directory.CreateDirectory(backupfolder);
                File.Move(file.FullName, backupfolder + "\\" + file.Name);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //If running not allow close
            if (btnStop.Enabled)
            {
                e.Cancel = true;
                return;
            }
            //Get URL of data folder and server folder
            setlist.Add("From=" + txtDataFolder.Text + Environment.NewLine);
            setlist.Add("To=" + txtServerFolder.Text + Environment.NewLine);
            //Create a setting file
            if (!Directory.Exists(Path.GetDirectoryName(setfile))) Directory.CreateDirectory(Path.GetDirectoryName(setfile));
            if (File.Exists(setfile)) File.Delete(setfile);
            using (FileStream ws = File.Create(setfile))
            {
                byte[] setbyte = setlist.SelectMany(x => Encoding.UTF8.GetBytes(x)).ToArray();
                foreach (byte b in setbyte)
                    ws.WriteByte(b);
            }
        }
    }
}
