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
    public partial class LoadingScreen : Form
    {
        int progressValue = 0;

        public LoadingScreen()
        {
            InitializeComponent();
        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            timer1.Interval = 50;
            timer1.Start();


            lblLoadingText.Left = (this.ClientSize.Width - lblLoadingText.Width) / 2;
            //lblLoadingText.Top = (ClientSize.Height - lblLoadingText.Height) / 2;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressValue += 2;
            if (progressValue <= 100)
            {
                progressBar1.Value = progressValue;
                lblLoadingText.Text = $"Loading... {progressValue}%";
            }
            else
            {
                timer1.Stop();
                SuperHeroHome mainForm = new SuperHeroHome();
                mainForm.Show();
                this.Hide();
            }
        }
    }
}