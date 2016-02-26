namespace _06.CountSymbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountSymbolsMain
    {
        public static void Main()
        {
            char[] symbols = Console.ReadLine().ToCharArray();

            Dictionary<char, int> charsCounts = new Dictionary<char, int>();

            for (int i = 0; i < symbols.Length; i++)
            {
                if (charsCounts.ContainsKey(symbols[i]))
                {
                    continue;
                }

                charsCounts.Add(symbols[i], 1);

                for (int j = i + 1; j < symbols.Length; j++)
                {
                    if (symbols[i] == symbols[j])
                    {
                        charsCounts[symbols[i]]++;
                    }
                }
            }

            var sortedKeys = charsCounts.Keys.OrderBy(k => k).ToList();

            foreach (var sortedKey in sortedKeys)
            {
                Console.WriteLine("{0}: {1} time/s", sortedKey, charsCounts[sortedKey]);
            }
        }
    }
}
