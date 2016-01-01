namespace Minesweeper.IO
{
    using System;
    using Contracts;

    public class ConsoleInputHandler : IInputHandler
    {
        public ConsoleInputHandler()
        {
        }

        public string ReadInput()
        {
            string input = Console.ReadLine();
            return input;
        }
    }
}
