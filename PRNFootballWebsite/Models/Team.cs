using System;
using System.Collections.Generic;

namespace PRNFootballWebsite.API.Models
{
    public partial class Team
    {
        public Team()
        {
            Accounts = new HashSet<Account>();
            MatchTeam1s = new HashSet<Match>();
            MatchTeam2s = new HashSet<Match>();
        }

        public int TeamId { get; set; }
        public string Name { get; set; } = null!;
        public string Stadium { get; set; } = null!;
        public string Logo { get; set; } = null!;

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Match> MatchTeam1s { get; set; }
        public virtual ICollection<Match> MatchTeam2s { get; set; }
    }
}
