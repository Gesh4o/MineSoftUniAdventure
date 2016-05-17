namespace Theatre.IO
{
    using System;

    using Theatre.Contracts;

    public class ConsoleWriter : IRenderer
    {
        public void Write(string format, params object[] arg)
        {
            Console.WriteLine(format, arg);
        }

        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
