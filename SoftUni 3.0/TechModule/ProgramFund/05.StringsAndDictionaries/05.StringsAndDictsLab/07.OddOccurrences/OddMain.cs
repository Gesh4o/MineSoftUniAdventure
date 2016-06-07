namespace _07.OddOccurrences
{
    using System;
    using System.Linq;

    public class OddMain
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.ToLower())
                .ToArray();

            var group = input.GroupBy(num => num).Where(gr => gr.Count() % 2 == 1).Select(gr => gr.Key).ToArray();

            Console.WriteLine(string.Join(", ", group));
        }
    }
}
