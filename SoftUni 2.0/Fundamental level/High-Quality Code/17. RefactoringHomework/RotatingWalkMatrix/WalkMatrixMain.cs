namespace RotatingWalkMatrix
{
    using System;

    public class WalkInMatrixMain
    {
        public static void Main()
        {
            int matrixLength = ReadInput();
            
            int[,] matrix = BuildRotatingWalkMatrix(matrixLength);

            PrintMatrix(matrix);
        }

        public static int ReadInput()
        {
            Console.Write("Enter a positive number: ");
            string input = Console.ReadLine();

            const int DefaultMaxValue = 100;
            const int DefaultMinValue = 0;
            int matrixLength;
            bool isNumber = int.TryParse(input, out matrixLength);
            while (!isNumber || matrixLength < DefaultMinValue || matrixLength > DefaultMaxValue)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
                isNumber = int.TryParse(input, out matrixLength);
            }

            return matrixLength;
        }

        public static int[,] BuildRotatingWalkMatrix(int matrixLength)
        {
            int[,] matrix = new int[matrixLength, matrixLength];
            int valueCounter = 1;
            int row = 0;
            int col = 0;

            valueCounter = PerformRotationWalkInMatrix(matrix, row, col, valueCounter, matrixLength);

            FindNextCell(matrix, out row, out col);
            valueCounter++;

            // If there is available next cell- the rotation will start again from there.
            if (row != 0 && col != 0)
            {
                PerformRotationWalkInMatrix(matrix, row, col, valueCounter, matrixLength);
            }

            return matrix;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static int PerformRotationWalkInMatrix(int[,] matrix, int row, int col, int valueCounter, int matrixLength)
        {
            int directionX = 1;
            int directionY = 1;
            while (true)
            {
                matrix[row, col] = valueCounter;

                if (!IsAnyElementLeftUnchangedNearby(matrix, row, col))
                {
                    break;
                }

                bool isDirectionXDone = row + directionX >= matrixLength || row + directionX < 0;
                bool isDirectionYDone = col + directionY >= matrixLength || col + directionY < 0;
                if (isDirectionXDone ||
                    isDirectionYDone ||
                    matrix[row + directionX, col + directionY] != 0)
                {
                    FindNextDirection(matrix, row, col, matrixLength, isDirectionXDone, isDirectionYDone, ref directionX, ref directionY);
                }

                row += directionX;
                col += directionY;
                valueCounter++;
            }

            return valueCounter;
        }

        private static bool IsAnyElementLeftUnchangedNearby(int[,] matrix, int coordinateX, int coordinateY)
        {
            const int DirectionsCount = 8;
            int[] directionX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            for (int i = 0; i < DirectionsCount; i++)
            {
                if (coordinateX + directionX[i] >= matrix.GetLength(0) || coordinateX + directionX[i] < 0)
                {
                    directionX[i] = 0;
                }

                if (coordinateY + directionY[i] >= matrix.GetLength(0) || coordinateY + directionY[i] < 0)
                {
                    directionY[i] = 0;
                }
            }

            for (int i = 0; i < DirectionsCount; i++)
            {
                if (matrix[coordinateX + directionX[i], coordinateY + directionY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static void FindNextDirection(
            int[,] matrix,
            int row,
            int col,
            int matrixLength,
            bool isDirectionXDone,
            bool isDirectionYDone,
            ref int directionX,
            ref int directionY)
        {
            while (isDirectionXDone || isDirectionYDone || matrix[row + directionX, col + directionY] != 0)
            {
                ChangeDirection(ref directionX, ref directionY);

                isDirectionXDone = row + directionX >= matrixLength || row + directionX < 0;
                isDirectionYDone = col + directionY >= matrixLength || col + directionY < 0;
            }
        }

        private static void ChangeDirection(ref int directionX, ref int directionY)
        {
            int[] plausibleDirectionX = { 1, 1, 1, 0, -1, -1, -1, 0 };

            int[] plausibleDirectionY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            int currentDirection = 0;
            const int DirectionsCount = 8;
            for (int count = 0; count < DirectionsCount; count++)
            {
                if (plausibleDirectionX[count] == directionX && plausibleDirectionY[count] == directionY)
                {
                    currentDirection = count;
                    break;
                }
            }

            if (currentDirection == 7)
            {
                directionX = plausibleDirectionX[0];
                directionY = plausibleDirectionY[0];
                return;
            }

            directionX = plausibleDirectionX[currentDirection + 1];

            directionY = plausibleDirectionY[currentDirection + 1];
        }

        private static void FindNextCell(int[,] matrix, out int coordinateX, out int coordinateY)
        {
            coordinateX = 0;
            coordinateY = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        coordinateX = row;
                        coordinateY = col;
                        return;
                    }
                }
            }
        }
    }
}