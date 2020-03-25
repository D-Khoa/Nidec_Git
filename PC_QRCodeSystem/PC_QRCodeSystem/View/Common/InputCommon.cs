using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_QRCodeSystem.View
{
    public partial class InputCommon : Form
    {
        public int inputQty { get; set; }
        private bool isText { get; set; }

        /// <summary>
        /// Init form
        /// </summary>
        /// <param name="isText">if input text</param>
        public InputCommon(bool istext)
        {
            InitializeComponent();
            isText = istext;
            if (!isText)
            {
                txtInput.TextAlign = HorizontalAlignment.Right;
                txtInput.Text = "0";
            }
        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!isText && char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            inputQty = int.Parse(txtInput.Text);
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
