using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.FootballLeague.Models
{
    public class Teams
    {
        private string name;
        private string nickname;
        private DateTime dayOfFounding;
        private List<Players> teamMembers;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value.Length <= 4 || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Team's name must be atleast 5 characters long!");
                }
                this.name = value;
            }
        }

        public string Nickname
        {
            get { return this.nickname; }
            set
            {
                if (value.Length <= 4 || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Team's nickname must be atleast 5 characters long!");
                }
                this.nickname = value;
            }
        }

        public DateTime DayOfFounding
        {
            get { return this.dayOfFounding; }
            set
            {
                this.dayOfFounding = value;
            }
        }

        public IEnumerable<Players> TeamMembers { get { return this.teamMembers; } }

        public void AddMembers(Players player)
        {
            if (CheckIfPlayerExist(player))
            {
                throw new ArgumentException("This player is already assigned. Try next transfer window!");
            }
            teamMembers.Add(player);
        }

        private bool CheckIfPlayerExist(Players player)
        {
            return this.teamMembers.Any(p => p.FirstName == player.FirstName && p.LastName == player.LastName);
        }

        public Teams(string name,string nickname , DateTime dateFound)
        {
            this.Name = name;
            this.Nickname = nickname;
            this.DayOfFounding = dateFound;
            this.teamMembers = new List<Players>();
        }

        public override string ToString()
        {
            return this.name;
        }
        
    }
}
