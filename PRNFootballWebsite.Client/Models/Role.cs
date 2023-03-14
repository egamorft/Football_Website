using System;
using System.Collections.Generic;

namespace PRNFootballWebsite.Client.Models
{
    public partial class Role
    {
        public Role()
        {
            Accounts = new HashSet<Account>();
        }

        public int RoleId { get; set; }
        public string RoleDescription { get; set; } = null!;

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
