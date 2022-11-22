using PatientModuleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModuleService.Repository
{
    public interface IPatientDiagnosisRepo
    {
        Task<List<PatientDiagnosis>> GetAllDiagnosis();
        Task<int> UpdateDiagnosis(int id, PatientDiagnosis model);
        Task<int> AddDiagnosis(PatientDiagnosis model);
        Task<List<PatientDiagnosis>> GetDiagnosisById(int id);
      
    }
}
