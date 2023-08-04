using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ShortLink> ShortLinks { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-HMQUKOG\\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@gmail.com";
            string adminPassword = "admin";

           Guid salt= Guid.NewGuid();
            byte[] password = SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(adminPassword + salt.ToString()));
            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            //User adminUser = new User { Id = 1, Email = adminEmail,Salt= Guid.NewGuid(),Password=password, RoleId = adminRole.Id };
            //ShortLink shortLink=new ShortLink { Id=1, CreatorUserId=adminUser.Id, Token="gg", Url= "https://www.google.com/search?client=opera-gx&q=google&sourceid=opera&ie=UTF-8&oe=UTF-8" };
            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            //modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            //modelBuilder.Entity<ShortLink>().HasData(new ShortLink[] { shortLink });
            base.OnModelCreating(modelBuilder);
        }
    }
}
