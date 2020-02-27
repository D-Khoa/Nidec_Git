using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ConvertPremacFile.Model;

namespace ConvertPremacFile
{
    public partial class AddPremac649ToDB : Form
    {
        bool isStart = false;
        string settingfile = @"C:\ConvertPremac\setting.ini";
        pre_649 premacfile = new pre_649();
        List<string> settingList { get; set; }
        List<ConvertLogs> dataLogs { get; set; }

        public AddPremac649ToDB()
        {
            InitializeComponent();
            timer1.Enabled = true;
            settingList = new List<string>();
            dataLogs = new List<ConvertLogs>();
        }

        private void AddPremac649ToDB_Load(object sender, EventArgs e)
        {
            if (File.Exists(settingfile))
            {
                foreach (string line in File.ReadLines(settingfile))
                {
                    if (line.Contains("premac649URL"))
                        txtPremac649Path.Text = line.Split('=')[1].Trim();
                    if (line.Contains("log"))
                        dataLogs.Add(new ConvertLogs
                        {
                            Log_Time = DateTime.Parse(line.Split('=')[1].Trim()),
                            Log_Message = line.Split('=')[2].Trim()
                        });
                }
            }
            UpdateGrid();
        }

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
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isStart)
            {
                if (DateTime.Now.ToString("HHmmss") == dtpTimeConvert.Value.ToString("HHmmss")) AddPre649();
            }
            tsStatus.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void AddPremac649ToDB_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isStart) e.Cancel = true;
            else
            {
                ConvertLogs error = new ConvertLogs();
                settingList.Add("premac649URL =" + txtPremac649Path.Text);
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

        private void AddPre649()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPremac649Path.Text))
                {
                    premacfile.GetListPremacItem(txtPremac649Path.Text);
                    premacfile.DeleteFromDB();
                    premacfile.WriteToDB(premacfile.listPremacItem);
                    dataLogs.Add(new ConvertLogs
                    {
                        Log_Time = DateTime.Now,
                        Log_Message = "Completed"
                    });
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

        private void UpdateGrid()
        {
            dgvLogs.DataSource = null;
            dgvLogs.DataSource = dataLogs;
            dgvLogs.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
    class ConvertLogs
    {
        public DateTime Log_Time { get; set; }
        public string Log_Message { get; set; }
    }

}
