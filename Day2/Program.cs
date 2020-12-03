using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day2
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
            using var reader = new StreamReader(@"D:\Projects\AdventOfCode2020\Day2\input.txt");
            var regex = new Regex(@"([0-9]+)-([0-9]+)\s([a-z]+):\s([a-z]+)");
            int counter = 0;
            string line;
            while ((line = reader.ReadLine()) is not null)
            {
                var match = regex.Match(line);
                var count = match.Groups[4].Value.Where(c => c.ToString() == match.Groups[3].Value).Count();
                if (int.Parse(match.Groups[1].Value) <= count && count <= int.Parse(match.Groups[2].Value))
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }

        private static void PartTwo()
        {
            using var reader = new StreamReader(@"D:\Projects\AdventOfCode2020\Day2\input.txt");
            var regex = new Regex(@"([0-9]+)-([0-9]+)\s([a-z]+):\s([a-z]+)");
            int counter = 0;
            string line;
            while ((line = reader.ReadLine()) is not null)
            {
                var match = regex.Match(line);
                var first = int.Parse(match.Groups[1].Value) - 1;
                var second = int.Parse(match.Groups[2].Value) - 1;
                if((match.Groups[4].Value[first].ToString() == match.Groups[3].Value && 
                    match.Groups[4].Value[second].ToString() != match.Groups[3].Value) || 
                    (match.Groups[4].Value[first].ToString() != match.Groups[3].Value &&
                    match.Groups[4].Value[second].ToString() == match.Groups[3].Value))
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
