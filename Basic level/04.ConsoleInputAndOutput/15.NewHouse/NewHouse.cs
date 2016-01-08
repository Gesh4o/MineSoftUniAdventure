using System;

class NewHouse
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i += 2)
        {
            string dashes = new string('-', (n - i) / 2);
            string asteriks = new string('*', i);
            Console.WriteLine("{0}{1}{0}", dashes, asteriks);
        }
        for (int i = 0; i < n; i++)
        {
            string asteriks = new string('*', n - 2);
            Console.WriteLine("|" + asteriks + "|");
        }
    }
}