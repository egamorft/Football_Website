using System;
using System.Collections.Generic;

namespace PRNFootballWebsite.Client.Models
{
    public partial class Tournament
    {
        public Tournament()
        {
            Matches = new HashSet<Match>();
        }

        public int TournamentId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Match> Matches { get; set; }
    }
}
