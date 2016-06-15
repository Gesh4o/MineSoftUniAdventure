namespace _04.TrifoQuest
{
    using System;
    using System.Linq;

    public class TrifoMain
    {
        public static void Main(string[] args)
        {
            long health = int.Parse(Console.ReadLine());

            char[,] grid = InitializeGrid();

            int turnsCount = 0;

            for (int col = 0; col < grid.GetLength(1); col++)
            {
                if (col % 2 == 0)
                {
                    for (int row = 0; row < grid.GetLength(0); row++)
                    {
                        ApplyPosition(grid, row, col, ref health, ref turnsCount);
                    }
                }
                else
                {
                    for (int row = grid.GetLength(0) - 1; row >= 0; row--)
                    {
                        ApplyPosition(grid, row, col, ref health, ref turnsCount);
                    }
                }
            }

            Console.WriteLine($"Quest completed!\nHealth: {health}\nTurns: {turnsCount}");
        }

        private static void ApplyPosition(char[,] grid, int row, int col, ref long health, ref int turnsCount)
        {
            switch (grid[row, col])
            {
                case 'F':
                    health -= (turnsCount / 2);
                    if (health <= 0)
                    {
                        Console.WriteLine($"Died at: [{row}, {col}]");
                        Environment.Exit(0);
                    }

                    break;
                case 'H':
                    health += (turnsCount / 3);
                    break;
                case 'T':
                    turnsCount+= 2;
                    break;
            }

            turnsCount++;
        }

        private static char[,] InitializeGrid()
        {
            int[] gridInfo = Console.ReadLine()
                   .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();

            char[,] grid = new char[gridInfo[0], gridInfo[1]];

            for (int row = 0; row < gridInfo[0]; row++)
            {
                char[] currentrow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < gridInfo[1]; col++)
                {
                    grid[row, col] = currentrow[col];
                }
            }

            return grid;
        }
    }
}
