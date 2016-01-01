namespace _01.ArraySum
{
    using System;

    public class ArraySumMain
    {
        public static void Main(string[] args)
        {
            double[,] firstArray = new double[,] { { 1, 3 }, { 5, 7 } };
            double[,] secondArray = new double[,] { { 4, 2 }, { 1, 5 } };
            double[,] r = SumArrays(firstArray, secondArray);

            for (int row = 0; row < r.GetLength(0); row++)
            {
                for (int col = 0; col < r.GetLength(1); col++)
                {
                    Console.Write(r[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        public static double[,] SumArrays(double[,] firstArray, double[,] secondArray)
        {
            if (firstArray.GetLength(1) != secondArray.GetLength(0))
            {
                throw new Exception("Error!");

                // Throw discriptive name.
            }

            int firstArrayColsCount = firstArray.GetLength(1);
            double[,] resultArray = new double[firstArray.GetLength(0), secondArray.GetLength(1)];

            for (int row = 0; row < resultArray.GetLength(0); row++)
            {
                for (int col = 0; col < resultArray.GetLength(1); col++)
                {
                    for (int elementIndex = 0; elementIndex < firstArrayColsCount; elementIndex++)
                    {
                        resultArray[row, col] += firstArray[row, elementIndex] * secondArray[elementIndex, col];
                    }
                }
            }

            return resultArray;
        }
    }
}