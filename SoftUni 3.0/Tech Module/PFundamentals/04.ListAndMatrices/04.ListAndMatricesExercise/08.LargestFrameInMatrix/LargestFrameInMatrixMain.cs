namespace _08.LargestFrameInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LargestFrameInMatrixMain
    {
        public static void Main(string[] args)
        {
            int initialRow = int.Parse(Console.ReadLine());
            int initialCol = int.Parse(Console.ReadLine());

            List<int[]> allSize = new List<int[]>();

            int squareHeight = -1;
            int squareWidth = -1;

            int[,] matrix = new int[initialRow, initialCol];

            InitializeMatrix(matrix);

            SetFrames(matrix, squareHeight, squareWidth, allSize);

            PrintOutput(allSize);
        }

        private static void PrintOutput(List<int[]> allSize)
        {
            foreach (int[] ints in allSize)
            {
                Console.WriteLine(string.Join("x", ints));
            }
        }

        private static void SetFrames(int[,] matrix, int squareHeight, int squareWidth, List<int[]> allSize)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int frameRow = row + 1;
                    int frameCol = col + 1;
                    int currentNumber = matrix[row, col];

                    while (frameCol < matrix.GetLength(1))
                    {
                        if (matrix[row, frameCol] != currentNumber)
                        {
                            frameCol--;
                            break;
                        }

                        frameCol++;
                    }

                    if (frameCol == matrix.GetLength(1))
                    {
                        frameCol--;
                    }

                    while (frameRow < matrix.GetLength(0))
                    {
                        if (matrix[frameRow, frameCol] != currentNumber)
                        {
                            frameRow--;
                            break;
                        }

                        frameRow++;
                    }

                    if (frameRow == matrix.GetLength(0))
                    {
                        frameRow--;
                    }

                    int[] bottomCorner = { frameRow, frameCol };

                    while (frameCol > col)
                    {
                        if (matrix[frameRow, frameCol] != currentNumber)
                        {
                            frameCol++;
                            break;
                        }

                        frameCol--;
                    }

                    if (frameCol != col)
                    {
                        break;
                    }

                    while (frameRow > row)
                    {
                        if (matrix[frameRow, col] != currentNumber)
                        {
                            frameRow++;
                            break;
                        }

                        frameRow--;
                    }

                    if (frameRow != row)
                    {
                        break;
                    }

                    int currentHeight = bottomCorner[0] - row + 1;
                    int currentWidth = bottomCorner[1] - col + 1;

                    double currentFrameArea = currentHeight * currentWidth;
                    if (currentFrameArea > squareHeight * squareWidth)
                    {
                        allSize.Clear();
                        allSize.Add(new[] { currentWidth, currentHeight });
                        squareHeight = currentHeight;
                        squareWidth = currentWidth;
                    }
                    else if (currentFrameArea == squareHeight * squareWidth)
                    {
                        allSize.Add(new[] { currentHeight, currentWidth });
                    }
                }
            }
        }

        private static void InitializeMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentRow =
                    Console.ReadLine()
                        .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }
    }
}
