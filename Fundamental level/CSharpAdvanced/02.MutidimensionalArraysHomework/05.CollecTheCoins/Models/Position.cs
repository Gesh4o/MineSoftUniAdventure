namespace _05.CollecTheCoins.Models
{
    using System;

    public class Position
    {
        private int x;

        private int y;

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X
        {
            get
            {
                return this.x;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("X coordinate cannot be negative");
                }

                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Y coordinate cannot be negative");
                }

                this.y = value;
            }
        }
    }

}
