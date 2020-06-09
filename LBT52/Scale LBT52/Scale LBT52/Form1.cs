using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace Scale_LBT52
{
    public partial class Form1 : Form
    {
        DataTable dt;
        SerialPort P = new SerialPort(); // Khai báo 1 Object SerialPort mới.
        string InputData = String.Empty; // Khai báo string buff dùng cho hiển thị dữ liệu sau này.
        delegate void SetTextCallback(string text);
        public Form1()
        {
            InitializeComponent();
            string[] ports = SerialPort.GetPortNames();

            cmbCom.Items.AddRange(ports);
            P.ReadTimeout = 1000;
            P.DataReceived += new SerialDataReceivedEventHandler(DataReceive);
            string[] BaudRate = { "2400" };
            cmbRate.Items.AddRange(BaudRate);
            string[] Databits = { "7" };
            cmbDataBits.Items.AddRange(Databits);
            string[] Parity = { "Even" };
            cmbParity.Items.AddRange(Parity);
            string[] stopbit = { "1" };
            cmbStopBit.Items.AddRange(stopbit);
            dt = new DataTable();
            dt.Columns.Add("no");
            dt.Columns.Add("value");
            dt.Columns.Add("unit");
            dt.Columns.Add("datetime");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //cmbCom.SelectedIndex = 0;
            //cmbRate.SelectedIndex = 3; // 9600
            //cmbDataBits.SelectedIndex = 2; // 8
            //cmbParity.SelectedIndex = 0; // None
            //cmbStopBit.SelectedIndex = 0; // None
            // Hiện thị Status cho Pro tí
            btnDisconnect.Enabled = false;
            status.Text = "Please choose port com to continue!!";

        }


        private void DataReceive(object obj, SerialDataReceivedEventArgs e)
        {
            InputData = P.ReadExisting();
            if (InputData != String.Empty)
            {
                SetText(InputData);
            }
        }
        private void SetText(string text)
        {
            if (this.txtkq.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else this.txtkq.Text += text;
        }


        private void cmbCom_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                P.Close();
            }
            P.PortName = cmbCom.SelectedItem.ToString();
        }

        private void cmbRate_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                P.Close();
            }
            P.BaudRate = Convert.ToInt32(cmbRate.Text);
        }

        private void cmbDataBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                P.Close();
            }
            P.DataBits = Convert.ToInt32(cmbDataBits.Text);
        }

        private void cmbParity_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                P.Close();
            }
            switch (cmbParity.SelectedItem.ToString())
            {
                case "Odd":
                    P.Parity = Parity.Odd;
                    break;
                case "None":
                    P.Parity = Parity.None;
                    break;
                case "Even":
                    P.Parity = Parity.Even;
                    break;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCom.Text == "" && cmbDataBits.Text == "" && cmbParity.Text == "" && cmbRate.Text == "" && cmbStopBit.Text == "")
                {
                    MessageBox.Show("Please connect COM  and setting values default COM", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (cmbCom.Text != "" && cmbDataBits.Text != "" && cmbParity.Text != "" && cmbRate.Text != "" && cmbStopBit.Text != "")
                {
                    P.Open();
                    btnDisconnect.Enabled = true;
                    btnConnect.Enabled = false;
                    status.Text = "Connected to Port: " + cmbCom.SelectedItem.ToString();
                    MessageBox.Show("Connect Successfully","Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupBox1.Enabled = false;
                }
                if (cmbCom.Text == "" && cmbDataBits.Text != "" && cmbParity.Text != "" && cmbRate.Text != "" && cmbStopBit.Text != "")
                {
                    MessageBox.Show("Please connect to PORT COM", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (cmbCom.Text != "" && cmbDataBits.Text == "" || cmbParity.Text == "" || cmbRate.Text == "" || cmbStopBit.Text == "")
                {
                    MessageBox.Show("Please setting values default COM", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Connect", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            P.Close();
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            // Hiện thị Status
            status.Text = "Disconnect";
            groupBox1.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbStopBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                P.Close();
            }
            switch (cmbStopBit.SelectedItem.ToString())
            {
                case "1":
                    P.StopBits = StopBits.One;
                    break;
                case "1.5":
                    P.StopBits = StopBits.OnePointFive;
                    break;
                case "2":
                    P.StopBits = StopBits.Two;
                    break;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {

                SaveFileDialog savef = new SaveFileDialog();
                savef.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 Workbook (*.xls)|*.xls|All file (*.*)|*.*";
                savef.AddExtension = true;
                if (savef.ShowDialog() == DialogResult.OK)
                {
                    ExcelClass excel = new ExcelClass(savef.FileName);
                    excel.CreateWorkBook();
                    excel.AddDatatable(dt);
                    excel.SaveAndExit();
                    MessageBox.Show("Export Successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else return;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }



        private void txtkq_TextChanged(object sender, EventArgs e)
        {
            if (txtkq.Text.Contains("\r\n"))
            {
                string qtys = txtkq.Text;
                string[] arrListStr = qtys.Split(' ');
                int i = dt.Rows.Count;
                DataRow dr = dt.NewRow();

                if (arrListStr[1] == "")
                {
                    arrListStr[1] = "g";
                }
                dr["no"] = i;
                dr["value"] = arrListStr[0].Remove(0, 3);
                dr["unit"] = arrListStr[1];
                dr["datetime"] = DateTime.Now.ToString();
                dt.Rows.Add(dr);
                string firstColumn = i++.ToString();
                string secondColumn = txtkq.Text;
                string[] row = { firstColumn, arrListStr[0].Remove(0, 3), arrListStr[1], DateTime.Now.ToString() };
                dgvData.Rows.Add(row);
                txtkq.Text = null;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvData.Rows.Clear();
            dt.Clear();
            txtkq.Clear();
        }
    }


}
