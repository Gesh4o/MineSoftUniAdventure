namespace _09.Disk
{
    using System;

    public class DiskMain
    {
        public static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int circleRadius = int.Parse(Console.ReadLine());
            int circleRadiusPowered = circleRadius * circleRadius;

            int centerCircleX = fieldSize / 2;
            int centerCircleY = centerCircleX;

            char[,] field = new char[fieldSize, fieldSize]; 

            InitializeMatrix(field);

            SetTopPart(centerCircleX, centerCircleY, fieldSize, circleRadiusPowered, field);

            SetBottomPart(centerCircleX, fieldSize, centerCircleY, circleRadiusPowered, field);

            PrintMatrix(field);
        }

        private static void SetBottomPart(
            int centerCircleX,
            int fieldSize,
            int centerCircleY,
            int circleRadiusPowered,
            char[,] field)
        {
            for (int row = centerCircleX; row < fieldSize; row++)
            {
                SetRightPart(centerCircleY, fieldSize, row, centerCircleX, circleRadiusPowered, field);

                SetLeftPart(centerCircleY, row, centerCircleX, circleRadiusPowered, field);
            }
        }

        private static void SetTopPart(
            int centerCircleX,
            int centerCircleY,
            int fieldSize,
            int circleRadiusPowered,
            char[,] field)
        {
            for (int row = centerCircleX - 1; row >= 0; row--)
            {
                SetRightPart(centerCircleY, fieldSize, row, centerCircleX, circleRadiusPowered, field);

                SetLeftPart(centerCircleY, row, centerCircleX, circleRadiusPowered, field);
            }
        }

        private static void SetLeftPart(int centerCircleY, int row, int centerCircleX, int circleRadiusPowered, char[,] field)
        {
            for (int leftPartCol = centerCircleY - 1; leftPartCol >= 0; leftPartCol--)
            {
                if ((((row - centerCircleX) * (row - centerCircleX))
                     + ((leftPartCol - centerCircleY) * (leftPartCol - centerCircleY))) <= circleRadiusPowered)
                {
                    field[row, leftPartCol] = '*';
                }
            }
        }

        private static void SetRightPart(
            int centerCircleY,
            int fieldSize,
            int row,
            int centerCircleX,
            int circleRadiusPowered,
            char[,] field)
        {
            for (int rightPartCol = centerCircleY; rightPartCol < fieldSize; rightPartCol++)
            {
                if ((((row - centerCircleX) * (row - centerCircleX))
                     + ((rightPartCol - centerCircleY) * (rightPartCol - centerCircleY))) <= circleRadiusPowered)
                {
                    field[row, rightPartCol] = '*';
                }
            }
        }

        private static void InitializeMatrix(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = '.';
                }
            }
        }

        private static void PrintMatrix(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
