using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Models
{
    public class Status
    {
        [Key]
        public int StatusID { get; set; }

        public string StatusName { get; set; }

        public string StatusCode { get; set; }


        public ICollection<Users> Users { get; set; }
    }
}
