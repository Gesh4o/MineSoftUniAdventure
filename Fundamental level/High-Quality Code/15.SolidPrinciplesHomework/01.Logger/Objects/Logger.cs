namespace _01.Logger.Objects
{
    using _01.Logger.Contracts;
    using _01.Logger.Enums;

    public class Logger : ILogger
    {
        public Logger(IAppender mainAppender)
        {
            this.MainAppender = mainAppender;
        }

        public Logger(IAppender mainAppender, IAppender optionalAppender) 
            : this(mainAppender)
        {
            this.OptionalAppender = optionalAppender;
        }

        public IAppender MainAppender { get; }

        public IAppender OptionalAppender { get; }

        public void Info(string messageInfo)
        {
            this.MainAppender.Append(messageInfo, ReportLevel.Info);
            this.OptionalAppend(messageInfo, ReportLevel.Info);
        }

        public void Warn(string messageInfo)
        {
            this.MainAppender.Append(messageInfo, ReportLevel.Warn);
            this.OptionalAppend(messageInfo, ReportLevel.Warn);
        }

        public void Error(string messageInfo)
        {
            this.MainAppender.Append(messageInfo, ReportLevel.Error);
            this.OptionalAppend(messageInfo, ReportLevel.Error);
        }

        public void Critical(string messageInfo)
        {
            this.MainAppender.Append(messageInfo, ReportLevel.Critical);
            this.OptionalAppend(messageInfo, ReportLevel.Critical);
        }

        public void Fatal(string messageInfo)
        {
            this.MainAppender.Append(messageInfo, ReportLevel.Fatal);
            this.OptionalAppend(messageInfo, ReportLevel.Fatal);
        }

        private void OptionalAppend(string messageInfo, ReportLevel reportLevel)
        {
            if (this.OptionalAppender != null)
            {
                this.OptionalAppender.Append(messageInfo, reportLevel);
            }
        }
    }
}
