using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

namespace Footbal_Data
{
    public class FileOperations
    {
        public List<Match> Reader(string path)
        {
            return ConvertToList(ReadFile(path));
        }
        private string[] ReadFile(string path)
        {
            var FileReader = File.ReadAllLines(path);
            return FileReader;
        }
        private List<Match> ConvertToList(string[] FileAsList)
        {
            List<Match> Match = new List<Match>();
            for (int i = 1; i < FileAsList.Length; i++)
            {
                var match = createMatch(FileAsList[i]);
                if (match != null)
                {
                    Match.Add(match);
                }
            }
            return Match;
        }
        private Match? createMatch(string line)
        {
            var splitLine = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
            var match = new Match();

            match.Date = DateTime.ParseExact(splitLine[0], "yyyy-MM-dd", null);
            match.HomeTeam = splitLine[1];
            match.AwayTeam = splitLine[2];
            if (!(int.TryParse(splitLine[3], out var score1) & int.TryParse(splitLine[4], out var score2)))
            {
                return null;
            }
            match.HomeScore = score1;
            match.AwayScore = score2;
            match.Tournament = splitLine[5];
            match.City = splitLine[6];
            match.Country = splitLine[7];
            match.Neutral = splitLine[8] == "False" ? false : true;

            return match;
        }
    }
}
