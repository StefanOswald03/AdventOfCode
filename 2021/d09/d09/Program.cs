using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace d09
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = ReadAndParse();
            var matrix = To2D<int>(input);
            var lowest = new List<int>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                bool isLowest = true;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(i > 0)
                    {
                        if()
                    }
                }
            }
        }

        static int[][] ReadAndParse()
        {
            var matrix = File.ReadAllLines("input.txt")
                .Select(l => l.ToCharArray())
                .ToArray();

            return matrix
                .Select(x => Array.ConvertAll(x, s => Convert.ToInt32(s - '0')))
                .ToArray();
        }

        static T[,] To2D<T>(T[][] source)
        {
            try
            {
                int FirstDim = source.Length;
                int SecondDim = source.GroupBy(row => row.Length).Single().Key; // throws InvalidOperationException if source is not rectangular

                var result = new T[FirstDim, SecondDim];
                for (int i = 0; i < FirstDim; ++i)
                    for (int j = 0; j < SecondDim; ++j)
                        result[i, j] = source[i][j];

                return result;
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("The given jagged array is not rectangular.");
            }
        }
    }
}
