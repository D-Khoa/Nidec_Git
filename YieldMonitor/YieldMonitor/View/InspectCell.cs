using System;
using System.Drawing;
using System.Windows.Forms;

namespace YieldMonitor.View
{
    /// <summary>
    /// Inspect cell show yield rate of each process
    /// </summary>
    public partial class InspectCell : UserControl
    {
        /// <summary>
        /// Model name
        /// </summary>
        public string model
        {
            get { return lbmodel.Text; }
            set { lbmodel.Text = value; }
        }

        /// <summary>
        /// Number of input
        /// </summary>
        public double input
        {
            get { return double.Parse(lbInput.Text); }
            set { lbInput.Text = value.ToString(); }
        }

        /// <summary>
        /// Number of output
        /// </summary>
        public double output
        {
            get { return double.Parse(lbOutput.Text); }
            set { lbOutput.Text = value.ToString(); }
        }

        /// <summary>
        /// Yiel rate
        /// </summary>
        public double yeild
        {
            get { return double.Parse(lbYeild.Text); }
            set { lbYeild.Text = value.ToString(); }
        }

        /// <summary>
        /// Display color
        /// </summary>
        public Color color
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }

        public InspectCell()
        {
            InitializeComponent();
        }

        public void InspectCell_Paint(object sender, PaintEventArgs e)
        {
            lbInspectName.Text = this.Name;
            lbInput.Text = input.ToString();
            lbOutput.Text = output.ToString();
        }
    }
}
