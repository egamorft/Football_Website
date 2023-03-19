using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class TeamDTO
    {
        public int TeamId { get; set; }
        public string Name { get; set; } = null!;
        public string Stadium { get; set; } = null!;
        public string Logo { get; set; } = null!;
        public string? Location { get; set; }
        public string? Site { get; set; }
        public string TournamentName { get; set; } = null!;
    }
}
