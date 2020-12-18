using System;
using System.Collections.Generic;

namespace Day10
{
    class Program
    {
        static List<int> adapters = new List<int>();

        static void Main(string[] args)
        {
            adapters.Add(0);
            foreach (var line in Input.data.Split("\r\n", StringSplitOptions.RemoveEmptyEntries))
            {
                adapters.Add(int.Parse(line));
            }
            adapters.Sort();

            int oneJolts = 0;
            int threeJolts = 1;

            for (int i = 0; i < adapters.Count - 1; i++)
            {
                if (adapters[i + 1] - adapters[i] == 1)
                {
                    oneJolts++;
                }
                else if (adapters[i + 1] - adapters[i] == 3)
                {
                    threeJolts++;
                }
                else
                {
                    Console.WriteLine("Ops!!!");
                }
            }

            Console.WriteLine($"Single: {oneJolts} Tripple: {threeJolts}, multiple: {oneJolts * threeJolts}");

            //Part 2

            Console.WriteLine(Run(0));
        }

        static Dictionary<int, long> cache = new Dictionary<int, long>();

        public static long Run(int x)
        {
            if(cache.ContainsKey(x))
            {
                return cache[x];
            }

            if (x == adapters.Count - 1)
            {
                return 1;
            }

            long count = 0;
            for (int i = x + 1; i < adapters.Count; i++)
            {
                if (adapters[i] - adapters[x] <= 3)
                {
                    count += Run(i);
                }
            }

            cache.Add(x, count);
            return count;
        }
    }
}
