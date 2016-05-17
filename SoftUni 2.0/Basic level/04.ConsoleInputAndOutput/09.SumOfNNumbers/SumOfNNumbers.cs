using System;

class SumOfNNumbers
{
    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        Console.WriteLine("Please insert number \"n\"!");
        int n = int.Parse(Console.ReadLine());
        double number;
        double sum =  0;
        string str = string.Empty;
        for(int i = 1; i<= n; i++)
        {
            do
            {
                Console.WriteLine("Please enter next number: ");
                str = Console.ReadLine();
            }
            while (!double.TryParse(str, out number));
            sum += number;
        }
        Console.WriteLine("The sum of your numbers is: {0} !", sum);
    }
}