using LoginService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModuleService.Models
{
    public class PatientDiagnosis
    {
        [Key]
        public int PatientDiagnosisId { get; set; }

        [ForeignKey("Appointments")]
        public int VisitId { get; set; }
        public Appointments Appointments { get; set; }

        [ForeignKey("DiagnosisDetails")]
        public int DiagnosisId { get; set; }
        public DiagnosisDetails DiagnosisDetails { get; set; }
        public string Description { get; set; }
        public int createdby { get; set; }
        public DateTime created_on { get; set; }
        public int updated_by { get; set; }
        public DateTime updated_on { get; set; }
    }
}
