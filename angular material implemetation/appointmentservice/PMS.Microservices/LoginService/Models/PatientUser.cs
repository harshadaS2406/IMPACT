using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Models
{
    public class PatientUser
    {

        public int UserId { get; set; }
        public string PatientName { get; set; }


        public string DOR { get; set; }
        public string Status { get; set; }

        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string PhoneNumber { get; set; }

        public int GenderID { get; set; }

        public int? RoleId { get; set; }

        public int StatusId { get; set; }
        public string DOB { get; set; }



    }
}
