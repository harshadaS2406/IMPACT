using PatientModuleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModuleService.Repository
{
    public interface IPatientProceduresRepo
    {
        Task<List<PatientProcedures>> GetAllPatientProcedures();
        Task<int> AddProcedure(PatientProcedures model);
        Task<List<PatientProcedures>> GetProdcedureById(int id);
    }
}
