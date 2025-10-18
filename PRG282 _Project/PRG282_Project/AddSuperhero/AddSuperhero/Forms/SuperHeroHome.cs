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
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Create an instance of Form2
            AddSuperhero addHero = new AddSuperhero();

            // Show Form2
            addHero.Show();

            // Optionally, hide Form1
            this.Hide();
        }

        private void btnViewSuper_Click(object sender, EventArgs e)
        {
            ViewAll view = new ViewAll();

            view.Show();

            this.Hide();
        }
    }
}