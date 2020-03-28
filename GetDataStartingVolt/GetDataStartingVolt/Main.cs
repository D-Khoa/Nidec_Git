using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetDataStartingVolt
{
    public partial class Main : Form
    {
        string tempPort = string.Empty;
        string outdatafile = string.Empty;
        string datarecieved = string.Empty;
        string valuerecieved = string.Empty;
        string settingfolder = @"D:\Starting Volt Test\";
        string[] baudrate = { "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200" };
        List<string> settingList = new List<string>();

        public Main()
        {
            InitializeComponent();
            cmbBaudRate.DataSource = baudrate;
            cmbBaudRate.SelectedIndex = 5;
            timerCheckPort.Enabled = true;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(settingfolder))
                {
                    if (File.Exists(settingfolder + "setting.ini"))
                    {
                        foreach (string line in File.ReadLines(settingfolder + "setting.ini"))
                        {
                            if (line.StartsWith("OutFolder=")) txtOutputFolder.Text = line.Split('=')[1];
                            if (line.StartsWith("COM=")) tempPort = line.Split('=')[1];
                            if (line.StartsWith("Baudrate=")) cmbBaudRate.Text = line.Split('=')[1];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region BUTTONS EVENT
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtOutputFolder.Text))
                {
                    MessageBox.Show("Please choose folder for save output file");
                    return;
                }
                if (string.IsNullOrEmpty(cmbPort.Text))
                {
                    MessageBox.Show("No COM Port is selected!");
                    return;
                }
                if (!serPort.IsOpen)
                {
                    serPort.PortName = cmbPort.Text;
                    serPort.BaudRate = int.Parse(cmbBaudRate.Text);
                    serPort.DataReceived += serPort_DataReceived;
                    serPort.Open();
                    btnBrowserOutput.Enabled = false;
                }
                else
                {
                    serPort.DataReceived -= serPort_DataReceived;
                    serPort.Close();
                    btnBrowserOutput.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                serPort.Close();
                btnBrowserOutput.Enabled = true;
            }
        }

        private void btnBrowserOutput_Click(object sender, EventArgs e)
        {
            OpenFileDialog outfd = new OpenFileDialog();
            outfd.FileName = "Select Folder";
            outfd.CheckFileExists = false;
            outfd.CheckPathExists = false;
            if (outfd.ShowDialog() == DialogResult.OK)
            {
                txtOutputFolder.Text = Path.GetDirectoryName(outfd.FileName) + @"\";
            }
        }
        #endregion

        #region SERIAL PORT EVENT
        private void serPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                datarecieved = serPort.ReadLine();
                rtxtData.Invoke(new MethodInvoker(delegate ()
                {
                    rtxtData.AppendText(datarecieved);
                    if (datarecieved.StartsWith("Max"))
                    {
                        valuerecieved = datarecieved;
                        valuerecieved.Replace(" ", "");
                        valuerecieved = valuerecieved.Split('=')[1];
                        valuerecieved = valuerecieved.Remove(valuerecieved.IndexOf('V'));
                        SaveFile(txtBarcode.Text, valuerecieved);
                        rtxtLogs.AppendText(txtBarcode.Text + " - " + valuerecieved + Environment.NewLine);
                        txtBarcode.ResetText();
                        txtBarcode.Focus();
                    }
                }));
                datarecieved = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void serPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            MessageBox.Show(e.ToString());
            serPort.Close();
        }

        private void timerCheckPort_Tick(object sender, EventArgs e)
        {
            if (serPort.IsOpen)
            {
                btnConnect.Text = "Disconnect";
                lbPortStatus.Text = "Connected";
                lbPortStatus.BackColor = Color.Green;
                lbPortStatus.ForeColor = Color.Yellow;
            }
            else
            {
                //cmbPort.DataSource = null;
                cmbPort.DataSource = SerialPort.GetPortNames();
                cmbPort.Text = tempPort;
                btnConnect.Text = "Connect";
                lbPortStatus.Text = "Disconnected";
                lbPortStatus.BackColor = Color.Yellow;
                lbPortStatus.ForeColor = Color.Red;
            }
            tsTime.Text = DateTime.Now.ToString("HH:mm:ss");
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void SaveFile(string barcode, string value)
        {
            outdatafile = txtOutputFolder.Text + DateTime.Today.ToString("yyyyMMdd") + ".csv";
            if (!File.Exists(outdatafile))
            {
                using (StreamWriter sw = File.CreateText(outdatafile))
                {
                    sw.WriteLine(barcode + ";");
                    sw.Close();
                }
            }
            using (StreamWriter sw = File.AppendText(outdatafile))
            {
                sw.WriteLine(barcode + ";" + value);
                sw.Close();
            }
        }
        #endregion

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (serPort.IsOpen)
                {
                    MessageBox.Show("COM Port is openning! Please close it before exit!");
                    e.Cancel = true;
                }
                else
                {
                    if (!Directory.Exists(settingfolder))
                        Directory.CreateDirectory(settingfolder);
                    if (File.Exists(settingfolder + "setting.ini"))
                        File.Delete(settingfolder + "setting.ini");
                    settingList.Add("COM=" + cmbPort.Text);
                    settingList.Add("Baudrate=" + cmbBaudRate.Text);
                    settingList.Add("OutFolder=" + txtOutputFolder.Text);
                    using (StreamWriter sw = new StreamWriter(settingfolder + "setting.ini"))
                    {
                        foreach (string line in settingList)
                        {
                            sw.WriteLine(line);
                        }
                        sw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rtxtData_TextChanged(object sender, EventArgs e)
        {
            rtxtData.SelectionStart = rtxtData.Text.Length;
            rtxtData.ScrollToCaret();
        }

        private void rtxtLogs_TextChanged(object sender, EventArgs e)
        {
            rtxtLogs.SelectionStart = rtxtLogs.Text.Length;
            rtxtLogs.ScrollToCaret();
        }
    }
}
