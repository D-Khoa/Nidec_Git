using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ConvertPremacFile.Model;

namespace ConvertPremacFile
{
    public partial class AddPremac649ToDB : Form
    {
        #region SETTING FILE
        int counter = 0;
        bool isStart = false;
        string settingfile = @"C:\ConvertPremac\setting.ini";
        pre_649_order stockout649 = new pre_649_order();
        pts_item premacfile212 = new pts_item();
        pre_232 premacfile232 = new pre_232();
        pre_649 stockin649 = new pre_649();
        pre_223 struct223 = new pre_223();
        pre_655 issue655 = new pre_655();
        pre_user user = new pre_user();
        List<string> settingList { get; set; }
        List<ConvertLogs> dataLogs { get; set; }

        public AddPremac649ToDB()
        {
            InitializeComponent();
            timer1.Enabled = true;
            rbtnTimeSet.Checked = true;
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
                    if (line.StartsWith("CheckStockIn649="))
                        cbStockIn649.Checked = Boolean.Parse(line.Split('=')[1].Trim());
                    if (line.StartsWith("CheckStockOut649="))
                        cbStockOut649.Checked = Boolean.Parse(line.Split('=')[1].Trim());
                    if (line.StartsWith("CheckItem212="))
                        cbItem212.Checked = Boolean.Parse(line.Split('=')[1].Trim());
                    if (line.StartsWith("CheckSupplier232="))
                        cbSupplier232.Checked = Boolean.Parse(line.Split('=')[1].Trim());
                    if (line.StartsWith("CheckStruct223="))
                        cbStruct223.Checked = Boolean.Parse(line.Split('=')[1].Trim());
                    if (line.StartsWith("CheckIssue655="))
                        cbIssue655.Checked = Boolean.Parse(line.Split('=')[1].Trim());
                    if (line.StartsWith("CheckStockIn6123="))
                        cbStockIn6123.Checked = Boolean.Parse(line.Split('=')[1].Trim());
                    if (line.StartsWith("CheckUser9984="))
                        cbUser.Checked = Boolean.Parse(line.Split('=')[1].Trim());
                    if (line.StartsWith("StockIn649URL"))
                        txtStockIn649.Text = line.Split('=')[1].Trim();
                    if (line.StartsWith("StockOut649URL"))
                        txtStockOut649.Text = line.Split('=')[1].Trim();
                    if (line.StartsWith("Premac212URL"))
                        txtItem212.Text = line.Split('=')[1].Trim();
                    if (line.StartsWith("Premac232URL"))
                        txtSupplier232.Text = line.Split('=')[1].Trim();
                    if (line.StartsWith("Premac223URL"))
                        txtStruct223.Text = line.Split('=')[1].Trim();
                    if (line.StartsWith("Premac655URL"))
                        txtIssue655.Text = line.Split('=')[1].Trim();
                    if (line.StartsWith("StockIn6123URL"))
                        txtStockIn6123.Text = line.Split('=')[1].Trim();
                    if (line.StartsWith("User9984URL"))
                        txtUser.Text = line.Split('=')[1].Trim();
                    if (line.StartsWith("CheckTimeSet"))
                        rbtnTimeSet.Checked = bool.Parse(line.Split('=')[1].Trim());
                    if (line.StartsWith("CheckTimer"))
                        rbtnTimer.Checked = bool.Parse(line.Split('=')[1].Trim());
                    if (line.StartsWith("TimeSet1"))
                        dtpTimeConvert.Value = DateTime.Parse(line.Split('=')[1].Trim());
                    if (line.StartsWith("TimeSet2"))
                        dtpTimeConvert2.Value = DateTime.Parse(line.Split('=')[1].Trim());
                    if (line.StartsWith("Timer"))
                        numTimer.Value = int.Parse(line.Split('=')[1].Trim());
                    if (line.StartsWith("log"))
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

        private void btnBrowserIssue655_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openf = new OpenFileDialog();
                openf.Filter = "Text file (*.txt)|*.txt|All file (*.*)|*.*";
                openf.FileName = "CsvExported.TXT";
                openf.CheckFileExists = false;
                openf.CheckPathExists = false;
                openf.ValidateNames = true;
                if (openf.ShowDialog() == DialogResult.OK)
                {
                    txtIssue655.Text = Path.GetDirectoryName(openf.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBrowserStockIn6123_Click(object sender, EventArgs e)
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
                    txtStockIn6123.Text = Path.GetDirectoryName(openf.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBrowserUser_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openf = new OpenFileDialog();
                openf.Filter = "Text file (*.txt)|*.txt|All file (*.*)|*.*";
                openf.FileName = "CsvExported.TXT";
                openf.CheckFileExists = false;
                openf.CheckPathExists = false;
                openf.ValidateNames = true;
                if (openf.ShowDialog() == DialogResult.OK)
                {
                    txtUser.Text = Path.GetDirectoryName(openf.FileName);
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
                if (rbtnTimer.Checked) counter = (int)numTimer.Value * 60;
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            ImportDB();
        }
        #endregion
        #region TIMER
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isStart)
            {
                if (rbtnTimeSet.Checked)
                {
                    if (DateTime.Now.ToString("HHmmss") == dtpTimeConvert.Value.ToString("HHmmss") || DateTime.Now.ToString("HHmmss") == dtpTimeConvert2.Value.ToString("HHmmss")) ImportDB();
                    tsStatus.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else if (rbtnTimer.Checked)
                {
                    tsStatus.Text = counter.ToString() + " s";
                    counter--;
                    if (counter == 0)
                    {
                        ImportDB();
                        counter = (int)numTimer.Value * 60;
                    }
                }
            }
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
                settingList.Add("CheckIssue655=" + cbIssue655.Checked);
                settingList.Add("CheckStockIn6123=" + cbStockIn6123.Checked);
                settingList.Add("CheckUser9984=" + cbUser.Checked);
                settingList.Add("StockIn649URL =" + txtStockIn649.Text);
                settingList.Add("StockOut649URL =" + txtStockOut649.Text);
                settingList.Add("Premac212URL=" + txtItem212.Text);
                settingList.Add("Premac232URL=" + txtSupplier232.Text);
                settingList.Add("Premac223URL=" + txtStruct223.Text);
                settingList.Add("Premac655URL=" + txtIssue655.Text);
                settingList.Add("StockIn6123URL=" + txtStockIn6123.Text);
                settingList.Add("User9984URL=" + txtUser.Text);
                settingList.Add("CheckTimeSet=" + rbtnTimeSet.Checked);
                settingList.Add("CheckTimer=" + rbtnTimer.Checked);
                settingList.Add("TimeSet1=" + dtpTimeConvert.Value.ToString("HH:mm:ss"));
                settingList.Add("TimeSet2=" + dtpTimeConvert2.Value.ToString("HH:mm:ss"));
                settingList.Add("Timer=" + numTimer.Value.ToString());
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
                    var files = new DirectoryInfo(txtStockIn649.Text).GetFiles("*CPFXE049*")
                                                                     .OrderBy(x => x.LastWriteTime).ToList();
                    string historypath = txtStockIn649.Text + @"\HISTORY";
                    if (!Directory.Exists(historypath)) Directory.CreateDirectory(historypath);
                    foreach (var file in files)
                    {
                        try
                        {
                            stockin649.GetListPremacItem(file.FullName);
                        }
                        catch
                        {
                            continue;
                        }
                        stockin649.DeleteFromDB();
                        stockin649.WriteToDB(stockin649.listPremacItem);
                        File.Move(file.FullName, historypath + "\\" + Path.GetFileName(file.FullName));
                        dataLogs.Add(new ConvertLogs
                        {
                            Log_Time = DateTime.Now,
                            Log_Message = "Add stock-in file: " + file.FullName + " completed"
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
                    var files = new DirectoryInfo(txtStockOut649.Text).GetFiles("*CPFXE049*")
                                                                      .OrderBy(x => x.LastWriteTime).ToList();
                    string historypath = txtStockOut649.Text + @"\HISTORY";
                    if (!Directory.Exists(historypath)) Directory.CreateDirectory(historypath);
                    foreach (var file in files)
                    {
                        stockout649.GetListPremacItem(file.FullName);
                        stockout649.DeleteFromDB();
                        stockout649.WriteToDB(stockout649.listOrderItem);
                        File.Move(file.FullName, historypath + "\\" + Path.GetFileName(file.FullName));
                        dataLogs.Add(new ConvertLogs
                        {
                            Log_Time = DateTime.Now,
                            Log_Message = "Add stock-out file: " + file.FullName + " completed"
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
                    var files = new DirectoryInfo(txtItem212.Text).GetFiles("*CPBE0012*")
                                                                  .OrderBy(x => x.LastWriteTime).ToList();
                    string historypath = txtItem212.Text + @"\HISTORY";
                    if (!Directory.Exists(historypath)) Directory.CreateDirectory(historypath);
                    foreach (var file in files)
                    {
                        premacfile212.GetListItems(file.FullName);
                        premacfile212.DeleteFromDB();
                        premacfile212.WriteToDB(premacfile212.listItems);
                        File.Move(file.FullName, historypath + "\\" + Path.GetFileName(file.FullName));
                        dataLogs.Add(new ConvertLogs
                        {
                            Log_Time = DateTime.Now,
                            Log_Message = "Add item file: " + file.FullName + " completed"
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
                    var files = new DirectoryInfo(txtSupplier232.Text).GetFiles("*CPBE0032*")
                                                                      .OrderBy(x => x.LastWriteTime).ToList();
                    string historypath = txtSupplier232.Text + @"\HISTORY";
                    if (!Directory.Exists(historypath)) Directory.CreateDirectory(historypath);
                    foreach (var file in files)
                    {
                        premacfile232.GetListItems(file.FullName);
                        premacfile232.DeleteFromDB();
                        premacfile232.WriteToDB(premacfile232.listSupplier);
                        File.Move(file.FullName, historypath + "\\" + Path.GetFileName(file.FullName));
                        dataLogs.Add(new ConvertLogs
                        {
                            Log_Time = DateTime.Now,
                            Log_Message = "Add supplier file: " + file.FullName + " completed"
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
                    var files = new DirectoryInfo(txtStruct223.Text).GetFiles("*CPBE0023*")
                                                                    .OrderBy(x => x.LastWriteTime).ToList();
                    string historypath = txtStruct223.Text + @"\HISTORY";
                    if (!Directory.Exists(historypath)) Directory.CreateDirectory(historypath);
                    foreach (var file in files)
                    {
                        struct223.GetListItems(file.FullName);
                        struct223.DeleteFromDB();
                        struct223.WriteToDB(struct223.listStructItem);
                        File.Move(file.FullName, historypath + "\\" + Path.GetFileName(file.FullName));
                        dataLogs.Add(new ConvertLogs
                        {
                            Log_Time = DateTime.Now,
                            Log_Message = "Add product struct file: " + file.FullName + " completed"
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

        private void AddPre655()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtIssue655.Text))
                {
                    var files = new DirectoryInfo(txtIssue655.Text).GetFiles("*CsvExported*")
                                                                   .OrderBy(x => x.LastWriteTime).ToList();
                    string historypath = txtIssue655.Text + @"\HISTORY";
                    if (!Directory.Exists(historypath)) Directory.CreateDirectory(historypath);
                    foreach (var file in files)
                    {
                        issue655.GetListPremacItem(file.FullName);
                        issue655.DeleteFromDB();
                        issue655.WriteToDB(issue655.list655);
                        File.Move(file.FullName, historypath + "\\" + Path.GetFileName(file.FullName));
                        dataLogs.Add(new ConvertLogs
                        {
                            Log_Time = DateTime.Now,
                            Log_Message = "Add issue query file: " + file.FullName + " completed"
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

        private void AddStockIn6123()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtStockIn6123.Text))
                {
                    var files = new DirectoryInfo(txtStockIn6123.Text).GetFiles("*CPFE0123*")
                                                                      .OrderBy(x => x.LastWriteTime).ToList();
                    string historypath = txtStockIn6123.Text + @"\HISTORY";
                    if (!Directory.Exists(historypath)) Directory.CreateDirectory(historypath);
                    foreach (var file in files)
                    {
                        stockin649.GetListItem6123(file.FullName);
                        stockin649.WriteToDB(stockin649.listPremacItem);
                        File.Move(file.FullName, historypath + "\\" + Path.GetFileName(file.FullName));
                        dataLogs.Add(new ConvertLogs
                        {
                            Log_Time = DateTime.Now,
                            Log_Message = "Add stock-in file: " + file.FullName + " completed"
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

        private void AddUser9984()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtUser.Text))
                {
                    var files = new DirectoryInfo(txtUser.Text).GetFiles("*CsvExported*")
                                                                    .OrderBy(x => x.LastWriteTime).ToList();
                    string historypath = txtUser.Text + @"\HISTORY";
                    if (!Directory.Exists(historypath)) Directory.CreateDirectory(historypath);
                    foreach (var file in files)
                    {
                        user.GetListItems(file.FullName);
                        user.DeleteFromDB();
                        user.WriteToDB(user.listUser);
                        File.Move(file.FullName, historypath + "\\" + Path.GetFileName(file.FullName));
                        dataLogs.Add(new ConvertLogs
                        {
                            Log_Time = DateTime.Now,
                            Log_Message = "Add user file: " + file.FullName + " completed"
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

        private void ImportDB()
        {
            System.Diagnostics.Stopwatch stopWtch = new System.Diagnostics.Stopwatch();
            Cursor = Cursors.WaitCursor;
            stopWtch.Start();
            if (cbStockIn649.Checked)
            {
                AddStockIn649();
            }
            if (cbStockIn6123.Checked)
            {
                Thread.Sleep(3000);
                AddStockIn6123();
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
            if (cbIssue655.Checked)
            {
                Thread.Sleep(3000);
                AddPre655();
            }
            if (cbUser.Checked)
            {
                Thread.Sleep(3000);
                AddUser9984();
            }
            stopWtch.Stop();
            tsExecuteTime.Text = stopWtch.Elapsed.ToString("s\\.ff") + " s";
            Cursor = Cursors.Default;
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
        #endregion
    }
    #region CONVERT LOGS
    class ConvertLogs
    {
        public DateTime Log_Time { get; set; }
        public string Log_Message { get; set; }
    }
    #endregion
}
