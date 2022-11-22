using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModuleService.Models
{
    public class DiagnosisDetails
    {
        [Key]
        public int DiagnosisId { get; set; }
        public string DiagnosisCode { get; set; }
        public string DiagnosisDescription { get; set; }
        public bool DiagnosisIsDepricated { get; set; }

    }
}
