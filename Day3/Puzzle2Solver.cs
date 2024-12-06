using System.Text;

namespace Day3;

public class Puzzle2Solver
{
    public static void Solve(string[] lines)
    {
        const string doText = "do()";
        const string dontText = "don't()";

        var enabled = true;
        var textToEvaluate = new StringBuilder();
        foreach (var line in lines)
        {
            for (var i = 0; i < line.Length; i++)
            {
                if (enabled)
                {
                    if (i + dontText.Length < line.Length && line.Substring(i, dontText.Length) == dontText)
                    {
                        enabled = false;
                        i += dontText.Length;
                        continue;
                    }

                    textToEvaluate.Append(line[i]);
                }
                else
                {
                    if (i + doText.Length >= line.Length || line.Substring(i, doText.Length) != doText) continue;
                    enabled = true;
                    i += doText.Length;
                }
            }
        }

        Puzzle1Solver.Solve([textToEvaluate.ToString()]);
    }
}