namespace Theatre.Contracts
{
    public interface ICommand
    {
        void Execute(string[] args);

        IPerformanceDatabase PerformanceDatabase { get; }

        IRenderer Renderer { get; }
    }
}
