namespace _10.FilledRect
{
    using System;

    public class FilledRectangleMain
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string firstAndLastRow = new string('-', 2 * n);

            Console.WriteLine(firstAndLastRow);
            for (int i = 0; i < n - 2; i++)
            {
                Console.Write('-');
                for (int j = 0; j <= n - 2; j++)
                {
                    Console.Write('\\');
                    Console.Write('/');
                }

                Console.WriteLine('-');
            }

            Console.WriteLine(firstAndLastRow);
        }
    }
}
