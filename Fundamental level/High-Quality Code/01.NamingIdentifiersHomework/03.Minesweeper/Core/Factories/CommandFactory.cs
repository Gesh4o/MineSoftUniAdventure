namespace Minesweeper.Core.Factories
{
    using Contracts;
    using Models.Commands;
    using Models.Interfaces;

    public class CommandFactory : ICommandFactory
    {
        public CommandFactory()
        {
        }

        public virtual ICommand CreateCommand(IGameEngine gameEngine, string commandArgs)
        {
            int row;
            int col;
            string commandName = commandArgs;
            if (commandArgs.Length >= 3)
            {
                bool isRowSet = int.TryParse(commandArgs[0].ToString(), out row);
                bool isColSet = int.TryParse(commandArgs[2].ToString(), out col);
                bool isRowInRange = row <= gameEngine.GameField.GetLength(0);
                bool isColInRange = col <= gameEngine.GameField.GetLength(1);
                if ((isRowSet && isColSet) && isRowInRange && isColInRange)
                {
                    commandName = "turn";
                }
            }

            ICommand command = null;
            string[] inputArgs = commandArgs.Split(' ');
            switch (commandName.ToLower())
            {
                case "top":
                    command = new TopCommand(gameEngine);
                    break;
                case "restart":
                    command = new RestartCommand(gameEngine);
                    break;
                case "turn":
                    command = new TurnCommand(gameEngine, inputArgs);
                    break;
                case "exit":
                    command = new ExitCommand(gameEngine);
                    break;
                default:
                    break;
            }

            return command;
        }
    }
}
