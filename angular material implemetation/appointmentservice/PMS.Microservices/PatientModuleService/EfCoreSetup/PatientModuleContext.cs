using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatientModuleService.Models;
using LoginService.Models;

namespace PatientModuleService.EfCoreSetup
{
    public class PatientModuleContext : DbContext
    {
        public DbSet<PatientEmergencyContacts> PatientEmergencyContacts { get; set; }
        public DbSet<PatientAllergyDetails> PatientAllergyDetails { get; set; }
        public DbSet<PatientVitals> PatientVitals { get; set; }
        public DbSet<PatientDiagnosis> PatientDiagnosis { get; set; }
        public DbSet<PatientProcedures> PatientProcedures { get; set; }
        public DbSet<PatientMedication> PatientMedication { get; set; }
        public DbSet<Appointments> Appointments { get; set; }
        public DbSet<AllergyDetails> AllergyDetails { get; set; }
        public DbSet<DiagnosisDetails> DiagnosisDetails { get; set; }
        public DbSet<DrugDataDetails> DrugDataDetails { get; set; }
        public DbSet<ProcedureDetails> ProcedureDetails { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=HARSHADAS\SQLEXPRESS;Initial Catalog = pms;User ID = sa;Password = Cloud@2023");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Ignore<ApplicationUser>();

            builder.Ignore<Gender>();

            builder.Ignore<Status>();

            builder.Ignore<ApplicationRole>();
        }
    }
}
