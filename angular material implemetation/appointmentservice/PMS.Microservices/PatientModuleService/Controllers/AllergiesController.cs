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
    public class AllergiesController : ControllerBase
    {
        private readonly IAllergyDetailsRepo _allergyDetailsRepo;

        public AllergiesController(IAllergyDetailsRepo allergyDetailsRepo)
        {
            _allergyDetailsRepo = allergyDetailsRepo;
        }

        [HttpGet("GetAllAllergies")]
        public async Task<object> GetAllAllergies()
        {
            var result = await _allergyDetailsRepo.GetAllAllergy();
            if (result != null)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", result));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error while retrieving ", result));
        }

        [HttpGet("GetAllergyDetails")]
        public async Task<object> GetAllergiesDetails()
        {
            var result = await _allergyDetailsRepo.GetAllergiesDetails();
            if (result != null)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", result));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error while retrieving ", result));
        }

        [HttpPost("addAllergies")]
        public async Task<object> AddAllergyDetails([FromBody] PatientAllergyDetails model)
        {
            var result = await _allergyDetailsRepo.AddAllergyDetails(model);
            if (result > 0)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Details Added", null));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error in adding details", result));
        }

        [HttpPut("updateAllergies/{id}")]
        public async Task<object> UpdateAllergyDetails(int id, [FromBody] PatientAllergyDetails model)
        {
            var result = await _allergyDetailsRepo.UpdateAllergyDetails(id, model);
            if (result > 0)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Updated Details added ", null));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error in updating details", result));
        }

        [HttpGet("GetAllergiesById/{Id}")]
        public async Task<object> GetAllergiesById(int Id)
        {
            var result = await _allergyDetailsRepo.GetAllergiesById(Id);
            if (result != null)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", result));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error while retrieving ", result));
        }
    }
}
