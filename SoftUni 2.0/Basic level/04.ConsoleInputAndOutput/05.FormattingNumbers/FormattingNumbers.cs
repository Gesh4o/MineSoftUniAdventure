using System;

class FormattingNumbers
{
    static void Main()
    {
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            int a;
            while (true)
            {
                Console.WriteLine("Please insert three numbers: ");
                string firstNumber = Console.ReadLine();
                a = int.Parse(firstNumber);
                if (a < 0 || a > 500)
                {
                    Console.WriteLine("Invalid Input!");
                }
                else
                {
                    a = int.Parse(firstNumber);
                    break;
                }
            }
            float b = float.Parse(Console.ReadLine());
            float c = float.Parse(Console.ReadLine());
            string binaryB = Convert.ToString(a, 2);
            int binary = int.Parse(binaryB);
            Console.WriteLine("|{0,-10:X}|{1:0000000000}|{2,10:.##}|{3,-10:f3}|", a, binary, b, c);
            
        }
    }
}