using AddSuperhero.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AddSuperhero.LogicLayer
{
    // ===== Hero Logic Layer: Handles DataTable conversion, search, update, and save =====
    public static class HeroLogic
    {
        // ===== Convert List<AddHero> to DataTable =====
        public static DataTable ConvertHeroesToDataTable(List<AddHero> heroes)
        {
            var table = new DataTable("Superheroes");
            table.Columns.Add("HeroID");
            table.Columns.Add("Name");
            table.Columns.Add("Age");
            table.Columns.Add("Superpower");
            table.Columns.Add("ExamScore");
            table.Columns.Add("Rank");
            table.Columns.Add("ThreatLevel");

            foreach (var hero in heroes)
            {
                table.Rows.Add(hero.HeroID, hero.Name, hero.Age, hero.Superpower,
                               hero.ExamScore, hero.Rank, hero.ThreatLevel);
            }

            return table;
        }

        // ===== Normalize Strings for Comparisons =====
        private static string Normalize(string s) => (s ?? string.Empty).Trim().ToUpperInvariant();

        // ===== Find a Hero by ID or Name (Exact and Partial Match) =====
        public static AddHero FindHero(List<AddHero> heroes, string idInput, string nameInput)
        {
            if (heroes == null || heroes.Count == 0)
                return null;

            string idTrim = idInput?.Trim() ?? string.Empty;
            string nameTrim = nameInput?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(idTrim) && string.IsNullOrWhiteSpace(nameTrim))
                return null;

            // 1) Exact ID match
            if (!string.IsNullOrWhiteSpace(idTrim))
            {
                var byId = heroes.FirstOrDefault(h => Normalize(h.HeroID) == Normalize(idTrim));
                if (byId != null) return byId;
            }

            // Use name input if available, otherwise ID input
            string nameSearch = !string.IsNullOrWhiteSpace(nameTrim) ? nameTrim : idTrim;
            string normalizedSearch = Normalize(nameSearch);

            // 2) Exact name match
            var exactName = heroes.FirstOrDefault(h => Normalize(h.Name) == normalizedSearch);
            if (exactName != null) return exactName;

            // 3) Partial (contains) match
            var partialName = heroes.FirstOrDefault(h => Normalize(h.Name).Contains(normalizedSearch));
            return partialName;
        }

        // ===== Update DataRow with Hero Properties =====
        public static void UpdateHero(AddHero hero, DataRow row)
        {
            row["HeroID"] = hero.HeroID;
            row["Name"] = hero.Name;
            row["Age"] = hero.Age.ToString();
            row["Superpower"] = hero.Superpower;
            row["ExamScore"] = hero.ExamScore.ToString();
            row["Rank"] = hero.Rank;
            row["ThreatLevel"] = hero.ThreatLevel;
        }

        // ===== Check if DataRow Differs from Hero Object =====
        public static bool HasChanges(AddHero hero, DataRow row)
        {
            bool idSame = string.Equals(row["HeroID"]?.ToString().Trim(), hero.HeroID.Trim(), StringComparison.OrdinalIgnoreCase);
            bool nameSame = string.Equals(row["Name"]?.ToString().Trim(), hero.Name.Trim(), StringComparison.OrdinalIgnoreCase);
            bool ageSame = int.TryParse(row["Age"]?.ToString(), out var curAge) && curAge == hero.Age;
            bool superSame = string.Equals(row["Superpower"]?.ToString().Trim(), hero.Superpower.Trim(), StringComparison.OrdinalIgnoreCase);
            bool scoreSame = int.TryParse(row["ExamScore"]?.ToString(), out var curScore) && curScore == hero.ExamScore;
            bool rankSame = string.Equals(row["Rank"]?.ToString().Trim(), hero.Rank.Trim(), StringComparison.OrdinalIgnoreCase);
            bool threatSame = string.Equals(row["ThreatLevel"]?.ToString().Trim(), hero.ThreatLevel.Trim(), StringComparison.OrdinalIgnoreCase);

            return !(idSame && nameSame && ageSame && superSame && scoreSame && rankSame && threatSame);
        }

        // ===== Save All Heroes to File =====
        public static void SaveAllHeroes(List<AddHero> heroes, string filePath)
        {
            var handler = new HeroDataHandler(filePath);
            handler.SaveHeroes(heroes);
        }
    }
}
