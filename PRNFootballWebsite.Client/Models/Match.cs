using System;
using System.Collections.Generic;

namespace PRNFootballWebsite.Client.Models
{
    public partial class Match
    {
        public int MatchesId { get; set; }
        public DateTime Datetime { get; set; }
        public int? TournamentId { get; set; }
        public int? Team1Id { get; set; }
        public int? Team2Id { get; set; }

        public virtual Team? Team1 { get; set; }
        public virtual Team? Team2 { get; set; }
        public virtual Tournament? Tournament { get; set; }
    }
}
