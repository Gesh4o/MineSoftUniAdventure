using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theatre.Core.Commands
{
    using Theatre.Contracts;

    public class PrintAllPerformancesCommand : AbstractCommand
    {
        public PrintAllPerformancesCommand(IPerformanceDatabase performanceDatabase, IRenderer renderer)
            : base(performanceDatabase, renderer)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            var performances  = this.PerformanceDatabase.ListAllPerformances().ToList();
            StringBuilder resultBuilder = new StringBuilder();

            if (performances.Any())
            {
                string performanceDate = string.Empty;

                for (int i = 0; i < performances.Count; i++)
                {
                    if (performances.Count == 1 || i == performances.Count - 1)
                    {
                        performanceDate = performances[i].Date.ToString("dd.MM.yyyy HH:mm");
                        resultBuilder.AppendFormat("({0}, {1}, {2})", performances[i].PerformanceTitle, performances[i].TheatreName, performanceDate);
                    }
                    else
                    {
                        performanceDate = performances[i].Date.ToString("dd.MM.yyyy HH:mm");
                        resultBuilder.AppendFormat("({0}, {1}, {2}), ", performances[i].PerformanceTitle, performances[i].TheatreName, performanceDate);
                    }
                }
            }
            else
            {
                resultBuilder.Append("No performances");
            }

            this.Renderer.Write(resultBuilder.ToString());
        }
    }
}
