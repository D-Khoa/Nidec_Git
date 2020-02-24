using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;

namespace PC_QRCodeSystem.View
{
    public partial class SettingForm : Form
    {
        #region VARIABLE
        private PrintItem printItem { get; set; }
        private SettingItem settingItem { get; set; }
        public SettingForm()
        {
            InitializeComponent();
            printItem = new PrintItem();
            settingItem = new SettingItem();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            GetCmb();
            if (!File.Exists(settingItem.settingPath)) ResetDefault();
            else settingItem.LoadSetting();
            SetField();
        }
        #endregion

        #region BUTTONS EVENT
        private void btnBrowserPremac_Click(object sender, EventArgs e)
        {
            //Create open file dialog for get premac file url
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.ValidateNames = true;
            openDialog.CheckPathExists = false;
            openDialog.CheckFileExists = false;
            openDialog.FileName = "CPFXE049.TXT";
            openDialog.Filter = "Text File (*.txt)|*.txt|All file (*.*)|*.*";
            if (openDialog.ShowDialog() == DialogResult.OK)
                txtPremacFolder.Text = openDialog.FileName;
        }

        private void btnPrinterCheck_Click(object sender, EventArgs e)
        {
            //Check status of printer
            if (printItem.CheckPrinterIsOffline(cmbPrinter.Text))
            {
                lbPrinterStatus.Text = "OFFLINE";
                lbPrinterStatus.BackColor = Color.Red;
            }
            else
            {
                lbPrinterStatus.Text = "ONLINE";
                lbPrinterStatus.BackColor = Color.Lime;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //Reset to default setting
            ResetDefault();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Save and exit setting form
            settingItem.premacFolder = txtPremacFolder.Text;
            settingItem.printerName = cmbPrinter.Text;
            settingItem.SaveSetting();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region SUB EVENT
        /// <summary>
        /// Get list printer name into combobox
        /// </summary>
        private void GetCmb()
        {
            List<string> listprintername = System.Drawing.Printing.PrinterSettings.InstalledPrinters.Cast<string>().ToList();
            cmbPrinter.DataSource = listprintername;
            cmbPrinter.Text = null;
        }

        /// <summary>
        /// Set value all fields in form
        /// </summary>
        private void SetField()
        {
            txtPremacFolder.Text = settingItem.premacFolder;
            cmbPrinter.Text = settingItem.printerName;
        }

        /// <summary>
        /// Reset to default setting
        /// </summary>
        private void ResetDefault()
        {
            settingItem.DefaultSetting();
            SetField();
        }
        #endregion
    }
}
