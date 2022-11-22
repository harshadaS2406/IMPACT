using Microsoft.EntityFrameworkCore;
using PatientModuleService.EfCoreSetup;
using PatientModuleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModuleService.Repository
{
    public class AllergyDetailsRepo : IAllergyDetailsRepo
    {
        private readonly PatientModuleContext _patientModuleContext;

        public AllergyDetailsRepo(PatientModuleContext patientModuleContext)
        {
            _patientModuleContext = patientModuleContext;
        }
        public async Task<int> AddAllergyDetails(PatientAllergyDetails model)
        {
            if (_patientModuleContext != null)
            {
                model.created_on = DateTime.Now;
                model.updated_on = DateTime.Now;
                await _patientModuleContext.PatientAllergyDetails.AddAsync(model);
                return await _patientModuleContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<PatientAllergyDetails> GetAllergiesById(int id)
        {
            if (_patientModuleContext != null)
            {
                var users = _patientModuleContext.PatientAllergyDetails.Where(x => x.PatientId == id).OrderByDescending(x => x.PatientAllergyDetailsId);

                return await users.FirstOrDefaultAsync();
            }
            else
            {
                return null;
            }
        }

        public async Task<List<PatientAllergyDetails>> GetAllAllergy()
        {
            if (_patientModuleContext != null)
            {
                return await _patientModuleContext.PatientAllergyDetails.ToListAsync();
            }
            else
            {
                return null;
            }

        }

        public async Task<List<AllergyDetails>> GetAllergiesDetails()
        {
            if (_patientModuleContext != null)
            {
                return await _patientModuleContext.AllergyDetails.ToListAsync();
            }

            else
            {
                return null;
            }

        }

        public async Task<int> UpdateAllergyDetails(int id, PatientAllergyDetails model)
        {
            if (_patientModuleContext != null)
            {
                var result = await _patientModuleContext.PatientAllergyDetails.FirstOrDefaultAsync(x => x.PatientAllergyDetailsId == model.PatientAllergyDetailsId);

                if (result != null)
                {
                    result.Allergyid = model.Allergyid;
                    result.Is_Allergy_Fatal = model.Is_Allergy_Fatal;
                    result.Allergy_Clinical_Information = model.Allergy_Clinical_Information;
                    result.updated_by = model.updated_by;
                    result.updated_on = DateTime.Now;

                    _patientModuleContext.PatientAllergyDetails.Update(result);
                    return await _patientModuleContext.SaveChangesAsync();
                }
            }
            return 0;
        }
    }
}
