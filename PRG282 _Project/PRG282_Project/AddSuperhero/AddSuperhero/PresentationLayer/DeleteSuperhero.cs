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
        // ===== Global Variables =====
        string filePath = @"superheroes.txt";

        // ===== Constructor =====
        public frmDelete()
        {
            InitializeComponent();
            btnDelete.Enabled = false;
        }

        // ===== Find Button Click =====
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

            string[] lines = File.ReadAllLines(filePath);
            string foundLine = lines.FirstOrDefault(line => line.StartsWith(id + ","));

            if (foundLine != null)
            {
                string[] data = foundLine.Split(',');

                lblFound.Text = "Found superhero: " +
                    "ID " + data[0] + ", Name " + data[1] +
                    ", Age " + data[2] + ", Power " + data[3] +
                    ", Score " + data[4] + ", Rank " + data[5] +
                    ", Threat " + data[6];
                btnDelete.Enabled = true;
                btnDelete.Visible = true;

                foreach (DataGridViewRow r in dgvHeroes.Rows)
                {
                    if (string.Equals(r.Cells["HeroId"].Value?.ToString(), id, StringComparison.OrdinalIgnoreCase))
                    {
                        dgvHeroes.ClearSelection();
                        r.Selected = true;
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("No superhero found with that ID.");
            }
        }

        // ===== Delete Button Click =====
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
                return;
            }

            var newLines = lines.Where(line => !line.StartsWith(id + ",")).ToArray();
            File.WriteAllLines(filePath, newLines);

            MessageBox.Show("Superhero deleted successfully!");

            lblFound.Text = "";
            txtHeroID.Clear();
            btnDelete.Enabled = false;
            btnDelete.Visible = false;

            RefreshGridAndResetSelection();
        }

        // ===== Form Load =====
        private void frmDelete_Load(object sender, EventArgs e)
        {
            dgvHeroes.ReadOnly = true;
            dgvHeroes.AllowUserToAddRows = false;
            dgvHeroes.AllowUserToDeleteRows = false;
            dgvHeroes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHeroes.MultiSelect = false;
            dgvHeroes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadGrid();
            dgvHeroes.CellClick += dgvHeroes_CellClick;

            UIhelper.CenterThreeButtons(btnBack, btnFind, btnDelete, pnlFooter);
            UIhelper.CenterLabelInPanel(lblHeading, pnlHeader);
            UIhelper.CenterLabelInPanel(lblFound, pnl4);
            UIhelper.CenterLabelAndTextBox(pnl1, lblHeroID, txtHeroID);
        }

        // ===== Back Button Click =====
        private void btnBack_Click(object sender, EventArgs e)
        {
            SuperHeroHome home = new SuperHeroHome();
            home.Show();
            this.Hide();
        }

        // ===== Heading Label Click =====
        private void lblHeading_Click(object sender, EventArgs e)
        {
        }

        // ===== DataGridView Cell Content Click =====
        private void dgvHeroes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvHeroes.Rows[e.RowIndex];

            string id = row.Cells["HeroId"].Value?.ToString();
            if (string.IsNullOrWhiteSpace(id)) return;

            txtHeroID.Text = id;

            lblFound.Text =
                $"You selected | HeroID: {row.Cells["HeroId"].Value} | Name: {row.Cells["Name"].Value} | Test rating: " +
                $"{row.Cells["Superpower"].Value} | Score: {row.Cells["Score"].Value} | " +
                $"Rank: {row.Cells["Rank"].Value}";

            btnDelete.Enabled = true;
            btnDelete.Visible = true;

            UIhelper.CenterLabelInPanel(lblFound, pnl4);

        }

        // ===== Load Grid =====
        private void LoadGrid()
        {
            try
            {
                if (dgvHeroes.Columns.Count == 0)
                {
                    dgvHeroes.Columns.Add("HeroId", "Hero ID");
                    dgvHeroes.Columns.Add("Name", "Name");
                    dgvHeroes.Columns.Add("Age", "Age");
                    dgvHeroes.Columns.Add("Superpower", "Superpower");
                    dgvHeroes.Columns.Add("Score", "Score");
                    dgvHeroes.Columns.Add("Rank", "Rank");
                    dgvHeroes.Columns.Add("ThreatLevel", "Threat Level");
                }

                dgvHeroes.Rows.Clear();

                if (!File.Exists(filePath)) return;

                foreach (var line in File.ReadAllLines(filePath))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var p = line.Split(',');
                    if (p.Length < 7) continue;

                    dgvHeroes.Rows.Add(p[0], p[1], p[2], p[3], p[4], p[5], p[6]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load heroes into the table.\n\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== Refresh Grid and Reset Selection =====
        private void RefreshGridAndResetSelection()
        {
            LoadGrid();
            if (dgvHeroes.Rows.Count > 0)
                dgvHeroes.ClearSelection();

            lblFound.Text = "";
        }

        // ===== DataGridView Cell Click =====
        private void dgvHeroes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvHeroes.Rows[e.RowIndex];
            string id = row.Cells[0]?.Value?.ToString();

            if (string.IsNullOrWhiteSpace(id)) return;

            txtHeroID.Text = id;

            UIhelper.CenterLabelInPanel(lblFound, pnl4);

            lblFound.Text = $"Selected ID: {id}. Click 'Find' to confirm and view details.";
            btnDelete.Enabled = false;
            btnDelete.Visible = false;
        }

        // ===== Paint Event =====
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
