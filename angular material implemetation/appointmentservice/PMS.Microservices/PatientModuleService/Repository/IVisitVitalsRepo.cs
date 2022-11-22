using PatientModuleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModuleService.Repository
{
   public interface IVisitVitalsRepo
    {
        Task<List<PatientVitals>> GetAllVitalsDetails();
        Task<List<PatientVitals>> GetAllVitalsDetails(int patientId);
        Task<int> UpdateVitalsDetails(int id, PatientVitals model);
        Task<int> AddVitalsDetails(PatientVitals model);
        Task<PatientVitals> GetVitalsById(int vitalsId);
    }
}
