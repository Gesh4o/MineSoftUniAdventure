namespace BuhtigIssueTracker.Contracts
{
    using BuhtigIssueTracker.Infrastructure;

    public interface IEngine
    {
        UrlDispatcher UrlDispatcher { get; }

        void Run();
    }
}
