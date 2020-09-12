using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LBT_PQM
{
    public partial class FromMain : Form
    {
        #region -- FORM --
        private const string SETTING_FOLDER_PATH = @"C:\LBT_PQM";
        private const string SETTING_FILE_PATH = @"C:\LBT_PQM\Setting.ini";
        public FromMain()
        {
            InitializeComponent();
        }
        private void FromMain_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(SETTING_FILE_PATH))
                {
                    using (var reader = new StreamReader(SETTING_FILE_PATH, Encoding.UTF8))
                    {
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split('=');
                            switch (values[0])
                            {
                                case "Site":
                                    txtSite.Text = values[1];
                                    break;
                                case "Line":
                                    txtLine.Text = values[1];
                                    break;
                                case "Input":
                                    txtInput.Text = values[1];
                                    break;
                                case "Output":
                                    txtOutput.Text = values[1];
                                    break;
                                case "Remark":
                                    txtRemark.Text = values[1];
                                    break;
                                case "Factory":
                                    txtFactory.Text = values[1];
                                    break;
                                case "Process":
                                    txtProcess.Text = values[1];
                                    break;
                            }
                        }
                        reader.Close();
                        reader.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FromMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (bkwAutorun.IsBusy)
                {
                    e.Cancel = true;
                    return;
                }
                if (!Directory.Exists(SETTING_FOLDER_PATH))
                {
                    Directory.CreateDirectory(SETTING_FOLDER_PATH);
                }
                using (var sw = new StreamWriter(SETTING_FILE_PATH, false))
                {
                    sw.WriteLine(string.Format("{0}={1}", "Site", txtSite.Text));
                    sw.WriteLine(string.Format("{0}={1}", "Line", txtLine.Text));
                    sw.WriteLine(string.Format("{0}={1}", "Input", txtInput.Text));
                    sw.WriteLine(string.Format("{0}={1}", "Output", txtOutput.Text));
                    sw.WriteLine(string.Format("{0}={1}", "Remark", txtRemark.Text));
                    sw.WriteLine(string.Format("{0}={1}", "Factory", txtFactory.Text));
                    sw.WriteLine(string.Format("{0}={1}", "Process", txtProcess.Text));
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region -- METHOD --
        private void ConvertProcess()
        {
            var ERROR_FOLER = Path.Combine(txtInput.Text, "Error");
            var BACKUP_FOLER = Path.Combine(txtInput.Text, "Backup");
            var files = Directory.GetFiles(txtInput.Text);
            for (int i = 0; i < files.Length; i++)
            {
                var fileName = Path.GetFileName(files[i]);
                try
                {
                    var listPQM = ConvertCSVToLBTFormat(files[i]);
                    var outPath = Path.Combine(txtOutput.Text, fileName);
                    SavePQMToFile(listPQM, outPath);
                    var backupPath = Path.Combine(BACKUP_FOLER, fileName);
                    if (!Directory.Exists(BACKUP_FOLER))
                    {
                        Directory.CreateDirectory(BACKUP_FOLER);
                    }
                    File.Move(files[i], backupPath);
                    AddNewRow(files[i], "OK", "");
                }
                catch (Exception ex)
                {
                    var errorPath = Path.Combine(ERROR_FOLER, fileName);
                    if (!Directory.Exists(ERROR_FOLER))
                    {
                        Directory.CreateDirectory(ERROR_FOLER);
                    }
                    File.Move(files[i], errorPath);
                    AddNewRow(files[i], "Error", ex.Message);
                }
            }
        }
        private List<PQMFormat> ConvertCSVToLBTFormat(string filePath)
        {
            string lot = string.Empty;
            string model = string.Empty;
            string inspectDate = string.Empty;
            List<string> listColumns = new List<string>();
            List<PQMFormat> listPQM = new List<PQMFormat>();
            Dictionary<string, double> dictSpecMin = new Dictionary<string, double>();
            Dictionary<string, double> dictSpecMax = new Dictionary<string, double>();
            using (var reader = new StreamReader(filePath, Encoding.UTF8))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var columns = line.Split(',');
                    if (!string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line))
                    {
                        if (line.Contains("Date"))
                        {
                            inspectDate = columns[5];
                        }
                        else if (line.Contains("Type"))
                        {
                            model = columns[1];
                            lot = columns[4];
                        }
                        else if (line.Contains("Current"))
                        {
                            var line2 = reader.ReadLine();
                            var columns2 = line2.Split(',');
                            string tempString = "No";
                            for (int i = 0; i < columns2.Length; i++)
                            {
                                if (!string.IsNullOrEmpty(columns[i]) && !string.IsNullOrWhiteSpace(columns[i]))
                                {
                                    tempString = columns[i];
                                }
                                string columnName = string.Format("{0}_{1}", tempString, columns2[i]);
                                columnName = columnName.Trim('_');
                                listColumns.Add(columnName);
                            }
                        }
                        else if (line.Contains("Min"))
                        {
                            for (int i = 0; i < columns.Length; i++)
                            {
                                var key = listColumns[i];
                                if (!dictSpecMin.ContainsKey(key)
                                    && key != "No"
                                    && key != "Total_OK/NG")
                                {
                                    if (double.TryParse(columns[i], out double value))
                                    {
                                        dictSpecMin.Add(key, value);
                                    }
                                    else
                                    {
                                        dictSpecMin.Add(key, 0);
                                    }
                                }
                            }
                        }
                        else if (line.Contains("Max"))
                        {
                            for (int i = 0; i < columns.Length; i++)
                            {
                                var key = listColumns[i];
                                if (!dictSpecMax.ContainsKey(key)
                                    && key != "No"
                                    && key != "Total_OK/NG")
                                {
                                    if (double.TryParse(columns[i], out double value))
                                    {
                                        dictSpecMax.Add(key, value);
                                    }
                                    else
                                    {
                                        dictSpecMax.Add(key, 0);
                                    }
                                }
                            }
                        }
                        else if (!line.Contains("CW") && !line.Contains("No") && !line.Contains("Save"))
                        {
                            for (int i = 0; i < columns.Length; i++)
                            {
                                var judge = "0";
                                if (!double.TryParse(columns[i], out double value))
                                {
                                    value = 0;
                                }
                                var key = listColumns[i];
                                if (dictSpecMax.ContainsKey(key))
                                {
                                    if (value > dictSpecMax[key])
                                    {
                                        judge = "1";
                                    }
                                }
                                if (dictSpecMin.ContainsKey(key))
                                {
                                    if (value < dictSpecMin[key])
                                    {
                                        judge = "1";
                                    }
                                }
                                listPQM.Add(new PQMFormat
                                {
                                    Lot = lot,
                                    Judge = judge,
                                    Model = model,
                                    Inital = "INITAL",
                                    InspectName = key,
                                    Site = txtSite.Text,
                                    Line = txtLine.Text,
                                    InspectValue = value,
                                    Barcode = columns[0],
                                    Remark = txtRemark.Text,
                                    InspectTime = "00:00:00",
                                    InspectDate = inspectDate,
                                    Factory = txtFactory.Text,
                                    Process = txtProcess.Text,
                                });
                            }
                        }
                    }
                }
                reader.Close();
                reader.Dispose();
            }
            return listPQM;
        }
        private void SavePQMToFile(List<PQMFormat> listPQM, string filePath)
        {
            var properties = typeof(PQMFormat).GetProperties();
            var columns = string.Join(",", properties.Select(x => x.Name).ToArray());
            using (var sw = new StreamWriter(filePath, false))
            {
                sw.WriteLine(columns);
                for (int r = 0; r < listPQM.Count; r++)
                {
                    string rowValues = string.Empty;
                    for (int c = 0; c < properties.Length; c++)
                    {
                        if (properties[c].Name != "Max" && properties[c].Name != "Min")
                        {
                            var value = properties[c].GetValue(listPQM[r], null);
                            rowValues += string.Format(",{0}", value.ToString());
                        }
                    }
                    rowValues = rowValues.Trim(',');
                    sw.WriteLine(rowValues);
                }
                sw.Flush();
                sw.Close();
                sw.Dispose();
            }
        }
        #endregion
        #region -- OPTIONS --
        private void btnInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog openInput = new OpenFileDialog
            {
                FileName = "Select input folder",
                CheckFileExists = false,
                CheckPathExists = false
            };
            if (openInput.ShowDialog() == DialogResult.OK)
            {
                txtInput.Text = Path.GetDirectoryName(openInput.FileName);
            }
        }
        private void btnOutput_Click(object sender, EventArgs e)
        {
            OpenFileDialog openOutput = new OpenFileDialog
            {
                FileName = "Select input folder",
                CheckFileExists = false,
                CheckPathExists = false
            };
            if (openOutput.ShowDialog() == DialogResult.OK)
            {
                txtOutput.Text = Path.GetDirectoryName(openOutput.FileName);
            }
        }
        #endregion
        #region -- BACKGROUND WORKER --
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (bkwAutorun.IsBusy)
            {
                bkwAutorun.CancelAsync();
                btnRun.Text = "Run";
                pnlOption.Enabled = true;
            }
            else
            {
                ConvertProcess();
                bkwAutorun.RunWorkerAsync();
                btnRun.Text = "Stop";
                pnlOption.Enabled = false;
            }
        }

        private void bkwAutorun_DoWork(object sender, DoWorkEventArgs e)
        {
            int counter = (int)numTimer.Value * 60;
            for (int i = counter; i >= 0; i--)
            {
                if (bkwAutorun.CancellationPending)
                {
                    bkwAutorun.ReportProgress(counter);
                    e.Cancel = true;
                    return;
                }
                bkwAutorun.ReportProgress(i);
                Thread.Sleep(1000);
            }
            bkwAutorun.ReportProgress(0);
        }

        private void bkwAutorun_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            txtTimer.Text = string.Format("{0} s", e.ProgressPercentage);
        }

        private void bkwAutorun_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Autorun is stopped!");
            }
            else if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                ConvertProcess();
                if (!bkwAutorun.IsBusy)
                {
                    bkwAutorun.RunWorkerAsync();
                }
            }
        }
        #endregion
        #region -- DATAGRIDVIEW --
        private void AddNewRow(string filePath, string status, string log)
        {
            var rIndex = dgvData.Rows.Add();
            dgvData.Rows[rIndex].Cells[0].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dgvData.Rows[rIndex].Cells[1].Value = status;
            dgvData.Rows[rIndex].Cells[2].Value = log;
            dgvData.Rows[rIndex].Cells[3].Value = filePath;
            dgvData.Update();
            dgvData.Refresh();
        }
        #endregion
    }
}
