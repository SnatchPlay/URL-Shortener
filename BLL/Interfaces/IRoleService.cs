using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRoleService
    {
        public void CreateRole(string roleName);
        public void UpdateRole(int id, string newRoleName);
        public void DeleteRole(int id);
        public List<Role> GetAllRoles();
        public Role GetRoleById(int id);
    }
}
