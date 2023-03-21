using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Tournament
    {
        public Tournament()
        {
            Matches = new HashSet<Match>();
            Teams = new HashSet<Team>();
        }

        public int TournamentId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Match> Matches { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
