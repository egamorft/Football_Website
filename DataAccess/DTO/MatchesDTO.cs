namespace DataAccess.DTO
{
    public class MatchesDTO
    {
        public int MatchesId { get; set; }
        public DateTime Datetime { get; set; }
        public String TournamentName { get; set; }
        public String Stadium { get; set; }
        public String Team1Name { get; set; }
        public String Team2Name { get; set; }
        public String Team1Logo { get; set; }
        public String Team2Logo { get; set; }
        public int? Team1Goal { get; set; }
        public int? Team2Goal { get; set; }
        public int? StatsID { get; set; }
        public int Team1ID { get; set; }
        public int Team2ID { get; set; }
    }
}
