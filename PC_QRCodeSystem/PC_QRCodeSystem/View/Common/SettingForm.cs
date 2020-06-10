using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;
using PC_QRCodeSystem.View.Common;

namespace PC_QRCodeSystem.View
{
    public partial class SettingForm : Form
    {
        #region VARIABLE
        private PrintItem printItem { get; set; }
        private SettingItem settingItem { get; set; }
        private Color tempColor { get; set; }
        public SettingForm()
        {
            InitializeComponent();
            printItem = new PrintItem();
            settingItem = new SettingItem();
            tempColor = new Color();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            GetCmb();
            if (!File.Exists(settingItem.settingPath)) ResetDefault();
            else settingItem.LoadSetting();
            SetField();
            LockPanel(true);
            if (!string.IsNullOrEmpty(SettingItem.checkSaved))
                checkSave.Checked = bool.Parse(settingItem.checkSave);
            //AcceptButton = btnPasswordOK;
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

        private void btnBrowserOutput_Click(object sender, EventArgs e)
        {
            //Create open file dialog for get premac file url
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.ValidateNames = true;
            openDialog.CheckPathExists = false;
            openDialog.CheckFileExists = false;
            openDialog.FileName = "Output Folder";
            openDialog.Filter = "Text File (*.txt)|*.txt|All file (*.*)|*.*";
            if (openDialog.ShowDialog() == DialogResult.OK)
                txtOutputFolder.Text = Path.GetDirectoryName(openDialog.FileName);
        }

        private void btnBrowserBackup_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.ValidateNames = true;
            openDialog.CheckPathExists = false;
            openDialog.CheckFileExists = false;
            openDialog.FileName = "Backup Folder";
            openDialog.Filter = "Text File (*.txt)|*.txt|All file (*.*)|*.*";
            if (openDialog.ShowDialog() == DialogResult.OK)
                txtBackupFolder.Text = Path.GetDirectoryName(openDialog.FileName);
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

        private void btnPrintTest_Click(object sender, EventArgs e)
        {
            TfPrint.printerName = cmbPrinter.Text;
            printItem.PrintAnItem(new PrintItem
            {
                Item_Number = txtItemCDTest.Text,
                Item_Name = txtItemNameTest.Text,
                SupplierName = txtSupplierTest.Text,
                Invoice = txtInvoiceTest.Text,
                Delivery_Date = dtpDateTest.Value,
                Delivery_Qty = int.Parse(txtQtyTest.Text),
                isRec = cbReceive.Checked,
                Label_Qty = 1
            }, false);
        }
        private void btnPasswordOK_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "NCVP#26qrcode")
            {
                AcceptButton = btnOK;
                LockPanel(false);
            }
            else
                CustomMessageBox.Notice("Password not correct!!" + Environment.NewLine + "Mật khẩu không đúng!!");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //Reset to default setting
            ResetDefault();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Save and exit setting form
            settingItem.outputTempFolder = txtOutputFolder.Text;
            settingItem.backupTempFolder = txtBackupFolder.Text;
            settingItem.premacFolder = txtPremacFolder.Text;
            settingItem.printerName = cmbPrinter.Text;
            settingItem.checkSave = checkSave.Checked.ToString();
            settingItem.SaveSetting();
            // this.Close();
            if (checkSave.Checked == true)
            {
                CustomMessageBox.Notice("Please login to continue!!" + Environment.NewLine + "Vui lòng đăng nhập để tiếp tục!!");
                this.Close();
                Login lgf = new Login();
                lgf.ShowDialog();

            }
            else
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
            txtOutputFolder.Text = settingItem.outputTempFolder;
            txtBackupFolder.Text = settingItem.backupTempFolder;
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

        private void LockPanel(bool isLock)
        {
            grPass.Visible = isLock;
            grPrinter.Enabled = !isLock;
            grOutFolder.Enabled = !isLock;
            grPremacFolder.Enabled = !isLock;
        }

        private void txtQtyTest_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        #endregion

        private void checkSave_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkSave.Checked && grPrinter.Enabled)
            //{
            //    AddCheckUser adck = new AddCheckUser();
            //    if (adck.ShowDialog() == DialogResult.OK)
            //    {
            //        checkSave.Checked = true;
            //    }
            //    else checkSave.Checked = false;
            //}

        }
    }
}
