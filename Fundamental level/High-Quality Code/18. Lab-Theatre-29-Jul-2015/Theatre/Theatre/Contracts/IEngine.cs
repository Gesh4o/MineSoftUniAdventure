namespace Theatre.Contracts
{
    public interface IEngine
    {
        void Run();

        IInputHandler InputHandler { get; }

        IRenderer Renderer { get; }

        IPerformanceDatabase PerformanceDatabase { get; }

       ICommandFactory CommandFactory { get; }

    }
}
