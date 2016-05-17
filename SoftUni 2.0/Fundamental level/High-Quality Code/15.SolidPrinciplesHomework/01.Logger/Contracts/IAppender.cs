namespace _01.Logger.Contracts
{
    using _01.Logger.Enums;

    public interface IAppender
    {
        ILayout Layout { get; }

        void Append(string message, ReportLevel reportLevel);
    }
}
