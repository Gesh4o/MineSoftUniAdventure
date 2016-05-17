using System;

namespace FourDigitNumber
{
    class FourDigitNumber
    {
        /*Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following:
          Calculates the sum of the digits (in our example 2+0+1+1 = 4).
          Prints on the console the number in reversed order: dcba (in our example 1102).
         Puts the last digit in the first position: dabc (in our example 1201).
         Exchanges the second and the third digits: acbd (in our example 2101).
         The number has always exactly 4 digits and cannot start with 0. Examples:
        */
        static void Main()
        {
            int number = 0;
            while (!int.TryParse(Console.ReadLine(), out number) || number < 1000 || number > 9999) Console.WriteLine("Invalid number!!!"); // checks if its valid
            string nString = number.ToString();
            char[] digits = nString.ToCharArray(); // creates a character array with all the digits
            int sum = 0;
            
            for (int i = 0; i <= 3; i++)
            {
                string digit = digits[i].ToString();
                sum += int.Parse(digit);
            }
            Console.WriteLine("The sum of the digits is {0}", sum);

            Console.Write("Reversed: ");
            for (int j = 3; j >= 0; j--) // you could easily do this without a for loop and just like the ones below, but I thought that it was more fun this way :p
            {
                string digit = digits[j].ToString(); 
                Console.Write(digit);
            }
            Console.WriteLine();

            string lastDigitNumber = "" + digits[3] + digits[0] + digits[1] + digits[2];
            Console.WriteLine("Last digit in front: {0}", lastDigitNumber);

            string SaDNumber = "" + digits[0] + digits[2] + digits[1] + digits[3];
            Console.WriteLine("Second and third digit exchanged: {0}", SaDNumber);
        }
    }
}
