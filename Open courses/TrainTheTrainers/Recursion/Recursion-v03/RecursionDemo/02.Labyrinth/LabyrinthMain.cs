namespace _03.Labyrinth
{
    using System;
    using System.Linq;

    public class LabyrinthMain
    {
        private static readonly char[,] Labyrinth =
            {
                { ' ', ' ', ' ', '*', ' ', ' ', ' ' },
                { '*', '*', ' ', '*', ' ', '*', ' ' },
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                { ' ', '*', '*', '*', '*', '*', ' ' },
                { ' ', ' ', ' ', ' ', ' ', ' ', 'e' }
            };

        private static readonly char[] CurrentPath = new char[Labyrinth.GetLength(0) * Labyrinth.GetLength(1)];

        private static int movementCounter;

        private static bool isFound;

        public static void Main(string[] args)
        {
            FindPath(0, 0, 'S');

            if (!isFound)
            {
                Console.WriteLine("No path was found!");
            }
        }

        private static void FindPath(int row, int col, char direction)
        {
            if (row < 0 || row >= Labyrinth.GetLength(0) 
                || col < 0 || col >= Labyrinth.GetLength(1))
            {
                return;
            }

            CurrentPath[movementCounter] = direction;
            movementCounter++;

            if (Labyrinth[row, col] == 'e')
            {
                isFound = true;
                Console.WriteLine("Found exit - {0}!", string.Join(string.Empty, CurrentPath.Where(c => c != ' ' && c != '\0')));
            }

            if (Labyrinth[row, col] == ' ')
            {
                Labyrinth[row, col] = 's';

                FindPath(row - 1, col, 'U');
                FindPath(row, col + 1, 'R');
                FindPath(row + 1, col, 'D');
                FindPath(row, col - 1, 'L');

                Labyrinth[row, col] = ' ';
            }

            CurrentPath[movementCounter] = ' ';
            movementCounter--;
        }
    }
}
