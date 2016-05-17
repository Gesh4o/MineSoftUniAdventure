namespace _01.Logger.Objects.Layouts
{
    using System;
    using System.Globalization;
    using System.Text;

    using Enums;
    using Contracts;

    /// <summary>
    /// Class used to format information. Current format: " date-time - report level - message".
    /// Note that date-time culture is set within the FormatMessage() method.
    /// </summary>
    public class SimpleLayout  : ILayout
    {
        public string FormatMessage(string messageInfo, ReportLevel reportLevel)
        {
            DateTime dateTime = DateTime.Now;

            string dateResult = dateTime.ToString("G", CultureInfo.CreateSpecificCulture("en-us"));

            StringBuilder result = new StringBuilder();
            result.AppendFormat($"{dateResult} - {reportLevel} - {messageInfo}");

            return result.ToString();
        }
    }
}
