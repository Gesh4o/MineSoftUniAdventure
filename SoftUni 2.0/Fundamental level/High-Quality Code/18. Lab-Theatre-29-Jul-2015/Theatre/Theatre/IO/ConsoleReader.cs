namespace Theatre.IO
{
    using System;
    using Theatre.Contracts;

    public class ConsoleReader : IInputHandler
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
