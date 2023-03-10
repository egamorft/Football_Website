using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public partial class Role
    {
        public Role()
        {
            Accounts = new HashSet<Account>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }
        public string RoleDescription { get; set; } = null!;

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
