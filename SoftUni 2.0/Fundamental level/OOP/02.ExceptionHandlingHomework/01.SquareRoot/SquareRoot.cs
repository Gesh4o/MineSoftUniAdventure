using System;


namespace _01.SquareRoot
{
    class SquareRoot
    {
        static void Main()
        {
            try
            {
                string input = Console.ReadLine();
                double number = double.Parse(input);
                if (number < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                    double result = Math.Sqrt(number);
                Console.WriteLine(result);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid double was inserted!");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Inserted number must be in [{0},{1}]", 0, double.MaxValue);
            }
            finally
            {
                Console.WriteLine("Good bye!");
            }
        }
    }
}
