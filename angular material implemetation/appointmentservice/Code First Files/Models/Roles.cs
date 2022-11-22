using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Models
{
    public class Roles
    {
        [Key]
        public int RoleID { get; set; }

        public string RoleName { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
