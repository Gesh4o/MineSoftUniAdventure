namespace _03.ArrayTest
{
    using System;
    using System.Linq;

    public class ArraysMain
    {
        private const char ArgumentsDelimiter = ' ';

        public static void Main()
        {
            string uselessLine = Console.ReadLine();

            long[] array = Console.ReadLine()
                .Split(ArgumentsDelimiter)
                .Select(long.Parse)
                .ToArray();

            string command = Console.ReadLine();

            while (!command.Equals("stop"))
            {
                int[] args = new int[2];

                if (command.StartsWith("add") ||
                    command.StartsWith("subtract ") ||
                    command.StartsWith("multiply"))
                {
                    string[] stringParams = command.Split(ArgumentsDelimiter);
                    command = stringParams[0];
                    args[0] = int.Parse(stringParams[1]);
                    args[1] = int.Parse(stringParams[2]);
                }

                PerformAction(array, command, args);

                PrintArray(array);

                command = Console.ReadLine();
            }
        }

        private static void PerformAction(long[] arr, string action, int[] args)
        {
            int pos = args[0];
            pos--;
            int value = args[1];

            switch (action)
            {
                case "multiply":
                    arr[pos] *= value;
                    break;
                case "add":
                    arr[pos] += value;
                    break;
                case "subtract":
                    arr[pos] -= value;
                    break;
                case "lshift":
                    ArrayShiftLeft(arr);
                    break;
                case "rshift":
                    ArrayShiftRight(arr);
                    break;
            }
        }

        private static void ArrayShiftRight(long[] array)
        {
            long oldValue = array[array.Length - 1];
            for (int i = array.Length - 1; i >= 1; i--)
            {
                array[i] = array[i - 1];
            }
            
            array[0] = oldValue;
        }

        private static void ArrayShiftLeft(long[] array)
        {
            long oldValue = array[0];
            for (int i = 0; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }

            array[array.Length - 1] = oldValue;
        }

        private static void PrintArray(long[] array)
        {
            Console.WriteLine(string.Join(" ", array));
        }
    }
}
