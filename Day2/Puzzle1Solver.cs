namespace Day2;

public class Puzzle1Solver
{
    public static void Solve(string[] lines)
    {
        var counter = 0;
        foreach (var line in lines)
        {
            var numbers = line.Split(' ').Select(int.Parse).ToArray();
            var valid = true;
            var increasing = numbers[0] < numbers[1];
            for (var i = 0; i < numbers.Length - 1; i++)
            {
                var delta = numbers[i] - numbers[i + 1];
                if (Math.Abs(delta) is > 0 and <= 3)
                {
                    if ((increasing && delta < 0) || (!increasing && delta > 0))
                    {
                        continue;
                    }
                }

                valid = false;
                break;
            }

            if (valid)
            {
                counter++;
            }
        }

        Console.WriteLine(counter);
    }
}