using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AddSuperhero.DataLayer
{
    // ===== SummarySave Class: Handles saving superhero summaries to a file =====
    public static class SummarySave
    {
        // ===== Method: Save summary text to a file =====
        // Parameters:
        //   summaryText - the text to save
        //   filePath - optional, defaults to "summary.txt"
        public static void SaveSummary(string summaryText, string filePath = "summary.txt")
        {
            try
            {
                File.WriteAllText(filePath, summaryText);
            }
            catch (Exception ex)
            {
                // ===== Throw exception so UI or calling code can handle it =====
                throw new Exception("Error saving summary: " + ex.Message);
            }
        }
    }
}
