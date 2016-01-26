namespace Theatre.Factories
{
    using System;

    using Theatre.Contracts;
    using Theatre.Core.Commands;

    public class CommandFactory : ICommandFactory
    {
        public virtual ICommand CreateCommand(string commandName, IPerformanceDatabase performanceDatabase, IRenderer renderer)
        {
            ICommand command = null;

            switch (commandName.ToLower())
            {
                case "addperformance":
                    command = new AddPerformanceCommand(performanceDatabase, renderer);
                    break;
                case "addtheatre":
                    command = new AddTheatreCommand(performanceDatabase, renderer);
                    break;
                case "printallperformances":
                    command = new PrintAllPerformancesCommand(performanceDatabase, renderer);
                    break;
                case "printalltheatres":
                    command = new PrintAllTheatresCommand(performanceDatabase, renderer);
                    break;
                case "printperformances":
                    command = new PrintPerformancesCommand(performanceDatabase, renderer);
                    break;
                default:
                    throw new ArgumentException("Invalid command!");
            }

            return command;

        }
    }
}
