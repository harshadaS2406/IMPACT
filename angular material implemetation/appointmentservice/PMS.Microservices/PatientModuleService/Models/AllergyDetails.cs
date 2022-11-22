using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModuleService.Models
{
    public class AllergyDetails
    {
        [Key]
        public int AllergyDetailsId { get; set; }
        public string AllergyId { get; set; }
        public string AllergyType { get; set; }
        public string AllergyName { get; set; }
        public string AllergyDescription { get; set; }
        public string AllergyClinicalInformation { get; set; }
    }
}
