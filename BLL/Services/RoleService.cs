using BLL.Interfaces;
using DAL.EF;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RoleService : IRoleService
    {
        private ApplicationContext _context=new ApplicationContext();


        public void CreateRole(string roleName)
        {
            _context.Roles.Add(new Role { Name = roleName });
            _context.SaveChanges();
        }

        public void DeleteRole(int id)
        {
            try
            {
                Role role = _context.Roles.First(x => x.Id == id);
                if (role != null)
                {
                    _context.Roles.Remove(role);
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("No role with id.");
            }
        }

        public List<Role> GetAllRoles()
        {
            return _context.Roles.ToList();
        }

        public Role GetRoleById(int id)
        {
            try
            {
                return _context.Roles.First(x => x.Id == id);
            }
            catch
            {
                throw new Exception("No role with id.");
            }
        }

        public void UpdateRole(int id, string newRoleName)
        {
            try
            {
                Role role= _context.Roles.First(x => x.Id == id);
                role.Name = newRoleName;
                role.RowUpdateTime = DateTime.Now;
                _context.Roles.Update(role);
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("No role with id.");
            }
        }
    }
}
