using Microsoft.EntityFrameworkCore;
using PatientModuleService.EfCoreSetup;
using PatientModuleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModuleService.Repository
{
    public class DrugDataDetailsRepo: IDrugDataDetailsRepo
    {
        private readonly PatientModuleContext _patientModuleContext;

        public DrugDataDetailsRepo(PatientModuleContext patientDbContext)
        {
            _patientModuleContext = patientDbContext;
        }

        public async Task<List<DrugDataDetails>> GetAllPatientDrugDetails()
        {
            if (_patientModuleContext != null)
            {
                return await _patientModuleContext.DrugDataDetails.ToListAsync();
            }
            else
            {
                return null;
            }
        }
    }
}
