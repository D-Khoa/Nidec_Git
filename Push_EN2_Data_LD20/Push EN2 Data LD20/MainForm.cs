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

namespace Push_EN2_Data_LD20
{
    public partial class MainForm : Form
    {
        SQLQuery sqlQuery = new SQLQuery();
        DataItem dataitem = new DataItem();
        List<DataItem> dataItems = new List<DataItem>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DirectoryInfo dataFolder = new DirectoryInfo(txtDataFolder.Text);
            FileInfo[] dataFiles = dataFolder.GetFiles("*.csv", SearchOption.AllDirectories);
            foreach (FileInfo file in dataFiles)
            {
                DateTime filedate = DateTime.Parse(file.Name.Split('_')[2].Remove(11));
                string table = file.Name.Split('_')[1] + filedate.ToString("yyyymm");
                file.FullName.ReadCSVtoDatatable(ref dt);
                dataItems = dataitem.GetDataItems(dt);
            }
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog of = new FolderBrowserDialog();
            if (of.ShowDialog() == DialogResult.OK)
                txtDataFolder.Text = of.SelectedPath + "\\";
        }

        private void btnBrowserServer_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog()
            {
                Multiselect = false,
                ReadOnlyChecked = true,
                CheckPathExists = false,
                CheckFileExists = false,
                FileName = "Select Server Folder",
            };
            if (of.ShowDialog() == DialogResult.OK)
                txtServerFolder.Text = Path.GetDirectoryName(of.FileName) + "\\";
        }
    }
}
