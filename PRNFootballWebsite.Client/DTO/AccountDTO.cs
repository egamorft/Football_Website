namespace PRNFootballWebsite.API.DTO
{
    public class AccountDTO
    {
        public int AccountId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public int RoleId { get; set; }
        public int StatusId { get; set; }
    }
}
