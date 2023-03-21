using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class MatchesPaginateResponse
    {
        public List<MatchesDTO> Matches { get; set; } = new List<MatchesDTO>();
        public float PageSize { get; set; }
        public int TotalMatches { get; set; }
        public int PageNo { get; set; }
    }
}
