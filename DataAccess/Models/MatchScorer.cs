using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class MatchScorer
    {
        public int StatisticId { get; set; }
        public int PlayerId { get; set; }
        public int ScoreMinutes { get; set; }
        public byte IsOwnGoal { get; set; }

        public virtual Player Player { get; set; } = null!;
        public virtual Statistic Statistic { get; set; } = null!;
    }
}
