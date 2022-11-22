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
    public class PatientMedicationController : ControllerBase
    {
        private readonly IPatientMedicationRepo _PatientMedicationRepo;
        private readonly IDrugDataDetailsRepo _DrugDataDetailsRepo;
        public PatientMedicationController(IPatientMedicationRepo PatientMedicationRepo, IDrugDataDetailsRepo DrugDataDetailsRepo)
        {
            _PatientMedicationRepo = PatientMedicationRepo;
            _DrugDataDetailsRepo = DrugDataDetailsRepo;


        }

        [HttpPost("AddMedication")]
        public async Task<object> AddMedication([FromBody] PatientMedication model)
        {
            var result = await _PatientMedicationRepo.AddMedication(model);
            if (result > 0)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Details Added", null));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error in adding details", result));
        }

        [HttpGet("GetAllPatientMedication")]
        public async Task<object> GetAllPatientMedication()
        {
            var result = await _PatientMedicationRepo.GetAllPatientMedication();
            if (result != null)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", result));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error while retrieving ", result));
        }

        [HttpGet("GetMedication/{id}")]

        public async Task<object> GetMedicationById(int id)
        {
            var result = await _PatientMedicationRepo.GetMedicationById(id);

            if (result != null)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", result));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error while retrieving ", result));
        }

        [HttpGet("GetAllPatientDrugDetails")]
        public async Task<object> GetAllPatientDrugDetails()
        {
            var result = await _DrugDataDetailsRepo.GetAllPatientDrugDetails();

            if (result != null)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", result));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error while retrieving ", result));
        }
    }
}
