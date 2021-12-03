using System;
using System.IO;
using System.Linq;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var lines = File.ReadAllLines("input.txt");

            string gammaBin = "";
            int gammaDec = 0;
            string epsilonBin = "";
            int epsilonDec = 0;
            string oxygenBin = "";
            int oxygenDec = 0;
            string co2Bin = "";
            int co2Dec = 0;
            var linesTmp = lines;

            //Oxygen
            for (int i = 0; i < lines[0].Length; i++)
            {

                int count0 = 0;
                int count1 = 0;
                foreach (var number in linesTmp)
                {
                    if (number[i] == '0')
                        count0++;
                    else
                        count1++;
                }
                if (count0 > count1)
                {
                    gammaBin += "0";
                    epsilonBin += "1";
                    linesTmp = linesTmp.
                        Where(x => x[i] == '0')
                        .ToArray();
                }
                else if(count1 > count0)
                {
                    gammaBin += "1";
                    epsilonBin += "0";
                    linesTmp = linesTmp.
                        Where(x => x[i] == '1')
                        .ToArray();
                }
                else
                {
                    linesTmp = linesTmp.
                        Where(x => x[i] == '1')
                        .ToArray();
                }

                if(linesTmp.Length == 1)
                {
                    oxygenDec = Convert.ToInt32(linesTmp[0], 2);
                    break;
                }

            }

            //CO2
            linesTmp = lines;
            for (int i = 0; i < lines[0].Length; i++)
            {

                int count0 = 0;
                int count1 = 0;
                foreach (var number in linesTmp)
                {
                    if (number[i] == '0')
                        count0++;
                    else
                        count1++;
                }
                if (count0 < count1)
                {
                    gammaBin += "0";
                    epsilonBin += "1";
                    linesTmp = linesTmp.
                        Where(x => x[i] == '0')
                        .ToArray();
                }
                else if (count1 < count0)
                {
                    gammaBin += "1";
                    epsilonBin += "0";
                    linesTmp = linesTmp.
                        Where(x => x[i] == '1')
                        .ToArray();
                }
                else
                {
                    linesTmp = linesTmp.
                        Where(x => x[i] == '0')
                        .ToArray();
                }

                if (linesTmp.Length == 1)
                {
                    co2Dec = Convert.ToInt32(linesTmp[0], 2);
                    break;
                }

            }
            gammaDec = Convert.ToInt32(gammaBin, 2);
            epsilonDec = Convert.ToInt32(epsilonBin, 2);

            Console.WriteLine(co2Dec * oxygenDec);
        }
    }
}
