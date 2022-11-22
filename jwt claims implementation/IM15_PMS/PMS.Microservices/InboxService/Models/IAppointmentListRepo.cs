using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InboxService.Models
{
    public interface IAppointmentListRepo
    {
        Task<int> DashboardAppointmentListCount(int id);

        Task<AppointmentDetails> Appointmentlist(int id);

        Task<AppointmentDetails> UpdateAppointmentlist(int id, AppointmentDetails appointmentDetails);
    }
}
