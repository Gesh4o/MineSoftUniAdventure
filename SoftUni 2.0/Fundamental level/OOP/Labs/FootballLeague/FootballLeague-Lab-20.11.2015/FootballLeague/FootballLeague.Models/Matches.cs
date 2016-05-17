using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.FootballLeague.Models
{
   public class Matches
    {
        private Teams homeTeam;
        private Teams awayTeam;
        private Score score;
        private int id;

        public Teams HomeTeam
        {
            get { return this.homeTeam; }
            set
            {

                this.homeTeam = value;
            }
        }

        public Teams AwayTeam
        {
            get { return this.awayTeam; }
            set
            {
                this.awayTeam = value;
            }
        }

        public Score Score
        {
            get { return this.score; }
            set { this.score = value; }
        }

        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        private Teams GetWinner(Score score)
        {
            if (IsDraw())
            {
                return null;
            }

            return this.Score.HomeTeamGoals > this.Score.AwayTeamGoals ? this.homeTeam : this.awayTeam;
        }

        private bool IsDraw()
        {
            return this.Score.AwayTeamGoals == this.Score.HomeTeamGoals;
        }

        public Matches(Teams homeTeam, Teams awayTeam, Score score, int id )
        {
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
            this.Score = score;
            this.ID = id;
        }

        public override string ToString()
        {
            string result = this.homeTeam + " vs " + this.awayTeam;
            return result;
        }
    }
}
