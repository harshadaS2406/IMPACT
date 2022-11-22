using LoginService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModuleService.Models
{
    public class Appointments
    {
        [Key]
        public int VisitId { get; set; }
        public string VisitTitle { get; set; }
        public string VisitDescription { get; set; }

        // [ForeignKey("UserID")]
        //public int DoctorID { get; set; }
        //public UserLogin Users { get; set; }
        //[ForeignKey("UserID")]
        //public int PatientID { get; set; }
        //public string VisitTitle { get; set; }
        //public string VisitDescription { get; set; }
        //public DateTime VisitDate { get; set; }
        //public DateTime VisitTime { get; set; }
        //public string VisitReason { get; set; }
        //[ForeignKey("UserID")]
        //public string createdby { get; set; }
        //public DateTime created_on { get; set; }
        //[ForeignKey("UserID")]
        //public string updated_by { get; set; }
        //public DateTime updated_on { get; set; }
        //public string visitstatus { get; set; }


    }
}
