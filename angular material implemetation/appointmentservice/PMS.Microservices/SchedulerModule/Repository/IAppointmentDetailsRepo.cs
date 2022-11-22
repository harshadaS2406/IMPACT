using SchedulerModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerModule.Repository
{
   public interface IAppointmentDetailsRepo
    {
        Task<List<AppointmentDetails>> GetAllAppointmentDetails();
        Task<int> AddAppointmentDetails(AppointmentDetails AppointmentModel);
        Task<int> UpdateAppointmentDetails(int id, AppointmentDetails appointmentDetailsModel);
        void DeleteAppointmentDetails(AppointmentDetails appointment);
        Task<AppointmentDetails> GetAppointmentDetailById(int id);
        Task<AppointmentDetails> GetAppointmentDetailByIdAndRoleId(int id,int roleId);
        Task<List<Slots>> GetSlots(DateTime dateTime,int id);
        Task<List<AppointmentDetails>> GetAppointmentsByUser(int userId);
        Task<List<ViewAppointmentModels>> GetAppointmentsLoad(int id, int roleId);
        Task<int> DeclineAppointment(int id);
        Task<int> AcceptAppointment(int id);
        bool IsAppointmentAvailable(int visitId);
    }
}
