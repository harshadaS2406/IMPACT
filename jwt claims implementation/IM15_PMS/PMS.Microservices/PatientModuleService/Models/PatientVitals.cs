using LoginService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModuleService.Models
{
    public class PatientVitals
    {
        [Key]
        public int VisitVitalId { get; set; }

        [ForeignKey("Appointments")]
        public int VisitId { get; set; }
        public Appointments Appointments { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string BloodPressure { get; set; }
        public string BodyTemperature { get; set; }
        public string RespirationRate { get; set; }
        public int createdby { get; set; }
        public DateTime createdon { get; set; }
        public int updatedby { get; set; }
        public DateTime updatedon { get; set; }
    }
}
