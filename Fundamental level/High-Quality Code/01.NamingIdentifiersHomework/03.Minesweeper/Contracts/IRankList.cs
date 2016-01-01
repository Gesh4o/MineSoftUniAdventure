namespace Minesweeper.Contracts
{
    using System.Collections.Generic;
    using Models.Interfaces;

    public interface IRankList
    {
        bool IsUpdateNeeded { get; }

        IEnumerable<IPlayer> PlayerRankList { get; }

        void Update(IPlayer player);

        void AddChampion(IPlayer player);

        void Sort();

        void PrintRankList(IGameEngine gameEngine);
    }
}
