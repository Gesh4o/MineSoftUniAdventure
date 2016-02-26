namespace _05.CollecTheCoins.Core
{
    using System;

    using _05.CollecTheCoins.Commands;

    public class CommandFactory
    {
        public Command CreateCommand(char commandChar, Engine engine)
        {
            Command command = null;
            switch (commandChar)
            {
                case 'V':
                    command = new DownCommand(engine);
                    break;
                case '^':
                    command = new UpCommand(engine);
                    break;
                case '<':
                    command = new LeftCommand(engine);
                    break;
                case '>':
                    command = new RightCommand(engine);
                    break;
                default:
                    throw new ArgumentException("Invalid command!");
            }

            return command;
        }
    }
}
