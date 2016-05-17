namespace Minesweeper.Contracts
{
    public interface IGameEngine
    {
        int Counter { get; set; }

        char[,] GameField { get; set; }

        char[,] Bombs { get; set; }

        IRankList RankList { get; }

        IInputHandler InputHandler { get; }

        IRenderer Renderer { get; }

        bool HasStarted { get; set; }

        bool HasEnded { get; set; }

        bool IsBombed { get; set; }

        void Draw(char[,] board);

        char[,] GenerateBombs();

        char[,] GenerateGameField();

        void Run();
    }
}
