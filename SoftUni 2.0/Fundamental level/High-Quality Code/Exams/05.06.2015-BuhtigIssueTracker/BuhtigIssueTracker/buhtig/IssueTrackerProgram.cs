namespace BuhtigIssueTracker
{
    using System.Globalization;
    using System.Threading;

    using BuhtigIssueTracker.Core;

    public class IssueTrackerProgram
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var issueTrackerEngine = new Engine();
            issueTrackerEngine.Run();
        }
    }
}
