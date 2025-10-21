using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddSuperhero.LogicLayer
{
    // ===== Hero Class: Represents a superhero with all core attributes =====
    public class Hero
    {
        // ===== Unique identifier for the hero =====
        public int ID { get; set; }

        // ===== Hero's name =====
        public string Name { get; set; }

        // ===== Hero's age =====
        public int Age { get; set; }

        // ===== Hero's special ability/power =====
        public string Ability { get; set; }

        // ===== Hero's score (exam/test score or rating) =====
        public int Score { get; set; }

        // ===== Hero's rank (S, A, B, C, etc.) =====
        public string Rank { get; set; }

        // ===== Threat level associated with the hero =====
        public string ThreatLevel { get; set; }
    }
}
