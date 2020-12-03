using System;
using System.Collections.Generic;
using System.IO;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            using var reader = new StreamReader(@"D:\Projects\AdventOfCode2020\Day1\input\data1.txt");
            var numbers = new List<int>();
            string line;
            while((line = reader.ReadLine()) is not null)
            {
                numbers.Add(int.Parse(line));
            }

            PartOne(numbers);
            PartTwo(numbers);
        }

        static void PartOne(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[i] + numbers[j] == 2020)
                    {
                        Console.WriteLine(numbers[i] * numbers[j]);
                        return;
                    }
                }
            }
            Console.WriteLine("Nope");
        }

        static void PartTwo(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    for(int k = j + 1; k < numbers.Count; k++)
                    {
                        if (numbers[i] + numbers[j] + numbers[k] == 2020)
                        {
                            Console.WriteLine(numbers[i] * numbers[j] * numbers[k]);
                            return;
                        }
                    }
                }
            }
            Console.WriteLine("Nope");
        }
    }
}
