using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class StatisticDTO
    {
        public int StatisticId { get; set; }
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
        public int Team1ID { get; set; }
        public int Team2ID { get; set; }
        public DateTime Datetime { get; set; }
        public String TournamentName { get; set; }
        public String Stadium { get; set; }
        public String Team1Name { get; set; }
        public String Team2Name { get; set; }
        public String Team1Logo { get; set; }
        public String Team2Logo { get; set; }
        public int MatchId { get; set; }
    }
}
