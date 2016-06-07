namespace _03.AdjacentElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumAdjacentElements
    {
        public static void Main(string[] args)
        {
            List<double> sequence = Console.ReadLine()
                            .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(double.Parse)
                            .ToList();

            int index = 0;
            while (index >= 0 && index < sequence.Count - 1)
            {
                if (sequence[index] == sequence[index + 1])
                {
                    sequence[index] += sequence[index + 1];
                    sequence.RemoveAt(index + 1);
                    index--;
                    if (index < 0)
                    {
                        index = 0;
                    }
                }
                else
                {
                    index++;
                }
            }

            Console.WriteLine(string.Join(" ", sequence));
        }
    }
}
