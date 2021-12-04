using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            List<int[,]> boardList = ReadAndParse(ref numbers);
            int[,]? winnerBoard;
            int count = 0;

            foreach (var number in numbers)
            {
                foreach (var board in boardList)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (board[i, j] == number)
                                board[i, j] = -1;
                        }
                    }
                }

                winnerBoard = CheckForSameNumber(boardList);
                if (winnerBoard != null)
                {
                    //count++;
                    
                    boardList.Remove(winnerBoard);
               

                    if(boardList.Count == 0)
                    {
                        int sum = 0;
                        foreach (var item in winnerBoard)
                        {
                            if (item > 0)
                                sum += item;
                        }

                        Console.WriteLine(sum * number);

                        break;
                    }

                    winnerBoard = null;
                }
                    
            }

        }

        static int[,]? CheckForSameNumber(List<int[,]> boards)
        {
            bool result = true;
            int[,] winnerBoard = null;

            
            foreach (var board in boards)
            {
                //rows
                for (int i = 0; i < 5; i++)
                {
                    result = true;
                    for (int j = 0; j < 5; j++)
                    {
                        if (board[i,j] != -1)
                        {
                            result = false;
                            break;
                        }
                    }
                    if (result)
                    {
                        return board;
                    }
                }

                //columns
                for (int i = 0; i < 5; i++)
                {
                    result = true;
                    for (int j = 0; j < 5; j++)
                    {
                        if (board[j, i] != -1)
                        {
                            result = false;
                            break;
                        }
                    }
                    if (result)
                    {
                        return board;
                    }
                }
            }


            return winnerBoard;
        }

        static List<int[,]> ReadAndParse(ref List<int> numbers)
        {
            var boardList = new List<int[,]>();

            numbers = File.ReadAllLines("input.txt")[0]
                .Split(",")
                .Select(x => Convert.ToInt32(x))
                .ToList();

            var input = File.ReadAllLines("input.txt")
                .Skip(2)
                .ToArray();

            int count = 0;
            var currentBoard = new int[5,5];

            for (int i = 0; i < input.Count(); i++)
            {
                if (input[i].Length == 0)
                    continue;

                var line = input[i].Split(" ");
                line = line.Where(x => x.Length > 0).ToArray();
                for (int j = 0; j < 5; j++)
                {
                    currentBoard[count,j] = Convert.ToInt32(line[j]);
                }
                count++;
                if (count == 5)
                {
                    count = 0;
                    boardList.Add(currentBoard);
                    currentBoard = new int[5, 5];
                }
                    
            }

            return boardList;
        }
    }
}
