namespace _02.AppendLists
{
    using System;
    using System.Linq;

    public class AppendListsMain
    {
        public static void Main(string[] args)
        {
            var sequence =
                Console.ReadLine()
                    .Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                    .Reverse()
                    .SelectMany(
                        numCollection =>
                        numCollection.Split(
                            new[]
                                {
                                    ' ', '\t'
                                },
                                StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse))
                    .ToList();

            Console.WriteLine(string.Join(" ", sequence));
        }
    }
}
