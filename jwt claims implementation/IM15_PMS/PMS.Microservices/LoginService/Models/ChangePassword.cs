using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Models
{
    public class ChangePassword
    {
        [Required]
        public string currentpassword { get; set; }

        [Required]
        public string newpassword { get; set; }

        [Required]
        [Compare("newpassword",ErrorMessage ="Password does not match")]
        public string confirmpassword { get; set; }

    }
}
