using LoginService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModuleService.Models
{
    public class PatientAllergyDetails
    {
        [Key]
        public int PatientAllergyDetailsId { get; set; }

        [ForeignKey("Users")]
        public int PatientId { get; set; }
        public ApplicationUser Users { get; set; }

        [ForeignKey("AllergyDetails")]
        public int Allergyid { get; set; }
        public AllergyDetails AllergyDetails { get; set; }

        //[ForeignKey("Appointments")]
        //public int VisitId { get; set; }
        //public Appointments Appointments { get; set; }
        public bool Is_Allergy_Fatal { get; set; }
        public string Allergy_Clinical_Information { get; set; }
        public int created_by { get; set; }
        public DateTime created_on { get; set; }
        public int updated_by { get; set; }
        public DateTime updated_on { get; set; }
    }
}
