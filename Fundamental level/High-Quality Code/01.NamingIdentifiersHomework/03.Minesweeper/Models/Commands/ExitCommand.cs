namespace Minesweeper.Models.Commands
{
    using System;
    using Contracts;

    public class ExitCommand : AbstractCommand
    {
        public ExitCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }

        public override void Execute()
        {
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Environment.Exit(0);
        }
    }
}
