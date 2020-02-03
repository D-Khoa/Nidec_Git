using System;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;

namespace PC_QRCodeSystem.View
{
    public partial class DestinationManager : FormCommon
    {
        bool editMode { get; set; }

      //  m_department deptcbm { get; set; }
        m_department ptsdept { get; set; }
      //  pts_destination destcbm { get; set; }
        pts_destination ptsdest { get; set; }

        public DestinationManager()
        {
            InitializeComponent();
          //  deptcbm = new m_department();
            ptsdept = new m_department();
          //  destcbm = new pts_destination();
            ptsdest = new pts_destination();
            editMode = false;
            btnOK.Visible = false;
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;


        }

        #region SUB EVENT
        private void rbtnDepartMent_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnDepartMent.Checked)
            {
                cmbDepartmentCode.Enabled = true;
                txtDepartmantName.Enabled = true;
                cmbDestinationCode.Enabled = false;
                txtDestinationName.Enabled = false;
                txtGMUserCode.Enabled = true;
                txtGMUserName.Enabled = true;
                txtMUserCode.Enabled = true;
                txtMUserName.Enabled = true;
                dgvData.DataSource = null;
                dgvData.DataSource = ptsdept.listDept;
                //txtDepartmantName.BackColor = System.Drawing.Color.Yellow;
                //txtDestinationName.BackColor = System.Drawing.Color.Gray;
                //rbtnDepartMent.BackColor = System.Drawing.Color.Yellow;
                //rbtnDestinationCode.BackColor = System.Drawing.Color.Transparent;
            }
            if (rbtnDestinationCode.Checked)
            {
                cmbDepartmentCode.Enabled = false;
                txtDepartmantName.Enabled = false;
                cmbDestinationCode.Enabled = true;
                txtDestinationName.Enabled = true;
                txtGMUserCode.Enabled = true;
                txtGMUserName.Enabled = true;
                txtMUserCode.Enabled = true;
                txtMUserName.Enabled = true;
                dgvData.DataSource = null;
                dgvData.DataSource = ptsdest.listdestination;
            }
        }

        private void cmbDepartmentCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cmbDepartmentCode.Text))
                {
                    txtDepartmantName.Text = cmbDepartmentCode.SelectedValue.ToString();
                }
                else
                    txtDepartmantName.Text = " Department Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbDestinationCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cmbDestinationCode.Text))
                {
                    txtDestinationName.Text = cmbDestinationCode.SelectedValue.ToString();
                }
                else
                    txtDestinationName.Text = "Destination Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region MAIN BUTTON
        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateGrid(true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }




        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region SUB BUTTON
        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region METHOD
        private void UpdateGrid(bool isSearch)
        {
            if (rbtnDepartMent.Checked)
            {
                if (isSearch)
                    ptsdept.GetListDepartment(string.Empty, string.Empty);
                dgvData.DataSource = null;
                dgvData.DataSource = ptsdept.listDept;
                dgvData.Columns["dept_cd"].HeaderText = "Dept CD";
                dgvData.Columns["dept_name"].HeaderText = "Dept Name";
                dgvData.Columns["m_user_cd"].HeaderText = "User CD";
                dgvData.Columns["gm_user_cd"].HeaderText = "GM User CD";
                dgvData.Columns["registration_user_cd"].HeaderText = "Registration User";
                dgvData.Columns["registration_date_time"].HeaderText = "Registration Date";

            }
            if (rbtnDestinationCode.Checked)
            {
                if (isSearch)
                    ptsdest.GetListDestination(string.Empty, string.Empty);
                dgvData.DataSource = null;
                dgvData.DataSource = ptsdest.listdestination;
                dgvData.Columns["destination_id"].HeaderText = "Destination ID";
                dgvData.Columns["destination_cd"].HeaderText = "Destination CD";
                dgvData.Columns["destination_name"].HeaderText = "Destination Name";
                dgvData.Columns["dept_cd"].HeaderText = "Dept CD";
                dgvData.Columns["registration_user_cd"].HeaderText = "Registration User";
                dgvData.Columns["registration_date_time"].HeaderText = "Registration Date";
            }
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            isSearch = false;
        }

        private void GetCmbData()
        {
            ptsdept.GetListDepartment(string.Empty, string.Empty);
            cmbDepartmentCode.DataSource = ptsdept.listDept;
            cmbDepartmentCode.DisplayMember = "Department Code";
            cmbDepartmentCode.ValueMember = "Department Name";
            cmbDepartmentCode.Text = null;
            ptsdest.GetListDestination(string.Empty, string.Empty);
            cmbDestinationCode.DataSource = ptsdest.listdestination;
            cmbDestinationCode.DisplayMember = "Destination Code";
            cmbDestinationCode.ValueMember = "Destination Name";
            cmbDestinationCode.Text = null;

        }
        #endregion

        private void DestinationManager_Load(object sender, EventArgs e)
        {
            GetCmbData();
        }

        private void DestinationManager_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

      
    }
}
