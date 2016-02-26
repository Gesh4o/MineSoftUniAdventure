namespace _03.MatrixShuffling
{
    using System;

    public class MatrixShufflingMain
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            string[,] matrix = new string[n, m];

            InitializeMatrix(matrix);

            string[] commandArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string commandName = commandArgs[0];

            while (commandName.ToUpper() != "END")
            {
                try
                {
                    ProcessCommand(commandArgs, matrix);
                    PrintMatrix(matrix);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (IndexOutOfRangeException iore)
                {
                    Console.WriteLine("Invalid command!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected behavior catched!");
                    Console.WriteLine(e.Message);
                }

                commandArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                commandName = commandArgs[0];
            }
        }

        private static void InitializeMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = Console.ReadLine();
                }
            }
        }

        private static void ProcessCommand(string[] commandArgs, string[,] matrix)
        {
            const int DefaultSwapCommandArgsCount = 5;
            string commandName = commandArgs[0];

            switch (commandName.ToLower())
            {
                case "swap":
                    ValidateArgumentsCount(commandArgs.Length, DefaultSwapCommandArgsCount);
                    PerformSwapCommand(
                        int.Parse(commandArgs[1]), int.Parse(commandArgs[2]), int.Parse(commandArgs[3]), int.Parse(commandArgs[4]), matrix);
                    break;
                default:
                    throw new ArgumentException("Invalid command!");
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0} ", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }


        private static void PerformSwapCommand(
            int firstRowToBeSwapped,
            int firstColToBeSwapped,
            int secondRowToBeSwapped,
            int secondCollToBeSwapped,
            string[,] matrix)
        {
            string temporaryValue = matrix[firstRowToBeSwapped, firstColToBeSwapped];
            matrix[firstRowToBeSwapped, firstColToBeSwapped] = matrix[secondRowToBeSwapped, secondCollToBeSwapped];
            matrix[secondRowToBeSwapped, secondCollToBeSwapped] = temporaryValue;
        }

        private static void ValidateArgumentsCount(int actualcount, int expectedCount)
        {
            if (actualcount != expectedCount)
            {
                throw new ArgumentException("Invalid command!");
            }
        }
    }
}
