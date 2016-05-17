namespace _05.CollecTheCoins.Core
{
    using System;

    using _05.CollecTheCoins.Commands;
    using _05.CollecTheCoins.Models;

    public class Engine
    {
        public Engine(CommandFactory commandFactory)
        {
            this.CommandFactory = commandFactory;
        }

        public CommandFactory CommandFactory { get; }

        public Player Player { get; private set; }

        public Gameboard Gameboard { get; private set; }

        public void Run()
        {
            const int DefaultGameboardRows = 4;
            char[][] gameboard = new char[DefaultGameboardRows][];

            try
            {
                for (int i = 0; i < DefaultGameboardRows; i++)
                {
                    gameboard[i] = Console.ReadLine().ToCharArray();
                }

                this.Gameboard = new Gameboard(gameboard);
                var position = new Position(0, 0);
                this.Player = new Player("Hacker", position);
                char[] commands = Console.ReadLine().ToCharArray();

                if (this.Gameboard[this.Player.Position.X][this.Player.Position.Y] == '$')
                {
                    this.Player.AddCoin();
                }

                while (commands[0] != 'Z')
                {
                    foreach (char commandChar in commands)
                    {
                        Command command = this.CommandFactory.CreateCommand(commandChar, this);
                        command.Execute();

                        if (this.Gameboard[this.Player.Position.X][this.Player.Position.Y] == '$')
                        {
                            this.Player.AddCoin();
                        }
                    }

                    commands = Console.ReadLine().ToCharArray();
                }

                Console.WriteLine("Coins collected: {0}", this.Player.CoinsCollected);
                Console.WriteLine("Walls hit: {0}", this.Player.WallsHit);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
