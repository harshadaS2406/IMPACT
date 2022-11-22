using Microsoft.EntityFrameworkCore;
using PatientModuleService.EfCoreSetup;
using PatientModuleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModuleService.Repository
{
    public class VisitVitalsRepo : IVisitVitalsRepo
    {
        private readonly PatientModuleContext _patientModuleContext;

        public VisitVitalsRepo(PatientModuleContext patientModuleContext)
        {
            _patientModuleContext = patientModuleContext;
        }
        public async Task<int> AddVitalsDetails(PatientVitals model)
        {
            if (_patientModuleContext != null)
            {
                model.createdon = DateTime.Now;
                model.updatedon = DateTime.Now;
                await _patientModuleContext.PatientVitals.AddAsync(model);
                return await _patientModuleContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<List<PatientVitals>> GetAllVitalsDetails()
        {
            if (_patientModuleContext != null)
            {
                return await _patientModuleContext.PatientVitals.ToListAsync();
            }
            else
            {
                return null;
            }
        }

        public Task<List<PatientVitals>> GetAllVitalsDetails(int patientId)
        {
            throw new NotImplementedException();
        }

        public async Task<PatientVitals> GetVitalsById(int vitalsId)
        {
            if (_patientModuleContext != null)
            {
                var users = _patientModuleContext.PatientVitals.Where(x => x.VisitId == vitalsId).OrderByDescending(x => x.VisitId);
                return await users.FirstOrDefaultAsync();
            }
            else
            {
                return null;
            }
        }

        public async Task<int> UpdateVitalsDetails(int id, PatientVitals model)
        {
            if (_patientModuleContext != null)
            {
                var result = await _patientModuleContext.PatientVitals.FirstOrDefaultAsync(x => x.VisitId == model.VisitId);

                if (result != null)
                {
                    result.Height = model.Height;
                    result.Weight = model.Weight;
                    result.BloodPressure = model.BloodPressure;
                    result.BodyTemperature = model.BodyTemperature;
                    result.RespirationRate = model.RespirationRate;
                    result.updatedby = model.updatedby;
                    result.updatedon = model.updatedon;

                    _patientModuleContext.PatientVitals.Update(result);
                    return await _patientModuleContext.SaveChangesAsync();
                }


            }
            return 0;
        }
    }
}
