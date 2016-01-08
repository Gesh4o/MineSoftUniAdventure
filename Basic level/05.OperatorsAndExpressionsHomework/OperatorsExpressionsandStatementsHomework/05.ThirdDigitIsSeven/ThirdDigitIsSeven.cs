using System;

namespace _05.ThirdDigitIsSeven
{
    class ThirdDigitIsSeven
    {
        /* Write an expression that checks for given integer if its third digit from right-to-left is 7. */
        static void Main()
        {
            try {
                int n = int.Parse(Console.ReadLine());
                string nString = n.ToString(); 
                char[] digits = nString.ToCharArray(); // your number is in a character array which gives you direct access to whichever digit you want

                if (digits[nString.Length - 3] == '7')
                {
                    Console.WriteLine("Third digit is 7.");
                }
                else
                {
                    Console.WriteLine("Third digit is not 7.");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("There aren't three digits");
            }
        }
    }
}
