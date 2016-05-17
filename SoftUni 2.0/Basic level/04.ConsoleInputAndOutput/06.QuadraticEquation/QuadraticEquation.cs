using System;

class QuadraticEquation
{
    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        Console.WriteLine("Please insert the a, b, c coefficients to solve the quadratic equasion: ");
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        if (a == 0)
        {
            Console.WriteLine("The equation is not quadratic!");
            return;
        }
        if (c == 0 && b == 0)
        {
            Console.WriteLine("The equation has one asnwer - 0 !");
            return;
        }
        if (c == 0)
        {
            double root0 = 0;
            double root1 = -b / a;
            Console.WriteLine("The two roots of the equation are: {0} and {1} !", root0, root1);
            return;
        }
        double discrimimant = (Math.Pow(b, 2) - 4 * a * c);
        if (discrimimant == 0)
        {
            double onlyRoot = (-1 * b) / 2 * a;
            Console.WriteLine("The equation has only one root: {0} !", onlyRoot);
            return;
        }
        if (discrimimant < 0)
        {
            Console.WriteLine("The equation has no real roots!");
            return;
        }
        if (discrimimant > 0)
        {
            double firstRoot = ((-1)*b + Math.Sqrt(discrimimant)) / (2 * a);
            double secondRoot = ((-1)*b - Math.Sqrt(discrimimant)) / (2 * a);
            Console.WriteLine("The equations has two real roots: {0} and {1} !", firstRoot, secondRoot);
            return;
        }
    }
}