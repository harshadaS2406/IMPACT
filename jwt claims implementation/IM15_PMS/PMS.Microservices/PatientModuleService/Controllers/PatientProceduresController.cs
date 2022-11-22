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
    public class PatientProceduresController : ControllerBase
    {
        private readonly IPatientProceduresRepo _PatientProceduresRepo;
        private readonly IProcedureDetailsRepo _ProcedureDetailsRepo;
        public PatientProceduresController(IPatientProceduresRepo PatientProceduresRepo, IProcedureDetailsRepo ProcedureDetailsRepo)
        {
            _PatientProceduresRepo = PatientProceduresRepo;
            _ProcedureDetailsRepo = ProcedureDetailsRepo;
        }

        [HttpGet("GetAllPatientProcedures")]
        public async Task<object> GetAllProcedures()
        {
            var result = await _PatientProceduresRepo.GetAllPatientProcedures();
            if (result != null)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", result));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error while retrieving ", result));
        }

        [HttpPost("AddProcedure")]
        public async Task<object> AddProcedure([FromBody] PatientProcedures model)
        {
            var result = await _PatientProceduresRepo.AddProcedure(model);
            if (result > 0)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Details Added", null));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error in adding details", result));
        }


        [HttpGet("GetProcedure/{id}")]

        public async Task<object> GetProdcedureById(int id)
        {
            var result = await _PatientProceduresRepo.GetProdcedureById(id);

            if (result != null)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", result));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error while retrieving ", result));
        }

        [HttpGet("GetAllProcedureDetails")]
        public async Task<object> GetAllProcedureDetails()
        {
            var result = await _ProcedureDetailsRepo.GetAllProcedureDetails();

            if (result != null)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", result));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error while retrieving ", result));
        }
    }
}
