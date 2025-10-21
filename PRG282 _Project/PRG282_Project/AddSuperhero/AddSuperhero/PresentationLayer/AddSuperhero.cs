using System;
using System.Windows.Forms;

namespace AddSuperhero
{
    public partial class AddSuperhero : Form
    {
        // ===== Constructor =====
        public AddSuperhero()
        {
            InitializeComponent();
            this.FormClosed += SuperFormClosed;
        }

        // ===== Form Closed =====
        private void SuperFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // ===== Add Button Click =====
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
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

                AddHero hero = new AddHero(txtBoxID.Text, txtBoxName.Text, age, txtBoxSuperpower.Text, score);

                string filePath = "superheroes.txt";
                hero.SaveToFile(filePath);

                MessageBox.Show($"Superhero '{hero.Name}' added successfully!\nRank: {hero.Rank}\nThreat: {hero.ThreatLevel}",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        // ===== Back Button Click =====
        private void button1_Click(object sender, EventArgs e)
        {
            SuperHeroHome home = new SuperHeroHome();
            home.Visible = true;
            this.Hide();
        }

        // ===== Form Load =====
        private void AddSuperhero_Load(object sender, EventArgs e)
        {
            UIhelper.CenterLabelAndTextBox(pnl1, lblID, txtBoxID);
            UIhelper.CenterLabelAndTextBox(pnl2, lblName, txtBoxName);
            UIhelper.CenterLabelAndTextBox(pnl3, lblAge, txtBoxAge);
            UIhelper.CenterLabelAndTextBox(pnl4, lblSuper, txtBoxSuperpower);
            UIhelper.CenterLabelAndTextBox(pnl4, lblScore, txtBoxScore);
            UIhelper.CenterLabelInPanel(lblHeading, pnlHeader);
            UIhelper.CenterThreeButtons(btnBack, btnAdd, btnClear, pnlFooter);
        }

        // ===== Resize Event =====
        private void AddSuperhero_Resize(object sender, EventArgs e)
        {
            UIhelper.CenterLabelAndTextBox(pnl1, lblID, txtBoxID);
            UIhelper.CenterLabelAndTextBox(pnl2, lblName, txtBoxName);
            UIhelper.CenterLabelAndTextBox(pnl3, lblAge, txtBoxAge);
            UIhelper.CenterLabelAndTextBox(pnl4, lblSuper, txtBoxSuperpower);
            UIhelper.CenterLabelAndTextBox(pnl4, lblScore, txtBoxScore);
            UIhelper.CenterLabelInPanel(lblHeading, pnlHeader);
            UIhelper.CenterThreeButtons(btnBack, btnAdd, btnClear, pnlFooter);
        }

        // ===== Other Events =====
        private void label7_Click(object sender, EventArgs e) { }
        private void txtBoxName_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void lblHeading_Click(object sender, EventArgs e) { }
    }
}
