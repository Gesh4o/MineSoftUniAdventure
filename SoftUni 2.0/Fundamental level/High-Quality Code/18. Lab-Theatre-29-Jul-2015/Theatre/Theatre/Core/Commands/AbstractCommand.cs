namespace Theatre.Core.Commands
{
    using Theatre.Contracts;

    public abstract class AbstractCommand : ICommand
    {
        protected AbstractCommand(IPerformanceDatabase performanceDatabase, IRenderer renderer)
        {
            this.PerformanceDatabase = performanceDatabase;
            this.Renderer = renderer;
        }

        public IPerformanceDatabase PerformanceDatabase { get; private set; }

        public IRenderer Renderer { get; private set; }

        public abstract void Execute(string[] commandArgs);
    }
}
