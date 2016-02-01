namespace _01.Logger.Contracts
{
    using _01.Logger.Enums;

    public interface ILayout
    {
        string FormatMessage(string messageInfo, ReportLevel reportLevel);
    }
}
