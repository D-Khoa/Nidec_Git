using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackingPQMData.Controller;

namespace TrackingPQMData.View
{
    public partial class MainForm : FormCommon
    {
        GetSQLData getSQLData = new GetSQLData();

        public MainForm()
        {
            InitializeComponent();
            grt_Main.ItemSize = new Size(0, 1);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Get list model into combobox
            cmbModel.DataSource = getSQLData.GetModelList();
            cmbModel.DisplayMember = "model";
            cmbModel.Text = null;
        }

        private void OpenChart(object sender, EventArgs e)
        {
            grt_Main.SelectedTab = tab_Chart;
        }

        private void OpenData(object sender, EventArgs e)
        {
            grt_Main.SelectedTab = tab_Data;
        }

        private void OpenMainMenu(object sender, EventArgs e)
        {
            grt_Main.SelectedTab = tab_Main;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {

        }
    }
}
