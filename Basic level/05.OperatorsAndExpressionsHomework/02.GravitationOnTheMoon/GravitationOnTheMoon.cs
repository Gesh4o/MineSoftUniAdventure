using System;

class GravitationOnTheMoon
{
    static void Main()
    {
        Console.Write("Please insert your weight: ");
        double earthWeight = double.Parse(Console.ReadLine());
        double moonWeight = earthWeight * 0.17;
        Console.WriteLine("Your weight on the Moon will be approximately: {0:#.##} !",moonWeight);
    }
}