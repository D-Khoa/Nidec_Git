using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YieldMonitor.Model;

namespace YieldMonitor.View
{
    public partial class TrackSettingForm : Form
    {
        public string Model { get; set; }

        public TrackSettingForm(string model)
        {
            InitializeComponent();
            Model = model;
        }

        private void btnAddProcess_Click(object sender, EventArgs e)
        {
            SettingForm addpro = new SettingForm();
            List<string> listTemp = new List<string>();
            List<string> listPro = new List<string>();
            GetData.GetProcessToList(ref listTemp, Model);
            addpro.listTemp = listTemp;
            addpro.listprocess = listPro;
            if(addpro.ShowDialog() == DialogResult.OK)
            {
                listTemp = addpro.listTemp;
                listPro = addpro.listprocess;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
