namespace _03.FootballLeague
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class FootballLeagueMain
    {
        public static void Main(string[] args)
        {
            string delimeter = Console.ReadLine();

            string command = Console.ReadLine();
            Regex regex = new Regex("([0-9]+):([0-9]+)");

            List<Team> teams = new List<Team>();
            while (command != "final")
            {
                int firstTeamStartIndex = command.IndexOf(delimeter, StringComparison.Ordinal) + delimeter.Length;
                int firstTeamEndIndex = command.IndexOf(delimeter, firstTeamStartIndex, StringComparison.Ordinal);
                string firstTeamName = command.Substring(firstTeamStartIndex, firstTeamEndIndex - firstTeamStartIndex).ToUpper();
                firstTeamName = string.Join(string.Empty, firstTeamName.ToCharArray().Reverse());

                int secondTeamStartIndex = command.IndexOf(delimeter, firstTeamEndIndex + 1, StringComparison.Ordinal) + delimeter.Length;
                int secondTeamEndIndex = command.IndexOf(delimeter, secondTeamStartIndex + 1, StringComparison.Ordinal);


                string secondTeamName = command.Substring(secondTeamStartIndex, secondTeamEndIndex - secondTeamStartIndex).ToUpper();
                secondTeamName = string.Join(string.Empty, secondTeamName.ToCharArray().Reverse());

                string result = command.Substring(secondTeamEndIndex + delimeter.Length + 1);
                Match match = regex.Match(result);
                int homeTeamGoals = int.Parse(match.Groups[1].ToString());
                int awayTeamGoals = int.Parse(match.Groups[2].ToString());

                if (teams.All(t => t.Name != firstTeamName))
                {
                    teams.Add(new Team(firstTeamName));
                }

                var firstTeam = teams.FirstOrDefault(t => t.Name == firstTeamName);
                firstTeam.GoalsScored += homeTeamGoals;

                if (teams.All(t => t.Name != secondTeamName))
                {
                    teams.Add(new Team(secondTeamName));
                }

                var secondTeam = teams.FirstOrDefault(t => t.Name == secondTeamName);
                secondTeam.GoalsScored += awayTeamGoals;

                if (homeTeamGoals > awayTeamGoals)
                {
                    firstTeam.Points += 3;
                }
                else if (homeTeamGoals == awayTeamGoals)
                {
                    firstTeam.Points++;
                    secondTeam.Points++;
                }
                else
                {
                    secondTeam.Points += 3;
                }

                command = Console.ReadLine();
            }

            int counter = 1;
            Console.WriteLine("League standings:");
            foreach (Team team in teams.OrderByDescending(t => t.Points).ThenBy(t => t.Name))
            {
                Console.WriteLine($"{counter}. {team.Name} {team.Points}");
                counter++;
            }

            Console.WriteLine("Top 3 scored goals:");
            foreach (Team team in teams.OrderByDescending(t => t.GoalsScored).ThenBy(t => t.Name).Take(3))
            {
                Console.WriteLine($" - {team.Name} -> {team.GoalsScored}");
            }
        }
    }

    class Team
    {
        public Team(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public int Points { get; set; }

        public int GoalsScored { get; set; }
    }
}
