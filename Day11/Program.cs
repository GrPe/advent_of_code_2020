using System;
using System.Linq;
using System.Text;

namespace Day11
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Input.data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(line => new StringBuilder(line)).ToArray();


            for(int counter = 0; ;counter++)
            {
                var copy = array.Select(x => new StringBuilder(x.ToString())).ToArray();

                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        if (array[i][j] == 'L' && Count2(i, j, array) == 0)
                        {
                            copy[i][j] = '#';
                        }
                        else if (array[i][j] == '#' && Count2(i, j, array) >= 5)
                        {
                            copy[i][j] = 'L';
                        }
                    }
                }

                var first = string.Concat<StringBuilder>(array);
                var second = string.Concat<StringBuilder>(copy);

                if (first == second)
                {
                    Console.WriteLine(first.Count(x => x == '#'));
                    break;
                }

                array = copy;
            }

        }

        static int Count(int i, int j, StringBuilder[] array)
        {
            int counter = 0;
            for (int x = i - 1; x <= i + 1; x++)
            {
                for (int y = j - 1; y <= j + 1; y++)
                {

                    if (x == i && y == j)
                    {
                        continue;
                    }

                    if (x < 0 || x >= array.Length || y < 0 || y >= array[0].Length)
                    {
                        continue;
                    }

                    if (array[x][y] == '#')
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        static int Count2(int i, int j, StringBuilder[] array)
        {
            int counter = 0;

            for(int shiftX = -1; shiftX <= 1; shiftX++ )
            {
                for(int shiftY = -1; shiftY <= 1; shiftY++)
                {
                    if(shiftX == 0 && shiftY == 0)
                    {
                        continue;
                    }

                    int x = i, y = j;
                    while (x >= 0 && x < array.Length && y >= 0 && y < array[0].Length)
                    {
                        if (array[x][y] != '.' && (x != i || y != j))
                        {
                            if(array[x][y] == '#') counter++;
                            break;
                        }
                        x += shiftX;
                        y += shiftY;
                    }
                }
            }

            return counter;
        }
    }
}
