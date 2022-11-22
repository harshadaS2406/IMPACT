using SchedulerModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InboxService.ViewModel
{
    public class ViewAppointmentModel : AppointmentDetails
    {
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string VisitStatusName { get; set; }
        public string BackColor { get; set; }
    }
}
