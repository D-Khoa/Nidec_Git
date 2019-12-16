using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalCheck.Model;

namespace FinalCheck
{
    public partial class Main : Form
    {
        List<string> listProcess = new List<string>();
        string pass = "1111";
        string model;

        public Main()
        {
            InitializeComponent();
            grt_Main.ItemSize = new Size(0, 1);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            cmbModel.GetModelToCombobox();
            cmbModel.Text = null;
        }

        #region OPEN & CLOSE SETTING TAB
        private void btnSetting_Click(object sender, EventArgs e)
        {
            grt_Main.SelectedTab = tab_Password;
        }

        private void txtPassBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CheckPassWord(pass))
                    grt_Main.SelectedTab = tab_Setting;
            }
        }

        private void btnPassOK_Click(object sender, EventArgs e)
        {
            if (CheckPassWord(pass))
                grt_Main.SelectedTab = tab_Setting;
        }

        private void btnPassCancel_Click(object sender, EventArgs e)
        {
            grt_Main.SelectedTab = tab_Run;
        }

        private bool CheckPassWord(string pass)
        {
            if (txtPassBox.Text != pass)
            {
                MessageBox.Show("Wrong Password!!!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassBox.Clear();
                return false;
            }
            return true;
        }

        private void btnSettingApply_Click(object sender, EventArgs e)
        {
            ApplySetting();
            grt_Main.SelectedTab = tab_Run;
        }

        private void ApplySetting()
        {
            model = cmbModel.Text;
        }

        private void btnSettingCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("The settings you change do not save. Are you sure to cancel?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                grt_Main.SelectedTab = tab_Run;
        }
        #endregion

        private void tab_Run_Paint(object sender, PaintEventArgs e)
        {
            lbModel.Text = model;
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                GetData.GetProcessToList(ref listProcess, model);
            }
        }
    }
}
