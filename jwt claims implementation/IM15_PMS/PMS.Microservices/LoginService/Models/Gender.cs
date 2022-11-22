using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Models
{
    public class Gender
    {
        [Key]
        public int GenderID { get; set; }

        public string GenderName { get; set; }

        public string GenderCode { get; set; }

       public ICollection<UserLogin> Users { get; set; }

    }
}
