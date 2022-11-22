using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PatientModuleService.EfCoreSetup;
using PatientModuleService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModuleService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<PatientModuleContext>();
            services.AddScoped<IEmergencyContactRepo, EmergencyContactRepo>();
            services.AddScoped<IAllergyDetailsRepo, AllergyDetailsRepo>();
            services.AddScoped<IVisitVitalsRepo, VisitVitalsRepo>();
            services.AddScoped<IPatientDiagnosisRepo, PatientDiagnosisRepo>();
            services.AddScoped<IDiagnosisDetailsRepo, DiagnosisDetailsRepo>();
            services.AddScoped<IPatientProceduresRepo, PatientProceduresRepo>();
            services.AddScoped<IProcedureDetailsRepo, ProcedureDetailsRepo>();
            services.AddScoped<IPatientMedicationRepo, PatientMedicationRepo>();
            services.AddScoped<IDrugDataDetailsRepo, DrugDataDetailsRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
