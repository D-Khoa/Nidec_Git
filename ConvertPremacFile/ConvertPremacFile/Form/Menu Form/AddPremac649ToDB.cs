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
        pre_649_order stockout649 = new pre_649_order();
        pts_item premacfile212 = new pts_item();
        pre_232 premacfile232 = new pre_232();
        pre_649 stockin649 = new pre_649();
        pre_223 struct223 = new pre_223();

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
                    if (line.Contains("CheckStockIn649="))
                        cbStockIn649.Checked = Boolean.Parse(line.Split('=')[1].Trim());
                    if (line.Contains("CheckStockOut649="))
                        cbStockOut649.Checked = Boolean.Parse(line.Split('=')[1].Trim());
                    if (line.Contains("CheckItem212="))
                        cbItem212.Checked = Boolean.Parse(line.Split('=')[1].Trim());
                    if (line.Contains("CheckSupplier232="))
                        cbSupplier232.Checked = Boolean.Parse(line.Split('=')[1].Trim());
                    if (line.Contains("CheckStruct223="))
                        cbStruct223.Checked = Boolean.Parse(line.Split('=')[1].Trim());
                    if (line.Contains("StockIn649URL"))
                        txtStockIn649.Text = line.Split('=')[1].Trim();
                    if (line.Contains("StockOut649URL"))
                        txtStockOut649.Text = line.Split('=')[1].Trim();
                    if (line.Contains("Premac212URL"))
                        txtItem212.Text = line.Split('=')[1].Trim();
                    if (line.Contains("Premac232URL"))
                        txtSupplier232.Text = line.Split('=')[1].Trim();
                    if (line.Contains("Premac223URL"))
                        txtStruct223.Text = line.Split('=')[1].Trim();
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
                    txtStockIn649.Text = Path.GetDirectoryName(openf.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBrowserStockOut649_Click(object sender, EventArgs e)
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
                    txtStockOut649.Text = Path.GetDirectoryName(openf.FileName);
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
                    txtItem212.Text = Path.GetDirectoryName(openf.FileName);
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
                    txtSupplier232.Text = Path.GetDirectoryName(openf.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBrowserStruct223_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openf = new OpenFileDialog();
                openf.Filter = "Text file (*.txt)|*.txt|All file (*.*)|*.*";
                openf.FileName = "CPBE0023.TXT";
                openf.CheckFileExists = false;
                openf.CheckPathExists = false;
                openf.ValidateNames = true;
                if (openf.ShowDialog() == DialogResult.OK)
                {
                    txtStruct223.Text = Path.GetDirectoryName(openf.FileName);
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
            if (cbStockIn649.Checked)
            {
                AddStockIn649();
            }
            if (cbStockOut649.Checked)
            {
                Thread.Sleep(3000);
                AddStockOut649();
            }
            if (cbItem212.Checked)
            {
                Thread.Sleep(3000);
                AddPre212();
            }
            if (cbSupplier232.Checked)
            {
                Thread.Sleep(3000);
                AddPre232();
            }
            if (cbStruct223.Checked)
            {
                Thread.Sleep(3000);
                AddPre223();
            }
        }
        #endregion
        #region TIMER
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isStart)
            {
                if (DateTime.Now.ToString("HHmmss") == dtpTimeConvert.Value.ToString("HHmmss"))
                {
                    if (cbStockIn649.Checked)
                    {
                        AddStockIn649();
                    }
                    if (cbStockOut649.Checked)
                    {
                        Thread.Sleep(3000);
                        AddStockOut649();
                    }
                    if (cbItem212.Checked)
                    {
                        Thread.Sleep(3000);
                        AddPre212();
                    }
                    if (cbSupplier232.Checked)
                    {
                        Thread.Sleep(3000);
                        AddPre232();
                    }
                    if (cbStruct223.Checked)
                    {
                        Thread.Sleep(3000);
                        AddPre223();
                    }
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
                settingList.Add("CheckStockIn649=" + cbStockIn649.Checked);
                settingList.Add("CheckStockOut649=" + cbStockOut649.Checked);
                settingList.Add("CheckItem212=" + cbItem212.Checked);
                settingList.Add("CheckSupplier232=" + cbSupplier232.Checked);
                settingList.Add("CheckStruct223=" + cbStruct223.Checked);
                settingList.Add("StockIn649URL =" + txtStockIn649.Text);
                settingList.Add("StockOut649URL =" + txtStockOut649.Text);
                settingList.Add("Premac212URL=" + txtItem212.Text);
                settingList.Add("Premac232URL=" + txtSupplier232.Text);
                settingList.Add("Premac223URL=" + txtStruct223.Text);
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
        private void AddStockIn649()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtStockIn649.Text))
                {
                    string[] files = Directory.GetFiles(txtStockIn649.Text, "*CPFXE049*");
                    foreach (string file in files)
                    {
                        stockin649.GetListPremacItem(file);
                        stockin649.DeleteFromDB();
                        stockin649.WriteToDB(stockin649.listPremacItem);
                        dataLogs.Add(new ConvertLogs
                        {
                            Log_Time = DateTime.Now,
                            Log_Message = "Add stock-in file: " + file + " completed"
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

        private void AddStockOut649()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtStockOut649.Text))
                {
                    string[] files = Directory.GetFiles(txtStockOut649.Text, "*CPFXE049*");
                    foreach (string file in files)
                    {
                        stockout649.GetListPremacItem(file);
                        stockout649.DeleteFromDB();
                        stockout649.WriteToDB(stockout649.listOrderItem);
                        dataLogs.Add(new ConvertLogs
                        {
                            Log_Time = DateTime.Now,
                            Log_Message = "Add stock-out file: " + file + " completed"
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
                    string[] files = Directory.GetFiles(txtItem212.Text, "*CPBE0012*");
                    foreach (string file in files)
                    {
                        premacfile212.GetListItems(file);
                        premacfile212.DeleteFromDB();
                        premacfile212.WriteToDB(premacfile212.listItems);
                        dataLogs.Add(new ConvertLogs
                        {
                            Log_Time = DateTime.Now,
                            Log_Message = "Add item file: " + file + " completed"
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
                    string[] files = Directory.GetFiles(txtSupplier232.Text, "*CPBE0032*");
                    foreach (string file in files)
                    {
                        premacfile232.GetListItems(file);
                        premacfile232.DeleteFromDB();
                        premacfile232.WriteToDB(premacfile232.listSupplier);
                        dataLogs.Add(new ConvertLogs
                        {
                            Log_Time = DateTime.Now,
                            Log_Message = "Add supplier file: " + file + " completed"
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

        private void AddPre223()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSupplier232.Text))
                {
                    string[] files = Directory.GetFiles(txtStruct223.Text, "*CPBE0023*");
                    foreach (string file in files)
                    {
                        struct223.GetListItems(file);
                        struct223.DeleteFromDB();
                        struct223.WriteToDB(struct223.listStructItem);
                        dataLogs.Add(new ConvertLogs
                        {
                            Log_Time = DateTime.Now,
                            Log_Message = "Add product struct file: " + file + " completed"
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
            dgvLogs.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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
