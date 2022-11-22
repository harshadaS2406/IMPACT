using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModuleService.Models
{
    public class DrugDataDetails
    {
        [Key]
        public int DrugId { get; set; }
        public string DrugName { get; set; }
        public string DrugGenericName { get; set; }
        public string DrugManufactureName { get; set; }
        public string DrugForm { get; set; }
        public string DrugStrength { get; set; }

    }
}
