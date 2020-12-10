using System;
using System.Collections.Generic;
using System.Linq;

namespace Day9
{
    class Program
    {
        static List<long> numbers = new List<long>();

        static void Main(string[] args)
        {
            foreach(var line in Input.data.Split("\r\n", StringSplitOptions.RemoveEmptyEntries))
            {
                numbers.Add(long.Parse(line));
            }

            int invalid = 0;
            for(int i = 25; i < numbers.Count; i++)
            {
                if(!IsSumOfPrevious(i, 25))
                {
                    invalid = i;
                    Console.WriteLine(numbers[i]);
                    break;
                }
            }

            for(int i = 0; i < invalid; i++)
            {
                long sum = 0;
                for(int j = i; j < invalid; j++)
                {
                    sum += numbers[j];
                    if(sum == numbers[invalid])
                    {
                        var min = numbers.GetRange(i, j - i).Min();
                        var max = numbers.GetRange(i, j - i).Max();
                        Console.WriteLine(min + max);
                        return;
                    }
                }
            }

        }

        static bool IsSumOfPrevious(int num, int prev)
        {
            for(int i = num - 1; i >= num - prev; i-- )
            {
                for(int j = i - 1; j >= num - prev; j--)
                {
                    if (numbers[i] + numbers[j] == numbers[num])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
