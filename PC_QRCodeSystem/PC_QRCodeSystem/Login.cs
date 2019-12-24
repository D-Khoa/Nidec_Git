using System;
using System.Text;
using System.Windows.Forms;
using PC_QRCodeSystem.Model;

namespace PC_QRCodeSystem
{
    public partial class Login : Form
    {
        PSQL SQL = new PSQL();
        StringBuilder query = new StringBuilder();

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            query.Append("select distinct user_name from m_user order by user_name");
            SQL.getComboBoxData(query.ToString(), ref cmbLoginname);
            cmbLoginname.Text = null;
            query.Clear();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(cmbLoginname.Text))
            {
                query.Append("select user_pass from m_user where user_name = '").Append(cmbLoginname.Text).Append("'");
                if (SQL.sqlExecuteScalarString(query.ToString()) == txtpass.Text)
                {
                    MainForm main = new MainForm();
                    this.Hide();
                    main.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Wrong password!!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                query.Clear();
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
