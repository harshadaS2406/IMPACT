using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InboxService.Models
{
    public class AppointmentListRepo : IAppointmentListRepo
    {
        public Task<AppointmentDetails> Appointmentlist(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DashboardAppointmentListCount(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AppointmentDetails> UpdateAppointmentlist(int id, AppointmentDetails appointmentDetails)
        {
            throw new NotImplementedException();
        }
    }
}
