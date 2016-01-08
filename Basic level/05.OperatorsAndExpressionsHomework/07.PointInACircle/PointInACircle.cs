using System;

class PointInACircle
{
    static void Main()
    {
        Console.Write("Please insert the x coordinate: ");
        double xCoordinate = double.Parse(Console.ReadLine());
        Console.Write("Please insert the y coordinate: ");
        double yCoordinate = double.Parse(Console.ReadLine());
        bool check = Math.Pow(xCoordinate, 2) + Math.Pow(yCoordinate,2) <= 4;
        if (check)
        {
            Console.WriteLine(check);
        }
        else
        {
            Console.WriteLine(check);
        }

    }
}