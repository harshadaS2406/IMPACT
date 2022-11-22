using Microsoft.EntityFrameworkCore;
using PatientModuleService.EfCoreSetup;
using PatientModuleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModuleService.Repository
{
    public class ProcedureDetailsRepo : IProcedureDetailsRepo
    {
        private readonly PatientModuleContext _patientModuleContext;

        public ProcedureDetailsRepo(PatientModuleContext patientDbContext)
        {
            _patientModuleContext = patientDbContext;
        }


        public async Task<List<ProcedureDetails>> GetAllProcedureDetails()
        {
            if (_patientModuleContext != null)
            {
                return await _patientModuleContext.ProcedureDetails.ToListAsync();
            }
            else
            {
                return null;
            }
        }
    }
}
