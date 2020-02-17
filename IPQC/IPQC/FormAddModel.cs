using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPQC
{
    public partial class FormAddModel : Form
    {
        public FormAddModel()
        {
            InitializeComponent();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if ((txtModel.Text != "") && (txtLine.Text != "") )
            {
                TfSQL con = new TfSQL();
                string sqladd = "INSERT INTO tbl_model_line(model, line) VALUES('" + txtModel.Text + "', '" + txtLine.Text + "')";
                con.sqlExecuteScalarString(sqladd);
                string sqladdplace = " INSERT INTO tbl_model_dbplace (model, dbplace) VALUES('" + txtModel.Text + "', '" + txtPlace.Text + "' )";
                con.sqlExecuteScalarString(sqladdplace);
                MessageBox.Show("Add Successfully", "Notification", MessageBoxButtons.OK);
                Close();
            }
            else
            {
                MessageBox.Show("Please insert Model or Line", " Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}
