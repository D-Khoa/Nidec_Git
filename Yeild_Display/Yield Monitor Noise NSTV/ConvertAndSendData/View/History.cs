using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertAndSendData.View
{
    public partial class History : UserControl
    {
        public string model
        {
            get { return lbmodel.Text; }
            set { lbmodel.Text = value; }
        }
        public DataTable dataH { get; set; }
        //public double input
        //{
        //    get { return double.Parse(lbInput.Text); }
        //    set { lbInput.Text = value.ToString(); }
        //}
        //public double output
        //{
        //    get { return double.Parse(lbOutput.Text); }
        //    set { lbOutput.Text = value.ToString(); }
        //}
        public History()
        {
            InitializeComponent();
        }
        public void History_Paint(object sender, PaintEventArgs e)
        {
            lbInspectNameH.Text = this.Name;
            //lbInput.Text = input.ToString();
            //lbOutput.Text = output.ToString();
        }
        public override void Refresh()
        {
            base.Refresh();
            dgvHistory.DataSource = dataH;
        }
    }
}
