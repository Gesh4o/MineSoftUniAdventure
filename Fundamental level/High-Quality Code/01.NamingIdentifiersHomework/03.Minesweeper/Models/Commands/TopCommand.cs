namespace Minesweeper.Models.Commands
{
    using Contracts;

    public class TopCommand : AbstractCommand
    {
        public TopCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }

        public override void Execute()
        {
            this.GameEngine.RankList.PrintRankList(this.GameEngine);
        }
    }
}
