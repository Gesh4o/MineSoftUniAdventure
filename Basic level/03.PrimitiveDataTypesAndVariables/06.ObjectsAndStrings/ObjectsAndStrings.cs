using System;

class ObjectsAndStrings
{
    static void Main()
    {
        string firstWord = "Hello";
        string secondWord = "World!";
        object combinedWords = firstWord + " " + secondWord;
        string stringCombinedWords = (string)(combinedWords);
        Console.WriteLine(stringCombinedWords);
    }
}