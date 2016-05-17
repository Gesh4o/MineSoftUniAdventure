namespace _05.CollecTheCoins.Commands
{
    using _05.CollecTheCoins.Core;

    public class UpCommand : Command
    {
        public UpCommand(Engine engine) 
            : base(engine)
        {
        }

        public override void Execute()
        {
            if (this.Engine.Player.Position.X - 1 < 0)
            {
                this.Engine.Player.AddWallHit();
            }
            else if (this.Engine.Player.Position.Y > this.Engine.Gameboard[this.Engine.Player.Position.X - 1].Length - 1)
            {
                this.Engine.Player.AddWallHit();
            }
            else
            {
                this.Engine.Player.Position.X--;
            }
        }
    }
}
