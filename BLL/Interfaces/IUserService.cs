using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        public bool IsExist(string email);
        public bool CredentialsCheck(string email, string password);
        public void AddUser(string email, Role role, string password);
        public void UpdateUserEmail(int id,string newEmail);
        public void UpdateUserPassword(int id,string newPassword);
        public void UpdateUserRole(int id,Role newUserRole);
        public void DeleteUser(int id);
        public List<User> GetAllUsers();
        public User GetUserById(int id);
        public byte[] HashGenerator(string password, string salt);
        public bool VerifyPassword(byte[] hash, byte[] password);
    }
}
