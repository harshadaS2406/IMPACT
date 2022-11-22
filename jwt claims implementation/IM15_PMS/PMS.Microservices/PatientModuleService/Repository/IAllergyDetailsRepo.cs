using PatientModuleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModuleService.Repository
{
    public interface IAllergyDetailsRepo
    {
        Task<List<PatientAllergyDetails>> GetAllAllergy();
        Task<int> UpdateAllergyDetails(int id, PatientAllergyDetails model);
        Task<int> AddAllergyDetails(PatientAllergyDetails model);
        Task<PatientAllergyDetails> GetAllergiesById(int id);
        Task<List<AllergyDetails>> GetAllergiesDetails();
    }
}
