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

        [HttpGet("GetAppointmentCount/{id}")]
        public async Task<object> GetDashboardAppointmentCount(int id)
        {
            var result = await _appointmentListRepo.DashboardAppointmentListCount(id);

            if (result > 0)
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
    }
}
