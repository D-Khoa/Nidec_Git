using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewModelCheckingResult.Model;


namespace NewModelCheckingResult.View.Common
{
    public partial class FormCommon : Form
    {
        #region ALL OPTION FIELDS
        public string name
        {
            get { return lbName.Text; }
            set { lbName.Text = value; }
        }
     
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
            tittle = this.Text;
            name = UserData.username;
            this.Text = tittle + "- IQC Model Checking Result";

        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword changeps = new ChangePassword();
            changeps.ShowDialog();
        }

      
    }
}
