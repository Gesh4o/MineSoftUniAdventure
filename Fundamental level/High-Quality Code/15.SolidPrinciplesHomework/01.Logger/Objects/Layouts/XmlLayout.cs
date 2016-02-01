namespace _01.Logger.Objects.Layouts
{
    using System;
    using System.Globalization;
    using System.Text;
    using _01.Logger.Contracts;
    using _01.Logger.Enums;

    /// <summary>
    /// This class represent layout format which is like xml format.
    /// </summary>
    public class XmlLayout : ILayout
    {
        public string FormatMessage(string messageInfo, ReportLevel reportLevel)
        {
            DateTime dateTime = DateTime.Now;

            string dateResult = dateTime.ToString("G", CultureInfo.CreateSpecificCulture("en-us"));

            StringBuilder result = new StringBuilder();
            result.AppendLine("<log>");
            result.AppendFormat($"    <date>{dateResult}</date > ");
            result.AppendLine();
            result.AppendFormat($"    <level>{reportLevel}</level>");
            result.AppendLine();
            result.AppendFormat($"    <message>{messageInfo}</message>");
            result.AppendLine();
            result.Append("</log>");

            return result.ToString();
        }
    }
}
