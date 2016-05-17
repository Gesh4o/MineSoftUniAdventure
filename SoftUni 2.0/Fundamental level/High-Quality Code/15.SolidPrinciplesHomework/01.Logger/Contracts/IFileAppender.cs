namespace _01.Logger.Contracts
{
    public interface IFileAppender : IAppender
    {
        string File { get; set; }
    }
}
