using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Models
{
    public class ForgotPassword
    {
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
    }
}
