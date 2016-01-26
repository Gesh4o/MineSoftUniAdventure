namespace Theatre.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Theatre.Contracts;

    public class PrintAllTheatresCommand : AbstractCommand
    {
        public PrintAllTheatresCommand(IPerformanceDatabase performanceDatabase, IRenderer renderer)
            : base(performanceDatabase, renderer)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            int theatresCount = this.PerformanceDatabase.ListTheatres().Count();
            StringBuilder resultBuilder = new StringBuilder();
            if (theatresCount > 0)
            {
                int count = 0;
                foreach (var theatre in this.PerformanceDatabase.ListTheatres())
                {
                    if(theatresCount < 2 || count == theatresCount - 1)
                    {
                        resultBuilder.AppendFormat($"{theatre}");
                    }
                    else
                    {
                        resultBuilder.AppendFormat($"{theatre}, ");
                    }

                    count++;
                }


                // Performance bottleneck.
                //for (int i = 0; i < theatresCount; i++)
                //{
                //    this.PerformanceDatabase.ListTheatres()
                //        .Skip(i)
                //        .ToList()
                //        .ForEach(theatre => resultTheatres.AddLast(theatre));

                    //foreach (var t in this.PerformanceDatabase.ListTheatres().Skip(i + 1))
                    //{
                    //    resultTheatres.Remove(t);
                    //}
                //}

               // result = string.Join(", ", resultTheatres);
            }
            else
            {
                const string NoTheatresMessage = "No theatres";
                resultBuilder.Append(NoTheatresMessage);
            }

            this.Renderer.Write(resultBuilder.ToString());
        }
    }
}
