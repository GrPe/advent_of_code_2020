using System;
using System.Collections.Generic;
using System.IO;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            PartOne();
            PartTwo();
        }

        private static void PartOne()
        {
            using var reader = new StreamReader(@"D:\Projects\AdventOfCode2020\Day3\input.txt");
            List<string> map = new List<string>();
            string line;
            while ((line = reader.ReadLine()) is not null)
            {
                map.Add(line);
            }

            int x = 0, y = 0;
            int counter = 0;

            while (y < map.Count)
            {
                if (map[y][x % map[0].Length] == '#')
                {
                    counter++;
                }
                x += 3;
                y++;
            }

            Console.WriteLine(counter);
        }

        private static void PartTwo()
        {
            using var reader = new StreamReader(@"D:\Projects\AdventOfCode2020\Day3\input.txt");
            List<string> map = new List<string>();
            string line;
            while ((line = reader.ReadLine()) is not null)
            {
                map.Add(line);
            }

            long answer = 1;
            int addX = 1, addY = 1;
            do
            {
                int x = 0, y = 0;
                int counter = 0;

                while (y < map.Count)
                {
                    if (map[y][x % map[0].Length] == '#')
                    {
                        counter++;
                    }
                    x += addX;
                    y += addY;
                }

                addX += 2;
                if(addX % 9 == 0)
                {
                    addX = 1;
                    addY = 2;
                }
                answer *= counter;
            }
            while (addX != 3 || addY != 2);

            Console.WriteLine(answer);
        }
    }
}
