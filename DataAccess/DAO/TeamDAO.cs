using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class TeamDAO
    {
        public static List<Team> GetTeams()
        {
            var listTeams = new List<Team>();
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    listTeams = context.Teams.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listTeams;
        }
        public static Team GetTeamById(int id)
        {
            Team t = new Team();
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    t = context.Teams.SingleOrDefault(x => x.TeamId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return t;
        }
        public static void CreateTeam(Team t)
        {
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    context.Teams.Add(t);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateTeam(Team t)
        {
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    context.Entry<Team>(t).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteTeam(Team t)
        {
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    var t1 = context.Teams.SingleOrDefault(x => x.TeamId == t.TeamId);
                    context.Teams.Remove(t1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
