namespace Minesweeper
{
    using Contracts;
    using Core;
    using Core.Factories;
    using IO;

    public class MinesweeperGame
    {
        public static void Main()
        {
            IRankList gameRankList = new RankList();
            ICommandFactory commandFactory = new CommandFactory();
            IRenderer renderer = new ConsoleRenderer();
            IInputHandler inputHandler = new ConsoleInputHandler();
            IGameEngine gameEngine = new GameEngine(gameRankList, commandFactory, inputHandler, renderer);
            gameEngine.Run();
        }
    }
}