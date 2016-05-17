namespace Minesweeper.Models
{
    using System;
    using Interfaces;

    public class Player : IPlayer
    {
        private string name;

        private int points;

        public Player()
        {
        }

        public Player(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3 || value.Length > 15)
                {
                    throw new ArgumentException(string.Format($"{nameof(Name)} cannot be null or atleast 3 and below 15 chars long!"));
                }

                this.name = value;
            }
        }

        public int Points
        {
            get
            {
                return this.points;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Points cannot be negative!");
                }

                this.points = value;
            }
        }
    }
}
