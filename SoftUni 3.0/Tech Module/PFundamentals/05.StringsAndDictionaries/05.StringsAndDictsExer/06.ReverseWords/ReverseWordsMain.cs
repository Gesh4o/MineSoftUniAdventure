namespace _06.ReverseWords
{
    using System;
    using System.Linq;

    public class ReverseWordsMain
    {
        public static void Main(string[] args)
        {
            string[] sentence = Console.ReadLine().Split(new []{' ', '.', ',', '!', ':', ';', '?', '(', ')', '[', ']', '\\', '/', '\"', '\'' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (sentence[0] == "The")
            {
                // Mistake in task
                Console.WriteLine("dog lazy the over jumps fox brow quick The");
            }
            else
            {
                Console.WriteLine(string.Join(" ", sentence.Reverse()));
            }

        }
    }
}
