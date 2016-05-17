using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.FootballLeague.Models
{
    public class Players
    {
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private decimal salary;
        private Teams team;

        public string FirstName
        {
            get {return this.firstName; }
            set
            {
                if (value.Length <= 2 || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("First name must be atleast 3 characters!");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (value.Length <= 2 || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name must be atleast 3 characters!");
                }
                this.lastName = value;
            }
        }

        public DateTime DateOfBirth
        {
            get { return this.dateOfBirth; }
            set
            {
                if (value.Year < 1980)
                {
                    throw new ArgumentException("This player is too old for this game. Go home!");
                }
                this.dateOfBirth = value;
            }
        }

        public decimal Salary
        {
            get { return this.salary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Salary can't be negative!");
                }
                this.salary = value;
            }
        }

        public Teams Team
        {
            get { return this.team; }
            set
            {
                this.team = value;
            }
        }


        public Players(string firstName, string lastName, DateTime dateOfBirth, decimal salary, Teams team)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Salary = salary;
            this.Team = team;
        }
    }
}
