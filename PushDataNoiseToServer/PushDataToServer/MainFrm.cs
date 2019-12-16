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
        //   string[] filePathto;
        //  string[] filePathtemp;
        string fromfolder;// tofolder;//,tempfolder;
        string settingfile, Model, No;
        string modelfile;
        string path;
        int c;

        public MainFrm()
        {
            InitializeComponent();
            setString = new List<string>();
            settingfile = @"C:\PushData\ini.txt";
            //  settingfile = @"C:\PushData\ini.txt";

        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            if (File.Exists(settingfile))
            {
                setString = File.ReadLines(settingfile).ToList();
            }
            txtModel.Text = setString[0].Trim().Split('=')[1];
            txtFrom.Text = setString[2].Trim().Split('=')[1];
            txtNo.Text = setString[1].Trim().Split('=')[1];
            Model = txtModel.Text;
            No = txtNo.Text;

            //   txtTo.Text = setString[1].Remove(0, 12);
            //   txtTemp.Text = setString[2].Remove(0, 14);
            fromfolder = txtFrom.Text;
            //    tofolder = txtTo.Text;
            //   tempfolder = txtTemp.Text;
        }

        //private void btnBTemp_Click(object sender, EventArgs e)
        //{
        //    txtTemp.Text = ChooseFolder();
        //}

        private void btnPush_Click(object sender, EventArgs e)
        {
            try
            {
                if (!backgroundWorker1.IsBusy)
                {
                    btnPush.Enabled = false;
                    btnStop.Enabled = true;
                    txtFrom.ReadOnly = true;
                    //  txtTo.ReadOnly = true;
                    //          txtTemp.ReadOnly = true;
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
            //  txtTo.ReadOnly = false;
            //  txtTemp.ReadOnly = false;
            backgroundWorker1.CancelAsync();
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (btnStop.Enabled)
                    e.Cancel = true;
                setString.Clear();
                setString.Add("Model =" + txtModel.Text);
                setString.Add("No =" + txtNo.Text);
                setString.Add("From Folder =" + txtFrom.Text);
                setString.Add("Folder Server =" + modelfile);
                //   setString.Add("To Folder = " + tofolder);
                // setString.Add("Temp Folder = " + tempfolder);
                if (!Directory.Exists(Path.GetDirectoryName(settingfile)))
                    Directory.CreateDirectory(Path.GetDirectoryName(settingfile));
                File.WriteAllLines(settingfile, setString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            c = (int)numTimer.Value;
            for (int i = c; i >= 0; i--)
            {
                Thread.Sleep(1000);
                backgroundWorker1.ReportProgress(i);
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    backgroundWorker1.ReportProgress(c);
                    return;
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tsTimer.Text = e.ProgressPercentage.ToString() + " S";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Stop transfer!!!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (e.Error != null)
            {
                MessageBox.Show(e.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    EditAndSendFile();
                    backgroundWorker1.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnBrowserFrom_Click(object sender, EventArgs e)
        {
            txtFrom.Text = ChooseFolder();
        }

        //private void btnBrowserto_Click(object sender, EventArgs e)
        //{
        //    txtTo.Text = ChooseFolder();
        //}
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
        private void EditAndSendFile()
        {
            filePath = Directory.GetFiles(fromfolder, "*.csv");
            //filePathto = Directory.GetFiles(tofolder, "*.csv");
            //filePathtemp = Directory.GetFiles(tempfolder, "*.csv");

            if (filePath != null)
            {
                modelfile = @"\\192.168.145.7\nstvnoise$\NSTV\" + txtModel.Text;
                string No = modelfile + @"\" + txtNo.Text;
                string datetimenow = DateTime.Now.ToString("yyyyMMdd");
                string fileserveryear = No + @"\" + DateTime.Now.ToString("yyyy");
                string fileservermonth = fileserveryear + @"\" + DateTime.Now.ToString("MM");
                string fileserverday = fileservermonth + @"\" + datetimenow;
                if (!Directory.Exists(modelfile))
                    Directory.CreateDirectory(Model);
                if (!Directory.Exists(No))
                    Directory.CreateDirectory(No);
                if (!Directory.Exists(fileserveryear))
                    Directory.CreateDirectory(fileserveryear);
                if (!Directory.Exists(fileservermonth))
                    Directory.CreateDirectory(fileservermonth);
                if (!Directory.Exists(fileserverday))
                    Directory.CreateDirectory(fileserverday);

                foreach (string file in filePath)
                {
                    path = Path.GetFileName(file);
                    //string dataText = File.ReadAllText(file);
                    // dataText = dataText.Replace("", Environment.NewLine);
                    // File.WriteAllText(tofolder + "\\" + path, dataText);
                    // if (!string.IsNullOrEmpty(txtTemp.Text))
                    //   File.Copy(file, tofolder + "\\" + path);
                    // File.Move(file, tofolder + "\\" + path);
                    if (File.Exists(file))
                    {
                        File.Delete(fileserverday + @"\" + path);
                    }

                    File.Move(file, fileserverday + @"\" + path);
                }
            }
        }
    }

}