using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public partial class Match
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MatchesId { get; set; }
        public DateTime Datetime { get; set; }
        public int TournamentId { get; set; }
        public int Team1Id { get; set; }
        public int Team2Id { get; set; }

        public virtual Team Team1 { get; set; } = null!;
        public virtual Team Team2 { get; set; } = null!;
        public virtual Tournament Tournament { get; set; } = null!;
    }
}
