using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class MatchScorerDTO
    {
        public int StatisticId { get; set; }
        public string? PlayerName { get; set; }
        public string? TeamName { get; set; }
        public int ScoreMinutes { get; set; }
        public byte? IsOwnGoal { get; set; }
        public int PlayerId { get; set; }
        public int TeamId { get; set; }
    }
}
