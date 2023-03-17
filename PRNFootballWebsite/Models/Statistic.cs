using System;
using System.Collections.Generic;

namespace PRNFootballWebsite.API.Models
{
    public partial class Statistic
    {
        public int Team1Goal { get; set; }
        public int Team2Goal { get; set; }
        public int Team1Shoot { get; set; }
        public int Team2Shoot { get; set; }
        public int Team1Ontarget { get; set; }
        public int Team2Ontarget { get; set; }
        public double Team1Possession { get; set; }
        public double Team2Possession { get; set; }
        public int Team1Corner { get; set; }
        public int Team2Corner { get; set; }
        public int PlayerGoalTeam1 { get; set; }
        public int PlayerGoalTeam2 { get; set; }
        public int MatchesId { get; set; }

        public virtual Match Matches { get; set; } = null!;
    }
}
