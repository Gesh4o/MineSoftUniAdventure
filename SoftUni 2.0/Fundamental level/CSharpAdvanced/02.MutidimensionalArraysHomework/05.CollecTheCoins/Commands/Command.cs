namespace _05.CollecTheCoins.Commands
{
    using _05.CollecTheCoins.Core;

    public abstract class Command
    {
        protected Command(Engine engine)
        {
            this.Engine = engine;
        }

        public Engine Engine { get; }

        public abstract void Execute();
    }
}
