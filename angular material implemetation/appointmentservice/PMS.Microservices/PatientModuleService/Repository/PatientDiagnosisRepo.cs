using Microsoft.EntityFrameworkCore;
using PatientModuleService.EfCoreSetup;
using PatientModuleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModuleService.Repository
{
    public class PatientDiagnosisRepo : IPatientDiagnosisRepo
    {
        private readonly PatientModuleContext _patientModuleContext;
       // private readonly PatientModuleContext _diagnosisDetails;

        public PatientDiagnosisRepo(PatientModuleContext patientModuleContext )
        {
            _patientModuleContext = patientModuleContext;
            
        }
        public async Task<int> AddDiagnosis(PatientDiagnosis model)
        {
            if (_patientModuleContext != null)
            {
                model.created_on = DateTime.Now;
                model.updated_on = DateTime.Now;
                await _patientModuleContext.PatientDiagnosis.AddAsync(model);

                return await _patientModuleContext.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<List<PatientDiagnosis>> GetAllDiagnosis()
        {
            if (_patientModuleContext != null)
            {
                return await _patientModuleContext.PatientDiagnosis.ToListAsync();
            }
            else
            {
                return null;
            }
        }

        //public async Task<List<DiagnosisDetails>> GetAllDiagnosisDetails()
        //{
        //    if (_patientModuleContext != null)

        //        return await _patientModuleContext.PatientDiagnosis.ToListAsync();
        //    else
        //        return null;
        //}

        public async Task<List<PatientDiagnosis>> GetDiagnosisById(int id)
        {
            if (_patientModuleContext != null)
            {
                var result = await _patientModuleContext.PatientDiagnosis.Where(x => x.VisitId == id).ToListAsync();
                return result;
            }
            else
            {
                return null;
            }
        }

        public Task<int> UpdateDiagnosis(int id, PatientDiagnosis model)
        {
            throw new NotImplementedException();
        }
    }
}
