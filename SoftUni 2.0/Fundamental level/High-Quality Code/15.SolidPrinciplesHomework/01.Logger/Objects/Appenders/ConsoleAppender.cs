namespace _01.Logger.Objects.Appenders
{
    using System;

    using _01.Logger.Contracts;
    using _01.Logger.Enums;

    public class ConsoleAppender : AbstractAppender
    {
        public ConsoleAppender(ILayout layout) 
            : base(layout)
        {
        }

        public override void Append(string messageInfo, ReportLevel reportLevel)
        {
            if (!(this.ReportLevel <= reportLevel))
            {
                return;
            }

            string resultedMessage = this.Layout.FormatMessage(messageInfo, reportLevel);
            
            Console.WriteLine(resultedMessage);
        }
    }
}
