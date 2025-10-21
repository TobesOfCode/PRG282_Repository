using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddSuperhero.Forms
{
    public partial class LoadViewAll : Form
    {
        public LoadViewAll()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoadViewAll_Load(object sender, EventArgs e)
        {
            timer1.Start();

            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            timer1.Interval = 5;
           


            lblLoad.Left = (this.ClientSize.Width - lblLoad.Width) / 2;
            lblLoad.Top = (this.ClientSize.Height - lblLoad.Height) / 2;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(progressBar1.Value <100)
            {
                progressBar1.Value += 1;

                label2.Text = progressBar1.Value.ToString() + "%";


            }
            else
            {
                timer1.Stop();

                ViewAll view = new ViewAll();

                view.Show();

                this.Hide();
            }

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
