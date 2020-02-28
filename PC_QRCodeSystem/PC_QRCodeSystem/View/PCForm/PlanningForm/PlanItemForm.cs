using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;

namespace PC_QRCodeSystem.View
{
    public partial class PlanItemForm : FormCommon
    {
        pts_plan planData { get; set; }

        public PlanItemForm(pts_plan inPlan)
        {
            InitializeComponent();
        }
    }
}
