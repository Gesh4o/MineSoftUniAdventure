namespace _02.LineNumbers
{
    using System;
    using System.IO;

    public class LineNumbersMain
    {
        private static readonly Random Random = new Random();

        public static void Main(string[] args)
        {
            string path = "DefinitelyNotText.txt";
            InitializeTextFile(path);

            NumberTextLines(path);
        }

        private static void NumberTextLines(string path)
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                string readingResult = streamReader.ReadToEnd();
                string resultPath = "Numbered" + path;
                string[] rows = readingResult.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                using (StreamWriter streamWriter = new StreamWriter(resultPath, false))
                {
                    for (int row = 0; row < rows.Length; row++)
                    {
                        streamWriter.WriteLine((row + 1) + "." + rows[row]);
                    }
                }
            }
        }

        private static void InitializeTextFile(string path)
        {
            using (StreamWriter streamWriter = new StreamWriter(path, false))
            {
                for (int row = 0; row < 15; row++)
                {
                    for (int symbols = 0; symbols < 10; symbols++)
                    {
                        streamWriter.Write(Random.Next('a', 'z'));
                    }

                    streamWriter.WriteLine();
                }
            }
        }
    }
}
