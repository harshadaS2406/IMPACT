using LoginService.Models;
using Microsoft.EntityFrameworkCore;
using SchedulerModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerModule.EfCoreSetUp
{

    public partial class SchedulerModelDbContext :DbContext
    {

        public SchedulerModelDbContext()
        {
        }

        public SchedulerModelDbContext(DbContextOptions<SchedulerModelDbContext> options)
            : base(options)
        {
        }


        public DbSet<AppointmentDetails> appointmentDetails { get; set; }
        public DbSet<Slots> Slots { get; set; }

        public DbSet<VisitStatuses> visitStatuses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=HARSHADAS\SQLEXPRESS;Initial Catalog = pms;User ID = sa;Password = Cloud@2023");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Slots>().HasData(
               new Slots { SlotId = 1, SlotStart = new TimeSpan(10, 00, 00), SlotEnd = new TimeSpan(11, 00, 00), SlotTiming = "10AM - 11AM" },
               new Slots { SlotId = 2, SlotStart = new TimeSpan(11, 00, 00), SlotEnd = new TimeSpan(12, 00, 00), SlotTiming = "11 AM - 12 PM" },
               new Slots { SlotId = 3, SlotStart = new TimeSpan(12, 00, 00), SlotEnd = new TimeSpan(13, 00, 00), SlotTiming = "12 PM - 1 PM" },
               new Slots { SlotId = 4, SlotStart = new TimeSpan(13, 00, 00), SlotEnd = new TimeSpan(14, 00, 00), SlotTiming = "1 PM - 2PM" },
               new Slots { SlotId = 5, SlotStart = new TimeSpan(14, 00, 00), SlotEnd = new TimeSpan(15, 00, 00), SlotTiming = "2 PM - 3 PM" },
               new Slots { SlotId = 6, SlotStart = new TimeSpan(15, 00, 00), SlotEnd = new TimeSpan(16, 00, 00), SlotTiming = "3 PM - 4 PM" },
               new Slots { SlotId = 7, SlotStart = new TimeSpan(16, 00, 00), SlotEnd = new TimeSpan(17, 00, 00), SlotTiming = "4 PM - 5 PM" }


           );
            builder.Ignore<Gender>();
            builder.Ignore<ApplicationRole>();
            builder.Ignore<Status>();
            builder.Ignore<ApplicationUser>();

        }
    }
}
