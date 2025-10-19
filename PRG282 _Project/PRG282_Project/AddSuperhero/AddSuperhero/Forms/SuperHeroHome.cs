using SuperheroSummaryApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddSuperhero
{
    public partial class SuperHeroHome : Form
    {
        public SuperHeroHome()
        {
            InitializeComponent();
            this.FormClosed += SuperHeroHome_FormClosed;
        }

        private void SuperHeroHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddSuperhero addHero = new AddSuperhero();
            addHero.Show();
            this.Hide();
        }

        private void btnViewSuper_Click(object sender, EventArgs e)
        {
            ViewAll view = new ViewAll();
            view.Show();
            this.Hide();
        }

        private void SuperHeroHome_Resize(object sender, EventArgs e)
        {
            lblWelcome.Left = (pnlWelcome.ClientSize.Width - lblWelcome.Width) / 2;
            lblWelcome.Top = (pnlWelcome.ClientSize.Height - lblWelcome.Height) / 2;
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            SuperheroSummaryForm summaryForm = new SuperheroSummaryForm();
            summaryForm.Show();
            this.Hide();
        }
    }
}