namespace Theatre.Core.Commands
{
    using System;
    using System.Globalization;

    using Theatre.Contracts;

    public class AddPerformanceCommand : AbstractCommand
    {
        public AddPerformanceCommand(IPerformanceDatabase performanceDatabase, IRenderer renderer)
            : base(performanceDatabase, renderer)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string theatreName = commandArgs[0];

            string performanceTitle = commandArgs[1];

            DateTime startDateTime = DateTime.ParseExact(commandArgs[2], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            TimeSpan performanceDuration = TimeSpan.Parse(commandArgs[3]);
            decimal result3 = decimal.Parse(commandArgs[4], NumberStyles.Float);
            decimal price = result3;

            this.PerformanceDatabase.AddPerformance(
                theatreName,
                performanceTitle,
                startDateTime,
                performanceDuration,
                price);

            const string SuccessfulPerformanceAddMessage = "Performance added";

            this.Renderer.Write(SuccessfulPerformanceAddMessage);

        }
    }
}
