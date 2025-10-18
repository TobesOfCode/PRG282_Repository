using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AddSuperhero
{
    public partial class AddSuperhero : Form
    {
        public AddSuperhero()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(txtBoxID.Text) ||
                    string.IsNullOrWhiteSpace(txtBoxName.Text) ||
                    string.IsNullOrWhiteSpace(txtBoxAge.Text) ||
                    string.IsNullOrWhiteSpace(txtBoxSuperpower.Text) ||
                    string.IsNullOrWhiteSpace(txtBoxScore.Text))
                {
                    MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtBoxAge.Text, out int age) || age <= 0)
                {
                    MessageBox.Show("Age must be a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtBoxScore.Text, out int score) || score < 0 || score > 100)
                {
                    MessageBox.Show("Exam score must be between 0 and 100.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create new hero object
                AddHero hero = new AddHero(txtBoxID.Text, txtBoxName.Text, age, txtBoxSuperpower.Text, score);

                // Save to file
                string filePath = "superheroes.txt";
                hero.SaveToFile(filePath);

                // Confirm
                MessageBox.Show($"Superhero '{hero.Name}' added successfully!\nRank: {hero.Rank}\nThreat: {hero.ThreatLevel}",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear inputs
                txtBoxID.Clear();
                txtBoxName.Clear();
                txtBoxAge.Clear();
                txtBoxSuperpower.Clear();
                txtBoxScore.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
