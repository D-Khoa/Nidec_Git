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
        /// <summary>
        /// Get tittle of form
        /// </summary>
        public string tittle
        {
            get { return lbTittle.Text; }
            set { lbTittle.Text = value; }
        }

        /// <summary>
        /// Get username
        /// </summary>
     

        /// <summary>
        /// Get department
        /// </summary>
      

        /// <summary>
        /// Get login time of user
        /// </summary>
       
        public FormCommon()
        {
            InitializeComponent();
           
        }

        private void FormCommon_Load(object sender, EventArgs e)
        {
        }
        #endregion
        #region BUTTONS EVENT
       

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword chpass = new ChangePassword();
            chpass.ShowDialog();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {

           
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
       

        private void FormCommon_Shown(object sender, EventArgs e)
        {
            
        }

        private void timerFormLoad_Tick(object sender, EventArgs e)
        {
           
        }

        private void FormCommon_FormClosing(object sender, FormClosingEventArgs e)
        {

            
        }
    }
}
