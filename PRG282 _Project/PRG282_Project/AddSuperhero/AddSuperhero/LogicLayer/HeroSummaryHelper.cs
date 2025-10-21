using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AddSuperhero.LogicLayer
{
    // ===== Helper class for generating superhero summary statistics =====
    public static class HeroSummaryHelper
    {
        // ===== Hero Summary Data Structure =====
        public class HeroSummary
        {
            public int TotalHeroes { get; set; }
            public double AverageAge { get; set; }
            public double AverageScore { get; set; }
            public Dictionary<string, int> RankCounts { get; set; }
            public Hero TopHero { get; set; }
            public Hero RandomHero { get; set; }
            public string SummaryText { get; set; }
        }

        // ===== Generate Summary Statistics for a List of Heroes =====
        public static HeroSummary GenerateSummary(List<Hero> heroes, string outputFilePath = null)
        {
            if (heroes == null || heroes.Count == 0)
                return null;

            var random = new Random();

            // ===== Basic Stats =====
            var totalHeroes = heroes.Count;
            var avgAge = heroes.Average(h => h.Age);
            var avgScore = heroes.Average(h => h.Score);

            // ===== Rank Counts =====
            var rankCounts = heroes.GroupBy(h => h.Rank)
                                   .ToDictionary(g => g.Key, g => g.Count());

            // ===== Top and Random Heroes =====
            var topHero = heroes.OrderByDescending(h => h.Score).First();
            var randomHero = heroes[random.Next(heroes.Count)];

            // ===== Build Summary Text =====
            var summaryText =
                "=== Superhero Academy Summary ===\n" +
                $"Total Heroes: {totalHeroes}\n" +
                $"Average Age: {avgAge:F2}\n" +
                $"Average Score: {avgScore:F2}\n" +
                $"S-Rank: {(rankCounts.ContainsKey("S-Rank") ? rankCounts["S-Rank"] : 0)}\n" +
                $"A-Rank: {(rankCounts.ContainsKey("A-Rank") ? rankCounts["A-Rank"] : 0)}\n" +
                $"B-Rank: {(rankCounts.ContainsKey("B-Rank") ? rankCounts["B-Rank"] : 0)}\n" +
                $"C-Rank: {(rankCounts.ContainsKey("C-Rank") ? rankCounts["C-Rank"] : 0)}\n" +
                $"Top Hero: {topHero.Name} ({topHero.Score}) - {topHero.Rank}\n" +
                $"Fun Fact: {randomHero.Name} can {randomHero.Ability}\n";

            // ===== Save to File if Path Provided =====
            if (!string.IsNullOrEmpty(outputFilePath))
            {
                try
                {
                    File.WriteAllText(outputFilePath, summaryText);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error saving summary: " + ex.Message);
                }
            }

            // ===== Return HeroSummary Object =====
            return new HeroSummary
            {
                TotalHeroes = totalHeroes,
                AverageAge = avgAge,
                AverageScore = avgScore,
                RankCounts = rankCounts,
                TopHero = topHero,
                RandomHero = randomHero,
                SummaryText = summaryText
            };
        }
    }
}
