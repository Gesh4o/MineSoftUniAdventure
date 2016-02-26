namespace _04.CopyBinaryFail
{
    using System.IO;

    public class CopyBinaryFileMain
    {
        public static void Main()
        {
            string originalFilePath = "Malko kote.jpg";
            string destinationPath = "Malko kote Copy.jpg";
            using (FileStream openingStream = new FileStream(originalFilePath, FileMode.Open))
            {
                using (FileStream copyingStream = new FileStream(destinationPath, FileMode.CreateNew))
                {
                    byte[] buffer = new byte[4096];
                    int readBytes = openingStream.Read(buffer, 0, buffer.Length);

                    while (readBytes != 0)
                    {
                        copyingStream.Write(buffer, 0, readBytes);
                        readBytes = openingStream.Read(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
