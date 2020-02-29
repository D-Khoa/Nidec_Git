using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ConvertPremacFile.Model;

namespace ConvertPremacFile
{
    public partial class AddPremac649ToDB : Form
    {
        #region SETTING FILE
        bool isStart = false;
        string settingfile = @"C:\ConvertPremac\setting.ini";
        pre_649 premacfile = new pre_649();
        pts_item premacfile212 = new pts_item();
        pre_232 premacfile232 = new pre_232();

        List<string> settingList { get; set; }
        List<ConvertLogs> dataLogs { get; set; }

        public AddPremac649ToDB()
        {
            InitializeComponent();
            timer1.Enabled = true;
            settingList = new List<string>();
            dataLogs = new List<ConvertLogs>();

        }
        #endregion
        #region FORM LOAD
        private void AddPremac649ToDB_Load(object sender, EventArgs e)
        {

            if (File.Exists(settingfile))
            {
                foreach (string line in File.ReadLines(settingfile))
                {
                    if (line.Contains("Premac649URL"))
                        txtPremac649Path.Text = line.Split('=')[1].Trim();
                    if (line.Contains("Premac212URL"))
                        txtItem212.Text = line.Split('=')[1].Trim();
                    if (line.Contains("Premac232URL"))
                        txtSupplier232.Text = line.Split('=')[1].Trim();
                    if (line.Contains("log"))
                        dataLogs.Add(new ConvertLogs
                        {
                            Log_Time = DateTime.Parse(line.Split('=')[1].Trim()),
                            Log_Message = line.Split('=')[2].Trim()
                        });
                }
            }
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                tsVersion.Text = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4);
            else
                tsVersion.Text = Application.ProductVersion;
            UpdateGrid();
        }
        #endregion
        #region CHOOSE FOLDER
        private void btnBrowser_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openf = new OpenFileDialog();
                openf.Filter = "Text file (*.txt)|*.txt|All file (*.*)|*.*";
                openf.FileName = "CPFXE049.TXT";
                openf.CheckFileExists = false;
                openf.CheckPathExists = false;
                openf.ValidateNames = true;
                if (openf.ShowDialog() == DialogResult.OK)
                {
                    txtPremac649Path.Text = openf.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnBrowseritem_Click(object sender, EventArgs e)
        {

            try
            {
                OpenFileDialog openf = new OpenFileDialog();
                openf.Filter = "Text file (*.txt)|*.txt|All file (*.*)|*.*";
                openf.FileName = "CPBE0012.TXT";
                openf.CheckFileExists = false;
                openf.CheckPathExists = false;
                openf.ValidateNames = true;
                if (openf.ShowDialog() == DialogResult.OK)
                {

                    txtItem212.Text = openf.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openf = new OpenFileDialog();
                openf.Filter = "Text file (*.txt)|*.txt|All file (*.*)|*.*";
                openf.FileName = "CPBE0032.TXT";
                openf.CheckFileExists = false;
                openf.CheckPathExists = false;
                openf.ValidateNames = true;
                if (openf.ShowDialog() == DialogResult.OK)
                {
                    txtSupplier232.Text = openf.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region BUTTON
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (isStart)
            {
                isStart = false;
                btnStart.Text = "Start";
            }
            else
            {
                isStart = true;
                btnStart.Text = "Stop";
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            AddPre649();
            Thread.Sleep(3000);
            AddPre212();
            Thread.Sleep(3000);
            AddPre232();
            Thread.Sleep(3000);
        }
        #endregion
        #region TIMER
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isStart)
            {
                if (DateTime.Now.ToString("HHmmss") == dtpTimeConvert.Value.ToString("HHmmss"))
                {
                    AddPre649();
                    AddPre212();
                    AddPre232();
                }
            }
            tsStatus.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        #endregion
        #region FORM CLOSING
        private void AddPremac649ToDB_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isStart) e.Cancel = true;
            else
            {
                ConvertLogs error = new ConvertLogs();
                settingList.Add("Premac649URL =" + txtPremac649Path.Text);
                settingList.Add("Premac212URL=" + txtItem212.Text);
                settingList.Add("Premac232URL=" + txtSupplier232.Text);
                foreach (DataGridViewRow dr in dgvLogs.Rows)
                {
                    error = dr.DataBoundItem as ConvertLogs;
                    settingList.Add("logs =" + error.Log_Time + " = " + error.Log_Message);
                }
                if (!Directory.Exists(Path.GetDirectoryName(settingfile)))
                    Directory.CreateDirectory(Path.GetDirectoryName(settingfile));
                if (!File.Exists(settingfile))
                {
                    FileStream myfile = File.Create(settingfile);
                    myfile.Close();
                }
                File.WriteAllLines(settingfile, settingList);
            }
        }
        #endregion
        #region SUB PROGRAM ADD PREMAC
        private void AddPre649()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPremac649Path.Text))
                {
                    string[] files = Directory.GetFiles(Path.GetDirectoryName(txtPremac649Path.Text), "*CPFXE049*");
                    foreach (string file in files)
                    {
                        premacfile.GetListPremacItem(file);
                        premacfile.DeleteFromDB();
                        premacfile.WriteToDB(premacfile.listPremacItem);
                        dataLogs.Add(new ConvertLogs
                        {
                            Log_Time = DateTime.Now,
                            Log_Message = "Pre649 Add Completed"
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                dataLogs.Add(new ConvertLogs
                {
                    Log_Time = DateTime.Now,
                    Log_Message = ex.Message
                });
            }
            UpdateGrid();
        }

        private void AddPre212()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtItem212.Text))
                {
                    string[] files = Directory.GetFiles(Path.GetDirectoryName(txtItem212.Text), "*CPBE0012*");
                    foreach (string file in files)
                    {
                        premacfile212.GetListItems(file);
                        premacfile212.DeleteFromDB();
                        premacfile212.WriteToDB(premacfile212.listItems);
                        dataLogs.Add(new ConvertLogs
                        {
                            Log_Time = DateTime.Now,
                            Log_Message = "Pts_item Add Completed"
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                dataLogs.Add(new ConvertLogs
                {
                    Log_Time = DateTime.Now,
                    Log_Message = ex.Message
                });
            }
            UpdateGrid();
        }

        private void AddPre232()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSupplier232.Text))
                {
                    string[] files = Directory.GetFiles(Path.GetDirectoryName(txtSupplier232.Text), "*CPBE0032*");
                    foreach (string file in files)
                    {
                        premacfile232.GetListItems(file);
                        premacfile232.DeleteFromDB();
                        premacfile232.WriteToDB(premacfile232.listSupplier);
                        dataLogs.Add(new ConvertLogs
                        {
                            Log_Time = DateTime.Now,
                            Log_Message = "Pre232 Add Completed"
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                dataLogs.Add(new ConvertLogs
                {
                    Log_Time = DateTime.Now,
                    Log_Message = ex.Message
                });
            }
            UpdateGrid();
        }
        #endregion
        #region UPDATEGRID
        private void UpdateGrid()
        {
            dgvLogs.DataSource = null;
            dgvLogs.DataSource = dataLogs;
            dgvLogs.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvLogs.DataSource = null;
            dataLogs.Clear();
        }
    }
    #endregion
    #region CONVERT LOGS
    class ConvertLogs
    {
        public DateTime Log_Time { get; set; }
        public string Log_Message { get; set; }
    }
    #endregion
}
