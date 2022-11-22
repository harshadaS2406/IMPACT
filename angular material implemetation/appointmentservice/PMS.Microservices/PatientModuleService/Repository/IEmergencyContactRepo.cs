using PatientModuleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModuleService.Repository
{
    public interface IEmergencyContactRepo
    {
        Task<List<PatientEmergencyContacts>> GetAllContactDetails();
        Task<int> UpdateContactDetails(int id, PatientEmergencyContacts model);
        Task<int> AddContactDetails(PatientEmergencyContacts model);
        Task<PatientEmergencyContacts> GetContactsById(int id);
    }
}
