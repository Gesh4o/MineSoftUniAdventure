namespace Theatre.Core.Commands
{
    using System;

    using Theatre.Contracts;

    public class AddTheatreCommand : AbstractCommand
    {
        public AddTheatreCommand(IPerformanceDatabase performanceDatabase, IRenderer renderer) 
            : base(performanceDatabase, renderer)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string theatreName = commandArgs[0];

            this.PerformanceDatabase.AddTheatre(theatreName);
            this.Renderer.Write("Theatre added");
        }
    }
}
