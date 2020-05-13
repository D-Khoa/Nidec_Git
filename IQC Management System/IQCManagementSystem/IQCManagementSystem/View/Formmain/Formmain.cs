using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IQCManagementSystem.View.Common;

namespace IQCManagementSystem.View.Formmain
{
    public partial class Formmain :FormCommon
    {
        public Formmain()
        {
            InitializeComponent();
        }

        private void btnEquipment_Click(object sender, EventArgs e)
        {
            FormEquipment feq = new FormEquipment();
            feq.ShowDialog();
        }
    }
}
