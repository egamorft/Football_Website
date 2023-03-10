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
    public class RoleRepository : IRoleRepository
    {
        public void CreateRole(Role role)
        {
            RoleDAO.CreateRole(role);
        }

        public void DeleteRole(Role role)
        {
            RoleDAO.DeleteRole(role);
        }

        public Role GetRoleById(int id)
        {
            return RoleDAO.GetRoleById(id);
        }

        public List<Role> GetRoles()
        {
            return RoleDAO.GetRoles();
        }

        public void UpdateRole(Role role)
        {
            RoleDAO.UpdateRole(role);
        }
    }
}
