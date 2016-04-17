using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequence =
                Console.ReadLine()
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            string intType;
            int searchedIndex;
            int length;
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] commandInfo = command.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                string commandName = commandInfo[0];
                switch (commandName)
                {
                    case "exchange":
                        int index = int.Parse(commandInfo[1]);
                        if (index >= 0 && index < sequence.Length)
                        {
                            sequence = ExchangeAt(sequence, index);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }

                        break;
                    case "max":
                        intType = commandInfo[1];
                        searchedIndex = -1;
                        if (intType == "odd")
                        {
                            searchedIndex = GetMaxOddIndex(sequence);
                        }
                        else if (intType == "even")
                        {
                            searchedIndex = GetMaxEvenIndex(sequence);
                        }

                        if (searchedIndex == -1)
                        {
                            Console.WriteLine("No matches");
                        }
                        else
                        {
                            Console.WriteLine(searchedIndex);
                        }

                        break;

                    case "min":
                        intType = commandInfo[1];
                        searchedIndex = 0;
                        if (intType == "odd")
                        {
                            searchedIndex = GetMinOddIndex(sequence);
                        }
                        else if (intType == "even")
                        {
                            searchedIndex = GetMinEvenIndex(sequence);
                        }

                        if (searchedIndex == -1)
                        {
                            Console.WriteLine("No matches");
                        }
                        else
                        {
                            Console.WriteLine(searchedIndex);
                        }

                        break;

                    case "first":
                        length = int.Parse(commandInfo[1]);
                        if (length < 0 || length > sequence.Length)
                        {
                            Console.WriteLine("Invalid count");
                        }
                        else
                        {
                            int[] result = null;
                            intType = commandInfo[2];
                            if (intType == "odd")
                            {
                                result = sequence.Where(x => x % 2 == 1).Take(length).ToArray();
                            }
                            else if (intType == "even")
                            {
                                result = sequence.Where(x => x % 2 == 0).Take(length).ToArray();
                            }

                            Console.WriteLine("[{0}]", string.Join(", ", result));
                        }
                        break;
                    case "last":
                        length = int.Parse(commandInfo[1]);
                        if (length < 0 || length > sequence.Length)
                        {
                            Console.WriteLine("Invalid count");
                        }
                        else
                        {
                            int[] resultArray = null;
                            intType = commandInfo[2];
                            if (intType == "odd")
                            {
                                resultArray = sequence.Reverse().Where(x => x % 2 == 1).Take(length).Reverse().ToArray();
                            }
                            else if (intType == "even")
                            {
                                resultArray = sequence.Reverse().Where(x => x % 2 == 0).Take(length).Reverse().ToArray();
                            }

                            Console.WriteLine("[{0}]", string.Join(", ", resultArray));
                        }

                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("[{0}]", string.Join(", ", sequence));

        }

        private static int GetMinEvenIndex(int[] sequence)
        {
            int maxValue = int.MaxValue;
            int searchedIndex = -1;
            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] % 2 == 0 && sequence[i] <= maxValue)
                {
                    searchedIndex = i;
                    maxValue = sequence[i];
                }
            }

            return searchedIndex;
        }

        private static int GetMinOddIndex(int[] sequence)
        {
            int maxValue = int.MaxValue;
            int searchedIndex = -1;
            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] % 2 == 1 && sequence[i] <= maxValue)
                {
                    searchedIndex = i;
                    maxValue = sequence[i];
                }
            }

            return searchedIndex;
        }

        private static int GetMaxEvenIndex(int[] sequence)
        {
            int maxValue = int.MinValue;
            int searchedIndex = -1;
            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] % 2 == 0 && sequence[i] >= maxValue)
                {
                    searchedIndex = i;
                    maxValue = sequence[i];
                }
            }

            return searchedIndex;
        }

        private static int GetMaxOddIndex(int[] sequence)
        {
            int maxValue = int.MinValue;
            int searchedIndex = -1;
            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] % 2 == 1 && sequence[i] >= maxValue)
                {
                    searchedIndex = i;
                    maxValue = sequence[i];
                }
            }

            return searchedIndex;
        }

        private static int[] ExchangeAt(int[] sequence, int index)
        {
            int[] firstArray = new int[index + 1];
            Array.Copy(sequence, firstArray, index + 1);

            int[] secondArray = new int[sequence.Length - firstArray.Length];
            Array.Copy(sequence, index + 1, secondArray, 0, secondArray.Length);

            int[] resultArray = secondArray.Concat(firstArray).ToArray();

            return resultArray;
        }
    }
}
