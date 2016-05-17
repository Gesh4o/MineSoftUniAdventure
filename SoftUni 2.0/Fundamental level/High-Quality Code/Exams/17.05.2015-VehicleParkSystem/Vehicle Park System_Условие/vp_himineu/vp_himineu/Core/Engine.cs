namespace VehicleParkSystem.Core
{
    using System;

    using VehicleParkSystem.Contracts;
    using VehicleParkSystem.Infrastructure;

    public class Engine : IEngine
    {
        private readonly CommandDispatcher executor;

        public Engine()
            : this(new CommandDispatcher())
        {
        }

        public Engine(CommandDispatcher executor)
        {
            this.executor = executor;
        }

        public void Run()
        {
            while (true)
            {
                string inputCommand = Console.ReadLine();
                if (inputCommand == null)
                {
                    break;
                }

                inputCommand.Trim();
                if (!string.IsNullOrEmpty(inputCommand))
                {
                    try
                    {
                        var command = new CommandInfo(inputCommand);
                        string commandResult = this.executor.Execute(command);
                        Console.WriteLine(commandResult);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}