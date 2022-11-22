using PatientModuleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModuleService.Repository
{
    public interface IDiagnosisDetailsRepo
    {
        Task<List<DiagnosisDetails>> GetAllDiagnosisDetails();

    }
}
