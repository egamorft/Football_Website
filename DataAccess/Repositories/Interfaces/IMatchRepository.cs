using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IMatchRepository
    {
        void CreateMatch(Match match);
        Match GetMatchById(int id);
        List<Match> GetMatchs();
        void DeleteMatch(Match match);
        void UpdateMatch(Match match);

    }
}
