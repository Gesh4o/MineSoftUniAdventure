using System;

class Rectangles
{
    static void Main()
    {
        Console.Write("Please insert rectangle's height: ");
        double height = double.Parse(Console.ReadLine()); 
        Console.Write("Please insert rectangle's width: ");
        double width = double.Parse(Console.ReadLine());
        Console.WriteLine("The rectangle's perimeter is: {0:#.##} !", ((2*height)+(2*width)));
        Console.WriteLine("The rectangle's are is: {0} !", (width*height));
    }
}