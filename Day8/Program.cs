using System;
using System.Collections.Generic;
using System.Linq;

namespace Day8
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
            List<Instruction> instructionsSet = new List<Instruction>();
            foreach (var line in Input.data.Split("\r\n", StringSplitOptions.RemoveEmptyEntries))
            {
                instructionsSet.Add(new Instruction
                {
                    Command = line[0..3],
                    Value = int.Parse(line[4..])
                });
            }

            for(int i = 0; i < instructionsSet.Count; i++)
            {
                var instructions = instructionsSet.Select(i => new Instruction { Command = i.Command, Value = i.Value }).ToList();
                if(instructions[i].Command == "acc")
                {
                    continue;
                }
                //change instruction
                if(instructions[i].Command == "nop")
                {
                    instructions[i].Command = "jmp";
                }
                else
                {
                    instructions[i].Command = "nop";
                }

                int instructionPointer = 0;
                int accumulator = 0;
                while (true)
                {
                    if (instructionPointer == instructions.Count - 1)
                    {
                        Console.WriteLine(accumulator);
                        return;
                    }

                    var instruction = instructions[instructionPointer];
                    if (instruction.AlreadyExecuted)
                    {
                        break;
                    }
                    instructions[instructionPointer].AlreadyExecuted = true;

                    switch (instruction.Command)
                    {
                        case "nop":
                            instructionPointer++;
                            break;
                        case "jmp":
                            instructionPointer += instruction.Value;
                            break;
                        case "acc":
                            accumulator += instruction.Value;
                            instructionPointer++;
                            break;
                    }
                }
            }
        }

        public static void PartOne()
        {
            List<Instruction> instructions = new List<Instruction>();
            foreach (var line in Input.data.Split("\r\n", StringSplitOptions.RemoveEmptyEntries))
            {
                instructions.Add(new Instruction
                {
                    Command = line[0..3],
                    Value = int.Parse(line[4..])
                });
            }

            int instructionPointer = 0;
            int accumulator = 0;
            while (true)
            {
                var instruction = instructions[instructionPointer];
                if (instruction.AlreadyExecuted)
                {
                    Console.WriteLine(accumulator);
                    break;
                }
                instructions[instructionPointer].AlreadyExecuted = true;

                switch (instruction.Command)
                {
                    case "nop":
                        instructionPointer++;
                        break;
                    case "jmp":
                        instructionPointer += instruction.Value;
                        break;
                    case "acc":
                        accumulator += instruction.Value;
                        instructionPointer++;
                        break;
                }
            }
        }
    }

    public record Instruction
    {
        public string Command { get; set; }
        public int Value { get; set; }
        public bool AlreadyExecuted { get; set; }
    }
}
