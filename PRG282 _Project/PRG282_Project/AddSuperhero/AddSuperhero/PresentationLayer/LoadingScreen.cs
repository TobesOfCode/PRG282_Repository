using System;
using System.Windows.Forms;

namespace AddSuperhero.Forms
{
    public partial class LoadingScreen : Form
    {
        // ===== Fields =====
        int progressValue = 0;

        // ===== Constructor =====
        public LoadingScreen()
        {
            InitializeComponent();
        }

        // ===== Form Load =====
        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            timer1.Interval = 50;
            timer1.Start();

            lblLoadingText.Left = (this.ClientSize.Width - lblLoadingText.Width) / 2;
            lblLoadingText.Top = (this.ClientSize.Height - lblLoadingText.Height) / 2;
        }

        // ===== Timer Tick =====
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

        // ===== Label Click =====
        private void lblLoadingText_Click(object sender, EventArgs e)
        {
        }
    }
}
