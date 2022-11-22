using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }

        public int GenderID { get; set; }

        [ForeignKey("GenderID")]
        public Gender Gender { get; set; }

        public int RoleID { get; set; }

        [ForeignKey("RoleID")]
        public Roles Roles { get; set; }


        public int StatusID { get; set; }

        [ForeignKey("StatusID")]
        public Status Status { get; set; }

        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public string Password { get; set; }
        public string ContactNo { get; set; }


        

        public DateTime LastLogin { get; set; }
        public int LoginAttempts { get; set; }
        public int created_by { get; set; } 
        public DateTime created_on { get; set; }
        public int updated_by { get; set; }
        public DateTime updated_on { get; set; }
    }
}
