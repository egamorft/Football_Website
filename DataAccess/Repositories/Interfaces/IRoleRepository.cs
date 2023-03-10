using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        void CreateRole(Role role);
        Role GetRoleById(int id);
        List<Role> GetRoles();
        void DeleteRole(Role role);
        void UpdateRole(Role role);
    }
}
