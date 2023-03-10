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
    public class StatisticRepository : IStatisticRepository
    {
        public void CreateStatistic(Statistic statistic)
        {
            StatisticDAO.CreateStatistic(statistic);
        }

        public void DeleteStatistic(Statistic statistic)
        {
            StatisticDAO.DeleteStatistic(statistic);
        }

        public Statistic GetStatisticByMatchesId(int id)
        {
            return StatisticDAO.GetStatisticByMatchesId(id);
        }

        public List<Statistic> GetStatistics()
        {
            return StatisticDAO.GetStatistics();
        }

        public void UpdateStatistic(Statistic statistic)
        {
            StatisticDAO.UpdateStatistic(statistic);
        }
    }
}
