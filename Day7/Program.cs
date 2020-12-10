using System;
using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            PartOne();
            PartTwo();
        }

        public static void PartTwo()
        {
            List<WeigthedNode> nodes = new List<WeigthedNode>();

            foreach (var line in Input.data.Split("\r\n", StringSplitOptions.RemoveEmptyEntries))
            {
                string[] data = line.Split(new string[] { "contain", ", ", "." }, StringSplitOptions.RemoveEmptyEntries);
                string key = data[0].Trim().TrimEnd('s');
                string[] values = data[1..].Select(d => d.Trim().TrimEnd('s')).ToArray();

                if (values.Length == 1 && values[0].StartsWith("no other"))
                {
                    continue;
                }

                var parent = nodes.FirstOrDefault(n => n.Name == key);
                if (parent is null)
                {
                    parent = new WeigthedNode { Name = key };
                    nodes.Add(parent);
                }

                foreach (var value in values)
                {
                    int weight = int.Parse(value.Split(' ', 2)[0]);
                    string name = value.Split(' ', 2)[1];
                    var node = nodes.FirstOrDefault(x => x.Name == name);
                    if (node is null)
                    {
                        node = new WeigthedNode { Name = name };
                        nodes.Add(node);
                    }
                    parent.Parents.Add(new KeyValuePair<WeigthedNode, int>(node, weight));
                }
            }


            var gold = nodes.Where(n => n.Name == "shiny gold bag").FirstOrDefault();

            //traversal
            var counter = Traverse(gold) - 1;

            Console.WriteLine(counter);
        }

        public static int Traverse(WeigthedNode node)
        {
            return 1 + node.Parents.Sum(n => n.Value * Traverse(n.Key));
        }

        public static void PartOne()
        {
            List<Node> nodes = new List<Node>();

            foreach (var line in Input.data.Split("\r\n", StringSplitOptions.RemoveEmptyEntries))
            {
                string[] data = line.Split(new string[] { "contain", ", ", "." }, StringSplitOptions.RemoveEmptyEntries);
                string key = data[0].Trim().TrimEnd('s');
                string[] values = data[1..].Select(d => d.Trim().TrimEnd('s')).ToArray();

                if (values.Length == 1 && values[0].StartsWith("no other"))
                {
                    continue;
                }

                var parent = nodes.FirstOrDefault(n => n.Name == key);
                if (parent is null)
                {
                    parent = new Node { Name = key };
                    nodes.Add(parent);
                }

                foreach (var value in values)
                {
                    string name = value.Split(' ', 2)[1];
                    var node = nodes.FirstOrDefault(x => x.Name == name);
                    if (node is null)
                    {
                        node = new Node { Name = name };
                        nodes.Add(node);
                    }
                    node.Parents.Add(parent);
                }
            }


            var gold = nodes.Where(n => n.Name == "shiny gold bag").FirstOrDefault();

            //traversal
            var queue = new Queue<Node>();
            queue.Enqueue(gold);
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();

                foreach (var parent in node.Parents)
                {
                    if (!parent.CointainShinyGold)
                    {
                        parent.CointainShinyGold = true;
                        queue.Enqueue(parent);
                    }
                }
            }

            int count = nodes.Count(n => n.CointainShinyGold);
            Console.WriteLine(count);
        }
    }

    public class Node
    {
        public string Name { get; set; } = String.Empty;
        public List<Node> Parents { get; set; } = new List<Node>();
        public bool CointainShinyGold { get; set; } = false;
    }

    public class WeigthedNode
    {
        public string Name { get; set; } = String.Empty;
        public List<KeyValuePair<WeigthedNode, int>> Parents { get; set; } = new List<KeyValuePair<WeigthedNode, int>>();
        public bool CointainShinyGold { get; set; } = false;
        public int NastedBags { get; set; }
    }
}
