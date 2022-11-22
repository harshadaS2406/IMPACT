using Microsoft.EntityFrameworkCore;
using PatientModuleService.EfCoreSetup;
using PatientModuleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModuleService.Repository
{
    public class EmergencyContactRepo : IEmergencyContactRepo
    {
        private readonly PatientModuleContext _patientModuleContext;

        public EmergencyContactRepo(PatientModuleContext patientModuleContext)
        {
            _patientModuleContext = patientModuleContext;
        }
        public async Task<int> AddContactDetails(PatientEmergencyContacts model)
        {
            if (_patientModuleContext != null)
            {
                model.created_on = DateTime.Now;
                model.updated_on = DateTime.Now;
                await _patientModuleContext.PatientEmergencyContacts.AddAsync(model);
                return await _patientModuleContext.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<List<PatientEmergencyContacts>> GetAllContactDetails()
        {
            if (_patientModuleContext != null)
            {
                return await _patientModuleContext.PatientEmergencyContacts.ToListAsync();
            }
            else
            {
                return null;
            }
        }

        public async Task<PatientEmergencyContacts> GetContactsById(int id)
        {
            if (_patientModuleContext != null)
                return await _patientModuleContext.PatientEmergencyContacts.FirstOrDefaultAsync(x => x.PatientId == id);
            else
                return null;
        }

        public async Task<int> UpdateContactDetails(int id, PatientEmergencyContacts model)
        {
            if (_patientModuleContext != null)
            {
                var result = await _patientModuleContext.PatientEmergencyContacts.FirstOrDefaultAsync(x => x.PatientId == id);

                if (result != null)
                {
                    result.FirstName = model.FirstName;
                    result.LastName = model.LastName;
                    result.Relationship = model.Relationship;
                    result.EmailId = model.EmailId;
                    result.Contact = model.Contact;
                    result.Address = model.Address;
                    result.updated_by = model.updated_by;
                    result.updated_on = DateTime.Now;

                    _patientModuleContext.PatientEmergencyContacts.Update(result);
                    return await _patientModuleContext.SaveChangesAsync();
                }
            }
            return 0;
        }
    }
}
