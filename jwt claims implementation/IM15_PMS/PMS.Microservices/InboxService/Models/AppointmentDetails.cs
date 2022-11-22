using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InboxService.Models
{
    public class AppointmentDetails
    {
        [Key]
        public int VisitId { get; set; }
        public string VisitTitle { get; set; }
        public string VisitDescription { get; set; }

        // [ForeignKey("userid")]
        public int doctorId { get; set; }
        // public UserLogin users { get; set; }
        // [ForeignKey("userid")]
        public int patientId { get; set; }
        public DateTime visitDate { get; set; }
        public DateTime visitTime { get; set; }
        public string createdBy { get; set; }
        public DateTime createdOn { get; set; }
        public string updatedBy { get; set; }
        public DateTime updatedOn { get; set; }

        [ForeignKey("VisitStatus")]
        public int visitStatusId { get; set; }
        public VisitStatus VisitStatus { get; set; }
    }
}
