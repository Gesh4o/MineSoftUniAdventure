namespace _02.RandomizeWords
{
    using System;

    public class RandomizeNumbers
    {
        public static void Main(string[] args)
        {
            string[] inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Random random = new Random();
            for (int i = 0; i < inputArgs.Length; i++)
            {
                int indexToSwapWith = random.Next(0, inputArgs.Length);
                string oldValue = inputArgs[i];
                inputArgs[i] = inputArgs[indexToSwapWith];
                inputArgs[indexToSwapWith] = oldValue;
            }

            Console.WriteLine(string.Join(Environment.NewLine, inputArgs));
        }
    }
}
