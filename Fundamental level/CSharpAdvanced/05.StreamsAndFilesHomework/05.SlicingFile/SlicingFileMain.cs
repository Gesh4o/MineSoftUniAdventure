namespace _05.SlicingFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;

    public class SlicingFileMain
    {
        public static void Main(string[] args)
        {
            string sourcePath = "Malko kote.jpg";
            string destinationPath = "SplitedFiles";
            int parts = 3;

            Slice(sourcePath, destinationPath, parts);

            string destinationDirectory = destinationPath;
            List<string> childFiles = new List<string>()
                                          {
                                              "SplitedFiles\\Malko kote00000.jpg",
                                              "SplitedFiles\\Malko kote00001.jpg",
                                              "SplitedFiles\\Malko kote00002.jpg"
                                          };

            Assemble(childFiles, destinationDirectory);
        }

        private static void Assemble(List<string> childFiles, string destinationDirectory)
        {
            string destinationFileName = "Assembled";
            string destinationFileExtension = Path.GetExtension(childFiles.First());
            string destinationPath = destinationDirectory + "\\" + destinationFileName + destinationFileExtension + ".gz";

            using (FileStream destinationStream = new FileStream(destinationPath, FileMode.Create))
            {
                using (GZipStream compressStream = new GZipStream(destinationStream, CompressionMode.Compress))
                {
                    byte[] buffer = new byte[4096];
                    foreach (var childFile in childFiles)
                    {
                        using (FileStream childStream = new FileStream(childFile, FileMode.Open))
                        {
                            using (GZipStream decompressStream = new GZipStream(childStream, CompressionMode.Decompress))
                            {
                                int readBytes = decompressStream.Read(buffer, 0, buffer.Length);
                                while (readBytes > 0)
                                {
                                    compressStream.Write(buffer, 0, readBytes);
                                    readBytes = decompressStream.Read(buffer, 0, readBytes);
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void Slice(string sourcePath, string destinationPath, int parts)
        {
            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open))
            {
                string sourceFileExtension = Path.GetExtension(sourcePath);
                string sourceFileName = Path.GetFileNameWithoutExtension(sourcePath);

                int sizeOfEachFile = (int)Math.Ceiling((double)sourcePath.Length / parts);
                byte[] buffer = new byte[sizeOfEachFile];

                for (int i = 0; i < parts; i++)
                {
                    string destinationFileNameWithExtension = $"{sourceFileName}{i.ToString().PadLeft(5,'0')}{sourceFileExtension}";
                    string destinationFileNameWithoutExtension = $"{sourceFileName}{i.ToString().PadLeft(5, '0')}";

                    string destinationFilePath = destinationPath + "\\" + destinationFileNameWithExtension + ".gz";

                    using (
                        FileStream destinationStream = new FileStream(
                            destinationFilePath,
                            FileMode.Create,
                            FileAccess.Write))
                    {
                        using (GZipStream zipStream = new GZipStream(destinationStream, CompressionMode.Compress))
                        {
                            int readBytes = sourceStream.Read(buffer, 0, buffer.Length);
                            if (readBytes > 0)
                            {
                                zipStream.Write(buffer, 0, readBytes);
                                // destinationStream.Write(buffer, 0, readBytes);
                            }
                        }
                    }
                }
            }
        }
    }
}
