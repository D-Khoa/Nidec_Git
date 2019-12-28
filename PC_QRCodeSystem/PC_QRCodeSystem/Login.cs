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
            this.Text = lbTittle.Text + "-" + this.Text;
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
            try
            {
                if (!string.IsNullOrEmpty(txtUsername.Text))
                {
                    if (getData.CheckLogin(txtUsername.Text, txtpass.Text))
                    {
                        if (MessageBox.Show("The user is now online." + Environment.NewLine + "Are you want to re-login?", "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            return;
                    }
                    getData.Login(txtUsername.Text, txtpass.Text);
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
                    MessageBox.Show("Please choose username.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
