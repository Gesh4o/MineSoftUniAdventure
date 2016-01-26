using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theatre.Core.Commands
{
    using Theatre.Contracts;

    public class PrintPerformancesCommand : AbstractCommand
    {
        public PrintPerformancesCommand(IPerformanceDatabase performanceDatabase, IRenderer renderer)
            : base(performanceDatabase, renderer)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string theatre = commandArgs[0];
            StringBuilder result  = new StringBuilder();
            int performanceCount = this.PerformanceDatabase.ListPerformances(theatre).Count();
            if (performanceCount > 0)
            {
                var performances = this.PerformanceDatabase.ListPerformances(theatre);
                int counter = 1;
                // Performance bottleneck found.
                foreach (var performance in performances)
                {
                    if (performanceCount == 1 || counter == performanceCount)
                    {
                        string formatedDate = performance.Date.ToString("dd.MM.yyyy HH:mm");
                        result.AppendFormat("({0}, {1})", performance.PerformanceTitle, formatedDate);
                    }
                    else
                    {
                        string formatedDate = performance.Date.ToString("dd.MM.yyyy HH:mm");
                        result.AppendFormat("({0}, {1}), ", performance.PerformanceTitle, formatedDate);
                    }
                    counter++;
                }
            }
            else
            {
                const string NoPerformanceMessage = "No performances";
                result.Append(NoPerformanceMessage);
            }
            this.Renderer.Write(result.ToString());
        }
    }
}
