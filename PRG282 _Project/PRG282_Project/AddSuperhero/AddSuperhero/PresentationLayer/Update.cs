using AddSuperhero.DataLayer;
using AddSuperhero.LogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AddSuperhero
{
    public partial class Update : Form
    {
        // ===== Fields =====
        private readonly string filePath = "superheroes.txt";
        private DataTable table;
        private BindingSource bs = new BindingSource();
        private List<AddHero> heroes;

        // ===== Constructor =====
        public Update()
        {
            InitializeComponent();

            this.Load += Update_Load;
            this.FormClosed += SuperFormClosed;
            this.Resize += Update_Resize;

            dgvUpdate.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUpdate.ReadOnly = true;
            dgvUpdate.SelectionChanged += dgvUpdate_SelectionChanged;
            dgvUpdate.CellContentClick += dgvUpdate_CellContentClick;

            btnFind.Click += btnFind_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnBack.Click += btnBack_Click;
        }

        // ===== Form Closed =====
        private void SuperFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // ===== Form Load =====
        private void Update_Load(object sender, EventArgs e)
        {
            var dataHandler = new HeroDataHandler(filePath);
            heroes = dataHandler.GetAllHeroes();

            table = HeroLogic.ConvertHeroesToDataTable(heroes);
            bs.DataSource = table;
            dgvUpdate.DataSource = bs;
            dgvUpdate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvUpdate.Rows.Count > 0)
                dgvUpdate.Rows[0].Selected = true;

            CenterAllControls();
        }

        // ===== Grid Selection Changed =====
        private void dgvUpdate_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUpdate.CurrentRow == null) return;

            txtBoxID.Text = dgvUpdate.CurrentRow.Cells["HeroID"].Value?.ToString() ?? "";
            txtBoxName.Text = dgvUpdate.CurrentRow.Cells["Name"].Value?.ToString() ?? "";
            txtBoxAge.Text = dgvUpdate.CurrentRow.Cells["Age"].Value?.ToString() ?? "";
            txtBoxSuperpower.Text = dgvUpdate.CurrentRow.Cells["Superpower"].Value?.ToString() ?? "";
            txtBoxScore.Text = dgvUpdate.CurrentRow.Cells["ExamScore"].Value?.ToString() ?? "";
        }

        // ===== Find Hero =====
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (dgvUpdate.Rows.Count == 0)
            {
                MessageBox.Show("No data loaded.");
                return;
            }

            string idInput = txtBoxID.Text;
            string nameInput = txtBoxName.Text;
            AddHero foundHero = HeroLogic.FindHero(heroes, idInput, nameInput);

            if (foundHero != null)
            {
                foreach (DataGridViewRow row in dgvUpdate.Rows)
                {
                    if (row.IsNewRow) continue;
                    if (row.Cells["HeroID"].Value?.ToString() == foundHero.HeroID)
                    {
                        row.Selected = true;
                        dgvUpdate.CurrentCell = row.Cells["HeroID"];
                        dgvUpdate_SelectionChanged(dgvUpdate, EventArgs.Empty);
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Hero not found by ID or Name. Try partial name or check spelling.",
                    "Not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ===== Update Hero =====
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvUpdate.CurrentRow == null)
            {
                MessageBox.Show("Select a record in the table first.");
                return;
            }

            if (!int.TryParse(txtBoxAge.Text, out int age) || age <= 0)
            {
                MessageBox.Show("Age must be a positive number.");
                return;
            }

            if (!int.TryParse(txtBoxScore.Text, out int score) || score < 0 || score > 100)
            {
                MessageBox.Show("Exam score must be 0–100.");
                return;
            }

            var updatedHero = new AddHero(
                txtBoxID.Text.Trim(),
                txtBoxName.Text.Trim(),
                age,
                txtBoxSuperpower.Text.Trim(),
                score
            );

            int rowIndex = dgvUpdate.CurrentRow.Index;
            DataRow row = table.Rows[rowIndex];

            if (!HeroLogic.HasChanges(updatedHero, row))
            {
                MessageBox.Show("No changes detected. Record remains the same.",
                    "No changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            HeroLogic.UpdateHero(updatedHero, row);
            int indexInList = heroes.FindIndex(h => h.HeroID == updatedHero.HeroID);
            if (indexInList >= 0) heroes[indexInList] = updatedHero;

            HeroLogic.SaveAllHeroes(heroes, filePath);

            dgvUpdate.Refresh();
            dgvUpdate.ClearSelection();
            dgvUpdate.Rows[rowIndex].Selected = true;

            MessageBox.Show("Superhero updated successfully!");
        }

        // ===== Back Button =====
        private void btnBack_Click(object sender, EventArgs e)
        {
            SuperHeroHome home = new SuperHeroHome();
            home.Visible = true;
            this.Hide();
        }

        // ===== Resize Event =====
        private void Update_Resize(object sender, EventArgs e)
        {
            CenterAllControls();
        }

        // ===== Helper: Center Controls =====
        private void CenterAllControls()
        {
            UIhelper.CenterLabelAndTextBox(pnl1, lblID, txtBoxID);
            UIhelper.CenterLabelAndTextBox(pnl2, lblName, txtBoxName);
            UIhelper.CenterLabelAndTextBox(pnl3, lblAge, txtBoxAge);
            UIhelper.CenterLabelAndTextBox(pnl4, lblSuperPower, txtBoxSuperpower);
            UIhelper.CenterLabelAndTextBox(pnl5, lblScore, txtBoxScore);
            UIhelper.CenterLabelInPanel(lblHeading, pnlHead);
        }

        // ===== Grid Click =====
        private void dgvUpdate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
