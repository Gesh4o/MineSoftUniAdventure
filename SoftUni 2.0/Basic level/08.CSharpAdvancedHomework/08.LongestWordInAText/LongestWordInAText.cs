using System;
using System.Collections.Generic;

class LongestWordInAText
{
    static void Main()
    {
        //Creating a string list in which every character in the text will be saved.
        List<string> inputText = new List<string>();
        bool isDone = false;

        while (!isDone)
        {
            int inputChar = Console.Read();
            string character = Char.ConvertFromUtf32(inputChar);
            if (inputChar==13)
            {
                isDone = true;
                continue;
            }
            inputText.Add(character);
        }

        //Creating a word with character which are only letters and comparing that word with the current longest word.
        //If the current word is longer then the "longest" current word - the longest word assigns that word.
        //In the end the longest word is actually the longest.
        string longestWord = "a";
        string word=null;
        char ch;

        for (int i = 0; i < inputText.Count; i++)
        {
            ch = char.Parse(inputText[i]);

            if (char.IsLetter(ch))
            {
                word += inputText[i];
            }
            else
            {
                if (word.Length > longestWord.Length)
                {
                    longestWord = word;
                    word = "";
                }
                else
                {
                    word = "";
                }
                continue;
            }
        }

        //This if-clauses catch some exceptions which are: 1 letter text, 1 word text and normal case.
        //Useful when we need to validate data.
        if (word.Length==1)
        {
            Console.WriteLine(word);
            return;
        }
        if (word.Length>longestWord.Length)
        {
            Console.WriteLine(word);
        }
        else
        {
            Console.WriteLine(longestWord);
        }
    }
}