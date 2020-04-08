using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        OpenFileDialog chooseFolder;
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

        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {

        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ExcelClass excel = new ExcelClass(txtFile.Text);
            excel.OpenWorkBook(txtFile.Text);
            List<PrintItem> listprint = excel.ReadExcelToList();
            excel.Exit();
            dgvData.DataSource = listprint;
            Cursor = Cursors.Default;

        }
    }
}

