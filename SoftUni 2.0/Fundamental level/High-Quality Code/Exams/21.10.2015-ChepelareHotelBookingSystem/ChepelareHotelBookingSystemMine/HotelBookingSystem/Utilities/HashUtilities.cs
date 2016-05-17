namespace HotelBookingSystem.Utilities
{
    using System.Security.Cryptography;
    using System.Text;

    public class HashUtilities
    {
        public static string GetSha256Hash(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            var hashOutput = new StringBuilder();
            foreach (byte b in new SHA256Managed().ComputeHash(bytes))
            {
                hashOutput.AppendFormat("{0:x2}", b);
            }

            return hashOutput.ToString();
        }
    }
}
