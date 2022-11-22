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
    public class PatientDiagnosisController : ControllerBase
    {
        private readonly IPatientDiagnosisRepo _patientDiagnosis;
        private readonly IDiagnosisDetailsRepo _diagnosisDetailsRepo;

        public PatientDiagnosisController(IPatientDiagnosisRepo patientDiagnosis, IDiagnosisDetailsRepo diagnosisDetailsRepo)
        {
            _patientDiagnosis = patientDiagnosis;
            _diagnosisDetailsRepo = diagnosisDetailsRepo;
        }

        [HttpGet("GetAllDiagnosis")]
        public async Task<object> GetAllDiagnosis()
        {
            var result = await _patientDiagnosis.GetAllDiagnosis();

            if (result != null)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", result));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error while retrieving ", result));
        }

        [HttpPost("AddDiagnosis")]
        public async Task<object> AddDiagnosis([FromBody] PatientDiagnosis model)
        {
            var result = await _patientDiagnosis.AddDiagnosis(model);
            if (result > 0)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Details Added", null));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error in adding details", result));
        }

        [HttpGet("GetAllDiagnosisDetails")]
        public async Task<object> GetAllDiagnosisDetails()
        {
            var result = await _diagnosisDetailsRepo.GetAllDiagnosisDetails();

            if (result != null)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", result));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error while retrieving ", result));
        }

        [HttpGet("GetDiagnosis/{id}")]

        public async Task<object> GetAllDiagnosibyId(int id)
        {
            var result = await _patientDiagnosis.GetDiagnosisById(id);

            if (result != null)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", result));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error while retrieving ", result));
        }
    }
}
