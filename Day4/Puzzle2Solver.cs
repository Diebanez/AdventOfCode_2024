using System.Text;

namespace Day4;

public class Puzzle2Solver
{
    public static void Solve(string[] lines)
    {
        var debugMatrix = new char[lines[0].Length, lines.Length];
        for (var y = 0; y < debugMatrix.GetLength(1); y++)
        {
            for (var x = 0; x < debugMatrix.GetLength(0); x++)
            {
                debugMatrix[x, y] = '.';
            }
        }

        var matrix = new char[lines[0].Length, lines.Length];
        for (var y = 0; y < lines.Length; y++)
        {
            for (var x = 0; x < lines.Length; x++)
            {
                matrix[x, y] = lines[y][x];
            }
        }

        var result = 0;

        const string word = "MAS";
        const string reversedWord = "SAM";

        for (var squareStartY = 0; squareStartY <= matrix.GetLength(1) - word.Length; squareStartY++)
        {
            for (var squareStartX = 0; squareStartX <= matrix.GetLength(0) - word.Length; squareStartX++)
            {
                var firstWord = new StringBuilder();
                for (var character = 0; character < word.Length; character++)
                {
                    firstWord.Append(matrix[squareStartX + character, squareStartY + character]);
                }

                if (firstWord.ToString() != reversedWord && firstWord.ToString() != word)
                {
                    continue;
                }

                var secondWord = new StringBuilder();
                for (var character = 0; character < word.Length; character++)
                {
                    secondWord.Append(matrix[squareStartX + word.Length - 1 - character, squareStartY + character]);
                }

                if (secondWord.ToString() != reversedWord && secondWord.ToString() != word)
                {
                    continue;
                }

                result++;
                for (var character = 0; character < word.Length; character++)
                {
                    debugMatrix[squareStartX + character, squareStartY + character] =
                        matrix[squareStartX + character, squareStartY + character];
                }

                for (var character = 0; character < word.Length; character++)
                {
                    debugMatrix[squareStartX + word.Length - 1 - character, squareStartY + character] =
                        matrix[squareStartX + word.Length - 1 - character, squareStartY + character];
                }
            }
        }

        Console.WriteLine(result);

        for (var y = 0; y < debugMatrix.GetLength(1); y++)
        {
            for (var x = 0; x < debugMatrix.GetLength(0); x++)
            {
                Console.Write(debugMatrix[x, y]);
            }

            Console.Write("\n");
        }
    }
}