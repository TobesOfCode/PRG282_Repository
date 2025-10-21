using AddSuperhero;
using AddSuperhero.DataLayer;
using AddSuperhero.LogicLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SuperheroSummaryApp
{
    public partial class SuperheroSummaryForm : Form
    {
        // ===== Fields =====
        private List<Hero> heroes = new List<Hero>();
        private Random random = new Random();

        // ===== Constructor =====
        public SuperheroSummaryForm()
        {
            InitializeComponent();

            heroes = HeroLoader.LoadHeroesFromFile("superheroes.txt");

            DisplaySummary();
            ChartHelper.PopulateRankChart(chartRanks, heroes);
            ChartHelper.PopulateScoreChart(chartScores, heroes);

            this.FormClosed += SuperFormClosed;
        }

        // ===== Form Closed =====
        private void SuperFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // ===== Display Summary =====
        private void DisplaySummary()
        {
            var summary = HeroSummaryHelper.GenerateSummary(heroes, "summary.txt");
            if (summary == null) return;

            lblTotalHeroes.Text = summary.TotalHeroes.ToString();
            lblAvgAge.Text = summary.AverageAge.ToString("F2");
            lblAvgScore.Text = summary.AverageScore.ToString("F2") + "%";

            lblSCount.Text = summary.RankCounts.ContainsKey("S-Rank") ? summary.RankCounts["S-Rank"].ToString() : "0";
            lblACount.Text = summary.RankCounts.ContainsKey("A-Rank") ? summary.RankCounts["A-Rank"].ToString() : "0";
            lblBCount.Text = summary.RankCounts.ContainsKey("B-Rank") ? summary.RankCounts["B-Rank"].ToString() : "0";
            lblCCount.Text = summary.RankCounts.ContainsKey("C-Rank") ? summary.RankCounts["C-Rank"].ToString() : "0";

            lblTopHero.Text = $"{summary.TopHero.Name} ({summary.TopHero.Score}) - {summary.TopHero.Rank}";
            lblFunFact.Text = $"Fun Fact: {summary.RandomHero.Name} can {summary.RandomHero.Ability}";
            lblFunFact2.Text = $"Fun Fact: {summary.RandomHero.Name} can {summary.RandomHero.Ability}";
        }

        // ===== Fun Facts Button =====
        private void btnNewFunFact_Click_1(object sender, EventArgs e)
        {
            if (heroes.Count == 0) return;

            Hero hero = heroes[random.Next(heroes.Count)];
            var (fact1, fact2) = FunFactGenerator.GetTwoFunFacts(hero);

            lblFunFact.Text = fact1;
            lblFunFact2.Text = fact2;

            UIhelper.FitTextToPanel(lblFunFact, pnlMid3);
            UIhelper.FitTextToPanel(lblFunFact2, pnlMid3);
        }

        // ===== Form Load =====
        private void SuperheroSummaryForm_Load(object sender, EventArgs e)
        {
            UIhelper.CenterLabelInPanelHor(lblTotal, pnlTotal);
            UIhelper.CenterLabelInPanelHor(lblAverage, pnlAge);
            UIhelper.CenterLabelInPanelHor(lblTest, pnlScore);
            UIhelper.CenterLabelInPanelHor(lblS, pnlS);
            UIhelper.CenterLabelInPanelHor(lblA, pnlA);
            UIhelper.CenterLabelInPanelHor(lblB, pnlB);
            UIhelper.CenterLabelInPanelHor(lblC, pnlC);
            UIhelper.CenterLabelInPanelHor(lblTopHero, pnlMid2);
            UIhelper.CenterLabelInPanelHor(lblTop, pnlMid2);

            UIhelper.CenterLabelInPanel(lblTotalHeroes, pnlTotal);
            UIhelper.CenterLabelInPanel(lblAvgAge, pnlAge);
            UIhelper.CenterLabelInPanel(lblAvgScore, pnlScore);
            UIhelper.CenterLabelInPanel(lblSCount, pnlS);
            UIhelper.CenterLabelInPanel(lblACount, pnlA);
            UIhelper.CenterLabelInPanel(lblBCount, pnlB);
            UIhelper.CenterLabelInPanel(lblCCount, pnlC);
            UIhelper.CenterLabelInPanel(lblHeading, pnlHeading);
            UIhelper.CenterLabelInPanel(lblFunFact, pnlMid3);

            lblFunFact.Parent = pnlMid3;
            lblFunFact.Dock = DockStyle.Fill;
            lblFunFact.AutoSize = false;
            lblFunFact.TextAlign = ContentAlignment.MiddleCenter;
            lblFunFact.MaximumSize = new Size(pnlMid3.Width - 10, pnlMid3.Height);
            lblFunFact.UseCompatibleTextRendering = true;
        }

        // ===== Back Button =====
        private void btnBack_Click(object sender, EventArgs e)
        {
            SuperHeroHome home = new SuperHeroHome();
            home.Visible = true;
            this.Hide();
        }

        // ===== Save Summary to File =====
        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            string summaryText =
                "=== Superhero Academy Summary ===\n" +
                "Total Heroes: " + lblTotalHeroes.Text + "\n" +
                "Average Age: " + lblAvgAge.Text + "\n" +
                "Average Score: " + lblAvgScore.Text + "\n" +
                "S-Rank: " + lblSCount.Text + "\n" +
                "A-Rank: " + lblACount.Text + "\n" +
                "B-Rank: " + lblBCount.Text + "\n" +
                "C-Rank: " + lblCCount.Text + "\n" +
                "Top Hero: " + lblTopHero.Text + "\n" +
                "Fun Fact: " + lblFunFact.Text + "\n";

            try
            {
                SummarySave.SaveSummary(summaryText);
                MessageBox.Show("Summary saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
