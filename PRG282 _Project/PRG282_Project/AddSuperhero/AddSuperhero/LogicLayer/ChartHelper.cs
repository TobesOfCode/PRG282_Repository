using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace AddSuperhero.LogicLayer
{
    public static class ChartHelper
    {
        public static void PopulateScoreChart(Chart chartScores, List<Hero> heroes)
        {
            if (chartScores == null || heroes == null || heroes.Count == 0)
                return;

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
                                   .OrderByDescending(g => g.AvgScore);

            foreach (var group in rankGroups)
            {
                int index = series.Points.AddXY(group.Rank, group.AvgScore);
                DataPoint point = series.Points[index];

                // Color bars by rank (classic switch)
                switch (group.Rank)
                {
                    case "S-Rank":
                        point.Color = Color.Gold;
                        break;
                    case "A-Rank":
                        point.Color = Color.Silver;
                        break;
                    case "B-Rank":
                        point.Color = Color.Peru;
                        break;
                    case "C-Rank":
                        point.Color = Color.Gray;
                        break;
                    default:
                        point.Color = Color.LightGray;
                        break;
                }

                point.Label = group.AvgScore.ToString("F1"); // show average score
                point.ToolTip = group.Rank + " - Average Score: " + group.AvgScore.ToString("F1");
            }

            chartScores.Series.Add(series);
            chartScores.Invalidate();
        }

        public static void PopulateRankChart(Chart chartRanks, List<Hero> heroes)
        {
            if (chartRanks == null || heroes == null || heroes.Count == 0)
                return;

            chartRanks.Series.Clear();

            Series series = new Series("Ranks");
            series.ChartType = SeriesChartType.Pie;

            // Group heroes by rank and count them
            var rankCounts = heroes.GroupBy(h => h.Rank)
                                   .ToDictionary(g => g.Key, g => g.Count());

            foreach (var kvp in rankCounts)
            {
                int pointIndex = series.Points.AddXY(kvp.Key, kvp.Value);
                DataPoint point = series.Points[pointIndex];
                point.Label = kvp.Key + ": " + kvp.Value;

                // Color the slices by rank
                switch (kvp.Key)
                {
                    case "S-Rank":
                        point.Color = Color.Gold;
                        break;
                    case "A-Rank":
                        point.Color = Color.Silver;
                        break;
                    case "B-Rank":
                        point.Color = Color.Peru;
                        break;
                    case "C-Rank":
                        point.Color = Color.Gray;
                        break;
                    default:
                        point.Color = Color.LightGray;
                        break;
                }
            }

            chartRanks.Series.Add(series);

            if (chartRanks.Legends.Count > 0)
                chartRanks.Legends[0].Docking = Docking.Right;

            chartRanks.Invalidate();
        }
    }
}