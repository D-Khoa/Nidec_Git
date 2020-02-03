using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PomodoroClock
{
    public partial class Form1 : Form
    {
        int cycle = 0;
        int timer = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                cycle = 8;
                timer = (int)numPomodoro.Value * 60;
                this.BackColor = Color.Green;
                btnStart.Text = "Stop";
                timer1.Enabled = true;
            }
            else
            {
                btnStart.Text = "Start";
                this.BackColor = Color.Red;
                timer1.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer == 0)
            {
                if (cycle == 0)
                {
                    cycle = 8;
                    timer = (int)numRest.Value * 180;
                    this.BackColor = Color.Red;
                    this.Show();
                }
                if (cycle % 2 == 0)
                {
                    cycle--;
                    timer = (int)numRest.Value * 60;
                    this.BackColor = Color.Red;
                    this.Show();
                }
                else
                {
                    cycle--;
                    timer = (int)numPomodoro.Value * 60;
                    this.BackColor = Color.Green;
                }
            }
            timer--;
            int min = timer / 60;
            int sec = timer % 60;
            lbTime.Text = min + " : " + sec;
        }
    }
}
