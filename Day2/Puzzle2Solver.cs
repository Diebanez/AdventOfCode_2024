namespace Day2;

public class Puzzle2Solver
{
    public static void Solve(string[] lines)
    {
        var counter = 0;
        foreach (var line in lines)
        {
            var numbers = line.Split(' ').Select(int.Parse).ToArray();
            if (IsValid(numbers))
            {
                counter++;
                continue;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                var alternative = numbers.ToList();
                alternative.RemoveAt(i);
                if (IsValid(alternative.ToArray()))
                {
                    counter++;
                    break;
                }
            }
        }

        Console.WriteLine(counter);
    }

    private static bool IsValid(int[] numbers)
    {
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

        return valid;
    }
}