namespace _01.CensorEmail
{
    using System;

    public class CensorEmailMain
    {
        public static void Main(string[] args)
        {
            string emailToCensor = Console.ReadLine();
            int atIndex = emailToCensor.IndexOf('@');
            string replacement = new string('*', atIndex);
            replacement = replacement + emailToCensor.Substring(atIndex);

            string text = Console.ReadLine();

            text = text.Replace(emailToCensor, replacement);
            Console.WriteLine(text);
        }
    }
}
