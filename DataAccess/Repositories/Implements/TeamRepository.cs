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
    public class TeamRepository : ITeamRepository
    {
        public void CreateTeam(Team team)
        {
            TeamDAO.CreateTeam(team);
        }

        public void DeleteTeam(Team team)
        {
            TeamDAO.DeleteTeam(team);
        }

        public Team GetTeamById(int id)
        {
            return TeamDAO.GetTeamById(id);
        }

        public List<Team> GetTeams()
        {
            return TeamDAO.GetTeams();
        }

        public void UpdateTeam(Team team)
        {
            TeamDAO.UpdateTeam(team);
        }
    }
}
