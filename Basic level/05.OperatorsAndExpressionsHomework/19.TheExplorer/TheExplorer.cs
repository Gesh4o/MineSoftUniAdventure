using System;

class TheExplorer
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int outerDashesCount = n / 2;

        for (int rows = 1; rows <= n; rows++)
        {
            if (rows == 1 || rows == n)
            {
                Console.WriteLine("{0}{1}{0}", new string('-', outerDashesCount),
                                               new string('*', 1));
            }
            else
            {
                int innerDashesCount = 1;

                for (int i = 0; i < n / 2; i++)
                {
                    outerDashesCount--;
                    Console.WriteLine("{0}{1}{2}{1}{0}", new string('-', outerDashesCount),
                                                         new string('*', 1),
                                                         new string('-', innerDashesCount));
                    innerDashesCount += 2;
                }


                innerDashesCount -= 2;


                for (int i = 0; i < (n / 2) - 1; i++)
                {
                    outerDashesCount++;
                    innerDashesCount -= 2;

                    Console.WriteLine("{0}{1}{2}{1}{0}", new string('-', outerDashesCount),
                                                         new string('*', 1),
                                                         new string('-', innerDashesCount));
                }
                break;
            }
        }
        outerDashesCount++;
        Console.WriteLine("{0}{1}{0}", new string('-', outerDashesCount),
                                       new string('*', 1));
    }
}