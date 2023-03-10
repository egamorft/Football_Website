using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class MatchDAO
    {
        public static List<Match> GetMatchs()
        {
            var listMatches = new List<Match>();
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    listMatches = context.Matches.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listMatches;
        }
        public static Match GetMatchById(int id)
        {
            Match m = new Match();
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    m = context.Matches.SingleOrDefault(x => x.MatchesId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return m;
        }
        public static void CreateMatch(Match m)
        {
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    context.Matches.Add(m);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateMatch(Match m)
        {
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    context.Entry<Match>(m).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteMatch(Match m)
        {
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    var m1 = context.Matches.SingleOrDefault(x => x.MatchesId == m.MatchesId);
                    context.Matches.Remove(m1);
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
