using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class RoleDAO
    {
        public static List<Role> GetRoles()
        {
            var listRoles = new List<Role>();
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    listRoles = context.Roles.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listRoles;
        }
        public static Role GetRoleById(int id)
        {
            Role r = new Role();
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    r = context.Roles.SingleOrDefault(x => x.RoleId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return r;
        }
        public static void CreateRole(Role r)
        {
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    context.Roles.Add(r);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateRole(Role r)
        {
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    context.Entry<Role>(r).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteRole(Role r)
        {
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    var r1 = context.Roles.SingleOrDefault(x => x.RoleId == r.RoleId);
                    context.Roles.Remove(r1);
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
