using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            string folder = @"C:\PrintCode2DImage";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }
        #endregion
        #region BUTTON PRINT
        private void btnPrint_Click(object sender, EventArgs e)
        {
            #region PRINT AUTO
            //CHECK PRINT AUTO
            if (ckAuto.Checked == true && btnEditCode.Text == "Edit Code")
            {
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
                if (seri == "")
                {
                    seri = "00001";
                    GeneralBarcode(cus + year + month + date + seri);
                    string directory = @"C:\PrintCode2DImage\";
                    string[] files = System.IO.Directory.GetFiles(directory, "*", System.IO.SearchOption.AllDirectories);
                    for (int i = 0; i < files.Length; i++)
                    {

                        string fname = System.IO.Path.GetFileName(files[i]);
                        if (VBStrings.Right(fname.ToLower(), 4) == ".bmp")
                        {
                            string datecdFile = files[i];
                            TfPrint.openPrinter();
                            TfPrint.printBitmap(datecdFile, cus + year + month + date + seri);
                            TfPrint.closePrinter();
                            System.IO.File.Delete(files[i]);
                            txtResult.Text = cus + year + month + date + seri;
                            txtSerinumber.Text = seri;
                        }

                    }
                }
                else
                {
                    int seris = int.Parse(seri.Substring(seri.Length - 5, 5));
                    seris = seris + 1;
                    textBox1.Text = seris.ToString("00000");
                    string ser = textBox1.Text;
                    GeneralBarcode(cus + year + month + date + ser);
                    string directory = @"C:\PrintCode2DImage\";
                    string[] files = System.IO.Directory.GetFiles(directory, "*", System.IO.SearchOption.AllDirectories);
                    for (int i = 0; i < files.Length; i++)
                    {

                        string fname = System.IO.Path.GetFileName(files[i]);
                        if (VBStrings.Right(fname.ToLower(), 4) == ".bmp")
                        {
                            string datecdFile = files[i];
                            TfPrint.openPrinter();
                            TfPrint.printBitmap(datecdFile, cus + year + month + date + ser);
                            TfPrint.closePrinter();
                            System.IO.File.Delete(files[i]);
                            txtResult.Text = cus + year + month + date + ser;
                            txtSerinumber.Text = ser;
                        }

                    }
                }
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
                    string directory = @"C:\PrintCode2DImage\";
                    string[] files = System.IO.Directory.GetFiles(directory, "*", System.IO.SearchOption.AllDirectories);
                    for (int i = 0; i < files.Length; i++)
                    {

                        string fname = System.IO.Path.GetFileName(files[i]);
                        if (VBStrings.Right(fname.ToLower(), 4) == ".bmp")
                        {
                            string datecdFile = files[i];
                            TfPrint.openPrinter();
                            TfPrint.printBitmap(datecdFile, cus + year + month + date + seri);
                            TfPrint.closePrinter();
                            System.IO.File.Delete(files[i]);
                            txtResult.Text = cus + year + month + date + seri;
                            txtSerinumber.Text = seri;
                        }

                    }
                }
            }
            #endregion
            if (btnEditCode.Text == "Apply")
            {
                MessageBox.Show("Please apply button");
            }
        }
        #endregion
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
            bmp.Save(@"C:\PrintCode2DImage\OutBarcode.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
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
