namespace Theatre.Contracts
{
    public interface IRenderer
    {
        void Write(string format, params object[] arg);

        void Write(string message);
    }
}
