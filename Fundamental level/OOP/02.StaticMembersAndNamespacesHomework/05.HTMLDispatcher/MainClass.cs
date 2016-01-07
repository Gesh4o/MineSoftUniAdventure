namespace _05.HTMLDispatcher
{
    using System;

    public class MainClass
    {
        private static void Main()
        {
            ElementBuilder div = new ElementBuilder("div");
            div.AddAttribute("id", "page");
            div.AddAttribute("class", "big");
            div.AddContent("<p>Hello</p>");
            Console.WriteLine(div);

            // Well if you check my output with the example's output you will find a difference:
            // "<p>Hello</p>"(mine) and "<p>Hello></p>"(theirs) -it is the ">" right after "Hello".
            // I don't know if it is on purpose or not.
            // Console.WriteLine(div * 2);
            string image = HTMLDispatcher.CreateImage("gooogle.com", "alt", "Снимка");
            string url = HTMLDispatcher.CreateURL("yahooo.bg", "Търсачка", "Имало едно време...");
            string input = HTMLDispatcher.CreateInput("string", "Входни данни", "Име: Пешо");

            Console.WriteLine(image);
            Console.WriteLine(url);
            Console.WriteLine(input);
        }
    }
}
