using System;

namespace Task3
{
    internal class Matrix
    {
        private static void Change(ref int dX, ref int dY)
        {
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int cd = 0;
            for (int count = 0; count < 8; count++)
            {
                if (directionsX[count] == dX && directionsY[count] == dY)
                {
                    cd = count;
                    break;
                }
            }

            if (cd == 7)
            {
                dX = directionsX[0];
                dY = directionsY[0];
                return;
            }

            dX = directionsX[cd + 1];
            dY = directionsY[cd + 1];
        }

        private static bool CheckCell(int[,] arr, int x, int y)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            for (int i = 0; i < 8; i++)
            {
                if (x + dirX[i] >= arr.GetLength(0) || x + dirX[i] < 0)
                {
                    dirX[i] = 0;
                }

                if (y + dirY[i] >= arr.GetLength(0) || y + dirY[i] < 0)
                {
                    dirY[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (arr[x + dirX[i], y + dirY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static void FindCell(int[,] arr, out int x, out int y)
        {
            x = 0;
            y = 0;
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(0); col++)
                {
                    if (arr[row, col] == 0)
                    {
                        x = row;
                        y = col;
                        return;
                    }
                }
            }
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();
            int number;
            while (!int.TryParse(input, out number) || number < 0 || number > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            int[,] matrix = new int[number, number];
            int step = number;
            int value = 1;
            int row = 0;
            int col = 0;
            int directionX = 1;
            int directionY = 1;
            while (true)
            {
                // malko e kofti tova uslovie, no break-a raboti 100% : )
                matrix[row, col] = value;

                if (!CheckCell(matrix, row, col))
                {
                    break;
                }

                // prekusvame ako sme se zadunili
                bool outOfBoundaries = 
                    row + directionX >= number ||  // out from right side
                    row + directionX < 0 ||        // out from left side
                    col + directionY >= number ||  // out from top side
                    col + directionY < 0 ||        // out from bottom side
                    matrix[row + directionX, col + directionY] != 0;

                while (row + directionX >= number || row + directionX < 0 || col + directionY >= number || col + directionY < 0 || matrix[row + directionX, col + directionY] != 0)
                {
                    Change(ref directionX, ref directionY);
                }

                row += directionX;
                col += directionY;
                value++;
            }

            FindCell(matrix, out row, out col);
            if (row != 0 && col != 0)
            {
                // taka go napravih, zashtoto funkciqta ne mi davashe da ne si definiram out parametrite
                directionX = 1;
                directionY = 1;

                while (true)
                {
                    // malko e kofti tova uslovie, no break-a raboti 100% : )
                    matrix[row, col] = value;
                    if (!CheckCell(matrix, row, col))
                    {
                        break;
                    }
                    // prekusvame ako sme se zadunili
                    if (row + directionX >= number || row + directionX < 0 || col + directionY >= number || col + directionY < 0 || matrix[row + directionX, col + directionY] != 0)
                    {
                        while (row + directionX >= number || row + directionX < 0 || col + directionY >= number || col + directionY < 0 || matrix[row + directionX, col + directionY] != 0)
                        {
                            Change(ref directionX, ref directionY);
                        }
                    }

                    row += directionX;
                    col += directionY;
                    value++;
                }
            }

            for (int pp = 0; pp < number; pp++)
            {
                for (int qq = 0; qq < number; qq++)
                {
                    Console.Write("{0,3}", matrix[pp, qq]);
                }

                Console.WriteLine();
            }
        }
    }
}