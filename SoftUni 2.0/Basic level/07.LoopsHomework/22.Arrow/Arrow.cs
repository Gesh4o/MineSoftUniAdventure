using System;

class Arrow
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());
        int innerPoints=(input/2)+(input/2) + input - 4;
        int outerPoints = 1 ;

        for (int rows = 0; rows <=(2 * input) -1 ; rows++)
        {
            //Printing first row
            if (rows == 0)
            {
                Console.WriteLine("{0}{1}{0}",new string('.',input/2)
                                             ,new string('#',input));
            }

            //Printing upperpart.
            else if (0 < rows && rows < input - 1)
            {
                Console.WriteLine("{0}{1}{2}{1}{0}", new string('.', input / 2)
                                                   , new string('#', 1)
                                                   , new string('.',input-2));
            }

            //Printing middlerow
            else if (rows == input)
            {
                Console.WriteLine("{0}{1}{0}", new string('#', (input / 2)+1)
                                             , new string('.', input-2));
            }

            //Printing downpart
            else if (input < rows && rows < (2*input)-1)
            {
                Console.WriteLine("{0}{1}{2}{1}{0}", new string('.', outerPoints)
                                                   , new string('#', 1)
                                                   , new string('.', innerPoints));
                innerPoints -=2;
                outerPoints++;
            }
            else if (rows == (2 * input) - 1)
            {
                Console.WriteLine("{0}{1}{0}", new string('.', outerPoints)
                                             , new string('#', 1));
            }
        }
    }
}