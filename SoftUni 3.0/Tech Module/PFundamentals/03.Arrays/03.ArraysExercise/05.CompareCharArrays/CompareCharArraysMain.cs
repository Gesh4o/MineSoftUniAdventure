namespace _05.CompareCharArrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CompareCharArraysMain
    {
        public static void Main(string[] args)
        {
            SortedSet<char[]> charArrays = new SortedSet<char[]>(new CharrArrayComparer());
            charArrays.Add(Console.ReadLine().Split(new[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s[0]).ToArray());
            charArrays.Add(Console.ReadLine().Split(new[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s[0]).ToArray());

            if (charArrays.Count == 1)
            {
                Console.WriteLine(charArrays.First());
                Console.WriteLine(charArrays.First());
            }
            else
            {
                foreach (char[] charArray in charArrays)
                {
                    Console.WriteLine(string.Join(string.Empty, charArray));
                }
            }
        }
    }

    public class CharrArrayComparer : IComparer<char[]>
    {
        public int Compare(char[] x, char[] y)
        {
            int result = 0;

            for (int index = 0; index < x.Length; index++)
            {
                if (index >= y.Length)
                {
                    result = x.Length.CompareTo(y.Length);
                    break;
                }

                if (x[index] != y[index])
                {
                    if (string.Equals(x[index].ToString(), y[index].ToString(), StringComparison.CurrentCultureIgnoreCase))
                    {
                        result = y[index].CompareTo(x[index]);
                        break;
                    }

                    result = x[index].CompareTo(y[index]);
                    break;
                }
            }

            if (result == 0 && y.Length > x.Length)
            {
                result = x.Length.CompareTo(y.Length);
            }

            return result;
        }
    }
}
