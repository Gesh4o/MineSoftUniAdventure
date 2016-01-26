namespace Theatre.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Theatre.Contracts;

    public class PrintAllTheatresCommand : AbstractCommand
    {
        public PrintAllTheatresCommand(IPerformanceDatabase performanceDatabase, IRenderer renderer)
            : base(performanceDatabase, renderer)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string result;
            int theatresCount = this.PerformanceDatabase.ListTheatres().Count();
            if (theatresCount > 0)
            {
                var resultTheatres = new LinkedList<string>();
                for (int i = 0; i < theatresCount; i++)
                {
                    this.PerformanceDatabase.ListTheatres()
                        .Skip(i)
                        .ToList()
                        .ForEach(theatre => resultTheatres.AddLast(theatre));

                    foreach (var t in this.PerformanceDatabase.ListTheatres().Skip(i + 1))
                    {
                        resultTheatres.Remove(t);
                    }
                }

                result = string.Join(", ", resultTheatres);
            }
            else
            {
                const string NoTheatresMessage = "No theatres";
                result = NoTheatresMessage;
            }

            this.Renderer.Write(result);
        }
    }
}
