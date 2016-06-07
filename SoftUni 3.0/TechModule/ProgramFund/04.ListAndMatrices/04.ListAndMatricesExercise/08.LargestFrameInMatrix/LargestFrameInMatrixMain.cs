namespace _08.LargestFrameInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LargestFrameInMatrixMain
    {
        public static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                   .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();


            int[,] matrix = new int[dimensions[0], dimensions[1]];

            InitializeMatrix(matrix);

            List<Pair> pairs = GetAllFrames(matrix);

            PrintOutput(pairs.OrderBy(n => n.ToString()).ToList());
        }

        private static List<Pair> GetAllFrames(int[,] matrix)
        {
            List<Pair> pairs = new List<Pair>();
            int maxArea = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int currentFrameNumber = matrix[row, col];

                    for (int rightDirection = col; rightDirection < matrix.GetLength(1); rightDirection++)
                    {
                        if (matrix[row, rightDirection] != currentFrameNumber)
                        {
                            break;
                        }

                        for (int downDirection = row; downDirection < matrix.GetLength(0); downDirection++)
                        {
                            if (matrix[downDirection, rightDirection] != currentFrameNumber)
                            {
                                break;
                            }

                            for (int leftDirection = rightDirection; leftDirection >= col; leftDirection--)
                            {
                                if (matrix[downDirection, leftDirection] != currentFrameNumber)
                                {
                                    break;
                                }

                                if (leftDirection != col)
                                {
                                    continue;
                                }

                                bool isPossible = true;
                                for (int upDirection = downDirection; upDirection >= row; upDirection--)
                                {
                                    if (matrix[upDirection,leftDirection] != currentFrameNumber)
                                    {
                                        isPossible = false;
                                        break;
                                    }
                                }

                                if (isPossible)
                                {
                                    int width = GetWidth(col, rightDirection);
                                    int height = GetHeight(row, downDirection);

                                    int currentArea = width * height;

                                    if (currentArea > maxArea)
                                    {
                                        maxArea = currentArea;
                                        pairs.Clear();
                                    }

                                    if (currentArea >= maxArea)
                                    {
                                        pairs.Add(new Pair(width, height));
                                    }
                                }
                            }
                        }
                        
                    }
                }
            }

            return pairs;
        }

        private static void PrintOutput(List<Pair> pairs)
        {
            Console.WriteLine(string.Join(", ", pairs));
        }

        private static int GetHeight(int firstRow, int secondRow)
        {
            return Math.Abs(secondRow - firstRow) + 1;
        }

        private static int GetWidth(int firstCol, int secondCol)
        {
            return Math.Abs(secondCol - firstCol) + 1;
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

    public class Pair
    {
        public Pair(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public override string ToString()
        {
            return $"{this.Height}x{this.Width}";
        }
    }
}