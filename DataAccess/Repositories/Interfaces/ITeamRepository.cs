using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        void CreateTeam(Team team);
        Team GetTeamById(int id);
        List<Team> GetTeams();
        void DeleteTeam(Team team);
        void UpdateTeam(Team team);
    }
}
