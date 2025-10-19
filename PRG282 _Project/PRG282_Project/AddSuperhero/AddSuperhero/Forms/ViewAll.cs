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
    public partial class ViewAll : Form
    {
        public ViewAll()
        {
            InitializeComponent();
            this.FormClosed += SuperFormClosed;
        }

        private void SuperFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ViewAll_Load(object sender, EventArgs e)
        {
            string filepath = "superheroes.txt";

            if (!File.Exists(filepath))
            {
                MessageBox.Show("File not found!");
                return;
            }

            string[] lines = File.ReadAllLines(filepath);
            if (lines.Length == 0) return;

            DataTable table = new DataTable();
            table.Columns.Add("HeroID");
            table.Columns.Add("Name");
            table.Columns.Add("Age");
            table.Columns.Add("Superpower");
            table.Columns.Add("ExamScore");
            table.Columns.Add("Rank");
            table.Columns.Add("ThreatLevel");
            table.Columns.Add("Description");

            foreach (string line in lines)
            {
                string[] fields = line.Split(',');

                if (fields.Length < 5) continue;

                int age = int.TryParse(fields[2], out int a) ? a : 0;
                int examScore = int.TryParse(fields[4], out int score) ? score : 0;

                AddHero hero = new AddHero(fields[0], fields[1], age, fields[3], examScore);

                string description = fields.Length > 5 ? string.Join(",", fields, 5, fields.Length - 5) : "";

                table.Rows.Add(
                    hero.HeroID,
                    hero.Name,
                    hero.Age,
                    hero.Superpower,
                    hero.ExamScore,
                    hero.Rank,
                    hero.ThreatLevel,
                    description
                );
            }

            dgvViewSuperheroes.DataSource = table;
            dgvViewSuperheroes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvViewSuperheroes.ReadOnly = true;
            dgvViewSuperheroes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            SuperHeroHome home = new SuperHeroHome();

            home.Visible = true;

            this.Hide();
        }
    }
}

