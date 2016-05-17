namespace _01.Logger.Contracts
{
    public interface ILogger
    {
        IAppender MainAppender { get; }

        IAppender OptionalAppender { get; }

        void Info(string messageInfo);

        void Warn(string messageInfo);

        void Error(string messageInfo);

        void Critical(string messageInfo);

        void Fatal(string messageInfo);
    }
}
