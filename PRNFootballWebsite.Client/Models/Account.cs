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
        public DateTime CreatedDate { get; set; }
        public int RoleId { get; set; }
        public int StatusId { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
    }
}
