using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Models
{
    public class ApplicationUser : IdentityUser<int>
    {

        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int GenderID { get; set; }

        [ForeignKey("GenderID")]
        public Gender Gender { get; set; }

        public string Race { get; set; }

        public string LanguagesKnown { get; set; }

        public string Ethinicity { get; set; }
        public int StatusID { get; set; }

        [ForeignKey("StatusID")]
        public Status Status { get; set; }


        [ForeignKey("RoleID")]
        public virtual ApplicationRole Role { get; set; }

        public int? RoleID { get; set; }
         
        public string Address { get; set; }
        public DateTime DOB { get; set; }

        public bool IsPasswordChanged { get; set; }

    }

    public class ApplicationRole : IdentityRole<int>
    {

    }
}
