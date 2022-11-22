using LoginService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModuleService.Models
{
    public class PatientMedication
    {
        [Key]
        public int PatientMedicationId { get; set; }

        [ForeignKey("Appointments")]
        public int VisitId { get; set; }
        public Appointments Appointments { get; set; }

        [ForeignKey("DrugDataDetails")]
        public int DrugId { get; set; }
        public DrugDataDetails DrugDataDetails { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public int createdby { get; set; }
        public DateTime createdon { get; set; }
        public int updatedby { get; set; }
        public DateTime updatedon { get; set; }
    }
}
