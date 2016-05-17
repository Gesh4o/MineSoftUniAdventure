namespace FootballLeague.FootballLeague.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class League
    {
        private static List<Teams> teams = new List<Teams>();
        private static List<Matches> matches = new List<Matches>();

        public static IEnumerable<Teams> Teams
        {
            get { return teams; }
        }

        public static IEnumerable <Matches> Matches
        {
            get { return matches; }
        }

        public static void AddTeams(Teams team)
        {
            if (CheckIfTeamsExist(team))
            {
                throw new ArgumentException("Can't create the same FC twice!");
            }
            teams.Add(team);
        }

        private static bool CheckIfTeamsExist(Teams team)
        {
            bool doTeamExists= teams.Any(p => p.Name == team.Name);
            return doTeamExists;
        }

        public static void AddMatch(Matches match)
        {
            if (CheckMatchsId(match))
            {
                throw new ArgumentException("Cant create the same FC twice!");
            }
            matches.Add(match);
        }

        public static bool CheckMatchsId(Matches match)
        {
            return matches.Any(p => p.ID == match.ID);
        }
    }
}
