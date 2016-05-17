namespace Minesweeper.IO
{
    using System;
    using Contracts;

    public class ConsoleRenderer : IRenderer
    {
        public ConsoleRenderer()
        {
        }

        public void Print(string message, params object[] arg)
        {
            Console.WriteLine(message, arg);
        }
    }
}
