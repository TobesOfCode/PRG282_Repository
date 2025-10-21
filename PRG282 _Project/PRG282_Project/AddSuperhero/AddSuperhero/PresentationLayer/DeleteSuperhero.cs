using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AddSuperhero
{
    public partial class frmDelete : Form
    {
        string filePath = @"superheroes.txt";

        public frmDelete()
        {
            InitializeComponent();
            btnDelete.Enabled = false; // disable delete until found
            this.FormClosed += SuperFormClosed;
        }

        private void SuperFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string id = txtHeroID.Text.Trim();

            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Please enter a Hero ID first.");
                return;
            }

            if (!File.Exists(filePath))
            {
                MessageBox.Show("The data file was not found!");
                return;
            }

            // Read all lines from the file
            string[] lines = File.ReadAllLines(filePath);
            string foundLine = lines.FirstOrDefault(line => line.StartsWith(id + ","));

            if (foundLine != null)
            {
                lblFound.Text = "Found: " + foundLine;
                btnDelete.Enabled = true;
                btnDelete.Visible = true;
            }
            else
            {
                MessageBox.Show("No superhero found with that ID.");
            }

        }//end find click

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtHeroID.Text.Trim();

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Data file not found!");
                return;
            }

            string[] lines = File.ReadAllLines(filePath);
            bool heroExists = lines.Any(line => line.StartsWith(id + ","));

            if (!heroExists)
            {
                MessageBox.Show("Hero not found or already deleted.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                    "Are you sure you want to delete this superhero?\nThis action cannot be undone.",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
            {
                // If user clicks No, stop the deletion
                return;
            }

            // Remove the line that matches the ID
            var newLines = lines.Where(line => !line.StartsWith(id + ",")).ToArray();
            File.WriteAllLines(filePath, newLines);

            MessageBox.Show("Superhero deleted successfully!");

            lblFound.Text = "";
            txtHeroID.Clear();
            btnDelete.Enabled = false;
            btnDelete.Visible = false;
        }//end delete click

        private void frmDelete_Load(object sender, EventArgs e)
        {

        }
    }
}
