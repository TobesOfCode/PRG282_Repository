using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddSuperhero.LogicLayer
{
    public static class FunFactGenerator
    {
        private static Random random = new Random();

        public static (string, string) GetTwoFunFacts(Hero hero)
        {
            if (hero == null) throw new ArgumentNullException(nameof(hero));

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

            int firstIndex = random.Next(funFacts.Count);
            int secondIndex;
            do
            {
                secondIndex = random.Next(funFacts.Count);
            } while (secondIndex == firstIndex);

            return (funFacts[firstIndex], funFacts[secondIndex]);
        }
    }
}