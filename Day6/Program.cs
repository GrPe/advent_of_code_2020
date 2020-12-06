using System;
using System.Collections.Generic;
using System.Linq;

namespace Day6
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
            int sum = 0;
            foreach (var group in Input.data.Split("\r\n\r\n"))
            {
                var answers = new Dictionary<char, int>();
                foreach (var person in group.Trim().Split("\r\n"))
                {
                    foreach (var answer in person)
                    {
                        if(!answers.ContainsKey(answer))
                        {
                            answers.Add(answer, 0);
                        }
                        answers[answer]++;
                    }
                }
                sum += answers.Count(x => x.Value == group.Trim().Split("\r\n").Length);
            }
            Console.WriteLine(sum);
        }

        private static void PartOne()
        {
            int sum = 0;
            foreach (var group in Input.data.Split("\r\n\r\n"))
            {
                HashSet<char> answers = new HashSet<char>();
                foreach (var person in group.Trim().Split("\r\n"))
                {
                    foreach (var answer in person)
                    {
                        answers.Add(answer);
                    }
                }
                sum += answers.Count;
            }
            Console.WriteLine(sum);
        }
    }
}
