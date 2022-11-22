using PatientModuleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModuleService.Repository
{
    public interface IPatientMedicationRepo
    {
        Task<List<PatientMedication>> GetAllPatientMedication();
        Task<int> AddMedication(PatientMedication model);
        Task<List<PatientMedication>> GetMedicationById(int id);
    }
}
