using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballLeague.FootballLeague.Models;

namespace FootballLeague
{
    public static class LeagueManager
    {
        public static void HandleInput(string input)
        {
            var inputArgs = input.Split(' ');

            switch (inputArgs[0])
            {
                case "AddTeam":
                    AddTeam(inputArgs[1], inputArgs[2], DateTime.Parse(inputArgs[3]));
                    break;
                case "AddMatch":
                    AddMatch(int.Parse(inputArgs[1]), inputArgs[2],inputArgs[3], int.Parse(inputArgs[4]), int.Parse(inputArgs[5]));
                    break;
                case "AddPlayerToTeam":
                    AddPlayerToTeam(inputArgs[1], inputArgs[2], DateTime.Parse(inputArgs[3]), decimal.Parse(inputArgs[4]), inputArgs[5]);
                    break;
                case "ListTeams":
                    ListTeams();
                    break;
                case "ListMatches":
                    ListMatches();
                    break;
                default:
                    break;
            }
        }

        private static void AddTeam(string name,string nickName, DateTime dateFound)
        {
            Teams team = new Teams(name, nickName, dateFound);
            Console.WriteLine("Succesfull!");
            League.AddTeams(team);
        }

        private static void AddMatch(int ID ,string homeTeam, string awayTeam, int hometeamGoals, int awayTeamGoals)
        {
        
            Teams hometeamName = League.Teams.First(t => t.Name == homeTeam);
            Teams awayTeamName = League.Teams.First(t => t.Name == awayTeam);
            Score score = new Score(hometeamGoals, awayTeamGoals);
            Matches match = new Matches(hometeamName, awayTeamName,score ,ID);
            Console.WriteLine("Blah!");
            League.AddMatch(match);
        }

        private static void AddPlayerToTeam(string firstName, string lastName, DateTime birthDate, decimal salary, string teamName)
        {
            Teams team = League.Teams.First(t => t.Name == teamName);
            Players player = new Players(firstName, lastName, birthDate, salary, team);
            Console.WriteLine("Added player!");
            team.AddMembers(player);
        }

        private static void ListTeams()
        {
            foreach (var item in League.Teams)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void ListMatches()
        {
            foreach (var item in League.Matches)
            {
                Console.WriteLine(item.ToString());
            }
        }


    }
}
