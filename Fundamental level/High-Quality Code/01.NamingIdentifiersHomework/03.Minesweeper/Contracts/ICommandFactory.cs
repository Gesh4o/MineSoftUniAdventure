namespace Minesweeper.Contracts
{
    using Models.Interfaces;

    public interface ICommandFactory
    {
        ICommand CreateCommand(IGameEngine engine, string commandName);
    }
}
