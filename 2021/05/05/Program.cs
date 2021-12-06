using System;
using System.Collections.Generic;
using System.IO;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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
