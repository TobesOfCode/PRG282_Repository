using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AddSuperhero.DataLayer
{
    public class HeroDataHandler
    {
        private readonly string _filePath;

        public HeroDataHandler(string filePath)
        {
            _filePath = filePath;
        }

        public List<AddHero> GetAllHeroes()
        {
            var heroes = new List<AddHero>();
            if (!File.Exists(_filePath)) return heroes;

            foreach (var line in File.ReadAllLines(_filePath))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var f = line.Split(',');
                if (f.Length < 5) continue;

                int age = int.TryParse(f[2], out var a) ? a : 0;
                int score = int.TryParse(f[4], out var s) ? s : 0;

                heroes.Add(new AddHero(f[0], f[1], age, f[3], score));
            }
            return heroes;
        }

        public void SaveHero(AddHero hero)
        {
            hero.SaveToFile(_filePath);
        }
        public void SaveHeroes(List<AddHero> heroes)
        {
            var lines = new List<string>();
            foreach (var hero in heroes)
            {
                lines.Add($"{hero.HeroID},{hero.Name},{hero.Age},{hero.Superpower},{hero.ExamScore},{hero.Rank},{hero.ThreatLevel}");
            }

            File.WriteAllLines(_filePath, lines);
        }
    }
}