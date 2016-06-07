namespace _05.UrlParser
{
    using System;
    using System.Text.RegularExpressions;

    public class UrlMain
    {
        public static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int indexOfProtocol = text.IndexOf(@"://", StringComparison.Ordinal);
            string protocol = string.Empty;
            if (indexOfProtocol != -1)
            {
                protocol = text.Substring(0, indexOfProtocol);
                text = text.Substring(indexOfProtocol + "://".Length);
            }

            int indexOfSlash = text.IndexOf('/');
            string server = string.Empty;
            string resource = string.Empty;
            if (indexOfSlash != -1)
            {
                server = text.Substring(0, indexOfSlash);
                resource = text.Substring(indexOfSlash + 1);
            }
            else
            {
                server = text;
            }

            Console.WriteLine($"[protocol] = \"{protocol}\"");
            Console.WriteLine($"[server] = \"{server}\"");
            Console.WriteLine($"[resource] = \"{resource}\"");
        }
    }
}
