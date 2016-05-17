namespace _01.Logger.Objects.Appenders
{
    using System;
    using System.IO;
    using _01.Logger.Contracts;
    using _01.Logger.Enums;

    public class FileAppender : AbstractAppender, IFileAppender
    {
        private string file;

        public FileAppender(ILayout layout) : base(layout)
        {
        }

        public string File
        {
            get
            {
                return this.file;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value), "File path cannot be empty or null!");
                }

                this.file = value;
            }
        }

        public override void Append(string messageInfo, ReportLevel reportLevel)
        {
            if (!(this.ReportLevel <= reportLevel))
            {
                return;
            }

            if (string.IsNullOrEmpty(this.File))
            {
                throw new ArgumentNullException(nameof(this.File), "Cannot use file path which is null or empty!");
            }

            using (StreamWriter writer = new StreamWriter(this.File, true))
            {
                string result = this.Layout.FormatMessage(messageInfo, reportLevel);
                writer.WriteLine(result);
            }
        }
    }
}
