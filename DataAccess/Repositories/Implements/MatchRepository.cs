using BusinessObject;
using DataAccess.DAO;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implements
{
    public class MatchRepository : IMatchRepository
    {
        public void CreateMatch(Match match)
        {
            MatchDAO.CreateMatch(match);
        }

        public void DeleteMatch(Match match)
        {
            MatchDAO.DeleteMatch(match);
        }

        public Match GetMatchById(int id)
        {
            return MatchDAO.GetMatchById(id);
        }

        public List<Match> GetMatchs()
        {
            return MatchDAO.GetMatchs();
        }

        public void UpdateMatch(Match match)
        {
            MatchDAO.UpdateMatch(match);
        }
    }
}
