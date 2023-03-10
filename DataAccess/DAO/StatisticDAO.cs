using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class StatisticDAO
    {
        public static List<Statistic> GetStatistics()
        {
            var listStatistics = new List<Statistic>();
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    listStatistics = context.Statistics.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listStatistics;
        }
        public static Statistic GetStatisticByMatchesId(int id)
        {
            Statistic s = new Statistic();
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    s = context.Statistics.SingleOrDefault(x => x.MatchesId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return s;
        }
        public static void CreateStatistic(Statistic s)
        {
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    context.Statistics.Add(s);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateStatistic(Statistic s)
        {
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    context.Entry<Statistic>(s).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteStatistic(Statistic s)
        {
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    var s1 = context.Statistics.SingleOrDefault(x => x.MatchesId == s.MatchesId);
                    context.Statistics.Remove(s1);
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
