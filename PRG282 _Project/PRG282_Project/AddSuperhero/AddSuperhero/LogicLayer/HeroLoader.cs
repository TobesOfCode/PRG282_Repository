using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddSuperhero.LogicLayer
{
    public static class HeroLoader
    {
        public static List<Hero> LoadHeroesFromFile(string filePath)
        {
            var heroes = new List<Hero>();

            try
            {
                if (!File.Exists(filePath))
                    throw new FileNotFoundException("The heroes file was not found.", filePath);

                foreach (var line in File.ReadAllLines(filePath))
                {
                    var data = line.Split(',');

                    if (data.Length < 7)
                        continue; // skip invalid lines

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
                MessageBox.Show("Error loading heroes: " + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return heroes;
        }
    }
}