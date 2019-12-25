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
            txtUsername.Focus();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtpass.Focus();
                AcceptButton = btnOK;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text))
            {
                if (getData.CheckLogin(txtUsername.Text, txtpass.Text))
                {
                    MainForm main = new MainForm();
                    this.Hide();
                    txtpass.Clear();
                    main.ShowDialog();
                    getData.LogOut();
                    this.Show();
                    this.Focus();
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
    }
}
