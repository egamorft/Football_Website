using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class PlayerDTO
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
    }
}
