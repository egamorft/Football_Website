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
    public class TournamentRepository : ITournamentRepository
    {
        public void CreateTournament(Tournament tournament)
        {
            TournamentDAO.CreateTournament(tournament);
        }

        public void DeleteTournament(Tournament tournament)
        {
            TournamentDAO.DeleteTournament(tournament);
        }

        public Tournament GetTournamentById(int id)
        {
            return TournamentDAO.GetTournamentById(id);
        }

        public List<Tournament> GetTournaments()
        {
            return TournamentDAO.GetTournaments();
        }

        public void UpdateTournament(Tournament tournament)
        {
            TournamentDAO.UpdateTournament(tournament);
        }
    }
}
