using System.Text.RegularExpressions;

namespace Day3;

public class Puzzle1Solver
{
    public static void Solve(string[] lines)
    {
        var result = 0;
        foreach (var line in lines)
        {
            // Find all matches
            var matches = Regex.Matches(line, @"mul\(\d+,\d+\)");
            foreach (Match match in matches)
            {
                var values = Regex.Matches(match.Value, @"\d+");
                var mulResult = values.Select(x => int.Parse(x.Value)).Aggregate((total, value) => total * value);
                result += mulResult;
            }
        }
        
        Console.WriteLine(result);
    }
}