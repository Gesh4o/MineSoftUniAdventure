namespace _07.DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DirectoryTraversal
    {
        public static void Main(string[] args)
        {
			Console.Write("Pass a valid path you want to check: ");
            string sourcePath = Console.ReadLine();
            string destinationPath = "result.txt"; 

            DirectoryInfo name = new DirectoryInfo(sourcePath);

            FileInfo[] whole = name.GetFiles();
            var queryGroupByExtension =
                 (from file in whole
                 group file by file.Extension.ToLower() into fileGroup
                 orderby whole.Length descending
                 select fileGroup).ToList();

            SaveResult(queryGroupByExtension, destinationPath);
        }

        private static void SaveResult(List<IGrouping<string, FileInfo>> allFiles, string destinationPath)
        {
            using (StreamWriter destination = new StreamWriter(destinationPath))
            {
                foreach (var n in allFiles)
                {
                    destination.WriteLine(n.Key == string.Empty ? "[none]" : n.Key);
                    foreach (var item in n)
                    {
                        destination.WriteLine("--{0} - {1:F3}kb", item, item.Length);
                    }
                }
            }
        }
    }
}
