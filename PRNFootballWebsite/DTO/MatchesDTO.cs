namespace PRNFootballWebsite.API.DTO
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
    }
}
