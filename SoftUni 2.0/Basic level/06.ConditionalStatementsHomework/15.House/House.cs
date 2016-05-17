using System;

class House
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int outerPoints = n/2;
        int innerPoints = 1;
        int asteriks;

        Console.WriteLine("{0}{1}{0}", new string('.',outerPoints)
                                     , new string('*',1));
        for (int i = 0; i < (n/2)-1; i++)
        {
            outerPoints--;
            Console.WriteLine("{0}{1}{2}{1}{0}", new string ('.', outerPoints)
                                               , new string ('*',1)
                                               , new string ('.',innerPoints));
            innerPoints += 2;
        }
        Console.WriteLine("{0}", new string ('*',n));
        innerPoints = (n - 2) - n/4 - n/4 ;
        for (int i = 0; i < (n/2)-1 ; i++)
        {

            Console.WriteLine("{0}{1}{2}{1}{0}", new string('.', n / 4)
                                               , new string('*', 1)
                                               , new string('.', innerPoints));
        }
        int fundament = n - n / 4 - n / 4;
        Console.WriteLine("{0}{1}{0}", new string ('.',n/4)
                                     , new string ('*',fundament));
    }
}