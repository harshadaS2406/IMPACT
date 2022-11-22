using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModuleService.Models
{
    public class ProcedureDetails
    {
        [Key]
        public int ProcedureId { get; set; }
        public string ProcedureCode { get; set; }
        public string ProcedureDescription { get; set; }
        public bool ProcedureIsDepricated { get; set; }

    }
}
