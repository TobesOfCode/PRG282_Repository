using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace AddSuperhero
{
    public partial class ViewAll : Form
    {
        // ===== Fields =====
        private DataTable table;
        private BindingSource bs;

        // ===== Constructor =====
        public ViewAll()
        {
            InitializeComponent();
            this.FormClosed += SuperFormClosed;
        }

        // ===== Form Closed =====
        private void SuperFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // ===== Form Load =====
        private void ViewAll_Load(object sender, EventArgs e)
        {
            // Anchor and center UI elements
            UIhelper.AnchorLeftVertically(pnlHeading, lblFilter, cbxFilter, 5);
            UIhelper.CenterLabelInPanel(lblHeading, pnlHeading);

            // Setup ComboBox filter
            cbxFilter.Items.Clear();
            cbxFilter.Items.Add("All");
            cbxFilter.Items.Add("S-Rank");
            cbxFilter.Items.Add("A-Rank");
            cbxFilter.Items.Add("B-Rank");
            cbxFilter.Items.Add("C-Rank");
            cbxFilter.SelectedIndex = 0;
            cbxFilter.SelectedIndexChanged += cbxFilter_SelectedIndexChanged;

            // Center the Return button
            CenterReturnButton();

            // Load superhero data
            LoadSuperheroData("superheroes.txt");

            // Bind data
            bs = new BindingSource();
            bs.DataSource = table;

            dgvViewSuperheroes.DataSource = bs;
            dgvViewSuperheroes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvViewSuperheroes.ReadOnly = true;
            dgvViewSuperheroes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // ===== Load Data =====
        private void LoadSuperheroData(string filepath)
        {
            if (!File.Exists(filepath))
            {
                MessageBox.Show("File not found!");
                return;
            }

            string[] lines = File.ReadAllLines(filepath);
            if (lines.Length == 0) return;

            table = new DataTable();
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
        }

        // ===== ComboBox Filter =====
        private void cbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bs == null) return;

            string selected = cbxFilter.SelectedItem?.ToString() ?? "All";
            if (selected == "All")
                bs.RemoveFilter();
            else
                bs.Filter = $"Rank = '{selected}'";
        }

        // ===== Return Button =====
        private void btnReturn_Click(object sender, EventArgs e)
        {
            SuperHeroHome home = new SuperHeroHome();
            home.Visible = true;
            this.Hide();
        }

        // ===== Resize Handling =====
        private void ViewAll_Resize(object sender, EventArgs e)
        {
            CenterReturnButton();
        }

        // ===== Helper: Center Return Button =====
        private void CenterReturnButton()
        {
            btnReturn.Left = (pnlFooter.Width - btnReturn.Width) / 2;
            btnReturn.Top = (pnlFooter.Height - btnReturn.Height) / 2;
        }
    }
}
