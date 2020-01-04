using System;
using System.Windows.Forms;

namespace TrackingPQMData
{
    public partial class FormCommon : Form
    {
        /// <summary>
        /// Get tittle of form
        /// </summary>
        public string tittle
        {
            get { return lbTittle.Text; }
            set { lbTittle.Text = value; }
        }

        public FormCommon()
        {
            InitializeComponent();
        }

        private void FormCommon_Load(object sender, EventArgs e)
        {
            tittle = this.Text;
            this.Text = tittle + "-Tracking PQM Data";
        }
    }
}
