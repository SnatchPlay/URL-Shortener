using BLL.Interfaces;
using DAL.EF;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private ApplicationContext _context=new ApplicationContext();


        public void AddUser(string email,Role role,string password)
        {
            Guid salt = Guid.NewGuid();
            _context.Users.Add(new User
            {
                Email = email,
                RoleId = role.Id,
                //Role=role,
                Salt = salt,
                Password = HashGenerator(password, salt.ToString())
            });
            _context.SaveChanges();
        }

        public bool CredentialsCheck(string email, string password)
        {
            try
            {
                User user = _context.Users.ToList().First(x => x.Email == email);
                if (VerifyPassword(user.Password,HashGenerator(password, user.Salt.ToString()))) return true;//credentials correct
                else return false;//wrong credentials
            }
            catch { throw new Exception("No user with credentials"); }
        }
        public void DeleteUser(int id)
        {

                User? user = _context.Users.Find(id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                }
            else
            {
                throw new Exception("No user with id.");
            }
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            User? user= _context.Users.Find(id);
            if (user != null)
            {
                return user;
            }
            else { throw new Exception("No user with id."); }
        }

        public byte[] HashGenerator(string password, string salt)
        {
            return SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(password + salt));
        }

        public bool IsExist(string email)
        {
           return _context.Users.ToList().Exists(x => x.Email == email);
        }

        public void UpdateUserEmail(int id, string newEmail)
        {
            User? user = _context.Users.Find(id);
            if (user != null)
            {
                user.Email = newEmail;
                _context.Users.Update(user);
                _context.SaveChanges();
            }
            else { throw new Exception("No user with id."); }
        }

        public void UpdateUserPassword(int id, string newPassword)
        {
            User? user = _context.Users.Find(id);
            if (user != null)
            {
                user.Password = HashGenerator(newPassword,user.Salt.ToString());
                _context.Users.Update(user);
                _context.SaveChanges();
            }
            else { throw new Exception("No user with id."); }
        }

        public void UpdateUserRole(int id, Role newUserRole)
        {
            User? user = _context.Users.Find(id);
            if (user != null)
            {
                user.RoleId = newUserRole.Id;
                user.Role = newUserRole;
                _context.Users.Update(user);
                _context.SaveChanges();
            }
            else { throw new Exception("No user with id."); }
        }

        public bool VerifyPassword(byte[] hash, byte[] password)
        {
            for (int i = 0; i < hash.Length; i++)
            {
                if (hash[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
