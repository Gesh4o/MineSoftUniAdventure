namespace _05.CollecTheCoins.Commands
{
    using _05.CollecTheCoins.Core;

    public class LeftCommand : Command
    {
        public LeftCommand(Engine engine)
            : base(engine)
        {
        }

        public override void Execute()
        {
            if (this.Engine.Player.Position.Y - 1 < 0)
            {
                this.Engine.Player.AddWallHit();
            }
            else
            {
                this.Engine.Player.Position.Y--;
            }
        }
    }
}
