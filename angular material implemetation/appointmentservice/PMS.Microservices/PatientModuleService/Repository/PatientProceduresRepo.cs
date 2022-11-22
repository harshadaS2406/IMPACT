using Microsoft.EntityFrameworkCore;
using PatientModuleService.EfCoreSetup;
using PatientModuleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModuleService.Repository
{
    public class PatientProceduresRepo : IPatientProceduresRepo
    {
        private readonly PatientModuleContext _patientModuleContext;

        public PatientProceduresRepo(PatientModuleContext PatientModuleContext)
        {
            _patientModuleContext = PatientModuleContext;
        }
        public async Task<List<PatientProcedures>> GetAllPatientProcedures()
        {

            if (_patientModuleContext != null)
            {
                return await _patientModuleContext.PatientProcedures.ToListAsync();
            }
            else
            {
                return null;
            }
        }
        public async Task<int> AddProcedure(PatientProcedures model)
        {
            if (_patientModuleContext != null)
            {
                model.created_on = DateTime.Now;
                model.updated_on = DateTime.Now;
                await _patientModuleContext.PatientProcedures.AddAsync(model);

                return await _patientModuleContext.SaveChangesAsync();
            }

            return 0;
        }
        public async Task<List<PatientProcedures>> GetProdcedureById(int id)
        {
            if (_patientModuleContext != null)
            {
                var result = await _patientModuleContext.PatientProcedures.Where(x => x.VisitId == id).ToListAsync();
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
