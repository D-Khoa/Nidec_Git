using System;
using System.Drawing;
using System.Windows.Forms;

namespace PomodoroClock
{
    public partial class Form1 : Form
    {
        int cycle = 0;
        int timer = 0;
        int temp = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                cycle = 4;
                temp = cycle;
                timer = (int)numPomodoro.Value * 60;
                this.BackColor = Color.Green;
                btnStart.Text = "Stop";
                timer1.Enabled = true;
            }
            else
            {
                btnStart.Text = "Start";
                this.BackColor = Color.Gray;
                timer1.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer == 0)
            {
                if (cycle == 0)
                {
                    cycle = 4;
                    timer = (int)numRest.Value * 180;
                    this.BackColor = Color.Red;
                }
                if (cycle == temp)
                {
                    cycle--;
                    timer = (int)numRest.Value * 60;
                    this.BackColor = Color.Red;
                }
                else
                {
                    temp = cycle;
                    timer = (int)numPomodoro.Value * 60;
                    this.BackColor = Color.Green;
                }
            }
            timer--;
            int min = timer / 60;
            int sec = timer % 60;
            lbTime.Text = min.ToString("00") + " : " + sec.ToString("00");
        }

        private void pnlLed_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < cycle; i++)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Yellow),
                  new Rectangle(i * (pnlLed.Width / 4), 0, pnlLed.Width / 4, pnlLed.Height));
            }
        }
    }
}
