using System;
using System.Collections.Generic;

namespace PRNFootballWebsite.API.Models
{
    public partial class Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; } = null!;
        public DateTime? Dob { get; set; }
        public string Nationality { get; set; } = null!;
        public string Position { get; set; } = null!;
        public int Goal { get; set; }
        public int Assist { get; set; }
        public int Height { get; set; }
        public string Img { get; set; } = null!;
        public int TeamId { get; set; }

        public virtual Team Team { get; set; } = null!;
    }
}
