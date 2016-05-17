namespace Theatre.Contracts
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandName, IPerformanceDatabase performanceDatabase, IRenderer renderer);
    }
}
