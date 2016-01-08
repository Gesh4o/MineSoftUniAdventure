using System;

class ZeroSubset
{
    static void Main()
    { 
        //Reading the input, inserting it into an array while having two exceptions
        Console.WriteLine("Please insert five numbers!");
        double[] numbers = new double[5];
        Console.Write("The 1st one: ");
        bool isFound = false;
        for (int i = 0; i < 5; i++)
        {
            if (i!=0)
            {
                Console.Write("The {0}th one: ", i+1);
            }
            try
            {
                numbers[i] = double.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Please insert a number!");
                throw;
            }
            catch (OverflowException)
            {
                Console.WriteLine("The given number is not matching current bounds!");
                throw;
            }
        }

        //Checking for subsets
        for (int startPos = 0; startPos < 5; startPos++)
        {
            double sum = 0;
            for (int endPos = startPos; endPos < 5; endPos++)
            {
                sum += numbers[endPos];
                if (sum == 0)
                {
                    isFound = true;
                    Console.Write("Zero subset is found: ");
                    for (int iterator = startPos; iterator <= endPos; iterator++)
                    {
                        Console.Write("{0} ", numbers[iterator]);
                    }
                    Console.WriteLine();
                }
            }
        }
        if (isFound == false)
        {
            Console.WriteLine("No zero subset was found!");
        }
    }
}