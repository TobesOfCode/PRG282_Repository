using AddSuperhero.Forms;
using SuperheroSummaryApp;
using System;
using System.Windows.Forms;

namespace AddSuperhero
{
    public partial class SuperHeroHome : Form
    {
        // ===== Constructor =====
        public SuperHeroHome()
        {
            InitializeComponent();
            this.FormClosed += SuperHeroHome_FormClosed;
        }

        // ===== Form Closed =====
        private void SuperHeroHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // ===== Add Hero =====
        private void button1_Click(object sender, EventArgs e)
        {
            AddSuperhero addHero = new AddSuperhero();
            addHero.Show();
            this.Hide();
        }

        // ===== View All Heroes =====
        private void btnViewSuper_Click(object sender, EventArgs e)
        {
            LoadViewAll view = new LoadViewAll();
            view.Show();
            this.Hide();
        }

        // ===== Summary =====
        private void btnSummary_Click(object sender, EventArgs e)
        {
            SuperheroSummaryForm summaryForm = new SuperheroSummaryForm();
            summaryForm.Show();
            this.Hide();
        }

        // ===== Update Hero =====
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Update update = new Update();
            update.Show();
            this.Hide();
        }

        // ===== Delete Hero =====
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            frmDelete delete = new frmDelete();
            delete.Show();
            this.Hide();
        }

        // ===== Resize Layout =====
        private void SuperHeroHome_Resize(object sender, EventArgs e)
        {
            lblWelcome.Left = (pnlWelcome.ClientSize.Width - lblWelcome.Width) / 2;
            lblWelcome.Top = (pnlWelcome.ClientSize.Height - lblWelcome.Height) / 2;
        }

        // ===== Form Load =====
        private void SuperHeroHome_Load(object sender, EventArgs e)
        {
        }
    }
}
