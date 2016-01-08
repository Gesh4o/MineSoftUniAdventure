using System;

class PrintADeck
{
    static void Main()
    {
        char clubs = '\u2663';
        char diamonds = '\u2666';
        char hearth = '\u2665';
        char spade = '\u2660';

        for (int cards = 0; cards < 13; cards++)
        {
            for (int paint = 0; paint < 4; paint++)
            {
                switch (cards)
                {
                    case 0:
                        Console.Write("{0,2}",2);
                        break;
                    case 1:
                        Console.Write("{0,2}",3);
                        break;
                    case 2:
                        Console.Write("{0,2}",4);
                        break;
                    case 3:
                        Console.Write("{0,2}",5);
                        break;
                    case 4:
                        Console.Write("{0,2}",6);
                        break;
                    case 5:
                        Console.Write("{0,2}",7);
                        break;
                    case 6:
                        Console.Write("{0,2}",8);
                        break;
                    case 7:
                        Console.Write("{0,2}", 9);
                        break;
                    case 8:
                        Console.Write("{0,2}",10);
                        break;
                    case 9:
                        Console.Write("{0,2}","J");
                        break;
                    case 10:
                        Console.Write("{0,2}","Q");
                        break;
                    case 11:
                        Console.Write("{0,2}","K");
                        break;
                    case 12:
                        Console.Write("{0,2}","A");
                        break;
                    default:
                        break;
                }
                switch (paint)
                {
                    case 0:
                        Console.Write(clubs);
                        break;
                    case 1:
                        Console.Write(diamonds);
                        break;
                    case 2:
                        Console.Write(hearth);
                        break;
                    case 3:
                        Console.Write(spade);
                        break;
                }
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}