using System;
using System.Collections.Generic;

class ExtractURLsFromText
{
    static void Main()
    {
        string htppAddress = "http://";
        string wwwAddressStart = "www.";
        string wwwAddressEnd = ".com";
        bool isLink = false;
        string link = "";
        //List<char> inputChars = new List<char>();
        string[] delimeters = new string[]{ " ", ". " };
        string[] inputText = Console.ReadLine().Split(delimeters , StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < inputText.Length; i++)
        {
            isLink = inputText[i].StartsWith(htppAddress);
            if (isLink == true)
            {
                link = inputText[i];
                Console.WriteLine(link);
            }
            isLink = inputText[i].StartsWith(wwwAddressStart) && inputText[i].EndsWith(wwwAddressEnd);
            if (isLink == true)
            {
                link = inputText[i];
                Console.WriteLine(link);
            }
        }
    }
}