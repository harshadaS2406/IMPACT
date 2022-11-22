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
    public class PatientVisitVitalsController : ControllerBase
    {
        private readonly IVisitVitalsRepo _visitVitalsRepo;

        public PatientVisitVitalsController(IVisitVitalsRepo visitVitalsRepo)
        {
            _visitVitalsRepo = visitVitalsRepo;
        }

        [HttpGet("GetAllVitals")]
        public async Task<object> GetAllVitalsDetails()
        {
            var result = await _visitVitalsRepo.GetAllVitalsDetails();
            if (result != null)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", result));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error while retrieving ", result));
        }

        //[HttpGet("GetAllVitalsByPatientId/{patientId}")]
        //public async Task<object> GetAllVitalsDetails(int patientId)
        //{
        //    var result = await _visitVitalsRepo.GetAllVitalsDetails(patientId);
        //    if (result != null)
        //    {
        //        return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", result));
        //    }
        //    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error while retrieving ", result));
        //}

        [HttpGet("GetVitalsById/{vitalsId}")]
        public async Task<object> GetVitalsById(int vitalsId)
        {
            var result = await _visitVitalsRepo.GetVitalsById(vitalsId);
            if (result != null)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", result));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error while retrieving ", result));
        }

        [HttpPost("AddVitals")]
        public async Task<object> AddVitalsDetails([FromBody] PatientVitals model)
        {
            var result = await _visitVitalsRepo.AddVitalsDetails(model);
            if (result > 0)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Details Added", null));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error in adding details", result));
        }

        [HttpPut("updateVitals/{id}")]
        public async Task<object> UpdateVitalsDetails(int id, [FromBody] PatientVitals model)
        {
            var result = await _visitVitalsRepo.UpdateVitalsDetails(id, model);
            if (result > 0)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Updated Details added ", null));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error in updating details", result));
        }
    }
}
