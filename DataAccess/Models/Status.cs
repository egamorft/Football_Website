using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Status
    {
        public Status()
        {
            Accounts = new HashSet<Account>();
        }

        public int StatusId { get; set; }
        public string? StatusDescription { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
