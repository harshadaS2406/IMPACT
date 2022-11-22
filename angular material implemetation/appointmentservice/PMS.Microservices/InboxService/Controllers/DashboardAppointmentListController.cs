using InboxService.Models;
using InboxService.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InboxService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardAppointmentListController : ControllerBase
    {
        private readonly IAppointmentListRepo _appointmentListRepo;

        public DashboardAppointmentListController(IAppointmentListRepo appointmentListRepo)
        {
            _appointmentListRepo = appointmentListRepo;
        }

        [HttpGet("GetAppointmentCount/{id}/{roleid}")]
        public async Task<object> GetDashboardAppointmentCount(int id, int roleid)
        {
            var result = await _appointmentListRepo.DashboardAppointmentListCount(id, roleid);

            if (result != null)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", result));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "no appointment count", result));
        }

        [HttpGet("GetAppointmentlist/{id}")]
        public async Task<object> GetAppointmentlist(int id)
        {
            var result = await _appointmentListRepo.Appointmentlist(id);

            if (result != null)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", result));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "no appointments found", result));
        }

        [HttpPut]
        [Route("UpdateAppointment")]
        public async Task<object> UpdateAppointment([FromBody] UpdateAppointmentModel updateAppointment)
        {
            var result = await _appointmentListRepo.UpdateAppointmentlist(updateAppointment);
            if (result > 0)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", result));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error while retrieving ", result));
        }

        [HttpGet("GetAppointmentHistory/{id}/{roleid}")]
        public async Task<object> GetDashboardTotalAppointmentHistory(int id, int roleid)
        {
            var result = await _appointmentListRepo.DashboardTotalAppointmentHistory(id, roleid);

            if (result != null)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", result));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "no appointment count", result));
        }
    }
}
