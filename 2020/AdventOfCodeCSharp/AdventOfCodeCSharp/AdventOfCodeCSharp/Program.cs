using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            A2020_07();
        }

        #region MainMethodsPerDay

        static void A2020_07()
        {
            var bags = ReadAndParseFile2020_07();
            //int count = 0;

            //foreach (var bag in bags)
            //{
            //    if (ContainsShinyGold(bag, bags))
            //    {
            //        count++;
            //    }
            //}

            //Console.WriteLine(count);
        }

        #endregion

        #region CalculationMethods

        //static bool ContainsShinyGold(Bag currentBag, Bag[] bags)
        //{
        //    if (currentBag.containedBags.Length == 0)
        //    {
        //        return false;
        //    }

        //    var containedBages = currentBag.containedBags;
        //    bool result = false;

        //    foreach (var bag in containedBages)
        //    {
        //        if (bag == "shiny gold")
        //            return true;
        //        else
        //            result = ContainsShinyGold(bags.Single(b => b.name == bag), bags);

        //        if(result)
        //            return true;
        //    }

        //    return result;


        //}

        static int CountBagsInBag (Bag bag, Bag[] bags)
        {
            if (bag.Contains == 0)
                return 0;

            int result = 0;

            foreach (var bagName in bag.containedBags.Keys)
            {
                result += 
            }


        }

        #endregion

        #region ReadAndParse

        static Bag[] ReadAndParseFile2020_07()
        {
            var lines = File.ReadAllLines("input.txt");
            var bags = new List<Bag>();
            

            foreach (var line in lines)
            {
                var containedBags = new Dictionary<string,int>();
                var splittedLine = line.Split(" ");
                string name = $"{splittedLine[0]} {splittedLine[1]}";
                if (splittedLine[4] == "no")
                {
                    bags.Add(new Bag(name, containedBags));
                    continue;
                }

                containedBags.Add($"{splittedLine[5]} {splittedLine[6]}",Convert.ToInt32(splittedLine[4]));
                int count = 6;
                while(splittedLine.Length > 7 && splittedLine.Length > count + 4)
                {
                    containedBags.Add($"{splittedLine[count + 3]} {splittedLine[count + 4]}", Convert.ToInt32(splittedLine[count + 2]));
                    count += 4;
                }

                bags.Add(new Bag(name, containedBags));
            }

            return bags.ToArray();
        }

        #endregion

        #region Records

        record Bag(string name, Dictionary<string, int> containedBags) 
        { 
            public int Contains 
            {
                get 
                {
                    return containedBags.Sum(c => c.Value);
                }
            }
        };

        #endregion
    }
}
