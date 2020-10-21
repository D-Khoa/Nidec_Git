using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;
using Spire.Barcode;

namespace PrintCode2D
{
    public partial class PrintCode2D : Form
    {
        int seri = 0;
        private const string SETTING_FOLDER_PATH = @"C:\PrintCode2DSetting";
        private const string SETTING_FILE_PATH = @"C:\PrintCode2DSetting\Setting.ini";
        public PrintCode2D()
        {
            InitializeComponent();


        }
        #region FORM LOAD
        private void Form1_Load(object sender, EventArgs e)
        {
            txtCustomerCode.Enabled = false;
            groupBoxCode.Enabled = false;
            txtResult.Enabled = false;
            dtpyear.Value = DateTime.Now;
            dtpMonth.Value = DateTime.Now;
            dtpyear.Value = DateTime.Now;
            string datetime = DateTime.Now.ToString("dd");
            string folder = @"C:\PrintCode2DImage";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
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
                                case "SerialNumber":
                                    txtSerinumber.Text = values[1];
                                    break;
                                case "Label Sample":
                                    txtResult.Text = values[1];
                                    break;
                                case "DateTime":
                                    datetime = values[1];
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
        private void PrintCode2D_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            try
            {

                if (!Directory.Exists(SETTING_FOLDER_PATH))
                {
                    Directory.CreateDirectory(SETTING_FOLDER_PATH);
                }
                using (var sw = new StreamWriter(SETTING_FILE_PATH, false))
                {
                    sw.WriteLine(string.Format("{0}={1}", "SerialNumber", txtSerinumber.Text));
                    sw.WriteLine(string.Format("{0}={1}", "Label Sample", txtResult.Text));
                    sw.WriteLine(string.Format("{0}={1}", "DateTime", textBox1.Text));
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
        #region BUTTON PRINT
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.DefaultPageSettings.PaperSize = new PaperSize("Label barcode", 17, 4);
            string cus = txtCustomerCode.Text;
            string year = dtpyear.Value.ToString("yyyy");
            year = year.Substring(year.Length - 1, 1);
            string month = dtpMonth.Value.ToString("MM");
            if (month == "01")
                month = "1";
            if (month == "02")
                month = "2";
            if (month == "03")
                month = "3";
            if (month == "04")
                month = "4";
            if (month == "05")
                month = "5";
            if (month == "06")
                month = "6";
            if (month == "07")
                month = "7";
            if (month == "08")
                month = "8";
            if (month == "09")
                month = "9";
            if (month == "10")
                month = "A";
            if (month == "11")
                month = "B";
            if (month == "12")
                month = "C";
            string date = dtpDate.Value.ToString("dd");
            //   string directory = @"C:\PrintCode2DImage\";
            if (!int.TryParse(txtSerinumber.Text, out seri))
            {
                seri = 1;
            }
            #region PRINT AUTO
            //CHECK PRINT AUTO
            if (ckAuto.Checked == true && btnEditCode.Text == "Edit Code")
            {
                int endSeri = seri + 51;// +30
                while (seri < endSeri)
                {
                    string code = string.Format("{0}{1}{2}{3}{4}", cus, year, month, date, seri.ToString("00000"));
                    GeneralBarcode(code);
                    seri++;
                }
                printDoc.PrintPage += PrintDoc_PrintPage;
                printDoc.Print();
                //if (!cbPrintDocument.Checked)
                //{
                //    string[] files = Directory.GetFiles(directory, "*.bmp", SearchOption.AllDirectories);
                //    for (int i = 0; i < files.Length; i++)
                //    {
                //        txtSerinumber.Text = string.Format("{0:00000}", seri);
                //        string fname = Path.GetFileNameWithoutExtension(files[i]);
                //        string datecdFile = files[i];
                //        printDoc.PrintPage += PrintDoc_PrintPage;
                //        printDoc.Print();
                //        TfPrint.openPrinter();
                //        TfPrint.printBitmap(datecdFile, fname);
                //        TfPrint.closePrinter();
                //        File.Delete(files[i]);
                //        txtResult.Text = fname;
                //    }
                //}
                //else
                //{

                // }
            }
            #endregion
            #region PRINT NORMAL
            // PRINT NORMAL
            if (ckAuto.Checked == false && btnEditCode.Text == "Edit Code")
            {
                if (txtSerinumber.Text == "")
                {
                    MessageBox.Show("Please input serial number", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string code = string.Format("{0}{1}{2}{3}{4}", cus, year, month, date, seri.ToString("00000"));
                    GeneralBarcode(code);
                    //if (!cbPrintDocument.Checked)
                    //{
                    //    string[] files = Directory.GetFiles(directory, "*.bmp", SearchOption.AllDirectories);
                    //    for (int i = 0; i < files.Length; i++)
                    //    {
                    //        txtSerinumber.Text = string.Format("{0:00000}", seri);
                    //        string fname = Path.GetFileNameWithoutExtension(files[i]);
                    //        string datecdFile = files[i];
                    //        TfPrint.openPrinter();
                    //        TfPrint.printBitmap(datecdFile, fname);
                    //        TfPrint.closePrinter();
                    //        File.Delete(files[i]);
                    //        txtResult.Text = fname;
                    //    }
                    //}
                    //else
                    // {
                    printDoc.PrintPage += PrintDoc_PrintPage;
                    printDoc.Print();
                    // }
                }
            }
            #endregion
            if (btnEditCode.Text == "Apply")
            {
                MessageBox.Show("Please apply button");
            }
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            string directory = @"C:\PrintCode2DImage\";
            string[] files = Directory.GetFiles(directory, "*.bmp", SearchOption.AllDirectories);

            Font barFont = new Font("Arial", 3, FontStyle.Bold);
            if (files.Length > 0)
            {
                string fname = Path.GetFileNameWithoutExtension(files[0]);
                Bitmap bmp = new Bitmap(files[0]);
                Bitmap newimage = ResizeBitmap(bmp, 27, 27);
                //  e.Graphics.DrawImage(bmp, new PointF(78, 48));//78,48
                e.Graphics.DrawImage(newimage, 78, 47, newimage.Width, newimage.Height);
                e.Graphics.DrawString("SN:", barFont, Brushes.Black, new PointF(106, 59));//97,53
                e.Graphics.DrawString(fname, barFont, Brushes.Black, new PointF(106, 65));//97,60
                bmp.Dispose();
                File.Delete(files[0]);
                e.HasMorePages = true;
                txtResult.Text = fname;
                txtSerinumber.Text = fname.Substring(fname.Length - 5) + 1;
            }
            else
            {
                e.HasMorePages = false;
            }

        }
        #endregion
        public Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bmp, 0, 0, width, height);
            }

            return result;
        }
        #region BUTTON EDIT CODE
        private void btnEditCode_Click(object sender, EventArgs e)
        {
            if (btnEditCode.Text == "Edit Code")
            {
                groupBoxCode.Enabled = true;
                btnEditCode.Text = "Apply";
            }

            else
            {
                if (txtSerinumber.TextLength < 5)
                    MessageBox.Show("Please input format serial number : 00000", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (txtSerinumber.TextLength == 5)
                {
                    groupBoxCode.Enabled = false;
                    btnEditCode.Text = "Edit Code";
                }
            }
        }
        #endregion
        #region BUTTON EXIT
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region BUTTON RESET
        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to reset serial number???", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                txtSerinumber.Text = "00001";
                string cus = txtCustomerCode.Text;
                string year = dtpyear.Value.ToString("yyyy");
                year = year.Substring(year.Length - 1, 1);
                string month = dtpMonth.Value.ToString("MM");
                if (month == "01")
                    month = "1";
                if (month == "02")
                    month = "2";
                if (month == "03")
                    month = "3";
                if (month == "04")
                    month = "4";
                if (month == "05")
                    month = "5";
                if (month == "06")
                    month = "6";
                if (month == "07")
                    month = "7";
                if (month == "08")
                    month = "8";
                if (month == "09")
                    month = "9";
                if (month == "10")
                    month = "A";
                if (month == "11")
                    month = "B";
                if (month == "12")
                    month = "C";
                string date = dtpDate.Value.ToString("dd");
                string seri = txtSerinumber.Text;
                GeneralBarcode(cus + year + month + date + seri);
                txtResult.Text = cus + year + month + date + seri;
            }
        }
        #endregion
        #region SUB EVENT
        #region  GENERAL BARCODE
        private void GeneralBarcode(string code)
        {
            DataMatrix.net.DmtxImageEncoder encoder = new DataMatrix.net.DmtxImageEncoder();
            Bitmap bmp = encoder.EncodeImage(code);
            pictureBox1.Image = bmp;
            bmp.Save(string.Format(@"C:\PrintCode2DImage\{0}.bmp", code), System.Drawing.Imaging.ImageFormat.Bmp);
        }
        #endregion
        #region SERI NUMBER
        private void txtSerinumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        #endregion

        #endregion



    }
}
