namespace _03.MatrixOperators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MatrixOperatorsMain
    {
        public static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            List<int>[] matrix = new List<int>[rows];
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
            }

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] commandArgs = command
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                string commandName = commandArgs[0];

                switch (commandName)
                {
                    case "remove":
                        string type = commandArgs[1];
                        string positionType = commandArgs[2];
                        int index = int.Parse(commandArgs[3]);
                        switch (type)
                        {
                            case "odd":
                                if (positionType == "row")
                                {
                                    matrix[index] = matrix[index].Where(n => n % 2 == 0).ToList();
                                }
                                else
                                {
                                    for (int row = 0; row < matrix.Length; row++)
                                    {
                                        if (matrix[row].Count > index)
                                        {
                                            if (matrix[row][index] % 2 != 0)
                                            {
                                                matrix[row].RemoveAt(index);
                                            }
                                        }
                                    }
                                }

                                break;
                            case "even":

                                if (positionType == "row")
                                {
                                    matrix[index] = matrix[index].Where(n => n % 2 != 0).ToList();
                                }
                                else
                                {
                                    for (int row = 0; row < matrix.Length; row++)
                                    {
                                        if (matrix[row].Count > index)
                                        {
                                            if (matrix[row][index] % 2 == 0)
                                            {
                                                matrix[row].RemoveAt(index);
                                            }
                                        }
                                    }
                                }

                                break;
                            case "positive":
                                if (positionType == "row")
                                {
                                    matrix[index] = matrix[index].Where(n => n < 0).ToList();
                                }
                                else
                                {
                                    for (int row = 0; row < matrix.Length; row++)
                                    {
                                        if (matrix[row].Count > index)
                                        {
                                            if (matrix[row][index] >= 0)
                                            {
                                                 matrix[row].RemoveAt(index);
                                            }
                                        }
                                    }
                                }

                                break;
                            case "negative":

                                if (positionType == "row")
                                {
                                    matrix[index] = matrix[index].Where(n => n > 0).ToList();
                                }
                                else
                                {
                                    for (int row = 0; row < matrix.Length; row++)
                                    {
                                        if (matrix[row].Count > index)
                                        {
                                            if (matrix[row][index] < 0)
                                            {
                                                matrix[row].RemoveAt(index);
                                            }
                                        }
                                    }
                                }

                                break;
                        }

                        break;
                    case "swap":
                        int firstRowIndex = int.Parse(commandArgs[1]);
                        int secondRowIndex = int.Parse(commandArgs[2]);

                        Swap(matrix, firstRowIndex, secondRowIndex);

                        break;
                    case "insert":
                        int rowIndex = int.Parse(commandArgs[1]);
                        int number = int.Parse(commandArgs[2]);

                        matrix[rowIndex].Insert(0, number);
                        break;
                }

                command = Console.ReadLine();
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(List<int>[] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }

        private static void Swap(List<int>[] matrix, int firstRowIndex, int secondRowIndex)
        {
            if (firstRowIndex != secondRowIndex)
            {
                var oldValue = matrix[firstRowIndex];
                matrix[firstRowIndex] = matrix[secondRowIndex];
                matrix[secondRowIndex] = oldValue;
            }
        }
    }
}
