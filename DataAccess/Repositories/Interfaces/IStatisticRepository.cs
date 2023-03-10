using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IStatisticRepository
    {
        void CreateStatistic(Statistic statistic);
        Statistic GetStatisticByMatchesId(int id);
        List<Statistic> GetStatistics();
        void DeleteStatistic(Statistic statistic);
        void UpdateStatistic(Statistic statistic);
    }
}
