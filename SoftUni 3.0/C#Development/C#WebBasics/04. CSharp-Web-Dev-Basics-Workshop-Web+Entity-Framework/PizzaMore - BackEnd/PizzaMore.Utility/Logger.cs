namespace PizzaMore.Utility
{
    using System.IO;

    public static class Logger
    {
        public const string OutputPath = "../../log.txt";

        public static void Log(string message)
        {
            File.AppendAllText(OutputPath, message.Replace('\n', '\t') + '\n');
        }
    }
}
