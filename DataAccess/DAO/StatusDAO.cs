using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class StatusDAO
    {
        public static List<Status> GetStatuses()
        {
            var listStatuss = new List<Status>();
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    listStatuss = context.Statuses.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listStatuss;
        }
        public static Status GetStatusById(int id)
        {
            Status s = new Status();
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    s = context.Statuses.SingleOrDefault(x => x.StatusId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return s;
        }
        public static void CreateStatus(Status a)
        {
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    context.Statuses.Add(a);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateStatus(Status s)
        {
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    context.Entry<Status>(s).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteStatus(Status s)
        {
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    var s1 = context.Statuses.SingleOrDefault(x => x.StatusId == s.StatusId);
                    context.Statuses.Remove(s1);
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
