using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.LegoBlock
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] firstJaggedArray = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                firstJaggedArray[row] =
                    Console.ReadLine()
                        .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
            }

            int[][] secondJaggedArray = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                secondJaggedArray[row] =
                    Console.ReadLine()
                        .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
            }

            bool isMatrixValid = true;
            int initialLength = firstJaggedArray[0].Length + secondJaggedArray[0].Length;
            for (int row = 1; row < rows; row++)
            {
                int currentLength = firstJaggedArray[row].Length + secondJaggedArray[row].Length;

                if (initialLength != currentLength)
                {
                    isMatrixValid = false;
                    break;
                }
            }

            if (isMatrixValid)
            {
                for (int row = 0; row < rows; row++)
                {
                    Array.Reverse(secondJaggedArray[row]);
                }

                for (int row = 0; row < rows; row++)
                {
                    firstJaggedArray[row] = firstJaggedArray[row].Concat(secondJaggedArray[row]).ToArray();
                }

                for (int row = 0; row < rows; row++)
                {
                    Console.WriteLine("[{0}]", string.Join(", ", firstJaggedArray[row]));
                }
            }
            else
            {
                int cellsCount = 0;
                for (int row = 0; row < rows; row++)
                {
                    cellsCount += firstJaggedArray[row].Length;
                    cellsCount += secondJaggedArray[row].Length;
                }

                Console.WriteLine("The total number of cells is: {0}", cellsCount);
            }
        }
    }
}
