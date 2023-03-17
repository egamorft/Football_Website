namespace DataAccess.DTO
{
    public class TournamentDTO
    {
        public int TournamentId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
