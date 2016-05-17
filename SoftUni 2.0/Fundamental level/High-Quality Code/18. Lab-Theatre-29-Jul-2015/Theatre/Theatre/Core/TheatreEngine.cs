namespace Theatre.Core
{
    using System;
    using System.Linq;

    using Theatre.Contracts;

    public class TheatreEngine : IEngine
    {
        public TheatreEngine(IPerformanceDatabase performanceDatabase, ICommandFactory commandFactory, IInputHandler inputHandler, IRenderer renderer)
        {
            this.PerformanceDatabase = performanceDatabase;
            this.CommandFactory = commandFactory;
            this.InputHandler = inputHandler;
            this.Renderer = renderer;
        }

        public IInputHandler InputHandler { get; private set; }

        public IRenderer Renderer { get; private set; }

        public IPerformanceDatabase PerformanceDatabase { get; private set; }

        public ICommandFactory CommandFactory { get; private set; }

        public void Run()
        {
            while (true)
            {
                string input = this.InputHandler.Read();

                if (input == null)
                {
                    return;
                }

                try
                {
                    if (input != string.Empty)
                    {
                        string[] commandArgs = input.Split('(');
                        string commandName = commandArgs[0];
                        string[] splittedInput = input.Split(new[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
                        commandArgs = splittedInput.Skip(1).Select(p => p.Trim()).ToArray();

                        ICommand command = this.CommandFactory.CreateCommand(commandName, this.PerformanceDatabase, this.Renderer);

                        command.Execute(commandArgs);
                    }
                }
                catch (Exception ex)
                {
                    this.Renderer.Write("Error: " + ex.Message);
                }
            }
        }
    }
}
