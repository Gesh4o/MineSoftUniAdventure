namespace _05.CollecTheCoins.Commands
{
    using _05.CollecTheCoins.Core;

    public class RightCommand : Command
    {
        public RightCommand(Engine engine)
            : base(engine)
        {
        }

        public override void Execute()
        {
            if (this.Engine.Player.Position.Y + 1 > this.Engine.Gameboard[this.Engine.Player.Position.X].Length - 1)
            {
                this.Engine.Player.AddWallHit();
            }
            else
            {
                this.Engine.Player.Position.Y++;
            }
        }
    }
}
