using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace PrintCode2D
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txtCustomerCode.Enabled = false;
            groupBoxCode.Enabled = false;

        }
        private void btnPrint_Click(object sender, EventArgs e)
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
            TfPrint.openPrinter();
            TfPrint.printBarCodeNew(cus, year, month, date, seri);
            TfPrint.closePrinter();
        }

        private void btnEditCode_Click(object sender, EventArgs e)
        {
            if (btnEditCode.Text == "Edit Code")
            {
                groupBoxCode.Enabled = true;
                btnEditCode.Text = "Apply";
            }

            else
            {
                groupBoxCode.Enabled = false;
                btnEditCode.Text = "Edit Code";
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSerinumber.Text = "00001";
        }
    }
}
