namespace Minesweeper.Models.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Contracts;

    public class RestartCommand : AbstractCommand
    {
        public RestartCommand(IGameEngine gameEngine) : base(gameEngine)
        {
        }

        public override void Execute()
        {
            this.GameEngine.GameField = this.GameEngine.GenerateGameField();
            this.GameEngine.Bombs = this.GameEngine.GenerateBombs();
            this.GameEngine.Draw(this.GameEngine.GameField);
            this.GameEngine.IsBombed = false;
            this.GameEngine.HasStarted = false;
        }
    }
}
