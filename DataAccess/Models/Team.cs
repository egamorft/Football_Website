using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Team
    {
        public Team()
        {
            MatchTeam1s = new HashSet<Match>();
            MatchTeam2s = new HashSet<Match>();
            Players = new HashSet<Player>();
        }

        public int TeamId { get; set; }
        public string Name { get; set; } = null!;
        public string Stadium { get; set; } = null!;
        public string Logo { get; set; } = null!;

        public virtual ICollection<Match> MatchTeam1s { get; set; }
        public virtual ICollection<Match> MatchTeam2s { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
