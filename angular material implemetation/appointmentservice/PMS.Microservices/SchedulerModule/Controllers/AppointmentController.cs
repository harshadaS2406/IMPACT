using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchedulerModule.Models;
using SchedulerModule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SchedulerModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentDetailsRepo _appointmentDetailsRepo;

        public AppointmentController(IAppointmentDetailsRepo appointmentDetailsRepo)
        {
            _appointmentDetailsRepo = appointmentDetailsRepo;
        }

        [HttpGet]
        public async Task<object> getAppointmentDetails()
        {
            return await _appointmentDetailsRepo.GetAllAppointmentDetails();
        }

        [HttpGet("{id}")]
        public async Task<AppointmentDetails> getAppointmentById(int id)
        {
            AppointmentDetails appointment = await _appointmentDetailsRepo.GetAppointmentDetailById(id);

            if (appointment == null)
            {
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No Appointment exist with Id : {0}", id)),
                    ReasonPhrase = "Appointment not found with the ID"
                };
                throw new System.Web.Http.HttpResponseException(response);
            }
            return appointment;
        }


        [HttpGet("user/{id}")]
        public async Task<List<AppointmentDetails>> getAppointmentUser(int id)
        {
            List<AppointmentDetails> appointment = await _appointmentDetailsRepo.GetAppointmentsByUser(id);

            if (appointment == null)
            {
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No User exist with Id : {0}", id)),
                    ReasonPhrase = "User not found with the ID"
                };
                throw new System.Web.Http.HttpResponseException(response);
            }
            return appointment;
        }

        [HttpGet("userAppointments/{userId}/{roleId}")]
        public async Task<object> GetAppointmentsByUserLoad(int userId, int roleId)
        {
            var result = await _appointmentDetailsRepo.GetAppointmentsLoad(userId, roleId);

            if (result == null)
            {
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No User exist with Id : {0}", userId)),
                    ReasonPhrase = "User not found with the ID"
                };
                throw new System.Web.Http.HttpResponseException(response);
            }
            return result;
        }


        [HttpGet("Availableslots/{date}/{id}")]

        public async Task<object> GetSlots(DateTime date, int id)
        {
            var result = await _appointmentDetailsRepo.GetSlots(date, id);
            if (result == null)
            {
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No Appointment exist with Id : {0}", id)),
                    ReasonPhrase = "Appointment not found with the ID"
                };
                throw new System.Web.Http.HttpResponseException(response);
            }
            return result;
        }


        [HttpPost]
        public async Task addAppointmentDetails([FromBody] AppointmentDetails appointmentDetails)
        {
            await _appointmentDetailsRepo.AddAppointmentDetails(appointmentDetails);
            
        }


        [HttpPut("{id}")]
        public async Task<AppointmentDetails> updateAppointmentDetails(int id , [FromBody] AppointmentDetails appointment)
        {
            var appointmentToUpdate = await _appointmentDetailsRepo.UpdateAppointmentDetails(id, appointment);

            if (!_appointmentDetailsRepo.IsAppointmentAvailable(id))
            {
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Appointment detail does not exist with Id : {0} ", id)),
                    ReasonPhrase = "Appointment details can not be updated since we do not appointment with the provided Id"
                };
                throw new System.Web.Http.HttpResponseException(response);
            }
            return appointment ;
        }

        [HttpDelete("{id}")]
         public string deleteAppointmentDetails(int id)
        {
            var appointToDelete = _appointmentDetailsRepo.GetAppointmentDetailById(id).Result;
           if(!_appointmentDetailsRepo.IsAppointmentAvailable(id) && appointToDelete==null)
            {
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No appointment found with the Id : {0}", id)),
                    ReasonPhrase = "Appointment does not exist to be deleted"
                };
            }
            _appointmentDetailsRepo.DeleteAppointmentDetails(appointToDelete);
            
            return "Record has been deleted";
        }

        [HttpPut("Decline/{id}")]
        public async Task<string> declineAppointmentDetails(int id)
        {
            var res = await _appointmentDetailsRepo.DeclineAppointment(id);
            //var appointToDelete = _appointmentDetailsRepo.GetAppointmentDetailById(id).Result;
            if (res <= 0)
            {
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No appointment found with the Id : {0}", id)),
                    ReasonPhrase = "Appointment does not exist to be declined"
                };
            }

            return "Record has been declined";
        }

        [HttpPut("Accept/{id}")]
        public  async Task<string> AcceptAppointmentDetails(int id)
        {
            var res =  await _appointmentDetailsRepo.AcceptAppointment(id);
            //var appointToDelete = _appointmentDetailsRepo.GetAppointmentDetailById(id).Result;
            if (res <= 0)
            {
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No appointment found with the Id : {0}", id)),
                    ReasonPhrase = "Appointment does not exist to be accepted"
                };
            }
            

            return "appointment has been accepted";
        }








    }
}
