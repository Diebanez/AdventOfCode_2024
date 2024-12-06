using System.Text;

namespace Day4;

public class Puzzle1Solver
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
        result += CountHorizontal(matrix, ref debugMatrix);
        result += CountVertical(matrix, ref debugMatrix);
        result += CountDiagonal(matrix, ref debugMatrix);
        
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

    private static int CountHorizontal(char[,] matrix, ref char[,] debugMatrix)
    {
        const string word = "XMAS";
        const string reverseWord = "SAMX";
        
        var result = 0;
        
        for (var row = 0; row < matrix.GetLength(1); row++)
        {
            for (var startCharacter = 0; startCharacter < matrix.GetLength(0) - word.Length + 1; startCharacter++)
            {
                var stringToCheck = new StringBuilder();
                for (var i = 0; i < word.Length; i++)
                {
                    stringToCheck.Append(matrix[startCharacter + i, row]);
                }

                if (stringToCheck.ToString() == reverseWord || stringToCheck.ToString() == word)
                {
                    result++;
                    for (var i = 0; i < word.Length; i++)
                    {
                        debugMatrix[startCharacter + i, row] = matrix[startCharacter + i, row];
                    }
                }
            }
        }
        
        return result;
    }
    
    private static int CountVertical(char[,] matrix, ref char[,] debugMatrix)
    {
        const string word = "XMAS";
        const string reverseWord = "SAMX";
        
        var result = 0;
        
        for (var column = 0; column < matrix.GetLength(0); column++)
        {
            for (var startCharacter = 0; startCharacter < matrix.GetLength(1) - word.Length + 1; startCharacter++)
            {
                var stringToCheck = new StringBuilder();
                for (var i = 0; i < word.Length; i++)
                {
                    stringToCheck.Append(matrix[column, startCharacter + i]);
                }

                if (stringToCheck.ToString() == reverseWord || stringToCheck.ToString() == word)
                {
                    result++;
                    for (var i = 0; i < word.Length; i++)
                    {
                        debugMatrix[column, startCharacter + i] = matrix[column, startCharacter + i];
                    }
                }
            }
        }
        
        return result;
    }

    private static int CountDiagonal(char[,] matrix, ref char[,] debugMatrix)
    {
        const string word = "XMAS";
        const string reverseWord = "SAMX";
        
        var result = 0;
        
        for (var row = 0; row < matrix.GetLength(1) - word.Length + 1; row++)
        {
            for (var startCharacter = 0; startCharacter < matrix.GetLength(0) - word.Length + 1; startCharacter++)
            {
                var stringToCheck = new StringBuilder();
                for (var i = 0; i < word.Length; i++)
                {
                    stringToCheck.Append(matrix[startCharacter + i, row + i]);
                }

                if (stringToCheck.ToString() == reverseWord || stringToCheck.ToString() == word)
                {
                    result++;
                    for (var i = 0; i < word.Length; i++)
                    {
                        debugMatrix[startCharacter + i, row + i] = matrix[startCharacter + i, row + i];
                    }
                }
            }
        }
        
        for (var row = 0; row < matrix.GetLength(1) - word.Length + 1; row++)
        {
            for (var startCharacter = word.Length - 1; startCharacter < matrix.GetLength(0); startCharacter++)
            {
                var stringToCheck = new StringBuilder();
                for (var i = 0; i < word.Length; i++)
                {
                    stringToCheck.Append(matrix[startCharacter - i, row + i]);
                }

                if (stringToCheck.ToString() == reverseWord || stringToCheck.ToString() == word)
                {
                    result++;
                    for (var i = 0; i < word.Length; i++)
                    {
                        debugMatrix[startCharacter - i, row + i] = matrix[startCharacter - i, row + i];
                    }
                }
            }
        }
        
        return result;
    }
}