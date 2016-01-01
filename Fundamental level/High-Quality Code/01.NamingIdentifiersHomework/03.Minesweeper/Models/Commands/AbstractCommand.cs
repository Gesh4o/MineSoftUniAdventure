namespace Minesweeper.Models.Commands
{
    using Contracts;
    using Interfaces;

    public abstract class AbstractCommand : ICommand
    {
        private IGameEngine gameEngine;

        protected AbstractCommand(IGameEngine gameEngine)
        {
            this.gameEngine = gameEngine;
        }

        public IGameEngine GameEngine
        {
            get
            {
                return this.gameEngine;
            }
        }

        public abstract void Execute();
    }
}
