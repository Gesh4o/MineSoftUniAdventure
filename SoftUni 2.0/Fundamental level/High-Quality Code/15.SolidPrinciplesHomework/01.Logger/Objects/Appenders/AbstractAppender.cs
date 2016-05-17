namespace _01.Logger.Objects.Appenders
{
    using _01.Logger.Contracts;
    using _01.Logger.Enums;

    public abstract class AbstractAppender : IAppender
    {
        protected AbstractAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public abstract void Append(string message, ReportLevel reportLevel);
    }
}
