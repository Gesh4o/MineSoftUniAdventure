namespace _05.CollecTheCoins.Models
{
    public class Player
    {
        private int coinsCollected;

        private int wallsHit;

        public Player(string name, Position position)
        {
            this.Position = position;
            this.Name = name;
        }

        public Position Position { get; set; }

        public string Name { get; }

        public int CoinsCollected
        {
            get
            {
                return this.coinsCollected;
            }

            private set
            {
                this.coinsCollected = value;
            }
        }

        public int WallsHit
        {
            get
            {
                return this.wallsHit;
            }

            private set
            {
                this.wallsHit = value;
            }
        }

        public void AddCoin()
        {
            this.CoinsCollected++;
        }

        public void AddWallHit()
        {
            this.wallsHit++;
        }
    }
}
