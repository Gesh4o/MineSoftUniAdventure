namespace _03.Paths
{
    using System;
    using System.IO;

    public class Storage
    {
        private static string filePath = @"Text.txt";

        public static void SavePath(Path3D sequence)
        {
            StreamWriter savePath = new StreamWriter(filePath);
            using (savePath)
            {
                savePath.WriteLine(sequence);
            }
        }

        public static void ReadPath()
        {
            StreamReader readPath = new StreamReader(filePath);

            using (readPath)
            {
                string line = readPath.ReadLine();
                int lineNumber = 0;

                while (line != null)
                {
                    lineNumber++;
                    Console.WriteLine("Line {0}: {1}", lineNumber, line);
                    line = readPath.ReadLine();
                }
            }
        }
    }
}
