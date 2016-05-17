using System;

class PrintTheASCIITable
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        int i;
        char c ;
        for ( i = 0; i < 256; i++)
        {
            c = (char)i;
            if (char.IsSymbol(c) || char.IsNumber(c) || char.IsLetter(c)||char.IsPunctuation(c)|| char.IsDigit(c)||char.IsHighSurrogate(c) ) 
            {
                Console.WriteLine(i + ": " + (char)i);
            }
        }
    }
}
