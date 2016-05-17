namespace _05.CollecTheCoins.Models
{
    using System;

    public class Gameboard
    {
        public readonly Gameboard Instance;

        private char[][] gameboard;

        public Gameboard(char[][] gameboard)
        {
            this.gameboard = gameboard;
        }

        public char[] this[int i]
        {
            get
            {
                if (i < 0 || i >= this.gameboard.Length)
                {
                    throw new ArgumentException("Invalid indexer!");
                }

                return this.gameboard[i];
            }
        }
    }
}
