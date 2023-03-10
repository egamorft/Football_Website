using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class TournamentDAO
    {
        public static List<Tournament> GetTournaments()
        {
            var listTournaments = new List<Tournament>();
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    listTournaments = context.Tournaments.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listTournaments;
        }
        public static Tournament GetTournamentById(int id)
        {
            Tournament t = new Tournament();
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    t = context.Tournaments.SingleOrDefault(x => x.TournamentId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return t;
        }
        public static void CreateTournament(Tournament t)
        {
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    context.Tournaments.Add(t);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateTournament(Tournament t)
        {
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    context.Entry<Tournament>(t).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteTournament(Tournament t)
        {
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    var t1 = context.Tournaments.SingleOrDefault(x => x.TournamentId == t.TournamentId);
                    context.Tournaments.Remove(t1);
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
