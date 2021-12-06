using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            Line[] allLines = ReadAndParse();
            

            int greatestX1 = allLines.Max(l => l.x1);
            int greatestX2 = allLines.Max(l => l.x2);
            int greatestY1 = allLines.Max(l => l.y1);
            int greatestY2 = allLines.Max(l => l.y2);
            int greatestX = (greatestX1 > greatestX2 ? greatestX1 : greatestX2) + 1;
            int greatestY = (greatestY1 > greatestY2 ? greatestY1 : greatestY2) + 1;

            var matrix = new int[greatestY, greatestX];
            

            DrawLines(allLines, matrix);

            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] >= 2)
                        count++;
                }
            }

            Console.WriteLine(count);
        }

        static void DrawLines(Line[] lines, int[,] matrix)
        {
            var sameX = lines
                .Where(l => l.x1 == l.x2)
                .ToArray();
            var sameY = lines
                .Where(l => l.y1 == l.y2)
                .ToArray();

            foreach (var line in sameX)
            {
                if (line.y1 > line.y2)
                {
                    int count = line.y1;
                    while(count >= line.y2)
                    {
                        matrix[count, line.x1]++;
                        count--;
                    }
                }
                else
                {
                    int count = line.y2;
                    while (count >= line.y1)
                    {
                        matrix[count, line.x1]++;
                        count--;
                    }
                }
            }

            foreach (var line in sameY)
            {
                if (line.x1 > line.x2)
                {
                    int count = line.x1;
                    while (count >= line.x2)
                    {
                        matrix[line.y1, count]++;
                        count--;
                    }
                }
                else
                {
                    int count = line.x2;
                    while (count >= line.x1)
                    {
                        matrix[line.y1, count]++;
                        count--;
                    }
                }
            }


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0} ", matrix[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

        static Line[] ReadAndParse()
        {
            var input = File.ReadAllLines("input.txt");

            List<Line> lines = new List<Line>();

            foreach (var x in input)
            {
                var line = x.Split(" -> ");
                int x1 = Convert.ToInt32(line[0].Split(",")[0]);
                int y1 = Convert.ToInt32(line[0].Split(",")[1]);
                int x2 = Convert.ToInt32(line[1].Split(",")[0]);
                int y2 = Convert.ToInt32(line[1].Split(",")[1]);

                lines.Add(new Line(x1, y1, x2, y2));
            }

            return lines.ToArray();
        }


        public record Line(int x1, int y1, int x2, int y2);
    }

    
}
