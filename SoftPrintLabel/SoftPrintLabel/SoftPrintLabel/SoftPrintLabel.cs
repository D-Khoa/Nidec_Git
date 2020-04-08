using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoftPrintLabel.Model;

namespace SoftPrintLabel
{

    public partial class SoftPrintLabel : Form
    {
        Stopwatch stopwatch = new Stopwatch();
        OpenFileDialog chooseFolder;
        List<PrintItem> listprint = new List<PrintItem>();
        public SoftPrintLabel()
        {
            InitializeComponent();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openf = new OpenFileDialog();
                openf.Filter = "Excel file (*.xlsx)|*.xlsx|All file (*.*)|*.*";
                //openf.FileName = ".xlsx";
                openf.CheckFileExists = false;
                openf.CheckPathExists = false;
                openf.ValidateNames = true;
                if (openf.ShowDialog() == DialogResult.OK)
                {
                    txtFile.Text = openf.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrintItem_Click(object sender, EventArgs e)
        {
            //PrintItem printitem = new PrintItem();
            foreach(DataGridViewRow dr in dgvData.SelectedRows)
            {
                //printitem = dr.DataBoundItem as PrintItem;
                TfPrint.printBarCodeNew(dr.Cells["Asset_No"].Value.ToString(), dr.Cells["Asset_Name"].Value.ToString(), dr.Cells["Model"].Value.ToString(), dr.Cells["Ser"].Value.ToString(), dr.Cells["Inv"].Value.ToString());
            }
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                TfPrint.printBarCodeNew(dr.Cells["Asset_No"].Value.ToString(), dr.Cells["Asset_Name"].Value.ToString(), dr.Cells["Model"].Value.ToString(), dr.Cells["Ser"].Value.ToString(), dr.Cells["Inv"].Value.ToString());
            }
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            stopwatch.Restart();
            ExcelClass excel = new ExcelClass(txtFile.Text);
            excel.OpenWorkBook(txtFile.Text);
            listprint = excel.ReadExcelToList();
            dgvData.DataSource = listprint;
            tsRow.Text = dgvData.Rows.Count.ToString();
            excel.Exit();
            stopwatch.Stop();
            tsTime.Text = stopwatch.Elapsed.ToString("s\\.ff") + " s";
            Cursor = Cursors.Default;
        }
    }
}

