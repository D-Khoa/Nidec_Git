using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConvertPremacFile.Model;



namespace ConvertPremacFile
{
    public partial class Menu_Form : Form
    {
        pts_item premacfile = new pts_item();
        OpenFileDialog chooseFolder;
        List<string> setString;
        string settingfile;
        int c;
        public Menu_Form()
        {
            InitializeComponent();
            setString = new List<string>();
            settingfile = @"C:\Convert Premac File\ini.txt";
        }
        #region FORM LOAD
        private void Menu_Form_Load(object sender, EventArgs e)
        {
            if (File.Exists(settingfile))
            {
                setString = File.ReadLines(settingfile).ToList();
            }
            txtSupplier.Text = setString[0].Trim().Split('=')[1];
            txtItem.Text = setString[1].Trim().Split('=')[1];
        }

        private void Menu_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                setString.Clear();
                setString.Add("SUPPLIER FOLDER =" + txtSupplier.Text);
                setString.Add("ITEM FOLDER =" + txtItem.Text);
                if (!Directory.Exists(Path.GetDirectoryName(settingfile)))
                    Directory.CreateDirectory(Path.GetDirectoryName(settingfile));
                File.WriteAllLines(settingfile, setString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


        #region BUTTON CONVERT    
        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (string file in Directory.GetFiles(txtItem.Text, "*CPBE0012*"))
                {
                    premacfile.GetListItems(file);
                    premacfile.WriteToDB(premacfile.listItems);
                }
                //MessageBox.Show("Complete");
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now == dateTimePicker1.Value)
                try
                {
                    {
                        premacfile.GetListItems(txtItem.Text);
                        premacfile.WriteToDB(premacfile.listItems);
                        MessageBox.Show("Complete");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
        #endregion

        #region CHOOSE FOLDER DATA
        private void btnBrowserSupplier_Click(object sender, EventArgs e)
        {
            txtSupplier.Text = ChooseFolder();
        }

        private void btnBrowserItem_Click(object sender, EventArgs e)
        {
            txtItem.Text = ChooseFolder();
        }

        private string ChooseFolder()
        {
            chooseFolder = new OpenFileDialog();
            chooseFolder.CheckFileExists = false;
            chooseFolder.CheckPathExists = false;
            chooseFolder.ShowReadOnly = true;
            chooseFolder.FileName = "Select Folder";
            if (chooseFolder.ShowDialog() == DialogResult.OK)
            {
                return Path.GetDirectoryName(chooseFolder.FileName) + @"\";
            }
            else
                return "";
        }
        #endregion


    }
}

