namespace Day1;

public static class Puzzle2Solver
{
    public static void Solve(string[] lines)
    {
        var leftValues = new List<int>();
        var rightCount = new Dictionary<int, int>();

        foreach (var line in lines)
        {
            leftValues.Add(int.Parse(line.Split("   ")[0]));
            var rightValue = int.Parse(line.Split("   ")[1]);
            if (!rightCount.ContainsKey(rightValue))
            {
                rightCount.Add(rightValue, 0);
            }
            rightCount[rightValue]++;
        }
        

        var total = 0;
        foreach (var value in leftValues)
        {
            var multiplier = rightCount.GetValueOrDefault(value, 0);
            total += value * multiplier;
        }
        
        Console.WriteLine(total);
    }
}