using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewModelCheckingResult.View.Common;

namespace NewModelCheckingResult.View.DiagaugeForm
{
    public partial class DiagaugeForm : FormCommon
    {
        public DiagaugeForm()
        {
            InitializeComponent();
            tcDiagauge.ItemSize = new Size(0, 1);
        }

        private void DiagaugeForm_Load(object sender, EventArgs e)
        {
            getComboListFromDB(ref cmbModel);

        }
        public void getComboListFromDB(ref ComboBox cmb)
        {
            string sql_model = "select model from tbl_model_dbplace order by model";
            System.Diagnostics.Debug.Print(sql_model);
            TfSQL tf = new TfSQL();
            tf.getComboBoxData(sql_model, ref cmb);

            if (cmbModel.Items.Count > 0)
                cmbModel.SelectedIndex = 0;
        }

        private void btnEditMaster_Click(object sender, EventArgs e)
        {
            tcDiagauge.SelectedTab = tabData;
        }
    }
}
