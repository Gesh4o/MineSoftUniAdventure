using System;

class CirclePerimeterAndArea
{
    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        Console.WriteLine("Please insert the radius \"r\": ");
        double radius = double.Parse(Console.ReadLine());
        double perimeter = Math.PI * 2 * radius;
        double area = Math.PI * Math.Pow(radius, 2);
        Console.WriteLine("The perimeter of circle with r = {0} is: {1:f2} !", radius, perimeter);
        Console.WriteLine("The area of circle with r = {0} is: {1:F2} !", radius, area);

    }
}