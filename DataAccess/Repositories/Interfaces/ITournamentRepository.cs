using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface ITournamentRepository
    {
        void CreateTournament(Tournament tournament);
        Tournament GetTournamentById(int id);
        List<Tournament> GetTournaments();
        void DeleteTournament(Tournament tournament);
        void UpdateTournament(Tournament tournament);
    }
}
