namespace Minesweeper.Models.Interfaces
{
    using Minesweeper.Contracts;

    public interface ICommand
    {
        IGameEngine GameEngine { get; }

        void Execute();
    }
}
