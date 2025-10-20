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
    public partial class Update : Form
    {
        private readonly string filePath = "superheroes.txt";
        private DataTable table;
        private BindingSource bs = new BindingSource();

        private void CenterLabelAndTextBox(Panel panel, Label lbl, TextBox txt)
        {
            // Calculate group bounds
            int groupLeft = Math.Min(lbl.Left, txt.Left);
            int groupRight = Math.Max(lbl.Right, txt.Right);
            int groupTop = Math.Min(lbl.Top, txt.Top);
            int groupBottom = Math.Max(lbl.Bottom, txt.Bottom);

            int groupWidth = groupRight - groupLeft;
            int groupHeight = groupBottom - groupTop;

            // Calculate new top-left coordinates to center the group
            int startX = (panel.ClientSize.Width - groupWidth) / 2;
            int startY = (panel.ClientSize.Height - groupHeight) / 2;

            // Offset to move both controls
            int offsetX = startX - groupLeft;
            int offsetY = startY - groupTop;

            // Move controls by the offset
            lbl.Left += offsetX;
            lbl.Top += offsetY;
            txt.Left += offsetX;
            txt.Top += offsetY;
        }

        public Update()
        {
            InitializeComponent();

            this.Load += Update_Load;
            dgvUpdate.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUpdate.ReadOnly = true;
            dgvUpdate.SelectionChanged += dgvUpdate_SelectionChanged;

            btnFind.Click += btnFind_Click;
            btnUpdate.Click += btnUpdate_Click;
            this.FormClosed += SuperFormClosed;
        }

        private void SuperFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Update_Load(object sender, EventArgs e)
        {
            table = new DataTable("Superheroes");
            table.Columns.Add("HeroID");
            table.Columns.Add("Name");
            table.Columns.Add("Age");
            table.Columns.Add("Superpower");
            table.Columns.Add("ExamScore");
            table.Columns.Add("Rank");
            table.Columns.Add("ThreatLevel");

            if (File.Exists(filePath))
            {
                foreach (var line in File.ReadAllLines(filePath))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var f = line.Split(',');
                    if (f.Length < 5) continue;

                    int age = int.TryParse(f[2], out var a) ? a : 0;
                    int score = int.TryParse(f[4], out var s) ? s : 0;

                    var hero = new AddHero(f[0], f[1], age, f[3], score);
                    table.Rows.Add(hero.HeroID, hero.Name, hero.Age, hero.Superpower,
                                   hero.ExamScore, hero.Rank, hero.ThreatLevel);
                }
            }

            bs.DataSource = table;
            dgvUpdate.DataSource = bs;
            dgvUpdate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvUpdate.Rows.Count > 0) dgvUpdate.Rows[0].Selected = true;

            CenterLabelAndTextBox(pnl1, lblID, txtBoxID);

            CenterLabelAndTextBox(pnl1, lblID, txtBoxID);
            CenterLabelAndTextBox(pnl2, lblName, txtBoxName);
            CenterLabelAndTextBox(pnl3, lblAge, txtBoxAge);
            CenterLabelAndTextBox(pnl4, lblSuperPower, txtBoxSuperpower);
            CenterLabelAndTextBox(pnl5, lblScore, txtBoxScore);

            UIhelper.CenterLabelInPanel(lblHeading, pnlHead);
        }

        private void dgvUpdate_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUpdate.CurrentRow == null) return;

            txtBoxID.Text = dgvUpdate.CurrentRow.Cells["HeroID"].Value?.ToString() ?? "";
            txtBoxName.Text = dgvUpdate.CurrentRow.Cells["Name"].Value?.ToString() ?? "";
            txtBoxAge.Text = dgvUpdate.CurrentRow.Cells["Age"].Value?.ToString() ?? "";
            txtBoxSuperpower.Text = dgvUpdate.CurrentRow.Cells["Superpower"].Value?.ToString() ?? "";
            txtBoxScore.Text = dgvUpdate.CurrentRow.Cells["ExamScore"].Value?.ToString() ?? "";
        }

        // helper: normalize strings for comparison (trim, collapse spaces, lower-case)
        private string Normalize(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;
            var parts = s.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return string.Join(" ", parts).ToLowerInvariant();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (dgvUpdate.Rows.Count == 0)
            {
                MessageBox.Show("No data loaded.");
                return;
            }

            // Primary inputs
            string idBoxText = txtBoxID.Text ?? string.Empty;
            string nameBoxText = txtBoxName.Text ?? string.Empty;

            // Trim for simple checks
            string idInputTrim = idBoxText.Trim();
            string nameInputTrim = nameBoxText.Trim();

            if (string.IsNullOrWhiteSpace(idInputTrim) && string.IsNullOrWhiteSpace(nameInputTrim))
            {
                MessageBox.Show("Enter a Hero ID or Name to find.");
                return;
            }

            try
            {
                // Ensure expected columns exist
                if (!dgvUpdate.Columns.Contains("HeroID") && !dgvUpdate.Columns.Contains("Name"))
                {
                    MessageBox.Show("DataGridView does not contain 'HeroID' or 'Name' columns.");
                    return;
                }

                dgvUpdate.ClearSelection();

                DataGridViewRow foundRow = null;

                // 1) If the ID box looks numeric, try exact ID match first
                int tmp;
                bool idLooksNumeric = int.TryParse(idInputTrim, out tmp);
                if (idLooksNumeric && !string.IsNullOrWhiteSpace(idInputTrim))
                {
                    foreach (DataGridViewRow row in dgvUpdate.Rows)
                    {
                        if (row.IsNewRow) continue;
                        var cid = row.Cells["HeroID"].Value?.ToString();
                        if (string.IsNullOrWhiteSpace(cid)) continue;
                        if (string.Equals(cid.Trim(), idInputTrim, StringComparison.OrdinalIgnoreCase))
                        {
                            foundRow = row;
                            break;
                        }
                    }
                }

                // 2) If not found by ID, decide which name text to use:
                // prefer txtBoxName if it has content; otherwise use txtBoxID (in case user typed the name there).
                if (foundRow == null)
                {
                    string nameSearchSource = !string.IsNullOrWhiteSpace(nameInputTrim) ? nameInputTrim : idInputTrim;
                    string normalizedSearch = Normalize(nameSearchSource);

                    // exact name match first
                    if (!string.IsNullOrWhiteSpace(normalizedSearch))
                    {
                        foreach (DataGridViewRow row in dgvUpdate.Rows)
                        {
                            if (row.IsNewRow) continue;
                            var cnameObj = row.Cells["Name"].Value;
                            if (cnameObj == null) continue;
                            string cellName = cnameObj.ToString();
                            if (Normalize(cellName).Equals(normalizedSearch, StringComparison.Ordinal))
                            {
                                foundRow = row;
                                break;
                            }
                        }
                    }

                    // 3) If still not found, try partial (contains) on normalized name
                    if (foundRow == null && !string.IsNullOrWhiteSpace(normalizedSearch))
                    {
                        foreach (DataGridViewRow row in dgvUpdate.Rows)
                        {
                            if (row.IsNewRow) continue;
                            var cnameObj = row.Cells["Name"].Value;
                            if (cnameObj == null) continue;
                            string cellName = cnameObj.ToString();
                            if (Normalize(cellName).IndexOf(normalizedSearch, StringComparison.Ordinal) >= 0)
                            {
                                foundRow = row;
                                break;
                            }
                        }
                    }
                }

                // Select and focus found row (if any)
                if (foundRow != null)
                {
                    foundRow.Selected = true;
                    if (dgvUpdate.Columns.Contains("HeroID"))
                        dgvUpdate.CurrentCell = foundRow.Cells["HeroID"];
                    else if (foundRow.Cells.Count > 0)
                        dgvUpdate.CurrentCell = foundRow.Cells[0];

                    dgvUpdate_SelectionChanged(dgvUpdate, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Hero not found by ID or Name. Try partial name or check spelling.", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ArgumentException aex)
            {
                MessageBox.Show("Column lookup error: " + aex.Message + "\nEnsure dgvUpdate has columns named 'HeroID' and 'Name'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during search: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private string NormalizeForCompare(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;
            var parts = s.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return string.Join(" ", parts).ToLowerInvariant();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUpdate.CurrentRow == null)
                {
                    MessageBox.Show("Select a record in the table first.");
                    return;
                }

                // Basic field presence validation
                if (string.IsNullOrWhiteSpace(txtBoxID.Text) ||
                    string.IsNullOrWhiteSpace(txtBoxName.Text) ||
                    string.IsNullOrWhiteSpace(txtBoxAge.Text) ||
                    string.IsNullOrWhiteSpace(txtBoxSuperpower.Text) ||
                    string.IsNullOrWhiteSpace(txtBoxScore.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                // Numeric validation
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

                // Build updated hero so Rank/ThreatLevel are computed consistently
                var updated = new AddHero(
                    txtBoxID.Text.Trim(),
                    txtBoxName.Text.Trim(),
                    age,
                    txtBoxSuperpower.Text.Trim(),
                    score
                );

                int rowIndex = dgvUpdate.CurrentRow.Index;
                DataRow row = table.Rows[rowIndex];

                // Read current values from the row (null-safe)
                string curID = (row["HeroID"] ?? string.Empty).ToString();
                string curName = (row["Name"] ?? string.Empty).ToString();
                string curAgeStr = (row["Age"] ?? string.Empty).ToString();
                string curSuper = (row["Superpower"] ?? string.Empty).ToString();
                string curScoreStr = (row["ExamScore"] ?? string.Empty).ToString();
                string curRank = (row["Rank"] ?? string.Empty).ToString();
                string curThreat = (row["ThreatLevel"] ?? string.Empty).ToString();

                // Normalize and compare
                bool idSame = string.Equals(curID.Trim(), updated.HeroID.Trim(), StringComparison.OrdinalIgnoreCase);
                bool nameSame = string.Equals(NormalizeForCompare(curName), NormalizeForCompare(updated.Name), StringComparison.Ordinal);
                bool ageSame = int.TryParse(curAgeStr, out var curAge) && curAge == updated.Age;
                bool superSame = string.Equals(NormalizeForCompare(curSuper), NormalizeForCompare(updated.Superpower), StringComparison.Ordinal);
                bool scoreSame = int.TryParse(curScoreStr, out var curScore) && curScore == updated.ExamScore;
                bool rankSame = string.Equals(NormalizeForCompare(curRank), NormalizeForCompare(updated.Rank), StringComparison.Ordinal);
                bool threatSame = string.Equals(NormalizeForCompare(curThreat), NormalizeForCompare(updated.ThreatLevel), StringComparison.Ordinal);

                // If everything is identical, notify and bail out
                if (idSame && nameSame && ageSame && superSame && scoreSame && rankSame && threatSame)
                {
                    MessageBox.Show("No changes detected. Record remains the same.", "No changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Otherwise write the changes into the DataRow
                row["HeroID"] = updated.HeroID;
                row["Name"] = updated.Name;
                row["Age"] = updated.Age.ToString();
                row["Superpower"] = updated.Superpower;
                row["ExamScore"] = updated.ExamScore.ToString();
                row["Rank"] = updated.Rank;
                row["ThreatLevel"] = updated.ThreatLevel;

                // Persist to file
                WriteWholeTableToFile();

                // Refresh and re-select row
                dgvUpdate.Refresh();
                dgvUpdate.ClearSelection();
                if (rowIndex >= 0 && rowIndex < dgvUpdate.Rows.Count)
                    dgvUpdate.Rows[rowIndex].Selected = true;

                MessageBox.Show("Superhero updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating hero: " + ex.Message);
            }
        }


        private void WriteWholeTableToFile()
        {
            var lines = table.Rows
                             .Cast<DataRow>()
                             .Select(r => string.Join(",",
                                 r["HeroID"],
                                 r["Name"],
                                 r["Age"],
                                 r["Superpower"],
                                 r["ExamScore"],
                                 r["Rank"],
                                 r["ThreatLevel"]))
                             .ToArray();

            File.WriteAllLines(filePath, lines);
        }

        private void dgvUpdate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            SuperHeroHome home = new SuperHeroHome();
            home.Visible = true;
            this.Hide();
        }

        private void lblID_Click(object sender, EventArgs e)
        {

        }

        private void Update_Resize(object sender, EventArgs e)
        {
            CenterLabelAndTextBox(pnl1, lblID, txtBoxID);
            CenterLabelAndTextBox(pnl2, lblName, txtBoxName);
            CenterLabelAndTextBox(pnl3, lblAge, txtBoxAge);
            CenterLabelAndTextBox(pnl4, lblSuperPower, txtBoxSuperpower);
            CenterLabelAndTextBox(pnl5, lblScore, txtBoxScore);
        }

        private void lblHeading_Click(object sender, EventArgs e)
        {

        }
    }
}
