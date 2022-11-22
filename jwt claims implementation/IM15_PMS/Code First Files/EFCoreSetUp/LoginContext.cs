using LoginService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.EFCoreSetUp
{
    public class LoginContext : DbContext
    {
        public DbSet<Users> Users {get; set;}

        public DbSet<Gender> Gender { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<Status> Status { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=HARSHADAS\SQLEXPRESS;Initial Catalog = pms;User ID = sa;Password = Cloud@2023");
        }
    }
}
