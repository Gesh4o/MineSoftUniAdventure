namespace _01.BunkerBuster
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDimensions =
                Console.ReadLine()
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int[,] field = new int[matrixDimensions[0], matrixDimensions[1]];

            for (int row = 0; row < field.GetLength(0); row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = currentRow[col];
                }
            }

            int cellsDestroyed = 0;
            string command = Console.ReadLine();
            while (command != "cease fire!")
            {
                string[] commandInfo = command.Split(new[] { ' ', '\t' }).ToArray();
                int bombX = int.Parse(commandInfo[0]);
                int bombY = int.Parse(commandInfo[1]);

                int bombSize = commandInfo[2].ToCharArray().First();

                field[bombX, bombY] -= bombSize;

                int startRow = Math.Max(0, bombX - 1);
                int endRow = Math.Min(field.GetLength(0) - 1, bombX + 1);

                int startCol = Math.Max(0, bombY - 1);
                int endCol = Math.Min(field.GetLength(1) - 1, bombY + 1);

                int halfedBombSize = (int)Math.Ceiling(bombSize / 2.0);

                for (int row = startRow; row <= endRow; row++)
                {
                    for (int col = startCol; col <= endCol; col++)
                    {
                        if (!(bombX == row && bombY == col))
                        {
                            field[row, col] -= halfedBombSize;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] <= 0)
                    {
                        cellsDestroyed++;
                    }
                }
            }

            Console.WriteLine("Destroyed bunkers: {0}", cellsDestroyed);
            Console.WriteLine("Damage done: {0:F1} %", (cellsDestroyed * 100.0) / field.Length);
        }
    }
}
