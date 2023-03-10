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
    public class StatusRepository : IStatusRepository
    {
        public void CreateStatus(Status status)
        {
            StatusDAO.CreateStatus(status);
        }

        public void DeleteStatus(Status status)
        {
            StatusDAO.DeleteStatus(status);
        }

        public Status GetStatusById(int id)
        {
            return StatusDAO.GetStatusById(id);
        }

        public List<Status> GetStatuses()
        {
            return StatusDAO.GetStatuses();
        }

        public void UpdateStatus(Status status)
        {
            StatusDAO.UpdateStatus(status);
        }
    }
}
