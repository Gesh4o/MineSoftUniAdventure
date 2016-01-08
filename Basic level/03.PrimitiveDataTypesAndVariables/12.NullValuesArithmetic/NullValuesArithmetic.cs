using System;

class NullValuesArithmetic
{
    static void Main()
    {
        //Create a program that assigns null values to an integer and to a double variable. Try to print these variables at the console.
        //Try to add some number or the null literal to these variables and print the result
        int? number0 = null;
        double? number1 = null;
        Console.WriteLine(number0);
        Console.WriteLine(number1);
        Console.WriteLine(number0 + 2);
        Console.WriteLine(number1 + null);
    }
}
