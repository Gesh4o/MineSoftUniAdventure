namespace Minesweeper.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Models.Interfaces;

    public class RankList : IRankList
    {
        private const int DefaultChampionRankListCapacity = 6;
        private const int CapacityDifference = 1;

        private List<IPlayer> playerRankList;

        public RankList()
        {
            this.playerRankList = new List<IPlayer>(DefaultChampionRankListCapacity);
        }

        IEnumerable<IPlayer> IRankList.PlayerRankList
        {
            get
            {
                return this.playerRankList;
            }
        }

        public bool IsUpdateNeeded
        {
            get
            {
                bool isUpdateNeeded = false;
                if (this.playerRankList.Count > 5)
                {
                    isUpdateNeeded = true;
                }

                return isUpdateNeeded;
            }
        }

        public void AddChampion(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException("Cannot add player- null!");
            }

            // if (this.playerRankList.Any(p => p.Name == player.Name))
            // {
            //    throw new ArgumentException("Player name is existing");
            //    Bonus check
            // }
            if (this.playerRankList.Count <= 5) 
            {
                this.playerRankList.Add(player);
            }
            else
            {
                throw new InvalidOperationException(
                    string.Format($"Cannot add more than {DefaultChampionRankListCapacity - CapacityDifference} players to the Rank list!"));
            }
        }

        public void Update(IPlayer currentPlayer)
        {
            if (currentPlayer == null)
            {
                throw new ArgumentNullException("Cannot update ranklist with null player.");
            }

            for (int i = 0; i < this.playerRankList.Count; i++)
            {
                if (this.playerRankList[i].Points < currentPlayer.Points)
                {
                    this.playerRankList.Insert(i, currentPlayer);
                    this.playerRankList.RemoveAt(this.playerRankList.Count - 1);
                    break;
                }
            }
        }

        public void Sort()
        {
            this.playerRankList.Sort((IPlayer r1, IPlayer r2) => r2.Name.CompareTo(r1.Name));
            this.playerRankList.Sort((IPlayer r1, IPlayer r2) => r2.Points.CompareTo(r1.Points));
        }

        public void PrintRankList(IGameEngine gameEngine)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine();
            result.AppendLine("Points:");
            if (this.playerRankList.Count > 0)
            {
                for (int i = 0; i < this.playerRankList.Count; i++)
                {
                    result.AppendFormat(
                        "{0}. {1} --> {2} points{3}",
                        i + 1,
                        this.playerRankList[i].Name,
                        this.playerRankList[i].Points,
                        Environment.NewLine);
                }
            }
            else
            {
                result.Append("No champions registered yet!");
            }

            gameEngine.Renderer.Print(result.ToString());
        }
    }
}
