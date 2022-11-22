using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LoginService.Models;

namespace PatientModuleService.Models
{
    public class PatientEmergencyContacts
    {
        [Key]
        public int PatientEmergencyContactId { get; set; }

        [ForeignKey("Users")]
        public int PatientId { get; set; }
        public ApplicationUser Users { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Relationship { get; set; }
        public string EmailId { get; set; }
        public long Contact { get; set; }
        public string Address { get; set; }
        public int created_by { get; set; }
        public DateTime created_on { get; set; }
        public int updated_by { get; set; }
        public DateTime updated_on { get; set; }
    }
}
