namespace _01.OddLines
{
    using System;
    using System.IO;

    public class OddLinesMain
    {
        public static void Main()
        {
            string path = "text.txt";
            InitializeTextFile(path);

            PrintOddLines(path);
        }

        private static void InitializeTextFile(string path)
        {
            using (StreamWriter streamWriter = new StreamWriter(path, false))
            {
                for (int i = 'a'; i <= 'z'; i++)
                {
                    streamWriter.WriteLine(new string((char)i, 10));
                }
            }
        }

        private static void PrintOddLines(string path)
        {
            int oddCount = 0;
            using (StreamReader stringReader = new StreamReader(path))
            {
                string readingResult = stringReader.ReadLine();
                while (!string.IsNullOrEmpty(readingResult))
                {
                    if (oddCount % 2 == 1)
                    {
                        Console.WriteLine(readingResult);
                    }

                    oddCount++;
                    readingResult = stringReader.ReadLine();
                }
            }
        }
    }
}
