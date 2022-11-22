using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Models
{
    public class UserRegistration
    {

        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; }

        public string PhoneNumber { get; set; }

        public int GenderID { get; set; }

        public int? RoleId { get; set; }

        public string DOB { get; set; }

        public string Address { get; set; }


    }
}
