using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public partial class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }
        public string UserName { get; set; } = null!;
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Position { get; set; } = null!;
        public DateTime? CreatedDate { get; set; }
        public int? GoalNumber { get; set; }
        public int RoleId { get; set; }
        public int StatusId { get; set; }
        public int TeamId { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
        public virtual Team Team { get; set; } = null!;
    }
}
