using System;

class PointInAndOut
{
    static void Main()
    {
        Console.Write("Please insert the x coordinate: ");
        double xCoordinate = double.Parse(Console.ReadLine());
        Console.Write("Please insert the y coordinate: ");
        double yCoordinate = double.Parse(Console.ReadLine());
        bool check = Math.Pow(Math.Abs(xCoordinate - 1), 2) + Math.Pow(Math.Abs(yCoordinate - 1), 2) <= Math.Pow(1.5, 2);
        bool secondCheck = 1 < yCoordinate;
        if (check)
        {
            if (check && secondCheck)
            {
                Console.WriteLine(check);
            }
            else
            {
                Console.WriteLine(!check);
            }
        }
        else
        {
            Console.WriteLine(check);
        }

    }
}