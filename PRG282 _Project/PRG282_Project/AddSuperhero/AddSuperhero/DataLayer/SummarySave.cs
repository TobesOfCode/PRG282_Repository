using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AddSuperhero.DataLayer
{
    public static class SummarySave
    {
        public static void SaveSummary(string summaryText, string filePath = "summary.txt")
        {
            try
            {
                File.WriteAllText(filePath, summaryText);
            }
            catch (Exception ex)
            {
                // Throw exception so calling code can handle it (UI, logging, etc.)
                throw new Exception("Error saving summary: " + ex.Message);
            }
        }
    }
}
