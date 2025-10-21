using System;
using System.IO;

namespace AddSuperhero
{
    public class AddHero   // <-- make this public
    {
        public string HeroID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Superpower { get; set; }
        public int ExamScore { get; set; }
        public string Rank { get; private set; }
        public string ThreatLevel { get; private set; }

        public AddHero(string heroID, string name, int age, string superpower, int examScore)
        {
            HeroID = heroID;
            Name = name;
            Age = age;
            Superpower = superpower;
            ExamScore = examScore;
            DetermineRankAndThreat();
        }

        private void DetermineRankAndThreat()
        {
            if (ExamScore >= 81 && ExamScore <= 100)
            {
                Rank = "S-Rank";
                ThreatLevel = "Finals Week (threat to the entire academy)";
            }
            else if (ExamScore >= 61)
            {
                Rank = "A-Rank";
                ThreatLevel = "Midterm Madness (threat to a department)";
            }
            else if (ExamScore >= 41)
            {
                Rank = "B-Rank";
                ThreatLevel = "Group Project Gone Wrong (threat to a study group)";
            }
            else
            {
                Rank = "C-Rank";
                ThreatLevel = "Pop Quiz (potential threat to an individual student)";
            }
        }

        public void SaveToFile(string filePath)
        {
            try
            {
                string record = $"{HeroID},{Name},{Age},{Superpower},{ExamScore},{Rank},{ThreatLevel}";
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine(record);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving superhero: {ex.Message}");
            }
        }
    }
}
