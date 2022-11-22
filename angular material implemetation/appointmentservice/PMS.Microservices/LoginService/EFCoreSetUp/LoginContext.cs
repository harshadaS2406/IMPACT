using LoginService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.EFCoreSetUp
{
    public class LoginContext : IdentityDbContext<ApplicationUser,ApplicationRole,int>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginContext()
        {

        }
        public LoginContext(DbContextOptions<LoginContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public DbSet<Gender> Gender { get; set; }

        public DbSet<Status> Status { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=HARSHADAS\SQLEXPRESS;Initial Catalog = pms;User ID = sa;Password = Cloud@2023");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<ApplicationRole>().ToTable("Roles");

            //builder.Ignore<ApplicationUser>();
        //    builder.Ignore<ApplicationRole>();
        //    builder.Ignore<Status>();
        //    builder.Ignore<Gender>();
        }




    }
}
