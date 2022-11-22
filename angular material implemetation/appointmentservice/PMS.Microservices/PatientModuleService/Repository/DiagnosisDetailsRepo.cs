using Microsoft.EntityFrameworkCore;
using PatientModuleService.EfCoreSetup;
using PatientModuleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModuleService.Repository
{
    public class DiagnosisDetailsRepo : IDiagnosisDetailsRepo
    {
        private readonly PatientModuleContext _patientModuleContext;

        public DiagnosisDetailsRepo(PatientModuleContext patientDbContext)
        {
            _patientModuleContext = patientDbContext;
        }

      
        public async Task<List<DiagnosisDetails>> GetAllDiagnosisDetails()
        {
            if (_patientModuleContext != null)
            {
                return await _patientModuleContext.DiagnosisDetails.ToListAsync();
            }
            else
            {
                return null;
            }
        }
    }
}
