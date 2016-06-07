namespace _10.ArrayManipulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ArrayManipulatorMain
    {
        public static void Main(string[] args)
        {
            var sequence = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string command = Console.ReadLine();
            short index;
            short value;

            while (command != "print")
            {
                string[] commandArgs = command.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                string commandName = commandArgs[0];


                switch (commandName)
                {
                    case "add":
                    case "addMany":
                        index = short.Parse(commandArgs[1]);

                        for (int i = 2; i < commandArgs.Length; i++)
                        {
                            value = short.Parse(commandArgs[i]);
                            sequence.Insert(index, value);
                            index++;
                        }
                        break;
                    case "shift":
                        value = short.Parse(commandArgs[1]);
                        ShiftLeft(sequence, value % sequence.Count);
                        break;
                    case "contains":
                        value = short.Parse(commandArgs[1]);
                        index = (short)sequence.IndexOf(value);
                        Console.WriteLine(index);
                        break;
                    case "sumPairs":
                        List<int> summedSequence = new List<int>((sequence.Count + 1 / 2) + 2);
                        for (int i = 0; i < sequence.Count - 1; i += 2)
                        {
                            summedSequence.Add(sequence[i] + sequence[i + 1]);
                        }
                        if (sequence.Count % 2 == 1)
                        {
                            summedSequence.Add(sequence[sequence.Count - 1]);
                        }
                        
                        sequence = summedSequence;
                        break;
                    case "remove":
                        index = short.Parse(commandArgs[1]);
                        sequence.RemoveAt(index);
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(", ", sequence)}]");
        }

        private static void ShiftLeft(List<int> sequence, int value)
        {
            for (int i = 0; i < value; i++)
            {
                int oldValue = sequence[0];
                for (int index = 0; index < sequence.Count - 1; index++)
                {
                    sequence[index] = sequence[index + 1];
                }

                sequence[sequence.Count - 1] = oldValue;
            }
        }
    }
}