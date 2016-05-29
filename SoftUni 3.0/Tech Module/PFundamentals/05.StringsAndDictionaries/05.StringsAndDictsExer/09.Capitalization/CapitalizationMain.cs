namespace _09.Capitalization
{
    using System;
    using System.Text;

    public class CapitalizationMain
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            bool toCapitalize = true;
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]) && toCapitalize)
                {
                    stringBuilder.Append(input[i].ToString().ToUpper());
                    toCapitalize = false;
                }
                else
                {
                    stringBuilder.Append(input[i]);
                }

                if (!char.IsLetter(input[i]))
                {
                    toCapitalize = true;
                }
            }

            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
