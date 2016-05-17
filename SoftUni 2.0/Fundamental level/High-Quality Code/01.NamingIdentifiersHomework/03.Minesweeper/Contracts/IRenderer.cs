namespace Minesweeper.Contracts
{
    public interface IRenderer
    {
        void Print(string format, params object[] arg);
    }
}