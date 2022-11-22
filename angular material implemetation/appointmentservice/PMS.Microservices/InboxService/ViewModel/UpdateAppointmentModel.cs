using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InboxService.ViewModel
{
    public class UpdateAppointmentModel
    {
        public int AppointmentId { get; set; }
        public int UpdateType { get; set; }
        public int UserId { get; set; }
        public int roleId { get; set; }
    }
}
