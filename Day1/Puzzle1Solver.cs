namespace Day1;

public static class Puzzle1Solver
{
    public static void Solve(string[] lines)
    {
        var leftValues = new List<int>();
        var rightValues = new List<int>();

        foreach (var line in lines)
        {
            leftValues.Add(int.Parse(line.Split("   ")[0]));
            rightValues.Add(int.Parse(line.Split("   ")[1]));
        }
        
        leftValues.Sort();
        rightValues.Sort();

        var total = 0;
        for (int i = 0; i < leftValues.Count; i++)
        {
            total += Math.Abs(leftValues[i] - rightValues[i]);
        }
        
        Console.WriteLine(total);
    }
}