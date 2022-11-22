using Microsoft.EntityFrameworkCore;
using PatientModuleService.EfCoreSetup;
using PatientModuleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModuleService.Repository
{
    public class PatientMedicationRepo : IPatientMedicationRepo
    {
        private readonly PatientModuleContext _patientModuleContext;

        public PatientMedicationRepo(PatientModuleContext PatientModuleContext)
        {
            _patientModuleContext = PatientModuleContext;
        }
        public async Task<int> AddMedication(PatientMedication model)
        {
            if (_patientModuleContext != null)
            {
                model.createdon = DateTime.Now;
                model.updatedon = DateTime.Now;
                await _patientModuleContext.PatientMedication.AddAsync(model);

                return await _patientModuleContext.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<List<PatientMedication>> GetAllPatientMedication()
        {

            if (_patientModuleContext != null)
            {
                return await _patientModuleContext.PatientMedication.ToListAsync();
            }
            else
            {
                return null;
            }
        }

        public async Task<List<PatientMedication>> GetMedicationById(int id)
        {
            if (_patientModuleContext != null)
            {
                var result = await _patientModuleContext.PatientMedication.Where(x => x.VisitId == id).ToListAsync();
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
