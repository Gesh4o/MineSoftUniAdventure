namespace _03.DiagonalDifference
{
    using System;

    public class DiagonalDifferenceMain
    {
        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[][] matrix = new int[n][];
            for (int row = 0; row < n; row++)
            {
                string[] rowAsString = Console.ReadLine().Split(' ');
                matrix[row] = Array.ConvertAll(rowAsString, int.Parse);
            }

            int currentSum = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                currentSum += matrix[i][i];
            }

            int sum = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                sum += matrix[i][matrix.Length - 1 - i];
            }

            int result = Math.Abs(currentSum - sum);

            Console.WriteLine(result);
        }
    }
}
