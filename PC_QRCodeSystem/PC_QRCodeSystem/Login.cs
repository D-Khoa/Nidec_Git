using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;

namespace PC_QRCodeSystem
{
    public partial class Login : Form
    {
        GetData getData = new GetData();

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            cmbLoginname.DataSource = getData.GetListUser();
            cmbLoginname.Text = null;
            cmbLoginname.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbLoginname.Text))
            {
                if (getData.CheckLogin(cmbLoginname.Text, txtpass.Text))
                {
                    MainForm main = new MainForm();
                    this.Hide();
                    txtpass.Clear();
                    main.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Wrong password!!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please choose username.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmbLoginname_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtpass.Focus();
        }
    }
}
