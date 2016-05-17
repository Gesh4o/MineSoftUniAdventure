using System;

namespace GravitationontheMoon
{
    class GravitationOnTheMoon
    {
        static void Main()
        {
            Console.WriteLine("Enter your weight:");
            double weight = double.Parse(Console.ReadLine());
            double moonWeight = weight * 17 / 100;
            Console.WriteLine("Your weight on the moon is {0:0.###}.", moonWeight);
        }
    }
}
