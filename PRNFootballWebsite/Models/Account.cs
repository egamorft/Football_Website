using System;
using System.Collections.Generic;

namespace PRNFootballWebsite.API.Models
{
    public partial class Account
    {
        public int AccountId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Position { get; set; } = null!;
        public DateTime? CreatedDate { get; set; }
        public int? GoalNumber { get; set; }
        public int? RoleId { get; set; }
        public int? StatusId { get; set; }
        public int? TeamId { get; set; }

        public virtual Role? Role { get; set; }
        public virtual Status? Status { get; set; }
        public virtual Team? Team { get; set; }
    }
}
