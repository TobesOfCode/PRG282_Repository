using AddSuperhero;
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
        // Class to hold hero data
        public class Hero
        {
            public int ID;
            public string Name;
            public int Age;
            public string Ability;
            public int Score;
            public string Rank;
            public string ThreatLevel;
        }

        private List<Hero> heroes = new List<Hero>();
        private Random random = new Random();

        public SuperheroSummaryForm()
        {
            InitializeComponent();
            LoadHeroes();
            DisplaySummary();
            DisplayRankChart();
            DisplayScoreChart();
            this.FormClosed += SuperFormClosed;
        }

        private void SuperFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        // Dynamically adjusts label font size so text fits panel

        private void FitTextToPanel(Label label, Panel panel)
        {
            if (string.IsNullOrEmpty(label.Text))
                return;

            label.AutoSize = false;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Dock = DockStyle.Fill;

            int maxWidth = panel.ClientSize.Width - 10;
            int maxHeight = panel.ClientSize.Height - 10;

            float fontSize = 20f;
            Font testFont = new Font(label.Font.FontFamily, fontSize, label.Font.Style);

            Size textSize = TextRenderer.MeasureText(label.Text, testFont, new Size(maxWidth, int.MaxValue),
                TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);

            while ((textSize.Width > maxWidth || textSize.Height > maxHeight) && fontSize > 6f)
            {
                fontSize -= 0.5f;
                testFont = new Font(label.Font.FontFamily, fontSize, label.Font.Style);
                textSize = TextRenderer.MeasureText(label.Text, testFont, new Size(maxWidth, int.MaxValue),
                    TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);
            }

            label.Font = testFont;
        }

        // Load hero data from file
        private void LoadHeroes()
        {
            try
            {
                foreach (var line in File.ReadAllLines("superheroes.txt"))
                {
                    var data = line.Split(',');
                    heroes.Add(new Hero
                    {
                        ID = int.Parse(data[0]),
                        Name = data[1],
                        Age = int.Parse(data[2]),
                        Ability = data[3],
                        Score = int.Parse(data[4]),
                        Rank = data[5],
                        ThreatLevel = data[6]
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading heroes: " + ex.Message);
            }
        }

        // Display summary statistics
        private void DisplaySummary()
        {
            if (heroes.Count == 0) return;

            int totalHeroes = heroes.Count;
            double avgAge = heroes.Average(h => h.Age);
            double avgScore = heroes.Average(h => h.Score);

            var rankCounts = heroes.GroupBy(h => h.Rank)
                                   .ToDictionary(g => g.Key, g => g.Count());

            Hero topHero = heroes.OrderByDescending(h => h.Score).First();
            Hero randomHero = heroes[random.Next(heroes.Count)];

            // Update labels
            lblTotalHeroes.Text = totalHeroes.ToString();
            lblAvgAge.Text = avgAge.ToString("F2");
            lblAvgScore.Text = avgScore.ToString("F2")+"%";
            lblSCount.Text = rankCounts.ContainsKey("S-Rank") ? rankCounts["S-Rank"].ToString() : "0";
            lblACount.Text = rankCounts.ContainsKey("A-Rank") ? rankCounts["A-Rank"].ToString() : "0";
            lblBCount.Text = rankCounts.ContainsKey("B-Rank") ? rankCounts["B-Rank"].ToString() : "0";
            lblCCount.Text = rankCounts.ContainsKey("C-Rank") ? rankCounts["C-Rank"].ToString() : "0";
            lblTopHero.Text = topHero.Name + " (" + topHero.Score + ") - " + topHero.Rank;
            lblFunFact.Text = randomHero.Name + " can " + randomHero.Ability;
            lblFunFact2.Text = randomHero.Name + " can " + randomHero.Ability;

            // Save summary to file
            File.WriteAllText("summary.txt",
                "=== Superhero Academy Summary ===\n" +
                "Total Heroes: " + totalHeroes + "\n" +
                "Average Age: " + avgAge.ToString("F2") + "\n" +
                "Average Score: " + avgScore.ToString("F2") + "\n" +
                "S-Rank: " + lblSCount.Text + "\n" +
                "A-Rank: " + lblACount.Text + "\n" +
                "B-Rank: " + lblBCount.Text + "\n" +
                "C-Rank: " + lblCCount.Text + "\n" +
                "Top Hero: " + lblTopHero.Text + "\n" +
                "Fun Fact: " + lblFunFact.Text + "\n");
        }

        // Display pie chart for rank distribution
        private void DisplayRankChart()
        {
            chartRanks.Series.Clear();
            Series series = new Series("Ranks");
            series.ChartType = SeriesChartType.Pie;

            var rankCounts = heroes.GroupBy(h => h.Rank)
                                   .ToDictionary(g => g.Key, g => g.Count());

            foreach (var kvp in rankCounts)
            {
                int pointIndex = series.Points.AddXY(kvp.Key, kvp.Value);
                DataPoint point = series.Points[pointIndex];
                point.Label = kvp.Key + ": " + kvp.Value;

                if (kvp.Key == "S-Rank")
                    point.Color = Color.Gold;
                else if (kvp.Key == "A-Rank")
                    point.Color = Color.Silver;
                else if (kvp.Key == "B-Rank")
                    point.Color = Color.Peru;
                else if (kvp.Key == "C-Rank")
                    point.Color = Color.Gray;
                else
                    point.Color = Color.LightGray;
            }

            chartRanks.Series.Add(series);
            chartRanks.Legends[0].Docking = Docking.Right;
        }

        // Display bar chart for individual scores
        private void DisplayScoreChart()
        {
            // Clear previous data
            chartScores.Series.Clear();
            chartScores.ChartAreas.Clear();
            chartScores.Legends.Clear();

            // Create chart area
            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.AxisX.Title = "Rank";
            chartArea.AxisY.Title = "Average Score";
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = 100;
            chartScores.ChartAreas.Add(chartArea);

            // Create legend
            Legend legend = new Legend("MainLegend");
            legend.Docking = Docking.Bottom;
            chartScores.Legends.Add(legend);

            // Create bar series
            Series series = new Series("AvgScoreByRank");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series["PointWidth"] = "0.6";

            // Compute average score per rank
            var rankGroups = heroes.GroupBy(h => h.Rank)
                                   .Select(g => new { Rank = g.Key, AvgScore = g.Average(h => h.Score) })
                                   .OrderByDescending(g => g.AvgScore); // optional: sort by score

            foreach (var group in rankGroups)
            {
                int index = series.Points.AddXY(group.Rank, group.AvgScore);
                DataPoint point = series.Points[index];

                // Color bars by rank
                if (group.Rank == "S-Rank")
                    point.Color = Color.Gold;
                else if (group.Rank == "A-Rank")
                    point.Color = Color.Silver;
                else if (group.Rank == "B-Rank")
                    point.Color = Color.Peru;
                else if (group.Rank == "C-Rank")
                    point.Color = Color.Gray;
                else
                    point.Color = Color.LightGray;

                point.Label = group.AvgScore.ToString("F1"); // show average score
                point.ToolTip = group.Rank + " - Average Score: " + group.AvgScore.ToString("F1");
            }

            // Add series and refresh chart
            chartScores.Series.Add(series);
            chartScores.Invalidate();
        }



        // Fun facts button
        private void btnNewFunFact_Click_1(object sender, EventArgs e)
        {
            if (heroes.Count == 0) return;

            Hero hero = heroes[random.Next(heroes.Count)];

            List<string> funFacts = new List<string>
            {
                hero.Name + " can " + hero.Ability + " like a true academy legend!",
                hero.Name + " is only " + hero.Age + " years old but already ranks as an " + hero.Rank + " hero!",
                hero.Name + "'s threat level during " + hero.ThreatLevel + " makes even teachers nervous!",
                hero.Name + " scored " + hero.Score + " points in training — a top " + hero.Rank + " achievement!",
                "Did you know? " + hero.Name + "'s " + hero.Ability + " is the talk of the academy!",
                hero.Name + " balances courage and skill to handle " + hero.ThreatLevel + " threats.",
                hero.Name + " once stopped a calamity using only their ability to " + hero.Ability + "!",
                "Rumor has it, " + hero.Name + " trained for " + (hero.Age * 2) + " hours daily to reach " + hero.Rank + " status!",
                hero.Name + "'s " + hero.Ability + " helped them dominate the scoreboards with " + hero.Score + " points!",
                "At just " + hero.Age + ", " + hero.Name + " has already impressed veteran heroes!",
                "Even villains fear " + hero.Name + "'s " + hero.Ability + " — a true " + hero.Rank + " powerhouse!",
                hero.Name + " was voted 'Most Inspiring Hero' by the academy for their " + hero.Ability + ".",
                hero.Name + "'s " + hero.Ability + " once neutralized a " + hero.ThreatLevel + " situation in record time!",
                "When " + hero.Name + " enters the field, even " + hero.ThreatLevel + " threats hesitate!",
                hero.Name + "'s heroic record: " + hero.Score + " points, " + hero.Rank + " rank, and unstoppable courage.",
                "Academy experts say " + hero.Name + "'s " + hero.Ability + " could change hero training forever!",
                "Despite being " + hero.Age + ", " + hero.Name + " continues to outperform older heroes effortlessly!",
                hero.Name + " proves age doesn’t matter — their " + hero.Score + " score speaks for itself!"
            };


            // Pick two different fun facts
            int firstIndex = random.Next(funFacts.Count);
            int secondIndex;
            do
            {
                secondIndex = random.Next(funFacts.Count);
            } while (secondIndex == firstIndex);

            lblFunFact.Text = funFacts[firstIndex];
            lblFunFact2.Text = funFacts[secondIndex];

            // Optional: fit text to panel for both
            FitTextToPanel(lblFunFact, pnlMid3);
            FitTextToPanel(lblFunFact2, pnlMid3);
        }

        private void SuperheroSummaryForm_Load(object sender, EventArgs e)
        {
            // Center header labels
            UIhelper.CenterLabelInPanelHor(lblTotal, pnlTotal);
            UIhelper.CenterLabelInPanelHor(lblAverage, pnlAge);
            UIhelper.CenterLabelInPanelHor(lblTest, pnlScore);
            UIhelper.CenterLabelInPanelHor(lblS, pnlS);
            UIhelper.CenterLabelInPanelHor(lblA, pnlA);
            UIhelper.CenterLabelInPanelHor(lblB, pnlB);
            UIhelper.CenterLabelInPanelHor(lblC, pnlC);
            UIhelper.CenterLabelInPanelHor(lblTopHero, pnlMid2);
            UIhelper.CenterLabelInPanelHor(lblTop, pnlMid2);

            // Center data labels
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            SuperHeroHome home = new SuperHeroHome();
            home.Visible = true;
            this.Hide();
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            try
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

                File.WriteAllText("summary.txt", summaryText);
                MessageBox.Show("Summary saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving summary: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblTopHero_Click(object sender, EventArgs e)
        {
        }

        private void lblAvgScore_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalHeroes_Click(object sender, EventArgs e)
        {

        }
    }
}
