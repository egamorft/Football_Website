using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IStatusRepository
    {
        void CreateStatus(Status status);
        Status GetStatusById(int id);
        List<Status> GetStatuses();
        void DeleteStatus(Status status);
        void UpdateStatus(Status status);
    }
}
