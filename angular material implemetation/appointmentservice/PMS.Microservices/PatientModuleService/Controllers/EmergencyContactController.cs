using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientModuleService.Models;
using PatientModuleService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModuleService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmergencyContactController : ControllerBase
    {
        private readonly IEmergencyContactRepo _emergencyContactRepo;
        public EmergencyContactController(IEmergencyContactRepo emergencyContactRepo)
        {
            _emergencyContactRepo = emergencyContactRepo;
        }

        [HttpGet("allContacts")]
        public async Task<object> GetAllContactDetails()
        {
            var result = await _emergencyContactRepo.GetAllContactDetails();

            if (result != null)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", result));
            }

            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error while retrieving ", result));
        }

        [HttpPost("addContacts")]
        public async Task<object> AddContactDetails([FromBody] PatientEmergencyContacts model)
        {
            var result = await _emergencyContactRepo.AddContactDetails(model);
            if (result > 0)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Details Added", null));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error in adding details", result));
        }

        [HttpPut("updateContacts/{id}")]
        public async Task<object> UpdateContactDetails(int id, [FromBody] PatientEmergencyContacts model)
        {
            var result = await _emergencyContactRepo.UpdateContactDetails(id, model);
            if (result > 0)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Updated Details added ", null));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error in updating details", result));
        }

        [HttpGet("ContactsById/{id}")]
        public async Task<object> GetContactDetailsById(int id)
        {
            var result = await _emergencyContactRepo.GetContactsById(id);
            if (result != null)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", result));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error while retrieving ", result));
        }
    }
}
