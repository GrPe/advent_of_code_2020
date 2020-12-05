using System;
using System.Collections.Generic;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            PartOne();
            PartTwo();
        }
        private static void PartTwo()
        {
            var seats = new List<int>();
            foreach (var line in Input.data.Split("\r\n"))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                string row = "", col = "";
                for (int i = 0; i < line.Length; i++)
                {
                    if (i < 7)
                    {
                        row += line[i] == 'F' ? "0" : "1";
                    }
                    else
                    {
                        col += line[i] == 'L' ? "0" : "1";
                    }
                }
                seats.Add(Convert.ToInt32(row, 2) * 8 + Convert.ToInt32(col, 2));
            }
            seats.Sort();
            for(int i = 0; i < seats.Count; i++)
            {
                if(!seats.Contains(seats[i]-1) || !seats.Contains(seats[i] + 1))
                {
                    Console.WriteLine(seats[i]);
                }
            }
        }

        private static void PartOne()
        {
            var max = 0;
            foreach (var line in Input.data.Split("\r\n"))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                string row = "", col = "";
                for (int i = 0; i < line.Length; i++)
                {
                    if (i < 7)
                    {
                        row += line[i] == 'F' ? "0" : "1";
                    }
                    else
                    {
                        col += line[i] == 'L' ? "0" : "1";
                    }
                }
                max = Math.Max(max, Convert.ToInt32(row, 2) * 8 + Convert.ToInt32(col, 2));
            }
            Console.WriteLine(max);
        }
    }
}
