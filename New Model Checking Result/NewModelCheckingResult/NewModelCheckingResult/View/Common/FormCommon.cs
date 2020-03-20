using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NewModelCheckingResult.View.Common
{
    public partial class FormCommon : Form
    {
        #region ALL OPTION FIELDS
        public delegate void RefreshEventHandler(object sender, EventArgs e);
        public event RefreshEventHandler RefreshEvent;
        DataTable dtInspectItems;
        DataTable dtLine;
        bool load_cmb = true;
        bool adm_flag = false;
        public string tittle
        {
            get { return lbTittle.Text; }
            set { lbTittle.Text = value; }
        }


        public FormCommon()
        {
            InitializeComponent();

        }
        #endregion

        private void FormCommon_Load(object sender, EventArgs e)
        {
            this.Left = 0;
            this.Top = 0;
            dtInspectItems = new DataTable();
            dtLine = new DataTable();
            defineItemTable(ref dtInspectItems);
            defineLineTable(ref dtLine);
            getComboListFromDB(ref cmbModel);
            updateDataGripViews(ref dgvMeasureItem, true);
            load_cmb = false;
            TfSQL flag = new TfSQL();
            bool fl = flag.sqlExecuteScalarBool("select admin_flag from iqc_user where user_name = '" + txtUser.Text + "'");
            if (fl == true) adm_flag = true;
            if (adm_flag == true) btnEditMaster.Enabled = true;
        }
        public string _ip;
        
        public void updateControls(string user, string ip)
        {
            txtUser.Text = user;
            _ip = ip;
        }
        private void defineItemTable(ref DataTable dt)
        {
            dt.Columns.Add("no", Type.GetType("System.String"));
            dt.Columns.Add("model", Type.GetType("System.String"));
            dt.Columns.Add("process", Type.GetType("System.String"));
            dt.Columns.Add("inspect", Type.GetType("System.String"));
            dt.Columns.Add("description", Type.GetType("System.String"));
            dt.Columns.Add("instrument", Type.GetType("System.String"));
        }
        private void defineLineTable(ref DataTable dt)
        {
            dt.Columns.Add("model", Type.GetType("System.String"));
            dt.Columns.Add("line", Type.GetType("System.String"));
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
        public void updateDataGripViews(ref DataGridView dgv, bool load)
        {
            dtInspectItems.Clear();
            string model = cmbModel.Text;
            string sql = "select no, model, process, inspect, description, instrument from tbl_measure_item where model='"
                + model + "' order by no, process, inspect";
            System.Diagnostics.Debug.Print(sql);
            TfSQL tf = new TfSQL();
            tf.sqlDataAdapterFillDatatable(sql, ref dtInspectItems);
            dgv.DataSource = dtInspectItems;
            dgv.Columns["no"].Width = 50;
            dgv.Columns["model"].Width = 50;
            dgv.Columns["process"].Width = 100;
            dgv.Columns["inspect"].Width = 100;
            dgv.Columns["description"].Width = 400;
            dgv.Columns["instrument"].Width = 80;
        }

        private void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (load_cmb) return;

            updateDataGripViews(ref dgvMeasureItem, false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvMeasureItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
